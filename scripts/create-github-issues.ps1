# Script para crear GitHub Issues para la migración OmniPOS
# Requiere: GitHub CLI (gh) instalado y autenticado

$repo = "huanre94/omnipos-winforms-mvp"

Write-Host "🚀 Creando issues para el proyecto OmniPOS en $repo" -ForegroundColor Cyan
Write-Host ""

# Función helper para crear issues
function Create-Issue {
	param(
		[string]$Title,
		[string]$Body,
		[string[]]$Labels,
		[string]$Milestone = ""
	)

	$labelsParam = ($Labels -join ",")

	if ($Milestone) {
		gh issue create --repo $repo --title $Title --body $Body --label $labelsParam --milestone $Milestone
	} else {
		gh issue create --repo $repo --title $Title --body $Body --label $labelsParam
	}

	if ($LASTEXITCODE -eq 0) {
		Write-Host "✅ Creado: $Title" -ForegroundColor Green
	} else {
		Write-Host "❌ Error creando: $Title" -ForegroundColor Red
	}
}

# ============================================================================
# MILESTONE: Crear milestone para Fase 1
# ============================================================================

Write-Host "📋 Creando milestone 'Fase 1 - Clean Architecture + API REST'..." -ForegroundColor Yellow
gh api repos/$repo/milestones --method POST --field title="Fase 1 - Clean Architecture + API REST" --field description="Implementación del backend con arquitectura limpia y API REST sin proxy de POS.DLL" --field state="open" 2>$null

Write-Host ""
Write-Host "📝 Creando issues..." -ForegroundColor Yellow
Write-Host ""

# ============================================================================
# EPIC 1: POS.Domain
# ============================================================================

Create-Issue `
	-Title "[Fase 1.1] Configurar proyecto POS.Domain y estructura de carpetas" `
	-Body @"
## 🎯 Objetivo
Configurar el proyecto POS.Domain con la estructura de carpetas base para la capa de dominio puro.

## 📋 Checklist
- [ ] Crear estructura de carpetas:
  - [ ] ``POS.Domain/Entities/``
  - [ ] ``POS.Domain/Interfaces/Repositories/``
  - [ ] ``POS.Domain/Interfaces/Services/``
  - [ ] ``POS.Domain/ValueObjects/``
  - [ ] ``POS.Domain/Enums/``
- [ ] Configurar .csproj para .NET 8
- [ ] Agregar NuGet packages necesarios (si aplica)
- [ ] Verificar que no haya referencias a Entity Framework u otras tecnologías de infraestructura

## 📚 Referencias
- Ver: ``docs/06-phase1-implementation-guide.md`` sección 1.1.1
- Ver: ``docs/05-project-structure.md``

