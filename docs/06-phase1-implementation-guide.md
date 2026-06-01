# OmniPOS — Guía de Implementación Fase 1

> Guía paso a paso para implementar Clean Architecture desde cero en el backend de OmniPOS, sin crear un proxy temporal de `POS.DLL`.

---

## Contexto

En lugar de hacer un proxy que envuelva `POS.DLL` (enfoque temporal), vamos a construir el backend con arquitectura limpia desde el inicio. Esto significa:

- ✅ **POS.Domain**: Entidades puras, interfaces, value objects, enums.
- ✅ **Domain.Application**: Services (casos de uso), DTOs, validadores.
- ✅ **POS.Infrastructure**: Repositorios EF Core, servicios externos, acceso a SPs.
- ✅ **POS.Api**: Controllers, middleware, autenticación JWT, Swagger.
- ❌ **NO** referenciar `POS.DLL` desde la nueva API.

---

## Fase 1.1 — Preparar la Infraestructura Base

### 1.1.1 — Configurar POS.Domain

#### Crear estructura de carpetas

```
POS.Domain/
├── Entities/
├── Interfaces/
│   ├── Repositories/
│   └── Services/
├── ValueObjects/
└── Enums/
```

#### Definir entidades de dominio

**Customer.cs** (ejemplo):

```csharp
namespace POS.Domain.Entities;

public class Customer
{
	public long CustomerId { get; set; }
	public string Identification { get; set; }
	public string IdentTypeId { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Email { get; set; }
	public string Phone { get; set; }
	public bool UseRetention { get; set; }
	public string Status { get; set; }
	public DateTime CreatedDate { get; set; }
	public DateTime? ModifiedDate { get; set; }

	// Navigation properties
	public ICollection<CustomerAddress> Addresses { get; set; }
}
```

**Reglas importantes**:
- No usar anotaciones de Entity Framework (`[Key]`, `[Required]`, etc.).
- No referenciar `System.ComponentModel.DataAnnotations`.
- Las entidades deben ser **independientes de cualquier tecnología**.

#### Crear Value Objects

**Identification.cs**:

```csharp
namespace POS.Domain.ValueObjects;

public class Identification
{
	public string Value { get; }
	public IdentificationType Type { get; }

	private Identification(string value, IdentificationType type)
	{
		Value = value;
		Type = type;
	}

	public static Identification Create(string value, IdentificationType type)
	{
		if (string.IsNullOrWhiteSpace(value))
			throw new ArgumentException("Identification cannot be empty");

		return type switch
		{
			IdentificationType.CI when value.Length != 10 => 
				throw new ArgumentException("CI must be 10 digits"),
			IdentificationType.RUC when value.Length != 13 => 
				throw new ArgumentException("RUC must be 13 digits"),
			_ => new Identification(value, type)
		};
	}
}
```

**Money.cs**:

```csharp
namespace POS.Domain.ValueObjects;

public class Money
{
	public decimal Amount { get; }
	public string Currency { get; }

	public Money(decimal amount, string currency = "USD")
	{
		if (amount < 0)
			throw new ArgumentException("Amount cannot be negative");

		Amount = amount;
		Currency = currency;
	}

	public static Money operator +(Money a, Money b)
	{
		if (a.Currency != b.Currency)
			throw new InvalidOperationException("Cannot add money with different currencies");

		return new Money(a.Amount + b.Amount, a.Currency);
	}
}
```

#### Crear interfaces de repositorio

**ICustomerRepository.cs**:

```csharp
namespace POS.Domain.Interfaces.Repositories;

public interface ICustomerRepository
{
	Task<Customer?> GetByIdAsync(long customerId, CancellationToken cancellationToken = default);
	Task<Customer?> GetByIdentificationAsync(string identification, CancellationToken cancellationToken = default);
	Task<Customer> CreateAsync(Customer customer, CancellationToken cancellationToken = default);
	Task<Customer> UpdateAsync(Customer customer, CancellationToken cancellationToken = default);
	Task<IEnumerable<CustomerAddress>> GetAddressesAsync(long customerId, CancellationToken cancellationToken = default);
	Task<CustomerAddress> AddAddressAsync(CustomerAddress address, CancellationToken cancellationToken = default);
	Task<CustomerAddress> UpdateAddressAsync(CustomerAddress address, CancellationToken cancellationToken = default);
}
```

**IInvoiceRepository.cs**:

```csharp
namespace POS.Domain.Interfaces.Repositories;

public interface IInvoiceRepository
{
	Task<Invoice?> GetByIdAsync(long invoiceId, CancellationToken cancellationToken = default);
	Task<Invoice> CreateAsync(Invoice invoice, CancellationToken cancellationToken = default);
	Task<bool> CancelAsync(long invoiceId, string cancelReason, long supervisorId, CancellationToken cancellationToken = default);
	Task<IEnumerable<InvoiceTicketLine>> GetTicketAsync(long invoiceId, CancellationToken cancellationToken = default);
	Task<SuspendedSale?> GetSuspendedSaleAsync(long emissionPointId, CancellationToken cancellationToken = default);
	Task<bool> SuspendSaleAsync(Invoice invoice, CancellationToken cancellationToken = default);
}
```

#### Mover enumeraciones

Mover todos los enums de `POS.DLL/Enums/` a `POS.Domain/Enums/`:

```csharp
// POS.Domain/Enums/PaymentMode.cs
namespace POS.Domain.Enums;

public enum PaymentMode
{
	Cash = 1,
	Card = 2,
	Check = 3,
	InternalCredit = 4,
	GiftCard = 5,
	Withhold = 6,
	Advance = 7,
	Return = 8
}
```

---

### 1.1.2 — Configurar Domain.Application

#### Crear estructura de carpetas

```
Domain.Application/
├── Services/
├── DTOs/
│   ├── Requests/
│   └── Responses/
└── Validators/
```

#### Crear DTOs

**LoginRequest.cs**:

```csharp
namespace Domain.Application.DTOs.Requests;

public record LoginRequest(
	string Username,
	string Password,
	string Workstation,
	string IpAddress
);
```

**LoginResponse.cs**:

```csharp
namespace Domain.Application.DTOs.Responses;

public record LoginResponse(
	bool Success,
	string? Token,
	string? ErrorMessage,
	UserInfo? UserInfo,
	EmissionPointInfo? EmissionPoint,
	IEnumerable<GlobalParameter>? GlobalParameters
);

public record UserInfo(long UserId, string Username, string FullName, string Role);
public record EmissionPointInfo(long Id, string Code, string Location);
```

**CreateCustomerRequest.cs**:

```csharp
namespace Domain.Application.DTOs.Requests;

public record CreateCustomerRequest(
	string Identification,
	string IdentTypeId,
	string FirstName,
	string LastName,
	string? Email,
	string? Phone,
	string? Address,
	long CustomerTypeId
);
```

**CustomerResponse.cs**:

```csharp
namespace Domain.Application.DTOs.Responses;

public record CustomerResponse(
	long CustomerId,
	string Identification,
	string IdentType,
	string FirstName,
	string LastName,
	string? Email,
	string? Phone,
	bool UseRetention,
	string Status
);
```

#### Crear validadores con FluentValidation

Instalar paquete:

```bash
dotnet add Domain.Application package FluentValidation
dotnet add Domain.Application package FluentValidation.DependencyInjectionExtensions
```

**LoginRequestValidator.cs**:

```csharp
namespace Domain.Application.Validators;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
	public LoginRequestValidator()
	{
		RuleFor(x => x.Username)
			.NotEmpty().WithMessage("Username is required")
			.MaximumLength(50);

		RuleFor(x => x.Password)
			.NotEmpty().WithMessage("Password is required")
			.MinimumLength(4);

		RuleFor(x => x.Workstation)
			.NotEmpty().WithMessage("Workstation name is required");

		RuleFor(x => x.IpAddress)
			.NotEmpty().WithMessage("IP address is required")
			.Matches(@"^(\d{1,3}\.){3}\d{1,3}$")
			.WithMessage("Invalid IP address format");
	}
}
```

**CreateCustomerRequestValidator.cs**:

```csharp
namespace Domain.Application.Validators;

public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
{
	public CreateCustomerRequestValidator()
	{
		RuleFor(x => x.Identification)
			.NotEmpty().WithMessage("Identification is required")
			.Must((req, id) => ValidateIdentificationFormat(id, req.IdentTypeId))
			.WithMessage("Invalid identification format");

		RuleFor(x => x.FirstName)
			.NotEmpty().WithMessage("First name is required")
			.MaximumLength(100);

		RuleFor(x => x.LastName)
			.NotEmpty().WithMessage("Last name is required")
			.MaximumLength(100);

		RuleFor(x => x.Email)
			.EmailAddress().When(x => !string.IsNullOrEmpty(x.Email))
			.WithMessage("Invalid email format");
	}

	private bool ValidateIdentificationFormat(string identification, string identTypeId)
	{
		return identTypeId switch
		{
			"CI" => identification.Length == 10 && identification.All(char.IsDigit),
			"RUC" => identification.Length == 13 && identification.All(char.IsDigit),
			"PAS" => identification.Length >= 5 && identification.Length <= 20,
			_ => false
		};
	}
}
```

