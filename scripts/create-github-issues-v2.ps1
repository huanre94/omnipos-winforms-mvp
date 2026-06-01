# Script para crear labels y GitHub Issues para la migración OmniPOS
# Requiere: GitHub CLI (gh) instalado y autenticado

$repo = "huanre94/omnipos-winforms-mvp"

Write-Host "🚀 Creando labels e issues para el proyecto OmniPOS en $repo" -ForegroundColor Cyan
Write-Host ""

# ============================================================================
# PASO 1: Crear labels necesarios
# ============================================================================

Write-Host "🏷️  Creando labels..." -ForegroundColor Yellow

$labels = @(
	@{name="enhancement"; color="a2eeef"; description="New feature or request"},
	@{name="backend"; color="0366d6"; description="Backend development"},
	@{name="frontend"; color="d73a4a"; description="Frontend development"},
	@{name="domain"; color="7057ff"; description="Domain layer"},
	@{name="application"; color="8957ff"; description="Application layer"},
	@{name="infrastructure"; color="9957ff"; description="Infrastructure layer"},
	@{name="api"; color="a957ff"; description="API layer"},
	@{name="phase-1"; color="fbca04"; description="Fase 1: Clean Architecture + API"},
	@{name="phase-2"; color="ffd700"; description="Fase 2: Frontend replacement"},
	@{name="phase-3"; color="ffed4e"; description="Fase 3: Testing & CI/CD"},
	@{name="migration"; color="d4c5f9"; description="Migration task"},
	@{name="validation"; color="c5def5"; description="Validation logic"},
	@{name="hardware"; color="e99695"; description="Hardware integration"},
	@{name="testing"; color="1d76db"; description="Testing task"},
	@{name="integration"; color="0e8a16"; description="Integration testing"},
	@{name="documentation"; color="0075ca"; description="Documentation"}
)

foreach ($label in $labels) {
	gh label create $label.name --color $label.color --description $label.description --repo $repo --force 2>$null
	if ($LASTEXITCODE -eq 0) {
		Write-Host "  ✅ Label creado: $($label.name)" -ForegroundColor Green
	}
}

Write-Host ""

# ============================================================================
# PASO 2: Crear milestone
# ============================================================================

Write-Host "📋 Creando milestone 'Fase 1 - Clean Architecture + API REST'..." -ForegroundColor Yellow

$milestoneJson = gh api repos/$repo/milestones --method POST --field title="Fase 1 - Clean Architecture + API REST" --field description="Implementación del backend con arquitectura limpia y API REST sin proxy de POS.DLL" --field state="open" 2>$null

if ($LASTEXITCODE -eq 0) {
	Write-Host "  ✅ Milestone creado" -ForegroundColor Green
} else {
	Write-Host "  ⚠️  Milestone podría existir ya" -ForegroundColor Yellow
}

Write-Host ""

# ============================================================================
# PASO 3: Función helper para crear issues
# ============================================================================

function Create-Issue {
	param(
		[string]$Title,
		[string]$Body,
		[string[]]$Labels,
		[string]$Milestone = ""
	)

	$labelsParam = ($Labels -join ",")

	try {
		if ($Milestone) {
			gh issue create --repo $repo --title $Title --body $Body --label $labelsParam --milestone $Milestone 2>&1 | Out-Null
		} else {
			gh issue create --repo $repo --title $Title --body $Body --label $labelsParam 2>&1 | Out-Null
		}

		if ($LASTEXITCODE -eq 0) {
			Write-Host "  ✅ $Title" -ForegroundColor Green
		} else {
			Write-Host "  ❌ Error: $Title" -ForegroundColor Red
		}
	}
	catch {
		Write-Host "  ❌ Error: $Title - $_" -ForegroundColor Red
	}

	Start-Sleep -Milliseconds 300
}

Write-Host "📝 Creando issues..." -ForegroundColor Yellow
Write-Host ""

# ============================================================================
# EPIC 1: POS.Domain (Issues 1-5)
# ============================================================================

Write-Host "Epic 1: POS.Domain" -ForegroundColor Cyan

Create-Issue `
	-Title "[Fase 1.1] Configurar proyecto POS.Domain y estructura de carpetas" `
	-Body @"
