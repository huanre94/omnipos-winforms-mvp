-- ============================================================
-- Insert Data Script (Combined DML)
-- POSDB — Full seed data
--
-- Composed from DML/_parts/ in order:
--   01_reference_data.sql      GlobalParameter, Country, Province, City,
--                              Server, Bank, CreditCard, BankCreditCard
--   02_finance_transport.sql   PaymMode, RetentionTable, TaxTable,
--                              TransportReason, Company, Location,
--                              Salesman, CustomerType, IdentType
--   03_inventory_data.sql      Vendor, Brand, InventLocation, InventUnit,
--                              ProductCategory, ProductGroup
--   04_pos_data.sql            PromotionType, PromotionTable, EmissionPoint,
--                              SequenceType, SequenceTable, CurrencyType,
--                              DenominationType, CurrencyDenomination,
--                              SalesOrigin, TransferStatus, SalesOrderStatus,
--                              LogType, CancelReason, Program, UserProfile
--
-- PREREQUISITE: Run DDL/Create Tables Script.sql first
-- ============================================================

USE POSDB
GO

-- ============================================================
-- PART 01: Reference Data
-- ============================================================

-- GlobalParameter
INSERT INTO [GlobalParameter]
SELECT  *, 'A', 1, 0, 1, 0, 'SERVER'
FROM	(SELECT 1 [GlobalParameterId], 'InternalCreditRequestAuth' [Name], '1' [Value], '' [Value2],	'SOLICITAR AUTORIZACION DEL SUPERVISOR POR USO DE TARJETA DE CONSUMO' [Description]
UNION	SELECT 2, 'MaxDecimalNumber',						'4',		'',	'CANTIDAD DE DECIMALES A USAR'
UNION	SELECT 3, 'MaxDaysForNC',							'7',		'',	'MAXIMO DE DIAS PARA APLICAR NOTA DE CREDITO'
UNION	SELECT 4, 'OpeningValueCashier',					'100',		'',	'VALOR DE APERTURA PARA LOS CAJEROS'
UNION	SELECT 5, 'CreditDaysForCustomers',					'15',		'',	'Dias de credito para los clientes'
UNION	SELECT 6, 'LostWeightQty',							'0.02',		'',	'cantidad de peso perdido en Balanzas'
UNION	SELECT 7, 'RequireSupervisorAuthorization',			'1',		'',	'SOLICITAR AUTORIZACION PARA ANULAR PRODUCTOS'
UNION	SELECT 8, 'RequireSupervisorAuthorizationCustomer',	'1',		'', 'SOLICITAR AUTORIZACION PARA CLIENTES CON CREDITO'
UNION	SELECT 9, 'MaxDifferenceClosingCashierValue',		'20.0',		'', 'Diferencia maxima permitida en el cierrre de caja'
UNION	SELECT 10, 'MaxScaleWaitTime',						'3',		'', 'Valor de espera en balanzas Honeywell'
UNION	SELECT 11, 'AllowPhysicalInventory',				'1',		'', 'Validacion para permitir ingresar a la opcion de inventario fisico'
UNION	SELECT 12, 'MODETEST',								'0',		'0', 'VARIABLE PARA INDICAR SI SE ENCUENTRA EN MODO TEST'
UNION	SELECT 14, 'OrderUpdateTimer',						'180000',	'', 'Tiempo de actualizacion pedidos'
UNION	SELECT 15, 'OrderTimerEnabled',						'1',		'', 'Activar timer'
) VIRT
GO

-- Country
INSERT INTO [Country]
SELECT 1, 'ECUADOR', 'EC', 1, 'A', 1, 0, 1, 0, 'SERVER'
GO

-- Province
INSERT INTO [Province]
SELECT 1, '09', 'GUAYAS', '00', 'A', 1, 0, 1, 0, 'SERVER'
GO

-- City
INSERT INTO [City]
SELECT  *, 'A', 1, 0, 1, 0, 'SERVER'
FROM	(SELECT 1 [CityId], '09' [ProvinceId], '01' [CityCode], 'GUAYAQUIL' [Name]
UNION	SELECT 2, '09', '06', 'DAULE'
UNION	SELECT 3, '09', '16', 'SAMBORONDON') VIRT
GO

-- Server
INSERT INTO [Server]
SELECT  *, 'A', 1, 0, 1, 0, 'SERVER'
FROM	(SELECT 1 [ServerId], 'SRVCTR' [Name],  1 [IsCentral], 0 [IsLocal]
UNION	SELECT 2, 'SRVAMR', 0, 0
UNION	SELECT 3, 'SRVALB', 0, 0
UNION	SELECT 4, 'SRVSMB', 0, 0
UNION	SELECT 5, 'SRVJYA', 0, 0
UNION	SELECT 6, 'SRVSLJ', 0, 0) VIRT
GO