#### Crear Application Services

**AuthService.cs**:

```csharp
namespace Domain.Application.Services;

public interface IAuthService
{
	Task<LoginResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default);
	Task<bool> ValidateSupervisorAsync(string username, string password, CancellationToken cancellationToken = default);
}

public class AuthService : IAuthService
{
	private readonly IUserRepository _userRepository;
	private readonly IEmissionPointRepository _emissionPointRepository;
	private readonly ITokenService _tokenService;

	public AuthService(
		IUserRepository userRepository,
		IEmissionPointRepository emissionPointRepository,
		ITokenService tokenService)
	{
		_userRepository = userRepository;
		_emissionPointRepository = emissionPointRepository;
		_tokenService = tokenService;
	}

	public async Task<LoginResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken)
	{
		// Validar credenciales
		var user = await _userRepository.ValidateCredentialsAsync(
			request.Username, 
			request.Password, 
			request.Workstation, 
			request.IpAddress, 
			cancellationToken);

		if (user == null)
			return new LoginResponse(false, null, "Invalid credentials or workstation not authorized", null, null, null);

		// Obtener punto de emisión
		var emissionPoint = await _emissionPointRepository.GetByWorkstationAsync(request.Workstation, cancellationToken);
		if (emissionPoint == null)
			return new LoginResponse(false, null, "Emission point not configured for this workstation", null, null, null);

		// Generar token JWT
		var token = _tokenService.GenerateToken(user);

		// Obtener parámetros globales
		var globalParams = await _emissionPointRepository.GetGlobalParametersAsync(cancellationToken);

		return new LoginResponse(
			true,
			token,
			null,
			new UserInfo(user.UserId, user.Username, user.FullName, user.Role),
			new EmissionPointInfo(emissionPoint.Id, emissionPoint.Code, emissionPoint.LocationName),
			globalParams
		);
	}

	public async Task<bool> ValidateSupervisorAsync(string username, string password, CancellationToken cancellationToken)
	{
		return await _userRepository.ValidateSupervisorAsync(username, password, cancellationToken);
	}
}
```

**CustomerService.cs**:

```csharp
namespace Domain.Application.Services;

public interface ICustomerService
{
	Task<CustomerResponse?> GetByIdentificationAsync(string identification, CancellationToken cancellationToken = default);
	Task<CustomerResponse> CreateAsync(CreateCustomerRequest request, CancellationToken cancellationToken = default);
	Task<CustomerResponse> UpdateAsync(long customerId, UpdateCustomerRequest request, CancellationToken cancellationToken = default);
	Task<IEnumerable<CustomerAddressResponse>> GetAddressesAsync(long customerId, CancellationToken cancellationToken = default);
}

public class CustomerService : ICustomerService
{
	private readonly ICustomerRepository _customerRepository;

	public CustomerService(ICustomerRepository customerRepository)
	{
		_customerRepository = customerRepository;
	}

	public async Task<CustomerResponse?> GetByIdentificationAsync(string identification, CancellationToken cancellationToken)
	{
		var customer = await _customerRepository.GetByIdentificationAsync(identification, cancellationToken);
		if (customer == null) return null;

		return MapToResponse(customer);
	}

	public async Task<CustomerResponse> CreateAsync(CreateCustomerRequest request, CancellationToken cancellationToken)
	{
		// Validar si ya existe
		var existing = await _customerRepository.GetByIdentificationAsync(request.Identification, cancellationToken);
		if (existing != null)
			throw new InvalidOperationException($"Customer with identification {request.Identification} already exists");

		var customer = new Customer
		{
			Identification = request.Identification,
			IdentTypeId = request.IdentTypeId,
			FirstName = request.FirstName,
			LastName = request.LastName,
			Email = request.Email,
			Phone = request.Phone,
			CustomerTypeId = request.CustomerTypeId,
			Status = "A",
			CreatedDate = DateTime.UtcNow
		};

		var created = await _customerRepository.CreateAsync(customer, cancellationToken);
		return MapToResponse(created);
	}

	private CustomerResponse MapToResponse(Customer customer)
	{
		return new CustomerResponse(
			customer.CustomerId,
			customer.Identification,
			customer.IdentTypeId,
			customer.FirstName,
			customer.LastName,
			customer.Email,
			customer.Phone,
			customer.UseRetention,
			customer.Status
		);
	}
}
```

