# OmniPOS — Estructura de Proyectos (To-Be)

## Árbol de directorios propuesto

```
omnipos-winforms-mvp/
│
├── POS/                          ← WinForms (mantener durante transición)
│   ├── Views/                    ← Interfaces de vistas (MVP)
│   ├── Presenter/                ← Presentadores (ampliar)
│   ├── Frm*.cs                   ← Forms existentes
│   └── ...
│
├── POS.DLL/                      ← Mantener para compatibilidad con WinForms
│   ├── Repository/               ← Acceso a datos (EF6)
│   ├── Contracts/                ← Interfaces de repositorios
│   ├── Classes/                  ← DTOs auxiliares
│   ├── Enums/                    ← Enumeraciones
│   └── ModelPOS.edmx             ← Modelo EF6
│
├── POS.Domain/                   ← Capa de dominio (NUEVA)
│   ├── Entities/
│   │   ├── Customer.cs
│   │   ├── Invoice.cs
│   │   ├── Product.cs
│   │   ├── SalesOrder.cs
│   │   ├── Payment.cs
│   │   └── ...
│   ├── Interfaces/
│   │   ├── Repositories/
│   │   │   ├── ICustomerRepository.cs
│   │   │   ├── IInvoiceRepository.cs
│   │   │   ├── IProductRepository.cs
│   │   │   └── ...
│   │   └── Services/
│   │       ├── IAuthService.cs
│   │       ├── ICustomerService.cs
│   │       └── ...
│   ├── ValueObjects/
│   │   ├── Identification.cs
│   │   ├── Money.cs
│   │   └── ...
│   └── Enums/                    ← Mover desde POS.DLL/Enums/
│
├── Domain.Application/           ← Casos de uso (NUEVA)
│   ├── Services/
│   │   ├── AuthService.cs
│   │   ├── CustomerService.cs
│   │   ├── InvoiceService.cs
│   │   ├── ProductService.cs
│   │   ├── PaymentService.cs
│   │   ├── SalesOrderService.cs
│   │   ├── ClosingCashierService.cs
│   │   └── ...
│   ├── DTOs/
│   │   ├── Requests/
│   │   │   ├── LoginRequest.cs
│   │   │   ├── CreateInvoiceRequest.cs
│   │   │   └── ...
│   │   └── Responses/
│   │       ├── LoginResponse.cs
│   │       ├── InvoiceResponse.cs
│   │       └── ...
│   └── Validators/               ← FluentValidation
│       ├── LoginRequestValidator.cs
│       ├── CustomerRequestValidator.cs
│       └── ...
│
├── POS.Infrastructure/           ← Implementaciones de infraestructura (NUEVA)
│   ├── Persistence/
│   │   ├── PosDbContext.cs       ← EF Core (migración desde EF6)
│   │   ├── Repositories/
│   │   │   ├── CustomerRepository.cs
│   │   │   ├── InvoiceRepository.cs
│   │   │   └── ...
│   │   └── Migrations/
│   ├── ExternalServices/
│   │   ├── PrinterService.cs
│   │   ├── ScaleService.cs
│   │   └── ScannerService.cs
│   └── DependencyInjection.cs    ← Registro de servicios
│
├── POS.Api/                      ← API REST (AMPLIAR)
│   ├── Controllers/
│   │   ├── AuthController.cs
│   │   ├── CustomersController.cs
│   │   ├── ProductsController.cs
│   │   ├── InvoicesController.cs
│   │   ├── PaymentsController.cs
│   │   ├── SalesOrdersController.cs
│   │   ├── RemissionGuidesController.cs
│   │   ├── ClosingCashierController.cs
│   │   ├── PhysicalStockController.cs
│   │   └── ConfigController.cs
│   ├── Middleware/
│   │   ├── ErrorHandlingMiddleware.cs
│   │   └── RequestLoggingMiddleware.cs
│   ├── Program.cs
│   └── appsettings.json
│
└── POS.Tests/                    ← Pruebas (AMPLIAR)
	├── Unit/
	│   ├── Services/
	│   │   ├── CustomerServiceTests.cs
	│   │   ├── InvoiceServiceTests.cs
	│   │   └── ...
	│   └── Validators/
	├── Integration/
	│   └── Controllers/
	└── ...
```

## Dependencias entre proyectos

```
POS.Api
  → Domain.Application
  → POS.Infrastructure

Domain.Application
  → POS.Domain

POS.Infrastructure
  → POS.Domain

POS.Domain
  → (sin dependencias internas)

POS (WinForms - transitorio)
  → POS.DLL          ← durante transición
  → POS.Api client   ← después de migración

POS.Tests
  → Domain.Application
  → POS.Infrastructure (para integration tests)
```

## Convenciones de nomenclatura

| Tipo | Convención | Ejemplo |
|------|-----------|---------|
| Controller | `{Entidad}Controller` | `CustomersController` |
| Service (interfaz) | `I{Entidad}Service` | `ICustomerService` |
| Service (implementación) | `{Entidad}Service` | `CustomerService` |
| Repository (interfaz) | `I{Entidad}Repository` | `ICustomerRepository` |
| Repository (implementación) | `{Entidad}Repository` | `CustomerRepository` |
| Request DTO | `{Acción}{Entidad}Request` | `CreateCustomerRequest` |
| Response DTO | `{Entidad}Response` | `CustomerResponse` |
| Validator | `{Request}Validator` | `CreateCustomerRequestValidator` |
| Enum | PascalCase | `PaymentMode`, `DocumentType` |
