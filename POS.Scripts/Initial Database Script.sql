/*
   -- Primero desabilitar la integridad referencial
   EXEC sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'
   GO

   EXEC sp_MSforeachtable @command1 = "DROP TABLE ?"
   GO
   
   -- Ahora volver a habilitar la integridad referencial
   EXEC sp_MSForEachTable 'ALTER TABLE ? CHECK CONSTRAINT ALL'
   GO

   sp_who2 
   kill 65
*/


USE MASTER 
GO
DROP Database POSDB
GO
Create  Database POSDB
    On ( Name = POSDB_Data, Filename = '/var/opt/mssql/data/POSDB.mdf' )
Log On ( Name = POSDB_Log, Filename = '/var/opt/mssql/data/POSDB_log.ldf' )
Collate SQL_Latin1_General_CP1_CI_AS
GO

USE POSDB
GO
--ALTER DATABASE POSDB SET COMPATIBILITY_LEVEL = 110
--GO

ALTER DATABASE POSDB SET RECOVERY SIMPLE
GO

CREATE TABLE [dbo].[GlobalParameter]
([GlobalParameterId]	INT				NOT NULL,
 [Name]					[varchar](50)	Collate Database_Default NOT NULL,  /*Nombre Contacto*/
 [Value]				[varchar](50)	Collate Database_Default NOT NULL,  /*Nombre Contacto*/
 [Value2]				[varchar](50)	Collate Database_Default NOT NULL,  /*Nombre Contacto*/
 [Description]			[varchar](500)	Collate Database_Default NOT NULL,  /*Nombre Contacto*/
 [Status]				[Char](1)		Collate Database_Default NULL,
 [CreatedBy]			INT            NOT NULL,
 [CreatedDatetime]		DATETIME       NOT NULL, 
 [ModifiedBy]			INT            NULL,
 [ModifiedDatetime]		DATETIME       NULL, 
 [Workstation]			VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__GlobalParameter] PRIMARY KEY CLUSTERED ([GlobalParameterId])) ON [PRIMARY]
Go
Create Unique Index Ind_GlobalParameter on [GlobalParameter] ([Name])
Go

INSERT INTO [GlobalParameter]
SELECT  *, 'A', 1, 0, 1, 0, 'SERVER'
FROM	(SELECT 1 [GlobalParameterId], 'InternalCreditRequestAuth' [Name], '1' [Value], '' [Value2],	'SOLICITAR AUTORIZACI N DEL SUPERVISOR POR USO DE TARJETA DE CONSUMO' [Description]
UNION	SELECT 2, 'MaxDecimalNumber',						'4',		'',	'CANTIDAD DE DECIMALES A USAR'
UNION	SELECT 3, 'MaxDaysForNC',							'7',		'',	'M XIMO DE D AS PARA APLICAR NOTA DE CR DITO'
UNION	SELECT 4, 'OpeningValueCashier',					'100',		'',	'VALOR DE APERTURA PARA LOS CAJEROS'
UNION	SELECT 5, 'CreditDaysForCustomers',					'15',		'',	'D as de cr dito para los clientes'
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
SELECT * FROM [GlobalParameter]

/*Tabla Pais */
CREATE TABLE [dbo].[Country]
([CountryId]         INT            NOT NULL,
 [Name]              [varchar](50)  Collate Database_Default NULL,
 [Prefix]            [varchar](4)   Collate Database_Default NULL,
 [IsLocal]           [Bit]          NULL,  
 [Status]            [Char](1)      Collate Database_Default NULL,
 [CreatedBy]         INT            NOT NULL,
 [CreatedDatetime]   DATETIME       NOT NULL, 
 [ModifiedBy]        INT            NULL,
 [ModifiedDatetime]  DATETIME       NULL, 
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__Country] PRIMARY KEY CLUSTERED ([CountryId] )) ON [PRIMARY]
Go

Insert into [Country]
Select 1, 'ECUADOR', 'EC', 1, 'A', 1, 0, 1, 0, 'SERVER'

SELECT * FROM [Country]

/*Tabla Provincias */
CREATE TABLE [dbo].[Province]
([CountryId]		INT            NOT NULL,
 [ProvinceId]		INT            NOT NULL,
 [Name]				[varchar](50)  Collate Database_Default NULL, /*Nombre Provincia*/
 [Region]			[varchar](3)   Collate Database_Default NOT NULL, 
 [Status]			[Char](1)      Collate Database_Default NULL,
 [CreatedBy]        INT            NOT NULL,
 [CreatedDatetime]  DATETIME       NOT NULL, 
 [ModifiedBy]       INT            NULL,
 [ModifiedDatetime] DATETIME       NULL, 
 [Workstation]      VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__Province] PRIMARY KEY CLUSTERED ([ProvinceId] ),
 CONSTRAINT [FK__Province_Country] FOREIGN KEY  ([CountryId]) REFERENCES [Country] ([CountryId])) ON [PRIMARY]
Go

Insert into [Province]
Select 1, '09', 'GUAYAS', '00', 'A', 1, 0, 1, 0, 'SERVER'

SELECT * FROM [Province]

/*Tabla Cantones */
CREATE TABLE [dbo].[City]
([CityId]           INT            NOT NULL,
 [ProvinceId]       INT            NOT NULL,
 [CityCode]         INT            NOT NULL,
 [Name]             [varchar](50)  Collate Database_Default NULL, /*Nombre Provincia*/
 [Status]           [Char](1)      Collate Database_Default NULL,
 [CreatedBy]		INT            NOT NULL,
 [CreatedDatetime]	DATETIME       NOT NULL, 
 [ModifiedBy]       INT            NULL,
 [ModifiedDatetime] DATETIME       NULL, 
 [Workstation]      VARCHAR(20)    Collate Database_Default NOT NULL,
CONSTRAINT [PK__City] PRIMARY KEY CLUSTERED ([CityId]),
CONSTRAINT [FK__City_Province] FOREIGN KEY ([ProvinceId]) REFERENCES [Province] ([ProvinceId])) ON [PRIMARY]
Go

Create Unique Index Ind_City on [City] ([ProvinceId], [CityCode])
Go

Insert into [City]
SELECT  *, 'A', 1, 0, 1, 0, 'SERVER'
FROM	(Select 1 [CityId], '09' [ProvinceId], '01' [CityCode], 'GUAYAQUIL' [Name]
UNION	Select 2, '09', '06', 'DAULE'
UNION	Select 3, '09', '16', 'SAMBORONDON') VIRT
go

SELECT * FROM [City]

CREATE TABLE [dbo].[Server]
([ServerId]			[Int]         NOT NULL,
 [Name]				[varchar](50) NOT NULL,
 [IsCentral]		BIT           NOT NULL,
 [IsLocal]			BIT           NOT NULL,
 [Status]			[Char](1)      Collate Database_Default NULL,
 [CreatedBy]		INT            NOT NULL,
 [CreatedDatetime]	DATETIME       NOT NULL, 
 [ModifiedBy]       INT            NULL,
 [ModifiedDatetime] DATETIME       NULL, 
 [Workstation]      VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__Server] PRIMARY KEY CLUSTERED ([ServerId])
) ON [PRIMARY]
go
Create Unique Index Ind_Server on [Server]([Name])
Go

INSERT INTO [Server]
SELECT  *, 'A', 1, 0, 1, 0, 'SERVER'
FROM	(SELECT 1 [ServerId], 'SRVCTR' [Name],      1 [IsCentral], 0 [IsLocal]
UNION	SELECT 2, 'SRVAMR',     0, 0
UNION	SELECT 3, 'SRVALB',     0, 0
UNION	SELECT 4, 'SRVSMB',		0, 0
UNION	SELECT 5, 'SRVJYA',     0, 0
UNION	SELECT 6, 'SRVSLJ',     0, 0) VIRT

SELECT * FROM [Server]

/****** Objeto:  Table [dbo].[UserLogin]     ******/
/****** Objetivo: Para los Usuarios que contendr  el Sistema ******/
CREATE TABLE [dbo].[UserLogin]
([UserId]            [Int]          NOT NULL,
 [UserName]          [varchar](20)  NOT NULL,
 [Lastname]          [varchar](150) Collate Database_Default NOT NULL,  /*Nombre Contacto*/
 [Firtsname]         [varchar](150) Collate Database_Default NOT NULL,  /*Nombre Contacto*/
 [IsProfile]         [Bit]          NOT NULL,
 [IsAdministrator]   [Bit]          NOT NULL,
 [Type]              [char](1)      NOT NULL,
 [Password]          varbinary(150)	NOT NULL,
 [Email]             [varchar](60)  Collate Database_Default NOT NULL,  /*Email*/
 [Status]            [Char](1)      Collate Database_Default NULL,
 [CreatedBy]         INT            NOT NULL,
 [CreatedDatetime]   DATETIME       NOT NULL, 
 [ModifiedBy]        INT            NULL,
 [ModifiedDatetime]  DATETIME       NULL, 
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__UserLogin] PRIMARY KEY CLUSTERED ([UserId])) ON [PRIMARY]
Go
Create Unique Index Ind_User on [UserLogin] ([UserName])
Go

CREATE TABLE [dbo].[Supervisor]
([UserId]            [Int]          NOT NULL,
 [PasswordId]        [Int]          NOT NULL,
 [barcode]           [varchar](20)	Collate Database_Default NOT NULL,  /*Nombre Contacto*/
 [Status]            [Char](1)      Collate Database_Default NULL,
 [AllowEmployeeCredit] BIT			NOT NULL
 [CreatedBy]         INT            NOT NULL,
 [CreatedDatetime]   DATETIME       NOT NULL, 
 [ModifiedBy]        INT            NULL,
 [ModifiedDatetime]  DATETIME       NULL, 
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__Supervisor] PRIMARY KEY CLUSTERED ([UserId], [PasswordId]),
 CONSTRAINT [FK__Supervisor_UserLogin] FOREIGN KEY  ([UserId]) REFERENCES [UserLogin] ([UserId])
) ON [PRIMARY]
Go
Create Unique Index Ind_Supervisor on [Supervisor] ([barcode])
Go


CREATE TABLE [dbo].[Bank]
([BankId]			[INT] NOT NULL,
 [Name]				[varchar](150) Collate Database_Default NOT NULL,
 [SAPCode]			[varchar](20)  Collate Database_Default NOT NULL,
 [GaranchekCode]	[INT]          NOT NULL,
 [Status]			[Char](1)      Collate Database_Default NULL,
 [CreatedBy]        INT            NOT NULL,
 [CreatedDatetime]  DATETIME       NOT NULL, 
 [ModifiedBy]       INT            NULL,
 [ModifiedDatetime] DATETIME       NULL, 
 [Workstation]      VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__Bank] PRIMARY KEY CLUSTERED ([BankId])) ON [PRIMARY]
Go

Insert Into [Bank]
SELECT  *, 1, 0, 1, 0, 'SERVER'
FROM	(select  '01' [BankId],'BANCO CENTRAL' [Name],          '' [SAPCode],   0 [GaranchekCode], 'A' [Status]
UNION	select  '02','FOMENTO',                '',   5, 'I'
UNION	select  '10','PICHINCHA',              '',   1, 'A'
UNION	select  '17','GUAYAQUIL',              '',   2, 'A'
UNION	select  '24','CITIBANK',               '',  20, 'A'
UNION	select  '25','MACHALA',                '',   8, 'A'
UNION	select  '29','LOJA',                   '',   7, 'A'
UNION	select  '30','PACIFICO',               '',  11, 'A'
UNION	select  '32','INTERNACIONAL',          '',   3, 'A'
UNION	select  '34','AMAZONAS',               '',  18, 'A'
UNION	select  '35','AUSTRO',                 '',  17, 'A'
UNION	select  '36','PRODUBANCO',             '',   4, 'A'
UNION	select  '37','BOLIVARIANO',            '',  10, 'A'
UNION	select  '39','COMERCIAL DE MANABI',    '',  27, 'A'
UNION	select  '42','RUMINAHUI',              '',  15, 'A'
UNION	select  '43','DEL LITORAL',            '',  25, 'A'
UNION	select  '59','SOLIDARIO',              '',   6, 'A'
UNION	select  '60','BANCO PROCREDIT',        '',  16, 'A'
UNION	select  '61','BANCO CAPITAL',          '',  22, 'A'
UNION	select  '66','BANECUADOR',             '',  29, 'A'
UNION	select  '79','COOP POLICIA NACIONAL',  '',   0, 'A'
UNION	select '201','DELBANK',                '',  21, 'A'
UNION	select '213','COOP JEP',               '',   0, 'A'
UNION	select '238','MUTUALISTA PICHINCHA',   '',  28, 'A'
UNION	select '349','INTERDIN',                '',  0, 'A') VIRT

SELECT * FROM [Bank]

CREATE TABLE [dbo].[CreditCard]
([CreditCardId]		[INT] NOT NULL,
 [Name]				[varchar](150) Collate Database_Default NOT NULL,
 [SAPCode]			[varchar](20)  Collate Database_Default NOT NULL,
 [IsCredit]			[Bit]          NULL, 
 [Status]			[Char](1)      Collate Database_Default NULL,  /*Estado*/
 [CreatedBy]        INT            NOT NULL,
 [CreatedDatetime]  DATETIME       NOT NULL, 
 [ModifiedBy]       INT            NULL,
 [ModifiedDatetime] DATETIME       NULL, 
 [Workstation]      VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__CreditCard] PRIMARY KEY CLUSTERED ([CreditCardId]) ) ON [PRIMARY]
Go

insert into [CreditCard]
SELECT  *, 1, 0, 1, 0, 'SERVER'
FROM	(Select '01' [CreditCardId] ,'AMERICAN EXPRESS' [Name],  '' [SAPCode], 1 [IsCredit], 'A' [Status]
UNION	select '02','DINERS CLUB',       '', 1, 'A'
UNION	select '03','DISCOVER',          '', 1, 'A'
UNION	select '04','MASTERCARD',        '', 1, 'A'
UNION	select '05','VISA',              '', 1, 'A'
UNION	select '06','ALIA',              '', 1, 'A'
UNION	select '07','OTRA TARJETA',      '', 1, 'A'
UNION	select '08','MASTERCARD DEBIT',  '', 0, 'A'
UNION	select '09','VISA DEBIT',        '', 0, 'A') VIRT

SELECT * FROM [CreditCard]

CREATE TABLE [dbo].[BankCreditCard]
([BankId]			[INT] NOT NULL,
 [CreditCardId]		[INT] NOT NULL,
 [Status]			[Char](1)      Collate Database_Default NULL,  /*Estado*/
 [CreatedBy]        INT            NOT NULL,
 [CreatedDatetime]  DATETIME       NOT NULL, 
 [ModifiedBy]       INT            NULL,
 [ModifiedDatetime] DATETIME       NULL, 
 [Workstation]      VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__BankCreditCard] PRIMARY KEY CLUSTERED ([BankId], [CreditCardId]),
 CONSTRAINT [FK__BankCreditCard_Bank] FOREIGN KEY ([BankId]) REFERENCES [Bank] ([BankId]), 
 CONSTRAINT [FK__BankCreditCard_CreditCard] FOREIGN KEY ([CreditCardId]) REFERENCES [CreditCard] ([CreditCardId]) ) ON [PRIMARY]
Go

insert into   [BankCreditCard]
select cod, nomb, 'A', 1, 0, 1, 0, 'SERVER'
 from (
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
UNION SELECT '349', '05') virt

SELECT * FROM [BankCreditCard]

CREATE TABLE [dbo].[PaymMode]
([PaymModeId]		[Int]          NOT NULL,  /**/
 [Name]				[varchar](150) Collate Database_Default NOT NULL,  /**/
 [SAPCode]			[varchar](20)  Collate Database_Default NOT NULL,
 [UseRetention]		[Bit]          NULL, /*Retencion*/
 [UseFinanceSystem]	[Bit]          NULL, /*Sistema Financiero*/
 [Status]			[Char](1)      Collate Database_Default NULL,  /**/
 [CreatedBy]        INT            NOT NULL,
 [CreatedDatetime]  DATETIME       NOT NULL, 
 [ModifiedBy]       INT            NULL,
 [ModifiedDatetime] DATETIME       NULL, 
 [Workstation]      VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__PaymMode] PRIMARY KEY CLUSTERED ([PaymModeId])) ON [PRIMARY]
Go

INSERT INTO [PaymMode]
SELECT * , 'A', 1, 0, 1, 0, 'SERVER'
 FROM (SELECT 1 [PaymModeId], 'BONO' [Name], '' [SAPCode], 0 [UseRetention], 0 [UseFinanceSystem]
UNION SELECT  2, 'CHEQUE AL DIA',  '', 0, 1
UNION SELECT  3, 'CHEQUE POST',  '', 0, 1
UNION SELECT  4, 'CREDITO', '', 0, 0
UNION SELECT  5, 'DEBITO BANCARIO',  '', 0, 1
UNION SELECT  6, 'DEPOSITO BANCARIO', '', 0, 1
UNION SELECT  7, 'DINERO ELECTRONICO', '', 0, 1
UNION SELECT  8, 'EFECTIVO', '', 0, 0
UNION SELECT  9, 'NOTA CREDITO',  '', 0, 0
UNION SELECT 10, 'ANTICIPOS', '', 0, 0
UNION SELECT 11, 'PAGOS WEB', '', 0, 0
UNION SELECT 12, 'RETENCION', '', 1, 0
UNION SELECT 13, 'TARJETA CREDITO',  '', 0, 1
UNION SELECT 14, 'TARJETA CONSUMO', '', 0, 0) VIRT

SELECT * FROM [PaymMode]

CREATE TABLE [dbo].[RetentionTable]
([RetentionCode]	INT            NOT NULL,
 [Name]				[varchar](150) Collate Database_Default NOT NULL,
 [SAPCode]			[varchar](20)  Collate Database_Default NOT NULL,
 [Percent]			[NUMERIC](18,2)NOT NULL,
 [Type]				[VARCHAR](5)	Collate Database_Default NULL,
 [Status]			[Char](1)      Collate Database_Default NULL,
 [CreatedBy]        INT            NOT NULL,
 [CreatedDatetime]  DATETIME       NOT NULL, 
 [ModifiedBy]       INT            NULL,
 [ModifiedDatetime] DATETIME       NULL, 
 [Workstation]      VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__RetentionTable] PRIMARY KEY CLUSTERED ([RetentionCode])) ON [PRIMARY]
Go

INSERT INTO [RetentionTable]
      select 1,	'RET IVA 1.75 % CLIENTES GENERAL CON RUC',			'',   1.75, '1', 'A', 1, 0, NULL, NULL, 'SERVER'
UNION select 2,	'RET IVA 10 % CLIENTES SI LA CIA SI ES CONTR ESP.',	'',  10.00, '2', 'A', 1, 0, NULL, NULL, 'SERVER'
UNION select 3,	'RET IVA 30 % CLIENTES SI LA CIA NO ES CONTR ESP.',	'',  30.00, '2', 'A', 1, 0, NULL, NULL, 'SERVER'
UNION select 4,	'RET IVA 40 % CLIENTES SI LA CIA NO ES CONTR ESP.',	'', 100.00, '2', 'A', 1, 0, NULL, NULL, 'SERVER'
Go

SELECT * FROM [RetentionTable]

CREATE TABLE [dbo].[TaxTable]
([TaxId]             [Int]          NOT NULL,
 [Name]              [varchar](150) Collate Database_Default NOT NULL,
 [TaxValue]          [NUMERIC](18,2)NOT NULL,
 [Status]            [Char](1)      Collate Database_Default NULL,
 [CreatedBy]         INT            NOT NULL,
 [CreatedDatetime]   DATETIME       NOT NULL, 
 [ModifiedBy]        INT            NULL,
 [ModifiedDatetime]  DATETIME       NULL, 
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__TaxTable] PRIMARY KEY CLUSTERED ([TaxId])) ON [PRIMARY]
Go

INSERT INTO [TaxTable]
      select '0', 'Impuesto  0%', 00.00, 'I', 1, 0, NULL, NULL, 'SERVER'
UNION select '2', 'Impuesto 12%', 12.00, 'A', 1, 0, NULL, NULL, 'SERVER'
UNION select '3', 'Impuesto 14%', 14.00, 'I', 1, 0, NULL, NULL, 'SERVER'
Go

SELECT * FROM [TaxTable]

CREATE TABLE [dbo].[Transport]
([TransportId]			[Int]			NOT NULL,
 [LicencePlate]			VARCHAR(10)		Collate Database_Default NOT NULL,
 [Description]			[varchar](100)	NOT NULL,
 [Status]				[Char](1)		Collate Database_Default NULL,
 [CreatedBy]			INT				NOT NULL,
 [CreatedDatetime]		DATETIME		NOT NULL, 
 [ModifiedBy]			INT				NULL,
 [ModifiedDatetime]		DATETIME		NULL, 
 [Workstation]			VARCHAR(20)		Collate Database_Default NOT NULL,
 CONSTRAINT [PK__Transport] PRIMARY KEY CLUSTERED ([TransportId])) ON [PRIMARY]
Go
Create Unique Index Ind_Transport on [Transport] ([LicencePlate])
Go

