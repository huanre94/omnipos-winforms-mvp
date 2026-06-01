-- ============================================================
-- Create Tables Script (Combined DDL)
-- POSDB — Full schema: tables, constraints, indexes
--
-- Composed from DDL/_parts/ in order:
--   01_database.sql            Database creation
--   02_reference_tables.sql    Reference / lookup tables
--   03_company_customers.sql   Transport, Company, Location, Customers, Vendor, Brand
--   04_inventory.sql           Inventory locations, units, products
--   05_promotions_cards_sequences.sql  Promotions, Cards, EmissionPoint, Sequences
--   06_pos_sales_invoice.sql   Currency, Closing, SalesOrder, Invoice, AR
--   07_giftcard_logs_misc.sql  GiftCard, SalesRemission, Logs, Programs, UserProfile
--
-- NOTE: Run this script BEFORE Insert Data Script.sql
-- ============================================================

-- ============================================================
-- PART 01: Database
-- ============================================================

USE MASTER
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = N'POSDB')
BEGIN
    ALTER DATABASE POSDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE POSDB;
END
GO

CREATE DATABASE POSDB
    ON  (NAME = POSDB_Data, FILENAME = '/var/opt/mssql/data/POSDB.mdf')
    LOG ON (NAME = POSDB_Log,  FILENAME = '/var/opt/mssql/data/POSDB_log.ldf')
    COLLATE SQL_Latin1_General_CP1_CI_AS
GO

USE POSDB
GO

ALTER DATABASE POSDB SET RECOVERY SIMPLE
GO

-- ============================================================
-- PART 02: Reference / Lookup Tables
-- ============================================================

CREATE TABLE [dbo].[GlobalParameter]
([GlobalParameterId]    INT             NOT NULL,
 [Name]                 [varchar](50)   Collate Database_Default NOT NULL,
 [Value]                [varchar](50)   Collate Database_Default NOT NULL,
 [Value2]               [varchar](50)   Collate Database_Default NOT NULL,
 [Description]          [varchar](500)  Collate Database_Default NOT NULL,
 [Status]               [Char](1)       Collate Database_Default NULL,
 [CreatedBy]            INT             NOT NULL,
 [CreatedDatetime]      DATETIME        NOT NULL,
 [ModifiedBy]           INT             NULL,
 [ModifiedDatetime]     DATETIME        NULL,
 [Workstation]          VARCHAR(20)     Collate Database_Default NOT NULL,
 CONSTRAINT [PK__GlobalParameter] PRIMARY KEY CLUSTERED ([GlobalParameterId])
) ON [PRIMARY]
GO
CREATE UNIQUE INDEX Ind_GlobalParameter ON [GlobalParameter] ([Name])
GO

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
 CONSTRAINT [PK__Country] PRIMARY KEY CLUSTERED ([CountryId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Province]
([CountryId]         INT            NOT NULL,
 [ProvinceId]        INT            NOT NULL,
 [Name]              [varchar](50)  Collate Database_Default NULL,
 [Region]            [varchar](3)   Collate Database_Default NOT NULL,
 [Status]            [Char](1)      Collate Database_Default NULL,
 [CreatedBy]         INT            NOT NULL,
 [CreatedDatetime]   DATETIME       NOT NULL,
 [ModifiedBy]        INT            NULL,
 [ModifiedDatetime]  DATETIME       NULL,
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__Province] PRIMARY KEY CLUSTERED ([ProvinceId]),
 CONSTRAINT [FK__Province_Country] FOREIGN KEY ([CountryId]) REFERENCES [Country] ([CountryId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[City]
([CityId]            INT            NOT NULL,
 [ProvinceId]        INT            NOT NULL,
 [CityCode]          INT            NOT NULL,
 [Name]              [varchar](50)  Collate Database_Default NULL,
 [Status]            [Char](1)      Collate Database_Default NULL,
 [CreatedBy]         INT            NOT NULL,
 [CreatedDatetime]   DATETIME       NOT NULL,
 [ModifiedBy]        INT            NULL,
 [ModifiedDatetime]  DATETIME       NULL,
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__City] PRIMARY KEY CLUSTERED ([CityId]),
 CONSTRAINT [FK__City_Province] FOREIGN KEY ([ProvinceId]) REFERENCES [Province] ([ProvinceId])
) ON [PRIMARY]
GO
CREATE UNIQUE INDEX Ind_City ON [City] ([ProvinceId], [CityCode])
GO

CREATE TABLE [dbo].[Server]
([ServerId]          [Int]          NOT NULL,
 [Name]              [varchar](50)  NOT NULL,
 [IsCentral]         BIT            NOT NULL,
 [IsLocal]           BIT            NOT NULL,
 [Status]            [Char](1)      Collate Database_Default NULL,
 [CreatedBy]         INT            NOT NULL,
 [CreatedDatetime]   DATETIME       NOT NULL,
 [ModifiedBy]        INT            NULL,
 [ModifiedDatetime]  DATETIME       NULL,
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__Server] PRIMARY KEY CLUSTERED ([ServerId])
) ON [PRIMARY]
GO
CREATE UNIQUE INDEX Ind_Server ON [Server] ([Name])
GO

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
 CONSTRAINT [PK__UserLogin] PRIMARY KEY CLUSTERED ([UserId])
) ON [PRIMARY]
GO
CREATE UNIQUE INDEX Ind_User ON [UserLogin] ([UserName])
GO

CREATE TABLE [dbo].[Supervisor]
([UserId]               [Int]          NOT NULL,
 [PasswordId]           [Int]          NOT NULL,
 [barcode]              [varchar](20)  Collate Database_Default NOT NULL,
 [Status]               [Char](1)      Collate Database_Default NULL,
 [AllowEmployeeCredit]  BIT            NOT NULL,
 [CreatedBy]            INT            NOT NULL,
 [CreatedDatetime]      DATETIME       NOT NULL,
 [ModifiedBy]           INT            NULL,
 [ModifiedDatetime]     DATETIME       NULL,
 [Workstation]          VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__Supervisor] PRIMARY KEY CLUSTERED ([UserId], [PasswordId]),
 CONSTRAINT [FK__Supervisor_UserLogin] FOREIGN KEY ([UserId]) REFERENCES [UserLogin] ([UserId])
) ON [PRIMARY]
GO
CREATE UNIQUE INDEX Ind_Supervisor ON [Supervisor] ([barcode])
GO