-- Bank
INSERT INTO [Bank]
SELECT  *, 1, 0, 1, 0, 'SERVER'
FROM	(SELECT  '01' [BankId], 'BANCO CENTRAL' [Name],         '' [SAPCode],   0 [GaranchekCode], 'A' [Status]
UNION	SELECT  '02', 'FOMENTO',               '',   5, 'I'
UNION	SELECT  '10', 'PICHINCHA',             '',   1, 'A'
UNION	SELECT  '17', 'GUAYAQUIL',             '',   2, 'A'
UNION	SELECT  '24', 'CITIBANK',              '',  20, 'A'
UNION	SELECT  '25', 'MACHALA',               '',   8, 'A'
UNION	SELECT  '29', 'LOJA',                  '',   7, 'A'
UNION	SELECT  '30', 'PACIFICO',              '',  11, 'A'
UNION	SELECT  '32', 'INTERNACIONAL',         '',   3, 'A'
UNION	SELECT  '34', 'AMAZONAS',              '',  18, 'A'
UNION	SELECT  '35', 'AUSTRO',                '',  17, 'A'
UNION	SELECT  '36', 'PRODUBANCO',            '',   4, 'A'
UNION	SELECT  '37', 'BOLIVARIANO',           '',  10, 'A'
UNION	SELECT  '39', 'COMERCIAL DE MANABI',   '',  27, 'A'
UNION	SELECT  '42', 'RUMINAHUI',             '',  15, 'A'
UNION	SELECT  '43', 'DEL LITORAL',           '',  25, 'A'
UNION	SELECT  '59', 'SOLIDARIO',             '',   6, 'A'
UNION	SELECT  '60', 'BANCO PROCREDIT',       '',  16, 'A'
UNION	SELECT  '61', 'BANCO CAPITAL',         '',  22, 'A'
UNION	SELECT  '66', 'BANECUADOR',            '',  29, 'A'
UNION	SELECT  '79', 'COOP POLICIA NACIONAL', '',   0, 'A'
UNION	SELECT '201', 'DELBANK',               '',  21, 'A'
UNION	SELECT '213', 'COOP JEP',              '',   0, 'A'
UNION	SELECT '238', 'MUTUALISTA PICHINCHA',  '',  28, 'A'
UNION	SELECT '349', 'INTERDIN',              '',   0, 'A') VIRT
GO

-- CreditCard
INSERT INTO [CreditCard]
SELECT  *, 1, 0, 1, 0, 'SERVER'
FROM	(SELECT '01' [CreditCardId], 'AMERICAN EXPRESS' [Name],  '' [SAPCode], 1 [IsCredit], 'A' [Status]
UNION	SELECT '02', 'DINERS CLUB',      '', 1, 'A'
UNION	SELECT '03', 'DISCOVER',         '', 1, 'A'
UNION	SELECT '04', 'MASTERCARD',       '', 1, 'A'
UNION	SELECT '05', 'VISA',             '', 1, 'A'
UNION	SELECT '06', 'ALIA',             '', 1, 'A'
UNION	SELECT '07', 'OTRA TARJETA',     '', 1, 'A'
UNION	SELECT '08', 'MASTERCARD DEBIT', '', 0, 'A'
UNION	SELECT '09', 'VISA DEBIT',       '', 0, 'A') VIRT
GO

-- BankCreditCard
INSERT INTO [BankCreditCard]
SELECT cod, nomb, 'A', 1, 0, 1, 0, 'SERVER'
FROM (
	  SELECT '10' cod, '09' nomb
UNION SELECT '10', '04'
UNION SELECT '10', '05'
UNION SELECT '17', '08'
UNION SELECT '17', '01'
UNION SELECT '17', '04'
UNION SELECT '17', '05'
UNION SELECT '25', '09'
UNION SELECT '25', '04'
UNION SELECT '25', '05'
UNION SELECT '29', '09'
UNION SELECT '29', '05'
UNION SELECT '30', '08'
UNION SELECT '30', '04'
UNION SELECT '30', '05'
UNION SELECT '32', '09'
UNION SELECT '32', '04'
UNION SELECT '32', '05'
UNION SELECT '34', '09'
UNION SELECT '34', '05'
UNION SELECT '35', '08'
UNION SELECT '35', '04'
UNION SELECT '35', '05'
UNION SELECT '36', '09'
UNION SELECT '36', '04'
UNION SELECT '36', '05'
UNION SELECT '37', '09'
UNION SELECT '37', '05'
UNION SELECT '39', '09'
UNION SELECT '39', '05'
UNION SELECT '42', '09'
UNION SELECT '42', '05'
UNION SELECT '59', '06'
UNION SELECT '60', '08'
UNION SELECT '79', '08'
UNION SELECT '79', '04'
UNION SELECT '213', '09'
UNION SELECT '213', '04'
UNION SELECT '213', '05'
UNION SELECT '238', '09'
UNION SELECT '238', '05'
UNION SELECT '349', '02'
UNION SELECT '349', '05') VIRT
GO