CREATE TABLE [dbo].[TransportDriver]
([TransportDriverId]	[Int]          NOT NULL,
 [Identification]		[varchar](20)  NOT NULL,
 [Lastname]				[varchar](150) Collate Database_Default NOT NULL,  /*Nombre Contacto*/
 [Firtsname]			[varchar](150) Collate Database_Default NOT NULL,  /*Nombre Contacto*/
 [Status]				[Char](1)      Collate Database_Default NULL,
 [CreatedBy]			INT            NOT NULL,
 [CreatedDatetime]		DATETIME       NOT NULL, 
 [ModifiedBy]			INT            NULL,
 [ModifiedDatetime]		DATETIME       NULL, 
 [Workstation]			VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__TransportDriver] PRIMARY KEY CLUSTERED ([TransportDriverId])) ON [PRIMARY]
Go
Create Unique Index Ind_TransportDriver on [TransportDriver] ([Identification])
Go

/*Tipo de transaccion de Inventario*/
CREATE TABLE [dbo].[TransportReason]
([TransportReasonId]	Int NOT NULL,
 [Name]					[varchar](150)	Collate Database_Default NULL,
 [SAPCode]				[varchar](20)	Collate Database_Default NOT NULL,
 [Status]				[Char](1)		Collate Database_Default NULL,
 [CreatedBy]			INT				NOT NULL,
 [CreatedDatetime]		DATETIME		NOT NULL, 
 [ModifiedBy]			INT				NULL,
 [ModifiedDatetime]		DATETIME		NULL, 
 [Workstation]			VARCHAR(20)		Collate Database_Default NOT NULL,
 CONSTRAINT [PK__TransportReason] PRIMARY KEY CLUSTERED ([TransportReasonId])) ON [PRIMARY]
Go

INSERT INTO [TransportReason]
SELECT	* , 'A', 1, 0, 1, 0, 'SERVER'
FROM	(SELECT 1 [TransportReasonId], 'VENTA' [Name], '' [SAPCode]
UNION	SELECT 2, 'COMPRA', ''
UNION	SELECT 3, 'CONSIGNACI N', ''
UNION	SELECT 4, 'DEVOLUCI N', ''
UNION	SELECT 5, 'TRASLADO ENTRE ESTABLECIMIENTOS', ''
UNION	SELECT 6, 'EXHIBICI N', '') VIRT
 

/*Tabla Compa ias */
CREATE TABLE [dbo].[Company]
([CompanyId]			[Smallint]     NOT NULL,
 [Name]					[varchar](250) Collate Database_Default NULL, /*Nombre Cia*/
 [Identification]		[varchar](13)  Collate Database_Default NULL,  /*RUC Cia*/ 
 [Phone]				[varchar](10)  Collate Database_Default NULL,  /*Tel fono Cia*/
 [CityId]				INT            NOT NULL,
 [Address]				[varchar](150) Collate Database_Default NULL, /*Direccion Cia*/ 
 [IsTaxpayerSpecial]	[Bit]          NOT NULL,  /*si es contribuyente especial*/
 [HasRISE]				[Bit]          NOT NULL,  /*si es RISE*/
 [HasTaxback]			[Bit]          NOT NULL,  /*si recibe la devolucion del iva*/
 [Status]				[Char](1)      Collate Database_Default NULL,  /**/
 [CreatedBy]			INT				NOT NULL,
 [CreatedDatetime]		DATETIME		NOT NULL, 
 [ModifiedBy]			INT				NULL,
 [ModifiedDatetime]		DATETIME		NULL, 
 [Workstation]			VARCHAR(20)		Collate Database_Default NOT NULL,
 CONSTRAINT [PK__Company] PRIMARY KEY CLUSTERED ([CompanyId]),
 CONSTRAINT [FK__Company_City] FOREIGN KEY ([CityId]) REFERENCES [City] ([CityId])
 ) ON [PRIMARY]
Go

INSERT INTO [Company]
		Select  1, 'DISCAREM S.A.',		'0992715553001', '042283497', 3, 'GUAYAS / GUAYAQUIL / TARQUI / COSME RENELLA 216 Y AV. DE LAS AMERICAS' , 0, 0, 0,  'A', 1, 0, 1, 0, 'SERVER'
UNION	Select  2, 'ECUARIDER S.A.',	'0992156287001', '042283497', 1, 'GUAYAS / GUAYAQUIL / TARQUI / AV. ISIDRO AYORA SOLAR 1 Y BENJAMIN CARRION' , 0, 0, 0,  'A', 1, 0, 1, 0, 'SERVER'
UNION	Select  3, 'EQUACORPSA S.A.',	'0992375280001', '042283497', 1, 'GUAYAS / GUAYAQUIL / TARQUI / COSME RENELLA 216 Y AV. DE LAS AMERICAS' , 0, 0, 0,  'I', 1, 0, 1, 0, 'SERVER'
UNION	Select  4, 'SALJUPER S.A.',		'0992104821001', '043910900', 1, 'GUAYAS / GUAYAQUIL / TARQUI / COSME RENELLA 216 Y AV. DE LAS AMERICAS' , 0, 0, 0,  'A', 1, 0, 1, 0, 'SERVER'

SELECT * FROM [Company]

/*Tabla Sucursales */
CREATE TABLE [dbo].[Location]
([LocationId]			[Smallint]		NOT NULL,
 [CompanyId]			[Smallint]		NOT NULL,
 [Name]					[varchar](120)	Collate Database_Default NULL,   /*Nombre Sucursal*/
 [Establishment]		[varchar](5)	Collate Database_Default NOT NULL,
 [Phone]				[varchar](10)	Collate Database_Default NULL,   /*Tel fono Sucursal*/
 [CityId]				INT				NOT NULL,
 [Address]				[varchar](150)	Collate Database_Default NULL,   /*Direccion Sucursal*/
 [IsMain]				[Bit]			NULL,   /*Sucursal Principal*/
 [ServerId]				[Int]			NOT NULL,
 [Status]				[Char](1)		Collate Database_Default NULL,  /**/
 [CreatedBy]			INT				NOT NULL,
 [CreatedDatetime]		DATETIME		NOT NULL, 
 [ModifiedBy]			INT				NULL,
 [ModifiedDatetime]		DATETIME		NULL, 
 [Workstation]			VARCHAR(20)		Collate Database_Default NOT NULL,
 CONSTRAINT [PK__Location] PRIMARY KEY CLUSTERED ([LocationId]),
 CONSTRAINT [FK__Location_Company] FOREIGN KEY ([CompanyId]) REFERENCES [Company] ([CompanyId]),
 CONSTRAINT [FK__Location_City] FOREIGN KEY ([CityId]) REFERENCES [City] ([CityId])
 )ON [PRIMARY]
Go

INSERT INTO [Location]
      Select  1, 1, 'SAMBORONDON',		'002', '043710150', 3, 'GUAYAS / SAMBORONDON / SAMBORONDON / MANGLERO SOLAR 84B',				1, 4, 'A', 1, 0, 1, 0, 'SERVER'
UNION Select  2, 1, 'LA JOYA',			'003', '000000000', 2, 'GUAYAS / DAULE / LA AURORA (SATELITE) / SOLAR D5',						0, 5, 'A', 1, 0, 1, 0, 'SERVER'
UNION Select  3, 2, 'ALBORADA',			'001', '042283497', 1, 'GUAYAS / GUAYAQUIL / TARQUI / AV. ISIDRO AYORA 1 Y BENJAMIN CARRION',	1, 3, 'A', 1, 0, 1, 0, 'SERVER'
UNION Select  4, 2, 'AMERICAS',			'002', '042283497', 1, 'GUAYAS / GUAYAQUIL / TARQUI / COSME RENELLA 216 Y AV. DE LAS AMERICAS', 0, 2, 'A', 1, 0, 1, 0, 'SERVER'
UNION Select  5, 4, 'DARK STORE',		'013', '043910900', 1, 'GUAYAS / GUAYAQUIL / VIA A LA COSTA',									0, 6, 'A', 1, 0, 1, 0, 'SERVER'

SELECT * FROM [Location]

/****** Objeto:  Table [dbo].[Salesman]     ******/
/****** Objetivo: Para los Vendedores que contendr  el Sistema ******/
CREATE TABLE [dbo].[Salesman]
([SalesmanId]			INT            NOT NULL,
 [Name]					VARCHAR(200)   NOT NULL,
 [SAPCode]				[varchar](20)  Collate Database_Default NOT NULL,
 [IsExternal]			[BIT]          NOT NULL,
 [ParentId]				INT            NOT NULL,
 [Type]					VARCHAR(2)     NOT NULL,
 [CommissionPercent]	[numeric](18,4)NOT NULL,  /*Valor Comision*/
 [Fulfillment]			[numeric](18,2)NOT NULL,  /*Valor Cumplimiento*/
 [Status]				[Char](1)      Collate Database_Default NULL,
 [CreatedBy]			INT            NOT NULL,
 [CreatedDatetime]		DATETIME       NOT NULL, 
 [ModifiedBy]			INT            NULL,
 [ModifiedDatetime]		DATETIME       NULL, 
 [Workstation]			VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__Salesman] PRIMARY KEY CLUSTERED ([SalesmanId])) ON [PRIMARY]
Go

INSERT INTO [Salesman]
SELECT	*, 0, '', 0, 0, 'A', 1, 0, NULL, NULL, 'SERVER'
FROM	(SELECT 0 [SalesmanId], 'NINGUNO' [Name], 0 [SAPCode], 0 [IsExternal]
UNION	SELECT 1, 'SUPERMERCADOS', 0, 0
UNION	SELECT 2, 'DOMICILIO', 0, 0
UNION	SELECT 3, 'EMPLEADOS', 0, 0
UNION	SELECT 4, 'GLOVO', 0, 1
UNION	SELECT 5, 'RAPPI', 0, 1
UNION	SELECT 6, 'PEDIDOS WEB', 0, 1) VIRT

SELECT * FROM [Salesman]

/*Tabla Tipos de Clientes */
CREATE TABLE [dbo].[CustomerType]
([CustomerTypeId] Int NOT NULL,
 [Name]				[varchar](220) Collate Database_Default NULL,
 [ParentId]			Int NOT NULL,
 [Level]			Int NOT NULL,
 [Status]			[Char](1)      Collate Database_Default NULL,
 [CreatedBy]        INT            NOT NULL,
 [CreatedDatetime]  DATETIME       NOT NULL, 
 [ModifiedBy]       INT            NULL,
 [ModifiedDatetime] DATETIME       NULL, 
 [Workstation]      VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__CustomerType] PRIMARY KEY CLUSTERED ([CustomerTypeId]) ) ON [PRIMARY]
Go

insert into [CustomerType]
Select  0, 'NINGUNO', 0, 0,  'A', 1, 0, NULL, NULL, 'SERVER'

SELECT * FROM [CustomerType]

CREATE TABLE [dbo].[IdentType]
([IdentTypeId]		[Int] NOT NULL,
 [Name]				[varchar](50)  Collate Database_Default NULL,
 [Prefix]			[Char](1)      Collate Database_Default NULL,
 [Status]			[Char](1)      Collate Database_Default NULL,
 [CreatedBy]        INT            NOT NULL,
 [CreatedDatetime]  DATETIME       NOT NULL, 
 [ModifiedBy]       INT            NULL,
 [ModifiedDatetime] DATETIME       NULL, 
 [Workstation]      VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__IdentType] PRIMARY KEY CLUSTERED ([IdentTypeId])) ON [PRIMARY]
Go

INSERT INTO [IdentType]
SELECT	*, 'A', 1, 0, NULL, NULL, 'SERVER'
FROM	(SELECT 1 [IdentTypeId], 'RUC' [Name], 'R' [Prefix]
UNION	SELECT 2, 'CEDULA', 'C'
UNION	SELECT 3, 'PASAPORTE', 'P'
UNION	SELECT 4, 'RUC EXTARNJERO', 'E'
UNION	SELECT 5, 'CONSUMIDOR FINAL', 'C') VIRT

SELECT * FROM [IdentType]


CREATE TABLE [dbo].[Customer]
([CustomerId]			BIGINT         NOT NULL,
 [CustomerIdLocal]		BIGINT         IDENTITY NOT NULL,
 [Lastname]				[varchar](150) Collate Database_Default NOT NULL,  /*Nombre Contacto*/
 [Firtsname]			[varchar](150) Collate Database_Default NOT NULL,  /*Nombre Contacto*/
 [SAPCode]				[varchar](20)  Collate Database_Default NOT NULL,  /*Codigo Auxiliar*/
 [LocationId]			SMALLINT       NOT NULL,
 [IdentTypeId]			[Int]          NOT NULL,
 [Identification]		[varchar](20)  Collate Database_Default NULL,
 [Gender]				[Varchar](1)   Collate Database_Default NULL,  /*Genero*/
 [PersonType]			[Char](1)      Collate Database_Default NOT NULL,  /*Tipo Persona(N:Natural, J:Juridica, E:Especial)*/
 [IsSpecialTaxpayer]	[Bit]          NULL, /*Si es Contribuyente especial*/ 
 [IsEmployee]			[Bit]          NOT NULL, /*Si es Empleado*/
 [EmployeeId]			INT            NOT NULL, /*Id del Empleado asignado*/
 [Phone]				[varchar](10)  Collate Database_Default NOT NULL,  /*Tel fono */
 [Email]					[varchar](150) Collate Database_Default NOT NULL,  /*Email */
 [CityId]				INT            NOT NULL,
 [Address]				varchar(250)   Collate Database_Default NULL, /*Direccion Cia*/
 [CustomerTypeId]		Int            NOT NULL,
 [UseRetention]         [Bit]          NULL, /*RETENCION*/
 [IsCredit]				[Bit]          NULL, /*RETENCION*/
 [CreditLimit]          NUMERIC(18, 2) NOT NULL, --
 [Status]               [Char](1)      Collate Database_Default NULL,
 [CreatedBy]            INT            NOT NULL,
 [CreatedDatetime]      DATETIME       NOT NULL, 
 [ModifiedBy]           INT            NULL,
 [ModifiedDatetime]     DATETIME       NULL, 
 [Workstation]          VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__Customer] PRIMARY KEY CLUSTERED ([CustomerId]),
 CONSTRAINT [FK__Customer_Location] FOREIGN KEY ([LocationId]) REFERENCES [Location] ([LocationId]),
 CONSTRAINT [FK__Customer_IdentType] FOREIGN KEY ([IdentTypeId]) REFERENCES [IdentType] ([IdentTypeId]),
 CONSTRAINT [FK__Customer_City] FOREIGN KEY ([CityId]) REFERENCES [City] ([CityId]),
 CONSTRAINT [FK__Customer_CustomerType] FOREIGN KEY ([CustomerTypeId]) REFERENCES [CustomerType] ([CustomerTypeId]),
 ) ON [PRIMARY]
Go

Create Unique Index Customer on Customer([Identification])
Go

CREATE NONCLUSTERED INDEX [Ind_Customer_1]
    ON [dbo].[Customer]([CustomerIdLocal] ASC);
GO


CREATE TABLE [dbo].[CustomerAddress]
([CustomerAddressId]		BIGINT        NOT NULL,
 [CustomerAddressIdLocal]	BIGINT        IDENTITY (1, 1) NOT NULL,
 [CustomerId]				BIGINT        NOT NULL,
 [Sequence]					INT           NOT NULL,
 [Address]					VARCHAR (MAX) NOT NULL,
 [AddressReference]			VARCHAR (MAX) NOT NULL,
 [Coordinates]				VARCHAR (100) NOT NULL,
 [Telephone]				VARCHAR (100) NOT NULL,
 [Status]					CHAR (1)      DEFAULT ('A') NULL,
 [CreatedBy]				INT            NOT NULL,
 [CreatedDatetime]			DATETIME       NOT NULL, 
 [ModifiedBy]				INT            NULL,
 [ModifiedDatetime]			DATETIME       NULL, 
 [Workstation]				VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__CustomerAddress] PRIMARY KEY CLUSTERED ([CustomerAddressId]),
 CONSTRAINT [FK__CustomerAddress_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [Customer] ([CustomerId]),
 ) ON [PRIMARY]
Go

CREATE NONCLUSTERED INDEX [Ind_CustomerAddress_1]
    ON [dbo].[CustomerAddress]([CustomerAddressIdLocal] ASC);
GO

CREATE NONCLUSTERED INDEX [Ind_CustomerAddress_2]
    ON [dbo].[CustomerAddress]([CustomerId] ASC)
    INCLUDE([Sequence]);


CREATE TABLE [dbo].[Vendor]
([VendorId]             [INT]          NOT NULL,
 [Name]                 [varchar](150) Collate Database_Default NOT NULL,  /*Nombre Contacto*/
 [SAPCode]              [varchar](20)  Collate Database_Default NOT NULL,  /*Codigo Auxiliar*/
 [IdentTypeId]          [Int]          NOT NULL,
 [Identification]       [varchar](20)  Collate Database_Default NULL,
 [TaxpayerType]         [Char](1)      Collate Database_Default NOT NULL,  /*Tipo Persona(N:Natural, J:Juridica, E:Especial)*/
 [IsSpecialTaxpayer]    [Bit]          NULL, /*Si es Contribuyente especial*/  
 [Phone]                [varchar](10)  Collate Database_Default NOT NULL,  /*Tel fono */
 [Email]                 [varchar](100) Collate Database_Default NOT NULL,  /*Email */
 [CityId]               INT            NOT NULL,
 [Address]              varchar(250)   Collate Database_Default NULL, /*Direccion Cia*/
 [Status]               [Char](1)      Collate Database_Default NULL,
 [CreatedBy]            INT            NOT NULL,
 [CreatedDatetime]      DATETIME       NOT NULL, 
 [ModifiedBy]           INT            NULL,
 [ModifiedDatetime]     DATETIME       NULL, 
 [Workstation]          VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__Vendor] PRIMARY KEY CLUSTERED ([VendorId]),
 CONSTRAINT [FK__Vendor_CustIdType] FOREIGN KEY ([IdentTypeId]) REFERENCES [IdentType] ([IdentTypeId]),
 CONSTRAINT [FK__Vendor_City] FOREIGN KEY ([CityId]) REFERENCES [City] ([CityId])
 ) ON [PRIMARY]
Go

INSERT INTO [Vendor]
SELECT 0, 'NINGUNO', '', 5, '', '', 0, '', '', 1, '', 'A', 1, 0, NULL, NULL, 'SERVER'

SELECT * FROM [Vendor]

CREATE TABLE [dbo].[Brand]
([BrandId]			Int NOT NULL,
 [Name]				[varchar](220) Collate Database_Default NULL,
 [SAPCode]			[varchar](20)  Collate Database_Default NOT NULL,
 [Status]			[Char](1)      Collate Database_Default NULL,
 [CreatedBy]        INT            NOT NULL,
 [CreatedDatetime]  DATETIME       NOT NULL, 
 [ModifiedBy]       INT            NULL,
 [ModifiedDatetime] DATETIME       NULL, 
 [Workstation]      VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__Brand] PRIMARY KEY CLUSTERED ([BrandId])) ON [PRIMARY]
Go

INSERT INTO [Brand]
Select 0, 'NINGUNO', '', 'A', 1, 0, NULL, NULL, 'SERVER'

SELECT * FROM [Brand]

CREATE TABLE [dbo].[InventLocation](
 [InventLocationId] INT            NOT NULL,
 [Name]             [varchar](150) Collate Database_Default NOT NULL,
 [SAPCode]          [varchar](20)  Collate Database_Default NOT NULL,  
 [LocationId]       SMALLINT       NOT NULL,
 [Type]             [varchar](2)      Collate Database_Default NULL, /*Invent, Quarentine,Transit*/
 [IsMain]           [Bit]          NOT NULL,  /*Es Principal*/
 [Status]           [Char](1)      Collate Database_Default NULL,
 [CreatedBy]        INT            NOT NULL,
 [CreatedDatetime]  DATETIME       NOT NULL, 
 [ModifiedBy]       INT            NULL,
 [ModifiedDatetime] DATETIME       NULL, 
 [Workstation]      VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__InventLocation] PRIMARY KEY CLUSTERED ([InventLocationId]),
 CONSTRAINT [FK__InventLocation_Location] FOREIGN KEY ([LocationId]) REFERENCES [Location] ([LocationId])
 ) ON [PRIMARY]
Go

