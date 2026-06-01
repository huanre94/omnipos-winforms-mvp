/* =====================================================================
   DDL PART 03 - Transporte, Empresa, Ubicaciones y Clientes
   Incluye: Transport, TransportDriver, TransportReason, Company,
            Location, Salesman, CustomerType, IdentType, Customer,
            CustomerAddress, Vendor, Brand
   ===================================================================== */

USE POSDB
GO

/* ---- Transport ---- */
CREATE TABLE [dbo].[Transport]
([TransportId]		[Int]          NOT NULL,
 [LicencePlate]		VARCHAR(10)    Collate Database_Default NOT NULL,
 [Description]		[varchar](100) NOT NULL,
 [Status]			[Char](1)      Collate Database_Default NULL,
 [CreatedBy]		INT            NOT NULL,
 [CreatedDatetime]	DATETIME       NOT NULL,
 [ModifiedBy]		INT            NULL,
 [ModifiedDatetime]	DATETIME       NULL,
 [Workstation]		VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__Transport] PRIMARY KEY CLUSTERED ([TransportId])) ON [PRIMARY]
GO
CREATE UNIQUE INDEX Ind_Transport ON [Transport] ([LicencePlate])
GO

/* ---- TransportDriver ---- */
CREATE TABLE [dbo].[TransportDriver]
([TransportDriverId]	[Int]          NOT NULL,
 [Identification]		[varchar](20)  NOT NULL,
 [Lastname]				[varchar](150) Collate Database_Default NOT NULL,
 [Firtsname]			[varchar](150) Collate Database_Default NOT NULL,
 [Status]				[Char](1)      Collate Database_Default NULL,
 [CreatedBy]			INT            NOT NULL,
 [CreatedDatetime]		DATETIME       NOT NULL,
 [ModifiedBy]			INT            NULL,
 [ModifiedDatetime]		DATETIME       NULL,
 [Workstation]			VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__TransportDriver] PRIMARY KEY CLUSTERED ([TransportDriverId])) ON [PRIMARY]
GO
CREATE UNIQUE INDEX Ind_TransportDriver ON [TransportDriver] ([Identification])
GO

/* ---- TransportReason ---- */
CREATE TABLE [dbo].[TransportReason]
([TransportReasonId]	Int            NOT NULL,
 [Name]					[varchar](150) Collate Database_Default NULL,
 [SAPCode]				[varchar](20)  Collate Database_Default NOT NULL,
 [Status]				[Char](1)      Collate Database_Default NULL,
 [CreatedBy]			INT            NOT NULL,
 [CreatedDatetime]		DATETIME       NOT NULL,
 [ModifiedBy]			INT            NULL,
 [ModifiedDatetime]		DATETIME       NULL,
 [Workstation]			VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__TransportReason] PRIMARY KEY CLUSTERED ([TransportReasonId])) ON [PRIMARY]
GO

/* ---- Company ---- */
CREATE TABLE [dbo].[Company]
([CompanyId]			[Smallint]     NOT NULL,
 [Name]					[varchar](250) Collate Database_Default NULL,
 [Identification]		[varchar](13)  Collate Database_Default NULL,
 [Phone]				[varchar](10)  Collate Database_Default NULL,
 [CityId]				INT            NOT NULL,
 [Address]				[varchar](150) Collate Database_Default NULL,
 [IsTaxpayerSpecial]	[Bit]          NOT NULL,
 [HasRISE]				[Bit]          NOT NULL,
 [HasTaxback]			[Bit]          NOT NULL,
 [Status]				[Char](1)      Collate Database_Default NULL,
 [CreatedBy]			INT            NOT NULL,
 [CreatedDatetime]		DATETIME       NOT NULL,
 [ModifiedBy]			INT            NULL,
 [ModifiedDatetime]		DATETIME       NULL,
 [Workstation]			VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__Company] PRIMARY KEY CLUSTERED ([CompanyId]),
 CONSTRAINT [FK__Company_City] FOREIGN KEY ([CityId]) REFERENCES [City] ([CityId])
) ON [PRIMARY]
GO

