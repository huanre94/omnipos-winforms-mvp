-- ============================================================
-- DML Part 04: POS & Miscellaneous Data
-- Tables: PromotionType, PromotionTable, EmissionPoint,
--         SequenceType, SequenceTable, CurrencyType,
--         DenominationType, CurrencyDenomination, SalesOrigin,
--         TransferStatus, SalesOrderStatus, LogType,
--         CancelReason, Program, UserProfile
-- ============================================================

USE POSDB
GO

-- PromotionType
INSERT INTO [PromotionType]
SELECT *, 'A', 1, 0, NULL, NULL, 'SERVER'
FROM (
	  SELECT  1 [PromotionTypeId], 'CUPONES PARA SORTEOS'                      [Name], 'CUST' [Type], 1 [UseCoupon], 0 [UseReward], 0 [ControlCoupon]
UNION SELECT  2, 'CUPONES CON STOCK SORTEOS',                                          'CSST', 1, 0, 1
UNION SELECT  3, 'CUPONES PARA PREMIOS',                                               'CUPR', 1, 1, 0
UNION SELECT  4, 'CUPONES CON STOCK PREMIOS',                                          'CSPR', 1, 1, 1
UNION SELECT  5, 'DESCUENTO 2X1',                                                      'D2X1', 0, 0, 0
UNION SELECT  6, 'DESCUENTO 3X2',                                                      'D3X2', 0, 0, 0
UNION SELECT  7, 'DESCUENTO 4X3',                                                      'D4X3', 0, 0, 0
UNION SELECT  8, 'DESCUENTO CLIENTES LISTADOS',                                        'DCLI', 0, 0, 0
UNION SELECT  9, 'DESCUENTO EMPLEADOS',                                                'DEMP', 0, 0, 0
UNION SELECT 10, 'DESCUENTO PORCENTAJE PRODUCTO PRINCIPAL',                            'DSCP', 0, 0, 0
UNION SELECT 11, 'DESCUENTO PORCENTAJE PRODUCTO SECUNDARIO',                           'DSCS', 0, 0, 0
UNION SELECT 12, 'DESCUENTO PORCENTAJE PRODUCTO ADICIONAL',                            'DSCA', 0, 1, 0
UNION SELECT 13, 'DESCUENTO PORCENTAJE SEGUNDA LIBRA',                                 'DPSL', 0, 0, 0) VIRT
GO

-- PromotionTable
INSERT INTO [PromotionTable]
      SELECT  1, 'EMPLEADOS LA ESPANOLA DESCUENTO 10%',         9, 'V',  0, '20200101', '20501231', 1, 1, 1, 1, 1, 1, 1, 'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT  2, 'MARTES DE EMBUTIDOS DESCUENTO 20%',          10, 'C',  0, '20200101', '20501231', 0, 1, 0, 0, 0, 0, 0, 'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT  3, 'MIERCOLES DE FRUTAS Y VEGETALES 25%',        10, 'C',  0, '20200101', '20501231', 0, 0, 1, 0, 0, 0, 0, 'I', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT  4, 'CLIENTES GOLDGYMS DESCUENTO 10 %, TCR 5%',   8, 'C',  0, '20200101', '20201231', 1, 1, 1, 1, 1, 1, 1, 'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT  5, 'CLIENTES TAURUS DESCUENTO 10 %, TCR 5%',     8, 'C',  0, '20200101', '20200930', 1, 1, 1, 1, 1, 1, 1, 'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT  6, 'CLIENTES TORREMAR DESCUENTO 10 %, TCR 5%',   8, 'C',  0, '20200101', '20231031', 1, 1, 1, 1, 1, 1, 1, 'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT  7, 'FIESTAS OCTUBRINAS 2DO PROD DESCUENTO 50%', 11, 'V',  0, '20201002', '20201031', 1, 1, 1, 1, 1, 1, 1, 'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT  8, 'PROMO CRUZADA PICANHA + VINO A $5.99',       12, 'V', 20, '20201002', '20201031', 1, 1, 1, 1, 1, 1, 1, 'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT 20, 'DESCUENTO CLIENTES ESPECIALES',               9, 'V',  0, '20200101', '20501231', 1, 1, 1, 1, 1, 1, 1, 'A', 1, 0, NULL, NULL, 'SERVER'
GO