INSERT INTO [InventLocation]
SELECT	*, 'A', 1, 0, NULL, NULL, 'SERVER'
FROM	(SELECT  1 [InventLocationId], 'SUPERMERCADOS SAMBORONDON' [Name], '' [SAPCode], 1 [LocationId], '' [Type], 1 [IsMain]
UNION	SELECT  2, 'SECOS SAMBORONDON',                    '', 1, '', 0
UNION	SELECT  3, 'CARNICOS SAMBORONDON',                 '', 1, '', 0
UNION	SELECT  4, 'LEGUMBRES SAMBORONDON',                '', 1, '', 0
UNION	SELECT  5, 'MATERIALES Y SUMINISTROS SAMBORONDON', '', 1, '', 0
UNION	SELECT  6, 'DEVOLUCIONES SAMBORONDON',             '', 1, '', 0
UNION	SELECT  7, 'COCINA SAMBORONDON',                   '', 1, '', 0
UNION	SELECT  8, 'TRANSITO SAMBORONDON',                 '', 1, '', 0
UNION	SELECT  9, 'TEMPORADA SAMBORONDON',                '', 1, '', 0
UNION	SELECT 10, 'COMPRAS SAMBORONDON',                  '', 1, '', 0
/*LA JOYA*/
UNION	SELECT 11, 'SUPERMERCADOS LA JOYA',                '', 2, '', 1
UNION	SELECT 12, 'SECOS LA JOYA',                        '', 2, '', 0
UNION	SELECT 13, 'CARNICOS LA JOYA',                     '', 2, '', 0
UNION	SELECT 14, 'LEGUMBRES LA JOYA',                    '', 2, '', 0
UNION	SELECT 15, 'MATERIALES Y SUMINISTROS LA JOYA',     '', 2, '', 0
UNION	SELECT 16, 'DEVOLUCIONES LA JOYA',                 '', 2, '', 0
UNION	SELECT 17, 'COCINA LA JOYA',                       '', 2, '', 0
UNION	SELECT 18, 'TRANSITO LA JOYA',                     '', 2, '', 0
UNION	SELECT 19, 'TEMPORADA LA JOYA',                    '', 2, '', 0
UNION	SELECT 20, 'COMPRAS LA JOYA',                      '', 2, '', 0
/*ALBORADA*/
UNION	SELECT 21, 'SUPERMERCADOS ALBORADA',				'', 3, '', 1
UNION	SELECT 22, 'SECOS ALBORADA',                        '', 3, '', 0
UNION	SELECT 23, 'CARNICOS ALBORADA',                     '', 3, '', 0
UNION	SELECT 24, 'LEGUMBRES ALBORADA',                    '', 3, '', 0
UNION	SELECT 25, 'MATERIALES Y SUMINISTROS ALBORADA',     '', 3, '', 0
UNION	SELECT 26, 'DEVOLUCIONES ALBORADA',                 '', 3, '', 0
UNION	SELECT 27, 'COCINA ALBORADA',                       '', 3, '', 0
UNION	SELECT 28, 'TRANSITO ALBORADA',                     '', 3, '', 0
UNION	SELECT 29, 'TEMPORADA ALBORADA',                    '', 3, '', 0
UNION	SELECT 30, 'COMPRAS ALBORADA',                      '', 3, '', 0
/*AMERICAS*/
UNION	SELECT 31, 'SUPERMERCADOS AMERICAS',				'', 4, '', 1
UNION	SELECT 32, 'SECOS AMERICAS',                        '', 4, '', 0
UNION	SELECT 33, 'CARNICOS AMERICAS',                     '', 4, '', 0
UNION	SELECT 34, 'LEGUMBRES AMERICAS',                    '', 4, '', 0
UNION	SELECT 35, 'MATERIALES Y SUMINISTROS AMERICAS',     '', 4, '', 0
UNION	SELECT 36, 'DEVOLUCIONES AMERICAS',                 '', 4, '', 0
UNION	SELECT 37, 'COCINA AMERICAS',                       '', 4, '', 0
UNION	SELECT 38, 'TRANSITO AMERICAS',                     '', 4, '', 0
UNION	SELECT 39, 'TEMPORADA AMERICAS',                    '', 4, '', 0
UNION	SELECT 40, 'COMPRAS AMERICAS',                      '', 4, '', 0

) VIRT

SELECT * FROM [InventLocation]

/*Tipo de transaccion de Inventario*/
CREATE TABLE [dbo].[InventTransType]
([InventTransTypeId]	Int NOT NULL,
 [Name]					[varchar](150) Collate Database_Default NULL,
 [SAPCode]				[varchar](20)  Collate Database_Default NOT NULL,
 [Type]					[Char](1)      Collate Database_Default NOT NULL,
 [Status]				[Char](1)      Collate Database_Default NULL,
 [CreatedBy]			INT            NOT NULL,
 [CreatedDatetime]		DATETIME       NOT NULL, 
 [ModifiedBy]			INT            NULL,
 [ModifiedDatetime]		DATETIME       NULL, 
 [Workstation]			VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__InventTransType] PRIMARY KEY CLUSTERED ([InventTransTypeId])) ON [PRIMARY]
Go

/*unidad de Medida*/
CREATE TABLE [dbo].[InventUnit]
([InventUnitId]		Int NOT NULL,
 [Name]				[varchar](220) Collate Database_Default NULL,
 [SAPCode]			[varchar](20)  Collate Database_Default NOT NULL,
 [WeightControl]	[Bit]          NOT NULL,  /*Si es Peso*/
 [Status]			[Char](1)      Collate Database_Default NULL,
 [CreatedBy]        INT            NOT NULL,
 [CreatedDatetime]  DATETIME       NOT NULL, 
 [ModifiedBy]       INT            NULL,
 [ModifiedDatetime] DATETIME       NULL, 
 [Workstation]      VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__InventUnit] PRIMARY KEY CLUSTERED ([InventUnitId])) ON [PRIMARY]
Go

INSERT INTO [InventUnit]
      Select '01', 'UNIDAD'   , '', 0, 'A', 1, 0, NULL, NULL, 'SERVER'
UNION Select '02', 'KILOGRAMO', '', 1, 'A', 1, 0, NULL, NULL, 'SERVER'
UNION Select '03', 'LIBRA'    , '', 1, 'I', 1, 0, NULL, NULL, 'SERVER'
UNION Select '04', 'LITRO'    , '', 0, 'I', 1, 0, NULL, NULL, 'SERVER'
UNION Select '05', 'METRO'    , '', 0, 'I', 1, 0, NULL, NULL, 'SERVER'

SELECT * FROM [InventUnit]

/*Tabla Familia de Productos */
CREATE TABLE [dbo].[ProductCategory]
([ProductCategoryId]	Int NOT NULL,
 [ParentId]				Int NOT NULL,
 [Name]					[varchar](220) Collate Database_Default NULL,
 [FriendlyName]			[varchar](220) Collate Database_Default NULL,
 [Level]				Int NOT NULL,
 [Status]				[Char](1)      Collate Database_Default NULL,
 [CreatedBy]			INT            NOT NULL,
 [CreatedDatetime]		DATETIME       NOT NULL, 
 [ModifiedBy]			INT            NULL,
 [ModifiedDatetime]		DATETIME       NULL, 
 [Workstation]			VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__ProductCategory] PRIMARY KEY CLUSTERED ([ProductCategoryId]), 
) ON [PRIMARY]
Go

INSERT INTO [ProductCategory]
Select 0, 0, 'NINGUNO', '', 0, 'A', 1, 0, NULL, NULL, 'SERVER'

SELECT * FROM [ProductCategory]

CREATE TABLE [dbo].[ProductGroup]
([ProductGroupId]	Int NOT NULL,
 [Name]				[varchar](220) Collate Database_Default NULL,
 [Status]			[Char](1)      Collate Database_Default NULL,
 [CreatedBy]		INT            NOT NULL,
 [CreatedDatetime]	DATETIME       NOT NULL, 
 [ModifiedBy]		INT            NULL,
 [ModifiedDatetime]	DATETIME       NULL, 
 [Workstation]		VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__ProductGroup] PRIMARY KEY CLUSTERED ([ProductGroupId]), 
) ON [PRIMARY]
Go

INSERT INTO [ProductGroup]
Select 0, 'NINGUNO', 'A', 1, 0, NULL, NULL, 'SERVER'

SELECT * FROM [ProductGroup]

CREATE TABLE [dbo].[Product]
([ProductId]            BIGINT NOT NULL,
 [SAPCode]              [varchar](20)  Collate Database_Default NOT NULL,
 [Name]                 [varchar](220) Collate Database_Default NULL,
 [Description]          [varchar](150) Collate Database_Default NOT NULL,  /*Nombre Producto*/
 [InventUnitId]         Int            NOT NULL,
 [ProductGroupId]       Int            NOT NULL,
 [ProductCategoryId]    INT            NOT NULL, 
 [Type]                 [varchar](1)   Collate Database_Default NOT NULL, /*Tipe=Product, Services */ 
 [IsDeductible]         [BIT]          NOT NULL, /*si es decucible al sri*/
 [UseTax]               [BIT]          NOT NULL, /*Graba IVA*/
 [UseIrbp]              [BIT]          NOT NULL, /*si es IRBP*/
 [IsECommerce]          [BIT]          NOT NULL, /*si es de Venta*/
 [UseCatchWeight]       [BIT]          NOT NULL, /*si es de CW*/
 [CatchWeightMax]       [numeric](24, 6) NOT NULL, /*Max CW*/
 [CatchWeightMin]       [numeric](24, 6) NOT NULL, /*Min CW*/
 [VendorId]             [INT]          NULL,
 [BrandId]              [INT]          NULL,
 [ProductOldCode]       [varchar](20)  Collate Database_Default NOT NULL,  /*codigo Anterior*/
 [Status]               [Char](1)      Collate Database_Default NULL,
 [CreatedBy]            INT            NOT NULL,
 [CreatedDatetime]      DATETIME       NOT NULL, 
 [ModifiedBy]           INT            NULL,
 [ModifiedDatetime]     DATETIME       NULL, 
 [Workstation]          VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__Product] PRIMARY KEY CLUSTERED ([ProductId]),
 CONSTRAINT [FK__Product_InventUnit] FOREIGN KEY ([InventUnitId]) REFERENCES [InventUnit] ([InventUnitId]),
 CONSTRAINT [FK__Product_ProductGroup] FOREIGN KEY ([ProductGroupId]) REFERENCES [ProductGroup] ([ProductGroupId]),
 CONSTRAINT [FK__Product_ProductCategory] FOREIGN KEY ([ProductCategoryId]) REFERENCES [ProductCategory] ([ProductCategoryId]),
 CONSTRAINT [FK__Product_VendorId] FOREIGN KEY ([VendorId]) REFERENCES [Vendor] ([VendorId]),
 CONSTRAINT [FK__Product_Brand] FOREIGN KEY ([BrandId]) REFERENCES [Brand] ([BrandId])
 ) ON [PRIMARY]
Go

CREATE UNIQUE INDEX Ind_Product_ProductOldCode on Product([ProductOldCode])
GO

CREATE NONCLUSTERED INDEX [Ind_Product_1]
    ON [dbo].[Product]([ModifiedDatetime] ASC)
    INCLUDE([Name], [InventUnitId], [ProductCategoryId], [UseTax], [IsECommerce], [ProductOldCode], [Status]);
GO

CREATE NONCLUSTERED INDEX [Ind_Product_2]
    ON [dbo].[Product]([Name] ASC, [ProductCategoryId] ASC)
    INCLUDE([UseCatchWeight]);
GO

CREATE NONCLUSTERED INDEX [Ind_Product_3]
    ON [dbo].[Product]([ProductCategoryId] ASC, [Status] ASC)
    INCLUDE([UseTax], [ProductOldCode]);
GO


CREATE TABLE [dbo].[ProductBarcode]
([ProductId]         BIGINT            NOT NULL,
 [Barcode]           [varchar](20)     Collate Database_Default NOT NULL,  /*codigo Anterior*/
 [Quantity]          [numeric](18, 2)  NOT NULL, 
 [Status]            [Char](1)      Collate Database_Default NULL,
 [CreatedBy]         INT            NOT NULL,
 [CreatedDatetime]   DATETIME       NOT NULL, 
 [ModifiedBy]        INT            NULL,
 [ModifiedDatetime]  DATETIME       NULL, 
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__ProductBarcode] PRIMARY KEY CLUSTERED ([ProductId], [Barcode]),
 CONSTRAINT [FK__ProductBarcode_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([ProductId])
 ) ON [PRIMARY]
Go

CREATE NONCLUSTERED INDEX [Ind_ProductBarcode_1]
    ON [dbo].[ProductBarcode]([Barcode] ASC);
GO


CREATE TABLE [dbo].[ProductModule]
([ProductId]		BIGINT            NOT NULL,
 [LocationId]		INT               NOT NULL,
 [Cost]				[numeric](24, 6)  NOT NULL, /*COSTO*/
 [PriceReference]	[numeric](24, 6)  NOT NULL, /*PRECIO REF*/
 [Price]			[numeric](24, 6)  NOT NULL, /*PRECIO*/
 [TaxAmount]		[numeric](24, 6)  NOT NULL, /*IVA*/ 
 [IrbpAmount]		[numeric](24, 6)  NOT NULL, /*IVA*/ 
 [CreatedBy]        INT            NOT NULL,
 [CreatedDatetime]  DATETIME       NOT NULL, 
 [ModifiedBy]       INT            NULL,
 [ModifiedDatetime] DATETIME       NULL, 
 [Workstation]      VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__ProductModule] PRIMARY KEY CLUSTERED ([ProductId], [LocationId]),
 CONSTRAINT [FK__ProductModule_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([ProductId])
 ) ON [PRIMARY]
Go

CREATE NONCLUSTERED INDEX [Ind_ProductModule_1]
    ON [dbo].[ProductModule]([LocationId] ASC)
    INCLUDE([Cost]);
GO

CREATE NONCLUSTERED INDEX [Ind_ProductModule_2]
    ON [dbo].[ProductModule]([LocationId] ASC)
    INCLUDE([Cost], [Price], [ModifiedDatetime]);
GO


--CREATE TABLE [dbo].[ProductModuleRange](
-- [ProductId]      BIGINT            NOT NULL,
-- [LocationId]     INT               NOT NULL,
-- [Sequence]       SMALLINT          NOT NULL,
-- [StartRange]     [numeric](24, 6)  NOT NULL, /*PRECIO*/
-- [FinalRange]     [numeric](24, 6)  NOT NULL, /*PRECIO*/
-- [Type]           [varchar](1)      Collate Database_Default NOT NULL, /*P, V*/ 
-- [Price]          [numeric](24, 6)  NOT NULL, /*PRECIO*/
-- CONSTRAINT [PK__ProductModuleRange] PRIMARY KEY CLUSTERED ([ProductId], [LocationId]),
-- CONSTRAINT [FK__ProductModuleRange_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([ProductId])
-- ) ON [PRIMARY]
--Go

CREATE TABLE [dbo].[InventProductLocation](
 [ProductId]         BIGINT            NOT NULL,
 [LocationId]        INT               NOT NULL,
 [InventLocationId]  INT               NOT NULL,
 [MinStock]          [numeric](12, 2)  NOT NULL, /*Existencia Minimo*/
 [MaxStock]          [numeric](12, 2)  NOT NULL, /*Existencia Maximo*/
 [Stock]             [numeric](24, 6)  NOT NULL, /*Existencia*/
 [CreatedBy]         INT            NOT NULL,
 [CreatedDateTime]   DATETIME       NOT NULL, 
 [ModifiedBy]        INT            NULL,
 [ModifiedDateTime]  DATETIME       NULL, 
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__InventProductLocation] PRIMARY KEY CLUSTERED ([ProductId], [LocationId], [InventLocationId]),
 CONSTRAINT [FK__InventProductLocation_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([ProductId]),
 CONSTRAINT [FK__InventProductLocation_InventLocation] FOREIGN KEY ([InventLocationId]) REFERENCES [InventLocation] ([InventLocationId])
 ) ON [PRIMARY]
Go

CREATE NONCLUSTERED INDEX [Ind_InventProductLocation_1]
    ON [dbo].[InventProductLocation]([LocationId] ASC, [ModifiedDateTime] ASC)
    INCLUDE([Stock]);
GO

CREATE NONCLUSTERED INDEX [Ind_InventProductLocation_2]
    ON [dbo].[InventProductLocation]([ModifiedDateTime] ASC)
    INCLUDE([Stock]);
GO



CREATE TABLE [dbo].[PromotionType]
([PromotionTypeId]   INT            NOT NULL,
 [Name]              VARCHAR(150)   Collate Database_Default NOT NULL,  /*Nombre*/ 
 [Type]              VARCHAR(5)     Collate Database_Default NOT NULL,
 [UseCoupon]         Bit            NOT NULL,
 [UseReward]         Bit            NOT NULL,
 [ControlCoupon]     Bit            NOT NULL,
 [Status]            CHAR(1)        NOT NULL, --Estado Promocion
 [CreatedBy]         INT            NOT NULL,
 [CreatedDatetime]   DATETIME       NOT NULL, 
 [ModifiedBy]        INT            NULL,
 [ModifiedDatetime]  DATETIME       NULL, 
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__PromotionType] PRIMARY KEY CLUSTERED ([PromotionTypeId]),
 ) ON [PRIMARY]
Go

INSERT INTO [PromotionType]
SELECT	*, 'A', 1, 0, NULL, NULL, 'SERVER'
FROM	(SELECT  1 [PromotionTypeId], 'CUPONES PARA SORTEOS' [Name],'CUST' [Type], 1 [UseCoupon],  0 [UseReward],  0 [ControlCoupon]
UNION	SELECT  2, 'CUPONES CON STOCK SORTEOS',               'CSST', 1,  0,  1
UNION	SELECT  3, 'CUPONES PARA PREMIOS',                    'CUPR', 1,  1,  0
UNION	SELECT  4, 'CUPONES CON STOCK PREMIOS',               'CSPR', 1,  1,  1
UNION	SELECT  5, 'DESCUENTO 2X1',                           'D2X1', 0,  0,  0
UNION	SELECT  6, 'DESCUENTO 3X2',                           'D3X2', 0,  0,  0
UNION	SELECT  7, 'DESCUENTO 4X3',                           'D4X3', 0,  0,  0
UNION	SELECT  8, 'DESCUENTO CLIENTES LISTADOS',             'DCLI', 0,  0,  0
UNION	SELECT  9, 'DESCUENTO EMPLEADOS',                     'DEMP', 0,  0,  0
UNION	SELECT 10, 'DESCUENTO PORCENTAJE PRODUCTO PRINCIPAL', 'DSCP', 0,  0,  0
UNION	SELECT 11, 'DESCUENTO PORCENTAJE PRODUCTO SECUNDARIO','DSCS', 0,  0,  0
UNION	SELECT 12, 'DESCUENTO PORCENTAJE PRODUCTO ADICIONAL', 'DSCA', 0,  1,  0
UNION	SELECT 13, 'DESCUENTO PORCENTAJE SEGUNDA LIBRA',      'DPSL', 0,  0,  0) VIRT

SELECT	* FROM [PromotionType]
/*--------------------Cabecera Promociones--------------------*/
CREATE TABLE [dbo].[PromotionTable]
([PromotionId]       BIGINT         NOT NULL,
 [Name]              VARCHAR(200)   Collate Database_Default NOT NULL,  --Nombre Poltica
 [PromotionTypeId]   INT            NOT NULL,
 [ConsumptionOrigin] CHAR(1)        NOT NULL,  --C:Cantidad, V:Valor
 [ConsumptionMax]    NUMERIC(18, 2) NOT NULL, --
 [Vigence]           DATETIME       NOT NULL,--Fecha Inicio
 [Expiration]        DATETIME       NOT NULL,--Fecha Fin
 [UseMonday]         BIT            NOT NULL,  --D a
 [UseTuesday]        BIT            NOT NULL,  --D a
 [UseWednesday]      BIT            NOT NULL,  --D a
 [UseThursday]       BIT            NOT NULL,  --D a
 [UseFriday]         BIT            NOT NULL,  --D a
 [UseSaturday]       BIT            NOT NULL,  --D a
 [UseSunday]         BIT            NOT NULL,  --D a
 [Status]            [Char](1)      Collate Database_Default NULL,
 [CreatedBy]         INT            NOT NULL,
 [CreatedDatetime]   DATETIME       NOT NULL, 
 [ModifiedBy]        INT            NULL,
 [ModifiedDatetime]  DATETIME       NULL, 
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__PromotionTable] PRIMARY KEY CLUSTERED ([PromotionId]),
 CONSTRAINT [FK__PromotionTable_PromotionType] FOREIGN KEY ([PromotionTypeId]) REFERENCES [PromotionType] ([PromotionTypeId]),
 ) ON [PRIMARY]
Go

INSERT INTO [PromotionTable]
      SELECT   1, 'EMPLEADOS LA ESPA OLA DESCUENTO 10%',        9, 'V', 0, '20200101', '20501231', 1, 1, 1, 1, 1, 1, 1, 'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT   2, 'MARTES DE EMBUTIDOS DESCUENTO 20%',         10, 'C', 0, '20200101', '20501231', 0, 1, 0, 0, 0, 0, 0, 'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT   3, 'MIERCOLES DE FRUTAS Y VEGETALES 25%',       10, 'C', 0, '20200101', '20501231', 0, 0, 1, 0, 0, 0, 0, 'I', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT   4, 'CLIENTES GOLDGYMS DESCUENTO 10 %, TCR 5%',   8, 'C', 0, '20200101', '20201231', 1, 1, 1, 1, 1, 1, 1, 'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT   5, 'CLIENTES TAURUS DESCUENTO 10 %, TCR 5%',     8, 'C', 0, '20200101', '20200930', 1, 1, 1, 1, 1, 1, 1, 'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT   6, 'CLIENTES TORREMAR DESCUENTO 10 %, TCR 5%',	8, 'C', 0, '20200101', '20231031', 1, 1, 1, 1, 1, 1, 1, 'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT   7, 'FIESTAS OCTUBRINAS 2DO PROD DESCUENTO 50%', 11, 'V', 0, '20201002', '20201031', 1, 1, 1, 1, 1, 1, 1, 'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT   8, 'PROMO CRUZADA PICANHA + VINO A $5.99',	   12, 'V', 20, '20201002', '20201031', 1, 1, 1, 1, 1, 1, 1, 'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT   20, 'DESCUENTO CLIENTES ESPECIALES',				9, 'V', 0, '20200101', '20501231', 1, 1, 1, 1, 1, 1, 1, 'A', 1, 0, NULL, NULL, 'SERVER'

