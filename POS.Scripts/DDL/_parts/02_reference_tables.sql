/* =====================================================================
   DDL PART 02 - Tablas de referencia / catalogos base
   Incluye: GlobalParameter, Country, Province, City, Server,
            UserLogin, Supervisor, Bank, CreditCard, BankCreditCard,
            PaymMode, RetentionTable, TaxTable
   ===================================================================== */

USE POSDB
GO

/* ---- GlobalParameter ---- */
CREATE TABLE [dbo].[GlobalParameter]
([GlobalParameterId]	INT             NOT NULL,
 [Name]					[varchar](50)   Collate Database_Default NOT NULL,
 [Value]				[varchar](50)   Collate Database_Default NOT NULL,
 [Value2]				[varchar](50)   Collate Database_Default NOT NULL,
 [Description]			[varchar](500)  Collate Database_Default NOT NULL,
 [Status]				[Char](1)       Collate Database_Default NULL,
 [CreatedBy]			INT             NOT NULL,
 [CreatedDatetime]		DATETIME        NOT NULL,
 [ModifiedBy]			INT             NULL,
 [ModifiedDatetime]		DATETIME        NULL,
 [Workstation]			VARCHAR(20)     Collate Database_Default NOT NULL,
 CONSTRAINT [PK__GlobalParameter] PRIMARY KEY CLUSTERED ([GlobalParameterId])) ON [PRIMARY]
GO
CREATE UNIQUE INDEX Ind_GlobalParameter ON [GlobalParameter] ([Name])
GO

/* ---- Country ---- */
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
 CONSTRAINT [PK__Country] PRIMARY KEY CLUSTERED ([CountryId])) ON [PRIMARY]
GO

/* ---- Province ---- */
CREATE TABLE [dbo].[Province]
([CountryId]		INT            NOT NULL,
 [ProvinceId]		INT            NOT NULL,
 [Name]				[varchar](50)  Collate Database_Default NULL,
 [Region]			[varchar](3)   Collate Database_Default NOT NULL,
 [Status]			[Char](1)      Collate Database_Default NULL,
 [CreatedBy]        INT            NOT NULL,
 [CreatedDatetime]  DATETIME       NOT NULL,
 [ModifiedBy]       INT            NULL,
 [ModifiedDatetime] DATETIME       NULL,
 [Workstation]      VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__Province] PRIMARY KEY CLUSTERED ([ProvinceId]),
 CONSTRAINT [FK__Province_Country] FOREIGN KEY ([CountryId]) REFERENCES [Country] ([CountryId])) ON [PRIMARY]
GO

/* ---- City ---- */
CREATE TABLE [dbo].[City]
([CityId]           INT            NOT NULL,
 [ProvinceId]       INT            NOT NULL,
 [CityCode]         INT            NOT NULL,
 [Name]             [varchar](50)  Collate Database_Default NULL,
 [Status]           [Char](1)      Collate Database_Default NULL,
 [CreatedBy]		INT            NOT NULL,
 [CreatedDatetime]	DATETIME       NOT NULL,
 [ModifiedBy]       INT            NULL,
 [ModifiedDatetime] DATETIME       NULL,
 [Workstation]      VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__City] PRIMARY KEY CLUSTERED ([CityId]),
 CONSTRAINT [FK__City_Province] FOREIGN KEY ([ProvinceId]) REFERENCES [Province] ([ProvinceId])) ON [PRIMARY]
GO
CREATE UNIQUE INDEX Ind_City ON [City] ([ProvinceId], [CityCode])
GO

/* ---- Server ---- */
CREATE TABLE [dbo].[Server]
([ServerId]			[Int]          NOT NULL,
 [Name]				[varchar](50)  NOT NULL,
 [IsCentral]		BIT            NOT NULL,
 [IsLocal]			BIT            NOT NULL,
 [Status]			[Char](1)      Collate Database_Default NULL,
 [CreatedBy]		INT            NOT NULL,
 [CreatedDatetime]	DATETIME       NOT NULL,
 [ModifiedBy]       INT            NULL,
 [ModifiedDatetime] DATETIME       NULL,
 [Workstation]      VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__Server] PRIMARY KEY CLUSTERED ([ServerId])) ON [PRIMARY]
GO
CREATE UNIQUE INDEX Ind_Server ON [Server] ([Name])
GO

/* ---- UserLogin ---- */
CREATE TABLE [dbo].[UserLogin]
([UserId]            [Int]          NOT NULL,
 [UserName]          [varchar](20)  NOT NULL,
 [Lastname]          [varchar](150) Collate Database_Default NOT NULL,
 [Firtsname]         [varchar](150) Collate Database_Default NOT NULL,
 [IsProfile]         [Bit]          NOT NULL,
 [IsAdministrator]   [Bit]          NOT NULL,
 [Type]              [char](1)      NOT NULL,
 [Password]          varbinary(150) NOT NULL,
 [Email]             [varchar](60)  Collate Database_Default NOT NULL,
 [Status]            [Char](1)      Collate Database_Default NULL,
 [CreatedBy]         INT            NOT NULL,
 [CreatedDatetime]   DATETIME       NOT NULL,
 [ModifiedBy]        INT            NULL,
 [ModifiedDatetime]  DATETIME       NULL,
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__UserLogin] PRIMARY KEY CLUSTERED ([UserId])) ON [PRIMARY]
GO
CREATE UNIQUE INDEX Ind_User ON [UserLogin] ([UserName])
GO