---

## Fase 1.2 — Implementar la Capa de Infraestructura

### 1.2.1 — Migrar de EF6 a EF Core 8

#### Instalar paquetes

```bash
cd POS.Infrastructure
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
```

#### Generar el contexto desde la BD existente

```bash
dotnet ef dbcontext scaffold "Server=YOUR_SERVER;Database=YOUR_DB;Integrated Security=true;" Microsoft.EntityFrameworkCore.SqlServer -o Persistence/Models -c PosDbContext --context-dir Persistence
```

Esto generará:
- `Persistence/PosDbContext.cs` (contexto)
- `Persistence/Models/*.cs` (entidades generadas por EF)

#### Configurar el DbContext

```csharp
namespace POS.Infrastructure.Persistence;

public class PosDbContext : DbContext
{
	public PosDbContext(DbContextOptions<PosDbContext> options) : base(options) { }

	// DbSets generados por scaffold
	public DbSet<CustomerModel> Customer { get; set; }
	public DbSet<InvoiceTableModel> InvoiceTable { get; set; }
	public DbSet<ProductModel> Product { get; set; }
	// ... etc

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		// Configuraciones adicionales si es necesario
	}
}
```

**Nota**: Los modelos generados por EF Core (sufijo `Model`) son **modelos de infraestructura**, distintos de las entidades de dominio en `POS.Domain/Entities/`.

### 1.2.2 — Implementar Repositorios

**CustomerRepository.cs**:

```csharp
namespace POS.Infrastructure.Persistence.Repositories;

public class CustomerRepository : ICustomerRepository
{
	private readonly PosDbContext _context;

	public CustomerRepository(PosDbContext context)
	{
		_context = context;
	}

	public async Task<Customer?> GetByIdAsync(long customerId, CancellationToken cancellationToken)
	{
		var model = await _context.Customer
			.Where(c => c.CustomerId == customerId && c.Status == "A")
			.FirstOrDefaultAsync(cancellationToken);

		return model != null ? MapToDomain(model) : null;
	}

	public async Task<Customer?> GetByIdentificationAsync(string identification, CancellationToken cancellationToken)
	{
		var model = await _context.Customer
			.Where(c => c.Identification == identification && c.Status == "A")
			.FirstOrDefaultAsync(cancellationToken);

		return model != null ? MapToDomain(model) : null;
	}

	public async Task<Customer> CreateAsync(Customer customer, CancellationToken cancellationToken)
	{
		// Llamar al SP existente usando FromSqlRaw
		var xml = BuildCustomerXml(customer);
		var result = await _context.Database
			.ExecuteSqlRawAsync("EXEC SP_Customer_Insert @xml", 
				new SqlParameter("@xml", xml), 
				cancellationToken);

		// Recargar desde la BD
		return await GetByIdentificationAsync(customer.Identification, cancellationToken) 
			?? throw new InvalidOperationException("Failed to create customer");
	}

	private Customer MapToDomain(CustomerModel model)
	{
		return new Customer
		{
			CustomerId = model.CustomerId,
			Identification = model.Identification,
			IdentTypeId = model.IdentTypeId,
			FirstName = model.FirstName,
			LastName = model.LastName,
			Email = model.Email,
			Phone = model.Phone,
			UseRetention = model.UseRetention ?? false,
			Status = model.Status,
			CreatedDate = model.CreatedDate,
			ModifiedDate = model.ModifiedDate
		};
	}

	private string BuildCustomerXml(Customer customer)
	{
		// Construir XML según el formato esperado por el SP
		// TODO: Eventualmente reemplazar por parámetros tipados
		return $@"<Customer>
			<Identification>{customer.Identification}</Identification>
			<IdentTypeId>{customer.IdentTypeId}</IdentTypeId>
			<FirstName>{customer.FirstName}</FirstName>
			<LastName>{customer.LastName}</LastName>
			<Email>{customer.Email ?? ""}</Email>
			<Phone>{customer.Phone ?? ""}</Phone>
		</Customer>";
	}
}
```