---UNION SELECT   9, 'TIPICOS DE OCTUBRE CUPON LINEA BLANCA',	    1, 'C', 2, '20201101', '20201130', 1, 1, 1, 1, 1, 1, 1, 'A', 1, 0, NULL, NULL, 'SERVER'
---UNION SELECT  10, 'CUPON DELANTAL LA ESPA OLA',	    4, 'V', 75, '20201101', '20201130', 1, 1, 1, 1, 1, 1, 1, 'A', 1, 0, NULL, NULL, 'SERVER'

/*--------------------Detalle Promocion Clientes Asociados --------------------*/
CREATE TABLE [dbo].[PromotionCustomer]
([PromotionId]		BIGINT         NOT NULL,
 [Sequence]			INT            NOT NULL,
 [CustomerId]		BIGINT         not null,
 [Percent]			numeric(18,4)  not null,
 [StatusPromCust]	[Char](1)      Collate Database_Default NULL,
 [CreatedBy]        INT            NOT NULL,
 [CreatedDatetime]  DATETIME       NOT NULL, 
 [ModifiedBy]       INT            NULL,
 [ModifiedDatetime] DATETIME       NULL, 
 [Workstation]      VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__PromotionCustomer] PRIMARY KEY CLUSTERED ([PromotionId], [Sequence]),
 CONSTRAINT [FK__PromotionCustomer_PromotionTable] FOREIGN KEY ([PromotionId]) REFERENCES [PromotionTable] ([PromotionId]),
 CONSTRAINT [FK__PromotionCustomer_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [Customer] ([CustomerId]),
 ) ON [PRIMARY]
Go

/*--------------------Detalle Promocion Formas de Pago --------------------*/
CREATE TABLE [dbo].[PromotionPaymMode](
 [PromotionId]				BIGINT			NOT NULL,
 [Sequence]					INT				NOT NULL,
 [PaymModeId]				INT				NOT NULL,
 [BankId]					[INT]			NOT NULL,
 [CreditCardId]				[INT]			NOT NULL,
 [Percent]					numeric(18,4)	not null,
 [StatusPromPaym]			[Char](1)		Collate Database_Default NULL,
 [RewardMultiplierType]		varchar(1)		NOT NULL,
 [RewardMultiplierValue]	[INT]			NOT NULL,
 [CreatedBy]				INT				NOT NULL,
 [CreatedDatetime]			DATETIME		NOT NULL, 
 [ModifiedBy]				INT				NULL,
 [ModifiedDatetime]			DATETIME		NULL, 
 [Workstation]				VARCHAR(20)		Collate Database_Default NOT NULL,
 CONSTRAINT [PK__PromotionPaymMode] PRIMARY KEY CLUSTERED ([PromotionId], [Sequence]),
 CONSTRAINT [FK__PromotionPaymMode_PromotionTable] FOREIGN KEY ([PromotionId]) REFERENCES [PromotionTable] ([PromotionId]),
 CONSTRAINT [FK__PromotionPaymMode_PaymMode] FOREIGN KEY ([PaymModeId]) REFERENCES [PaymMode] ([PaymModeId])
 ) ON [PRIMARY]
Go

/*--------------------Detalle Promocion Productos--------------------*/
CREATE TABLE [dbo].[PromotionProducts](
 [PromotionId]       BIGINT         NOT NULL,
 [Sequence]          INT            NOT NULL,
 [Type]              VARCHAR(5)     Collate Database_Default NOT NULL, 
 [Origin]            VARCHAR(1)     Collate Database_Default NOT NULL,
 [ProductGroupId]    Int            NOT NULL,
 [ProductCategoryId] INT            NOT NULL, 
 [ProductId]         BIGINT         NOT NULL,
 [Percent]           numeric(18,4)  NOT null,
 [AddCoupon]         BIT            NOT NULL,
 [StatusPromProd]    [Char](1)      Collate Database_Default NULL,
 [CreatedBy]         INT            NOT NULL,
 [CreatedDatetime]   DATETIME       NOT NULL, 
 [ModifiedBy]        INT            NULL,
 [ModifiedDatetime]  DATETIME       NULL, 
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__PromotionProducts] PRIMARY KEY CLUSTERED ([PromotionId], [Sequence]),
 CONSTRAINT [FK__PromotionProducts_PromotionTable] FOREIGN KEY ([PromotionId]) REFERENCES [PromotionTable] ([PromotionId]),
 ) ON [PRIMARY]
Go

CREATE NONCLUSTERED INDEX [Ind_PromotionProducts_1]
    ON [dbo].[PromotionProducts]([Type] ASC, [StatusPromProd] ASC)
    INCLUDE([Origin], [ProductCategoryId], [ProductId]);
GO

/*--------------------Detalle Promocion PREMIOS--------------------*/
CREATE TABLE [dbo].[PromotionReward]
([PromotionId]       BIGINT         NOT NULL,
 [Sequence]          INT            NOT NULL,
 [ProductId]         BIGINT         NOT NULL,
 [StartRange]        NUMERIC(24, 4) NOT NULL, 
 [FinalRange]        NUMERIC(24, 4) NOT NULL, 
 [Percent]           NUMERIC(12, 4) NOT NULL, 
 [LowInventory]      BIT            NOT NULL,   
 [ProductIdReward]   BIGINT         NOT NULL,
 [QuantityReceive]   INT            NOT NULL, --
 [MaxReceive]        INT            NOT NULL, -- 
 [Caption]           VARCHAR(200)    Collate Database_Default NOT NULL,
 [TotalReward]       INT            NOT NULL, --
 [StockReward]       INT            NOT NULL, --
 [StatusPromRew]     [Char](1)      Collate Database_Default NULL,
 [CreatedBy]         INT            NOT NULL,
 [CreatedDatetime]   DATETIME       NOT NULL, 
 [ModifiedBy]        INT            NULL,
 [ModifiedDatetime]  DATETIME       NULL, 
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__PromotionReward] PRIMARY KEY CLUSTERED ([PromotionId], [Sequence]),
 CONSTRAINT [FK__PromotionReward_PromotionTable] FOREIGN KEY ([PromotionId]) REFERENCES [PromotionTable] ([PromotionId]),
 ) ON [PRIMARY]
Go 

/*--------------------Cabecera Tarjetas--------------------*/
CREATE TABLE [dbo].[InternalCreditCard]
([InternalCreditCardId]       BIGINT         NOT NULL,
 [InternalCreditCardIdLocal]  BIGINT         NOT NULL,
 [Barcode]                    VARCHAR(25)    Collate Database_Default NOT NULL,  --clave unica de la tareta
 [Name]                       VARCHAR(150)   Collate Database_Default NOT NULL,  --Nombre relacionado
 [Type]                       VARCHAR(1)     NOT NULL,  --Tipo Tarjeta C:CONSUMO CORP; E:EMPLEADO; R:REGALO
 [Vigence]                    DATETIME       NOT NULL,--Fecha Inicio
 [Expiration]                 DATETIME       NOT NULL,--Fecha Fin
 [CustomerId]                 BIGINT         NOT NULL,  --id del cliente final
 [EmployeeId]                 BIGINT         NOT NULL,  --id del empleado local
 [Quota]                      NUMERIC(18, 2) NOT NULL, --
 [Consumed]                   NUMERIC(18, 2) NOT NULL, --
 [Printed]                    BIT            NOT NULL, --Estado Tarjeta
 [Status]                     [Char](1)      Collate Database_Default NULL,
 [CreatedBy]                  INT            NOT NULL,
 [CreatedDatetime]            DATETIME       NOT NULL, 
 [ModifiedBy]                 INT            NULL,
 [ModifiedDatetime]           DATETIME       NULL, 
 [Workstation]                VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__InternalCreditCard] PRIMARY KEY CLUSTERED ([InternalCreditCardId]),
 CONSTRAINT [FK__InternalCreditCard_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [Customer] ([CustomerId]),
 ) ON [PRIMARY]
Go

CREATE TABLE [dbo].[InternalCreditCardLine]
([InternalCreditCardId] BIGINT   NOT NULL,
 [Sequence]             INT      NOT NULL,
 [PromotionId]          BIGINT   NOT NULL, --promocion relacionada 
 [CreatedBy]			INT            NOT NULL,
 [CreatedDatetime]		DATETIME       NOT NULL, 
 [ModifiedBy]			INT            NULL,
 [ModifiedDatetime]		DATETIME       NULL, 
 [Workstation]			VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__InternalCreditCardLine] PRIMARY KEY CLUSTERED ([InternalCreditCardId], [Sequence]),
 CONSTRAINT [FK__InternalCreditCardLine_InternalCreditCard] FOREIGN KEY ([InternalCreditCardId]) REFERENCES [InternalCreditCard] ([InternalCreditCardId]),
 CONSTRAINT [FK__InternalCreditCardLine_PromotionTable] FOREIGN KEY ([PromotionId]) REFERENCES [PromotionTable] ([PromotionId]),
 ) ON [PRIMARY]
Go

CREATE TABLE [dbo].[EmissionPoint]
([EmissionPointId]      INT				NOT NULL,
 [LocationId]           SMALLINT		NOT NULL,
 [InventLocationId]     INT				NOT NULL,
 [Establishment]        [varchar](5)	Collate Database_Default NOT NULL,
 [Emission]				[varchar](5)	Collate Database_Default NOT NULL,
 [Name]                 VARCHAR(100)	Collate Database_Default NOT NULL,  /*Nombre*/ 
 [AddressIP]            VARCHAR(20)		Collate Database_Default NOT NULL,  /*Nombre*/ 
 [ScaleName]            VARCHAR(20)		Collate Database_Default NOT NULL,  /*Nombre*/ 
 [ScaleBrand]           VARCHAR(20)		Collate Database_Default NOT NULL,  /*Nombre*/ 
 [ScanBarcodeName]      VARCHAR(20)		Collate Database_Default NOT NULL,  /*Nombre*/ 
 [PrinterName]			VARCHAR(20)		Collate Database_Default NOT NULL,  /*Nombre*/ 
 [ThermalPrinter]		BIT				NOT NULL,
 [Status]               [Char](1)		Collate Database_Default NULL,
 [CreatedBy]            INT				NOT NULL,
 [CreatedDatetime]      DATETIME		NOT NULL, 
 [ModifiedBy]           INT				NULL,
 [ModifiedDatetime]     DATETIME		NULL, 
 [Workstation]          VARCHAR(20)		Collate Database_Default NOT NULL,
 CONSTRAINT [PK__EmissionPoint] PRIMARY KEY CLUSTERED ([EmissionPointId]),
 CONSTRAINT [FK__EmissionPoint_Location] FOREIGN KEY ([LocationId]) REFERENCES [Location] ([LocationId]),
 CONSTRAINT [FK__EmissionPoint_InventLocation] FOREIGN KEY ([InventLocationId]) REFERENCES [InventLocation] ([InventLocationId]),
 ) ON [PRIMARY]
Go

Create Unique Index Ind_EmissionPoint on EmissionPoint([LocationId], [Establishment], [Emission])
Go

INSERT INTO  [EmissionPoint]
SELECT * , 'A', 1, 0, NULL, NULL, 'SERVER'
 FROM (
   /*SAMBORONDON*/
         SELECT  1 [EmissionPointId], 1 [LocationId], 1 [InventLocationId], '002' [Establishment], '011' [Point], 
		 'CAJA 001 SAMBO' [Name], '192.168.18.21' [AddressIP], '' [ScaleName], 'METTLER_TOLEDO' [ScaleBrand], '' [ScanBarcodeName], 'EPSON TM' [PrinterName], 1 [ThermalPrinter]
   UNION SELECT  2, 1, 1, '002', '012', 'CAJA 002 SAMBO',					'192.168.18.22', '', 'METTLER_TOLEDO', '', 'EPSON TM'  , 1
   UNION SELECT  3, 1, 1, '002', '013', 'CAJA 003 SAMBO',					'192.168.18.23', 'USBScale', 'DATALOGIC', 'USBScanner', 'EPSON TM'  , 1
   UNION SELECT  4, 1, 1, '002', '014', 'CAJA 004 SAMBO',					'192.168.18.24', '', 'METTLER_TOLEDO', '', 'EPSON TM'  , 1
   UNION SELECT  5, 1, 1, '002', '015', 'CAJA 005 SAMBO',					'192.168.18.25', '', 'METTLER_TOLEDO', '', 'EPSON TM'  , 1
   UNION SELECT  6, 1, 1, '002', '016', 'CAJA 006 SAMBO DOMICILIO',			'192.168.18.26', '', 'METTLER_TOLEDO', '', 'EPSON TM'  , 1
   UNION SELECT  7, 1, 1, '002', '017', 'CAJA 007 SAMBO GOURMET',			'192.168.18.27', '',			'',				'',			'EPSON TM'  , 1
   /*LA JOYA*/
   UNION SELECT  8, 2, 11, '003', '001', 'CAJA 001 LA JOYA',				'192.168.19.21', 'USBScale', 'DATALOGIC', 'USBScanner', 'LR2000' , 1
   UNION SELECT  9, 2, 11, '003', '002', 'CAJA 002 LA JOYA',				'192.168.19.22', 'USBScale', 'DATALOGIC', 'USBScanner', 'LR2000' , 1
   UNION SELECT 10, 2, 11, '003', '003', 'CAJA 003 LA JOYA',				'192.168.19.23', 'USBScale', 'DATALOGIC', 'USBScanner', 'LR2000' , 1
   UNION SELECT 11, 2, 11, '003', '004', 'CAJA 004 LA JOYA',				'192.168.19.24', 'USBScale', 'DATALOGIC', 'USBScanner', 'LR2000' , 1
   UNION SELECT 12, 2, 11, '003', '005', 'CAJA 005 LA JOYA',				'192.168.19.25', 'USBScale', 'DATALOGIC', 'USBScanner', 'LR2000' , 1
   UNION SELECT 13, 2, 11, '003', '006', 'CAJA 006 LA JOYA',				'192.168.19.26', 'USBScale', 'DATALOGIC', 'USBScanner', 'LR2000' , 1
   UNION SELECT 14, 2, 11, '003', '007', 'CAJA 007 LA JOYA',				'192.168.19.27', 'USBScale', 'DATALOGIC', 'USBScanner', 'LR2000' , 1
   UNION SELECT 15, 3, 1,  '001', '010', 'CAJA TEST',                       '192.168.14.72', '', 'METTLER_TOLEDO', '', 'EPSON TM'  , 0
   /*DOMICILIO SAMBORONDON*/
   UNION SELECT  16, 1, 1, '002', '018', 'PC DOMICILIOS 3 SAMBO', '192.168.16.14', '', 'DATALOGIC', 'USBScanner', 'LR2000'  , 1
   UNION SELECT  17, 1, 1, '002', '019', 'PC DOMICILIOS 1 SAMBO', '192.168.16.13', '', 'DATALOGIC', 'USBScanner', 'LR2000'  , 1
   UNION SELECT  18, 1, 1, '002', '020', 'PC DOMICILIOS 2 SAMBO', '192.168.16.12', '', 'DATALOGIC', 'USBScanner', 'LR2000'  , 1
   UNION SELECT  19, 1, 1, '002', '021', 'PC DOMICILIOS 4 SAMBO', '192.168.16.15', '', 'DATALOGIC', 'USBScanner', 'LR2000'  , 1
   UNION SELECT  20, 1, 1, '002', '022', 'PC DOMICILIOS 5 SAMBO', '192.168.16.16', '', 'DATALOGIC', 'USBScanner', 'LR2000'  , 1

   /*ALBORADA*/
   UNION SELECT  21, 3, 21, '001', '001', 'CAJA 001 ALBORADA',					'192.168.16.21', '', 'METTLER_TOLEDO', '', 'EPSON TM'  , 0
   UNION SELECT  22, 3, 21, '001', '002', 'CAJA 002 ALBORADA',					'192.168.16.22', '', 'METTLER_TOLEDO', '', 'EPSON TM'  , 0
   UNION SELECT  23, 3, 21, '001', '003', 'CAJA 003 ALBORADA',					'192.168.16.23', '', 'METTLER_TOLEDO', '', 'EPSON TM'  , 0
   UNION SELECT  24, 3, 21, '001', '004', 'CAJA 004 ALBORADA',					'192.168.16.24', '', 'METTLER_TOLEDO', '', 'EPSON TM'  , 0
   UNION SELECT  25, 3, 21, '001', '005', 'CAJA 005 ALBORADA',					'192.168.16.25', 'USBScale', 'DATALOGIC', 'USBScanner', 'LR2000'  , 0
   UNION SELECT  26, 3, 21, '001', '006', 'CAJA 006 ALBORADA',					'192.168.16.26', '', 'METTLER_TOLEDO', '', 'EPSON TM'  , 0
   UNION SELECT  27, 3, 21, '001', '007', 'PC DOMICILIOS 001',					'192.168.16.12', '', 'METTLER_TOLEDO', '', 'EPSON TM'  , 1

   /*DOMICILIO LA JOYA*/
   UNION SELECT  28, 2, 11,'003', '009', 'PC DOMICILIOS 001 LA JOYA', '192.168.19.11', 'USBScale', 'DATALOGIC', 'USBScanner', 'LR2000'  , 1
   UNION SELECT  29, 2, 11,'003', '010', 'PC DOMICILIOS 002 LA JOYA', '192.168.19.12', 'USBScale', 'DATALOGIC', 'USBScanner', 'LR2000'  , 1

   /*AMERICAS*/
   UNION SELECT  30, 4, 31, '001', '001', 'CAJA 001 AMERICAS',					'192.168.15.21', '', 'METTLER_TOLEDO', '', 'EPSON TM'  , 0
   UNION SELECT  31, 4, 31, '001', '002', 'CAJA 002 AMERICAS',					'192.168.15.22', '', 'METTLER_TOLEDO', '', 'EPSON TM'  , 0
   UNION SELECT  32, 4, 31, '001', '003', 'CAJA 003 AMERICAS',					'192.168.15.23', '', 'METTLER_TOLEDO', '', 'EPSON TM'  , 0
   UNION SELECT  33, 4, 31, '001', '004', 'CAJA 004 AMERICAS',					'192.168.15.24', '', 'METTLER_TOLEDO', '', 'EPSON TM'  , 0
   UNION SELECT  34, 4, 31, '001', '005', 'CAJA 005 AMERICAS',					'192.168.15.26', 'USBScale', 'DATALOGIC', 'USBScanner', 'LR2000'  , 0
   )VIRT



CREATE TABLE [dbo].[SequenceType]
([SequenceTypeId]	Int				NOT NULL,
 [Name]				[varchar](50)	Collate Database_Default NULL,
 [Status]			[Char](1)		Collate Database_Default NULL,
 [CreatedBy]        INT				NOT NULL,
 [CreatedDatetime]  DATETIME		NOT NULL, 
 [ModifiedBy]       INT				NULL,
 [ModifiedDatetime] DATETIME		NULL, 
 [Workstation]      VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__SequenceType] PRIMARY KEY CLUSTERED ([SequenceTypeId]) ) ON [PRIMARY]
Go

INSERT INTO [SequenceType]
		SELECT 1 , 'Invoice', 'A', 1, 0, NULL, NULL, 'SERVER'
UNION	SELECT 2 , 'SalesOrder', 'A', 1, 0, NULL, NULL, 'SERVER'
UNION	SELECT 3 , 'RemissionGuide', 'A', 1, 0, NULL, NULL, 'SERVER'
GO

SELECT * FROM [SequenceType]

CREATE TABLE [dbo].[SequenceTable]
([LocationId]		SMALLINT		NOT NULL,
 [SequenceId]		INT				NOT NULL,
 [SequenceTypeId]	INT				NOT NULL,
 [EmissionPointId]  INT				NOT NULL,
 [Sequence]			INT				NOT NULL,
 [Name]             VARCHAR(100)	Collate Database_Default NOT NULL,  /*Nombre*/ 
 [Status]			[Char](1)		Collate Database_Default NULL,
 [CreatedBy]        INT				NOT NULL,
 [CreatedDatetime]  DATETIME		NOT NULL, 
 [ModifiedBy]       INT				NULL,
 [ModifiedDatetime] DATETIME		NULL, 
 [Workstation]      VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__SequenceTable] PRIMARY KEY CLUSTERED ([LocationId], [SequenceId]),
 CONSTRAINT [FK__SequenceTable_Location] FOREIGN KEY ([LocationId]) REFERENCES [Location] ([LocationId]),
 CONSTRAINT [FK__SequenceTable_SequenceType] FOREIGN KEY ([SequenceTypeId]) REFERENCES [SequenceType] ([SequenceTypeId]),
 ) ON [PRIMARY]

Create Unique Index Ind_SequenceTable on [SequenceTable]([LocationId], [SequenceTypeId], [EmissionPointId])
Go


--SELECT 1, ROW_NUMBER() OVER(ORDER BY SeqType), *, 'A'
--FROM (
--			SELECT 'AccountsReceivableId' SeqType, 0 EmissionPointId, 0 Sequence, 'SECUENCIAL PRINCIPAL DE LA TRANSACCION CUENTAS POR COBRAR' Name
--	UNION	SELECT 'InvoiceId', 0, 0, 'SECUENCIAL PRINCIPAL DE LA FACTURA'
--	UNION	SELECT 'SalesOrderId', 0, 0, 'SECUENCIAL PRINCIPAL DE LA ORDEN DE VENTA'
--	UNION	SELECT 'ClosingCashierPartial', 0, 0, 'SECUENCIAL PRINCIPAL DE CIERRE PARCIAL'
--	UNION	SELECT 'ClosingCashierFull', 0, 0, 'SECUENCIAL PRINCIPAL DE CIERRE FINAL') vIRT
--UNION ALL
--SELECT 2, ROW_NUMBER() OVER(ORDER BY SeqType), *, 'A'
--FROM (
--			SELECT 'AccountsReceivableId' SeqType, 0 EmissionPointId, 0 Sequence, 'SECUENCIAL PRINCIPAL DE LA TRANSACCION CUENTAS POR COBRAR' Name
--	UNION	SELECT 'InvoiceId', 0, 0, 'SECUENCIAL PRINCIPAL DE LA FACTURA'
--	UNION	SELECT 'SalesOrderId', 0, 0, 'SECUENCIAL PRINCIPAL DE LA ORDEN DE VENTA'
--	UNION	SELECT 'ClosingCashierPartial', 0, 0, 'SECUENCIAL PRINCIPAL DE CIERRE PARCIAL'
--	UNION	SELECT 'ClosingCashierFull', 0, 0, 'SECUENCIAL PRINCIPAL DE CIERRE FINAL') vIRT