## 🎯 Objetivo
Configurar el proyecto POS.Domain con la estructura de carpetas base para la capa de dominio puro.

## 📋 Checklist
- [ ] Crear estructura de carpetas
- [ ] Configurar .csproj para .NET 8
- [ ] Verificar que no haya referencias a Entity Framework

## 📚 Referencias
- ``docs/06-phase1-implementation-guide.md`` sección 1.1.1
- ``docs/05-project-structure.md``
"@ `
	-Labels @("enhancement", "backend", "domain", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Create-Issue `
	-Title "[Fase 1.1] Implementar entidades de dominio principales" `
	-Body @"
## 🎯 Objetivo
Crear las entidades de dominio puras: Customer, Invoice, Product, SalesOrder, Payment.

## 📋 Checklist
- [ ] Implementar Customer.cs
- [ ] Implementar Invoice.cs
- [ ] Implementar Product.cs
- [ ] Implementar SalesOrder.cs
- [ ] Implementar Payment.cs

## 📚 Referencias
- ``docs/06-phase1-implementation-guide.md`` sección 1.1.1
- ``docs/02-modules-backend.md``
"@ `
	-Labels @("enhancement", "backend", "domain", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Create-Issue `
	-Title "[Fase 1.1] Crear Value Objects (Identification, Money, Address)" `
	-Body @"
## 🎯 Objetivo
Implementar Value Objects para encapsular conceptos de dominio inmutables.

## 📋 Checklist
- [ ] Implementar Identification.cs
- [ ] Implementar Money.cs
- [ ] Implementar Address.cs
- [ ] Agregar pruebas unitarias

## 📚 Referencias
- ``docs/06-phase1-implementation-guide.md`` sección 1.1.1
"@ `
	-Labels @("enhancement", "backend", "domain", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Create-Issue `
	-Title "[Fase 1.1] Definir interfaces de repositorio en POS.Domain" `
	-Body @"
## 🎯 Objetivo
Crear interfaces de repositorio que serán implementadas por POS.Infrastructure.

## 📋 Checklist
- [ ] Crear ICustomerRepository.cs
- [ ] Crear IInvoiceRepository.cs
- [ ] Crear IProductRepository.cs
- [ ] Crear ISalesOrderRepository.cs
- [ ] Crear IPaymentRepository.cs
- [ ] Crear IClosingCashierRepository.cs

## 📚 Referencias
- ``docs/06-phase1-implementation-guide.md`` sección 1.1.1
- ``docs/02-modules-backend.md``
"@ `
	-Labels @("enhancement", "backend", "domain", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Create-Issue `
	-Title "[Fase 1.1] Migrar enumeraciones desde POS.DLL a POS.Domain" `
	-Body @"
## 🎯 Objetivo
Mover todas las enumeraciones de POS.DLL/Enums/ a POS.Domain/Enums/.

## 📋 Checklist
- [ ] Migrar PaymentMode.cs
- [ ] Migrar LogType.cs
- [ ] Migrar InvoiceStatus.cs
- [ ] Migrar IdentificationType.cs
- [ ] Actualizar namespaces

## 📚 Referencias
- ``docs/06-phase1-implementation-guide.md`` sección 1.1.1
"@ `
	-Labels @("enhancement", "backend", "domain", "phase-1", "migration") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

# ============================================================================
# EPIC 2: Domain.Application (Issues 6-10)
# ============================================================================

Write-Host ""
Write-Host "Epic 2: Domain.Application" -ForegroundColor Cyan

Create-Issue `
	-Title "[Fase 1.1] Configurar proyecto Domain.Application y estructura" `
	-Body @"
## 🎯 Objetivo
Configurar el proyecto Domain.Application con estructura para casos de uso.

## 📋 Checklist
- [ ] Crear estructura de carpetas
- [ ] Instalar FluentValidation
- [ ] Agregar referencia a POS.Domain
- [ ] Crear DependencyInjection.cs

## 📚 Referencias
- ``docs/06-phase1-implementation-guide.md`` sección 1.1.2
"@ `
	-Labels @("enhancement", "backend", "application", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Create-Issue `
	-Title "[Fase 1.1] Crear DTOs (Requests y Responses)" `
	-Body @"
## 🎯 Objetivo
Implementar los DTOs que serán usados por controllers y services.

## 📋 Checklist
- [ ] Crear LoginRequest, CreateCustomerRequest, etc.
- [ ] Crear LoginResponse, CustomerResponse, etc.
- [ ] Usar C# records para inmutabilidad

## 📚 Referencias
- ``docs/06-phase1-implementation-guide.md`` sección 1.1.2
- ``docs/02-modules-backend.md``
"@ `
	-Labels @("enhancement", "backend", "application", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Create-Issue `
	-Title "[Fase 1.1] Implementar validadores con FluentValidation" `
	-Body @"
## 🎯 Objetivo
Crear validadores para todos los DTOs de Request.

## 📋 Checklist
- [ ] Implementar LoginRequestValidator
- [ ] Implementar CreateCustomerRequestValidator
- [ ] Implementar CreateInvoiceRequestValidator
- [ ] Registrar validadores en DI

## 📚 Referencias
- ``docs/06-phase1-implementation-guide.md`` sección 1.1.2
- ``docs/02-modules-backend.md``
"@ `
	-Labels @("enhancement", "backend", "application", "phase-1", "validation") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Create-Issue `
	-Title "[Fase 1.1] Implementar AuthService y CustomerService" `
	-Body @"
## 🎯 Objetivo
Crear los Application Services principales.

## 📋 Checklist
- [ ] Implementar AuthService
- [ ] Implementar CustomerService
- [ ] Registrar en DI

## 📚 Referencias
- ``docs/06-phase1-implementation-guide.md`` sección 1.1.2
- ``docs/02-modules-backend.md``
"@ `
	-Labels @("enhancement", "backend", "application", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Create-Issue `
	-Title "[Fase 1.1] Implementar ProductService, InvoiceService y PaymentService" `
	-Body @"
## 🎯 Objetivo
Crear los Application Services para productos, facturas y pagos.

## 📋 Checklist
- [ ] Implementar ProductService
- [ ] Implementar InvoiceService
- [ ] Implementar PaymentService
- [ ] Registrar en DI

## 📚 Referencias
- ``docs/06-phase1-implementation-guide.md``
- ``docs/02-modules-backend.md``
"@ `
	-Labels @("enhancement", "backend", "application", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

# ============================================================================
# EPIC 3: POS.Infrastructure (Issues 11-15)
# ============================================================================

Write-Host ""
Write-Host "Epic 3: POS.Infrastructure" -ForegroundColor Cyan

Create-Issue `
	-Title "[Fase 1.2] Migrar de Entity Framework 6 a EF Core 8" `
	-Body @"
## 🎯 Objetivo
Migrar el modelo de datos de EF6 a EF Core 8.

## 📋 Checklist
- [ ] Instalar paquetes EF Core
- [ ] Ejecutar scaffold desde BD
- [ ] Configurar PosDbContext
- [ ] Configurar connection string

## 📚 Referencias
- ``docs/06-phase1-implementation-guide.md`` sección 1.2.1
"@ `
	-Labels @("enhancement", "backend", "infrastructure", "phase-1", "migration") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Create-Issue `
	-Title "[Fase 1.2] Implementar CustomerRepository con EF Core" `
	-Body @"
## 🎯 Objetivo
Implementar el repositorio de clientes usando EF Core 8.

## 📋 Checklist
- [ ] Crear CustomerRepository.cs
- [ ] Implementar ICustomerRepository
- [ ] Métodos de mapeo Domain ↔ EF Models
- [ ] Envolver SPs con ExecuteSqlRaw

## 📚 Referencias
- ``docs/06-phase1-implementation-guide.md`` sección 1.2.2
"@ `
	-Labels @("enhancement", "backend", "infrastructure", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Create-Issue `
	-Title "[Fase 1.2] Implementar InvoiceRepository y ProductRepository" `
	-Body @"
## 🎯 Objetivo
Implementar repositorios de facturas y productos.

## 📋 Checklist
- [ ] Crear InvoiceRepository.cs
- [ ] Crear ProductRepository.cs
- [ ] Implementar interfaces
- [ ] Métodos de mapeo

## 📚 Referencias
- ``docs/06-phase1-implementation-guide.md`` sección 1.2.2
- ``docs/02-modules-backend.md``
"@ `
	-Labels @("enhancement", "backend", "infrastructure", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Create-Issue `
	-Title "[Fase 1.2] Crear servicios externos (Printer, Scale, Scanner)" `
	-Body @"
## 🎯 Objetivo
Implementar servicios para interactuar con periféricos.

## 📋 Checklist
- [ ] Crear PrinterService
- [ ] Crear ScaleService
- [ ] Crear ScannerService
- [ ] Configurar desde appsettings

## 📚 Referencias
- ``docs/06-phase1-implementation-guide.md`` sección 1.2.3
"@ `
	-Labels @("enhancement", "backend", "infrastructure", "phase-1", "hardware") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Create-Issue `
	-Title "[Fase 1.2] Configurar Dependency Injection en POS.Infrastructure" `
	-Body @"
## 🎯 Objetivo
Crear clase de extensión para registrar servicios de infraestructura.

## 📋 Checklist
- [ ] Crear DependencyInjection.cs
- [ ] Registrar DbContext
- [ ] Registrar repositorios
- [ ] Registrar servicios externos

## 📚 Referencias
- ``docs/06-phase1-implementation-guide.md`` sección 1.2.4
"@ `
	-Labels @("enhancement", "backend", "infrastructure", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

# ============================================================================
# EPIC 4: POS.Api (Issues 16-23)
# ============================================================================

Write-Host ""
Write-Host "Epic 4: POS.Api" -ForegroundColor Cyan

Create-Issue `
	-Title "[Fase 1.3] Configurar POS.Api con JWT, Swagger y Serilog" `
	-Body @"
## 🎯 Objetivo
Configurar el proyecto POS.Api con autenticación, documentación y logging.

## 📋 Checklist
- [ ] Instalar paquetes NuGet
- [ ] Configurar Program.cs
- [ ] Configurar appsettings.json
- [ ] Registrar capas Application e Infrastructure

## 📚 Referencias
- ``docs/06-phase1-implementation-guide.md`` sección 1.3.1
"@ `
	-Labels @("enhancement", "backend", "api", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Create-Issue `
	-Title "[Fase 1.3] Implementar Middleware (ErrorHandling y RequestLogging)" `
	-Body @"
## 🎯 Objetivo
Crear middleware para manejo de errores y logging.

## 📋 Checklist
- [ ] Crear ErrorHandlingMiddleware
- [ ] Crear RequestLoggingMiddleware
- [ ] Registrar en Program.cs

## 📚 Referencias
- ``docs/06-phase1-implementation-guide.md`` sección 1.3.2
"@ `
	-Labels @("enhancement", "backend", "api", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Create-Issue `
	-Title "[Fase 1.3] Crear AuthController" `
	-Body @"
## 🎯 Objetivo
Implementar el controller de autenticación.

## 📋 Checklist
- [ ] Crear AuthController.cs
- [ ] Endpoint POST /api/auth/login
- [ ] Endpoint POST /api/auth/supervisor

## 📚 Referencias
- ``docs/06-phase1-implementation-guide.md`` sección 1.3.3
- ``docs/02-modules-backend.md`` módulo Auth
"@ `
	-Labels @("enhancement", "backend", "api", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Create-Issue `
	-Title "[Fase 1.3] Crear CustomersController" `
	-Body @"
## 🎯 Objetivo
Implementar el controller de gestión de clientes.

## 📋 Checklist
- [ ] Crear CustomersController.cs
- [ ] Endpoints CRUD completos
- [ ] Endpoint GET addresses

## 📚 Referencias
- ``docs/06-phase1-implementation-guide.md`` sección 1.3.3
- ``docs/02-modules-backend.md`` módulo Customers
"@ `
	-Labels @("enhancement", "backend", "api", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Create-Issue `
	-Title "[Fase 1.3] Crear ProductsController" `
	-Body @"
## 🎯 Objetivo
Implementar el controller de consulta de productos.

## 📋 Checklist
- [ ] Crear ProductsController.cs
- [ ] Endpoint GET by barcode
- [ ] Endpoint GET search
- [ ] Endpoint POST consult

## 📚 Referencias
- ``docs/06-phase1-implementation-guide.md``
- ``docs/02-modules-backend.md`` módulo Products
"@ `
	-Labels @("enhancement", "backend", "api", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Create-Issue `
	-Title "[Fase 1.3] Crear InvoicesController y PaymentsController" `
	-Body @"
## 🎯 Objetivo
Implementar los controllers de facturación y pagos.

## 📋 Checklist
- [ ] Crear InvoicesController.cs
- [ ] Crear PaymentsController.cs
- [ ] Endpoints completos

## 📚 Referencias
- ``docs/02-modules-backend.md`` módulos Invoices y Payments
"@ `
	-Labels @("enhancement", "backend", "api", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Create-Issue `
	-Title "[Fase 1.3] Testing de endpoints con Swagger" `
	-Body @"
## 🎯 Objetivo
Probar todos los endpoints implementados usando Swagger UI.

## 📋 Checklist
- [ ] Ejecutar POS.Api
- [ ] Probar flujo completo de Login → Cliente → Producto → Factura → Pago
- [ ] Probar casos de error
- [ ] Documentar en TESTING.md

## 📚 Referencias
- ``docs/06-phase1-implementation-guide.md`` sección 1.3
"@ `
	-Labels @("testing", "backend", "api", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

# ============================================================================
# EPIC 5: Coexistencia y Testing (Issues 24-26)
# ============================================================================

Write-Host ""
Write-Host "Epic 5: Coexistencia y Testing" -ForegroundColor Cyan

Create-Issue `
	-Title "[Fase 1.4] Validar coexistencia WinForms (POS.DLL) + API" `
	-Body @"
## 🎯 Objetivo
Verificar que WinForms y API operan simultáneamente contra la misma BD.

## 📋 Checklist
- [ ] Crear venta desde WinForms → consultar desde API
- [ ] Crear cliente desde API → buscar en WinForms
- [ ] Documentar en COEXISTENCE.md

## 📚 Referencias
- ``docs/06-phase1-implementation-guide.md`` sección 1.4
- ``docs/03-migration-plan.md`` Fase 1.4
"@ `
	-Labels @("testing", "integration", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Create-Issue `
	-Title "[Fase 1.4] Implementar pruebas de integración" `
	-Body @"
## 🎯 Objetivo
Crear suite de pruebas de integración para la API.

## 📋 Checklist
- [ ] Crear proyecto POS.IntegrationTests
- [ ] Instalar paquetes (WebApplicationFactory, xUnit, FluentAssertions)
- [ ] Crear tests por controller
- [ ] Ejecutar dotnet test
- [ ] Integrar en CI pipeline

## 📚 Referencias
- Microsoft Docs - Integration tests in ASP.NET Core
"@ `
	-Labels @("testing", "integration", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Create-Issue `
	-Title "[Fase 1] Documentar API y actualizar README del proyecto" `
	-Body @"
## 🎯 Objetivo
Actualizar documentación del proyecto con información de la nueva API.

## 📋 Checklist
- [ ] Actualizar README.md
- [ ] Crear API.md
- [ ] Actualizar Swagger summaries
- [ ] Crear CHANGELOG.md
- [ ] Crear DEPLOYMENT.md

## 📚 Referencias
- ``docs/`` folder completo
"@ `
	-Labels @("documentation", "phase-1") `
	-Milestone "Fase 1 - Clean Architecture + API REST"

Write-Host ""
Write-Host "✅ Proceso completado!" -ForegroundColor Green
Write-Host ""
Write-Host "📊 Resumen:" -ForegroundColor Cyan
Write-Host "   - Labels creados: 16" -ForegroundColor White
Write-Host "   - Milestone: Fase 1 - Clean Architecture + API REST" -ForegroundColor White
Write-Host "   - Issues creados: 26" -ForegroundColor White
Write-Host ""
Write-Host "🔗 Ver issues en: https://github.com/$repo/issues" -ForegroundColor Yellow
Write-Host "📋 Ver milestone en: https://github.com/$repo/milestones" -ForegroundColor Yellow
Write-Host "🏷️  Ver labels en: https://github.com/$repo/labels" -ForegroundColor Yellow
