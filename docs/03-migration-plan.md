# OmniPOS — Plan de Migración Front/Back

## Fases

```
Fase 1: Implementar Clean Architecture con API REST
Fase 2: Reemplazar el frontend WinForms
Fase 3: Pruebas, CI/CD y despliegue
```

---

## Fase 1 — Implementar Clean Architecture con API REST

**Objetivo**: Construir el backend desde cero con arquitectura limpia, separando la lógica de negocio en capas bien definidas. NO hacer proxy de `POS.DLL`.

### 1.1 — Preparar la infraestructura base

**POS.Domain** (capa de dominio puro):
1. Definir entidades de dominio en `POS.Domain/Entities/`:
   - `Customer.cs`, `Invoice.cs`, `Product.cs`, `SalesOrder.cs`, `Payment.cs`, etc.
   - Usar **Value Objects** para conceptos como `Identification`, `Money`, `Address`.
2. Crear interfaces de repositorio en `POS.Domain/Interfaces/Repositories/`:
   - `ICustomerRepository`, `IInvoiceRepository`, `IProductRepository`, etc.
3. Mover enumeraciones desde `POS.DLL/Enums/` a `POS.Domain/Enums/`.
4. No referenciar Entity Framework ni ninguna tecnología de infraestructura.

**Domain.Application** (casos de uso):
1. Crear DTOs en `Domain.Application/DTOs/`:
   - `Requests/`: `LoginRequest`, `CreateCustomerRequest`, `CreateInvoiceRequest`, etc.
   - `Responses/`: `LoginResponse`, `CustomerResponse`, `InvoiceResponse`, etc.
2. Crear Application Services en `Domain.Application/Services/`:
   - `AuthService`, `CustomerService`, `ProductService`, `InvoiceService`, `PaymentService`, `SalesOrderService`, `ClosingCashierService`.
3. Implementar validadores con **FluentValidation** en `Domain.Application/Validators/`:
   - `LoginRequestValidator`, `CreateCustomerRequestValidator`, etc.
4. Extraer y reescribir la lógica de negocio que hoy vive en:
   - Stored Procedures → métodos en los Services.
   - Forms de WinForms → Validators.
   - Repositorios de `POS.DLL` → Services.

### 1.2 — Implementar la capa de infraestructura

**POS.Infrastructure** (acceso a datos y servicios externos):
1. Migrar el modelo de Entity Framework 6 a **EF Core 8**:
   - Usar `scaffold-dbcontext` desde la base de datos existente.
   - Crear `PosDbContext.cs` en `POS.Infrastructure/Persistence/`.
2. Implementar repositorios concretos en `POS.Infrastructure/Persistence/Repositories/`:
   - `CustomerRepository.cs`, `InvoiceRepository.cs`, `ProductRepository.cs`, etc.
   - Implementar las interfaces definidas en `POS.Domain`.
3. Envolver llamadas a **Stored Procedures** con `FromSqlRaw` / `ExecuteSqlRaw`:
   - Crear métodos privados en los repositorios para cada SP.
   - Mapear resultados a entidades de dominio.
4. Crear servicios para periféricos en `POS.Infrastructure/ExternalServices/`:
   - `PrinterService.cs` (impresoras térmicas).
   - `ScaleService.cs` (balanzas).
   - `ScannerService.cs` (lectores de código de barras).
5. Configurar **Dependency Injection** en `POS.Infrastructure/DependencyInjection.cs`:
   - Registrar `DbContext`, repositorios, servicios externos.

### 1.3 — Construir la API REST

**POS.Api** (capa de presentación HTTP):
1. Configurar `Program.cs`:
   - Registrar servicios de `Domain.Application` y `POS.Infrastructure`.
   - Configurar **JWT Authentication** con `AddAuthentication().AddJwtBearer()`.
   - Agregar **Swagger/OpenAPI** con `AddSwaggerGen()`.
   - Configurar **Serilog** para logging estructurado.
2. Crear Middleware en `POS.Api/Middleware/`:
   - `ErrorHandlingMiddleware.cs` → captura excepciones y retorna JSON estructurado.
   - `RequestLoggingMiddleware.cs` → log de todas las peticiones HTTP.
3. Crear Controllers en `POS.Api/Controllers/` (uno por módulo):
   - `AuthController.cs` → `/api/auth/login`, `/api/auth/supervisor`.
   - `CustomersController.cs` → CRUD de clientes y direcciones.
   - `ProductsController.cs` → búsqueda y consulta de productos.
   - `InvoicesController.cs` → creación, anulación, tickets.
   - `PaymentsController.cs` → validación de medios de pago.
   - `SalesOrdersController.cs` → CRUD de órdenes.
   - `RemissionGuidesController.cs` → guías de remisión.
   - `ClosingCashierController.cs` → cierres de caja.
   - `PhysicalStockController.cs` → conteo físico.
   - `ConfigController.cs` → parámetros globales y catálogos.
4. Los Controllers **solo** llaman a los Application Services, nunca a repositorios directamente.
5. Validar automáticamente los Requests con `FluentValidation.AspNetCore`.

### 1.4 — Manejar la transición con WinForms

**Estrategia de coexistencia**:
- `POS.DLL` sigue funcionando para el WinForms actual.
- La nueva API **no referencia** `POS.DLL`, es independiente.
- Ambos sistemas apuntan a la **misma base de datos**.
- Comunicación:
  - WinForms → `POS.DLL` → SQL Server (estado actual).
  - Nueva API → `POS.Infrastructure` → SQL Server (nueva arquitectura).