-- EmissionPoint
INSERT INTO [EmissionPoint]
SELECT *, 'A', 1, 0, NULL, NULL, 'SERVER'
FROM (
	-- SAMBORONDON
	  SELECT  1 [EmissionPointId], 1 [LocationId],  1 [InventLocationId], '002' [Establishment], '011' [Emission], 'CAJA 001 SAMBO'          [Name], '192.168.18.21' [AddressIP], ''         [ScaleName], 'METTLER_TOLEDO' [ScaleBrand], ''           [ScanBarcodeName], 'EPSON TM' [PrinterName], 1 [ThermalPrinter]
	UNION SELECT  2, 1,  1, '002', '012', 'CAJA 002 SAMBO',              '192.168.18.22', '',         'METTLER_TOLEDO', '',           'EPSON TM',   1
	UNION SELECT  3, 1,  1, '002', '013', 'CAJA 003 SAMBO',              '192.168.18.23', 'USBScale', 'DATALOGIC',     'USBScanner', 'EPSON TM',   1
	UNION SELECT  4, 1,  1, '002', '014', 'CAJA 004 SAMBO',              '192.168.18.24', '',         'METTLER_TOLEDO', '',           'EPSON TM',   1
	UNION SELECT  5, 1,  1, '002', '015', 'CAJA 005 SAMBO',              '192.168.18.25', '',         'METTLER_TOLEDO', '',           'EPSON TM',   1
	UNION SELECT  6, 1,  1, '002', '016', 'CAJA 006 SAMBO DOMICILIO',    '192.168.18.26', '',         'METTLER_TOLEDO', '',           'EPSON TM',   1
	UNION SELECT  7, 1,  1, '002', '017', 'CAJA 007 SAMBO GOURMET',      '192.168.18.27', '',         '',               '',           'EPSON TM',   1
	-- LA JOYA
	UNION SELECT  8, 2, 11, '003', '001', 'CAJA 001 LA JOYA',            '192.168.19.21', 'USBScale', 'DATALOGIC',     'USBScanner', 'LR2000',     1
	UNION SELECT  9, 2, 11, '003', '002', 'CAJA 002 LA JOYA',            '192.168.19.22', 'USBScale', 'DATALOGIC',     'USBScanner', 'LR2000',     1
	UNION SELECT 10, 2, 11, '003', '003', 'CAJA 003 LA JOYA',            '192.168.19.23', 'USBScale', 'DATALOGIC',     'USBScanner', 'LR2000',     1
	UNION SELECT 11, 2, 11, '003', '004', 'CAJA 004 LA JOYA',            '192.168.19.24', 'USBScale', 'DATALOGIC',     'USBScanner', 'LR2000',     1
	UNION SELECT 12, 2, 11, '003', '005', 'CAJA 005 LA JOYA',            '192.168.19.25', 'USBScale', 'DATALOGIC',     'USBScanner', 'LR2000',     1
	UNION SELECT 13, 2, 11, '003', '006', 'CAJA 006 LA JOYA',            '192.168.19.26', 'USBScale', 'DATALOGIC',     'USBScanner', 'LR2000',     1
	UNION SELECT 14, 2, 11, '003', '007', 'CAJA 007 LA JOYA',            '192.168.19.27', 'USBScale', 'DATALOGIC',     'USBScanner', 'LR2000',     1
	-- TEST
	UNION SELECT 15, 3,  1, '001', '010', 'CAJA TEST',                   '192.168.14.72', '',         'METTLER_TOLEDO', '',           'EPSON TM',   0
	-- DOMICILIO SAMBORONDON
	UNION SELECT 16, 1,  1, '002', '018', 'PC DOMICILIOS 3 SAMBO',       '192.168.16.14', '',         'DATALOGIC',     'USBScanner', 'LR2000',     1
	UNION SELECT 17, 1,  1, '002', '019', 'PC DOMICILIOS 1 SAMBO',       '192.168.16.13', '',         'DATALOGIC',     'USBScanner', 'LR2000',     1
	UNION SELECT 18, 1,  1, '002', '020', 'PC DOMICILIOS 2 SAMBO',       '192.168.16.12', '',         'DATALOGIC',     'USBScanner', 'LR2000',     1
	UNION SELECT 19, 1,  1, '002', '021', 'PC DOMICILIOS 4 SAMBO',       '192.168.16.15', '',         'DATALOGIC',     'USBScanner', 'LR2000',     1
	UNION SELECT 20, 1,  1, '002', '022', 'PC DOMICILIOS 5 SAMBO',       '192.168.16.16', '',         'DATALOGIC',     'USBScanner', 'LR2000',     1
	-- ALBORADA
	UNION SELECT 21, 3, 21, '001', '001', 'CAJA 001 ALBORADA',           '192.168.16.21', '',         'METTLER_TOLEDO', '',           'EPSON TM',   0
	UNION SELECT 22, 3, 21, '001', '002', 'CAJA 002 ALBORADA',           '192.168.16.22', '',         'METTLER_TOLEDO', '',           'EPSON TM',   0
	UNION SELECT 23, 3, 21, '001', '003', 'CAJA 003 ALBORADA',           '192.168.16.23', '',         'METTLER_TOLEDO', '',           'EPSON TM',   0
	UNION SELECT 24, 3, 21, '001', '004', 'CAJA 004 ALBORADA',           '192.168.16.24', '',         'METTLER_TOLEDO', '',           'EPSON TM',   0
	UNION SELECT 25, 3, 21, '001', '005', 'CAJA 005 ALBORADA',           '192.168.16.25', 'USBScale', 'DATALOGIC',     'USBScanner', 'LR2000',     0
	UNION SELECT 26, 3, 21, '001', '006', 'CAJA 006 ALBORADA',           '192.168.16.26', '',         'METTLER_TOLEDO', '',           'EPSON TM',   0
	UNION SELECT 27, 3, 21, '001', '007', 'PC DOMICILIOS 001',           '192.168.16.12', '',         'METTLER_TOLEDO', '',           'EPSON TM',   1
	-- DOMICILIO LA JOYA
	UNION SELECT 28, 2, 11, '003', '009', 'PC DOMICILIOS 001 LA JOYA',   '192.168.19.11', 'USBScale', 'DATALOGIC',     'USBScanner', 'LR2000',     1
	UNION SELECT 29, 2, 11, '003', '010', 'PC DOMICILIOS 002 LA JOYA',   '192.168.19.12', 'USBScale', 'DATALOGIC',     'USBScanner', 'LR2000',     1
	-- AMERICAS
	UNION SELECT 30, 4, 31, '001', '001', 'CAJA 001 AMERICAS',           '192.168.15.21', '',         'METTLER_TOLEDO', '',           'EPSON TM',   0
	UNION SELECT 31, 4, 31, '001', '002', 'CAJA 002 AMERICAS',           '192.168.15.22', '',         'METTLER_TOLEDO', '',           'EPSON TM',   0
	UNION SELECT 32, 4, 31, '001', '003', 'CAJA 003 AMERICAS',           '192.168.15.23', '',         'METTLER_TOLEDO', '',           'EPSON TM',   0
	UNION SELECT 33, 4, 31, '001', '004', 'CAJA 004 AMERICAS',           '192.168.15.24', '',         'METTLER_TOLEDO', '',           'EPSON TM',   0
	UNION SELECT 34, 4, 31, '001', '005', 'CAJA 005 AMERICAS',           '192.168.15.26', 'USBScale', 'DATALOGIC',     'USBScanner', 'LR2000',     0
) VIRT
GO