-- ============================================================
-- PART 02: Finance & Transport Data
-- ============================================================

-- PaymMode
INSERT INTO [PaymMode]
SELECT *, 'A', 1, 0, 1, 0, 'SERVER'
FROM (
	  SELECT  1 [PaymModeId], 'BONO' [Name],               '' [SAPCode], 0 [UseRetention], 0 [UseFinanceSystem]
UNION SELECT  2, 'CHEQUE AL DIA',       '', 0, 1
UNION SELECT  3, 'CHEQUE POST',         '', 0, 1
UNION SELECT  4, 'CREDITO',             '', 0, 0
UNION SELECT  5, 'DEBITO BANCARIO',     '', 0, 1
UNION SELECT  6, 'DEPOSITO BANCARIO',   '', 0, 1
UNION SELECT  7, 'DINERO ELECTRONICO',  '', 0, 1
UNION SELECT  8, 'EFECTIVO',            '', 0, 0
UNION SELECT  9, 'NOTA CREDITO',        '', 0, 0
UNION SELECT 10, 'ANTICIPOS',           '', 0, 0
UNION SELECT 11, 'PAGOS WEB',           '', 0, 0
UNION SELECT 12, 'RETENCION',           '', 1, 0
UNION SELECT 13, 'TARJETA CREDITO',     '', 0, 1
UNION SELECT 14, 'TARJETA CONSUMO',     '', 0, 0) VIRT
GO

-- RetentionTable
INSERT INTO [RetentionTable]
      SELECT 1, 'RET IVA 1.75 % CLIENTES GENERAL CON RUC',           '',   1.75, '1', 'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT 2, 'RET IVA 10 % CLIENTES SI LA CIA SI ES CONTR ESP.',  '',  10.00, '2', 'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT 3, 'RET IVA 30 % CLIENTES SI LA CIA NO ES CONTR ESP.',  '',  30.00, '2', 'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT 4, 'RET IVA 40 % CLIENTES SI LA CIA NO ES CONTR ESP.',  '', 100.00, '2', 'A', 1, 0, NULL, NULL, 'SERVER'
GO

-- TaxTable
INSERT INTO [TaxTable]
      SELECT '0', 'Impuesto  0%',  0.00, 'I', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT '2', 'Impuesto 12%', 12.00, 'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT '3', 'Impuesto 14%', 14.00, 'I', 1, 0, NULL, NULL, 'SERVER'
GO

-- TransportReason
INSERT INTO [TransportReason]
SELECT *, 'A', 1, 0, 1, 0, 'SERVER'
FROM (
	  SELECT 1 [TransportReasonId], 'VENTA' [Name],                            '' [SAPCode]
UNION SELECT 2, 'COMPRA',                                                      ''
UNION SELECT 3, 'CONSIGNACION',                                                ''
UNION SELECT 4, 'DEVOLUCION',                                                  ''
UNION SELECT 5, 'TRASLADO ENTRE ESTABLECIMIENTOS',                             ''
UNION SELECT 6, 'EXHIBICION',                                                  '') VIRT
GO

-- Company
INSERT INTO [Company]
      SELECT  1, 'DISCAREM S.A.',    '0992715553001', '042283497', 3, 'GUAYAS / GUAYAQUIL / TARQUI / COSME RENELLA 216 Y AV. DE LAS AMERICAS',                0, 0, 0, 'A', 1, 0, 1, 0, 'SERVER'