## ⚠️ Importante
El proyecto POS.Domain debe ser **independiente de cualquier tecnología** de infraestructura o UI.
"@ `
	-Labels @("enhancement", "backend", "domain", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Start-Sleep -Milliseconds 500

Create-Issue `
	-Title "[Fase 1.1] Implementar entidades de dominio principales" `
	-Body @"
## 🎯 Objetivo
Crear las entidades de dominio puras: Customer, Invoice, Product, SalesOrder, Payment.

## 📋 Checklist
- [ ] Implementar ``Customer.cs``
  - [ ] Propiedades: CustomerId, Identification, IdentTypeId, FirstName, LastName, Email, Phone, UseRetention, Status, CreatedDate, ModifiedDate
  - [ ] Navigation property: Addresses
- [ ] Implementar ``Invoice.cs``
  - [ ] Propiedades: InvoiceId, InvoiceNumber, CustomerId, EmissionPointId, InvoiceDate, Subtotal, Tax, Total, Status
  - [ ] Navigation properties: InvoiceDetails, Customer, Payments
- [ ] Implementar ``Product.cs``
  - [ ] Propiedades: ProductId, Name, Description, Price, Stock, CategoryId, Status
  - [ ] Navigation property: Barcodes
- [ ] Implementar ``SalesOrder.cs``
- [ ] Implementar ``Payment.cs``
- [ ] Implementar entidades secundarias: ``InvoiceDetail``, ``ProductBarcode``, ``CustomerAddress``

## 📚 Referencias
- Ver: ``docs/06-phase1-implementation-guide.md`` sección 1.1.1
- Ver: ``docs/02-modules-backend.md`` para detalles de cada entidad

## ⚠️ Reglas importantes
- ❌ NO usar anotaciones de Entity Framework (``[Key]``, ``[Required]``, etc.)
- ❌ NO referenciar ``System.ComponentModel.DataAnnotations``
- ✅ Las entidades deben ser **independientes de cualquier tecnología**

## 🔗 Dependencias
Requiere: #1
"@ `
	-Labels @("enhancement", "backend", "domain", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Start-Sleep -Milliseconds 500

Create-Issue `
	-Title "[Fase 1.1] Crear Value Objects (Identification, Money, Address)" `
	-Body @"
## 🎯 Objetivo
Implementar Value Objects para encapsular conceptos de dominio inmutables.

## 📋 Checklist
- [ ] Implementar ``Identification.cs``
  - [ ] Propiedad Value (string)
  - [ ] Propiedad Type (IdentificationType enum)
  - [ ] Método estático ``Create()`` con validación por tipo
  - [ ] Validación para CI (10 dígitos), RUC (13 dígitos), Pasaporte
- [ ] Implementar ``Money.cs``
  - [ ] Propiedad Amount (decimal)
  - [ ] Propiedad Currency (string, default "USD")
  - [ ] Validación: Amount >= 0
  - [ ] Sobrecarga de operadores: +, -, *, /
  - [ ] Validación de misma moneda en operaciones
- [ ] Implementar ``Address.cs``
  - [ ] Propiedades: Street, City, Province, PostalCode, Country
  - [ ] Método ``Format()`` para mostrar dirección completa
- [ ] Agregar pruebas unitarias para cada Value Object

## 📚 Referencias
- Ver: ``docs/06-phase1-implementation-guide.md`` sección 1.1.1 (Value Objects)

## 💡 Conceptos clave
Los Value Objects son **inmutables** y su **igualdad se basa en sus propiedades**, no en su identidad.

## 🔗 Dependencias
Requiere: #1
"@ `
	-Labels @("enhancement", "backend", "domain", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Start-Sleep -Milliseconds 500

Create-Issue `
	-Title "[Fase 1.1] Definir interfaces de repositorio en POS.Domain" `
	-Body @"
## 🎯 Objetivo
Crear interfaces de repositorio que serán implementadas por POS.Infrastructure.

## 📋 Checklist
- [ ] Crear ``ICustomerRepository.cs``
  - [ ] ``GetByIdAsync(long customerId)``
  - [ ] ``GetByIdentificationAsync(string identification)``
  - [ ] ``CreateAsync(Customer customer)``
  - [ ] ``UpdateAsync(Customer customer)``
  - [ ] ``GetAddressesAsync(long customerId)``
  - [ ] ``AddAddressAsync(CustomerAddress address)``
  - [ ] ``UpdateAddressAsync(CustomerAddress address)``
- [ ] Crear ``IInvoiceRepository.cs``
  - [ ] ``GetByIdAsync(long invoiceId)``
  - [ ] ``CreateAsync(Invoice invoice)``
  - [ ] ``CancelAsync(long invoiceId, string reason, long supervisorId)``
  - [ ] ``GetTicketAsync(long invoiceId)``
  - [ ] ``GetSuspendedSaleAsync(long emissionPointId)``
  - [ ] ``SuspendSaleAsync(Invoice invoice)``
- [ ] Crear ``IProductRepository.cs``
- [ ] Crear ``ISalesOrderRepository.cs``
- [ ] Crear ``IPaymentRepository.cs``
- [ ] Crear ``IClosingCashierRepository.cs``
- [ ] Todas las interfaces deben soportar ``CancellationToken`` como parámetro opcional

## 📚 Referencias
- Ver: ``docs/06-phase1-implementation-guide.md`` sección 1.1.1 (Interfaces)
- Ver: ``docs/02-modules-backend.md`` para endpoints por módulo

## ⚠️ Importante
Las interfaces van en **POS.Domain**, las implementaciones van en **POS.Infrastructure**.

## 🔗 Dependencias
Requiere: #2
"@ `
	-Labels @("enhancement", "backend", "domain", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Start-Sleep -Milliseconds 500

Create-Issue `
	-Title "[Fase 1.1] Migrar enumeraciones desde POS.DLL a POS.Domain" `
	-Body @"
## 🎯 Objetivo
Mover todas las enumeraciones de ``POS.DLL/Enums/`` a ``POS.Domain/Enums/``.

## 📋 Checklist
- [ ] Migrar ``PaymentMode.cs`` (Cash, Card, Check, InternalCredit, GiftCard, Withhold, Advance, Return)
- [ ] Migrar ``LogType.cs``
- [ ] Migrar ``InvoiceStatus.cs``
- [ ] Migrar ``IdentificationType.cs`` (CI, RUC, Passport)
- [ ] Migrar otros enums relevantes
- [ ] Actualizar namespace de ``POS.DLL.Enums`` a ``POS.Domain.Enums``
- [ ] Verificar que no haya referencias rotas en POS.DLL

## 📚 Referencias
- Ver: ``docs/06-phase1-implementation-guide.md`` sección 1.1.1

## 💡 Estrategia
Copiar los archivos primero, no eliminarlos de POS.DLL hasta que toda la migración esté completa.

## 🔗 Dependencias
Requiere: #1
"@ `
	-Labels @("enhancement", "backend", "domain", "phase-1", "migration") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Start-Sleep -Milliseconds 500

# ============================================================================
# EPIC 2: Domain.Application
# ============================================================================

Create-Issue `
	-Title "[Fase 1.1] Configurar proyecto Domain.Application y estructura" `
	-Body @"
## 🎯 Objetivo
Configurar el proyecto Domain.Application con la estructura de carpetas para casos de uso.

## 📋 Checklist
- [ ] Crear estructura de carpetas:
  - [ ] ``Domain.Application/Services/``
  - [ ] ``Domain.Application/DTOs/Requests/``
  - [ ] ``Domain.Application/DTOs/Responses/``
  - [ ] ``Domain.Application/Validators/``
- [ ] Instalar paquetes NuGet:
  - [ ] ``FluentValidation`` (última versión)
  - [ ] ``FluentValidation.DependencyInjectionExtensions``
- [ ] Agregar referencia a ``POS.Domain``
- [ ] Crear clase ``DependencyInjection.cs`` para registrar servicios

## 📚 Referencias
- Ver: ``docs/06-phase1-implementation-guide.md`` sección 1.1.2
- Ver: ``docs/05-project-structure.md``

## 🔗 Dependencias
Requiere: #1
"@ `
	-Labels @("enhancement", "backend", "application", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Start-Sleep -Milliseconds 500

Create-Issue `
	-Title "[Fase 1.1] Crear DTOs (Requests y Responses)" `
	-Body @"
## 🎯 Objetivo
Implementar los DTOs que serán usados por los controllers y services.

## 📋 Checklist

### Requests
- [ ] ``LoginRequest`` (Username, Password, Workstation, IpAddress)
- [ ] ``CreateCustomerRequest`` (Identification, IdentTypeId, FirstName, LastName, Email, Phone, Address, CustomerTypeId)
- [ ] ``UpdateCustomerRequest``
- [ ] ``CreateInvoiceRequest`` (CustomerId, EmissionPointId, Details, PaymentMode)
- [ ] ``CreatePaymentRequest``
- [ ] ``CreateSalesOrderRequest``
- [ ] ``SupervisorAuthRequest``

### Responses
- [ ] ``LoginResponse`` (Success, Token, ErrorMessage, UserInfo, EmissionPointInfo, GlobalParameters)
- [ ] ``CustomerResponse`` (CustomerId, Identification, IdentType, FirstName, LastName, Email, Phone, UseRetention, Status)
- [ ] ``InvoiceResponse``
- [ ] ``ProductResponse``
- [ ] ``PaymentResponse``

### Records auxiliares
- [ ] ``UserInfo`` (UserId, Username, FullName, Role)
- [ ] ``EmissionPointInfo`` (Id, Code, Location)

## 📚 Referencias
- Ver: ``docs/06-phase1-implementation-guide.md`` sección 1.1.2 (DTOs)
- Ver: ``docs/02-modules-backend.md`` para estructura de cada módulo

## 💡 Usar C# Records
Los DTOs deben ser ``record`` para inmutabilidad.

## 🔗 Dependencias
Requiere: #6
"@ `
	-Labels @("enhancement", "backend", "application", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Start-Sleep -Milliseconds 500

Create-Issue `
	-Title "[Fase 1.1] Implementar validadores con FluentValidation" `
	-Body @"
## 🎯 Objetivo
Crear validadores para todos los DTOs de Request usando FluentValidation.

## 📋 Checklist
- [ ] ``LoginRequestValidator``
  - [ ] Username: NotEmpty, MaxLength(50)
  - [ ] Password: NotEmpty, MinLength(4)
  - [ ] Workstation: NotEmpty
  - [ ] IpAddress: NotEmpty, Regex para formato IP válido
- [ ] ``CreateCustomerRequestValidator``
  - [ ] Identification: NotEmpty, validación por tipo (CI 10 dígitos, RUC 13 dígitos)
  - [ ] FirstName: NotEmpty, MaxLength(100)
  - [ ] LastName: NotEmpty, MaxLength(100)
  - [ ] Email: EmailAddress (cuando no esté vacío)
- [ ] ``CreateInvoiceRequestValidator``
- [ ] ``CreatePaymentRequestValidator``
- [ ] ``CreateSalesOrderRequestValidator``
- [ ] Registrar validadores en DI (``AddValidatorsFromAssemblyContaining<LoginRequestValidator>()``)

## 📚 Referencias
- Ver: ``docs/06-phase1-implementation-guide.md`` sección 1.1.2 (Validadores)
- Ver: ``docs/02-modules-backend.md`` para reglas de validación por módulo

## 💡 Concepto clave
Los validadores deben contener **toda la lógica de validación** que hoy está dispersa en Forms y Stored Procedures.

## 🔗 Dependencias
Requiere: #7
"@ `
	-Labels @("enhancement", "backend", "application", "phase-1", "validation") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Start-Sleep -Milliseconds 500

Create-Issue `
	-Title "[Fase 1.1] Implementar AuthService y CustomerService" `
	-Body @"
## 🎯 Objetivo
Crear los Application Services principales: AuthService y CustomerService.

## 📋 Checklist

### AuthService
- [ ] Crear interfaz ``IAuthService``
- [ ] Implementar ``AuthService``
- [ ] Método ``LoginAsync(LoginRequest)`` → ``LoginResponse``
  - [ ] Validar credenciales llamando a IUserRepository
  - [ ] Obtener punto de emisión
  - [ ] Generar token JWT
  - [ ] Obtener parámetros globales
- [ ] Método ``ValidateSupervisorAsync(username, password)`` → ``bool``
- [ ] Registrar en DI

### CustomerService
- [ ] Crear interfaz ``ICustomerService``
- [ ] Implementar ``CustomerService``
- [ ] Método ``GetByIdentificationAsync(identification)`` → ``CustomerResponse?``
- [ ] Método ``CreateAsync(CreateCustomerRequest)`` → ``CustomerResponse``
  - [ ] Validar si ya existe
  - [ ] Crear Customer entity
  - [ ] Llamar a repository
  - [ ] Mapear a Response
- [ ] Método ``UpdateAsync(customerId, UpdateCustomerRequest)`` → ``CustomerResponse``
- [ ] Método ``GetAddressesAsync(customerId)`` → ``IEnumerable<CustomerAddressResponse>``
- [ ] Registrar en DI

## 📚 Referencias
- Ver: ``docs/06-phase1-implementation-guide.md`` sección 1.1.2 (Application Services)
- Ver: ``docs/02-modules-backend.md`` módulos Auth y Customers

## 🔗 Dependencias
Requiere: #4, #7, #8
"@ `
	-Labels @("enhancement", "backend", "application", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Start-Sleep -Milliseconds 500

Create-Issue `
	-Title "[Fase 1.1] Implementar ProductService, InvoiceService y PaymentService" `
	-Body @"
## 🎯 Objetivo
Crear los Application Services para productos, facturas y pagos.

## 📋 Checklist

### ProductService
- [ ] Interfaz ``IProductService``
- [ ] ``GetByBarcodeAsync(barcode)`` → ``ProductResponse?``
- [ ] ``GetByNameAsync(searchTerm)`` → ``IEnumerable<ProductResponse>``
- [ ] ``GetProductConsultAsync(productId, emissionPointId)`` → ``ProductConsultResponse``
  - [ ] Incluir precio, stock disponible, impuestos

### InvoiceService
- [ ] Interfaz ``IInvoiceService``
- [ ] ``CreateAsync(CreateInvoiceRequest)`` → ``InvoiceResponse``
  - [ ] Validar cliente existe
  - [ ] Validar stock de productos
  - [ ] Calcular totales (subtotal, impuestos, descuentos)
  - [ ] Crear invoice con detalles
- [ ] ``CancelAsync(invoiceId, cancelReason, supervisorId)`` → ``bool``
- [ ] ``GetTicketAsync(invoiceId)`` → ``InvoiceTicketResponse``
- [ ] ``GetSuspendedSaleAsync(emissionPointId)`` → ``InvoiceResponse?``
- [ ] ``SuspendSaleAsync(CreateInvoiceRequest)`` → ``bool``

### PaymentService
- [ ] Interfaz ``IPaymentService``
- [ ] ``ProcessPaymentAsync(ProcessPaymentRequest)`` → ``PaymentResponse``
  - [ ] Validar montos
  - [ ] Aplicar múltiples métodos de pago
  - [ ] Calcular cambio
  - [ ] Registrar retenciones si aplica

## 📚 Referencias
- Ver: ``docs/06-phase1-implementation-guide.md``
- Ver: ``docs/02-modules-backend.md`` módulos Products, Invoices, Payments

## 🔗 Dependencias
Requiere: #4, #7, #8
"@ `
	-Labels @("enhancement", "backend", "application", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Start-Sleep -Milliseconds 500

# ============================================================================
# EPIC 3: POS.Infrastructure
# ============================================================================

Create-Issue `
	-Title "[Fase 1.2] Migrar de Entity Framework 6 a EF Core 8" `
	-Body @"
## 🎯 Objetivo
Migrar el modelo de datos de EF6 (POS.DLL) a EF Core 8 (POS.Infrastructure).

## 📋 Checklist
- [ ] Instalar paquetes NuGet en POS.Infrastructure:
  - [ ] ``Microsoft.EntityFrameworkCore``
  - [ ] ``Microsoft.EntityFrameworkCore.SqlServer``
  - [ ] ``Microsoft.EntityFrameworkCore.Tools``
  - [ ] ``Microsoft.EntityFrameworkCore.Design``
- [ ] Ejecutar scaffold desde la BD existente:
  ``````bash
  dotnet ef dbcontext scaffold "Server=YOUR_SERVER;Database=YOUR_DB;Integrated Security=true;" Microsoft.EntityFrameworkCore.SqlServer -o Persistence/Models -c PosDbContext --context-dir Persistence
  ``````
- [ ] Revisar y ajustar ``PosDbContext.cs`` generado
- [ ] Crear carpeta ``Persistence/Models/`` para modelos EF (sufijo ``Model``)
- [ ] Verificar que se generaron todas las entidades
- [ ] Configurar connection string en ``appsettings.json``

## 📚 Referencias
- Ver: ``docs/06-phase1-implementation-guide.md`` sección 1.2.1

## ⚠️ Importante
Los modelos generados por EF Core son **modelos de infraestructura**, distintos de las entidades de dominio en ``POS.Domain``.

## 🔗 Dependencias
Requiere: #2
"@ `
	-Labels @("enhancement", "backend", "infrastructure", "phase-1", "migration") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Start-Sleep -Milliseconds 500

Create-Issue `
	-Title "[Fase 1.2] Implementar CustomerRepository con EF Core" `
	-Body @"
## 🎯 Objetivo
Implementar el repositorio de clientes usando EF Core 8 y stored procedures.

## 📋 Checklist
- [ ] Crear ``CustomerRepository.cs`` en ``POS.Infrastructure/Persistence/Repositories/``
- [ ] Implementar interfaz ``ICustomerRepository``
- [ ] ``GetByIdAsync(customerId)``
  - [ ] Query con EF Core
  - [ ] Mapear de ``CustomerModel`` a ``Customer`` (dominio)
- [ ] ``GetByIdentificationAsync(identification)``
- [ ] ``CreateAsync(Customer)``
  - [ ] Envolver SP existente con ``ExecuteSqlRawAsync``
  - [ ] Construir XML según formato esperado
  - [ ] Recargar desde BD
- [ ] ``UpdateAsync(Customer)``
- [ ] ``GetAddressesAsync(customerId)``
- [ ] ``AddAddressAsync(CustomerAddress)``
- [ ] ``UpdateAddressAsync(CustomerAddress)``
- [ ] Método privado ``MapToDomain(CustomerModel)`` → ``Customer``
- [ ] Método privado ``BuildCustomerXml(Customer)`` → ``string``

## 📚 Referencias
- Ver: ``docs/06-phase1-implementation-guide.md`` sección 1.2.2

## 💡 Estrategia
Por ahora usamos los SPs existentes con ``ExecuteSqlRawAsync``. Eventualmente podemos reemplazarlos por queries EF puras.

## 🔗 Dependencias
Requiere: #11, #4
"@ `
	-Labels @("enhancement", "backend", "infrastructure", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Start-Sleep -Milliseconds 500

Create-Issue `
	-Title "[Fase 1.2] Implementar InvoiceRepository y ProductRepository" `
	-Body @"
## 🎯 Objetivo
Implementar los repositorios de facturas y productos.

## 📋 Checklist

### InvoiceRepository
- [ ] Crear ``InvoiceRepository.cs``
- [ ] Implementar ``IInvoiceRepository``
- [ ] ``GetByIdAsync(invoiceId)`` → incluir InvoiceDetails, Customer, Payments
- [ ] ``CreateAsync(Invoice)`` → envolver SP de creación de factura
- [ ] ``CancelAsync(invoiceId, reason, supervisorId)`` → SP de cancelación
- [ ] ``GetTicketAsync(invoiceId)`` → SP que devuelve líneas del ticket
- [ ] ``GetSuspendedSaleAsync(emissionPointId)``
- [ ] ``SuspendSaleAsync(Invoice)``
- [ ] Métodos de mapeo: ``MapToDomain(InvoiceModel)`` → ``Invoice``

### ProductRepository
- [ ] Crear ``ProductRepository.cs``
- [ ] Implementar ``IProductRepository``
- [ ] ``GetByBarcodeAsync(barcode)``
  - [ ] Join con ProductBarcode
- [ ] ``GetByNameAsync(searchTerm)``
  - [ ] ``Where(p => p.Name.Contains(searchTerm))``
- [ ] ``ProductConsultAsync(ProductConsultDto)``
  - [ ] Envolver SP ``SP_Product_Consult``
  - [ ] Mapear resultado a entity
- [ ] Métodos de mapeo

## 📚 Referencias
- Ver: ``docs/06-phase1-implementation-guide.md`` sección 1.2.2
- Ver: ``docs/02-modules-backend.md`` módulos Invoices y Products

## 🔗 Dependencias
Requiere: #11, #4
"@ `
	-Labels @("enhancement", "backend", "infrastructure", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Start-Sleep -Milliseconds 500

Create-Issue `
	-Title "[Fase 1.2] Crear servicios externos (Printer, Scale, Scanner)" `
	-Body @"
## 🎯 Objetivo
Implementar servicios para interactuar con periféricos del POS.

## 📋 Checklist

### PrinterService
- [ ] Crear interfaz ``IPrinterService``
- [ ] Implementar ``PrinterService`` en ``POS.Infrastructure/ExternalServices/``
- [ ] Método ``PrintTicketAsync(string ticketContent)``
  - [ ] Detectar tipo de impresora configurada
  - [ ] Enviar comandos ESC/POS
  - [ ] Manejar errores de impresión

### ScaleService
- [ ] Crear interfaz ``IScaleService``
- [ ] Implementar ``ScaleService``
- [ ] Método ``GetWeightAsync()`` → ``decimal``
  - [ ] Leer peso de balanza serial/USB
  - [ ] Parsear respuesta según marca (configurable)

### ScannerService
- [ ] Crear interfaz ``IScannerService``
- [ ] Implementar ``ScannerService``
- [ ] Método ``StartListeningAsync(Action<string> onBarcodeScanned)``
- [ ] Método ``StopListeningAsync()``

## 📚 Referencias
- Ver: ``docs/06-phase1-implementation-guide.md`` sección 1.2.3
- Revisar código actual en ``POS/FrmMain.cs`` para lógica de scanner

## 💡 Configuración
Leer configuración de periféricos desde ``appsettings.json`` (puertos COM, marcas, etc.).

## 🔗 Dependencias
Ninguna (puede desarrollarse en paralelo)
"@ `
	-Labels @("enhancement", "backend", "infrastructure", "phase-1", "hardware") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Start-Sleep -Milliseconds 500

Create-Issue `
	-Title "[Fase 1.2] Configurar Dependency Injection en POS.Infrastructure" `
	-Body @"
## 🎯 Objetivo
Crear clase de extensión para registrar todos los servicios de infraestructura en el contenedor DI.

## 📋 Checklist
- [ ] Crear ``DependencyInjection.cs`` en raíz de POS.Infrastructure
- [ ] Método de extensión ``AddInfrastructure(this IServiceCollection services, IConfiguration configuration)``
- [ ] Registrar ``DbContext``:
  ``````csharp
  services.AddDbContext<PosDbContext>(options =>
	  options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
  ``````
- [ ] Registrar repositorios:
  - [ ] ``ICustomerRepository`` → ``CustomerRepository``
  - [ ] ``IInvoiceRepository`` → ``InvoiceRepository``
  - [ ] ``IProductRepository`` → ``ProductRepository``
  - [ ] ``ISalesOrderRepository`` → ``SalesOrderRepository``
  - [ ] ``IPaymentRepository`` → ``PaymentRepository``
  - [ ] ``IClosingCashierRepository`` → ``ClosingCashierRepository``
- [ ] Registrar servicios externos:
  - [ ] ``IPrinterService`` → ``PrinterService`` (Singleton)
  - [ ] ``IScaleService`` → ``ScaleService`` (Singleton)
  - [ ] ``IScannerService`` → ``ScannerService`` (Singleton)

## 📚 Referencias
- Ver: ``docs/06-phase1-implementation-guide.md`` sección 1.2.4

## 🔗 Dependencias
Requiere: #12, #13, #14
"@ `
	-Labels @("enhancement", "backend", "infrastructure", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Start-Sleep -Milliseconds 500

# ============================================================================
# EPIC 4: POS.Api
# ============================================================================

Create-Issue `
	-Title "[Fase 1.3] Configurar POS.Api con JWT, Swagger y Serilog" `
	-Body @"
## 🎯 Objetivo
Configurar el proyecto POS.Api con autenticación JWT, documentación Swagger y logging estructurado.

## 📋 Checklist

### Paquetes NuGet
- [ ] ``Microsoft.AspNetCore.Authentication.JwtBearer``
- [ ] ``Swashbuckle.AspNetCore``
- [ ] ``Serilog.AspNetCore``
- [ ] ``Serilog.Sinks.Console``
- [ ] ``Serilog.Sinks.File``

### Program.cs
- [ ] Configurar Serilog
  - [ ] Logs a consola y archivo rotativo
- [ ] Configurar autenticación JWT
  - [ ] Leer clave desde ``appsettings.json``
  - [ ] Configurar ``TokenValidationParameters``
- [ ] Configurar Swagger
  - [ ] Título: "OmniPOS API"
  - [ ] Agregar esquema de seguridad Bearer JWT
- [ ] Registrar capas:
  - [ ] ``services.AddApplication()``
  - [ ] ``services.AddInfrastructure(configuration)``
- [ ] Agregar FluentValidation
  - [ ] ``AddFluentValidationAutoValidation()``
  - [ ] ``AddValidatorsFromAssemblyContaining<LoginRequestValidator>()``

### appsettings.json
- [ ] Sección ``ConnectionStrings``
- [ ] Sección ``Jwt`` (Key, Issuer, Audience, ExpirationMinutes)
- [ ] Sección ``Serilog``

## 📚 Referencias
- Ver: ``docs/06-phase1-implementation-guide.md`` sección 1.3.1

## 🔗 Dependencias
Requiere: #6, #15
"@ `
	-Labels @("enhancement", "backend", "api", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Start-Sleep -Milliseconds 500

Create-Issue `
	-Title "[Fase 1.3] Implementar Middleware (ErrorHandling y RequestLogging)" `
	-Body @"
## 🎯 Objetivo
Crear middleware para manejo centralizado de errores y logging de requests.

## 📋 Checklist

### ErrorHandlingMiddleware
- [ ] Crear ``ErrorHandlingMiddleware.cs`` en ``POS.Api/Middleware/``
- [ ] Capturar excepciones no manejadas
- [ ] Mapear excepciones a códigos HTTP:
  - [ ] ``ArgumentException`` → 400 Bad Request
  - [ ] ``UnauthorizedAccessException`` → 401 Unauthorized
  - [ ] ``InvalidOperationException`` → 409 Conflict
  - [ ] Resto → 500 Internal Server Error
- [ ] Devolver JSON con ``{ error, statusCode }``
- [ ] Loggear con ``ILogger<ErrorHandlingMiddleware>``

### RequestLoggingMiddleware
- [ ] Crear ``RequestLoggingMiddleware.cs``
- [ ] Loggear cada request:
  - [ ] Método HTTP
  - [ ] Path
  - [ ] Query string
  - [ ] User claim (si está autenticado)
  - [ ] Duración de la request
- [ ] Usar Serilog structured logging

### Registrar en Program.cs
- [ ] ``app.UseMiddleware<ErrorHandlingMiddleware>();``
- [ ] ``app.UseMiddleware<RequestLoggingMiddleware>();``

## 📚 Referencias
- Ver: ``docs/06-phase1-implementation-guide.md`` sección 1.3.2

## 🔗 Dependencias
Requiere: #16
"@ `
	-Labels @("enhancement", "backend", "api", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Start-Sleep -Milliseconds 500

Create-Issue `
	-Title "[Fase 1.3] Crear AuthController" `
	-Body @"
## 🎯 Objetivo
Implementar el controller de autenticación.

## 📋 Checklist
- [ ] Crear ``AuthController.cs`` en ``POS.Api/Controllers/``
- [ ] Decorar con ``[ApiController]`` y ``[Route("api/[controller]")]``
- [ ] Inyectar ``IAuthService``
- [ ] Endpoint ``POST /api/auth/login``
  - [ ] Recibe ``LoginRequest``
  - [ ] Llama a ``authService.LoginAsync()``
  - [ ] Si éxito: devuelve 200 con ``LoginResponse`` (incluye token)
  - [ ] Si fallo: devuelve 401 con mensaje de error
- [ ] Endpoint ``POST /api/auth/supervisor``
  - [ ] Decorar con ``[Authorize]``
  - [ ] Recibe ``SupervisorAuthRequest``
  - [ ] Llama a ``authService.ValidateSupervisorAsync()``
  - [ ] Devuelve ``bool``

## 📚 Referencias
- Ver: ``docs/06-phase1-implementation-guide.md`` sección 1.3.3
- Ver: ``docs/02-modules-backend.md`` módulo Auth

## 🔗 Dependencias
Requiere: #9, #16, #17
"@ `
	-Labels @("enhancement", "backend", "api", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Start-Sleep -Milliseconds 500

Create-Issue `
	-Title "[Fase 1.3] Crear CustomersController" `
	-Body @"
## 🎯 Objetivo
Implementar el controller de gestión de clientes.

## 📋 Checklist
- [ ] Crear ``CustomersController.cs``
- [ ] Decorar con ``[ApiController]``, ``[Route("api/[controller]")]``, ``[Authorize]``
- [ ] Inyectar ``ICustomerService``
- [ ] Endpoint ``GET /api/customers/{identification}``
  - [ ] Llama a ``customerService.GetByIdentificationAsync()``
  - [ ] Si existe: 200 con ``CustomerResponse``
  - [ ] Si no existe: 404
- [ ] Endpoint ``POST /api/customers``
  - [ ] Recibe ``CreateCustomerRequest``
  - [ ] Llama a ``customerService.CreateAsync()``
  - [ ] Devuelve 201 Created con ``CustomerResponse`` y header ``Location``
- [ ] Endpoint ``PUT /api/customers/{customerId}``
  - [ ] Recibe ``UpdateCustomerRequest``
  - [ ] Llama a ``customerService.UpdateAsync()``
  - [ ] Devuelve 200 con ``CustomerResponse``
- [ ] Endpoint ``GET /api/customers/{customerId}/addresses``
  - [ ] Llama a ``customerService.GetAddressesAsync()``
  - [ ] Devuelve 200 con lista de direcciones

## 📚 Referencias
- Ver: ``docs/06-phase1-implementation-guide.md`` sección 1.3.3
- Ver: ``docs/02-modules-backend.md`` módulo Customers

## 🔗 Dependencias
Requiere: #9, #16, #17
"@ `
	-Labels @("enhancement", "backend", "api", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Start-Sleep -Milliseconds 500

Create-Issue `
	-Title "[Fase 1.3] Crear ProductsController" `
	-Body @"
## 🎯 Objetivo
Implementar el controller de consulta de productos.

## 📋 Checklist
- [ ] Crear ``ProductsController.cs``
- [ ] Decorar con ``[ApiController]``, ``[Route("api/[controller]")]``, ``[Authorize]``
- [ ] Inyectar ``IProductService``
- [ ] Endpoint ``GET /api/products/barcode/{barcode}``
  - [ ] Llama a ``productService.GetByBarcodeAsync()``
  - [ ] Si existe: 200 con ``ProductResponse``
  - [ ] Si no existe: 404
- [ ] Endpoint ``GET /api/products/search?q={searchTerm}``
  - [ ] Llama a ``productService.GetByNameAsync()``
  - [ ] Devuelve 200 con lista de productos
- [ ] Endpoint ``POST /api/products/consult``
  - [ ] Recibe ``ProductConsultRequest`` (productId, emissionPointId, quantity)
  - [ ] Llama a ``productService.GetProductConsultAsync()``
  - [ ] Devuelve ``ProductConsultResponse`` (con precio, stock, impuestos)

## 📚 Referencias
- Ver: ``docs/06-phase1-implementation-guide.md``
- Ver: ``docs/02-modules-backend.md`` módulo Products

## 🔗 Dependencias
Requiere: #10, #16, #17
"@ `
	-Labels @("enhancement", "backend", "api", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Start-Sleep -Milliseconds 500

Create-Issue `
	-Title "[Fase 1.3] Crear InvoicesController y PaymentsController" `
	-Body @"
## 🎯 Objetivo
Implementar los controllers de facturación y pagos.

## 📋 Checklist

### InvoicesController
- [ ] Crear ``InvoicesController.cs``
- [ ] Decorar con ``[Authorize]``
- [ ] Inyectar ``IInvoiceService``
- [ ] ``GET /api/invoices/{invoiceId}``
  - [ ] Devuelve factura con detalles y pagos
- [ ] ``POST /api/invoices``
  - [ ] Recibe ``CreateInvoiceRequest``
  - [ ] Valida stock, cliente, totales
  - [ ] Devuelve 201 con ``InvoiceResponse``
- [ ] ``DELETE /api/invoices/{invoiceId}``
  - [ ] Recibe query params: ``cancelReason``, ``supervisorId``
  - [ ] Llama a ``invoiceService.CancelAsync()``
  - [ ] Devuelve 204 No Content
- [ ] ``GET /api/invoices/{invoiceId}/ticket``
  - [ ] Devuelve líneas de texto para impresión térmica
- [ ] ``GET /api/invoices/suspended?emissionPointId={id}``
  - [ ] Devuelve venta suspendida si existe
- [ ] ``POST /api/invoices/suspend``
  - [ ] Suspende una venta para retomar después

### PaymentsController
- [ ] Crear ``PaymentsController.cs``
- [ ] Decorar con ``[Authorize]``
- [ ] Inyectar ``IPaymentService``
- [ ] ``POST /api/payments``
  - [ ] Recibe ``ProcessPaymentRequest`` (invoiceId, paymentDetails[])
  - [ ] Valida montos, calcula cambio
  - [ ] Devuelve ``PaymentResponse``

## 📚 Referencias
- Ver: ``docs/02-modules-backend.md`` módulos Invoices y Payments

## 🔗 Dependencias
Requiere: #10, #16, #17
"@ `
	-Labels @("enhancement", "backend", "api", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Start-Sleep -Milliseconds 500

Create-Issue `
	-Title "[Fase 1.3] Testing de endpoints con Swagger" `
	-Body @"
## 🎯 Objetivo
Probar todos los endpoints implementados usando Swagger UI.

## 📋 Checklist
- [ ] Ejecutar POS.Api en modo Development
- [ ] Acceder a ``https://localhost:xxxx/swagger``
- [ ] Probar flujo completo:
  - [ ] 1. ``POST /api/auth/login`` → obtener token JWT
  - [ ] 2. Copiar token y usar botón "Authorize" en Swagger
  - [ ] 3. ``POST /api/customers`` → crear cliente de prueba
  - [ ] 4. ``GET /api/customers/{identification}`` → verificar que se creó
  - [ ] 5. ``GET /api/products/barcode/{barcode}`` → buscar producto
  - [ ] 6. ``POST /api/invoices`` → crear factura
  - [ ] 7. ``GET /api/invoices/{invoiceId}/ticket`` → obtener ticket
  - [ ] 8. ``POST /api/payments`` → registrar pago
- [ ] Probar errores:
  - [ ] Login con credenciales incorrectas → 401
  - [ ] Request sin token → 401
  - [ ] Crear cliente duplicado → 409
  - [ ] Factura con stock insuficiente → 400
- [ ] Documentar casos de prueba en archivo ``TESTING.md``

## 📚 Referencias
- Ver: ``docs/06-phase1-implementation-guide.md`` sección 1.3

## 🔗 Dependencias
Requiere: #18, #19, #20, #21, #22
"@ `
	-Labels @("testing", "backend", "api", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Start-Sleep -Milliseconds 500

# ============================================================================
# EPIC 5: Coexistencia y Testing
# ============================================================================

Create-Issue `
	-Title "[Fase 1.4] Validar coexistencia WinForms (POS.DLL) + API" `
	-Body @"
## 🎯 Objetivo
Verificar que la aplicación WinForms existente y la nueva API pueden operar simultáneamente contra la misma base de datos.

## 📋 Checklist
- [ ] Ejecutar aplicación WinForms (POS) y crear una venta
- [ ] Usar Swagger para consultar esa venta creada por WinForms
- [ ] Crear un cliente desde la API
- [ ] Abrir WinForms y buscar ese cliente → debe aparecer
- [ ] Verificar que ambos sistemas usan la misma connection string
- [ ] Confirmar que **POS.Api NO referencia POS.DLL**
- [ ] Documentar flujo de coexistencia en ``COEXISTENCE.md``

## 📚 Referencias
- Ver: ``docs/06-phase1-implementation-guide.md`` sección 1.4
- Ver: ``docs/03-migration-plan.md`` Fase 1.4

## 💡 Reglas de coexistencia
- ❌ No modificar POS.DLL
- ✅ Misma base de datos
- ❌ Sin dependencias cruzadas
- ✅ Testing incremental
- ✅ Rollback seguro

## 🔗 Dependencias
Requiere: #23
"@ `
	-Labels @("testing", "integration", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Start-Sleep -Milliseconds 500

Create-Issue `
	-Title "[Fase 1.4] Implementar pruebas de integración" `
	-Body @"
## 🎯 Objetivo
Crear suite de pruebas de integración para la API usando WebApplicationFactory.

## 📋 Checklist
- [ ] Crear proyecto ``POS.IntegrationTests``
- [ ] Instalar paquetes:
  - [ ] ``Microsoft.AspNetCore.Mvc.Testing``
  - [ ] ``xUnit`` o ``NUnit``
  - [ ] ``FluentAssertions``
- [ ] Configurar ``WebApplicationFactory<Program>``
- [ ] Configurar base de datos de pruebas (in-memory o TestContainers)
- [ ] Crear tests:
  - [ ] ``AuthControllerTests`` (login exitoso, login fallido)
  - [ ] ``CustomersControllerTests`` (crear, consultar, actualizar)
  - [ ] ``ProductsControllerTests`` (buscar por barcode, por nombre)
  - [ ] ``InvoicesControllerTests`` (crear factura, cancelar, obtener ticket)
  - [ ] ``PaymentsControllerTests`` (procesar pago múltiple)
- [ ] Ejecutar tests con ``dotnet test``
- [ ] Integrar en CI pipeline (GitHub Actions) si existe

## 📚 Referencias
- Ver: Microsoft Docs - Integration tests in ASP.NET Core

## 🔗 Dependencias
Requiere: #23
"@ `
	-Labels @("testing", "integration", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Start-Sleep -Milliseconds 500

Create-Issue `
	-Title "[Fase 1] Documentar API y actualizar README del proyecto" `
	-Body @"
## 🎯 Objetivo
Actualizar documentación del proyecto con información de la nueva API.

## 📋 Checklist
- [ ] Actualizar ``README.md`` del repositorio:
  - [ ] Sección "Arquitectura" con diagrama de capas
  - [ ] Sección "Cómo ejecutar" con pasos para POS.Api
  - [ ] Sección "Tecnologías" (EF Core 8, JWT, Swagger, Serilog)
- [ ] Crear ``API.md`` con:
  - [ ] Endpoints disponibles
  - [ ] Formato de requests/responses
  - [ ] Códigos de error
  - [ ] Ejemplos de uso con cURL
- [ ] Actualizar Swagger con summaries y remarks en cada endpoint
- [ ] Agregar ``CHANGELOG.md`` con registro de cambios de la Fase 1
- [ ] Crear ``DEPLOYMENT.md`` con instrucciones de despliegue

## 📚 Referencias
- Ver: ``docs/`` folder con toda la documentación generada

## 🔗 Dependencias
Requiere: #24, #25
"@ `
	-Labels @("documentation", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Write-Host ""
Write-Host "✅ Proceso completado!" -ForegroundColor Green
Write-Host ""
Write-Host "📊 Resumen:" -ForegroundColor Cyan
Write-Host "   - Milestone: Fase 1 - Clean Architecture + API REST" -ForegroundColor White
Write-Host "   - Issues creados: 26" -ForegroundColor White
Write-Host ""
Write-Host "🔗 Ver issues en: https://github.com/$repo/issues" -ForegroundColor Yellow
Write-Host "📋 Ver milestone en: https://github.com/$repo/milestones" -ForegroundColor Yellow