-- SequenceType
INSERT INTO [SequenceType]
      SELECT 1, 'Invoice',        'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT 2, 'SalesOrder',     'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT 3, 'RemissionGuide', 'A', 1, 0, NULL, NULL, 'SERVER'
GO

-- SequenceTable (derived from EmissionPoint — one row per EmissionPoint per SequenceType)
INSERT INTO [SequenceTable]
SELECT
    LocationId,
    ROW_NUMBER() OVER (PARTITION BY LocationId ORDER BY SequenceTypeId, EmissionPointId),
    SequenceTypeId,
    EmissionPointId,
    Sequence,
    Name,
    Status,
    1, 0, NULL, NULL, 'SERVER'
FROM (
    SELECT LocationId, 1 SequenceTypeId, EmissionPointId, 1 Sequence, 'SECUENCIA FACTURA '  + Name Name, 'A' Status FROM EmissionPoint
    UNION ALL
    SELECT LocationId, 2 SequenceTypeId, EmissionPointId, 1 Sequence, 'SECUENCIA ORDEN '    + Name Name, 'A' Status FROM EmissionPoint
    UNION ALL
    SELECT LocationId, 3 SequenceTypeId, EmissionPointId, 1 Sequence, 'SECUENCIA GUIA '     + Name Name, 'A' Status FROM EmissionPoint
) VIRT
GO

-- CurrencyType
INSERT INTO [CurrencyType]
SELECT 1, 'DOLAR', 1, 'A', 1, 0, NULL, NULL, 'SERVER'
GO

-- DenominationType
INSERT INTO [DenominationType]
      SELECT 1, 'BILLETE', 'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT 2, 'MONEDA',  'A', 1, 0, NULL, NULL, 'SERVER'