/* ---- Location ---- */
CREATE TABLE [dbo].[Location]
([LocationId]		[Smallint]     NOT NULL,
 [CompanyId]		[Smallint]     NOT NULL,
 [Name]				[varchar](120) Collate Database_Default NULL,
 [Establishment]	[varchar](5)   Collate Database_Default NOT NULL,
 [Phone]			[varchar](10)  Collate Database_Default NULL,
 [CityId]			INT            NOT NULL,
 [Address]			[varchar](150) Collate Database_Default NULL,
 [IsMain]			[Bit]          NULL,
 [ServerId]			[Int]          NOT NULL,
 [Status]			[Char](1)      Collate Database_Default NULL,
 [CreatedBy]		INT            NOT NULL,
 [CreatedDatetime]	DATETIME       NOT NULL,
 [ModifiedBy]		INT            NULL,
 [ModifiedDatetime]	DATETIME       NULL,
 [Workstation]		VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__Location] PRIMARY KEY CLUSTERED ([LocationId]),
 CONSTRAINT [FK__Location_Company] FOREIGN KEY ([CompanyId]) REFERENCES [Company] ([CompanyId]),
 CONSTRAINT [FK__Location_City]    FOREIGN KEY ([CityId])    REFERENCES [City]    ([CityId])
) ON [PRIMARY]
GO

/* ---- Salesman ---- */
CREATE TABLE [dbo].[Salesman]
([SalesmanId]			INT             NOT NULL,
 [Name]					VARCHAR(200)    NOT NULL,
 [SAPCode]				[varchar](20)   Collate Database_Default NOT NULL,
 [IsExternal]			[BIT]           NOT NULL,
 [ParentId]				INT             NOT NULL,
 [Type]					VARCHAR(2)      NOT NULL,
 [CommissionPercent]	[numeric](18,4) NOT NULL,
 [Fulfillment]			[numeric](18,2) NOT NULL,
 [Status]				[Char](1)       Collate Database_Default NULL,
 [CreatedBy]			INT             NOT NULL,
 [CreatedDatetime]		DATETIME        NOT NULL,
 [ModifiedBy]			INT             NULL,
 [ModifiedDatetime]		DATETIME        NULL,
 [Workstation]			VARCHAR(20)     Collate Database_Default NOT NULL,
 CONSTRAINT [PK__Salesman] PRIMARY KEY CLUSTERED ([SalesmanId])) ON [PRIMARY]
GO

/* ---- CustomerType ---- */
CREATE TABLE [dbo].[CustomerType]
([CustomerTypeId]	Int            NOT NULL,
 [Name]				[varchar](220) Collate Database_Default NULL,
 [ParentId]			Int            NOT NULL,
 [Level]			Int            NOT NULL,
 [Status]			[Char](1)      Collate Database_Default NULL,
 [CreatedBy]        INT            NOT NULL,
 [CreatedDatetime]  DATETIME       NOT NULL,
 [ModifiedBy]       INT            NULL,
 [ModifiedDatetime] DATETIME       NULL,
 [Workstation]      VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__CustomerType] PRIMARY KEY CLUSTERED ([CustomerTypeId])) ON [PRIMARY]
GO

/* ---- IdentType ---- */
CREATE TABLE [dbo].[IdentType]
([IdentTypeId]		[Int]          NOT NULL,
 [Name]				[varchar](50)  Collate Database_Default NULL,
 [Prefix]			[Char](1)      Collate Database_Default NULL,
 [Status]			[Char](1)      Collate Database_Default NULL,
 [CreatedBy]        INT            NOT NULL,
 [CreatedDatetime]  DATETIME       NOT NULL,
 [ModifiedBy]       INT            NULL,
 [ModifiedDatetime] DATETIME       NULL,
 [Workstation]      VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__IdentType] PRIMARY KEY CLUSTERED ([IdentTypeId])) ON [PRIMARY]
GO

