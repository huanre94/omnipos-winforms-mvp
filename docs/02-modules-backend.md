# OmniPOS — Módulos y Lógica de Negocio (Backend)

> Este documento describe cada módulo con sus entidades, reglas de negocio y contratos de API sugeridos.
> El backend es la fuente de verdad: **todas las validaciones deben vivir aquí**.

---

## 1. Módulo Auth

### Entidades involucradas
- `UserLogin`, `SP_Login_Consult_Result`, `GlobalParameter`, `EmissionPoint`

### Lógica de negocio
- Autenticar usuario por `Username + Password + Workstation + IP`.
- Validar que el punto de emisión esté configurado y activo para la máquina.
- Devolver parámetros globales del sistema junto al token.
- Validar autorización de supervisor (`SP_Supervisor_Validate`).

### Reglas de validación
- Usuario y contraseña requeridos.
- IP y nombre de máquina deben coincidir con los registrados.
- Un usuario no puede tener dos sesiones activas simultáneas en distintas cajas (si aplica).

### Endpoints sugeridos
```
POST /api/auth/login          → LoginRequest → LoginResponse (token + globalParams)
POST /api/auth/supervisor     → SupervisorAuthRequest → bool
GET  /api/auth/emission-point → EmissionPointResponse
```

---

## 2. Módulo Customers

### Entidades
- `Customer`, `CustomerAddress`, `IdentType`, `CustomerType`

### Lógica de negocio
- Buscar cliente por cédula / RUC / pasaporte.
- Validar tipo y formato de identificación (`FN_Identification_Validate`).
- Crear o actualizar cliente (`SP_Customer_Insert`).
- Gestionar múltiples direcciones de entrega por cliente.
- Un cliente puede tener retención habilitada (`UseRetention`).

### Reglas de validación
- Identificación: formato según tipo (CI = 10 dígitos, RUC = 13 dígitos).
- Nombre, apellido, email: requeridos para factura con datos.
- Solo un cliente con status `A` puede ser seleccionado.
- Dirección de entrega: campos `Address`, `Telephone` requeridos.

### Endpoints sugeridos
```
GET    /api/customers/{identification}         → CustomerResponse
GET    /api/customers/{customerId}/addresses   → List<CustomerAddressResponse>
POST   /api/customers                          → CreateCustomerRequest → CustomerResponse
PUT    /api/customers/{customerId}             → UpdateCustomerRequest → CustomerResponse
POST   /api/customers/{customerId}/addresses   → CreateAddressRequest → CustomerAddressResponse
PUT    /api/customers/addresses/{addressId}    → UpdateAddressRequest → CustomerAddressResponse
POST   /api/customers/validate-identification  → ValidateIdentRequest → ValidationResult
```

---

## 3. Módulo Products

### Entidades
- `Product`, `ProductBarcode`, `InventUnit`, `ProductCategory`, `ProductGroup`, `SP_Product_Consult_Result`

### Lógica de negocio
- Consultar producto por código de barras o nombre.
- Calcular precio con descuentos, promociones y modo de pago (`SP_Product_Consult`).
- Soporte para productos de peso variable (balanza integrada).
- Consultar barras adicionales (`SP_ProductBarcode_Consult`).
- Verificador de precios independiente.

### Reglas de validación
- Producto no puede tener precio `<= 0` (IG003).
- Cantidad debe ser positiva y en la unidad correspondiente.
- Si el producto requiere peso, se debe leer de la balanza.
- Validar stock disponible según ubicación (`LocationId`).

### Endpoints sugeridos
```
GET  /api/products/barcode/{barcode}                    → ProductConsultResponse
GET  /api/products/search?name={name}                   → List<ProductResponse>
POST /api/products/consult                              → ProductConsultRequest → ProductConsultResponse
GET  /api/products/{productId}/barcodes                 → List<ProductBarcodeResponse>
```

---

## 4. Módulo Invoices

### Entidades
- `InvoiceTable`, `InvoiceLine`, `InvoicePayment`, `SP_Invoice_Insert_Result`, `SalesLog`

### Lógica de negocio
- Crear factura con líneas de productos y pagos via XML (`SP_Invoice_Insert`).
- Anular factura (`SP_InvoiceCancel_Consult`), requiere autorización de supervisor.
- Consultar ticket de impresión (`SP_InvoiceTicket_Consult`).
- Suspender y reanudar factura en progreso (`SalesLog`).
- Detectar si hay una venta suspendida al abrir caja.
- Calcular: Base IVA 0%, Base IVA X%, IVA, IRBP, Descuento.