GO

-- CurrencyDenomination
INSERT INTO [CurrencyDenomination]
SELECT *, 'A', 1, 0, NULL, NULL, 'SERVER'
FROM (
	  SELECT  1 [CurrencyDenominationId], 1 [CurrencyTypeId], 1 [DenominationTypeId], 100.00 [Value]
UNION SELECT  2, 1, 1,  50.00
UNION SELECT  3, 1, 1,  20.00
UNION SELECT  4, 1, 1,  10.00
UNION SELECT  5, 1, 1,   5.00
UNION SELECT  6, 1, 1,   2.00
UNION SELECT  7, 1, 1,   1.00
UNION SELECT  8, 1, 2,   1.00
UNION SELECT  9, 1, 2,   0.50
UNION SELECT 10, 1, 2,   0.25
UNION SELECT 11, 1, 2,   0.10
UNION SELECT 12, 1, 2,   0.05
UNION SELECT 13, 1, 2,   0.01) VIRT
GO

-- SalesOrigin
INSERT INTO [SalesOrigin]
SELECT *, 'A', 1, 0, NULL, NULL, 'SERVER'
FROM (
	  SELECT  1 [SalesOriginId], 'SUPERMERCADOS'          [Name], 1 [SalesmanId], 0 [IsECommerce], 0 [AllowCredit]
UNION SELECT  2, 'DOMICILIO',                                     2, 0, 0
UNION SELECT  3, 'EMPLEADOS',                                     3, 0, 0
UNION SELECT  4, 'PEDIDOS YA',                                    4, 0, 1
UNION SELECT  5, 'RAPPI',                                         5, 0, 0
UNION SELECT  6, 'PAGINA WEB',                                    6, 1, 0
UNION SELECT  7, 'APLICACION MOBIL',                              6, 1, 0
UNION SELECT  8, 'WHATSAPP',                                      2, 0, 0
UNION SELECT  9, 'LLAMADA CELULAR',                               2, 0, 0
UNION SELECT 10, 'LLAMADA CONVENCIONAL',                          2, 0, 0) VIRT
GO

-- TransferStatus
INSERT INTO [TransferStatus]
SELECT *, 'A', 1, 0, NULL, NULL, 'SERVER'
FROM (
	  SELECT 1 [TransferStatusId], 'PENDIENTE DE MIGRACION'                   [Name]
UNION SELECT 2, 'MIGRADO A ERP'
UNION SELECT 3, 'PENDIENTE DE ACTUALIZACION'
UNION SELECT 4, 'PENDIENTE DE ACTUALIZACION FORMA DE PAGO'
UNION SELECT 5, 'ACTUALIZADO EN ERP') VIRT
GO

-- SalesOrderStatus
INSERT INTO [SalesOrderStatus]
SELECT *, 'A', 1, 0, NULL, NULL, 'SERVER'
FROM (
	  SELECT 1 [SalesOrderStatusId], 'O' [ShortCode], 'ORDEN ABIERTA'    [Name], 'SAC COGE PEDIDO Y CREA CABECERA'                                                          [Observation], NULL [PreviousStatus]
UNION SELECT 2, 'P', 'ORDEN ECOMMERCE',   'PEDIDO DE LA WEB O APP',                                                                                                                NULL
UNION SELECT 3, 'A', 'ORDEN PICKING',     'PICKING - DESPACHADOR SE ENCUENTRA EN TIENDA REALIZANDO LA TOMA DE PRODUCTOS',                                                          NULL
UNION SELECT 4, 'E', 'ORDEN PACKING',     'PACKING - SELECCION DE PRODUCTOS FINALIZADA Y PASADOS POR CAJA, EN PROCESO DE EMPAQUETADO, LISTO PARA SER INSERTADO EN GUIA',          NULL
UNION SELECT 5, 'S', 'ORDEN SHIPPING',    'PEDIDO COMPLETADO Y LISTO PARA RUTA',                                                                                                   NULL
UNION SELECT 6, 'D', 'ORDEN DELIVERING',  'DELIVERING - PEDIDO SALIO DE TIENDA Y VA EN RUTA',                                                                                      NULL
UNION SELECT 7, 'F', 'ORDEN FACTURADA',   'PEDIDO FUE ENTREGADO AL CLIENTE Y SE FACTURO',                                                                                          NULL
UNION SELECT 8, 'I', 'ORDEN CANCELADA',   'PEDIDO CANCELADO POR CLIENTE',                                                                                                          NULL) VIRT
GO