INSERT INTO  [SequenceTable]
SELECT 
	LocationId, ROW_NUMBER() OVER (PARTITION BY LocationId ORDER BY SequenceTypeId, EmissionPointId), SequenceTypeId, EmissionPointId, Sequence, Name, Status , 1, 0, NULL, NULL, 'SERVER'
FROM (
	SELECT	LocationId, 1 SequenceTypeId, EmissionPointId, 1 Sequence, 'SECUENCIA FACTURA ' + NAME Name, 'A' Status
	FROM	EmissionPoint 
	union all
	SELECT	LocationId, 2 SequenceTypeId, EmissionPointId, 1 Sequence, 'SECUENCIA ORDEN ' + NAME Name, 'A' Status
	FROM	EmissionPoint
	union all
	SELECT	LocationId, 3 SequenceTypeId, EmissionPointId, 1 Sequence, 'SECUENCIA GUIA ' + NAME Name, 'A' Status
	FROM	EmissionPoint
	) VIRT

SELECT * FROM [SequenceTable]

/*----------------------------------------*/
CREATE TABLE [dbo].[CurrencyType]
([CurrencyTypeId]	INT				NOT NULL,
 [Name]				VARCHAR(100)	Collate Database_Default NOT NULL,  /*Nombre*/ 
 [Active]			BIT				NOT NULL,
 [Status]			[Char](1)		Collate Database_Default NULL,
 [CreatedBy]        INT				NOT NULL,
 [CreatedDatetime]  DATETIME		NOT NULL, 
 [ModifiedBy]       INT				NULL,
 [ModifiedDatetime] DATETIME		NULL, 
 [Workstation]      VARCHAR(20)		Collate Database_Default NOT NULL,
 CONSTRAINT [PK__CurrencyType] PRIMARY KEY CLUSTERED ([CurrencyTypeId]),
 ) ON [PRIMARY]
Go

INSERT INTO [CurrencyType]
SELECT 1, 'DOLAR', 1, 'A', 1, 0, NULL, NULL, 'SERVER'

SELECT * FROM [CurrencyType]

CREATE TABLE [dbo].[DenominationType]
([DenominationTypeId]	INT				NOT NULL,
 [Name]					VARCHAR(100)	Collate Database_Default NOT NULL,  /*Nombre*/ 
 [Status]				[Char](1)		Collate Database_Default NULL,
 [CreatedBy]			INT				NOT NULL,
 [CreatedDatetime]		DATETIME		NOT NULL, 
 [ModifiedBy]			INT				NULL,
 [ModifiedDatetime]		DATETIME		NULL, 
 [Workstation]			VARCHAR(20)		Collate Database_Default NOT NULL,
 CONSTRAINT [PK__DenominationType] PRIMARY KEY CLUSTERED ([DenominationTypeId]),
 ) ON [PRIMARY]
Go


INSERT INTO [DenominationType]
		SELECT 1, 'BILLETE', 'A', 1, 0, NULL, NULL, 'SERVER'
UNION	SELECT 2, 'MONEDA', 'A', 1, 0, NULL, NULL, 'SERVER'

SELECT * FROM [DenominationType]

CREATE TABLE [dbo].[CurrencyDenomination]
([CurrencyDenominationId]	INT				NOT NULL,
 [CurrencyTypeId]			INT				NOT NULL,
 [DenominationTypeId]		INT				NOT NULL,
 [Value]					NUMERIC(18,2)	NOT NULL, 
 [Status]					[Char](1)		Collate Database_Default NULL,
 [CreatedBy]				INT				NOT NULL,
 [CreatedDatetime]			DATETIME		NOT NULL, 
 [ModifiedBy]				INT				NULL,
 [ModifiedDatetime]			DATETIME		NULL, 
 [Workstation]				VARCHAR(20)		Collate Database_Default NOT NULL,
 CONSTRAINT [PK__CurrencyDenomination] PRIMARY KEY CLUSTERED ([CurrencyDenominationId]),
 CONSTRAINT [FK__CurrencyDenomination_CurrencyType] FOREIGN KEY ([CurrencyTypeId])  REFERENCES [CurrencyType] ([CurrencyTypeId]),
 CONSTRAINT [FK__CurrencyDenomination_DenominationType] FOREIGN KEY ([DenominationTypeId])  REFERENCES [DenominationType] ([DenominationTypeId]),
 ) ON [PRIMARY]
Go

INSERT INTO [CurrencyDenomination]
SELECT	* , 'A', 1, 0, NULL, NULL, 'SERVER'
FROM	(SELECT	1 [CurrencyDenominationId] , 1 [CurrencyTypeId], 1 [DenominationTypeId],   100 [Value]
UNION	SELECT	2, 1, 1,	50
UNION	SELECT	3, 1, 1,	20
UNION	SELECT	4, 1, 1,	10
UNION	SELECT	5, 1, 1,	 5
UNION	SELECT	6, 1, 1,	 2
UNION	SELECT	7, 1, 1,	 1
UNION	SELECT	8, 1, 2,	 1
UNION	SELECT	9, 1, 2,   0.5
UNION	SELECT 10, 1, 2,  0.25
UNION	SELECT 11, 1, 2,  0.10
UNION	SELECT 12, 1, 2,  0.05
UNION	SELECT 13, 1, 2,  0.01) VIRT

SELECT * FROM [CurrencyDenomination]
/*--------------------Cabecera Cuadre Cajero--------------------*/
CREATE TABLE [dbo].[ClosingCashierTable]
([ClosingCashierId]			BIGINT         NOT NULL,
 [ClosingCashierIdLocal]	BIGINT         IDENTITY NOT NULL,
 [LocationId]				SMALLINT       NOT NULL,
 [EmissionPointId]			INT            NOT NULL,
 [UserId]					INT            NOT NULL,
 [ClosingCashierDate]		DATETIME       NOT NULL, /*Fecha Emision*/
 [Type]						[Char](1)      Collate Database_Default NULL,
 [ClosingCashierIdParent]	BIGINT         NOT NULL,
 [OpeningAmount]			NUMERIC(18, 2) NOT NULL, /*Valor apertura*/
 [Authorization]			VARCHAR(40)    Collate Database_Default NOT NULL,  /*Autorizacion*/
 [Status]					[Char](1)      Collate Database_Default NULL,
 [CreatedBy]				INT            NOT NULL,
 [CreatedDatetime]			DATETIME       NOT NULL, 
 [ModifiedBy]				INT            NULL,
 [ModifiedDatetime]			DATETIME       NULL, 
 [Workstation]				VARCHAR(20) Collate Database_Default NOT NULL,
 [ReasonId]					INT             NULL,
 CONSTRAINT [PK__ClosingCashierTable] PRIMARY KEY CLUSTERED ([ClosingCashierId]),
 CONSTRAINT [PK__ClosingCashierTable_EmissionPoint] FOREIGN KEY ([EmissionPointId]) REFERENCES [EmissionPoint] ([EmissionPointId]),
 CONSTRAINT [FK__ClosingCashierTable_Location] FOREIGN KEY ([LocationId])  REFERENCES [Location] ([LocationId]),
 ) ON [PRIMARY]
Go


CREATE NONCLUSTERED INDEX [Ind_ClosingCashierTable_1]
    ON [dbo].[ClosingCashierTable]([LocationId] ASC, [EmissionPointId] ASC, [UserId] ASC, [Type] ASC, [ClosingCashierIdParent] ASC, [Status] ASC, [ClosingCashierDate] ASC);
GO

CREATE NONCLUSTERED INDEX [Ind_ClosingCashierTable_2]
    ON [dbo].[ClosingCashierTable]([LocationId] ASC, [EmissionPointId] ASC, [UserId] ASC, [Type] ASC, [Status] ASC)
    INCLUDE([ClosingCashierDate], [CreatedDatetime]);
GO

CREATE NONCLUSTERED INDEX [Ind_ClosingCashierTable_3]
    ON [dbo].[ClosingCashierTable]([ClosingCashierIdParent] ASC, [Status] ASC);
GO

CREATE NONCLUSTERED INDEX [Ind_ClosingCashierTable_4]
    ON [dbo].[ClosingCashierTable]([Type] ASC, [ClosingCashierIdParent] ASC, [Status] ASC);
GO

CREATE NONCLUSTERED INDEX [Ind_ClosingCashierTable_5]
    ON [dbo].[ClosingCashierTable]([ClosingCashierIdLocal] ASC);
GO

CREATE NONCLUSTERED INDEX [Ind_ClosingCashierTable_6]
    ON [dbo].[ClosingCashierTable]([ClosingCashierDate] ASC)
    INCLUDE([EmissionPointId], [UserId]);
GO

/*--------------------Detalle Cuadre Cajero--------------------*/
CREATE TABLE [dbo].[ClosingCashierLine]
([ClosingCashierId]		BIGINT         NOT NULL,
 [Sequence]				INT            NOT NULL,
 [PaymModeId]			INT            NOT NULL,
 [CashierAmount]		NUMERIC(18, 2) NOT NULL, /*Valor Cuadre por Caja*/
 [SystemAmount]			NUMERIC(18, 2) NOT NULL, /*Valor Cuadre por Sistema*/
 [Status]				[Char](1)      Collate Database_Default NULL,
 [CreatedBy]			INT            NOT NULL,
 [CreatedDatetime]		DATETIME       NOT NULL, 
 [ModifiedBy]			INT            NULL,
 [ModifiedDatetime]		DATETIME       NULL, 
 [Workstation]			VARCHAR(20) Collate Database_Default NOT NULL,
 CONSTRAINT [PK__ClosingCashierLine] PRIMARY KEY CLUSTERED ([ClosingCashierId], [Sequence]),
 CONSTRAINT [FK__ClosingCashierLine_ClosingCashierTable] FOREIGN KEY ([ClosingCashierId]) REFERENCES [ClosingCashierTable] ([ClosingCashierId]),
 CONSTRAINT [FK__ClosingCashierLine_PaymMode] FOREIGN KEY ([PaymModeId]) REFERENCES [PaymMode] ([PaymModeId])
 ) ON [PRIMARY]
Go

/*--------------------Detalle Cuadre Dinero--------------------*/
CREATE TABLE [dbo].[ClosingCashierMoney]
([ClosingCashierId]			BIGINT  NOT NULL,
 [Sequence]					INT     NOT NULL,
 [CurrencyDenominationId]	INT		NOT NULL,
 [Quantity]					NUMERIC(18, 2) NOT NULL, /**/
 [Status]					[Char](1)      Collate Database_Default NULL,
 [CreatedBy]				INT            NOT NULL,
 [CreatedDatetime]			DATETIME       NOT NULL, 
 [ModifiedBy]				INT            NULL,
 [ModifiedDatetime]			DATETIME       NULL, 
 [Workstation]				VARCHAR(20) Collate Database_Default NOT NULL,
 CONSTRAINT [PK__ClosingCashierMoney] PRIMARY KEY CLUSTERED ([ClosingCashierId], [Sequence]),
 CONSTRAINT [FK__ClosingCashierMoney_CurrencyDenomination] FOREIGN KEY ([CurrencyDenominationId]) REFERENCES [CurrencyDenomination] ([CurrencyDenominationId]),
 ) ON [PRIMARY]
Go


CREATE TABLE [dbo].[SalesOrigin](
 [SalesOriginId]	INT				NOT NULL,
 [Name]				VARCHAR(100)	Collate Database_Default NOT NULL,  /*Nombre*/ 
 [SalesmanId]		INT				NOT NULL, /*Id del vendedor*/
 [IsECommerce]		[BIT]			NOT NULL, /*si es de Venta*/
 [AllowCredit]		[BIT]			NOT NULL,
 [Status]			[Char](1)		Collate Database_Default NULL,
 [CreatedBy]		INT				NOT NULL,
 [CreatedDatetime]	DATETIME		NOT NULL, 
 [ModifiedBy]		INT				NULL,
 [ModifiedDatetime]	DATETIME		NULL, 
 [Workstation]		VARCHAR(20)		Collate Database_Default NOT NULL,
 CONSTRAINT [PK__SalesOrigin] PRIMARY KEY CLUSTERED ([SalesOriginId]),
 CONSTRAINT [FK__SalesOrigin_Salesman] FOREIGN KEY ([SalesmanId]) REFERENCES [Salesman] ([SalesmanId]),
 ) ON [PRIMARY]
Go

INSERT INTO [SalesOrigin]
SELECT *, 'A', 1, 0, NULL, NULL, 'SERVER'
FROM (	SELECT  1 ID, 'SUPERMERCADOS' Name, 1 SalesmanId, 0 [IsECommerce], 0 [AllowCredit]
UNION	SELECT  2, 'DOMICILIO',2, 0, 0
UNION	SELECT  3, 'EMPLEADOS',3, 0, 0
UNION	SELECT  4, 'PEDIDOS YA',4, 0, 1
UNION	SELECT  5, 'RAPPI',5, 0, 0
UNION	SELECT  6, 'PAGINA WEB',6, 1, 0
UNION	SELECT  7, 'APLICACI N MOBIL',6, 1, 0
UNION	SELECT  8, 'WHATSAPP',2, 0, 0
UNION	SELECT  9, 'LLAMADA CELULAR',2, 0, 0
UNION	SELECT 10, 'LLAMADA CONVENCIONAL',2, 0, 0) VIRT

SELECT * FROM [SalesOrigin]

CREATE TABLE [dbo].[TransferStatus]
([TransferStatusId]		INT            NOT NULL,
 [Name]					[varchar](50)  Collate Database_Default NULL,
 [Status]				[Char](1)      Collate Database_Default NULL,
 [CreatedBy]			INT            NOT NULL,
 [CreatedDatetime]		DATETIME       NOT NULL, 
 [ModifiedBy]			INT            NULL,
 [ModifiedDatetime]		DATETIME       NULL, 
 [Workstation]			VARCHAR(20) Collate Database_Default NOT NULL,
 CONSTRAINT [PK__TransferStatus] PRIMARY KEY CLUSTERED ([TransferStatusId] )) ON [PRIMARY]
Go

INSERT INTO TransferStatus
SELECT *, 'A', 1, 0, NULL, NULL, 'SERVER'
FROM (	SELECT 1 [TransferStatusId], 'PENDIENTE DE MIGRACI N' [Name]
UNION	SELECT 2, 'MIGRADO A ERP'
UNION	SELECT 3, 'PENDIENTE DE ACTUALIZACI N'
UNION	SELECT 4, 'PENDIENTE DE ACTUALIZACI N FORMA DE PAGO'
UNION	SELECT 5, 'ACTUALIZADO EN ERP') VIRT
GO

SELECT * FROM [TransferStatus]

CREATE TABLE [dbo].[SalesOrderStatus]
([SalesOrderStatusId]	INT           NOT NULL,
 [ShortCode]			CHAR (1)      NOT NULL,
 [Name]					VARCHAR (200) NOT NULL,
 [Observation]			VARCHAR (200) NOT NULL,
 [PreviousStatus]		VARCHAR (200) NULL,
 [Status]				CHAR (1)      DEFAULT ('A') NULL,
 [CreatedBy]			INT            NOT NULL,
 [CreatedDatetime]		DATETIME       NOT NULL, 
 [ModifiedBy]			INT            NULL,
 [ModifiedDatetime]		DATETIME       NULL, 
 [Workstation]			VARCHAR(20) Collate Database_Default NOT NULL,
 CONSTRAINT [PK__SalesOrderStatus] PRIMARY KEY CLUSTERED ([SalesOrderStatusId]),
 ) ON [PRIMARY]
GO

INSERT	INTO SalesOrderStatus
SELECT	*, 'A', 1, 0, NULL, NULL, 'SERVER'
FROM	(SELECT 1 [SalesOrderStatusId], 'O' [ShortCode],'ORDEN ABIERTA' [Name],	'SAC COGE PEDIDO Y CREA CABECERA' [Observation], NULL [PreviousStatus]
UNION	SELECT 2, 'P','ORDEN ECOMMERCE',	'PEDIDO DE LA WEB O APP', NULL
UNION	SELECT 3, 'A','ORDEN PICKING',		'PICKING - DESPACHADOR SE ENCUENTRA EN TIENDA REALIZANDO LA TOMA DE PRODUCTOS', NULL
UNION	SELECT 4, 'E','ORDEN PACKING',		'PACKING - SELECCION DE PRODUCTOS FINALIZADA Y PASADOS POR CAJA, EN PROCESO DE EMPAQUETADO, LISTO PARA SER INSERTADO EN GUIA', NULL
UNION	SELECT 5, 'S','ORDEN SHIPPING',		'PEDIDO COMPLETADO Y LISTO PARA RUTA', NULL
UNION	SELECT 6, 'D','ORDEN DELIVERING',	'DELIVERING - PEDIDO SALIO DE TIENDA Y VA EN RUTA', NULL
UNION	SELECT 7, 'F','ORDEN FACTURADA',	'PEDIDO FUE ENTREGADO AL CLIENTE Y SE FACTURO', NULL
UNION	SELECT 8, 'I','ORDEN CANCELADA',	'PEDIDO CANCELADO POR CLIENTE', NULL) VIRT
GO

SELECT * FROM [SalesOrderStatus]