CREATE TABLE [dbo].[Bank]
([BankId]            [INT]          NOT NULL,
 [Name]              [varchar](150) Collate Database_Default NOT NULL,
 [SAPCode]           [varchar](20)  Collate Database_Default NOT NULL,
 [GaranchekCode]     [INT]          NOT NULL,
 [Status]            [Char](1)      Collate Database_Default NULL,
 [CreatedBy]         INT            NOT NULL,
 [CreatedDatetime]   DATETIME       NOT NULL,
 [ModifiedBy]        INT            NULL,
 [ModifiedDatetime]  DATETIME       NULL,
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__Bank] PRIMARY KEY CLUSTERED ([BankId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CreditCard]
([CreditCardId]      [INT]          NOT NULL,
 [Name]              [varchar](150) Collate Database_Default NOT NULL,
 [SAPCode]           [varchar](20)  Collate Database_Default NOT NULL,
 [IsCredit]          [Bit]          NULL,
 [Status]            [Char](1)      Collate Database_Default NULL,
 [CreatedBy]         INT            NOT NULL,
 [CreatedDatetime]   DATETIME       NOT NULL,
 [ModifiedBy]        INT            NULL,
 [ModifiedDatetime]  DATETIME       NULL,
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__CreditCard] PRIMARY KEY CLUSTERED ([CreditCardId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[BankCreditCard]
([BankId]            [INT]          NOT NULL,
 [CreditCardId]      [INT]          NOT NULL,
 [Status]            [Char](1)      Collate Database_Default NULL,
 [CreatedBy]         INT            NOT NULL,
 [CreatedDatetime]   DATETIME       NOT NULL,
 [ModifiedBy]        INT            NULL,
 [ModifiedDatetime]  DATETIME       NULL,
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__BankCreditCard] PRIMARY KEY CLUSTERED ([BankId], [CreditCardId]),
 CONSTRAINT [FK__BankCreditCard_Bank]       FOREIGN KEY ([BankId])       REFERENCES [Bank]       ([BankId]),
 CONSTRAINT [FK__BankCreditCard_CreditCard] FOREIGN KEY ([CreditCardId]) REFERENCES [CreditCard] ([CreditCardId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[PaymMode]
([PaymModeId]        [Int]          NOT NULL,
 [Name]              [varchar](150) Collate Database_Default NOT NULL,
 [SAPCode]           [varchar](20)  Collate Database_Default NOT NULL,
 [UseRetention]      [Bit]          NULL,
 [UseFinanceSystem]  [Bit]          NULL,
 [Status]            [Char](1)      Collate Database_Default NULL,
 [CreatedBy]         INT            NOT NULL,
 [CreatedDatetime]   DATETIME       NOT NULL,
 [ModifiedBy]        INT            NULL,
 [ModifiedDatetime]  DATETIME       NULL,
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__PaymMode] PRIMARY KEY CLUSTERED ([PaymModeId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[RetentionTable]
([RetentionCode]     INT             NOT NULL,
 [Name]              [varchar](150)  Collate Database_Default NOT NULL,
 [SAPCode]           [varchar](20)   Collate Database_Default NOT NULL,
 [Percent]           [NUMERIC](18,2) NOT NULL,
 [Type]              [VARCHAR](5)    Collate Database_Default NULL,
 [Status]            [Char](1)       Collate Database_Default NULL,
 [CreatedBy]         INT             NOT NULL,
 [CreatedDatetime]   DATETIME        NOT NULL,
 [ModifiedBy]        INT             NULL,
 [ModifiedDatetime]  DATETIME        NULL,
 [Workstation]       VARCHAR(20)     Collate Database_Default NOT NULL,
 CONSTRAINT [PK__RetentionTable] PRIMARY KEY CLUSTERED ([RetentionCode])
) ON [PRIMARY]
GO

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
 CONSTRAINT [PK__TaxTable] PRIMARY KEY CLUSTERED ([TaxId])
) ON [PRIMARY]
GO

-- ============================================================
-- PART 03: Transport, Company, Location, Customers, Vendor, Brand
-- ============================================================

CREATE TABLE [dbo].[Transport]
([TransportId]       [Int]           NOT NULL,
 [LicencePlate]      VARCHAR(10)     Collate Database_Default NOT NULL,
 [Description]       [varchar](100)  NOT NULL,
 [Status]            [Char](1)       Collate Database_Default NULL,
 [CreatedBy]         INT             NOT NULL,
 [CreatedDatetime]   DATETIME        NOT NULL,
 [ModifiedBy]        INT             NULL,
 [ModifiedDatetime]  DATETIME        NULL,
 [Workstation]       VARCHAR(20)     Collate Database_Default NOT NULL,
 CONSTRAINT [PK__Transport] PRIMARY KEY CLUSTERED ([TransportId])
) ON [PRIMARY]
GO
CREATE UNIQUE INDEX Ind_Transport ON [Transport] ([LicencePlate])
GO

CREATE TABLE [dbo].[TransportDriver]
([TransportDriverId]  [Int]           NOT NULL,
 [Identification]     [varchar](20)   NOT NULL,
 [Lastname]           [varchar](150)  Collate Database_Default NOT NULL,
 [Firtsname]          [varchar](150)  Collate Database_Default NOT NULL,
 [Status]             [Char](1)       Collate Database_Default NULL,
 [CreatedBy]          INT             NOT NULL,
 [CreatedDatetime]    DATETIME        NOT NULL,
 [ModifiedBy]         INT             NULL,
 [ModifiedDatetime]   DATETIME        NULL,
 [Workstation]        VARCHAR(20)     Collate Database_Default NOT NULL,
 CONSTRAINT [PK__TransportDriver] PRIMARY KEY CLUSTERED ([TransportDriverId])
) ON [PRIMARY]
GO
CREATE UNIQUE INDEX Ind_TransportDriver ON [TransportDriver] ([Identification])
GO

CREATE TABLE [dbo].[TransportReason]
([TransportReasonId]  Int             NOT NULL,
 [Name]               [varchar](150)  Collate Database_Default NULL,
 [SAPCode]            [varchar](20)   Collate Database_Default NOT NULL,
 [Status]             [Char](1)       Collate Database_Default NULL,
 [CreatedBy]          INT             NOT NULL,
 [CreatedDatetime]    DATETIME        NOT NULL,
 [ModifiedBy]         INT             NULL,
 [ModifiedDatetime]   DATETIME        NULL,
 [Workstation]        VARCHAR(20)     Collate Database_Default NOT NULL,
 CONSTRAINT [PK__TransportReason] PRIMARY KEY CLUSTERED ([TransportReasonId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Company]
([CompanyId]             [Smallint]     NOT NULL,
 [Name]                  [varchar](250) Collate Database_Default NULL,
 [Identification]        [varchar](13)  Collate Database_Default NULL,
 [Phone]                 [varchar](10)  Collate Database_Default NULL,
 [CityId]                INT            NOT NULL,
 [Address]               [varchar](150) Collate Database_Default NULL,
 [IsTaxpayerSpecial]     [Bit]          NOT NULL,
 [HasRISE]               [Bit]          NOT NULL,
 [HasTaxback]            [Bit]          NOT NULL,
 [Status]                [Char](1)      Collate Database_Default NULL,
 [CreatedBy]             INT            NOT NULL,
 [CreatedDatetime]       DATETIME       NOT NULL,
 [ModifiedBy]            INT            NULL,
 [ModifiedDatetime]      DATETIME       NULL,
 [Workstation]           VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__Company] PRIMARY KEY CLUSTERED ([CompanyId]),
 CONSTRAINT [FK__Company_City] FOREIGN KEY ([CityId]) REFERENCES [City] ([CityId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Location]
([LocationId]        [Smallint]     NOT NULL,
 [CompanyId]         [Smallint]     NOT NULL,
 [Name]              [varchar](120) Collate Database_Default NULL,
 [Establishment]     [varchar](5)   Collate Database_Default NOT NULL,
 [Phone]             [varchar](10)  Collate Database_Default NULL,
 [CityId]            INT            NOT NULL,
 [Address]           [varchar](150) Collate Database_Default NULL,
 [IsMain]            [Bit]          NULL,
 [ServerId]          [Int]          NOT NULL,
 [Status]            [Char](1)      Collate Database_Default NULL,
 [CreatedBy]         INT            NOT NULL,
 [CreatedDatetime]   DATETIME       NOT NULL,
 [ModifiedBy]        INT            NULL,
 [ModifiedDatetime]  DATETIME       NULL,
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__Location] PRIMARY KEY CLUSTERED ([LocationId]),
 CONSTRAINT [FK__Location_Company] FOREIGN KEY ([CompanyId]) REFERENCES [Company]  ([CompanyId]),
 CONSTRAINT [FK__Location_City]    FOREIGN KEY ([CityId])    REFERENCES [City]      ([CityId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Salesman]
([SalesmanId]           INT            NOT NULL,
 [Name]                 VARCHAR(200)   NOT NULL,
 [SAPCode]              [varchar](20)  Collate Database_Default NOT NULL,
 [IsExternal]           [BIT]          NOT NULL,
 [ParentId]             INT            NOT NULL,
 [Type]                 VARCHAR(2)     NOT NULL,
 [CommissionPercent]    [numeric](18,4)NOT NULL,
 [Fulfillment]          [numeric](18,2)NOT NULL,
 [Status]               [Char](1)      Collate Database_Default NULL,
 [CreatedBy]            INT            NOT NULL,
 [CreatedDatetime]      DATETIME       NOT NULL,
 [ModifiedBy]           INT            NULL,
 [ModifiedDatetime]     DATETIME       NULL,
 [Workstation]          VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__Salesman] PRIMARY KEY CLUSTERED ([SalesmanId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CustomerType]
([CustomerTypeId]    Int            NOT NULL,
 [Name]              [varchar](220) Collate Database_Default NULL,
 [ParentId]          Int            NOT NULL,
 [Level]             Int            NOT NULL,
 [Status]            [Char](1)      Collate Database_Default NULL,
 [CreatedBy]         INT            NOT NULL,
 [CreatedDatetime]   DATETIME       NOT NULL,
 [ModifiedBy]        INT            NULL,
 [ModifiedDatetime]  DATETIME       NULL,
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__CustomerType] PRIMARY KEY CLUSTERED ([CustomerTypeId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[IdentType]
([IdentTypeId]       [Int]          NOT NULL,
 [Name]              [varchar](50)  Collate Database_Default NULL,
 [Prefix]            [Char](1)      Collate Database_Default NULL,
 [Status]            [Char](1)      Collate Database_Default NULL,
 [CreatedBy]         INT            NOT NULL,
 [CreatedDatetime]   DATETIME       NOT NULL,
 [ModifiedBy]        INT            NULL,
 [ModifiedDatetime]  DATETIME       NULL,
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__IdentType] PRIMARY KEY CLUSTERED ([IdentTypeId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Customer]
([CustomerId]           BIGINT         NOT NULL,
 [CustomerIdLocal]      BIGINT         IDENTITY NOT NULL,
 [Lastname]             [varchar](150) Collate Database_Default NOT NULL,
 [Firtsname]            [varchar](150) Collate Database_Default NOT NULL,
 [SAPCode]              [varchar](20)  Collate Database_Default NOT NULL,
 [LocationId]           SMALLINT       NOT NULL,
 [IdentTypeId]          [Int]          NOT NULL,
 [Identification]       [varchar](20)  Collate Database_Default NULL,
 [Gender]               [Varchar](1)   Collate Database_Default NULL,
 [PersonType]           [Char](1)      Collate Database_Default NOT NULL,
 [IsSpecialTaxpayer]    [Bit]          NULL,
 [IsEmployee]           [Bit]          NOT NULL,
 [EmployeeId]           INT            NOT NULL,
 [Phone]                [varchar](10)  Collate Database_Default NOT NULL,
 [Email]                [varchar](150) Collate Database_Default NOT NULL,
 [CityId]               INT            NOT NULL,
 [Address]              varchar(250)   Collate Database_Default NULL,
 [CustomerTypeId]       Int            NOT NULL,
 [UseRetention]         [Bit]          NULL,
 [IsCredit]             [Bit]          NULL,
 [CreditLimit]          NUMERIC(18, 2) NOT NULL,
 [Status]               [Char](1)      Collate Database_Default NULL,
 [CreatedBy]            INT            NOT NULL,
 [CreatedDatetime]      DATETIME       NOT NULL,
 [ModifiedBy]           INT            NULL,
 [ModifiedDatetime]     DATETIME       NULL,
 [Workstation]          VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__Customer]              PRIMARY KEY CLUSTERED ([CustomerId]),
 CONSTRAINT [FK__Customer_Location]     FOREIGN KEY ([LocationId])     REFERENCES [Location]     ([LocationId]),
 CONSTRAINT [FK__Customer_IdentType]    FOREIGN KEY ([IdentTypeId])    REFERENCES [IdentType]    ([IdentTypeId]),
 CONSTRAINT [FK__Customer_City]         FOREIGN KEY ([CityId])         REFERENCES [City]         ([CityId]),
 CONSTRAINT [FK__Customer_CustomerType] FOREIGN KEY ([CustomerTypeId]) REFERENCES [CustomerType] ([CustomerTypeId])
) ON [PRIMARY]
GO
CREATE UNIQUE INDEX Customer ON Customer([Identification])
GO
CREATE NONCLUSTERED INDEX [Ind_Customer_1] ON [dbo].[Customer]([CustomerIdLocal] ASC)
GO

CREATE TABLE [dbo].[CustomerAddress]
([CustomerAddressId]        BIGINT        NOT NULL,
 [CustomerAddressIdLocal]   BIGINT        IDENTITY (1, 1) NOT NULL,
 [CustomerId]               BIGINT        NOT NULL,
 [Sequence]                 INT           NOT NULL,
 [Address]                  VARCHAR (MAX) NOT NULL,
 [AddressReference]         VARCHAR (MAX) NOT NULL,
 [Coordinates]              VARCHAR (100) NOT NULL,
 [Telephone]                VARCHAR (100) NOT NULL,
 [Status]                   CHAR (1)      DEFAULT ('A') NULL,
 [CreatedBy]                INT           NOT NULL,
 [CreatedDatetime]          DATETIME      NOT NULL,
 [ModifiedBy]               INT           NULL,
 [ModifiedDatetime]         DATETIME      NULL,
 [Workstation]              VARCHAR(20)   Collate Database_Default NOT NULL,
 CONSTRAINT [PK__CustomerAddress]            PRIMARY KEY CLUSTERED ([CustomerAddressId]),
 CONSTRAINT [FK__CustomerAddress_Customer]   FOREIGN KEY ([CustomerId]) REFERENCES [Customer] ([CustomerId])
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [Ind_CustomerAddress_1] ON [dbo].[CustomerAddress]([CustomerAddressIdLocal] ASC)
GO
CREATE NONCLUSTERED INDEX [Ind_CustomerAddress_2] ON [dbo].[CustomerAddress]([CustomerId] ASC) INCLUDE([Sequence])
GO

CREATE TABLE [dbo].[Vendor]
([VendorId]             [INT]          NOT NULL,
 [Name]                 [varchar](150) Collate Database_Default NOT NULL,
 [SAPCode]              [varchar](20)  Collate Database_Default NOT NULL,
 [IdentTypeId]          [Int]          NOT NULL,
 [Identification]       [varchar](20)  Collate Database_Default NULL,
 [TaxpayerType]         [Char](1)      Collate Database_Default NOT NULL,
 [IsSpecialTaxpayer]    [Bit]          NULL,
 [Phone]                [varchar](10)  Collate Database_Default NOT NULL,
 [Email]                [varchar](100) Collate Database_Default NOT NULL,
 [CityId]               INT            NOT NULL,
 [Address]              varchar(250)   Collate Database_Default NULL,
 [Status]               [Char](1)      Collate Database_Default NULL,
 [CreatedBy]            INT            NOT NULL,
 [CreatedDatetime]      DATETIME       NOT NULL,
 [ModifiedBy]           INT            NULL,
 [ModifiedDatetime]     DATETIME       NULL,
 [Workstation]          VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__Vendor]            PRIMARY KEY CLUSTERED ([VendorId]),
 CONSTRAINT [FK__Vendor_CustIdType] FOREIGN KEY ([IdentTypeId]) REFERENCES [IdentType] ([IdentTypeId]),
 CONSTRAINT [FK__Vendor_City]       FOREIGN KEY ([CityId])      REFERENCES [City]      ([CityId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Brand]
([BrandId]           Int            NOT NULL,
 [Name]              [varchar](220) Collate Database_Default NULL,
 [SAPCode]           [varchar](20)  Collate Database_Default NOT NULL,
 [Status]            [Char](1)      Collate Database_Default NULL,
 [CreatedBy]         INT            NOT NULL,
 [CreatedDatetime]   DATETIME       NOT NULL,
 [ModifiedBy]        INT            NULL,
 [ModifiedDatetime]  DATETIME       NULL,
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__Brand] PRIMARY KEY CLUSTERED ([BrandId])
) ON [PRIMARY]
GO

-- ============================================================
-- PART 04: Inventory
-- ============================================================

CREATE TABLE [dbo].[InventLocation]
([InventLocationId]  INT            NOT NULL,
 [Name]              [varchar](150) Collate Database_Default NOT NULL,
 [SAPCode]           [varchar](20)  Collate Database_Default NOT NULL,
 [LocationId]        SMALLINT       NOT NULL,
 [Type]              [varchar](2)   Collate Database_Default NULL,
 [IsMain]            [Bit]          NOT NULL,
 [Status]            [Char](1)      Collate Database_Default NULL,
 [CreatedBy]         INT            NOT NULL,
 [CreatedDatetime]   DATETIME       NOT NULL,
 [ModifiedBy]        INT            NULL,
 [ModifiedDatetime]  DATETIME       NULL,
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__InventLocation]          PRIMARY KEY CLUSTERED ([InventLocationId]),
 CONSTRAINT [FK__InventLocation_Location] FOREIGN KEY ([LocationId]) REFERENCES [Location] ([LocationId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[InventTransType]
([InventTransTypeId]  Int            NOT NULL,
 [Name]               [varchar](150) Collate Database_Default NULL,
 [SAPCode]            [varchar](20)  Collate Database_Default NOT NULL,
 [Type]               [Char](1)      Collate Database_Default NOT NULL,
 [Status]             [Char](1)      Collate Database_Default NULL,
 [CreatedBy]          INT            NOT NULL,
 [CreatedDatetime]    DATETIME       NOT NULL,
 [ModifiedBy]         INT            NULL,
 [ModifiedDatetime]   DATETIME       NULL,
 [Workstation]        VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__InventTransType] PRIMARY KEY CLUSTERED ([InventTransTypeId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[InventUnit]
([InventUnitId]      Int            NOT NULL,
 [Name]              [varchar](220) Collate Database_Default NULL,
 [SAPCode]           [varchar](20)  Collate Database_Default NOT NULL,
 [WeightControl]     [Bit]          NOT NULL,
 [Status]            [Char](1)      Collate Database_Default NULL,
 [CreatedBy]         INT            NOT NULL,
 [CreatedDatetime]   DATETIME       NOT NULL,
 [ModifiedBy]        INT            NULL,
 [ModifiedDatetime]  DATETIME       NULL,
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__InventUnit] PRIMARY KEY CLUSTERED ([InventUnitId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ProductCategory]
([ProductCategoryId]  Int            NOT NULL,
 [ParentId]           Int            NOT NULL,
 [Name]               [varchar](220) Collate Database_Default NULL,
 [FriendlyName]       [varchar](220) Collate Database_Default NULL,
 [Level]              Int            NOT NULL,
 [Status]             [Char](1)      Collate Database_Default NULL,
 [CreatedBy]          INT            NOT NULL,
 [CreatedDatetime]    DATETIME       NOT NULL,
 [ModifiedBy]         INT            NULL,
 [ModifiedDatetime]   DATETIME       NULL,
 [Workstation]        VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__ProductCategory] PRIMARY KEY CLUSTERED ([ProductCategoryId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ProductGroup]
([ProductGroupId]    Int            NOT NULL,
 [Name]              [varchar](220) Collate Database_Default NULL,
 [Status]            [Char](1)      Collate Database_Default NULL,
 [CreatedBy]         INT            NOT NULL,
 [CreatedDatetime]   DATETIME       NOT NULL,
 [ModifiedBy]        INT            NULL,
 [ModifiedDatetime]  DATETIME       NULL,
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__ProductGroup] PRIMARY KEY CLUSTERED ([ProductGroupId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Product]
([ProductId]            BIGINT          NOT NULL,
 [SAPCode]              [varchar](20)   Collate Database_Default NOT NULL,
 [Name]                 [varchar](220)  Collate Database_Default NULL,
 [Description]          [varchar](150)  Collate Database_Default NOT NULL,
 [InventUnitId]         Int             NOT NULL,
 [ProductGroupId]       Int             NOT NULL,
 [ProductCategoryId]    INT             NOT NULL,
 [Type]                 [varchar](1)    Collate Database_Default NOT NULL,
 [IsDeductible]         [BIT]           NOT NULL,
 [UseTax]               [BIT]           NOT NULL,
 [UseIrbp]              [BIT]           NOT NULL,
 [IsECommerce]          [BIT]           NOT NULL,
 [UseCatchWeight]       [BIT]           NOT NULL,
 [CatchWeightMax]       [numeric](24,6) NOT NULL,
 [CatchWeightMin]       [numeric](24,6) NOT NULL,
 [VendorId]             [INT]           NULL,
 [BrandId]              [INT]           NULL,
 [ProductOldCode]       [varchar](20)   Collate Database_Default NOT NULL,
 [Status]               [Char](1)       Collate Database_Default NULL,
 [CreatedBy]            INT             NOT NULL,
 [CreatedDatetime]      DATETIME        NOT NULL,
 [ModifiedBy]           INT             NULL,
 [ModifiedDatetime]     DATETIME        NULL,
 [Workstation]          VARCHAR(20)     Collate Database_Default NOT NULL,
 CONSTRAINT [PK__Product]              PRIMARY KEY CLUSTERED ([ProductId]),
 CONSTRAINT [FK__Product_InventUnit]   FOREIGN KEY ([InventUnitId])      REFERENCES [InventUnit]      ([InventUnitId]),
 CONSTRAINT [FK__Product_ProductGroup] FOREIGN KEY ([ProductGroupId])    REFERENCES [ProductGroup]    ([ProductGroupId]),
 CONSTRAINT [FK__Product_ProductCategory] FOREIGN KEY ([ProductCategoryId]) REFERENCES [ProductCategory] ([ProductCategoryId]),
 CONSTRAINT [FK__Product_VendorId]     FOREIGN KEY ([VendorId])          REFERENCES [Vendor]          ([VendorId]),
 CONSTRAINT [FK__Product_Brand]        FOREIGN KEY ([BrandId])           REFERENCES [Brand]           ([BrandId])
) ON [PRIMARY]
GO
CREATE UNIQUE INDEX Ind_Product_ProductOldCode ON Product([ProductOldCode])
GO
CREATE NONCLUSTERED INDEX [Ind_Product_1] ON [dbo].[Product]([ModifiedDatetime] ASC) INCLUDE([Name],[InventUnitId],[ProductCategoryId],[UseTax],[IsECommerce],[ProductOldCode],[Status])
GO
CREATE NONCLUSTERED INDEX [Ind_Product_2] ON [dbo].[Product]([Name] ASC, [ProductCategoryId] ASC) INCLUDE([UseCatchWeight])
GO
CREATE NONCLUSTERED INDEX [Ind_Product_3] ON [dbo].[Product]([ProductCategoryId] ASC, [Status] ASC) INCLUDE([UseTax],[ProductOldCode])
GO

CREATE TABLE [dbo].[ProductBarcode]
([ProductId]         BIGINT           NOT NULL,
 [Barcode]           [varchar](20)    Collate Database_Default NOT NULL,
 [Quantity]          [numeric](18, 2) NOT NULL,
 [Status]            [Char](1)        Collate Database_Default NULL,
 [CreatedBy]         INT              NOT NULL,
 [CreatedDatetime]   DATETIME         NOT NULL,
 [ModifiedBy]        INT              NULL,
 [ModifiedDatetime]  DATETIME         NULL,
 [Workstation]       VARCHAR(20)      Collate Database_Default NOT NULL,
 CONSTRAINT [PK__ProductBarcode]         PRIMARY KEY CLUSTERED ([ProductId], [Barcode]),
 CONSTRAINT [FK__ProductBarcode_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([ProductId])
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [Ind_ProductBarcode_1] ON [dbo].[ProductBarcode]([Barcode] ASC)
GO

CREATE TABLE [dbo].[ProductModule]
([ProductId]         BIGINT           NOT NULL,
 [LocationId]        INT              NOT NULL,
 [Cost]              [numeric](24, 6) NOT NULL,
 [PriceReference]    [numeric](24, 6) NOT NULL,
 [Price]             [numeric](24, 6) NOT NULL,
 [TaxAmount]         [numeric](24, 6) NOT NULL,
 [IrbpAmount]        [numeric](24, 6) NOT NULL,
 [CreatedBy]         INT              NOT NULL,
 [CreatedDatetime]   DATETIME         NOT NULL,
 [ModifiedBy]        INT              NULL,
 [ModifiedDatetime]  DATETIME         NULL,
 [Workstation]       VARCHAR(20)      Collate Database_Default NOT NULL,
 CONSTRAINT [PK__ProductModule]         PRIMARY KEY CLUSTERED ([ProductId], [LocationId]),
 CONSTRAINT [FK__ProductModule_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([ProductId])
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [Ind_ProductModule_1] ON [dbo].[ProductModule]([LocationId] ASC) INCLUDE([Cost])
GO
CREATE NONCLUSTERED INDEX [Ind_ProductModule_2] ON [dbo].[ProductModule]([LocationId] ASC) INCLUDE([Cost],[Price],[ModifiedDatetime])
GO

CREATE TABLE [dbo].[InventProductLocation]
([ProductId]         BIGINT           NOT NULL,
 [LocationId]        INT              NOT NULL,
 [InventLocationId]  INT              NOT NULL,
 [MinStock]          [numeric](12, 2) NOT NULL,
 [MaxStock]          [numeric](12, 2) NOT NULL,
 [Stock]             [numeric](24, 6) NOT NULL,
 [CreatedBy]         INT              NOT NULL,
 [CreatedDateTime]   DATETIME         NOT NULL,
 [ModifiedBy]        INT              NULL,
 [ModifiedDateTime]  DATETIME         NULL,
 [Workstation]       VARCHAR(20)      Collate Database_Default NOT NULL,
 CONSTRAINT [PK__InventProductLocation]                         PRIMARY KEY CLUSTERED ([ProductId], [LocationId], [InventLocationId]),
 CONSTRAINT [FK__InventProductLocation_Product]                 FOREIGN KEY ([ProductId])        REFERENCES [Product]        ([ProductId]),
 CONSTRAINT [FK__InventProductLocation_InventLocation]          FOREIGN KEY ([InventLocationId]) REFERENCES [InventLocation] ([InventLocationId])
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [Ind_InventProductLocation_1] ON [dbo].[InventProductLocation]([LocationId] ASC, [ModifiedDateTime] ASC) INCLUDE([Stock])
GO
CREATE NONCLUSTERED INDEX [Ind_InventProductLocation_2] ON [dbo].[InventProductLocation]([ModifiedDateTime] ASC) INCLUDE([Stock])
GO

-- ============================================================
-- PART 05: Promotions, Cards, EmissionPoint, Sequences
-- ============================================================

CREATE TABLE [dbo].[PromotionType]
([PromotionTypeId]   INT            NOT NULL,
 [Name]              VARCHAR(150)   Collate Database_Default NOT NULL,
 [Type]              VARCHAR(5)     Collate Database_Default NOT NULL,
 [UseCoupon]         Bit            NOT NULL,
 [UseReward]         Bit            NOT NULL,
 [ControlCoupon]     Bit            NOT NULL,
 [Status]            CHAR(1)        NOT NULL,
 [CreatedBy]         INT            NOT NULL,
 [CreatedDatetime]   DATETIME       NOT NULL,
 [ModifiedBy]        INT            NULL,
 [ModifiedDatetime]  DATETIME       NULL,
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__PromotionType] PRIMARY KEY CLUSTERED ([PromotionTypeId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[PromotionTable]
([PromotionId]       BIGINT         NOT NULL,
 [Name]              VARCHAR(200)   Collate Database_Default NOT NULL,
 [PromotionTypeId]   INT            NOT NULL,
 [ConsumptionOrigin] CHAR(1)        NOT NULL,
 [ConsumptionMax]    NUMERIC(18, 2) NOT NULL,
 [Vigence]           DATETIME       NOT NULL,
 [Expiration]        DATETIME       NOT NULL,
 [UseMonday]         BIT            NOT NULL,
 [UseTuesday]        BIT            NOT NULL,
 [UseWednesday]      BIT            NOT NULL,
 [UseThursday]       BIT            NOT NULL,
 [UseFriday]         BIT            NOT NULL,
 [UseSaturday]       BIT            NOT NULL,
 [UseSunday]         BIT            NOT NULL,
 [Status]            [Char](1)      Collate Database_Default NULL,
 [CreatedBy]         INT            NOT NULL,
 [CreatedDatetime]   DATETIME       NOT NULL,
 [ModifiedBy]        INT            NULL,
 [ModifiedDatetime]  DATETIME       NULL,
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__PromotionTable]             PRIMARY KEY CLUSTERED ([PromotionId]),
 CONSTRAINT [FK__PromotionTable_PromotionType] FOREIGN KEY ([PromotionTypeId]) REFERENCES [PromotionType] ([PromotionTypeId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[PromotionCustomer]
([PromotionId]       BIGINT         NOT NULL,
 [Sequence]          INT            NOT NULL,
 [CustomerId]        BIGINT         NOT NULL,
 [Percent]           numeric(18,4)  NOT NULL,
 [StatusPromCust]    [Char](1)      Collate Database_Default NULL,
 [CreatedBy]         INT            NOT NULL,
 [CreatedDatetime]   DATETIME       NOT NULL,
 [ModifiedBy]        INT            NULL,
 [ModifiedDatetime]  DATETIME       NULL,
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__PromotionCustomer]                      PRIMARY KEY CLUSTERED ([PromotionId], [Sequence]),
 CONSTRAINT [FK__PromotionCustomer_PromotionTable]        FOREIGN KEY ([PromotionId]) REFERENCES [PromotionTable] ([PromotionId]),
 CONSTRAINT [FK__PromotionCustomer_Customer]              FOREIGN KEY ([CustomerId])  REFERENCES [Customer]       ([CustomerId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[PromotionPaymMode]
([PromotionId]              BIGINT         NOT NULL,
 [Sequence]                 INT            NOT NULL,
 [PaymModeId]               INT            NOT NULL,
 [BankId]                   [INT]          NOT NULL,
 [CreditCardId]             [INT]          NOT NULL,
 [Percent]                  numeric(18,4)  NOT NULL,
 [StatusPromPaym]           [Char](1)      Collate Database_Default NULL,
 [RewardMultiplierType]     varchar(1)     NOT NULL,
 [RewardMultiplierValue]    [INT]          NOT NULL,
 [CreatedBy]                INT            NOT NULL,
 [CreatedDatetime]          DATETIME       NOT NULL,
 [ModifiedBy]               INT            NULL,
 [ModifiedDatetime]         DATETIME       NULL,
 [Workstation]              VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__PromotionPaymMode]                       PRIMARY KEY CLUSTERED ([PromotionId], [Sequence]),
 CONSTRAINT [FK__PromotionPaymMode_PromotionTable]         FOREIGN KEY ([PromotionId]) REFERENCES [PromotionTable] ([PromotionId]),
 CONSTRAINT [FK__PromotionPaymMode_PaymMode]               FOREIGN KEY ([PaymModeId]) REFERENCES [PaymMode]        ([PaymModeId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[PromotionProducts]
([PromotionId]       BIGINT         NOT NULL,
 [Sequence]          INT            NOT NULL,
 [Type]              VARCHAR(5)     Collate Database_Default NOT NULL,
 [Origin]            VARCHAR(1)     Collate Database_Default NOT NULL,
 [ProductGroupId]    Int            NOT NULL,
 [ProductCategoryId] INT            NOT NULL,
 [ProductId]         BIGINT         NOT NULL,
 [Percent]           numeric(18,4)  NOT NULL,
 [AddCoupon]         BIT            NOT NULL,
 [StatusPromProd]    [Char](1)      Collate Database_Default NULL,
 [CreatedBy]         INT            NOT NULL,
 [CreatedDatetime]   DATETIME       NOT NULL,
 [ModifiedBy]        INT            NULL,
 [ModifiedDatetime]  DATETIME       NULL,
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__PromotionProducts]                       PRIMARY KEY CLUSTERED ([PromotionId], [Sequence]),
 CONSTRAINT [FK__PromotionProducts_PromotionTable]         FOREIGN KEY ([PromotionId]) REFERENCES [PromotionTable] ([PromotionId])
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [Ind_PromotionProducts_1] ON [dbo].[PromotionProducts]([Type] ASC, [StatusPromProd] ASC) INCLUDE([Origin],[ProductCategoryId],[ProductId])
GO

CREATE TABLE [dbo].[PromotionReward]
([PromotionId]       BIGINT         NOT NULL,
 [Sequence]          INT            NOT NULL,
 [ProductId]         BIGINT         NOT NULL,
 [StartRange]        NUMERIC(24, 4) NOT NULL,
 [FinalRange]        NUMERIC(24, 4) NOT NULL,
 [Percent]           NUMERIC(12, 4) NOT NULL,
 [LowInventory]      BIT            NOT NULL,
 [ProductIdReward]   BIGINT         NOT NULL,
 [QuantityReceive]   INT            NOT NULL,
 [MaxReceive]        INT            NOT NULL,
 [Caption]           VARCHAR(200)   Collate Database_Default NOT NULL,
 [TotalReward]       INT            NOT NULL,
 [StockReward]       INT            NOT NULL,
 [StatusPromRew]     [Char](1)      Collate Database_Default NULL,
 [CreatedBy]         INT            NOT NULL,
 [CreatedDatetime]   DATETIME       NOT NULL,
 [ModifiedBy]        INT            NULL,
 [ModifiedDatetime]  DATETIME       NULL,
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__PromotionReward]                         PRIMARY KEY CLUSTERED ([PromotionId], [Sequence]),
 CONSTRAINT [FK__PromotionReward_PromotionTable]           FOREIGN KEY ([PromotionId]) REFERENCES [PromotionTable] ([PromotionId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[InternalCreditCard]
([InternalCreditCardId]      BIGINT         NOT NULL,
 [InternalCreditCardIdLocal] BIGINT         NOT NULL,
 [Barcode]                   VARCHAR(25)    Collate Database_Default NOT NULL,
 [Name]                      VARCHAR(150)   Collate Database_Default NOT NULL,
 [Type]                      VARCHAR(1)     NOT NULL,
 [Vigence]                   DATETIME       NOT NULL,
 [Expiration]                DATETIME       NOT NULL,
 [CustomerId]                BIGINT         NOT NULL,
 [EmployeeId]                BIGINT         NOT NULL,
 [Quota]                     NUMERIC(18, 2) NOT NULL,
 [Consumed]                  NUMERIC(18, 2) NOT NULL,
 [Printed]                   BIT            NOT NULL,
 [Status]                    [Char](1)      Collate Database_Default NULL,
 [CreatedBy]                 INT            NOT NULL,
 [CreatedDatetime]           DATETIME       NOT NULL,
 [ModifiedBy]                INT            NULL,
 [ModifiedDatetime]          DATETIME       NULL,
 [Workstation]               VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__InternalCreditCard]              PRIMARY KEY CLUSTERED ([InternalCreditCardId]),
 CONSTRAINT [FK__InternalCreditCard_Customer]      FOREIGN KEY ([CustomerId]) REFERENCES [Customer] ([CustomerId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[InternalCreditCardLine]
([InternalCreditCardId]  BIGINT   NOT NULL,
 [Sequence]              INT      NOT NULL,
 [PromotionId]           BIGINT   NOT NULL,
 [CreatedBy]             INT      NOT NULL,
 [CreatedDatetime]       DATETIME NOT NULL,
 [ModifiedBy]            INT      NULL,
 [ModifiedDatetime]      DATETIME NULL,
 [Workstation]           VARCHAR(20) Collate Database_Default NOT NULL,
 CONSTRAINT [PK__InternalCreditCardLine]                            PRIMARY KEY CLUSTERED ([InternalCreditCardId], [Sequence]),
 CONSTRAINT [FK__InternalCreditCardLine_InternalCreditCard]         FOREIGN KEY ([InternalCreditCardId]) REFERENCES [InternalCreditCard] ([InternalCreditCardId]),
 CONSTRAINT [FK__InternalCreditCardLine_PromotionTable]             FOREIGN KEY ([PromotionId])          REFERENCES [PromotionTable]      ([PromotionId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[EmissionPoint]
([EmissionPointId]    INT           NOT NULL,
 [LocationId]         SMALLINT      NOT NULL,
 [InventLocationId]   INT           NOT NULL,
 [Establishment]      [varchar](5)  Collate Database_Default NOT NULL,
 [Emission]           [varchar](5)  Collate Database_Default NOT NULL,
 [Name]               VARCHAR(100)  Collate Database_Default NOT NULL,
 [AddressIP]          VARCHAR(20)   Collate Database_Default NOT NULL,
 [ScaleName]          VARCHAR(20)   Collate Database_Default NOT NULL,
 [ScaleBrand]         VARCHAR(20)   Collate Database_Default NOT NULL,
 [ScanBarcodeName]    VARCHAR(20)   Collate Database_Default NOT NULL,
 [PrinterName]        VARCHAR(20)   Collate Database_Default NOT NULL,
 [ThermalPrinter]     BIT           NOT NULL,
 [Status]             [Char](1)     Collate Database_Default NULL,
 [CreatedBy]          INT           NOT NULL,
 [CreatedDatetime]    DATETIME      NOT NULL,
 [ModifiedBy]         INT           NULL,
 [ModifiedDatetime]   DATETIME      NULL,
 [Workstation]        VARCHAR(20)   Collate Database_Default NOT NULL,
 CONSTRAINT [PK__EmissionPoint]              PRIMARY KEY CLUSTERED ([EmissionPointId]),
 CONSTRAINT [FK__EmissionPoint_Location]     FOREIGN KEY ([LocationId])       REFERENCES [Location]       ([LocationId]),
 CONSTRAINT [FK__EmissionPoint_InventLocation] FOREIGN KEY ([InventLocationId]) REFERENCES [InventLocation] ([InventLocationId])
) ON [PRIMARY]
GO
CREATE UNIQUE INDEX Ind_EmissionPoint ON EmissionPoint([LocationId], [Establishment], [Emission])
GO

CREATE TABLE [dbo].[SequenceType]
([SequenceTypeId]    Int            NOT NULL,
 [Name]              [varchar](50)  Collate Database_Default NULL,
 [Status]            [Char](1)      Collate Database_Default NULL,
 [CreatedBy]         INT            NOT NULL,
 [CreatedDatetime]   DATETIME       NOT NULL,
 [ModifiedBy]        INT            NULL,
 [ModifiedDatetime]  DATETIME       NULL,
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__SequenceType] PRIMARY KEY CLUSTERED ([SequenceTypeId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[SequenceTable]
([LocationId]        SMALLINT       NOT NULL,
 [SequenceId]        INT            NOT NULL,
 [SequenceTypeId]    INT            NOT NULL,
 [EmissionPointId]   INT            NOT NULL,
 [Sequence]          INT            NOT NULL,
 [Name]              VARCHAR(100)   Collate Database_Default NOT NULL,
 [Status]            [Char](1)      Collate Database_Default NULL,
 [CreatedBy]         INT            NOT NULL,
 [CreatedDatetime]   DATETIME       NOT NULL,
 [ModifiedBy]        INT            NULL,
 [ModifiedDatetime]  DATETIME       NULL,
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__SequenceTable]              PRIMARY KEY CLUSTERED ([LocationId], [SequenceId]),
 CONSTRAINT [FK__SequenceTable_Location]     FOREIGN KEY ([LocationId])    REFERENCES [Location]     ([LocationId]),
 CONSTRAINT [FK__SequenceTable_SequenceType] FOREIGN KEY ([SequenceTypeId]) REFERENCES [SequenceType] ([SequenceTypeId])
) ON [PRIMARY]
GO
CREATE UNIQUE INDEX Ind_SequenceTable ON [SequenceTable]([LocationId], [SequenceTypeId], [EmissionPointId])
GO

-- ============================================================
-- PART 06: Currency, Closing, SalesOrder, Invoice, AR
-- ============================================================

CREATE TABLE [dbo].[CurrencyType]
([CurrencyTypeId]    INT            NOT NULL,
 [Name]              VARCHAR(100)   Collate Database_Default NOT NULL,
 [Active]            BIT            NOT NULL,
 [Status]            [Char](1)      Collate Database_Default NULL,
 [CreatedBy]         INT            NOT NULL,
 [CreatedDatetime]   DATETIME       NOT NULL,
 [ModifiedBy]        INT            NULL,
 [ModifiedDatetime]  DATETIME       NULL,
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__CurrencyType] PRIMARY KEY CLUSTERED ([CurrencyTypeId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DenominationType]
([DenominationTypeId]  INT          NOT NULL,
 [Name]                VARCHAR(100) Collate Database_Default NOT NULL,
 [Status]              [Char](1)    Collate Database_Default NULL,
 [CreatedBy]           INT          NOT NULL,
 [CreatedDatetime]     DATETIME     NOT NULL,
 [ModifiedBy]          INT          NULL,
 [ModifiedDatetime]    DATETIME     NULL,
 [Workstation]         VARCHAR(20)  Collate Database_Default NOT NULL,
 CONSTRAINT [PK__DenominationType] PRIMARY KEY CLUSTERED ([DenominationTypeId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CurrencyDenomination]
([CurrencyDenominationId]  INT            NOT NULL,
 [CurrencyTypeId]          INT            NOT NULL,
 [DenominationTypeId]      INT            NOT NULL,
 [Value]                   NUMERIC(18,2)  NOT NULL,
 [Status]                  [Char](1)      Collate Database_Default NULL,
 [CreatedBy]               INT            NOT NULL,
 [CreatedDatetime]         DATETIME       NOT NULL,
 [ModifiedBy]              INT            NULL,
 [ModifiedDatetime]        DATETIME       NULL,
 [Workstation]             VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__CurrencyDenomination]                         PRIMARY KEY CLUSTERED ([CurrencyDenominationId]),
 CONSTRAINT [FK__CurrencyDenomination_CurrencyType]            FOREIGN KEY ([CurrencyTypeId])     REFERENCES [CurrencyType]      ([CurrencyTypeId]),
 CONSTRAINT [FK__CurrencyDenomination_DenominationType]        FOREIGN KEY ([DenominationTypeId]) REFERENCES [DenominationType]  ([DenominationTypeId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ClosingCashierTable]
([ClosingCashierId]         BIGINT         NOT NULL,
 [ClosingCashierIdLocal]    BIGINT         IDENTITY NOT NULL,
 [LocationId]               SMALLINT       NOT NULL,
 [EmissionPointId]          INT            NOT NULL,
 [UserId]                   INT            NOT NULL,
 [ClosingCashierDate]       DATETIME       NOT NULL,
 [Type]                     [Char](1)      Collate Database_Default NULL,
 [ClosingCashierIdParent]   BIGINT         NOT NULL,
 [OpeningAmount]            NUMERIC(18, 2) NOT NULL,
 [Authorization]            VARCHAR(40)    Collate Database_Default NOT NULL,
 [Status]                   [Char](1)      Collate Database_Default NULL,
 [CreatedBy]                INT            NOT NULL,
 [CreatedDatetime]          DATETIME       NOT NULL,
 [ModifiedBy]               INT            NULL,
 [ModifiedDatetime]         DATETIME       NULL,
 [Workstation]              VARCHAR(20)    Collate Database_Default NOT NULL,
 [ReasonId]                 INT            NULL,
 CONSTRAINT [PK__ClosingCashierTable]                PRIMARY KEY CLUSTERED ([ClosingCashierId]),
 CONSTRAINT [FK__ClosingCashierTable_EmissionPoint]  FOREIGN KEY ([EmissionPointId]) REFERENCES [EmissionPoint] ([EmissionPointId]),
 CONSTRAINT [FK__ClosingCashierTable_Location]        FOREIGN KEY ([LocationId])      REFERENCES [Location]      ([LocationId])
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [Ind_ClosingCashierTable_1] ON [dbo].[ClosingCashierTable]([LocationId],[EmissionPointId],[UserId],[Type],[ClosingCashierIdParent],[Status],[ClosingCashierDate])
GO
CREATE NONCLUSTERED INDEX [Ind_ClosingCashierTable_2] ON [dbo].[ClosingCashierTable]([LocationId],[EmissionPointId],[UserId],[Type],[Status]) INCLUDE([ClosingCashierDate],[CreatedDatetime])
GO
CREATE NONCLUSTERED INDEX [Ind_ClosingCashierTable_3] ON [dbo].[ClosingCashierTable]([ClosingCashierIdParent],[Status])
GO
CREATE NONCLUSTERED INDEX [Ind_ClosingCashierTable_4] ON [dbo].[ClosingCashierTable]([Type],[ClosingCashierIdParent],[Status])
GO
CREATE NONCLUSTERED INDEX [Ind_ClosingCashierTable_5] ON [dbo].[ClosingCashierTable]([ClosingCashierIdLocal])
GO
CREATE NONCLUSTERED INDEX [Ind_ClosingCashierTable_6] ON [dbo].[ClosingCashierTable]([ClosingCashierDate]) INCLUDE([EmissionPointId],[UserId])
GO

CREATE TABLE [dbo].[ClosingCashierLine]
([ClosingCashierId]   BIGINT         NOT NULL,
 [Sequence]           INT            NOT NULL,
 [PaymModeId]         INT            NOT NULL,
 [CashierAmount]      NUMERIC(18, 2) NOT NULL,
 [SystemAmount]       NUMERIC(18, 2) NOT NULL,
 [Status]             [Char](1)      Collate Database_Default NULL,
 [CreatedBy]          INT            NOT NULL,
 [CreatedDatetime]    DATETIME       NOT NULL,
 [ModifiedBy]         INT            NULL,
 [ModifiedDatetime]   DATETIME       NULL,
 [Workstation]        VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__ClosingCashierLine]                         PRIMARY KEY CLUSTERED ([ClosingCashierId], [Sequence]),
 CONSTRAINT [FK__ClosingCashierLine_ClosingCashierTable]      FOREIGN KEY ([ClosingCashierId]) REFERENCES [ClosingCashierTable] ([ClosingCashierId]),
 CONSTRAINT [FK__ClosingCashierLine_PaymMode]                 FOREIGN KEY ([PaymModeId])       REFERENCES [PaymMode]            ([PaymModeId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ClosingCashierMoney]
([ClosingCashierId]          BIGINT         NOT NULL,
 [Sequence]                  INT            NOT NULL,
 [CurrencyDenominationId]    INT            NOT NULL,
 [Quantity]                  NUMERIC(18, 2) NOT NULL,
 [Status]                    [Char](1)      Collate Database_Default NULL,
 [CreatedBy]                 INT            NOT NULL,
 [CreatedDatetime]           DATETIME       NOT NULL,
 [ModifiedBy]                INT            NULL,
 [ModifiedDatetime]          DATETIME       NULL,
 [Workstation]               VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__ClosingCashierMoney]                             PRIMARY KEY CLUSTERED ([ClosingCashierId], [Sequence]),
 CONSTRAINT [FK__ClosingCashierMoney_CurrencyDenomination]        FOREIGN KEY ([CurrencyDenominationId]) REFERENCES [CurrencyDenomination] ([CurrencyDenominationId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[SalesOrigin]
([SalesOriginId]     INT            NOT NULL,
 [Name]              VARCHAR(100)   Collate Database_Default NOT NULL,
 [SalesmanId]        INT            NOT NULL,
 [IsECommerce]       [BIT]          NOT NULL,
 [AllowCredit]       [BIT]          NOT NULL,
 [Status]            [Char](1)      Collate Database_Default NULL,
 [CreatedBy]         INT            NOT NULL,
 [CreatedDatetime]   DATETIME       NOT NULL,
 [ModifiedBy]        INT            NULL,
 [ModifiedDatetime]  DATETIME       NULL,
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__SalesOrigin]              PRIMARY KEY CLUSTERED ([SalesOriginId]),
 CONSTRAINT [FK__SalesOrigin_Salesman]     FOREIGN KEY ([SalesmanId]) REFERENCES [Salesman] ([SalesmanId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[TransferStatus]
([TransferStatusId]  INT            NOT NULL,
 [Name]              [varchar](50)  Collate Database_Default NULL,
 [Status]            [Char](1)      Collate Database_Default NULL,
 [CreatedBy]         INT            NOT NULL,
 [CreatedDatetime]   DATETIME       NOT NULL,
 [ModifiedBy]        INT            NULL,
 [ModifiedDatetime]  DATETIME       NULL,
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__TransferStatus] PRIMARY KEY CLUSTERED ([TransferStatusId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[SalesOrderStatus]
([SalesOrderStatusId]  INT           NOT NULL,
 [ShortCode]           CHAR (1)      NOT NULL,
 [Name]                VARCHAR (200) NOT NULL,
 [Observation]         VARCHAR (200) NOT NULL,
 [PreviousStatus]      VARCHAR (200) NULL,
 [Status]              CHAR (1)      DEFAULT ('A') NULL,
 [CreatedBy]           INT           NOT NULL,
 [CreatedDatetime]     DATETIME      NOT NULL,
 [ModifiedBy]          INT           NULL,
 [ModifiedDatetime]    DATETIME      NULL,
 [Workstation]         VARCHAR(20)   Collate Database_Default NOT NULL,
 CONSTRAINT [PK__SalesOrderStatus] PRIMARY KEY CLUSTERED ([SalesOrderStatusId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[SalesOrder]
([SalesOrderId]          BIGINT         NOT NULL,
 [SalesOrderIdLocal]     BIGINT         IDENTITY NOT NULL,
 [LocationId]            SMALLINT       NOT NULL,
 [CustomerId]            BIGINT         NOT NULL,
 [SalesmanId]            INT            NOT NULL,
 [OrderDate]             DATETIME       NOT NULL,
 [SalesOriginId]         INT            NOT NULL,
 [OrderECommerce]        BIGINT         NOT NULL,
 [DeliveryAddress]       VARCHAR(200)   Collate Database_Default NOT NULL,
 [DeliveryDate]          DATETIME       NOT NULL,
 [Recipient]             VARCHAR(200)   Collate Database_Default NOT NULL,
 [BaseAmount]            NUMERIC(18, 4) NOT NULL,
 [BaseTaxAmount]         NUMERIC(18, 4) NOT NULL,
 [Discount]              NUMERIC(18, 4) NOT NULL,
 [TaxPercent]            NUMERIC( 5, 2) NOT NULL,
 [TaxAmount]             NUMERIC(18, 4) NOT NULL,
 [IrbpAmount]            NUMERIC(18, 4) NOT NULL,
 [Total]                 NUMERIC(18, 4) NOT NULL,
 [ShippingFree]          BIT            NOT NULL,
 [ShippingAmount]        NUMERIC(18, 2) NOT NULL,
 [Observation]           VARCHAR(250)   Collate Database_Default NOT NULL,
 [CustomerAddressId]     BIGINT         NULL,
 [OrderXml]              VARCHAR (MAX)  NULL,
 [Status]                [Char](1)      Collate Database_Default NULL,
 [CreatedBy]             INT            NOT NULL,
 [CreatedDatetime]       DATETIME       NOT NULL,
 [ModifiedBy]            INT            NULL,
 [ModifiedDatetime]      DATETIME       NULL,
 [Workstation]           VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__SalesOrder]              PRIMARY KEY CLUSTERED ([SalesOrderId]),
 CONSTRAINT [FK__SalesOrder_Location]     FOREIGN KEY ([LocationId])    REFERENCES [Location]    ([LocationId]),
 CONSTRAINT [FK__SalesOrder_Customer]     FOREIGN KEY ([CustomerId])    REFERENCES [Customer]    ([CustomerId]),
 CONSTRAINT [FK__SalesOrder_Salesman]     FOREIGN KEY ([SalesmanId])    REFERENCES [Salesman]    ([SalesmanId]),
 CONSTRAINT [FK__SalesOrder_SalesOrigin]  FOREIGN KEY ([SalesOriginId]) REFERENCES [SalesOrigin] ([SalesOriginId])
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [Ind_SalesOrder_1] ON [dbo].[SalesOrder]([CustomerId])
GO
CREATE NONCLUSTERED INDEX [Ind_SalesOrder_2] ON [dbo].[SalesOrder]([LocationId]) INCLUDE([CustomerId],[OrderDate],[SalesOriginId],[OrderECommerce],[Status])
GO
CREATE NONCLUSTERED INDEX [Ind_SalesOrder_3] ON [dbo].[SalesOrder]([LocationId],[Status]) INCLUDE([CustomerId],[OrderDate],[SalesOriginId],[OrderECommerce])
GO
CREATE NONCLUSTERED INDEX [Ind_SalesOrder_4] ON [dbo].[SalesOrder]([OrderDate],[Observation]) INCLUDE([LocationId],[CustomerId],[DeliveryAddress],[CustomerAddressId])
GO
CREATE NONCLUSTERED INDEX [Ind_SalesOrder_5] ON [dbo].[SalesOrder]([OrderECommerce])
GO
CREATE NONCLUSTERED INDEX [Ind_SalesOrder_6] ON [dbo].[SalesOrder]([SalesOrderIdLocal])
GO
CREATE NONCLUSTERED INDEX [Ind_SalesOrder_7] ON [dbo].[SalesOrder]([Status]) INCLUDE([CustomerId],[OrderDate],[SalesOriginId],[CustomerAddressId])
GO

CREATE TABLE [dbo].[SalesOrderLine]
([SalesOrderId]              BIGINT         NOT NULL,
 [Sequence]                  INT            NOT NULL,
 [ProductId]                 BIGINT         NOT NULL,
 [Barcode]                   [varchar](20)  Collate Database_Default NOT NULL,
 [InventUnitId]              Int            NOT NULL,
 [UseTax]                    [BIT]          NOT NULL,
 [TaxProductAmount]          NUMERIC(18, 4) NOT NULL,
 [DiscountProductAmount]     NUMERIC(18, 4) NOT NULL,
 [Quantity]                  NUMERIC(18, 6) NOT NULL,
 [QuantityCW]                INT            NOT NULL,
 [Returned]                  INT            NOT NULL,
 [Cost]                      NUMERIC(18, 4) NOT NULL,
 [Price]                     NUMERIC(18, 4) NOT NULL,
 [BaseAmount]                NUMERIC(18, 4) NOT NULL,
 [BaseTaxAmount]             NUMERIC(18, 4) NOT NULL,
 [LinePercent]               NUMERIC( 5, 2) NOT NULL,
 [LineDiscount]              NUMERIC(18, 4) NOT NULL,
 [TaxPercent]                NUMERIC( 5, 2) NOT NULL,
 [TaxAmount]                 NUMERIC(18, 4) NOT NULL,
 [IrbpAmount]                NUMERIC(18, 4) NOT NULL,
 [LineAmount]                NUMERIC(18, 4) NOT NULL,
 [PromotionId]               BIGINT         NOT NULL,
 [Status]                    [Char](1)      Collate Database_Default NULL,
 [CreatedBy]                 INT            NOT NULL,
 [CreatedDatetime]           DATETIME       NOT NULL,
 [ModifiedBy]                INT            NULL,
 [ModifiedDatetime]          DATETIME       NULL,
 [Workstation]               VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__SalesOrderLine]                 PRIMARY KEY CLUSTERED ([SalesOrderId], [Sequence]),
 CONSTRAINT [FK__SalesOrderLine_SalesOrder]       FOREIGN KEY ([SalesOrderId]) REFERENCES [SalesOrder] ([SalesOrderId]),
 CONSTRAINT [FK__SalesOrderLine_Product]          FOREIGN KEY ([ProductId])    REFERENCES [Product]    ([ProductId]),
 CONSTRAINT [FK__SalesOrderLine_InventUnit]       FOREIGN KEY ([InventUnitId]) REFERENCES [InventUnit] ([InventUnitId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[SalesOrderPayment]
([SalesOrderId]          BIGINT         NOT NULL,
 [Sequence]              INT            NOT NULL,
 [PaymModeId]            INT            NOT NULL,
 [Amount]                NUMERIC(18, 2) NOT NULL,
 [BankId]                INT            DEFAULT ('') NOT NULL,
 [CreditCardId]          INT            DEFAULT ('') NOT NULL,
 [LocationId]            SMALLINT       NOT NULL,
 [Received]              NUMERIC(18, 2) NOT NULL,
 [Change]                NUMERIC(18, 2) NOT NULL,
 [PaymentDate]           DATETIME       NOT NULL,
 [AccountNumber]         VARCHAR(20)    NOT NULL,
 [CkeckNumber]           INT            NOT NULL,
 [CkeckType]             VARCHAR(2)     NOT NULL,
 [CkeckDate]             DATETIME       NOT NULL,
 [CheckOwner]            VARCHAR(100)   NOT NULL,
 [Authorization]         VARCHAR(40)    NOT NULL,
 [IsProtest]             BIT            NOT NULL,
 [ProtestDate]           DATETIME       NOT NULL,
 [InternalCreditCardId]  BIGINT         NOT NULL,
 [GiftCardNumber]        VARCHAR(20)    NOT NULL,
 [RetentionCode]         INT            NOT NULL,
 [RetentionNumber]       VARCHAR(15)    NOT NULL,
 [Status]                [Char](1)      Collate Database_Default NULL,
 [CreatedBy]             INT            NOT NULL,
 [CreatedDatetime]       DATETIME       NOT NULL,
 [ModifiedBy]            INT            NULL,
 [ModifiedDatetime]      DATETIME       NULL,
 [Workstation]           VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__SalesOrderPayment]              PRIMARY KEY CLUSTERED ([SalesOrderId], [Sequence]),
 CONSTRAINT [FK__SalesOrderPayment_SalesOrder]    FOREIGN KEY ([SalesOrderId]) REFERENCES [SalesOrder] ([SalesOrderId]),
 CONSTRAINT [FK__SalesOrderPayment_PaymMode]      FOREIGN KEY ([PaymModeId])   REFERENCES [PaymMode]   ([PaymModeId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[SalesOrderText]
([SalesOrderId]      BIGINT         NOT NULL,
 [Sequence]          INT            NOT NULL,
 [SalesOrderText]    VARCHAR(MAX)   Collate Database_Default NULL,
 [Status]            [Char](1)      Collate Database_Default NULL,
 [CreatedBy]         INT            NOT NULL,
 [CreatedDatetime]   DATETIME       NOT NULL,
 [ModifiedBy]        INT            NULL,
 [ModifiedDatetime]  DATETIME       NULL,
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__SalesOrderText] PRIMARY KEY CLUSTERED ([SalesOrderId], [Sequence]),
 CONSTRAINT [FK__SalesOrderText_SalesOrder] FOREIGN KEY ([SalesOrderId]) REFERENCES [SalesOrder] ([SalesOrderId])
) ON [PRIMARY]
GO

/* ---- InvoiceTable ---- */
CREATE TABLE [dbo].[InvoiceTable]
([InvoiceId]			BIGINT         NOT NULL,
 [InvoiceIdLocal]		BIGINT         IDENTITY NOT NULL,
 [LocationId]			SMALLINT       NOT NULL,
 [TypeDoc]				SMALLINT       NOT NULL,
 [InvoiceIdReference]	BIGINT         NOT NULL,
 [EmissionPointId]		INT            NOT NULL,
 [Establishment]		[varchar](5)   Collate Database_Default NOT NULL,
 [Emission]				[varchar](5)   Collate Database_Default NOT NULL,
 [InvoiceNumber]		BIGINT         NOT NULL,
 [CustomerId]			BIGINT         NOT NULL,
 [SalesmanId]			INT            NOT NULL,
 [IsCredit]				[BIT]          NOT NULL,
 [InvoiceDate]			DATETIME       NOT NULL,
 [Expiration]			DATETIME       NOT NULL,
 [BaseAmount]			NUMERIC(18,4)  NOT NULL,
 [BaseTaxAmount]		NUMERIC(18,4)  NOT NULL,
 [Discount]				NUMERIC(18,4)  NOT NULL,
 [TaxPercent]			NUMERIC(5,2)   NOT NULL,
 [TaxAmount]			NUMERIC(18,4)  NOT NULL,
 [IrbpAmount]			NUMERIC(18,4)  NOT NULL,
 [Total]				NUMERIC(18,4)  NOT NULL,
 [ShippingFree]			BIT            NOT NULL,
 [ShippingAmount]		NUMERIC(18,2)  NOT NULL,
 [Returned]				NUMERIC(18,2)  NOT NULL,
 [SalesOriginId]		INT            NOT NULL,
 [IsECommerce]			BIT            NOT NULL,
 [SalesOrderId]			BIGINT         NOT NULL,
 [ClosingCashierId]		BIGINT         NOT NULL,
 [Observation]			VARCHAR(250)   Collate Database_Default NOT NULL,
 [KeyAccessSri]         VARCHAR(50)    Collate Database_Default NOT NULL,
 [TransferStatusId]		INT            NOT NULL,
 [Status]				[Char](1)      Collate Database_Default NULL,
 [CreatedBy]			INT            NOT NULL,
 [CreatedDatetime]		DATETIME       NOT NULL,
 [ModifiedBy]			INT            NULL,
 [ModifiedDatetime]		DATETIME       NULL,
 [Workstation]			VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__InvoiceTable] PRIMARY KEY CLUSTERED ([InvoiceId]),
 CONSTRAINT [FK__InvoiceTable_Location]       FOREIGN KEY ([LocationId])       REFERENCES [Location]       ([LocationId]),
 CONSTRAINT [FK__InvoiceTable_Customer]       FOREIGN KEY ([CustomerId])       REFERENCES [Customer]       ([CustomerId]),
 CONSTRAINT [FK__InvoiceTable_Salesman]       FOREIGN KEY ([SalesmanId])       REFERENCES [Salesman]       ([SalesmanId]),
 CONSTRAINT [FK__InvoiceTable_EmissionPoint]  FOREIGN KEY ([EmissionPointId])  REFERENCES [EmissionPoint]  ([EmissionPointId]),
 CONSTRAINT [FK__InvoiceTable_SalesOrigin]    FOREIGN KEY ([SalesOriginId])    REFERENCES [SalesOrigin]    ([SalesOriginId]),
 CONSTRAINT [FK__InvoiceTable_TransferStatus] FOREIGN KEY ([TransferStatusId]) REFERENCES [TransferStatus] ([TransferStatusId])
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_1]  ON [dbo].[InvoiceTable] ([InvoiceIdLocal] ASC)
GO
CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_2]  ON [dbo].[InvoiceTable] ([ClosingCashierId] ASC, [Status] ASC) INCLUDE ([LocationId], [EmissionPointId], [InvoiceDate], [CreatedBy])
GO
CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_5]  ON [dbo].[InvoiceTable] ([CustomerId] ASC)
GO
CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_13] ON [dbo].[InvoiceTable] ([EmissionPointId] ASC) INCLUDE ([InvoiceNumber])
GO
CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_16] ON [dbo].[InvoiceTable] ([EmissionPointId] ASC, [InvoiceNumber] ASC)
GO
CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_34] ON [dbo].[InvoiceTable] ([SalesOrderId] ASC) INCLUDE ([Establishment], [Emission], [InvoiceNumber])
GO
CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_36] ON [dbo].[InvoiceTable] ([SalesOrderId] ASC, [Status] ASC)
GO
CREATE NONCLUSTERED INDEX [Ind_InvoiceTable_39] ON [dbo].[InvoiceTable] ([TransferStatusId] ASC, [InvoiceDate] ASC)
GO

/* ---- InvoiceLine ---- */
CREATE TABLE [dbo].[InvoiceLine]
([InvoiceId]				BIGINT         NOT NULL,
 [Sequence]					INT            NOT NULL,
 [ProductId]				BIGINT         NOT NULL,
 [Barcode]					[varchar](20)  Collate Database_Default NOT NULL,
 [InventUnitId]				Int            NOT NULL,
 [IsDeductible]				BIT            NOT NULL,
 [UseTax]					BIT            NOT NULL,
 [TaxProductAmount]			NUMERIC(18,4)  NOT NULL,
 [DiscountProductAmount]	NUMERIC(18,4)  NOT NULL,
 [Quantity]					NUMERIC(18,6)  NOT NULL,
 [QuantityCW]				INT            NOT NULL,
 [Returned]					INT            NOT NULL,
 [Cost]						NUMERIC(18,4)  NOT NULL,
 [Price]					NUMERIC(18,4)  NOT NULL,
 [BaseAmount]				NUMERIC(18,4)  NOT NULL,
 [BaseTaxAmount]			NUMERIC(18,4)  NOT NULL,
 [LinePercent]				NUMERIC(5,2)   NOT NULL,
 [LineDiscount]				NUMERIC(18,4)  NOT NULL,
 [TaxPercent]				NUMERIC(5,2)   NOT NULL,
 [TaxAmount]				NUMERIC(18,4)  NOT NULL,
 [IrbpAmount]				NUMERIC(18,4)  NOT NULL,
 [LineAmount]				NUMERIC(18,4)  NOT NULL,
 [PromotionId]				BIGINT         NOT NULL,
 [Status]					[Char](1)      Collate Database_Default NULL,
 [CreatedBy]				INT            NOT NULL,
 [CreatedDatetime]			DATETIME       NOT NULL,
 [ModifiedBy]				INT            NULL,
 [ModifiedDatetime]			DATETIME       NULL,
 [Workstation]				VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__InvoiceLine] PRIMARY KEY CLUSTERED ([InvoiceId], [Sequence]),
 CONSTRAINT [FK__InvoiceLine_InvoiceTable] FOREIGN KEY ([InvoiceId])    REFERENCES [InvoiceTable] ([InvoiceId]),
 CONSTRAINT [FK__InvoiceLine_Product]      FOREIGN KEY ([ProductId])    REFERENCES [Product]      ([ProductId]),
 CONSTRAINT [FK__InvoiceLine_InventUnit]   FOREIGN KEY ([InventUnitId]) REFERENCES [InventUnit]   ([InventUnitId])
) ON [PRIMARY]
GO

/* ---- InvoicePayment ---- */
CREATE TABLE [dbo].[InvoicePayment]
([InvoiceId]            BIGINT         NOT NULL,
 [LocationId]           SMALLINT       NOT NULL,
 [Sequence]             INT            NOT NULL,
 [PaymModeId]           INT            NOT NULL,
 [Amount]               NUMERIC(18,2)  NOT NULL,
 [Received]				NUMERIC(18,2)  NOT NULL,
 [Change]				NUMERIC(18,2)  NOT NULL,
 [PaymentDate]			DATETIME       NOT NULL,
 [BankId]               INT            NOT NULL,
 [CreditCardId]         INT            NOT NULL,
 [AccountNumber]        VARCHAR(20)    Collate Database_Default NOT NULL,
 [CkeckNumber]          INT            NOT NULL,
 [CkeckType]            VARCHAR(2)     Collate Database_Default NOT NULL,
 [CkeckDate]            DATETIME       NOT NULL,
 [CheckOwner]           VARCHAR(100)   Collate Database_Default NOT NULL,
 [Authorization]        VARCHAR(40)    Collate Database_Default NOT NULL,
 [IsProtest]            BIT            NOT NULL,
 [ProtestDate]          DATETIME       NOT NULL,
 [InternalCreditCardId] BIGINT         NOT NULL,
 [GiftCardNumber]       VARCHAR(20)    NOT NULL,
 [RetentionCode]		INT            NOT NULL,
 [RetentionNumber]      VARCHAR(15)    Collate Database_Default NOT NULL,
 [Status]               [Char](1)      Collate Database_Default NULL,
 [CreatedBy]            INT            NOT NULL,
 [CreatedDatetime]      DATETIME       NOT NULL,
 [ModifiedBy]           INT            NULL,
 [ModifiedDatetime]     DATETIME       NULL,
 [Workstation]          VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__InvoicePayment] PRIMARY KEY CLUSTERED ([InvoiceId], [Sequence]),
 CONSTRAINT [FK__InvoicePayment_Location]     FOREIGN KEY ([LocationId]) REFERENCES [Location]     ([LocationId]),
 CONSTRAINT [FK__InvoicePayment_InvoiceTable] FOREIGN KEY ([InvoiceId])  REFERENCES [InvoiceTable] ([InvoiceId]),
 CONSTRAINT [FK__InvoicePayment_PaymMode]     FOREIGN KEY ([PaymModeId]) REFERENCES [PaymMode]     ([PaymModeId])
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [Ind_InvoicePayment_1] ON [dbo].[InvoicePayment] ([PaymModeId] ASC) INCLUDE ([Amount], [Authorization])
GO

/* ---- AccountsReceivable ---- */
CREATE TABLE [dbo].[AccountsReceivable]
([AccountsReceivableId]       BIGINT         NOT NULL,
 [AccountsReceivableIdLocal]  BIGINT         IDENTITY NOT NULL,
 [LocationId]                 SMALLINT       NOT NULL,
 [TypeDoc]                    SMALLINT       NOT NULL,
 [CustomerId]                 BIGINT         NOT NULL,
 [InvoiceId]                  BIGINT         NOT NULL,
 [DocNumber]                  BIGINT         NOT NULL,
 [Registration]               DATETIME       NOT NULL,
 [Expiration]                 DATETIME       NOT NULL,
 [Amount]                     NUMERIC(18,2)  NOT NULL,
 [AmountPaid]                 NUMERIC(18,2)  NOT NULL,
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
 CONSTRAINT [FK__AccountsReceivable_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [Customer] ([CustomerId])
) ON [PRIMARY]
GO

-- ============================================================
-- PART 07: GiftCard, SalesRemission, Logs, Programs, UserProfile
-- ============================================================

/* ---- GiftCardBlockTable ---- */
CREATE TABLE [dbo].[GiftCardBlockTable]
([GiftCardBlockId]	BIGINT         NOT NULL,
 [LocationId]		SMALLINT       NOT NULL,
 [Year]				INT            NOT NULL,
 [Type]				VARCHAR(2)     Collate Database_Default NOT NULL,
 [Observation]		VARCHAR(200)   Collate Database_Default NOT NULL,
 [Status]			[Char](1)      Collate Database_Default NULL,
 [CreatedBy]		INT            NOT NULL,
 [CreatedDatetime]	DATETIME       NOT NULL,
 [ModifiedBy]		INT            NULL,
 [ModifiedDatetime]	DATETIME       NULL,
 [Workstation]		VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__GiftCardBlockTable] PRIMARY KEY CLUSTERED ([GiftCardBlockId]),
 CONSTRAINT [FK__GiftCardBlockTable_Location] FOREIGN KEY ([LocationId]) REFERENCES [Location] ([LocationId])
) ON [PRIMARY]
GO

/* ---- GiftCardBlockLine ---- */
CREATE TABLE [dbo].[GiftCardBlockLine]
([GiftCardBlockId]		BIGINT    NOT NULL,
 [Sequence]				INT       NOT NULL,
 [GiftCardNumberStart]	BIGINT    NOT NULL,
 [GiftCardNumberFinal]	BIGINT    NOT NULL,
 [Status]				[Char](1) Collate Database_Default NULL,
 [CreatedBy]			INT       NOT NULL,
 [CreatedDatetime]		DATETIME  NOT NULL,
 [ModifiedBy]			INT       NULL,
 [ModifiedDatetime]		DATETIME  NULL,
 [Workstation]			VARCHAR(20) Collate Database_Default NOT NULL,
 CONSTRAINT [PK__GiftCardBlockLine] PRIMARY KEY CLUSTERED ([GiftCardBlockId], [Sequence]),
 CONSTRAINT [FK__GiftCardBlockLine_GiftCardBlockTable] FOREIGN KEY ([GiftCardBlockId]) REFERENCES [GiftCardBlockTable] ([GiftCardBlockId])
) ON [PRIMARY]
GO

/* ---- GiftCardTable ---- */
CREATE TABLE [dbo].[GiftCardTable]
([GiftCardId]           BIGINT         NOT NULL,
 [GiftCardIdLocal]      BIGINT         NOT NULL,
 [LocationId]			SMALLINT       NOT NULL,
 [LocationIdOrigin]		SMALLINT       NOT NULL,
 [Year]					INT            NOT NULL,
 [GiftCardBlockId]      BIGINT         NOT NULL,
 [Registration]			DATETIME       NOT NULL,
 [Expiration]			DATETIME       NOT NULL,
 [Type]					VARCHAR(2)     Collate Database_Default NOT NULL,
 [UseCode]				VARCHAR(4)     NOT NULL,
 [CustomerId]			BIGINT         NOT NULL,
 [InvoiceId]			BIGINT         NOT NULL,
 [GiftCardNumberStart]	BIGINT         NOT NULL,
 [GiftCardNumberFinal]  BIGINT         NOT NULL,
 [Quantity]				INT            NOT NULL,
 [Total]				NUMERIC(18,2)  NOT NULL,
 [Observation]			VARCHAR(200)   Collate Database_Default NOT NULL,
 [Status]               [Char](1)      Collate Database_Default NULL,
 [CreatedBy]            INT            NOT NULL,
 [CreatedDatetime]      DATETIME       NOT NULL,
 [ModifiedBy]           INT            NULL,
 [ModifiedDatetime]     DATETIME       NULL,
 [Workstation]          VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__GiftCardTable] PRIMARY KEY CLUSTERED ([GiftCardId]),
 CONSTRAINT [FK__GiftCardTable_Location]           FOREIGN KEY ([LocationId])       REFERENCES [Location]          ([LocationId]),
 CONSTRAINT [FK__GiftCardTable_LocationOrigin]     FOREIGN KEY ([LocationIdOrigin]) REFERENCES [Location]          ([LocationId]),
 CONSTRAINT [FK__GiftCardTable_GiftCardBlockTable] FOREIGN KEY ([GiftCardBlockId])  REFERENCES [GiftCardBlockTable] ([GiftCardBlockId]),
 CONSTRAINT [FK__GiftCardTable_Customer]           FOREIGN KEY ([CustomerId])       REFERENCES [Customer]           ([CustomerId])
) ON [PRIMARY]
GO

/* ---- GiftCardLine ---- */
CREATE TABLE [dbo].[GiftCardLine]
([GiftCardId]				BIGINT         NOT NULL,
 [Sequence]					INT            NOT NULL,
 [Year]						INT            NOT NULL,
 [GiftCardNumber]			VARCHAR(20)    NOT NULL,
 [CustomerId]				BIGINT         NOT NULL,
 [RedeemIdentification]		VARCHAR(20)    Collate Database_Default NOT NULL,
 [RedeemCustomer]			VARCHAR(200)   Collate Database_Default NOT NULL,
 [Amount]					NUMERIC(18,4)  NOT NULL,
 [AmountConsumed]			NUMERIC(18,4)  NOT NULL,
 [StatusLine]				CHAR(1)        NOT NULL,
 [CreatedBy]				INT            NOT NULL,
 [CreatedDatetime]			DATETIME       NOT NULL,
 [ModifiedBy]				INT            NULL,
 [ModifiedDatetime]			DATETIME       NULL,
 [Workstation]				VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__GiftCardLine] PRIMARY KEY CLUSTERED ([GiftCardId], [Sequence]),
 CONSTRAINT [FK__GiftCardLine_GiftCardTable] FOREIGN KEY ([GiftCardId])  REFERENCES [GiftCardTable] ([GiftCardId]),
 CONSTRAINT [FK__GiftCardLine_Customer]      FOREIGN KEY ([CustomerId])  REFERENCES [Customer]      ([CustomerId])
) ON [PRIMARY]
GO
CREATE UNIQUE INDEX Ind_GiftCardLine ON GiftCardLine ([Year], [GiftCardNumber])
GO

/* ---- GiftCardLineProduct ---- */
CREATE TABLE [dbo].[GiftCardLineProduct]
([GiftCardId]		BIGINT         NOT NULL,
 [Sequence]			INT            NOT NULL,
 [ProdSeq]			INT            NOT NULL,
 [ProductId]		BIGINT         NOT NULL,
 [Quantity]			NUMERIC(24,6)  NOT NULL,
 [Status]			[Char](1)      Collate Database_Default NULL,
 [CreatedBy]		INT            NOT NULL,
 [CreatedDatetime]	DATETIME       NOT NULL,
 [ModifiedBy]		INT            NULL,
 [ModifiedDatetime]	DATETIME       NULL,
 [Workstation]		VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__GiftCardLineProduct] PRIMARY KEY CLUSTERED ([GiftCardId], [Sequence], [ProdSeq]),
 CONSTRAINT [FK__GiftCardLineProduct_GiftCardLine] FOREIGN KEY ([GiftCardId], [Sequence]) REFERENCES [GiftCardLine] ([GiftCardId], [Sequence]),
 CONSTRAINT [FK__GiftCardLineProduct_Product]      FOREIGN KEY ([ProductId])             REFERENCES [Product]      ([ProductId])
) ON [PRIMARY]
GO

/* ---- GiftCardTrans ---- */
CREATE TABLE [dbo].[GiftCardTrans]
([GiftCardId]       BIGINT         NOT NULL,
 [Sequence]			INT            NOT NULL,
 [TrnsSeq]			INT            NOT NULL,
 [LocationIdRedeem]	SMALLINT       NOT NULL,
 [RedeemDate]		DATETIME       NOT NULL,
 [TrnsType]			VARCHAR(2)     Collate Database_Default NOT NULL,
 [TrnsStatus]		CHAR(1)        NOT NULL,
 [TrnsId]			BIGINT         NOT NULL,
 [TrnsAmount]		NUMERIC(18,4)  NOT NULL,
 [ProductId]		BIGINT         NOT NULL,
 [Quantity]			NUMERIC(24,6)  NOT NULL,
 [RedeemQuantity]	NUMERIC(24,6)  NOT NULL,
 [CreatedBy]		INT            NOT NULL,
 [CreatedDatetime]	DATETIME       NOT NULL,
 [ModifiedBy]		INT            NULL,
 [ModifiedDatetime]	DATETIME       NULL,
 [Workstation]		VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__GiftCardTrans] PRIMARY KEY CLUSTERED ([GiftCardId], [Sequence], [TrnsSeq]),
 CONSTRAINT [FK__GiftCardTrans_GiftCardLine]   FOREIGN KEY ([GiftCardId], [Sequence]) REFERENCES [GiftCardLine] ([GiftCardId], [Sequence]),
 CONSTRAINT [FK__GiftCardTrans_LocationRedeem] FOREIGN KEY ([LocationIdRedeem])       REFERENCES [Location]     ([LocationId])
) ON [PRIMARY]
GO

/* ---- SalesRemissionTable ---- */
CREATE TABLE [dbo].[SalesRemissionTable]
([SalesRemissionId]			BIGINT         NOT NULL,
 [SalesRemissionIdLocal]	BIGINT         IDENTITY NOT NULL,
 [LocationId]				SMALLINT       NOT NULL,
 [TypeDoc]					SMALLINT       NOT NULL,
 [EmissionPointId]			INT            NOT NULL,
 [Establishment]			[varchar](5)   Collate Database_Default NOT NULL,
 [RemissionNumber]			BIGINT         NULL,
 [Emission]					[varchar](5)   Collate Database_Default NOT NULL,
 [TransportDriverId]		INT            NOT NULL,
 [TransportId]				[Int]          NOT NULL,
 [TransportReasonId]		Int            NOT NULL,
 [SalesRemissionDate]		DATETIME       NOT NULL,
 [DeliveryDate]				DATETIME       NOT NULL,
 [Observation]				VARCHAR(250)   Collate Database_Default NOT NULL,
 [KeyAccessSri]				VARCHAR(50)    Collate Database_Default NOT NULL,
 [TransferStatusId]			INT            NOT NULL,
 [Status]					[Char](1)      Collate Database_Default NULL,
 [CreatedBy]				INT            NOT NULL,
 [CreatedDatetime]			DATETIME       NOT NULL,
 [ModifiedBy]				INT            NULL,
 [ModifiedDatetime]			DATETIME       NULL,
 [Workstation]				VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__SalesRemissionTable]                 PRIMARY KEY CLUSTERED ([SalesRemissionId]),
 CONSTRAINT [FK__SalesRemissionTable_Location]        FOREIGN KEY ([LocationId])       REFERENCES [Location]        ([LocationId]),
 CONSTRAINT [FK__SalesRemissionTable_Transport]       FOREIGN KEY ([TransportId])      REFERENCES [Transport]       ([TransportId]),
 CONSTRAINT [FK__SalesRemissionTable_TransportDriver] FOREIGN KEY ([TransportDriverId]) REFERENCES [TransportDriver] ([TransportDriverId]),
 CONSTRAINT [FK__SalesRemissionTable_EmissionPoint]   FOREIGN KEY ([EmissionPointId])  REFERENCES [EmissionPoint]   ([EmissionPointId]),
 CONSTRAINT [FK__SalesRemissionTable_TransportReason] FOREIGN KEY ([TransportReasonId]) REFERENCES [TransportReason] ([TransportReasonId])
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [Ind_SalesRemissionTable_1] ON [dbo].[SalesRemissionTable] ([SalesRemissionDate] ASC) INCLUDE ([TransportDriverId])
GO
CREATE NONCLUSTERED INDEX [Ind_SalesRemissionTable_2] ON [dbo].[SalesRemissionTable] ([SalesRemissionIdLocal] ASC)
GO
CREATE NONCLUSTERED INDEX [Ind_SalesRemissionTable_3] ON [dbo].[SalesRemissionTable] ([Status] ASC) INCLUDE ([TransportDriverId], [TransportId], [SalesRemissionDate], [CreatedBy])
GO

/* ---- SalesRemissionLine ---- */
CREATE TABLE [dbo].[SalesRemissionLine]
([SalesRemissionId]	BIGINT      NOT NULL,
 [Sequence]			INT         NOT NULL,
 [SalesOrderId]		BIGINT      NOT NULL,
 [Status]			[Char](1)   Collate Database_Default NULL,
 [CreatedBy]		INT         NOT NULL,
 [CreatedDatetime]	DATETIME    NOT NULL,
 [ModifiedBy]		INT         NULL,
 [ModifiedDatetime]	DATETIME    NULL,
 [Workstation]		VARCHAR(20) Collate Database_Default NOT NULL,
 CONSTRAINT [PK__SalesRemissionLine] PRIMARY KEY CLUSTERED ([SalesRemissionId], [Sequence]),
 CONSTRAINT [FK__SalesRemissionLine_SalesRemissionTable] FOREIGN KEY ([SalesRemissionId]) REFERENCES [SalesRemissionTable] ([SalesRemissionId])
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [Ind_SalesRemissionLine_1] ON [dbo].[SalesRemissionLine] ([SalesOrderId] ASC) INCLUDE ([Status])
GO
CREATE NONCLUSTERED INDEX [Ind_SalesRemissionLine_3] ON [dbo].[SalesRemissionLine] ([SalesOrderId] ASC, [Status] ASC)
GO

CREATE TABLE [dbo].[LogType]
([LogTypeId]         INT            NOT NULL,
 [Name]              [varchar](50)  Collate Database_Default NULL,
 [Status]            [Char](1)      Collate Database_Default NULL,
 [CreatedBy]         INT            NOT NULL,
 [CreatedDatetime]   DATETIME       NOT NULL,
 [ModifiedBy]        INT            NULL,
 [ModifiedDatetime]  DATETIME       NULL,
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__LogType] PRIMARY KEY CLUSTERED ([LogTypeId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CancelReason]
([ReasonId]          INT            NOT NULL,
 [ReasonType]        INT            NULL,
 [Name]              [varchar](50)  Collate Database_Default NULL,
 [Status]            [Char](1)      Collate Database_Default NULL,
 [CreatedBy]         INT            NOT NULL,
 [CreatedDatetime]   DATETIME       NOT NULL,
 [ModifiedBy]        INT            NULL,
 [ModifiedDatetime]  DATETIME       NULL,
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__CancelReason] PRIMARY KEY CLUSTERED ([ReasonId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[SalesLog]
([SalesLogId]        BIGINT         IDENTITY NOT NULL,
 [LocationId]        SMALLINT       NOT NULL,
 [EmissionPointId]   INT            NOT NULL,
 [InvoiceNumber]     BIGINT         NOT NULL,
 [CustomerId]        BIGINT         NOT NULL,
 [LogTypeId]         INT            NOT NULL,
 [ReasonId]          INT            NOT NULL,
 [Authorization]     VARCHAR(40)    Collate Database_Default NOT NULL,
 [XmlLog]            XML            NOT NULL,
 [Status]            [Char](1)      Collate Database_Default NULL,
 [CreatedBy]         INT            NOT NULL,
 [CreatedDatetime]   DATETIME       NOT NULL,
 [ModifiedBy]        INT            NULL,
 [ModifiedDatetime]  DATETIME       NULL,
 [Workstation]       VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__SalesLog]          PRIMARY KEY CLUSTERED ([SalesLogId]),
 CONSTRAINT [FK__SalesLog_LogType]  FOREIGN KEY ([LogTypeId]) REFERENCES [LogType] ([LogTypeId])
) ON [PRIMARY]
GO

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
 CONSTRAINT [PK__PhysicalStockCountingTable]                         PRIMARY KEY CLUSTERED ([PhysicalStockCountingId]),
 CONSTRAINT [FK__PhysicalStockCountingTable_InventLocation]           FOREIGN KEY ([InventLocationId]) REFERENCES [InventLocation] ([InventLocationId]),
 CONSTRAINT [FK__PhysicalStockCountingTable_Location]                 FOREIGN KEY ([LocationId])      REFERENCES [Location]       ([LocationId])
)
GO

CREATE TABLE [dbo].[PhysicalStockCountingLine]
([PhysicalStockCountingId]   INT             NOT NULL,
 [Sequence]                  INT             NOT NULL,
 [ProductId]                 BIGINT          NOT NULL,
 [InventUnitId]              INT             NOT NULL,
 [StockQuantity]             NUMERIC (24, 6) NOT NULL,
 [CountedQuantity]           NUMERIC (24, 6) NOT NULL,
 [Cost]                      NUMERIC (24, 6) NOT NULL,
 [Status]                    [Char](1)       Collate Database_Default NULL,
 [CreatedBy]                 INT             NOT NULL,
 [CreatedDatetime]           DATETIME        NOT NULL,
 [ModifiedBy]                INT             NULL,
 [ModifiedDatetime]          DATETIME        NULL,
 [Workstation]               VARCHAR(20)     Collate Database_Default NOT NULL,
 CONSTRAINT [PK__PhysicalStockCountingLine]                              PRIMARY KEY CLUSTERED ([PhysicalStockCountingId], [Sequence]),
 CONSTRAINT [FK__PhysicalStockCountingLine_InventUnit]                    FOREIGN KEY ([InventUnitId])             REFERENCES [InventUnit]                ([InventUnitId]),
 CONSTRAINT [FK__PhysicalStockCountingLine_PhysicalStockCountingTable]    FOREIGN KEY ([PhysicalStockCountingId]) REFERENCES [PhysicalStockCountingTable] ([PhysicalStockCountingId]),
 CONSTRAINT [FK__PhysicalStockCountingLine_Product]                       FOREIGN KEY ([ProductId])               REFERENCES [Product]                   ([ProductId])
)
GO

CREATE TABLE TmpPromoReward
([PromotionId]      bigint,
 [RewardDate]       datetime,
 [CustomerId]       bigint,
 [ProductId]        bigint,
 [Quantity]         numeric(18,4),
 [Percent]          numeric(18,2),
 [RewardProductId]  bigint,
 [QuantityReceive]  INT NULL,
 [QuantityTotal]    INT NULL)
GO

CREATE TABLE [dbo].[ProductCategoryTEMP]
([Id]          BIGINT        NULL,
 [ParentID]    BIGINT        NULL,
 [Nivel]       INT           NULL,
 [CodGrupo]    VARCHAR(4)    COLLATE Modern_Spanish_CI_AS NULL,
 [Grupo]       VARCHAR(150)  COLLATE Modern_Spanish_CI_AS NULL,
 [CodSubGrupo] VARCHAR(4)    COLLATE Modern_Spanish_CI_AS NULL,
 [SubGrupo]    VARCHAR(150)  COLLATE Modern_Spanish_CI_AS NULL,
 [path]        VARCHAR(1000) COLLATE Modern_Spanish_CI_AS NULL)
GO

CREATE TABLE [dbo].[TransactionLog]
([TransactionLogId]  BIGINT      IDENTITY (1, 1) NOT NULL,
 [UserId]            [Int]       NULL,
 [CreatedDatetime]   DATETIME    NOT NULL,
 [TrLogType]         [char](1)   NULL,
 [TableName]         [varchar](50)  NULL,
 [ColumnName]        [varchar](50)  NULL,
 [PrimaryKey]        [varchar](50)  NULL,
 [ValueBefore]       [varchar](255) NULL,
 [ValueAfter]        [varchar](255) NULL,
 [Reference]         [varchar](128) NULL,
 CONSTRAINT [PK__TransactionLog] PRIMARY KEY CLUSTERED ([TransactionLogId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Program]
([ProgramId]         INT         NOT NULL,
 [Name]              VARCHAR(50) NOT NULL,
 [Description]       VARCHAR(100)NOT NULL,
 [Status]            CHAR(1)     Collate Database_Default NULL,
 [CreatedBy]         INT         NOT NULL,
 [CreatedDatetime]   DATETIME    NOT NULL,
 [ModifiedBy]        INT         NULL,
 [ModifiedDatetime]  DATETIME    NULL,
 [Workstation]       VARCHAR(20) Collate Database_Default NOT NULL,
 CONSTRAINT [PK__Program] PRIMARY KEY CLUSTERED ([ProgramId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[UserProfile]
([UserProfileId]     INT         NOT NULL,
 [Name]              VARCHAR(50) NOT NULL,
 [Status]            CHAR(1)     Collate Database_Default NULL,
 [CreatedBy]         INT         NOT NULL,
 [CreatedDatetime]   DATETIME    NOT NULL,
 [ModifiedBy]        INT         NULL,
 [ModifiedDatetime]  DATETIME    NULL,
 [Workstation]       VARCHAR(20) Collate Database_Default NOT NULL,
 CONSTRAINT [PK__UserProfile] PRIMARY KEY CLUSTERED ([UserProfileId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[UserProfileProgram]
([UserProfileId]     INT     NOT NULL,
 [ProgramId]         INT     NOT NULL,
 [Status]            CHAR(1) Collate Database_Default NULL,
 CONSTRAINT [PK__UserProfileProgram]                        PRIMARY KEY CLUSTERED ([UserProfileId], [ProgramId]),
 CONSTRAINT [FK__UserProfileProgram_UserProfile]             FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([UserProfileId]),
 CONSTRAINT [FK__UserProfileProgram_Program]                 FOREIGN KEY ([ProgramId])     REFERENCES [Program]     ([ProgramId])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[UserLoginUserProfile]
([UserId]            INT     NOT NULL,
 [UserProfileId]     INT     NOT NULL,
 [Status]            CHAR(1) Collate Database_Default NULL,
 CONSTRAINT [PK__UserLoginUserProfile]                       PRIMARY KEY CLUSTERED ([UserId], [UserProfileId]),
 CONSTRAINT [FK__UserLoginUserProfile_UserLogin]              FOREIGN KEY ([UserId])        REFERENCES [UserLogin]   ([UserId]),
 CONSTRAINT [FK__UserLoginUserProfile_UserProfile]            FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([UserProfileId])
) ON [PRIMARY]
GO