-- LogType
INSERT INTO [LogType]
      SELECT 1, 'Anular Documento',       'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT 2, 'Anular Cierre Parcial',  'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT 3, 'Eliminar Producto',      'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT 4, 'Anular Pedido',          'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT 5, 'Anular Guia de Remision','A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT 6, 'Anular Cierre de Caja',  'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT 7, 'Anular Nota de Credito', 'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT 8, 'Motivo Nota de Credito', 'A', 1, 0, NULL, NULL, 'SERVER'
GO

-- CancelReason
INSERT INTO [CancelReason]
      SELECT  1, 1, 'Cliente pide cambio de identificacion',    'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT  2, 1, 'Cliente se cancela por falta de dinero',   'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT  3, 1, 'Cliente desiste de la compra',             'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT  4, 2, 'Autorizado por Gerencia',                  'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT  5, 2, 'Retiro por Exceso',                        'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT  6, 2, 'Cierre por Auditoria',                     'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT  7, 4, 'Pedido de prueba',                         'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT  8, 4, 'Pedido duplicado',                         'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT  9, 4, 'Cliente desiste de pedido',                'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT 10, 4, 'Cliente no se encontro en domicilio',      'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT 11, 4, 'Pedido no fue despachado a tiempo',        'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT 12, 4, 'Zona de pedido no aplica a supermercado',  'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT 13, 5, 'Cambio Conductor',                         'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT 14, 3, 'Error de cajero',                          'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT 15, 3, 'Cliente desiste compra',                   'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT 16, 3, 'Cliente desiste producto especifico',      'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT 17, 2, 'Por Reposicion Caja',                      'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT 18, 2, 'Por Faltante en Arqueo',                   'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT 19, 7, 'Datos Incorrectos',                        'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT 20, 8, 'Cliente Desiste',                          'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT 21, 8, 'Producto Inconforme',                      'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT 22, 8, 'Datos Incorrectos',                        'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT 23, 8, 'Factura Duplicada',                        'A', 1, 0, NULL, NULL, 'SERVER'
GO

-- Program
INSERT INTO [Program]
      SELECT  1, 'FrmAdvance',           'Registro de Anticipos',          'A', 1, GETDATE(), NULL, NULL, 'SERVER'
UNION SELECT  2, 'FrmChangePaymMode',    'Cambiar Forma de Pago',          'A', 1, GETDATE(), NULL, NULL, 'SERVER'
UNION SELECT  3, 'FrmClosingCashier',    'Registro de Cierre de Caja',     'A', 1, GETDATE(), NULL, NULL, 'SERVER'
UNION SELECT  4, 'FrmInvoiceCancel',     'Anulacion de Facturas',          'A', 1, GETDATE(), NULL, NULL, 'SERVER'
UNION SELECT  5, 'FrmMain',              'POS',                            'A', 1, GETDATE(), NULL, NULL, 'SERVER'
UNION SELECT  6, 'FrmPartialClosing',    'Registro de Cierre Parcial',     'A', 1, GETDATE(), NULL, NULL, 'SERVER'
UNION SELECT  7, 'FrmPhysicalStockCount','Conteo de Inventario',           'A', 1, GETDATE(), NULL, NULL, 'SERVER'
UNION SELECT  8, 'FrmRedeemGiftCard',    'Canjear Bonos',                  'A', 1, GETDATE(), NULL, NULL, 'SERVER'
UNION SELECT  9, 'FrmReturns',           'Ingresar Devoluciones',          'A', 1, GETDATE(), NULL, NULL, 'SERVER'
UNION SELECT 10, 'FrmSalesOrder',        'Ingresar Ordenes de Pedidos',    'A', 1, GETDATE(), NULL, NULL, 'SERVER'
UNION SELECT 11, 'FrmSalesOrderPicker',  'Consultar Ordenes Pedidos',      'A', 1, GETDATE(), NULL, NULL, 'SERVER'
GO

-- UserProfile
INSERT INTO [UserProfile]
      SELECT 1, 'ADMINISTRADOR SISTEMAS',       'A', 1, GETDATE(), NULL, NULL, 'SERVER'
UNION SELECT 2, 'ADMINISTRADOR SUPERMERCADOS',  'A', 1, GETDATE(), NULL, NULL, 'SERVER'
UNION SELECT 3, 'CAJERO SUPERMERCADOS',         'A', 1, GETDATE(), NULL, NULL, 'SERVER'
UNION SELECT 4, 'MARKETING',                    'A', 1, GETDATE(), NULL, NULL, 'SERVER'
GO
