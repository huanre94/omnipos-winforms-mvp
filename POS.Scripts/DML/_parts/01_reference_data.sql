-- ============================================================
-- DML Part 01: Reference Data
-- Tables: GlobalParameter, Country, Province, City, Server,
--         Bank, CreditCard, BankCreditCard
-- ============================================================

USE POSDB
GO

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
