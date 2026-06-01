# OmniPOS — Prompts para Implementación de Pantallas (Frontend)

> Usa cada prompt en GitHub Copilot Chat, Claude, GPT u otro asistente IA.  
> Ajusta la tecnología objetivo según la opción elegida: `WinForms`, `React`, `Blazor`, etc.
> Asume que existe un cliente HTTP tipado `PosApiClient` con métodos que retornan los DTOs de la API.

---

## PANTALLA 01 — Login (`FrmLogin`)

```
Crea el componente de Login para un sistema POS llamado OmniPOS.

Requisitos funcionales:
- Campos: Usuario (texto), Contraseña (password).
- Botón "Ingresar" y botón "Cancelar".
- Al ingresar, llamar POST /api/auth/login con { username, password, workstation, ipAddress }.
- Si la respuesta tiene error=true, mostrar mensaje de advertencia con el campo TextError.
- Si el login es exitoso, navegar a la pantalla de Menú enviando { loginInfo, globalParams }.
- Obtener la IP local de la máquina y el nombre de la workstation automáticamente.
- Mostrar cursor de espera mientras se procesa.

Validaciones:
- Usuario y contraseña son requeridos.
- Mostrar error específico si no hay conexión con la API.

Tecnología: [React/Blazor/WinForms]. Usa el cliente HTTP PosApiClient.
```

---

## PANTALLA 02 — Menú Principal (`FrmMenu`)

```
Crea el componente de Menú Principal del POS OmniPOS.

Requisitos funcionales:
- Mostrar botones de navegación: Venta (FrmMain), Órdenes de Venta, Guía de Remisión, 
  Conteo Físico, Cierre de Caja, Salir.
- El menú recibe loginInfo (usuario logueado) y globalParams (parámetros del sistema).
- Cada botón abre la pantalla correspondiente pasando loginInfo y emissionPoint.
- Botón "Salir" regresa a la pantalla de Login.
- Mostrar el nombre del usuario logueado y el punto de emisión en la barra superior.

Tecnología: [React/Blazor/WinForms].
```

---

## PANTALLA 03 — Venta Principal (`FrmMain`)

```
Crea el componente principal de venta (POS terminal) para OmniPOS.

Requisitos funcionales:
- Área de ingreso de código de barras (campo de texto + Enter para buscar).
- Grilla de líneas de venta: columnas Descripción, Cantidad, Precio Unitario, Descuento, Total.
- Panel de totales: Subtotal, IVA, IRBP, Descuento, TOTAL.
- Botones de acción: Pagar, Seleccionar Cliente, Buscar Producto, Suspender Venta, Limpiar.
- Al iniciar, verificar si existe una venta suspendida (GET /api/invoices/suspended) y preguntar si reanudar.
- Al escanear barcode: llamar POST /api/products/consult con { locationId, barcode, quantity, customerId, paymmodeId }.
- Si el producto tiene precio=0, mostrar advertencia y no agregarlo.
- Mostrar el cliente seleccionado en la parte superior (nombre e identificación).
- Al presionar "Pagar", abrir pantalla de Pago con el XML de la factura construido.
- Soporte para productos de peso variable: abrir diálogo de peso antes de agregar.
- Al limpiar: confirmar acción antes de borrar todas las líneas.

Estado a manejar:
- currentCustomer, invoiceLines[], invoiceXml, emissionPoint, loginInfo, salesOriginId.

Validaciones:
- No se puede pagar si no hay líneas en la factura.
- No se puede agregar un producto sin cliente si el parámetro global lo requiere.

Tecnología: [React/Blazor/WinForms].
```

---

## PANTALLA 04 — Búsqueda de Producto (`FrmProductSearch`)

```
Crea el componente de búsqueda de productos para OmniPOS.

Requisitos funcionales:
- Campo de búsqueda por nombre o código.
- Llamar GET /api/products/search?name={texto} al escribir (debounce 300ms).
- Mostrar resultados en grilla: Código, Nombre, Precio, Unidad, Stock.
- Al seleccionar un producto, retornarlo al componente padre (FrmMain).
- Botón "Cancelar" para cerrar sin selección.

Tecnología: [React/Blazor/WinForms].
```

---

## PANTALLA 05 — Gestión de Cliente (`FrmCustomer`)