/*--------------------Cabecera PUNTO DE VENTA--------------------*/
CREATE TABLE [dbo].[SalesOrder]
([SalesOrderId]			BIGINT			NOT NULL,
 [SalesOrderIdLocal]	BIGINT			IDENTITY NOT NULL,
 [LocationId]			SMALLINT		NOT NULL,
 --[EmissionPointId]		INT				NOT NULL,
 --[Establishment]		[varchar](5)	Collate Database_Default NOT NULL,
 --[Emission]				[varchar](5)	Collate Database_Default NOT NULL,
 [CustomerId]			BIGINT			NOT NULL, /*Id del cliente*/
 [SalesmanId]			INT				NOT NULL, /*Id del vendedor*/
 [OrderDate]			DATETIME		NOT NULL, /*Fecha Emision*/
 [SalesOriginId]		INT				NOT NULL, /**/
 [OrderECommerce]		BIGINT			NOT NULL, 
 [DeliveryAddress]		VARCHAR(200)	Collate Database_Default NOT NULL,
 [DeliveryDate]			DATETIME		NOT NULL, /*Fecha Emision*/
 [Recipient]			VARCHAR(200)	Collate Database_Default NOT NULL,
 [BaseAmount]			NUMERIC(18, 4)	NOT NULL, /*BaseAmount Base Cero*/
 [BaseTaxAmount]		NUMERIC(18, 4)	NOT NULL, /*BaseAmount Base IVA*/
 [Discount]				NUMERIC(18, 4)	NOT NULL, /*Valor Descuento*/
 [TaxPercent]			NUMERIC( 5, 2)	NOT NULL, /*% IVA*/ 
 [TaxAmount]			NUMERIC(18, 4)	NOT NULL, /*Valor IVA*/ 
 [IrbpAmount]			NUMERIC(18, 4)	NOT NULL, /*Valor IRBP*/
 [Total]				NUMERIC(18, 4)	NOT NULL, /*Total a pagar*/
 [ShippingFree]			BIT				NOT NULL, /**/ 
 [ShippingAmount]		NUMERIC(18, 2)	NOT NULL, 
 --[InvoiceId]			BIGINT			NOT NULL,
 [Observation]			VARCHAR(250)	Collate Database_Default NOT NULL, 
 [CustomerAddressId]	BIGINT          NULL,
 [OrderXml]				VARCHAR (MAX)   NULL,
 [Status]				[Char](1)		Collate Database_Default NULL,
 [CreatedBy]			INT				NOT NULL,
 [CreatedDatetime]		DATETIME		NOT NULL, 
 [ModifiedBy]			INT				NULL,
 [ModifiedDatetime]		DATETIME		NULL, 
 [Workstation]			VARCHAR(20)		Collate Database_Default NOT NULL,
 CONSTRAINT [PK__SalesOrder] PRIMARY KEY CLUSTERED ([SalesOrderId]),
 CONSTRAINT [FK__SalesOrder_Location] FOREIGN KEY ([LocationId]) REFERENCES [Location] ([LocationId]),
 CONSTRAINT [FK__SalesOrder_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [Customer] ([CustomerId]),
 CONSTRAINT [FK__SalesOrder_Salesman] FOREIGN KEY ([SalesmanId]) REFERENCES [Salesman] ([SalesmanId]),
 --CONSTRAINT [FK__SalesOrder_EmissionPoint] FOREIGN KEY ([EmissionPointId]) REFERENCES [EmissionPoint] ([EmissionPointId]),
 CONSTRAINT [FK__SalesOrder_SalesOrigin] FOREIGN KEY ([SalesOriginId]) REFERENCES [SalesOrigin] ([SalesOriginId]),

 ) ON [PRIMARY]
Go

CREATE NONCLUSTERED INDEX [Ind_SalesOrder_1]
    ON [dbo].[SalesOrder]([CustomerId] ASC);
GO

CREATE NONCLUSTERED INDEX [Ind_SalesOrder_2]
    ON [dbo].[SalesOrder]([LocationId] ASC)
    INCLUDE([CustomerId], [OrderDate], [SalesOriginId], [OrderECommerce], [Status]);
GO

CREATE NONCLUSTERED INDEX [Ind_SalesOrder_3]
    ON [dbo].[SalesOrder]([LocationId] ASC, [Status] ASC)
    INCLUDE([CustomerId], [OrderDate], [SalesOriginId], [OrderECommerce]);
GO

CREATE NONCLUSTERED INDEX [Ind_SalesOrder_4]
    ON [dbo].[SalesOrder]([OrderDate] ASC, [Observation] ASC)
    INCLUDE([LocationId], [CustomerId], [DeliveryAddress], [CustomerAddressId]);
GO

CREATE NONCLUSTERED INDEX [Ind_SalesOrder_5]
    ON [dbo].[SalesOrder]([OrderECommerce] ASC);
GO

CREATE NONCLUSTERED INDEX [Ind_SalesOrder_6]
    ON [dbo].[SalesOrder]([SalesOrderIdLocal] ASC);
GO

CREATE NONCLUSTERED INDEX [Ind_SalesOrder_7]
    ON [dbo].[SalesOrder]([Status] ASC)
    INCLUDE([CustomerId], [OrderDate], [SalesOriginId], [CustomerAddressId]);
GO

/*--------------------Detalle PEDIDO--------------------*/
CREATE TABLE [dbo].[SalesOrderLine](
 [SalesOrderId]				BIGINT         NOT NULL,
 [Sequence]					INT            NOT NULL,
 [ProductId]				BIGINT         NOT NULL,
 [Barcode]					[varchar](20)  Collate Database_Default NOT NULL,
 [InventUnitId]				Int            NOT NULL,
 [UseTax]					[BIT]          NOT NULL, /*Graba IVA*/ 
 [TaxProductAmount]			NUMERIC(18, 4) NOT NULL, /*Precio*/ 
 [DiscountProductAmount]	NUMERIC(18, 4) NOT NULL, /*Precio*/ 
 [Quantity]					NUMERIC(18, 6) NOT NULL, /*Cantidad*/
 [QuantityCW]				INT            NOT NULL, /*Unidades*/
 [Returned]					INT            NOT NULL, /*Devolucion*/
 [Cost]						NUMERIC(18, 4) NOT NULL, /*Precio*/
 [Price]					NUMERIC(18, 4) NOT NULL, /*Precio*/
 [BaseAmount]				NUMERIC(18, 4) NOT NULL, /*BaseAmount Base Cero*/
 [BaseTaxAmount]			NUMERIC(18, 4) NOT NULL, /*BaseAmount Base IVA*/ 
 [LinePercent]				NUMERIC( 5, 2) NOT NULL, /*% Descuento*/
 [LineDiscount]				NUMERIC(18, 4) NOT NULL, /*Valor Descuento Base Cero*/
 [TaxPercent]				NUMERIC( 5, 2) NOT NULL, /*% IVA*/ 
 [TaxAmount]				NUMERIC(18, 4) NOT NULL, /*Valor IVA*/ 
 [IrbpAmount]				NUMERIC(18, 4) NOT NULL, /*Valor IRBP*/
 [LineAmount]				NUMERIC(18, 4) NOT NULL, /*Total a pagar*/
 [PromotionId]				BIGINT   NOT NULL,
 [Status]				[Char](1)		Collate Database_Default NULL,
 [CreatedBy]			INT				NOT NULL,
 [CreatedDatetime]		DATETIME		NOT NULL, 
 [ModifiedBy]			INT				NULL,
 [ModifiedDatetime]		DATETIME		NULL, 
 [Workstation]			VARCHAR(20)		Collate Database_Default NOT NULL,
 CONSTRAINT [PK__SalesOrderLine] PRIMARY KEY CLUSTERED ([SalesOrderId], [Sequence]),
 CONSTRAINT [FK__SalesOrderLine_SalesOrder] FOREIGN KEY ([SalesOrderId]) REFERENCES [SalesOrder] ([SalesOrderId]),
 CONSTRAINT [FK__SalesOrderLine_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([ProductId]),
 CONSTRAINT [FK__SalesOrderLine_InventUnit] FOREIGN KEY ([InventUnitId]) REFERENCES [InventUnit] ([InventUnitId]),
 ) ON [PRIMARY]
Go

/*--------------------Detalle ORDEN Formas de Pago Venta--------------------*/
CREATE TABLE [dbo].[SalesOrderPayment]
([SalesOrderId]			BIGINT         NOT NULL,
 [Sequence]				INT            NOT NULL,
 [PaymModeId]			INT            NOT NULL,
 [Amount]				NUMERIC(18, 2) NOT NULL, /*Valor*/
 [BankId]               INT             DEFAULT ('') NOT NULL,
 [CreditCardId]         INT             DEFAULT ('') NOT NULL,
 [LocationId]           SMALLINT        NOT NULL,
 [Received]             NUMERIC (18, 2) NOT NULL,
 [Change]               NUMERIC (18, 2) NOT NULL,
 [PaymentDate]          DATETIME        NOT NULL,
 [AccountNumber]        VARCHAR (20)    NOT NULL,
 [CkeckNumber]          INT             NOT NULL,
 [CkeckType]            VARCHAR (2)     NOT NULL,
 [CkeckDate]            DATETIME        NOT NULL,
 [CheckOwner]           VARCHAR (100)   NOT NULL,
 [Authorization]        VARCHAR (40)    NOT NULL,
 [IsProtest]            BIT             NOT NULL,
 [ProtestDate]          DATETIME        NOT NULL,
 [InternalCreditCardId] BIGINT          NOT NULL,
 [GiftCardNumber]       VARCHAR (20)    NOT NULL,
 [RetentionCode]        INT             NOT NULL,
 [RetentionNumber]      VARCHAR (15)    NOT NULL,
 [Status]				[Char](1)		Collate Database_Default NULL,
 [CreatedBy]			INT				NOT NULL,
 [CreatedDatetime]		DATETIME		NOT NULL, 
 [ModifiedBy]			INT				NULL,
 [ModifiedDatetime]		DATETIME		NULL, 
 [Workstation]			VARCHAR(20)		Collate Database_Default NOT NULL,
 CONSTRAINT [PK__SalesOrderPayment] PRIMARY KEY CLUSTERED ([SalesOrderId], [Sequence]),
 CONSTRAINT [FK__SalesOrderPayment_SalesOrder] FOREIGN KEY ([SalesOrderId]) REFERENCES [SalesOrder] ([SalesOrderId]),
 CONSTRAINT [FK__SalesOrderPayment_PaymMode] FOREIGN KEY ([PaymModeId]) REFERENCES [PaymMode] ([PaymModeId])
 ) ON [PRIMARY]
Go

CREATE TABLE [dbo].[SalesOrderText](
 [SalesOrderId]			BIGINT         NOT NULL,
 [Sequence]				INT            NOT NULL,
 [SalesOrderText]		VARCHAR(MAX)  Collate Database_Default NULL,
 [Status]				[Char](1)		Collate Database_Default NULL,
 [CreatedBy]			INT				NOT NULL,
 [CreatedDatetime]		DATETIME		NOT NULL, 
 [ModifiedBy]			INT				NULL,
 [ModifiedDatetime]		DATETIME		NULL, 
 [Workstation]			VARCHAR(20)		Collate Database_Default NOT NULL,
 CONSTRAINT [PK__SalesOrderText] PRIMARY KEY CLUSTERED ([SalesOrderId], [Sequence]),
 CONSTRAINT [FK__SalesOrderText_FACTrPedidoCab] FOREIGN KEY ([SalesOrderId]) REFERENCES [SalesOrder] ([SalesOrderId])) ON [PRIMARY]
Go

/*--------------------Cabecera PUNTO DE VENTA--------------------*/
CREATE TABLE [dbo].[InvoiceTable](
 [InvoiceId]			BIGINT			NOT NULL,
 [InvoiceIdLocal]		BIGINT			IDENTITY NOT NULL,
 [LocationId]			SMALLINT		NOT NULL,
 [TypeDoc]				SMALLINT		NOT NULL, /*1=Factura, 4=NC*/
 [InvoiceIdReference]	BIGINT			NOT NULL,
 [EmissionPointId]		INT				NOT NULL,
 [Establishment]		[varchar](5)	Collate Database_Default NOT NULL,
 [Emission]				[varchar](5)	Collate Database_Default NOT NULL,
 [InvoiceNumber]		BIGINT			NOT NULL,
 [CustomerId]			BIGINT			NOT NULL, /*Id del cliente*/
 [SalesmanId]			INT				NOT NULL, /*Id del vendedor*/
 [IsCredit]				[BIT]			NOT NULL, /*Graba IVA*/ 
 [InvoiceDate]			DATETIME		NOT NULL, /*Fecha Emision*/
 [Expiration]			DATETIME		NOT NULL, /*Fecha Caducidad*/ 
 [BaseAmount]			NUMERIC(18, 4)	NOT NULL, /*BaseAmount Base Cero*/
 [BaseTaxAmount]		NUMERIC(18, 4)	NOT NULL, /*BaseAmount Base IVA*/
 [Discount]				NUMERIC(18, 4)	NOT NULL, /*Valor Descuento*/
 [TaxPercent]			NUMERIC( 5, 2)	NOT NULL, /*% IVA*/ 
 [TaxAmount]			NUMERIC(18, 4)	NOT NULL, /*Valor IVA*/ 
 [IrbpAmount]			NUMERIC(18, 4)	NOT NULL, /*Valor IRBP*/
 [Total]				NUMERIC(18, 4)	NOT NULL, /*Total a pagar*/
 [ShippingFree]			BIT				NOT NULL, /**/ 
 [ShippingAmount]		NUMERIC(18, 2)	NOT NULL, 
 [Returned]				NUMERIC(18, 2)	NOT NULL, /*Valor Devolucion*/
 [SalesOriginId]		INT				NOT NULL, /**/
 [IsECommerce]			BIT				NOT NULL, /*si es de Venta*/
 [SalesOrderId]			BIGINT			NOT NULL, /*Id Pedido*/
 [ClosingCashierId]		BIGINT			NOT NULL, /*ID CUADRE DE CAJA*/
 [Observation]			VARCHAR(250)	Collate Database_Default NOT NULL,
 [KeyAccessSri]         VARCHAR(50)		Collate Database_Default NOT NULL,  /*ClaveAcceso*/
 [TransferStatusId]		INT				NOT NULL,
 [Status]				[Char](1)		Collate Database_Default NULL,
 [CreatedBy]			INT				NOT NULL,
 [CreatedDatetime]		DATETIME		NOT NULL, 
 [ModifiedBy]			INT				NULL,
 [ModifiedDatetime]		DATETIME		NULL, 
 [Workstation]			VARCHAR(20)		Collate Database_Default NOT NULL,
 CONSTRAINT [PK__InvoiceTable] PRIMARY KEY CLUSTERED ([InvoiceId]),
 CONSTRAINT [FK__InvoiceTable_Location] FOREIGN KEY ([LocationId]) REFERENCES [Location] ([LocationId]),
 CONSTRAINT [FK__InvoiceTable_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [Customer] ([CustomerId]),
 CONSTRAINT [FK__InvoiceTable_Salesman] FOREIGN KEY ([SalesmanId]) REFERENCES [Salesman] ([SalesmanId]),
 CONSTRAINT [FK__InvoiceTable_EmissionPoint] FOREIGN KEY ([EmissionPointId]) REFERENCES [EmissionPoint] ([EmissionPointId]),
 CONSTRAINT [FK__InvoiceTable_SalesOrigin] FOREIGN KEY ([SalesOriginId]) REFERENCES [SalesOrigin] ([SalesOriginId]),
 CONSTRAINT [FK__InvoiceTable_TransferStatus] FOREIGN KEY ([TransferStatusId]) REFERENCES [TransferStatus] ([TransferStatusId]),
 
 ) ON [PRIMARY]
Go

CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_1]
    ON [dbo].[InvoiceTable]([InvoiceIdLocal] ASC);
GO

CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_2]
    ON [dbo].[InvoiceTable]([ClosingCashierId] ASC, [Status] ASC)
    INCLUDE([LocationId], [EmissionPointId], [InvoiceDate], [CreatedBy]);
GO

CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_3]
    ON [dbo].[InvoiceTable]([CreatedBy] ASC, [InvoiceDate] ASC)
    INCLUDE([InvoiceNumber]);
GO

CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_4]
    ON [dbo].[InvoiceTable]([CreatedBy] ASC, [InvoiceDate] ASC)
    INCLUDE([Total]);
GO

CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_5]
    ON [dbo].[InvoiceTable]([CustomerId] ASC);
GO

CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_6]
    ON [dbo].[InvoiceTable]([Emission] ASC)
    INCLUDE([Establishment], [InvoiceNumber]);
GO

CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_7]
    ON [dbo].[InvoiceTable]([Emission] ASC)
    INCLUDE([Establishment], [InvoiceNumber], [InvoiceDate]);
GO

CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_8]
    ON [dbo].[InvoiceTable]([Emission] ASC)
    INCLUDE([InvoiceDate]);
GO

CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_9]
    ON [dbo].[InvoiceTable]([Emission] ASC, [InvoiceDate] ASC)
    INCLUDE([Establishment], [InvoiceNumber]);
GO
CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_10]
    ON [dbo].[InvoiceTable]([Emission] ASC, [InvoiceDate] ASC)
    INCLUDE([InvoiceIdLocal], [LocationId], [TypeDoc], [InvoiceIdReference], [EmissionPointId], [Establishment], [InvoiceNumber], [CustomerId], [SalesmanId], [IsCredit], [Expiration], [BaseAmount], [BaseTaxAmount], [Discount], [TaxPercent], [TaxAmount], [IrbpAmount], [Total], [ShippingFree], [ShippingAmount], [Returned], [SalesOriginId], [IsECommerce], [SalesOrderId], [ClosingCashierId], [Observation], [KeyAccessSri], [TransferStatusId], [Status], [CreatedBy], [CreatedDatetime], [ModifiedBy], [ModifiedDatetime], [Workstation]);
GO

CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_11]
    ON [dbo].[InvoiceTable]([Emission] ASC, [InvoiceDate] ASC)
    INCLUDE([InvoiceNumber]);
GO

CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_12]
    ON [dbo].[InvoiceTable]([Emission] ASC, [InvoiceNumber] ASC, [InvoiceDate] ASC);
GO

CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_13]
    ON [dbo].[InvoiceTable]([EmissionPointId] ASC)
    INCLUDE([InvoiceNumber]);
GO

CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_14]
    ON [dbo].[InvoiceTable]([EmissionPointId] ASC, [InvoiceDate] ASC)
    INCLUDE([InvoiceIdLocal], [LocationId], [TypeDoc], [InvoiceIdReference], [Establishment], [Emission], [InvoiceNumber], [CustomerId], [SalesmanId], [IsCredit], [Expiration], [BaseAmount], [BaseTaxAmount], [Discount], [TaxPercent], [TaxAmount], [IrbpAmount], [Total], [ShippingFree], [ShippingAmount], [Returned], [SalesOriginId], [IsECommerce], [SalesOrderId], [ClosingCashierId], [Observation], [KeyAccessSri], [TransferStatusId], [Status], [CreatedBy], [CreatedDatetime], [ModifiedBy], [ModifiedDatetime], [Workstation]);
GO

CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_15]
    ON [dbo].[InvoiceTable]([EmissionPointId] ASC, [InvoiceDate] ASC)
    INCLUDE([InvoiceNumber]);
GO

CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_16]
    ON [dbo].[InvoiceTable]([EmissionPointId] ASC, [InvoiceNumber] ASC);
GO

CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_17]
    ON [dbo].[InvoiceTable]([EmissionPointId] ASC, [InvoiceNumber] ASC, [InvoiceDate] ASC);
GO

CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_18]
    ON [dbo].[InvoiceTable]([InvoiceDate] ASC)
    INCLUDE([CreatedBy]);
GO

CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_19]
    ON [dbo].[InvoiceTable]([InvoiceDate] ASC)
    INCLUDE([Emission], [InvoiceNumber]);
GO

CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_20]
    ON [dbo].[InvoiceTable]([InvoiceDate] ASC)
    INCLUDE([EmissionPointId], [Emission], [CreatedBy]);
GO

CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_21]
    ON [dbo].[InvoiceTable]([InvoiceDate] ASC)
    INCLUDE([EmissionPointId], [Emission], [Total], [CreatedBy]);
GO

CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_22]
    ON [dbo].[InvoiceTable]([InvoiceDate] ASC)
    INCLUDE([Establishment], [Emission], [InvoiceNumber]);
GO

CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_23]
    ON [dbo].[InvoiceTable]([InvoiceDate] ASC)
    INCLUDE([InvoiceIdLocal], [LocationId], [TypeDoc], [InvoiceIdReference], [EmissionPointId], [Establishment], [Emission], [InvoiceNumber], [CustomerId], [SalesmanId], [IsCredit], [Expiration], [BaseAmount], [BaseTaxAmount], [Discount], [TaxPercent], [TaxAmount], [IrbpAmount], [Total], [ShippingFree], [ShippingAmount], [Returned], [SalesOriginId], [IsECommerce], [SalesOrderId], [ClosingCashierId], [Observation], [KeyAccessSri], [TransferStatusId], [Status], [CreatedBy], [CreatedDatetime], [ModifiedBy], [ModifiedDatetime], [Workstation]);
GO

CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_24]
    ON [dbo].[InvoiceTable]([InvoiceDate] ASC, [Status] ASC)
    INCLUDE([EmissionPointId], [Emission], [CreatedBy]);
GO

CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_25]
    ON [dbo].[InvoiceTable]([InvoiceDate] ASC, [Status] ASC)
    INCLUDE([EmissionPointId], [Emission], [Total], [CreatedBy]);
GO

CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_26]
    ON [dbo].[InvoiceTable]([InvoiceDate] ASC, [TransferStatusId] ASC)
    INCLUDE([InvoiceIdLocal], [LocationId], [TypeDoc], [InvoiceIdReference], [EmissionPointId], [Establishment], [Emission], [InvoiceNumber], [CustomerId], [SalesmanId], [IsCredit], [Expiration], [BaseAmount], [BaseTaxAmount], [Discount], [TaxPercent], [TaxAmount], [IrbpAmount], [Total], [ShippingFree], [ShippingAmount], [Returned], [SalesOriginId], [IsECommerce], [SalesOrderId], [ClosingCashierId], [Observation], [KeyAccessSri], [Status], [CreatedBy], [CreatedDatetime], [ModifiedBy], [ModifiedDatetime], [Workstation]);
GO

CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_27]
    ON [dbo].[InvoiceTable]([InvoiceIdLocal] ASC)
    INCLUDE([LocationId], [TypeDoc], [InvoiceIdReference], [EmissionPointId], [Establishment], [Emission], [InvoiceNumber], [CustomerId], [SalesmanId], [IsCredit], [InvoiceDate], [Expiration], [BaseAmount], [BaseTaxAmount], [Discount], [TaxPercent], [TaxAmount], [IrbpAmount], [Total], [ShippingFree], [ShippingAmount], [Returned], [SalesOriginId], [IsECommerce], [SalesOrderId], [ClosingCashierId], [Observation], [KeyAccessSri], [TransferStatusId], [Status], [CreatedBy], [CreatedDatetime], [ModifiedBy], [ModifiedDatetime], [Workstation]);
GO

CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_28]
    ON [dbo].[InvoiceTable]([InvoiceNumber] ASC)
    INCLUDE([InvoiceIdLocal], [LocationId], [TypeDoc], [InvoiceIdReference], [EmissionPointId], [Establishment], [Emission], [CustomerId], [SalesmanId], [IsCredit], [InvoiceDate], [Expiration], [BaseAmount], [BaseTaxAmount], [Discount], [TaxPercent], [TaxAmount], [IrbpAmount], [Total], [ShippingFree], [ShippingAmount], [Returned], [SalesOriginId], [IsECommerce], [SalesOrderId], [ClosingCashierId], [Observation], [KeyAccessSri], [TransferStatusId], [Status], [CreatedBy], [CreatedDatetime], [ModifiedBy], [ModifiedDatetime], [Workstation]);
GO

CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_29]
    ON [dbo].[InvoiceTable]([InvoiceNumber] ASC, [KeyAccessSri] ASC);
GO

CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_30]
    ON [dbo].[InvoiceTable]([LocationId] ASC, [Emission] ASC, [InvoiceNumber] ASC, [ClosingCashierId] ASC, [TransferStatusId] ASC);
GO

CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_31]
    ON [dbo].[InvoiceTable]([LocationId] ASC, [EmissionPointId] ASC, [ClosingCashierId] ASC, [CreatedBy] ASC, [InvoiceDate] ASC)
    INCLUDE([Status]);
GO

CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_32]
    ON [dbo].[InvoiceTable]([LocationId] ASC, [EmissionPointId] ASC, [ClosingCashierId] ASC, [CreatedBy] ASC, [InvoiceDate] ASC, [Status] ASC);
GO

CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_33]
    ON [dbo].[InvoiceTable]([LocationId] ASC, [EmissionPointId] ASC, [ClosingCashierId] ASC, [CreatedBy] ASC, [Status] ASC)
    INCLUDE([InvoiceDate]);
GO

CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_34]
    ON [dbo].[InvoiceTable]([SalesOrderId] ASC)
    INCLUDE([Establishment], [Emission], [InvoiceNumber]);
GO

CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_35]
    ON [dbo].[InvoiceTable]([SalesOrderId] ASC)
    INCLUDE([Status]);
GO

CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_36]
    ON [dbo].[InvoiceTable]([SalesOrderId] ASC, [Status] ASC);
GO

CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_37]
    ON [dbo].[InvoiceTable]([Status] ASC)
    INCLUDE([SalesOrderId]);
GO

CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_38]
    ON [dbo].[InvoiceTable]([TransferStatusId] ASC)
    INCLUDE([LocationId], [Establishment], [Emission], [InvoiceNumber], [CustomerId], [SalesmanId], [IsCredit], [InvoiceDate], [Expiration], [BaseAmount], [BaseTaxAmount], [TaxPercent], [TaxAmount], [IrbpAmount], [Total], [SalesOrderId], [KeyAccessSri], [Status], [CreatedBy], [CreatedDatetime]);
GO

CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_39]
    ON [dbo].[InvoiceTable]([TransferStatusId] ASC, [InvoiceDate] ASC);
GO



/*--------------------Detalle PUNTO DE VENTA--------------------*/
CREATE TABLE [dbo].[InvoiceLine]
([InvoiceId]				BIGINT			NOT NULL,
 [Sequence]					INT				NOT NULL,
 [ProductId]				BIGINT			NOT NULL,
 [Barcode]					[varchar](20)	Collate Database_Default NOT NULL,
 [InventUnitId]				Int				NOT NULL,
 [IsDeductible]				BIT				NOT NULL, /*si es decucible al sri*/
 [UseTax]					BIT				NOT NULL, /*Graba IVA*/
 [TaxProductAmount]			NUMERIC(18, 4)	NOT NULL, /*Precio*/ 
 [DiscountProductAmount]	NUMERIC(18, 4)	NOT NULL, /*Precio*/ 
 [Quantity]					NUMERIC(18, 6)	NOT NULL, /*Cantidad*/
 [QuantityCW]				INT				NOT NULL, /*Unidades*/
 [Returned]					INT				NOT NULL, /*Devolucion*/
 [Cost]						NUMERIC(18, 4)	NOT NULL, /*Precio*/
 [Price]					NUMERIC(18, 4)	NOT NULL, /*Precio*/
 [BaseAmount]				NUMERIC(18, 4)	NOT NULL, /*BaseAmount Base Cero*/
 [BaseTaxAmount]			NUMERIC(18, 4)	NOT NULL, /*BaseAmount Base IVA*/
 [LinePercent]				NUMERIC( 5, 2)	NOT NULL, /*% Descuento*/
 [LineDiscount]				NUMERIC(18, 4)	NOT NULL, /*Valor Descuento Base Cero*/
 [TaxPercent]				NUMERIC( 5, 2)	NOT NULL, /*% IVA*/ 
 [TaxAmount]				NUMERIC(18, 4)	NOT NULL, /*Valor IVA*/ 
 [IrbpAmount]				NUMERIC(18, 4)	NOT NULL, /*Valor IRBP*/
 [LineAmount]				NUMERIC(18, 4)	NOT NULL, /*Total a pagar*/
 [PromotionId]				BIGINT   NOT NULL,
 [Status]					[Char](1)		Collate Database_Default NULL,
 [CreatedBy]				INT				NOT NULL,
 [CreatedDatetime]			DATETIME		NOT NULL, 
 [ModifiedBy]				INT				NULL,
 [ModifiedDatetime]			DATETIME		NULL, 
 [Workstation]				VARCHAR(20)		Collate Database_Default NOT NULL,
 CONSTRAINT [PK__InvoiceLine] PRIMARY KEY CLUSTERED ([InvoiceId], [Sequence]),
 CONSTRAINT [FK__InvoiceLine_InvoiceTable] FOREIGN KEY ([InvoiceId]) REFERENCES [InvoiceTable] ([InvoiceId]),
 CONSTRAINT [FK__InvoiceLine_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([ProductId]),
 CONSTRAINT [FK__InvoiceLine_InventUnit] FOREIGN KEY ([InventUnitId]) REFERENCES [InventUnit] ([InventUnitId]),
 ) ON [PRIMARY]
Go


/*--------------------Detalle Formas de Pago Venta--------------------*/
CREATE TABLE [dbo].[InvoicePayment]
([InvoiceId]            BIGINT         NOT NULL,
 [LocationId]           SMALLINT       NOT NULL,
 [Sequence]             INT            NOT NULL,
 [PaymModeId]           INT            NOT NULL,
 [Amount]               NUMERIC(18, 2) NOT NULL, /*Valor*/
 [Received]				NUMERIC(18, 2)	NOT NULL, /*Recibido*/
 [Change]				NUMERIC(18, 2)	NOT NULL, /*Cambio*/
 [PaymentDate]			DATETIME       NOT NULL,
 [BankId]               INT            NOT NULL,
 [CreditCardId]         INT            NOT NULL,
 [AccountNumber]        VARCHAR(20)    Collate Database_Default NOT NULL,  /**/
 [CkeckNumber]          INT            NOT NULL,
 [CkeckType]            VARCHAR(2)     Collate Database_Default NOT NULL, /*Tipo Tarjeta*/
 [CkeckDate]            DATETIME       NOT NULL,
 [CheckOwner]           VARCHAR(100)   Collate Database_Default NOT NULL, /*Numero Tarjeta*/
 [Authorization]        VARCHAR(40)    Collate Database_Default NOT NULL,  /*Autorizacion*/
 [IsProtest]            BIT            NOT NULL,
 [ProtestDate]          DATETIME       NOT NULL,
 [InternalCreditCardId] BIGINT			NOT NULL,
 [GiftCardNumber]       VARCHAR(20)    NOT NULL,
 [RetentionCode]		INT            NOT NULL,
 [RetentionNumber]      VARCHAR(15)    Collate Database_Default NOT NULL,  /**/
 [Status]               [Char](1)      Collate Database_Default NULL,
 [CreatedBy]            INT            NOT NULL,
 [CreatedDatetime]      DATETIME       NOT NULL, 
 [ModifiedBy]           INT            NULL,
 [ModifiedDatetime]     DATETIME       NULL, 
 [Workstation]          VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__InvoicePayment] PRIMARY KEY CLUSTERED ([InvoiceId], [Sequence]),
 CONSTRAINT [FK__InvoicePayment_Location] FOREIGN KEY ([LocationId]) REFERENCES [Location] ([LocationId]),
 CONSTRAINT [FK__InvoicePayment_InvoiceTable] FOREIGN KEY ([InvoiceId]) REFERENCES [InvoiceTable] ([InvoiceId]),
 CONSTRAINT [FK__InvoicePayment_PaymMode] FOREIGN KEY ([PaymModeId]) REFERENCES [PaymMode] ([PaymModeId]),
 ) ON [PRIMARY]
Go

CREATE NONCLUSTERED INDEX [Ind_InvoicePayment_1]
    ON [dbo].[InvoicePayment]([PaymModeId] ASC)
    INCLUDE([Amount], [Authorization]);
GO

CREATE TABLE [dbo].[AccountsReceivable]
([AccountsReceivableId]       BIGINT         NOT NULL,
 [AccountsReceivableIdLocal]  BIGINT         IDENTITY NOT NULL,
 [LocationId]                 SMALLINT       NOT NULL,
 [TypeDoc]                    SMALLINT       NOT NULL, /*1=Factura, 4=NC*/
 [CustomerId]                 BIGINT         NOT NULL,
 [InvoiceId]                  BIGINT         NOT NULL,
 [DocNumber]                  BIGINT         NOT NULL,
 [Registration]               DATETIME       NOT NULL, /*Fecha Emision*/
 [Expiration]                 DATETIME       NOT NULL, /*Fecha Caducidad*/ 
 [Amount]                     NUMERIC(18, 2) NOT NULL, /*Valor*/
 [AmountPaid]                 NUMERIC(18, 2) NOT NULL, /*Total a pagar*/
 [Observation]                VARCHAR(250)   Collate Database_Default NOT NULL, 
 [StatusAccounts]             [Char](1)      Collate Database_Default NULL,
 [Status]                     [Char](1)      Collate Database_Default NULL,
 [CreatedBy]                  INT            NOT NULL,
 [CreatedDatetime]            DATETIME       NOT NULL, 
 [ModifiedBy]                 INT            NULL,
 [ModifiedDatetime]           DATETIME       NULL, 
 [Workstation]                VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__AccountsReceivable] PRIMARY KEY CLUSTERED ([AccountsReceivableId]),
 CONSTRAINT [FK__AccountsReceivable_Location] FOREIGN KEY ([LocationId]) REFERENCES [Location] ([LocationId]),
 CONSTRAINT [FK__AccountsReceivable_Customer] FOREIGN KEY ([CustomerId])  REFERENCES [Customer] ([CustomerId]),
 ) ON [PRIMARY]
Go