UNION SELECT  2, 'ECUARIDER S.A.',   '0992156287001', '042283497', 1, 'GUAYAS / GUAYAQUIL / TARQUI / AV. ISIDRO AYORA SOLAR 1 Y BENJAMIN CARRION',            0, 0, 0, 'A', 1, 0, 1, 0, 'SERVER'
UNION SELECT  3, 'EQUACORPSA S.A.',  '0992375280001', '042283497', 1, 'GUAYAS / GUAYAQUIL / TARQUI / COSME RENELLA 216 Y AV. DE LAS AMERICAS',                0, 0, 0, 'I', 1, 0, 1, 0, 'SERVER'
UNION SELECT  4, 'SALJUPER S.A.',    '0992104821001', '043910900', 1, 'GUAYAS / GUAYAQUIL / TARQUI / COSME RENELLA 216 Y AV. DE LAS AMERICAS',                0, 0, 0, 'A', 1, 0, 1, 0, 'SERVER'
GO

-- Location
INSERT INTO [Location]
      SELECT  1, 1, 'SAMBORONDON', '002', '043710150', 3, 'GUAYAS / SAMBORONDON / SAMBORONDON / MANGLERO SOLAR 84B',               1, 4, 'A', 1, 0, 1, 0, 'SERVER'
UNION SELECT  2, 1, 'LA JOYA',    '003', '000000000', 2, 'GUAYAS / DAULE / LA AURORA (SATELITE) / SOLAR D5',                      0, 5, 'A', 1, 0, 1, 0, 'SERVER'
UNION SELECT  3, 2, 'ALBORADA',   '001', '042283497', 1, 'GUAYAS / GUAYAQUIL / TARQUI / AV. ISIDRO AYORA 1 Y BENJAMIN CARRION',   1, 3, 'A', 1, 0, 1, 0, 'SERVER'
UNION SELECT  4, 2, 'AMERICAS',   '002', '042283497', 1, 'GUAYAS / GUAYAQUIL / TARQUI / COSME RENELLA 216 Y AV. DE LAS AMERICAS', 0, 2, 'A', 1, 0, 1, 0, 'SERVER'
UNION SELECT  5, 4, 'DARK STORE', '013', '043910900', 1, 'GUAYAS / GUAYAQUIL / VIA A LA COSTA',                                   0, 6, 'A', 1, 0, 1, 0, 'SERVER'
GO

-- Salesman
INSERT INTO [Salesman]
SELECT *, 0, '', 0, 0, 'A', 1, 0, NULL, NULL, 'SERVER'
FROM (
	  SELECT 0 [SalesmanId], 'NINGUNO'      [Name], 0 [SAPCode], 0 [IsExternal]
UNION SELECT 1, 'SUPERMERCADOS',                    0, 0
UNION SELECT 2, 'DOMICILIO',                        0, 0
UNION SELECT 3, 'EMPLEADOS',                        0, 0
UNION SELECT 4, 'GLOVO',                            0, 1
UNION SELECT 5, 'RAPPI',                            0, 1
UNION SELECT 6, 'PEDIDOS WEB',                      0, 1) VIRT
GO

-- CustomerType
INSERT INTO [CustomerType]
SELECT 0, 'NINGUNO', 0, 0, 'A', 1, 0, NULL, NULL, 'SERVER'
GO

-- IdentType
INSERT INTO [IdentType]
SELECT *, 'A', 1, 0, NULL, NULL, 'SERVER'
FROM (
	  SELECT 1 [IdentTypeId], 'RUC'              [Name], 'R' [Prefix]
UNION SELECT 2, 'CEDULA',                               'C'
UNION SELECT 3, 'PASAPORTE',                            'P'
UNION SELECT 4, 'RUC EXTARNJERO',                       'E'
UNION SELECT 5, 'CONSUMIDOR FINAL',                     'C') VIRT
GO

-- ============================================================
-- PART 03: Inventory Data
-- ============================================================

-- Vendor
INSERT INTO [Vendor]
SELECT 0, 'NINGUNO', '', 5, '', '', 0, '', '', 1, '', 'A', 1, 0, NULL, NULL, 'SERVER'
GO

-- Brand
INSERT INTO [Brand]
SELECT 0, 'NINGUNO', '', 'A', 1, 0, NULL, NULL, 'SERVER'
GO