```
Crea el componente de gestión de clientes para OmniPOS.

Requisitos funcionales:
- Campos: Tipo de Identificación (dropdown), Número de Identificación, Nombres, Apellidos, 
  Email, Teléfono, Dirección, Tipo de Cliente.
- Modo "nuevo cliente" y modo "editar cliente existente".
- Al ingresar identificación y presionar Tab/Enter: llamar GET /api/customers/{identification}.
  - Si existe, cargar los datos en el formulario (modo edición).
  - Si no existe, limpiar el formulario (modo nuevo).
- Antes de guardar, llamar POST /api/customers/validate-identification para validar formato.
- Botón "Guardar": POST /api/customers (nuevo) o PUT /api/customers/{id} (edición).
- Botón "Direcciones": abrir FrmAddressPicker para gestionar direcciones de entrega.
- Botón "Cancelar": cerrar sin guardar.
- Retornar el cliente guardado al componente padre.

Validaciones (mostrar errores inline):
- Identificación: requerida, formato según tipo (CI=10 dígitos, RUC=13 dígitos).
- Nombres y Apellidos: requeridos.
- Email: formato válido si se ingresa.

Tecnología: [React/Blazor/WinForms].
```

---

## PANTALLA 06 — Selector de Direcciones (`FrmAddressPicker`)

```
Crea el componente de gestión de direcciones de entrega para OmniPOS.

Requisitos funcionales:
- Listar las direcciones del cliente: GET /api/customers/{customerId}/addresses.
- Mostrar en lista: Dirección, Referencia, Teléfono.
- Botón "Nueva Dirección": formulario inline con Dirección, Referencia, Teléfono.
  - Guardar: POST /api/customers/{customerId}/addresses.
- Botón "Editar": cargar dirección seleccionada en formulario.
  - Guardar: PUT /api/customers/addresses/{addressId}.
- Botón "Seleccionar": retornar la dirección elegida al componente padre.
- Botón "Cancelar".

Validaciones:
- Dirección y Teléfono son requeridos.

Tecnología: [React/Blazor/WinForms].
```

---

## PANTALLA 07 — Pago (`FrmPayment`)

```
Crea el componente de pago para OmniPOS.

Requisitos funcionales:
- Panel de resumen: Base IVA 0%, Base IVA X%, IVA X%, IRBP, Descuento, Total.
- Campo "Monto a pagar" con botones de método de pago:
  Efectivo, Tarjeta, Cheque, Crédito Interno, Gift Card, Retención, Anticipo, Devolución.
- Grilla de pagos registrados (múltiples medios de pago por factura).
- Indicadores: Monto Pendiente, Cambio.
- Botón "Confirmar": solo habilitado cuando Pendiente = 0.
- Botón "Cancelar": limpiar pagos y volver a FrmMain.
- Si el cliente tiene UseRetention=true, preguntar al cargar si desea registrar retención.
- Al confirmar: llamar POST /api/invoices con el XML completo.
- Si la respuesta es exitosa, mostrar ticket de impresión.

Sub-flujos por método de pago:
- Efectivo: calcular cambio automáticamente.
- Tarjeta: abrir FrmPaymentCard.
- Cheque: abrir FrmPaymentCheck.
- Crédito Interno: abrir FrmPaymentCredit.
- Gift Card: abrir FrmPaymentGiftcard.
- Retención: abrir FrmPaymentWithhold.
- Anticipo: abrir FrmPaymentAdvance.

Estado: paymentLines[], pendingAmount, changeAmount, paymentXml.

Tecnología: [React/Blazor/WinForms].
```

---

## PANTALLA 08 — Pago con Tarjeta (`FrmPaymentCard`)

```
Crea el componente de pago con tarjeta crédito/débito para OmniPOS.

Requisitos funcionales:
- Dropdown de bancos emisores: GET /api/payments/modes?type=CARD.
- Campos: Banco, Número de Lote, Número de Autorización, Monto.
- Botón "Aceptar" y "Cancelar".
- Al aceptar, retornar { bank, lot, authorization, amount } al componente FrmPayment.

Validaciones:
- Banco requerido.
- Número de autorización requerido.
- Monto > 0.

Tecnología: [React/Blazor/WinForms].
```

---

## PANTALLA 09 — Crédito Interno (`FrmPaymentCredit`)

```
Crea el componente de pago con crédito interno para OmniPOS.

Requisitos funcionales:
- Campo para código de tarjeta de crédito interna.
- Al ingresar código: llamar GET /api/payments/internal-credit/{cardCode}.
- Mostrar: titular, saldo disponible, límite de crédito.
- Campo de monto a aplicar (máximo = pendiente de pago o saldo disponible).
- Botón "Aceptar" y "Cancelar".

Validaciones:
- Código de tarjeta requerido y debe existir.
- Monto no puede exceder el saldo disponible.
- Monto no puede exceder el pendiente de pago.

Tecnología: [React/Blazor/WinForms].
```

---

## PANTALLA 10 — Gift Card (`FrmPaymentGiftcard`)