--/*PARA PLANTILLA DEFINICI N DE PRODUCTOS EN BONOS*/
--CREATE TABLE [dbo].[GiftCardTemplateTable]
--([GiftCardTemplateId]	BIGINT			NOT NULL,
-- [ProductId]			BIGINT			NOT NULL,
-- [Observation]			VARCHAR(200)	Collate Database_Default NOT NULL,
-- [Status]               [Char](1)		Collate Database_Default NULL,
-- [CreatedBy]            INT				NOT NULL,
-- [CreatedDatetime]      DATETIME		NOT NULL, 
-- [ModifiedBy]           INT				NULL,
-- [ModifiedDatetime]     DATETIME		NULL, 
-- [Workstation]          VARCHAR(20)		Collate Database_Default NOT NULL,
-- CONSTRAINT [PK__GiftCardTemplateTable] PRIMARY KEY CLUSTERED ([GiftCardTemplateId]),
-- CONSTRAINT [FK__GiftCardTemplateTable_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([ProductId]),
-- ) ON [PRIMARY]
--Go

--CREATE  TABLE [dbo].[GiftCardTemplateLine]
--([GiftCardTemplateId]	BIGINT			NOT NULL,
-- [Sequence]				INT				NOT NULL,
-- [ProductId]			BIGINT			NOT NULL,
-- [Quantity]				NUMERIC(24, 6)	NOT NULL,
-- [StatusLine]			[Char](1)		Collate Database_Default NULL,
-- CONSTRAINT [PK__GiftCardTemplateLine] PRIMARY KEY CLUSTERED ([GiftCardTemplateId], [Sequence]),
-- CONSTRAINT [FK__GiftCardTemplateLine_GiftCardTemplateTable] FOREIGN KEY  ([GiftCardTemplateId]) REFERENCES [GiftCardTemplateTable] ([GiftCardTemplateId]),
-- CONSTRAINT [FK__GiftCardTemplateLine_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([ProductId]),
-- ) ON [PRIMARY]
--Go

--Create Unique Index Ind_GiftCardTemplateLine on GiftCardTemplateLine([GiftCardTemplateId], [ProductId])
--Go


CREATE TABLE [dbo].[GiftCardBlockTable](
 [GiftCardBlockId]      BIGINT			NOT NULL,
 [LocationId]			SMALLINT		NOT NULL,
 [Year]					INT				NOT NULL,
 [Type]					VARCHAR(2)		Collate Database_Default NOT NULL,
 [Observation]			VARCHAR(200)	Collate Database_Default NOT NULL,
 [Status]               [Char](1)		Collate Database_Default NULL,
 [CreatedBy]            INT				NOT NULL,
 [CreatedDatetime]      DATETIME		NOT NULL, 
 [ModifiedBy]           INT				NULL,
 [ModifiedDatetime]     DATETIME		NULL, 
 [Workstation]          VARCHAR(20)		Collate Database_Default NOT NULL,
 CONSTRAINT [PK__GiftCardBlockTable] PRIMARY KEY CLUSTERED ([GiftCardBlockId]),
 CONSTRAINT [FK__GiftCardBlockTable_Location] FOREIGN KEY ([LocationId]) REFERENCES [Location] ([LocationId]),
 ) ON [PRIMARY]
Go

CREATE TABLE [dbo].[GiftCardBlockLine](
 [GiftCardBlockId]		BIGINT   NOT NULL,
 [Sequence]				INT      NOT NULL,
 [GiftCardNumberStart]  BIGINT   NOT NULL,
 [GiftCardNumberFinal]  BIGINT   NOT NULL,
 [Status]				[Char](1)		Collate Database_Default NULL,
 [CreatedBy]			INT				NOT NULL,
 [CreatedDatetime]		DATETIME		NOT NULL, 
 [ModifiedBy]			INT				NULL,
 [ModifiedDatetime]		DATETIME		NULL, 
 [Workstation]			VARCHAR(20)		Collate Database_Default NOT NULL,
 CONSTRAINT [PK__GiftCardBlockLine] PRIMARY KEY CLUSTERED ([GiftCardBlockId], [Sequence]),
 CONSTRAINT [FK__GiftCardBlockLine_GiftCardBlockTable] FOREIGN KEY ([GiftCardBlockId]) REFERENCES [GiftCardBlockTable] ([GiftCardBlockId]),
 ) ON [PRIMARY]
Go

/*--------------------Cabecera Bonos--------------------*/
CREATE TABLE [dbo].[GiftCardTable]
([GiftCardId]           BIGINT         NOT NULL,
 [GiftCardIdLocal]      BIGINT         NOT NULL,
 [LocationId]			SMALLINT       NOT NULL,
 [LocationIdOrigin]		SMALLINT       NOT NULL,
 [Year]					INT            NOT NULL,
 [GiftCardBlockId]      BIGINT         NOT NULL,
 [Registration]			DATETIME       NOT NULL, /*Fecha Emision*/
 [Expiration]			DATETIME       NOT NULL, /*Fecha Caducidad*/ 
 [Type]					VARCHAR(2)     Collate Database_Default NOT NULL,  --CC:CLIENTE CORPORATIVO;EM:EMPLEADOS;CJ:CANJES
 [UseCode]				VARCHAR(4)     NOT NULL,  --Tipo Bono IC: INVOICE CONSUMPTION; DC:DELIVERY CONSUMPTION; PRPE:PRODUCTOS DE PESO; CNSB:CONSUMO NOTA ENTREGA SIN BAJAR STOCK
 [CustomerId]			bigINT         NOT NULL,
 [InvoiceId]			BIGINT         NOT NULL,  --id fatura Relacionada
 [GiftCardNumberStart]	BIGINT         NOT NULL,
 [GiftCardNumberFinal]  BIGINT         NOT NULL,
 [Quantity]				INT            NOT NULL,
 [Total]				NUMERIC(18, 2) NOT NULL, --   
 [Observation]			VARCHAR(200)   Collate Database_Default NOT NULL,  --
 [Status]               [Char](1)		Collate Database_Default NULL,
 [CreatedBy]            INT				NOT NULL,
 [CreatedDatetime]      DATETIME		NOT NULL, 
 [ModifiedBy]           INT				NULL,
 [ModifiedDatetime]     DATETIME		NULL, 
 [Workstation]          VARCHAR(20)		Collate Database_Default NOT NULL,
 CONSTRAINT [PK__GiftCardTable] PRIMARY KEY CLUSTERED ([GiftCardId]),
 CONSTRAINT [FK__GiftCardTable_Location] FOREIGN KEY ([LocationId]) REFERENCES [Location] ([LocationId]),
 CONSTRAINT [FK__GiftCardTable_LocationOrigin] FOREIGN KEY ([LocationIdOrigin]) REFERENCES [Location] ([LocationId]),
 CONSTRAINT [FK__GiftCardTable_GiftCardBlockTable] FOREIGN KEY ([GiftCardBlockId]) REFERENCES [GiftCardBlockTable] ([GiftCardBlockId]),
 CONSTRAINT [FK__GiftCardTable_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [Customer] ([CustomerId]),
 ) ON [PRIMARY]
Go

CREATE TABLE [dbo].[GiftCardLine]
([GiftCardId]				BIGINT         NOT NULL,
 [Sequence]					INT            NOT NULL,
 [Year]						INT            NOT NULL,
 [GiftCardNumber]			VARCHAR(20)    NOT NULL,
 [CustomerId]				BIGINT         NOT NULL,
 [RedeemIdentification]		VARCHAR(20)   Collate Database_Default NOT NULL,
 [RedeemCustomer]			VARCHAR(200)   Collate Database_Default NOT NULL,
 [Amount]					NUMERIC(18, 4) NOT NULL, --
 [AmountConsumed]			NUMERIC(18, 4) NOT NULL, --
 [StatusLine]				CHAR(1)        NOT NULL, --Estado Bono
 [CreatedBy]				INT				NOT NULL,
 [CreatedDatetime]			DATETIME		NOT NULL, 
 [ModifiedBy]				INT				NULL,
 [ModifiedDatetime]			DATETIME		NULL, 
 [Workstation]				VARCHAR(20)		Collate Database_Default NOT NULL,
 CONSTRAINT [PK__GiftCardLine] PRIMARY KEY CLUSTERED ([GiftCardId], [Sequence]),
 CONSTRAINT [FK__GiftCardLine_GiftCardTable] FOREIGN KEY ([GiftCardId]) REFERENCES [GiftCardTable] ([GiftCardId]),
 CONSTRAINT [FK__GiftCardLine_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [Customer] ([CustomerId]),
 ) ON [PRIMARY]
Go

Create Unique Index Ind_GiftCardLine on GiftCardLine([Year], [GiftCardNumber])
Go

CREATE  TABLE [dbo].[GiftCardLineProduct]
([GiftCardId]			BIGINT			NOT NULL,
 [Sequence]				INT				NOT NULL,
 [ProdSeq]				INT				NOT NULL,
 [ProductId]			BIGINT			NOT NULL,
 [Quantity]				NUMERIC(24, 6)	NOT NULL,
 [Status]				[Char](1)		Collate Database_Default NULL,
 [CreatedBy]			INT				NOT NULL,
 [CreatedDatetime]		DATETIME		NOT NULL, 
 [ModifiedBy]			INT				NULL,
 [ModifiedDatetime]		DATETIME		NULL, 
 [Workstation]			VARCHAR(20)		Collate Database_Default NOT NULL,
 CONSTRAINT [PK__GiftCardLineProduct] PRIMARY KEY CLUSTERED ([GiftCardId], [Sequence], [ProdSeq]),
 CONSTRAINT [FK__GiftCardLineProduct_GiftCardLine] FOREIGN KEY  ([GiftCardId], [Sequence]) REFERENCES [GiftCardLine] ([GiftCardId], [Sequence]),
 CONSTRAINT [FK__GiftCardLineProduct_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([ProductId]),
 ) ON [PRIMARY]
Go
--Create Unique Index Ind_GiftCardTemplateLine on GiftCardTemplateLine([GiftCardTemplateId], [ProductId])
--Go

CREATE TABLE [dbo].[GiftCardTrans]
(
 [GiftCardId]           BIGINT         NOT NULL,
 [Sequence]				INT            NOT NULL,
 [TrnsSeq]				INT            NOT NULL,
 [LocationIdRedeem]		SMALLINT       NOT NULL,
 [RedeemDate]			DATETIME       NOT NULL, /*Fecha Emision*/
 [TrnsType]				VARCHAR(2)     Collate Database_Default NOT NULL,  /*CF=CONSUMO FACTURA; CONSUMO NOTA ENTREGA=NOTA ENTREGA;*/
 [TrnsStatus]			CHAR(1)        NOT NULL, --Estado Bono
 [TrnsId]				BIGINT         NOT NULL,
 [TrnsAmount]			NUMERIC(18, 4) NOT NULL,
 [ProductId]			BIGINT         NOT NULL,
 [Quantity]				NUMERIC(24, 6) NOT NULL,
 [RedeemQuantity]		NUMERIC(24, 6) NOT NULL,
 [CreatedBy]			INT				NOT NULL,
 [CreatedDatetime]		DATETIME		NOT NULL, 
 [ModifiedBy]			INT				NULL,
 [ModifiedDatetime]		DATETIME		NULL, 
 [Workstation]			VARCHAR(20)		Collate Database_Default NOT NULL,
 CONSTRAINT [PK__GiftCardTrans] PRIMARY KEY CLUSTERED ([GiftCardId], [Sequence], [TrnsSeq]),
 CONSTRAINT [FK__GiftCardTrans_GiftCardLine] FOREIGN KEY ([GiftCardId],[Sequence]) REFERENCES [GiftCardLine] ([GiftCardId], [Sequence]),
 CONSTRAINT [FK__GiftCardTrans_LocationRedeem] FOREIGN KEY ([LocationIdRedeem]) REFERENCES [Location] ([LocationId]),
 ) ON [PRIMARY]
Go


/*--------------------Cabecera PUNTO DE VENTA--------------------*/
CREATE TABLE [dbo].[SalesRemissionTable]
([SalesRemissionId]			BIGINT			NOT NULL,
 [SalesRemissionIdLocal]	BIGINT			IDENTITY NOT NULL,
 [LocationId]				SMALLINT		NOT NULL,
 [TypeDoc]					SMALLINT		NOT NULL, /*1=Factura, 4=NC*/
 [EmissionPointId]			INT				NOT NULL,
 [Establishment]			[varchar](5)	Collate Database_Default NOT NULL,
 [RemissionNumber]			BIGINT			NULL,
 [Emission]					[varchar](5)	Collate Database_Default NOT NULL,
 [TransportDriverId]		INT				NOT NULL,
 [TransportId]				[Int]			NOT NULL,
 [TransportReasonId]		Int				NOT NULL, 
 [SalesRemissionDate]		DATETIME		NOT NULL, /*Fecha Emision*/
 [DeliveryDate]				DATETIME		NOT NULL, /*Fecha Caducidad*/ 
 [Observation]				VARCHAR(250)	Collate Database_Default NOT NULL,
 [KeyAccessSri]				VARCHAR(50)		Collate Database_Default NOT NULL,  /*ClaveAcceso*/
 [TransferStatusId]			INT				NOT NULL,
 [Status]					[Char](1)		Collate Database_Default NULL,
 [CreatedBy]				INT				NOT NULL,
 [CreatedDatetime]			DATETIME		NOT NULL, 
 [ModifiedBy]				INT				NULL,
 [ModifiedDatetime]			DATETIME		NULL, 
 [Workstation]				VARCHAR(20)		Collate Database_Default NOT NULL,
 CONSTRAINT [PK__SalesRemissionTable]					PRIMARY KEY CLUSTERED ([SalesRemissionId]),
 CONSTRAINT [FK__SalesRemissionTable_Location]			FOREIGN KEY ([LocationId]) REFERENCES [Location] ([LocationId]),
 CONSTRAINT [FK__SalesRemissionTable_Transport]			FOREIGN KEY ([TransportId]) REFERENCES [Transport] ([TransportId]),
 CONSTRAINT [FK__SalesRemissionTable_TransportDriver]	FOREIGN KEY ([TransportDriverId]) REFERENCES [TransportDriver] ([TransportDriverId]),
 CONSTRAINT [FK__SalesRemissionTable_EmissionPoint]		FOREIGN KEY ([EmissionPointId]) REFERENCES [EmissionPoint] ([EmissionPointId]),
 CONSTRAINT [FK__SalesRemissionTable_TransportReason]	FOREIGN KEY ([TransportReasonId]) REFERENCES [TransportReason] ([TransportReasonId]),
 ) ON [PRIMARY]
Go

CREATE NONCLUSTERED INDEX [Ind_SalesRemissionTable_1]
    ON [dbo].[SalesRemissionTable]([SalesRemissionDate] ASC)
    INCLUDE([TransportDriverId]);
GO

CREATE NONCLUSTERED INDEX [Ind_SalesRemissionTable_2]
    ON [dbo].[SalesRemissionTable]([SalesRemissionIdLocal] ASC);
GO

CREATE NONCLUSTERED INDEX [Ind_SalesRemissionTable_3]
    ON [dbo].[SalesRemissionTable]([Status] ASC)
    INCLUDE([TransportDriverId], [TransportId], [SalesRemissionDate], [CreatedBy]);
GO


/*--------------------Detalle PUNTO DE VENTA--------------------*/
CREATE TABLE [dbo].[SalesRemissionLine]
([SalesRemissionId]     BIGINT      NOT NULL,
 [Sequence]				INT         NOT NULL,
 [SalesOrderId]     BIGINT   NOT NULL,
 [Status]				[Char](1)	Collate Database_Default NULL,
 [CreatedBy]			INT			NOT NULL,
 [CreatedDatetime]		DATETIME	NOT NULL, 
 [ModifiedBy]			INT			NULL,
 [ModifiedDatetime]		DATETIME	NULL, 
 [Workstation]			VARCHAR(20)	Collate Database_Default NOT NULL,
 CONSTRAINT [PK__SalesRemissionLine] PRIMARY KEY CLUSTERED ([SalesRemissionId], [Sequence]),
 CONSTRAINT [FK__SalesRemissionLine_SalesRemissionTable] FOREIGN KEY ([SalesRemissionId]) REFERENCES [SalesRemissionTable] ([SalesRemissionId]),
 --CONSTRAINT [FK__SalesRemissionLine_InvoiceTable] FOREIGN KEY ([InvoiceId]) REFERENCES [InvoiceTable] ([InvoiceId]),
 ) ON [PRIMARY]
Go

CREATE NONCLUSTERED INDEX [Ind_SalesRemissionLine_1]
    ON [dbo].[SalesRemissionLine]([SalesOrderId] ASC)
    INCLUDE([Status]);
GO

CREATE NONCLUSTERED INDEX [Ind_SalesRemissionLine_3]
    ON [dbo].[SalesRemissionLine]([SalesOrderId] ASC, [Status] ASC);
GO

CREATE TABLE [dbo].[LogType]
([LogTypeId]			INT            NOT NULL,
 [Name]					[varchar](50)  Collate Database_Default NULL,
 [Status]				[Char](1)	Collate Database_Default NULL,
 [CreatedBy]			INT			NOT NULL,
 [CreatedDatetime]		DATETIME	NOT NULL, 
 [ModifiedBy]			INT			NULL,
 [ModifiedDatetime]		DATETIME	NULL, 
 [Workstation]			VARCHAR(20)	Collate Database_Default NOT NULL,
CONSTRAINT [PK__LogType] PRIMARY KEY CLUSTERED ([LogTypeId]),
) ON [PRIMARY]
Go

INSERT INTO [LogType]
		SELECT 1, 'Anular Documento', 		'A', 1, 0, NULL, NULL, 'SERVER' --INVOICE_CANCEL
UNION	SELECT 2, 'Anular Cierre Parcial',	'A', 1, 0, NULL, NULL, 'SERVER' -- PARTIAL_CLOSING
UNION	SELECT 3, 'Eliminar Producto',		'A', 1, 0, NULL, NULL, 'SERVER' -- ITEM_CANCEL
UNION	SELECT 4, 'Anular Pedido',			'A', 1, 0, NULL, NULL, 'SERVER' -- SALESORDER_CANCEL
UNION	SELECT 5, 'Anular Guia de Remisi n','A', 1, 0, NULL, NULL, 'SERVER' -- REMISSIONGUIDE_CANCEL
UNION	SELECT 6, 'Anular Cierre de Caja', 	'A', 1, 0, NULL, NULL, 'SERVER' -- CLOSINGCASHIER
UNION	SELECT 7, 'Anular Nota de Cr dito',	'A', 1, 0, NULL, NULL, 'SERVER' -- RETURN_CANCEL
UNION	SELECT 8, 'Motivo Nota de Cr dito',	'A', 1, 0, NULL, NULL, 'SERVER' -- RETURN_REASON

GO

SELECT * FROM [LogType]

CREATE TABLE [dbo].[CancelReason]
([ReasonId]				INT			NOT NULL,
 [ReasonType]			INT         NULL,
 [Name]					[varchar](50)	Collate Database_Default NULL,
 [Status]				[Char](1)	Collate Database_Default NULL,
 [CreatedBy]			INT			NOT NULL,
 [CreatedDatetime]		DATETIME	NOT NULL, 
 [ModifiedBy]			INT			NULL,
 [ModifiedDatetime]		DATETIME	NULL, 
 [Workstation]			VARCHAR(20)	Collate Database_Default NOT NULL,
CONSTRAINT [PK__CancelReason]	PRIMARY KEY CLUSTERED ([ReasonId]),
) ON [PRIMARY]
Go


INSERT	INTO [CancelReason]
		SELECT 1, 1, 'Cliente pide cambio de identificaci n', 	'A', 1, 0, NULL, NULL, 'SERVER'
UNION	SELECT 2, 1, 'Cliente se cancela por falta de dinero',	'A', 1, 0, NULL, NULL, 'SERVER'
UNION	SELECT 3, 1, 'Cliente desiste de la compra',			'A', 1, 0, NULL, NULL, 'SERVER'
UNION	SELECT 4, 2, 'Autorizado por Gerencia',					'A', 1, 0, NULL, NULL, 'SERVER'
UNION	SELECT 5, 2, 'Retiro por Exceso',						'A', 1, 0, NULL, NULL, 'SERVER'
UNION	SELECT 6, 2, 'Cierre por Auditoria',					'A', 1, 0, NULL, NULL, 'SERVER'
UNION	SELECT 7, 4, 'Pedido de prueba',						'A', 1, 0, NULL, NULL, 'SERVER'
UNION	SELECT 8, 4, 'Pedido duplicado',						'A', 1, 0, NULL, NULL, 'SERVER'
UNION	SELECT 9, 4, 'Cliente desiste de pedido',				'A', 1, 0, NULL, NULL, 'SERVER'
UNION	SELECT 10, 4, 'Cliente no se encontr  en domicilio',	'A', 1, 0, NULL, NULL, 'SERVER'
UNION	SELECT 11, 4, 'Pedido no fue despachado a tiempo',		'A', 1, 0, NULL, NULL, 'SERVER'
UNION	SELECT 12, 4, 'Zona de pedido no aplica a supermercado','A', 1, 0, NULL, NULL, 'SERVER'
UNION	SELECT 13, 5, 'Cambio Conductor',						'A', 1, 0, NULL, NULL, 'SERVER'
UNION	SELECT 14, 3, 'Error de cajero',						'A', 1, 0, NULL, NULL, 'SERVER'
UNION	SELECT 15, 3, 'Cliente desiste compra',					'A', 1, 0, NULL, NULL, 'SERVER'
UNION	SELECT 16, 3, 'Cliente desiste producto especifico',	'A', 1, 0, NULL, NULL, 'SERVER'
UNION	SELECT 17, 2, 'Por Reposici n Caja',					'A', 1, 0, NULL, NULL, 'SERVER'
UNION	SELECT 18, 2, 'Por Faltante en Arqueo',					'A', 1, 0, NULL, NULL, 'SERVER'
UNION	SELECT 19, 7, 'Datos Incorrectos',						'A', 1, 0, NULL, NULL, 'SERVER'
UNION	SELECT 20, 8, 'Cliente Desiste',						'A', 1, 0, NULL, NULL, 'SERVER'
UNION	SELECT 21, 8, 'Producto Inconforme',					'A', 1, 0, NULL, NULL, 'SERVER'
UNION	SELECT 22, 8, 'Datos Incorrectos',						'A', 1, 0, NULL, NULL, 'SERVER'
UNION	SELECT 23, 8, 'Factura Duplicada',						'A', 1, 0, NULL, NULL, 'SERVER'

GO

SELECT * FROM [CancelReason]


CREATE TABLE [dbo].[SalesLog]
([SalesLogId]			BIGINT			IDENTITY NOT NULL,
 [LocationId]			SMALLINT		NOT NULL,
 [EmissionPointId]		INT				NOT NULL,
 [InvoiceNumber]		BIGINT			NOT NULL,
 [CustomerId]			BIGINT			NOT NULL,
 [LogTypeId]			INT				NOT NULL,
 [ReasonId]				INT				NOT NULL,
 [Authorization]        VARCHAR(40)    Collate Database_Default NOT NULL,  /*Autorizacion*/
 [XmlLog]				XML				NOT NULL,
 [Status]				[Char](1)		Collate Database_Default NULL,
 [CreatedBy]			INT				NOT NULL,
 [CreatedDatetime]		DATETIME		NOT NULL, 
 [ModifiedBy]			INT				NULL,
 [ModifiedDatetime]		DATETIME		NULL, 
 [Workstation]			VARCHAR(20)		Collate Database_Default NOT NULL,
 CONSTRAINT [PK__SalesLog] PRIMARY KEY CLUSTERED ([SalesLogId]),
 CONSTRAINT [FK__SalesLog_LogType] FOREIGN KEY ([LogTypeId]) REFERENCES [LogType] ([LogTypeId]),
 ) ON [PRIMARY]
Go

CREATE TABLE [dbo].[PhysicalStockCountingTable]
([PhysicalStockCountingId]      INT           NOT NULL,
 [PhysicalStockCountingIdLocal] INT           IDENTITY (1, 1) NOT NULL,
 [LocationId]                   SMALLINT      NOT NULL,
 [EmissionPointId]              INT           NOT NULL,
 [InventLocationId]             INT           NOT NULL,
 [CountingDate]                 DATETIME      NOT NULL,
 [Type]                         CHAR (1)      NULL,
 [StockCountingId]              INT           NOT NULL,
 [ERPId]                        INT           NULL,
 [Observation]                  VARCHAR (150) NOT NULL,
 [Status]                       CHAR (1)      NULL,
 [CreatedBy]                    INT           NOT NULL,
 [CreatedDatetime]              DATETIME      NOT NULL,
 [ModifiedBy]                   INT           NULL,
 [ModifiedDatetime]             DATETIME      NULL,
 [Workstation]                  VARCHAR (20)  NOT NULL,
CONSTRAINT [PK__PhysicalStockCountingTable] PRIMARY KEY CLUSTERED ([PhysicalStockCountingId] ASC),
CONSTRAINT [FK__PhysicalStockCountingTable_InventLocation] FOREIGN KEY ([InventLocationId]) REFERENCES [dbo].[InventLocation] ([InventLocationId]),
CONSTRAINT [FK__PhysicalStockCountingTable_Location] FOREIGN KEY ([LocationId]) REFERENCES [dbo].[Location] ([LocationId])
);
GO

CREATE TABLE [dbo].[PhysicalStockCountingLine]
([PhysicalStockCountingId]	INT             NOT NULL,
 [Sequence]					INT             NOT NULL,
 [ProductId]				BIGINT          NOT NULL,
 [InventUnitId]				INT             NOT NULL,
 [StockQuantity]			NUMERIC (24, 6) NOT NULL,
 [CountedQuantity]			NUMERIC (24, 6) NOT NULL,
 [Cost]						NUMERIC (24, 6) NOT NULL,
 [Status]					[Char](1)		Collate Database_Default NULL,
 [CreatedBy]				INT				NOT NULL,
 [CreatedDatetime]			DATETIME		NOT NULL, 
 [ModifiedBy]				INT				NULL,
 [ModifiedDatetime]			DATETIME		NULL, 
 [Workstation]				VARCHAR(20)		Collate Database_Default NOT NULL,
 CONSTRAINT [PK__PhysicalStockCountingLine] PRIMARY KEY CLUSTERED ([PhysicalStockCountingId] ASC, [Sequence] ASC),
 CONSTRAINT [FK__PhysicalStockCountingLine_InventUnit] FOREIGN KEY ([InventUnitId]) REFERENCES [dbo].[InventUnit] ([InventUnitId]),
 CONSTRAINT [FK__PhysicalStockCountingLine_PhysicalStockCountingTable] FOREIGN KEY ([PhysicalStockCountingId]) REFERENCES [dbo].[PhysicalStockCountingTable] ([PhysicalStockCountingId]),
 CONSTRAINT [FK__PhysicalStockCountingLine_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([ProductId])
);
GO


CREATE TABLE TmpPromoReward
(PromotionId		bigint,
 RewardDate			datetime,
 CustomerId			bigint,
 ProductId			bigint,
 Quantity			numeric(18,4),
 [Percent]			numeric(18,2),
 RewardProductId	bigint,
 [QuantityReceive]	INT             NULL,
 [QuantityTotal]	INT             NULL)
GO

 CREATE TABLE [dbo].[ProductCategoryTEMP] (
    [Id]          BIGINT         NULL,
    [ParentID]    BIGINT         NULL,
    [Nivel]       INT            NULL,
    [CodGrupo]    VARCHAR (4)    COLLATE Modern_Spanish_CI_AS NULL,
    [Grupo]       VARCHAR (150)  COLLATE Modern_Spanish_CI_AS NULL,
    [CodSubGrupo] VARCHAR (4)    COLLATE Modern_Spanish_CI_AS NULL,
    [SubGrupo]    VARCHAR (150)  COLLATE Modern_Spanish_CI_AS NULL,
    [path]        VARCHAR (1000) COLLATE Modern_Spanish_CI_AS NULL
);
GO

CREATE TABLE [dbo].[TransactionLog](
 [TransactionLogId]	BIGINT IDENTITY (1, 1) NOT NULL,
 [UserId]           [Int] NULL,
 [CreatedDatetime]  DATETIME NOT NULL, 
 [TrLogType]		[char](1) NULL,
 [TableName]		[varchar](50) NULL,
 [ColumnName]		[varchar](50) NULL,
 [PrimaryKey]		[varchar](50) NULL,
 [ValueBefore]		[varchar](255) NULL,
 [ValueAfter]		[varchar](255) NULL,
 [Reference]		[varchar](128) NULL,
 CONSTRAINT [PK__TransactionLog] PRIMARY KEY CLUSTERED ([TransactionLogId])) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Program](
 [ProgramId]		INT			NOT NULL,
 [Name]				VARCHAR(50)	NOT NULL,
 [Description]		VARCHAR(100)NOT NULL,
 [Status]			CHAR(1)		Collate Database_Default NULL,
 [CreatedBy]		INT			NOT NULL,
 [CreatedDatetime]	DATETIME	NOT NULL, 
 [ModifiedBy]		INT			NULL,
 [ModifiedDatetime]	DATETIME	NULL, 
 [Workstation]		VARCHAR(20)	Collate Database_Default NOT NULL,
 CONSTRAINT [PK__Program] PRIMARY KEY CLUSTERED ([ProgramId]),
) ON [PRIMARY]
go

insert into [Program]
      Select  1, 'FrmAdvance', 'Registro de Anticipos',				'A', 1, GETDATE(),NULL, NULL, 'SERVER'
Union Select  2, 'FrmChangePaymMode', 'Cambiar Forma de Pago',		'A', 1, GETDATE(),NULL, NULL, 'SERVER'
Union Select  3, 'FrmClosingCashier', 'Registro de Cierre de Caja', 'A', 1, GETDATE(),NULL, NULL, 'SERVER'
Union Select  4, 'FrmInvoiceCancel', 'Anulaci n de Facturas',		'A', 1, GETDATE(),NULL, NULL, 'SERVER'
Union Select  5, 'FrmMain', 'POS',									'A', 1, GETDATE(),NULL, NULL, 'SERVER'
Union Select  6, 'FrmPartialClosing', 'Registro de Cierre Parcial', 'A', 1, GETDATE(),NULL, NULL, 'SERVER'
Union Select  7, 'FrmPhysicalStockCount', 'Contep de Inventario',	'A', 1, GETDATE(),NULL, NULL, 'SERVER'
Union Select  8, 'FrmRedeemGiftCard', 'Canjear Bonos',				'A', 1, GETDATE(),NULL, NULL, 'SERVER'
Union Select  9, 'FrmReturns', 'Ingresar Devoluciones',				'A', 1, GETDATE(),NULL, NULL, 'SERVER'
Union Select 10, 'FrmSalesOrder', 'Ingresar Ordenes de Pedidos',	'A', 1, GETDATE(),NULL, NULL, 'SERVER'
Union Select 11, 'FrmSalesOrderPicker', 'Consultar Ordenes Pedidos', 'A', 1, GETDATE(),NULL, NULL, 'SERVER'

go

CREATE TABLE [dbo].[UserProfile](
 [UserProfileId]	INT			NOT NULL,
 [Name]				VARCHAR(50)	NOT NULL,
 [Status]			CHAR(1)		Collate Database_Default NULL,
 [CreatedBy]		INT			NOT NULL,
 [CreatedDatetime]	DATETIME	NOT NULL, 
 [ModifiedBy]		INT			NULL,
 [ModifiedDatetime]	DATETIME	NULL, 
 [Workstation]		VARCHAR(20)	Collate Database_Default NOT NULL,
 CONSTRAINT [PK__UserProfile] PRIMARY KEY CLUSTERED ([UserProfileId]),
) ON [PRIMARY]
go

insert into UserProfile
      Select  1, 'ADMINISTRADOR SISTEMAS'     , 'A', 1, GETDATE(),NULL, NULL, 'SERVER'
Union Select  2, 'ADMINISTRADOR SUPERMERCADOS', 'A', 1, GETDATE(),NULL, NULL, 'SERVER'
Union Select  3, 'CAJERO SUPERMERCADOS'       , 'A', 1, GETDATE(),NULL, NULL, 'SERVER'
Union Select  4, 'MARKETING'				  , 'A', 1, GETDATE(),NULL, NULL, 'SERVER'
go

CREATE TABLE [dbo].[UserProfileProgram](
 [UserProfileId]	INT		NOT NULL,
 [ProgramId]		INT		NOT NULL,
 [Status]			CHAR(1)	Collate Database_Default NULL,
 CONSTRAINT [PK__UserProfileProgram] PRIMARY KEY CLUSTERED ([UserProfileId], [ProgramId]),
 CONSTRAINT [FK__UserProfileProgram_UserProfile] FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([UserProfileId]),
 CONSTRAINT [FK__UserProfileProgram_Program] FOREIGN KEY ([ProgramId]) REFERENCES [Program] ([ProgramId]),
) ON [PRIMARY]
go


CREATE TABLE [dbo].[UserLoginUserProfile](
 [UserId]			INT		NOT NULL,
 [UserProfileId]	INT		NOT NULL,
 [Status]			CHAR(1)	Collate Database_Default NULL,
 CONSTRAINT [PK__UserLoginUserProfile] PRIMARY KEY CLUSTERED ([UserId], [UserProfileId]),
 CONSTRAINT [FK__UserLoginUserProfile_UserLogin] FOREIGN KEY ([UserId]) REFERENCES [UserLogin] ([UserId]),
 CONSTRAINT [FK__UserLoginUserProfile_UserProfile] FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([UserProfileId]),
) ON [PRIMARY]
go