### Reglas de validación
- Al menos una línea de producto es requerida.
- El monto pagado debe cubrir el total de la factura.
- Si hay retención, debe registrarse en el mismo documento.
- No se puede facturar si el punto de emisión no está configurado.
- Descuento no puede exceder el subtotal del producto (HR001).

### Endpoints sugeridos
```
POST /api/invoices                          → CreateInvoiceRequest (XML) → InvoiceResult
GET  /api/invoices/{invoiceId}/ticket       → List<InvoiceTicketLine>
POST /api/invoices/{invoiceId}/cancel       → CancelInvoiceRequest → bool
GET  /api/invoices/suspended                → SuspendedSaleResponse
POST /api/invoices/suspend                  → SuspendInvoiceRequest → bool
POST /api/invoices/resume/{logId}           → ResumedInvoiceResponse
GET  /api/invoices/last                     → long (último número de factura)
```

---

## 5. Módulo Payments

### Entidades
- `PaymMode`, `CreditCard`, `BankCreditCard`, `GiftCardTable`, `InternalCreditCard`, `RetentionTable`, `SP_Advance_*`

### Modos de pago
| Código | Descripción |
|--------|-------------|
| CASH | Efectivo |
| CARD | Tarjeta de crédito/débito |
| CHECK | Cheque bancario |
| INTERNAL_CREDIT | Crédito interno (tarjeta interna) |
| GIFTCARD | Gift card |
| WITHHOLD | Retención |
| ADVANCE | Anticipo |
| RETURN | Devolución aplicada |

### Lógica de negocio
- Múltiples medios de pago para una sola factura.
- Calcular cambio cuando el pago en efectivo supera el total.
- Validar saldo de gift card (`SP_GiftCard_Consult`).
- Validar saldo de crédito interno (`SP_InternalCreditCard_Consult`).
- Aplicar descuento dinámico según modo de pago (HR002).
- Registrar anticipo existente y aplicarlo al total.
- Consultar y registrar retenciones.

### Reglas de validación
- La suma de pagos debe igualar o superar el total de la factura.
- Gift card: validar vigencia y saldo suficiente.
- Crédito interno: validar límite disponible.
- Retención: solo si el cliente tiene `UseRetention = true`.
- Anticipo: verificar que el anticipo pertenece al cliente activo.
- Cambio solo aplica para pago en efectivo.

### Endpoints sugeridos
```
GET  /api/payments/modes                        → List<PaymModeResponse>
POST /api/payments/giftcard/validate            → GiftCardValidateRequest → GiftCardBalanceResponse
POST /api/payments/giftcard/redeem              → GiftCardRedeemRequest → RedeemResult
GET  /api/payments/internal-credit/{cardCode}   → InternalCreditBalanceResponse
POST /api/payments/advance/consult              → AdvanceConsultRequest → AdvanceResponse
POST /api/payments/withhold                     → WithholdRequest → WithholdResult
```

---

## 6. Módulo SalesOrders

### Entidades
- `SalesOrder`, `SalesOrderLine`, `SalesOrderPayment`, `SalesOrderText`, `SalesOrderStatus`

### Lógica de negocio
- Crear y actualizar órdenes de venta (`SP_SalesOrderOmnipos_Insert`).
- Copiar una orden existente como nueva.
- Convertir orden a factura (`SP_SalesOrderToInvoice_Insert`).
- Consultar órdenes por estado y canal de venta.
- Registrar texto libre en la orden (`SalesOrderText`).
- Soporte para pagos anticipados en la orden.

### Reglas de validación
- Orden debe tener al menos una línea.
- No se puede convertir a factura una orden ya facturada.
- El cliente de la orden debe existir y estar activo.
- Canal de venta (`SalesOriginId`) es requerido.

### Endpoints sugeridos
```
GET    /api/sales-orders                          → filtros → List<SalesOrderResponse>
GET    /api/sales-orders/{salesOrderId}           → SalesOrderDetailResponse
POST   /api/sales-orders                          → CreateSalesOrderRequest → SalesOrderResult
PUT    /api/sales-orders/{salesOrderId}           → UpdateSalesOrderRequest → SalesOrderResult
POST   /api/sales-orders/{salesOrderId}/copy      → SalesOrderDetailResponse
POST   /api/sales-orders/{salesOrderId}/to-invoice → InvoiceResult
GET    /api/sales-orders/status                   → List<SalesOrderStatus>
```

---

## 7. Módulo RemissionGuide

### Entidades
- `SalesRemissionTable`, `SalesRemissionLine`, `Transport`, `TransportDriver`, `TransportReason`