### 1.2.3 — Servicios Externos

**PrinterService.cs**:

```csharp
namespace POS.Infrastructure.ExternalServices;

public interface IPrinterService
{
	Task<bool> PrintTicketAsync(string ticketContent, CancellationToken cancellationToken = default);
}

public class PrinterService : IPrinterService
{
	private readonly IConfiguration _configuration;

	public PrinterService(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	public async Task<bool> PrintTicketAsync(string ticketContent, CancellationToken cancellationToken)
	{
		// Implementar lógica de impresión según el tipo de impresora
		// Ejemplo: ESC/POS, ZPL, etc.
		await Task.CompletedTask; // placeholder
		return true;
	}
}
```

### 1.2.4 — Dependency Injection

**DependencyInjection.cs**:

```csharp
namespace POS.Infrastructure;

public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
	{
		// DbContext
		services.AddDbContext<PosDbContext>(options =>
			options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

		// Repositories
		services.AddScoped<ICustomerRepository, CustomerRepository>();
		services.AddScoped<IInvoiceRepository, InvoiceRepository>();
		services.AddScoped<IProductRepository, ProductRepository>();
		// ... etc

		// External services
		services.AddSingleton<IPrinterService, PrinterService>();
		services.AddSingleton<IScaleService, ScaleService>();

		return services;
	}
}
```

---

## Fase 1.3 — Construir la API REST

### 1.3.1 — Configurar Program.cs

```csharp
using Domain.Application;
using POS.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using FluentValidation.AspNetCore;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Serilog
Log.Logger = new LoggerConfiguration()
	.ReadFrom.Configuration(builder.Configuration)
	.Enrich.FromLogContext()
	.WriteTo.Console()
	.WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
	.CreateLogger();

builder.Host.UseSerilog();

// Services
builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();

// Capas
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// JWT
var jwtKey = builder.Configuration["Jwt:Key"];
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	{
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,
			ValidIssuer = builder.Configuration["Jwt:Issuer"],
			ValidAudience = builder.Configuration["Jwt:Audience"],
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
		};
	});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new() { Title = "OmniPOS API", Version = "v1" });
	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		In = ParameterLocation.Header,
		Description = "JWT Authorization header using the Bearer scheme",
		Name = "Authorization",
		Type = SecuritySchemeType.Http,
		BearerFormat = "JWT",
		Scheme = "bearer"
	});
	c.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } },
			Array.Empty<string>()
		}
	});
});

var app = builder.Build();

// Middleware
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
```

### 1.3.2 — Middleware

**ErrorHandlingMiddleware.cs**:

```csharp
namespace POS.Api.Middleware;

public class ErrorHandlingMiddleware
{
	private readonly RequestDelegate _next;
	private readonly ILogger<ErrorHandlingMiddleware> _logger;

	public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
	{
		_next = next;
		_logger = logger;
	}

	public async Task InvokeAsync(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "Unhandled exception occurred");
			await HandleExceptionAsync(context, ex);
		}
	}

	private static Task HandleExceptionAsync(HttpContext context, Exception exception)
	{
		context.Response.ContentType = "application/json";
		context.Response.StatusCode = exception switch
		{
			ArgumentException => StatusCodes.Status400BadRequest,
			UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
			InvalidOperationException => StatusCodes.Status409Conflict,
			_ => StatusCodes.Status500InternalServerError
		};

		var response = new
		{
			error = exception.Message,
			statusCode = context.Response.StatusCode
		};

		return context.Response.WriteAsJsonAsync(response);
	}
}
```

### 1.3.3 — Controllers

**AuthController.cs**:

```csharp
namespace POS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
	private readonly IAuthService _authService;

	public AuthController(IAuthService authService)
	{
		_authService = authService;
	}

	[HttpPost("login")]
	public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
	{
		var response = await _authService.LoginAsync(request, cancellationToken);

		if (!response.Success)
			return Unauthorized(response);

		return Ok(response);
	}

	[HttpPost("supervisor")]
	[Authorize]
	public async Task<ActionResult<bool>> ValidateSupervisor([FromBody] SupervisorAuthRequest request, CancellationToken cancellationToken)
	{
		var isValid = await _authService.ValidateSupervisorAsync(request.Username, request.Password, cancellationToken);
		return Ok(isValid);
	}
}
```