/* ---- Supervisor ---- */
CREATE TABLE [dbo].[Supervisor]
([UserId]              [Int]          NOT NULL,
 [PasswordId]          [Int]          NOT NULL,
 [barcode]             [varchar](20)  Collate Database_Default NOT NULL,
 [Status]              [Char](1)      Collate Database_Default NULL,
 [AllowEmployeeCredit] BIT            NOT NULL,  /* NOTA: coma faltante corregida */
 [CreatedBy]           INT            NOT NULL,
 [CreatedDatetime]     DATETIME       NOT NULL,
 [ModifiedBy]          INT            NULL,
 [ModifiedDatetime]    DATETIME       NULL,
 [Workstation]         VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__Supervisor] PRIMARY KEY CLUSTERED ([UserId], [PasswordId]),
 CONSTRAINT [FK__Supervisor_UserLogin] FOREIGN KEY ([UserId]) REFERENCES [UserLogin] ([UserId])
) ON [PRIMARY]
GO
CREATE UNIQUE INDEX Ind_Supervisor ON [Supervisor] ([barcode])
GO

/* ---- Bank ---- */
CREATE TABLE [dbo].[Bank]
([BankId]			[INT]          NOT NULL,
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
GO

/* ---- CreditCard ---- */
CREATE TABLE [dbo].[CreditCard]
([CreditCardId]		[INT]          NOT NULL,
 [Name]				[varchar](150) Collate Database_Default NOT NULL,
 [SAPCode]			[varchar](20)  Collate Database_Default NOT NULL,
 [IsCredit]			[Bit]          NULL,
 [Status]			[Char](1)      Collate Database_Default NULL,
 [CreatedBy]        INT            NOT NULL,
 [CreatedDatetime]  DATETIME       NOT NULL,
 [ModifiedBy]       INT            NULL,
 [ModifiedDatetime] DATETIME       NULL,
 [Workstation]      VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__CreditCard] PRIMARY KEY CLUSTERED ([CreditCardId])) ON [PRIMARY]
GO

/* ---- BankCreditCard ---- */
CREATE TABLE [dbo].[BankCreditCard]
([BankId]			[INT]          NOT NULL,
 [CreditCardId]		[INT]          NOT NULL,
 [Status]			[Char](1)      Collate Database_Default NULL,
 [CreatedBy]        INT            NOT NULL,
 [CreatedDatetime]  DATETIME       NOT NULL,
 [ModifiedBy]       INT            NULL,
 [ModifiedDatetime] DATETIME       NULL,
 [Workstation]      VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__BankCreditCard] PRIMARY KEY CLUSTERED ([BankId], [CreditCardId]),
 CONSTRAINT [FK__BankCreditCard_Bank]       FOREIGN KEY ([BankId])       REFERENCES [Bank]       ([BankId]),
 CONSTRAINT [FK__BankCreditCard_CreditCard] FOREIGN KEY ([CreditCardId]) REFERENCES [CreditCard] ([CreditCardId])) ON [PRIMARY]
GO

/* ---- PaymMode ---- */
CREATE TABLE [dbo].[PaymMode]
([PaymModeId]		[Int]          NOT NULL,
 [Name]				[varchar](150) Collate Database_Default NOT NULL,
 [SAPCode]			[varchar](20)  Collate Database_Default NOT NULL,
 [UseRetention]		[Bit]          NULL,
 [UseFinanceSystem]	[Bit]          NULL,
 [Status]			[Char](1)      Collate Database_Default NULL,
 [CreatedBy]        INT            NOT NULL,
 [CreatedDatetime]  DATETIME       NOT NULL,
 [ModifiedBy]       INT            NULL,
 [ModifiedDatetime] DATETIME       NULL,
 [Workstation]      VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__PaymMode] PRIMARY KEY CLUSTERED ([PaymModeId])) ON [PRIMARY]
GO

/* ---- RetentionTable ---- */
CREATE TABLE [dbo].[RetentionTable]
([RetentionCode]	INT             NOT NULL,
 [Name]				[varchar](150)  Collate Database_Default NOT NULL,
 [SAPCode]			[varchar](20)   Collate Database_Default NOT NULL,
 [Percent]			[NUMERIC](18,2) NOT NULL,
 [Type]				[VARCHAR](5)    Collate Database_Default NULL,
 [Status]			[Char](1)       Collate Database_Default NULL,
 [CreatedBy]        INT             NOT NULL,
 [CreatedDatetime]  DATETIME        NOT NULL,
 [ModifiedBy]       INT             NULL,
 [ModifiedDatetime] DATETIME        NULL,
 [Workstation]      VARCHAR(20)     Collate Database_Default NOT NULL,
 CONSTRAINT [PK__RetentionTable] PRIMARY KEY CLUSTERED ([RetentionCode])) ON [PRIMARY]
GO

/* ---- TaxTable ---- */
CREATE TABLE [dbo].[TaxTable]
([TaxId]             [Int]           NOT NULL,
 [Name]              [varchar](150)  Collate Database_Default NOT NULL,
 [TaxValue]          [NUMERIC](18,2) NOT NULL,
 [Status]            [Char](1)       Collate Database_Default NULL,
 [CreatedBy]         INT             NOT NULL,
 [CreatedDatetime]   DATETIME        NOT NULL,
 [ModifiedBy]        INT             NULL,
 [ModifiedDatetime]  DATETIME        NULL,
 [Workstation]       VARCHAR(20)     Collate Database_Default NOT NULL,
 CONSTRAINT [PK__TaxTable] PRIMARY KEY CLUSTERED ([TaxId])) ON [PRIMARY]
GO
