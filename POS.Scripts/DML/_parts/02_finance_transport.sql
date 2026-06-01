-- ============================================================
-- DML Part 02: Finance & Transport Data
-- Tables: PaymMode, RetentionTable, TaxTable, TransportReason,
--         Company, Location, Salesman, CustomerType, IdentType
-- ============================================================

USE POSDB
GO

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