/* ---- Customer ---- */
CREATE TABLE [dbo].[Customer]
([CustomerId]			BIGINT         NOT NULL,
 [CustomerIdLocal]		BIGINT         IDENTITY NOT NULL,
 [Lastname]				[varchar](150) Collate Database_Default NOT NULL,
 [Firtsname]			[varchar](150) Collate Database_Default NOT NULL,
 [SAPCode]				[varchar](20)  Collate Database_Default NOT NULL,
 [LocationId]			SMALLINT       NOT NULL,
 [IdentTypeId]			[Int]          NOT NULL,
 [Identification]		[varchar](20)  Collate Database_Default NULL,
 [Gender]				[Varchar](1)   Collate Database_Default NULL,
 [PersonType]			[Char](1)      Collate Database_Default NOT NULL,
 [IsSpecialTaxpayer]	[Bit]          NULL,
 [IsEmployee]			[Bit]          NOT NULL,
 [EmployeeId]			INT            NOT NULL,
 [Phone]				[varchar](10)  Collate Database_Default NOT NULL,
 [Email]				[varchar](150) Collate Database_Default NOT NULL,
 [CityId]				INT            NOT NULL,
 [Address]				varchar(250)   Collate Database_Default NULL,
 [CustomerTypeId]		Int            NOT NULL,
 [UseRetention]         [Bit]          NULL,
 [IsCredit]				[Bit]          NULL,
 [CreditLimit]          NUMERIC(18,2)  NOT NULL,
 [Status]               [Char](1)      Collate Database_Default NULL,
 [CreatedBy]            INT            NOT NULL,
 [CreatedDatetime]      DATETIME       NOT NULL,
 [ModifiedBy]           INT            NULL,
 [ModifiedDatetime]     DATETIME       NULL,
 [Workstation]          VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__Customer] PRIMARY KEY CLUSTERED ([CustomerId]),
 CONSTRAINT [FK__Customer_Location]     FOREIGN KEY ([LocationId])     REFERENCES [Location]     ([LocationId]),
 CONSTRAINT [FK__Customer_IdentType]    FOREIGN KEY ([IdentTypeId])    REFERENCES [IdentType]    ([IdentTypeId]),
 CONSTRAINT [FK__Customer_City]         FOREIGN KEY ([CityId])         REFERENCES [City]         ([CityId]),
 CONSTRAINT [FK__Customer_CustomerType] FOREIGN KEY ([CustomerTypeId]) REFERENCES [CustomerType] ([CustomerTypeId])
) ON [PRIMARY]
GO
CREATE UNIQUE INDEX Customer ON Customer ([Identification])
GO
CREATE NONCLUSTERED INDEX [Ind_Customer_1] ON [dbo].[Customer] ([CustomerIdLocal] ASC)
GO

/* ---- CustomerAddress ---- */
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
 [CreatedBy]				INT           NOT NULL,
 [CreatedDatetime]			DATETIME      NOT NULL,
 [ModifiedBy]				INT           NULL,
 [ModifiedDatetime]			DATETIME      NULL,
 [Workstation]				VARCHAR(20)   Collate Database_Default NOT NULL,
 CONSTRAINT [PK__CustomerAddress] PRIMARY KEY CLUSTERED ([CustomerAddressId]),
 CONSTRAINT [FK__CustomerAddress_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [Customer] ([CustomerId])
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [Ind_CustomerAddress_1] ON [dbo].[CustomerAddress] ([CustomerAddressIdLocal] ASC)
GO
CREATE NONCLUSTERED INDEX [Ind_CustomerAddress_2] ON [dbo].[CustomerAddress] ([CustomerId] ASC) INCLUDE ([Sequence])
GO

/* ---- Vendor ---- */
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
 CONSTRAINT [PK__Vendor] PRIMARY KEY CLUSTERED ([VendorId]),
 CONSTRAINT [FK__Vendor_CustIdType] FOREIGN KEY ([IdentTypeId]) REFERENCES [IdentType] ([IdentTypeId]),
 CONSTRAINT [FK__Vendor_City]       FOREIGN KEY ([CityId])       REFERENCES [City]       ([CityId])
) ON [PRIMARY]
GO

/* ---- Brand ---- */
CREATE TABLE [dbo].[Brand]
([BrandId]			Int            NOT NULL,
 [Name]				[varchar](220) Collate Database_Default NULL,
 [SAPCode]			[varchar](20)  Collate Database_Default NOT NULL,
 [Status]			[Char](1)      Collate Database_Default NULL,
 [CreatedBy]        INT            NOT NULL,
 [CreatedDatetime]  DATETIME       NOT NULL,
 [ModifiedBy]       INT            NULL,
 [ModifiedDatetime] DATETIME       NULL,
 [Workstation]      VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__Brand] PRIMARY KEY CLUSTERED ([BrandId])) ON [PRIMARY]
GO