-- InventLocation
INSERT INTO [InventLocation]
SELECT *, 'A', 1, 0, NULL, NULL, 'SERVER'
FROM (
	  SELECT  1 [InventLocationId], 'SUPERMERCADOS SAMBORONDON'          [Name], '' [SAPCode], 1 [LocationId], '' [Type], 1 [IsMain]
UNION SELECT  2, 'SECOS SAMBORONDON',                                            '', 1, '', 0
UNION SELECT  3, 'CARNICOS SAMBORONDON',                                         '', 1, '', 0
UNION SELECT  4, 'LEGUMBRES SAMBORONDON',                                        '', 1, '', 0
UNION SELECT  5, 'MATERIALES Y SUMINISTROS SAMBORONDON',                         '', 1, '', 0
UNION SELECT  6, 'DEVOLUCIONES SAMBORONDON',                                     '', 1, '', 0
UNION SELECT  7, 'COCINA SAMBORONDON',                                           '', 1, '', 0
UNION SELECT  8, 'TRANSITO SAMBORONDON',                                         '', 1, '', 0
UNION SELECT  9, 'TEMPORADA SAMBORONDON',                                        '', 1, '', 0
UNION SELECT 10, 'COMPRAS SAMBORONDON',                                          '', 1, '', 0
-- LA JOYA
UNION SELECT 11, 'SUPERMERCADOS LA JOYA',                                        '', 2, '', 1
UNION SELECT 12, 'SECOS LA JOYA',                                                '', 2, '', 0
UNION SELECT 13, 'CARNICOS LA JOYA',                                             '', 2, '', 0
UNION SELECT 14, 'LEGUMBRES LA JOYA',                                            '', 2, '', 0
UNION SELECT 15, 'MATERIALES Y SUMINISTROS LA JOYA',                             '', 2, '', 0
UNION SELECT 16, 'DEVOLUCIONES LA JOYA',                                         '', 2, '', 0
UNION SELECT 17, 'COCINA LA JOYA',                                               '', 2, '', 0
UNION SELECT 18, 'TRANSITO LA JOYA',                                             '', 2, '', 0
UNION SELECT 19, 'TEMPORADA LA JOYA',                                            '', 2, '', 0
UNION SELECT 20, 'COMPRAS LA JOYA',                                              '', 2, '', 0
-- ALBORADA
UNION SELECT 21, 'SUPERMERCADOS ALBORADA',                                       '', 3, '', 1
UNION SELECT 22, 'SECOS ALBORADA',                                               '', 3, '', 0
UNION SELECT 23, 'CARNICOS ALBORADA',                                            '', 3, '', 0
UNION SELECT 24, 'LEGUMBRES ALBORADA',                                           '', 3, '', 0
UNION SELECT 25, 'MATERIALES Y SUMINISTROS ALBORADA',                            '', 3, '', 0
UNION SELECT 26, 'DEVOLUCIONES ALBORADA',                                        '', 3, '', 0
UNION SELECT 27, 'COCINA ALBORADA',                                              '', 3, '', 0
UNION SELECT 28, 'TRANSITO ALBORADA',                                            '', 3, '', 0
UNION SELECT 29, 'TEMPORADA ALBORADA',                                           '', 3, '', 0
UNION SELECT 30, 'COMPRAS ALBORADA',                                             '', 3, '', 0
-- AMERICAS
UNION SELECT 31, 'SUPERMERCADOS AMERICAS',                                       '', 4, '', 1
UNION SELECT 32, 'SECOS AMERICAS',                                               '', 4, '', 0
UNION SELECT 33, 'CARNICOS AMERICAS',                                            '', 4, '', 0
UNION SELECT 34, 'LEGUMBRES AMERICAS',                                           '', 4, '', 0
UNION SELECT 35, 'MATERIALES Y SUMINISTROS AMERICAS',                            '', 4, '', 0
UNION SELECT 36, 'DEVOLUCIONES AMERICAS',                                        '', 4, '', 0
UNION SELECT 37, 'COCINA AMERICAS',                                              '', 4, '', 0
UNION SELECT 38, 'TRANSITO AMERICAS',                                            '', 4, '', 0
UNION SELECT 39, 'TEMPORADA AMERICAS',                                           '', 4, '', 0
UNION SELECT 40, 'COMPRAS AMERICAS',                                             '', 4, '', 0
) VIRT
GO

-- InventUnit
INSERT INTO [InventUnit]
      SELECT '01', 'UNIDAD',    '', 0, 'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT '02', 'KILOGRAMO', '', 1, 'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT '03', 'LIBRA',     '', 1, 'I', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT '04', 'LITRO',     '', 0, 'I', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT '05', 'METRO',     '', 0, 'I', 1, 0, NULL, NULL, 'SERVER'
GO

-- ProductCategory
INSERT INTO [ProductCategory]
SELECT 0, 0, 'NINGUNO', '', 0, 'A', 1, 0, NULL, NULL, 'SERVER'
GO

-- ProductGroup
INSERT INTO [ProductGroup]
SELECT 0, 'NINGUNO', 'A', 1, 0, NULL, NULL, 'SERVER'
GO

-- ============================================================
-- PART 04: POS & Miscellaneous Data
-- ============================================================

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