### Lógica de negocio
- Crear guía de remisión desde una orden de venta (`SP_RemissionGuideSalesOrder_Consult`).
- Convertir guía de remisión a factura (`SP_RemissionGuideInvoice_Insert`).
- Anular guía de remisión (`SP_RemissionGuide_Cancel`).
- Consultar órdenes pendientes de remisión (`SP_RemissionPendingSalesOrder_Consult`).
- Seleccionar transportista y conductor.

### Reglas de validación
- Solo se puede crear guía desde una orden confirmada.
- Transportista y motivo de traslado son requeridos.
- No se puede anular una guía ya convertida a factura.

### Endpoints sugeridos
```
GET  /api/remission-guides                              → List<RemissionGuideResponse>
GET  /api/remission-guides/{remissionId}                → RemissionGuideDetailResponse
POST /api/remission-guides                              → CreateRemissionRequest → RemissionResult
POST /api/remission-guides/{remissionId}/cancel         → CancelRemissionResult
POST /api/remission-guides/{remissionId}/to-invoice     → InvoiceResult
GET  /api/remission-guides/pending-orders               → List<PendingSalesOrderResponse>
GET  /api/remission-guides/orders/{salesOrderId}        → RemissionGuideOrderResponse
```

---

## 8. Módulo ClosingCashier

### Entidades
- `ClosingCashierTable`, `ClosingCashierLine`, `ClosingCashierMoney`, `CurrencyDenomination`

### Lógica de negocio
- Cierre total de caja (`SP_ClosingCashier_Insert`).
- Cierre parcial de caja (`SP_ClosingCashierPartial_Insert`).
- Anular cierre (`FrmVoidClosing`).
- Consultar denominaciones de monedas/billetes.
- Consultar resumen de pagos del turno.
- Imprimir ticket de cierre.

### Reglas de validación
- Solo el cajero activo puede realizar el cierre.
- No se puede realizar cierre total si hay facturas pendientes.
- El cierre parcial requiere registrar el monto en bóveda.
- Solo supervisor puede anular un cierre.

### Endpoints sugeridos
```
GET  /api/closing/denominations                 → List<DenominationResponse>
GET  /api/closing/payments                      → ClosingPaymentSummaryResponse
GET  /api/closing/partials                      → List<PartialClosingResponse>
POST /api/closing/full                          → FullClosingRequest → ClosingResult
POST /api/closing/partial                       → PartialClosingRequest → ClosingResult
POST /api/closing/void                          → VoidClosingRequest → bool
GET  /api/closing/ticket/{closingId}            → List<ClosingTicketLine>
```

---

## 9. Módulo PhysicalStock

### Entidades
- `PhysicalStockCountingTable`, `PhysicalStockCountingLine`

### Lógica de negocio
- Iniciar conteo físico de inventario.
- Agregar líneas por producto escaneado.
- Confirmar y guardar conteo (`SP_PhysicalStockCounting_Insert`).
- Consultar diferencias entre stock físico y sistema.

### Reglas de validación
- No se puede iniciar conteo durante turno con ventas activas (según configuración).
- Producto debe existir en la ubicación (`InventLocation`).
- Cantidad contada no puede ser negativa.

### Endpoints sugeridos
```
GET  /api/physical-stock                        → List<StockCountingResponse>
GET  /api/physical-stock/{countingId}           → StockCountingDetailResponse
POST /api/physical-stock                        → CreateCountingRequest → CountingResult
POST /api/physical-stock/{countingId}/lines     → AddStockLineRequest → StockLineResult
POST /api/physical-stock/{countingId}/confirm   → ConfirmCountingResult
GET  /api/physical-stock/products               → List<StockProductResponse>
```

---

## 10. Módulo Configuration / Catalog

### Entidades
- `EmissionPoint`, `GlobalParameter`, `SalesOrigin`, `TaxTable`, `InventLocation`, `Salesman`

### Lógica de negocio
- Leer parámetros globales del sistema.
- Obtener punto de emisión por workstation.
- Consultar canales de venta (`SalesOrigin`).
- Consultar impuesto activo.
- Consultar vendedores disponibles.

### Endpoints sugeridos
```
GET /api/config/global-parameters       → List<GlobalParameter>
GET /api/config/emission-point          → EmissionPointResponse
GET /api/config/sales-origins           → List<SalesOriginResponse>
GET /api/config/tax                     → TaxResponse
GET /api/config/salesmen                → List<SalesmanResponse>
GET /api/config/locations               → List<LocationResponse>
```