```
Crea el componente de pago con Gift Card para OmniPOS.

Requisitos funcionales:
- Campo para código de Gift Card.
- Al ingresar código: llamar POST /api/payments/giftcard/validate con { code }.
- Mostrar saldo disponible y vigencia.
- Campo de monto a aplicar.
- Botón "Aceptar": llamar POST /api/payments/giftcard/redeem.
- Botón "Cancelar".

Validaciones:
- Gift Card debe existir y tener saldo > 0.
- Gift Card no debe estar vencida.
- Monto no puede exceder el saldo disponible ni el pendiente.

Tecnología: [React/Blazor/WinForms].
```

---

## PANTALLA 11 — Retención (`FrmPaymentWithhold`)

```
Crea el componente de registro de retención fiscal para OmniPOS.

Requisitos funcionales:
- Campos: Número de Comprobante de Retención, Porcentaje de Retención, Monto.
- Mostrar el monto de la retención calculado automáticamente.
- Botón "Aceptar" y "Cancelar".
- Solo disponible para clientes con UseRetention=true.

Validaciones:
- Número de comprobante requerido.
- Porcentaje debe ser > 0.

Tecnología: [React/Blazor/WinForms].
```

---

## PANTALLA 12 — Anticipo (`FrmPaymentAdvance`)

```
Crea el componente de aplicación de anticipo para OmniPOS.

Requisitos funcionales:
- Llamar POST /api/payments/advance/consult con { customerId } para buscar anticipos.
- Mostrar anticipos disponibles en grilla: Número, Fecha, Monto, Saldo.
- Seleccionar anticipo(s) a aplicar.
- Mostrar monto total a aplicar.
- Botón "Aceptar" y "Cancelar".

Validaciones:
- Solo anticipos con saldo > 0 pueden seleccionarse.
- El monto aplicado no puede exceder el pendiente de pago.

Tecnología: [React/Blazor/WinForms].
```

---

## PANTALLA 13 — Orden de Venta (`FrmSalesOrder`)

```
Crea el componente de gestión de orden de venta para OmniPOS.

Requisitos funcionales:
- Listar órdenes: GET /api/sales-orders con filtros de estado y fecha.
- Grilla de órdenes: Número, Fecha, Cliente, Canal, Estado, Total.
- Botones: Nueva Orden, Editar, Copiar, Convertir a Factura, Cancelar.
- Al "Nueva Orden": abrir FrmSalesOrderHeader para capturar cabecera.
- Al "Editar": cargar la orden seleccionada en modo edición.
- Al "Copiar": POST /api/sales-orders/{id}/copy.
- Al "Convertir a Factura": POST /api/sales-orders/{id}/to-invoice, luego navegar a FrmPayment.

Validaciones:
- Solo órdenes en estado "pendiente" pueden editarse o convertirse.

Tecnología: [React/Blazor/WinForms].
```

---

## PANTALLA 14 — Cabecera de Orden de Venta (`FrmSalesOrderHeader`)

```
Crea el componente de cabecera de orden de venta para OmniPOS.

Requisitos funcionales:
- Campos: Cliente (búsqueda por identificación), Canal de Venta (dropdown), 
  Vendedor (dropdown), Fecha de Entrega, Observaciones.
- Canal de venta: GET /api/config/sales-origins.
- Vendedores: GET /api/config/salesmen.
- Líneas de productos: igual que FrmMain (buscar por código/nombre, cantidad, precio).
- Notas de texto libre: campo adicional por línea.
- Totales calculados en tiempo real.
- Botón "Guardar": POST /api/sales-orders.
- Botón "Cancelar".

Validaciones:
- Cliente requerido.
- Canal de venta requerido.
- Al menos una línea de producto.

Tecnología: [React/Blazor/WinForms].
```

---

## PANTALLA 15 — Cierre de Caja (`FrmClosingCashier`)

```
Crea el componente de cierre de caja para OmniPOS.

Requisitos funcionales:
- Mostrar resumen de pagos del turno: GET /api/closing/payments.
- Mostrar grilla de denominaciones para conteo de efectivo: GET /api/closing/denominations.
  - Por cada denominación: campo para ingresar cantidad contada.
  - Calcular subtotal por denominación y total contado automáticamente.
- Mostrar diferencia entre efectivo del sistema vs. contado.
- Botón "Cierre Total": POST /api/closing/full con el XML de cierre.
- Mostrar ticket de cierre al finalizar.
- Requiere confirmación antes de ejecutar.

Validaciones:
- Solo puede ejecutarse si hay pagos registrados en el turno.
- Confirmar si hay diferencia en el efectivo.

Tecnología: [React/Blazor/WinForms].
```

---

## PANTALLA 16 — Cierre Parcial (`FrmPartialClosing`)

```
Crea el componente de cierre parcial de caja para OmniPOS.

Requisitos funcionales:
- Mostrar cierres parciales previos: GET /api/closing/partials.
- Campo para ingresar monto a enviar a bóveda.
- Campo de observación.
- Botón "Registrar Cierre Parcial": POST /api/closing/partial.
- Imprimir ticket del cierre parcial.

Validaciones:
- Monto a bóveda > 0.
- No puede exceder el efectivo disponible.

Tecnología: [React/Blazor/WinForms].
```