- Durante esta fase, **no modificar** el WinForms existente.

**Resultado**: API REST funcional con Clean Architecture. WinForms sigue operando en paralelo sin cambios.

---

## Fase 2 — Reemplazar el frontend WinForms

**Objetivo**: Migrar el frontend para que consuma la nueva API en lugar de `POS.DLL`.

---

**Objetivo**: Reemplazar WinForms con una interfaz moderna que consuma la API.

### Opciones (elegir una)
| Opción | Pro | Contra |
|--------|-----|--------|
| WinForms + HttpClient | Mínimo cambio, equipo lo conoce | Tecnología legada |
| Blazor WebAssembly | .NET puro, sin JS | Curva de aprendizaje UI |
| React + TypeScript | Ecosistema enorme, ideal para web | Requiere conocimiento JS/TS |
| .NET MAUI | Cross-platform desktop/mobile | Complejo para POS táctil |

### Pasos (para cualquier opción)
1. Crear cliente HTTP tipado que consuma los endpoints de `POS.Api`.
2. Implementar pantalla de Login.
3. Implementar pantalla principal de venta (FrmMain equivalente).
4. Implementar flujo de pago.
5. Implementar gestión de clientes.
6. Implementar órdenes de venta.
7. Implementar cierre de caja.
8. Manejar impresión de tickets (API → base64 / ZPL / ESC-POS).

---

## Fase 3 — Pruebas y CI/CD

1. Agregar pruebas unitarias en `POS.Tests` para Application Services.
2. Agregar pruebas de integración para los Controllers.
3. Configurar GitHub Actions:
   - Build + Test en cada PR.
   - Publicar artefactos de `POS.Api`.
4. Configurar Serilog con niveles configurables por ambiente.

---

## Mapeo WinForms → API

| Form actual | Módulo API | Notas |
|-------------|-----------|-------|
| `FrmLogin` | `POST /api/auth/login` | |
| `FrmMenu` | `GET /api/config/*` | Solo lectura de config |
| `FrmMain` | `POST /api/invoices`, `GET /api/products/*` | Flujo principal de venta |
| `FrmCustomer` | `GET/POST/PUT /api/customers` | |
| `FrmAddressPicker` | `GET/POST /api/customers/{id}/addresses` | |
| `FrmPayment` | `POST /api/invoices` (con nodo Payment en XML) | |
| `FrmPaymentCard` | `POST /api/payments/card` | |
| `FrmPaymentCheck` | `POST /api/payments/check` | |
| `FrmPaymentCredit` | `GET/POST /api/payments/internal-credit` | |
| `FrmPaymentGiftcard` | `POST /api/payments/giftcard/validate` + `/redeem` | |
| `FrmPaymentWithhold` | `POST /api/payments/withhold` | |
| `FrmPaymentAdvance` | `POST /api/payments/advance/consult` | |
| `FrmSalesOrder` | `GET/POST/PUT /api/sales-orders` | |
| `FrmSalesOrderHeader` | `POST /api/sales-orders` (headers) | |
| `FrmSalesOrderPicker` | `GET /api/sales-orders` | |
| `FrmRemissionGuide` | `POST /api/remission-guides` | |
| `FrmRemissionGuideOrderSelector` | `GET /api/remission-guides/pending-orders` | |
| `FrmRemissionGuideOrderToInvoice` | `POST /api/remission-guides/{id}/to-invoice` | |
| `FrmClosingCashier` | `POST /api/closing/full` | |
| `FrmPartialClosing` | `POST /api/closing/partial` | |
| `FrmVoidClosing` | `POST /api/closing/void` | Requiere supervisor |
| `FrmInvoiceCancel` | `POST /api/invoices/{id}/cancel` | Requiere supervisor |
| `FrmReturns` | `POST /api/invoices` (tipo devolución) | |
| `FrmRedeemGiftCard` | `POST /api/payments/giftcard/redeem` | |
| `FrmProductSearch` | `GET /api/products/search` | |
| `FrmProductChecker` | `GET /api/products/barcode/{barcode}` | Modo verificador |
| `FrmPhysicalStockCount` | `POST /api/physical-stock` | |
| `FrmSalesOrigin` | `GET /api/config/sales-origins` | |
| `FrmSupervisorAuth` | `POST /api/auth/supervisor` | |
| `FrmChangePaymMode` | `GET /api/payments/modes` | |
| `FrmCatchWeight` | Manejo local (balanza) → enviado como qty | |
| `FrmKeyBoard` / `FrmKeyPad` | Componentes UI puros, no necesitan API | |
| `FrmMessage` | Componente UI puro | |

---

## Deuda Técnica Identificada

| Item | Prioridad | Notas |
|------|-----------|-------|
| `ICustomerRepository` está vacía | Alta | No tiene métodos definidos |
| `CreateCustomerDeliveryAddress(CustomerAddress)` tiene código incompleto (`_dbContext.CustomerAddress.(newAddress)`) | Alta | Error de compilación |
| Stored Procedures usados como única lógica transaccional | Media | Dificulta pruebas unitarias |
| XML como parámetro de entrada a SPs | Media | Reemplazar por parámetros tipados |
| `Program.customConnectionString` global estático | Media | Reemplazar por DI |
| MVP pattern solo implementado para `Product` | Media | Extender o elegir otra arquitectura |
| `TODO` comments en múltiples repositorios | Baja | Registrar como issues en GitHub |