**CustomersController.cs**:

```csharp
namespace POS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CustomersController : ControllerBase
{
	private readonly ICustomerService _customerService;

	public CustomersController(ICustomerService customerService)
	{
		_customerService = customerService;
	}

	[HttpGet("{identification}")]
	public async Task<ActionResult<CustomerResponse>> GetByIdentification(string identification, CancellationToken cancellationToken)
	{
		var customer = await _customerService.GetByIdentificationAsync(identification, cancellationToken);
		if (customer == null)
			return NotFound();

		return Ok(customer);
	}

	[HttpPost]
	public async Task<ActionResult<CustomerResponse>> Create([FromBody] CreateCustomerRequest request, CancellationToken cancellationToken)
	{
		var customer = await _customerService.CreateAsync(request, cancellationToken);
		return CreatedAtAction(nameof(GetByIdentification), new { identification = customer.Identification }, customer);
	}

	[HttpGet("{customerId}/addresses")]
	public async Task<ActionResult<IEnumerable<CustomerAddressResponse>>> GetAddresses(long customerId, CancellationToken cancellationToken)
	{
		var addresses = await _customerService.GetAddressesAsync(customerId, cancellationToken);
		return Ok(addresses);
	}
}
```

---

## Fase 1.4 — Estrategia de Coexistencia

### Diagrama de flujo

```
┌─────────────────────┐          ┌─────────────────────┐
│  WinForms (actual)  │          │   Nueva API REST    │
│                     │          │                     │
│   POS (UI)          │          │   POS.Api           │
│      ↓              │          │      ↓              │
│   POS.DLL           │          │ Domain.Application  │
│      ↓              │          │      ↓              │
│   EF6 + SPs         │          │ POS.Infrastructure  │
└─────────┬───────────┘          └─────────┬───────────┘
		  │                                │
		  └────────────┬───────────────────┘
					   ↓
			  ┌────────────────────┐
			  │   SQL Server DB    │
			  └────────────────────┘
```

### Reglas de coexistencia

1. **No modificar `POS.DLL`**: El WinForms actual sigue funcionando sin cambios.
2. **Misma base de datos**: Ambos sistemas leen/escriben de la misma BD.
3. **Sin dependencias cruzadas**: `POS.Api` NO referencia `POS.DLL`.
4. **Testing incremental**: Probar cada endpoint de la API mientras el WinForms sigue operando.
5. **Rollback seguro**: Si algo falla en la API, el WinForms sigue disponible.

---

## Checklist de Implementación

### POS.Domain ✅
- [ ] Crear estructura de carpetas
- [ ] Definir entidades de dominio (Customer, Invoice, Product, etc.)
- [ ] Crear Value Objects (Identification, Money, Address)
- [ ] Crear interfaces de repositorio
- [ ] Mover enumeraciones desde POS.DLL

### Domain.Application ✅
- [ ] Crear DTOs (Requests y Responses)
- [ ] Implementar validadores con FluentValidation
- [ ] Crear Application Services (Auth, Customer, Product, Invoice, etc.)
- [ ] Registrar servicios en DI

### POS.Infrastructure ✅
- [ ] Instalar paquetes de EF Core
- [ ] Scaffold DbContext desde la BD
- [ ] Implementar repositorios concretos
- [ ] Envolver SPs con FromSqlRaw/ExecuteSqlRaw
- [ ] Crear servicios externos (Printer, Scale, Scanner)
- [ ] Configurar DI en DependencyInjection.cs

### POS.Api ✅
- [ ] Configurar Program.cs (JWT, Swagger, Serilog)
- [ ] Crear Middleware (ErrorHandling, RequestLogging)
- [ ] Implementar Controllers (Auth, Customers, Products, etc.)
- [ ] Agregar validación automática con FluentValidation.AspNetCore
- [ ] Probar endpoints con Swagger

### Testing ✅
- [ ] Probar login desde Postman/Swagger
- [ ] Validar creación de cliente
- [ ] Validar consulta de productos
- [ ] Verificar que el WinForms sigue funcionando
- [ ] Probar coexistencia (WinForms crea cliente → API lo consulta)

---

## Próximos Pasos

Una vez completada la Fase 1:
- ✅ Backend con Clean Architecture funcional
- ✅ API REST documentada con Swagger
- ✅ WinForms operando en paralelo
- ➡️ **Fase 2**: Migrar el frontend para consumir la API