---

## PANTALLA 17 — Anulación de Factura (`FrmInvoiceCancel`)

```
Crea el componente de anulación de factura para OmniPOS.

Requisitos funcionales:
- Campo para buscar factura por número.
- Mostrar detalle de la factura encontrada.
- Dropdown de motivo de anulación: GET /api/config/cancel-reasons.
- Requerir autorización de supervisor antes de confirmar: POST /api/auth/supervisor.
- Botón "Anular": POST /api/invoices/{invoiceId}/cancel.
- Imprimir comprobante de anulación.

Validaciones:
- Factura debe existir y estar activa.
- Motivo de anulación requerido.
- Autorización de supervisor obligatoria.

Tecnología: [React/Blazor/WinForms].
```

---

## PANTALLA 18 — Guía de Remisión (`FrmRemissionGuide`)

```
Crea el componente de guía de remisión para OmniPOS.

Requisitos funcionales:
- Listar guías existentes: GET /api/remission-guides.
- Botón "Nueva Guía": abrir selector de órdenes pendientes (FrmRemissionGuideOrderSelector).
- Campos de cabecera: Transportista, Conductor, Placa, Motivo de Traslado, Dirección Destino.
- Líneas de productos provenientes de la orden seleccionada.
- Botón "Guardar": POST /api/remission-guides.
- Botón "Convertir a Factura": POST /api/remission-guides/{id}/to-invoice.
- Botón "Anular": POST /api/remission-guides/{id}/cancel (requiere supervisor).

Validaciones:
- Transportista y motivo de traslado son requeridos.
- No se puede anular una guía ya convertida a factura.

Tecnología: [React/Blazor/WinForms].
```

---

## PANTALLA 19 — Conteo Físico de Inventario (`FrmPhysicalStockCount`)

```
Crea el componente de conteo físico de inventario para OmniPOS.

Requisitos funcionales:
- Iniciar un nuevo conteo: POST /api/physical-stock.
- Campo de código de barras para escanear productos.
- Al escanear: GET /api/products/barcode/{barcode}, agregar a la grilla con cantidad 1.
- Si el producto ya está en la grilla, incrementar la cantidad.
- Campo editable de cantidad por línea.
- Botón "Confirmar Conteo": POST /api/physical-stock/{id}/confirm.
- Mostrar diferencias entre conteo y stock del sistema.

Validaciones:
- Producto debe existir en el catálogo.
- Cantidad no puede ser negativa.
- Confirmar antes de finalizar el conteo.

Tecnología: [React/Blazor/WinForms].
```

---

## PANTALLA 20 — Autenticación de Supervisor (`FrmSupervisorAuth`)

```
Crea el componente modal de autenticación de supervisor para OmniPOS.

Requisitos funcionales:
- Diálogo modal con campos: Usuario Supervisor y Contraseña.
- Botón "Autorizar": POST /api/auth/supervisor.
- Si la respuesta es exitosa, retornar true al componente padre.
- Si falla, mostrar mensaje de error y permitir reintentar.
- Botón "Cancelar": retornar false.

Validaciones:
- Usuario y contraseña requeridos.
- Máximo 3 intentos antes de bloquear.

Tecnología: [React/Blazor/WinForms]. Modal/Dialog reutilizable.
```

---

## PANTALLA 21 — Verificador de Precio (`FrmProductChecker`)

```
Crea el componente verificador de precios para OmniPOS (modo kiosko).

Requisitos funcionales:
- Campo de código de barras, se activa al escanear.
- Llamar GET /api/products/barcode/{barcode} automáticamente.
- Mostrar a pantalla completa: Nombre del producto, Precio, Código.
- Limpiar automáticamente después de 5 segundos.
- No requiere login (modo público).

Tecnología: [React/Blazor/WinForms].
```

---

## COMPONENTE REUTILIZABLE — Teclado Virtual (`FrmKeyBoard` / `FrmKeyPad`)

```
Crea un componente de teclado virtual para pantallas táctiles en OmniPOS.

Variante 1 - Teclado Alfanumérico (FrmKeyBoard):
- Teclado QWERTY completo con mayúsculas/minúsculas.
- Teclas especiales: Backspace, Enter, Space.
- Se vincula a un campo de texto del componente padre.

Variante 2 - Teclado Numérico (FrmKeyPad):
- Botones 0-9, punto decimal, Backspace, Enter.
- Se vincula a un campo numérico del componente padre.
- Opcional: mostrar el valor actual en display superior.

Ambos se abren como modal al tocar/hacer focus en el campo vinculado.

Tecnología: [React/Blazor/WinForms]. Componente reutilizable.
```
