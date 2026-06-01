# OmniPOS — Arquitectura General

## Estado Actual (As-Is)

```
┌─────────────────────────────────────────────────────────────────┐
│                        POS (WinForms)                           │
│  FrmLogin  FrmMain  FrmPayment  FrmCustomer  FrmSalesOrder ...  │
│                  Uses DevExpress UI Controls                    │
│                  MVP pattern incompleto (solo ProductPresenter) │
└────────────────────┬────────────────────────────────────────────┘
					 │ Direct instantiation / static calls
┌────────────────────▼────────────────────────────────────────────┐
│                       POS.DLL                                   │
│  Repository/  ← Entity Framework 6 (Database-First, EDMX)      │
│  Contracts/   ← interfaces (parcialmente implementadas)         │
│  Classes/     ← DTOs y clases auxiliares                        │
│  Enums/       ← enumeraciones de dominio                        │
│  ModelPOS.edmx ← contexto EF (POSEntities)                      │
└────────────────────┬────────────────────────────────────────────┘
					 │ EF6 + Stored Procedures + XML params
┌────────────────────▼────────────────────────────────────────────┐
│                  SQL Server Database                             │
│  Stored Procedures (SP_*) para toda la lógica transaccional     │
│  Functions (FN_*) para validaciones                             │
└─────────────────────────────────────────────────────────────────┘

Proyectos existentes pero vacíos (scaffolding inicial):
  POS.Api          ← ASP.NET Core Web API (solo WeatherForecast demo)
  POS.Domain       ← Capa de dominio (vacía)
  Domain.Application ← Capa de aplicación (vacía)
  POS.Infrastructure ← Infraestructura (vacía)
  POS.Tests        ← Pruebas (vacío)
```

## Arquitectura Objetivo (To-Be)

```
┌─────────────────────────────────────────────────────┐
│              Frontend (nuevo)                        │
│  Opción A: WinForms modernizado + HTTP client        │
│  Opción B: Web App (React / Blazor)                  │
│  Opción C: Electron / MAUI (cross-platform)          │
└────────────────┬────────────────────────────────────┘
				 │ HTTP/REST (JSON)
┌────────────────▼────────────────────────────────────┐
│              POS.Api  (ASP.NET Core 8)               │
│  Controllers/  ← endpoints REST por módulo           │
│  Middleware/   ← auth JWT, error handling, logging   │
└──────┬─────────────────────┬───────────────────────┘
	   │                     │
┌──────▼──────┐   ┌──────────▼──────────────┐
│ POS.Domain  │   │  Domain.Application      │
│ Entities    │   │  Services / Use Cases    │
│ Value Obj.  │   │  Validators (FluentVal.) │
│ Interfaces  │   │  DTOs / Request-Response │
└─────────────┘   └──────────┬──────────────┘
							 │
			  ┌──────────────▼──────────────┐
			  │     POS.Infrastructure       │
			  │  Repositories (EF Core)      │
			  │  SP wrappers → EF Raw SQL    │
			  │  External services (printers,│
			  │  scales, scanners)           │
			  └──────────────┬──────────────┘
							 │
			  ┌──────────────▼──────────────┐
			  │       SQL Server             │
			  └─────────────────────────────┘
```

## Principios de Diseño

| Principio | Aplicación |
|-----------|-----------|
| Clean Architecture | Dependencias apuntan hacia el dominio |
| CQRS ligero | Commands (escritura) / Queries (lectura) separados en `Domain.Application` |
| Repository Pattern | Interfaces en `POS.Domain`, implementaciones en `POS.Infrastructure` |
| Separation of Concerns | UI no conoce la BD; API no conoce UI |
| Validación en backend | Todas las reglas de negocio viven en la API, nunca solo en el front |

## Stack Tecnológico Propuesto

| Capa | Tecnología |
|------|-----------|
| API | ASP.NET Core 8, minimal API + controllers |
| Autenticación | JWT Bearer tokens |
| ORM | EF Core 8 (migración desde EF6) |
| Validaciones | FluentValidation |
| Documentación API | Swagger / OpenAPI |
| Logging | Serilog → archivo + seq |
| Tests | xUnit + Moq + FluentAssertions |
| CI/CD | GitHub Actions |

## Módulos del Sistema

| Módulo | Descripción |
|--------|-------------|
| Auth | Login, validación de usuario, parámetros globales |
| Customers | CRUD cliente, direcciones de entrega, validación RUC/CI |
| Products | Búsqueda, consulta de precio/stock, peso variable |
| Invoices | Creación de factura, anulación, tickets |
| Payments | Efectivo, tarjeta, cheque, crédito interno, gift card, retención, anticipo, devolución |
| SalesOrders | Creación, edición, copiado, conversión a factura |
| RemissionGuide | Guías de remisión, selección de órdenes, conversión a factura |
| ClosingCashier | Cierre total, cierre parcial, anulación de cierre, denominaciones |
| PhysicalStock | Conteo físico, líneas de inventario |
| SalesOrigin | Canal de venta (tienda, delivery, e-commerce, etc.) |
| Configuration | Punto de emisión, parámetros globales, impuestos |
