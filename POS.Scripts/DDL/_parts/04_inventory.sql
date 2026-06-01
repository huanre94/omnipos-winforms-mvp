/* =====================================================================
   DDL PART 04 - Inventario y Productos
   Incluye: InventLocation, InventTransType, InventUnit,
            ProductCategory, ProductGroup, Product, ProductBarcode,
            ProductModule, InventProductLocation
   ===================================================================== */

USE POSDB
GO

/* ---- InventLocation ---- */
CREATE TABLE [dbo].[InventLocation]
([InventLocationId] INT            NOT NULL,
 [Name]             [varchar](150) Collate Database_Default NOT NULL,
 [SAPCode]          [varchar](20)  Collate Database_Default NOT NULL,
 [LocationId]       SMALLINT       NOT NULL,
 [Type]             [varchar](2)   Collate Database_Default NULL,
 [IsMain]           [Bit]          NOT NULL,
 [Status]           [Char](1)      Collate Database_Default NULL,
 [CreatedBy]        INT            NOT NULL,
 [CreatedDatetime]  DATETIME       NOT NULL,
 [ModifiedBy]       INT            NULL,
 [ModifiedDatetime] DATETIME       NULL,
 [Workstation]      VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__InventLocation] PRIMARY KEY CLUSTERED ([InventLocationId]),
 CONSTRAINT [FK__InventLocation_Location] FOREIGN KEY ([LocationId]) REFERENCES [Location] ([LocationId])
) ON [PRIMARY]
GO

/* ---- InventTransType ---- */
CREATE TABLE [dbo].[InventTransType]
([InventTransTypeId]	Int            NOT NULL,
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
GO

/* ---- InventUnit ---- */
CREATE TABLE [dbo].[InventUnit]
([InventUnitId]		Int            NOT NULL,
 [Name]				[varchar](220) Collate Database_Default NULL,
 [SAPCode]			[varchar](20)  Collate Database_Default NOT NULL,
 [WeightControl]	[Bit]          NOT NULL,
 [Status]			[Char](1)      Collate Database_Default NULL,
 [CreatedBy]        INT            NOT NULL,
 [CreatedDatetime]  DATETIME       NOT NULL,
 [ModifiedBy]       INT            NULL,
 [ModifiedDatetime] DATETIME       NULL,
 [Workstation]      VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__InventUnit] PRIMARY KEY CLUSTERED ([InventUnitId])) ON [PRIMARY]
GO

/* ---- ProductCategory ---- */
CREATE TABLE [dbo].[ProductCategory]
([ProductCategoryId]	Int            NOT NULL,
 [ParentId]				Int            NOT NULL,
 [Name]					[varchar](220) Collate Database_Default NULL,
 [FriendlyName]			[varchar](220) Collate Database_Default NULL,
 [Level]				Int            NOT NULL,
 [Status]				[Char](1)      Collate Database_Default NULL,
 [CreatedBy]			INT            NOT NULL,
 [CreatedDatetime]		DATETIME       NOT NULL,
 [ModifiedBy]			INT            NULL,
 [ModifiedDatetime]		DATETIME       NULL,
 [Workstation]			VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__ProductCategory] PRIMARY KEY CLUSTERED ([ProductCategoryId])
) ON [PRIMARY]
GO

/* ---- ProductGroup ---- */
CREATE TABLE [dbo].[ProductGroup]
([ProductGroupId]	Int            NOT NULL,
 [Name]				[varchar](220) Collate Database_Default NULL,
 [Status]			[Char](1)      Collate Database_Default NULL,
 [CreatedBy]		INT            NOT NULL,
 [CreatedDatetime]	DATETIME       NOT NULL,
 [ModifiedBy]		INT            NULL,
 [ModifiedDatetime]	DATETIME       NULL,
 [Workstation]		VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__ProductGroup] PRIMARY KEY CLUSTERED ([ProductGroupId])
) ON [PRIMARY]
GO

/* ---- Product ---- */
CREATE TABLE [dbo].[Product]
([ProductId]            BIGINT           NOT NULL,
 [SAPCode]              [varchar](20)    Collate Database_Default NOT NULL,
 [Name]                 [varchar](220)   Collate Database_Default NULL,
 [Description]          [varchar](150)   Collate Database_Default NOT NULL,
 [InventUnitId]         Int              NOT NULL,
 [ProductGroupId]       Int              NOT NULL,
 [ProductCategoryId]    INT              NOT NULL,
 [Type]                 [varchar](1)     Collate Database_Default NOT NULL,
 [IsDeductible]         [BIT]            NOT NULL,
 [UseTax]               [BIT]            NOT NULL,
 [UseIrbp]              [BIT]            NOT NULL,
 [IsECommerce]          [BIT]            NOT NULL,
 [UseCatchWeight]       [BIT]            NOT NULL,
 [CatchWeightMax]       [numeric](24,6)  NOT NULL,
 [CatchWeightMin]       [numeric](24,6)  NOT NULL,
 [VendorId]             [INT]            NULL,
 [BrandId]              [INT]            NULL,
 [ProductOldCode]       [varchar](20)    Collate Database_Default NOT NULL,
 [Status]               [Char](1)        Collate Database_Default NULL,
 [CreatedBy]            INT              NOT NULL,
 [CreatedDatetime]      DATETIME         NOT NULL,
 [ModifiedBy]           INT              NULL,
 [ModifiedDatetime]     DATETIME         NULL,
 [Workstation]          VARCHAR(20)      Collate Database_Default NOT NULL,
 CONSTRAINT [PK__Product] PRIMARY KEY CLUSTERED ([ProductId]),
 CONSTRAINT [FK__Product_InventUnit]      FOREIGN KEY ([InventUnitId])      REFERENCES [InventUnit]      ([InventUnitId]),
 CONSTRAINT [FK__Product_ProductGroup]    FOREIGN KEY ([ProductGroupId])    REFERENCES [ProductGroup]    ([ProductGroupId]),
 CONSTRAINT [FK__Product_ProductCategory] FOREIGN KEY ([ProductCategoryId]) REFERENCES [ProductCategory] ([ProductCategoryId]),
 CONSTRAINT [FK__Product_VendorId]        FOREIGN KEY ([VendorId])          REFERENCES [Vendor]          ([VendorId]),
 CONSTRAINT [FK__Product_Brand]           FOREIGN KEY ([BrandId])           REFERENCES [Brand]           ([BrandId])
) ON [PRIMARY]
GO
CREATE UNIQUE INDEX Ind_Product_ProductOldCode ON Product ([ProductOldCode])
GO
CREATE NONCLUSTERED INDEX [Ind_Product_1] ON [dbo].[Product] ([ModifiedDatetime] ASC)
    INCLUDE ([Name], [InventUnitId], [ProductCategoryId], [UseTax], [IsECommerce], [ProductOldCode], [Status])
GO
CREATE NONCLUSTERED INDEX [Ind_Product_2] ON [dbo].[Product] ([Name] ASC, [ProductCategoryId] ASC)
    INCLUDE ([UseCatchWeight])
GO
CREATE NONCLUSTERED INDEX [Ind_Product_3] ON [dbo].[Product] ([ProductCategoryId] ASC, [Status] ASC)
    INCLUDE ([UseTax], [ProductOldCode])
GO

/* ---- ProductBarcode ---- */
CREATE TABLE [dbo].[ProductBarcode]
([ProductId]         BIGINT           NOT NULL,
 [Barcode]           [varchar](20)    Collate Database_Default NOT NULL,
 [Quantity]          [numeric](18,2)  NOT NULL,
 [Status]            [Char](1)        Collate Database_Default NULL,
 [CreatedBy]         INT              NOT NULL,
 [CreatedDatetime]   DATETIME         NOT NULL,
 [ModifiedBy]        INT              NULL,
 [ModifiedDatetime]  DATETIME         NULL,
 [Workstation]       VARCHAR(20)      Collate Database_Default NOT NULL,
 CONSTRAINT [PK__ProductBarcode] PRIMARY KEY CLUSTERED ([ProductId], [Barcode]),
 CONSTRAINT [FK__ProductBarcode_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([ProductId])
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [Ind_ProductBarcode_1] ON [dbo].[ProductBarcode] ([Barcode] ASC)
GO

/* ---- ProductModule ---- */
CREATE TABLE [dbo].[ProductModule]
([ProductId]		BIGINT           NOT NULL,
 [LocationId]		INT              NOT NULL,
 [Cost]				[numeric](24,6)  NOT NULL,
 [PriceReference]	[numeric](24,6)  NOT NULL,
 [Price]			[numeric](24,6)  NOT NULL,
 [TaxAmount]		[numeric](24,6)  NOT NULL,
 [IrbpAmount]		[numeric](24,6)  NOT NULL,
 [CreatedBy]        INT              NOT NULL,
 [CreatedDatetime]  DATETIME         NOT NULL,
 [ModifiedBy]       INT              NULL,
 [ModifiedDatetime] DATETIME         NULL,
 [Workstation]      VARCHAR(20)      Collate Database_Default NOT NULL,
 CONSTRAINT [PK__ProductModule] PRIMARY KEY CLUSTERED ([ProductId], [LocationId]),
 CONSTRAINT [FK__ProductModule_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([ProductId])
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [Ind_ProductModule_1] ON [dbo].[ProductModule] ([LocationId] ASC) INCLUDE ([Cost])
GO
CREATE NONCLUSTERED INDEX [Ind_ProductModule_2] ON [dbo].[ProductModule] ([LocationId] ASC) INCLUDE ([Cost], [Price], [ModifiedDatetime])
GO

/* ---- InventProductLocation ---- */
CREATE TABLE [dbo].[InventProductLocation]
([ProductId]         BIGINT           NOT NULL,
 [LocationId]        INT              NOT NULL,
 [InventLocationId]  INT              NOT NULL,
 [MinStock]          [numeric](12,2)  NOT NULL,
 [MaxStock]          [numeric](12,2)  NOT NULL,
 [Stock]             [numeric](24,6)  NOT NULL,
 [CreatedBy]         INT              NOT NULL,
 [CreatedDateTime]   DATETIME         NOT NULL,
 [ModifiedBy]        INT              NULL,
 [ModifiedDateTime]  DATETIME         NULL,
 [Workstation]       VARCHAR(20)      Collate Database_Default NOT NULL,
 CONSTRAINT [PK__InventProductLocation] PRIMARY KEY CLUSTERED ([ProductId], [LocationId], [InventLocationId]),
 CONSTRAINT [FK__InventProductLocation_Product]        FOREIGN KEY ([ProductId])        REFERENCES [Product]        ([ProductId]),
 CONSTRAINT [FK__InventProductLocation_InventLocation] FOREIGN KEY ([InventLocationId]) REFERENCES [InventLocation] ([InventLocationId])
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [Ind_InventProductLocation_1] ON [dbo].[InventProductLocation] ([LocationId] ASC, [ModifiedDateTime] ASC) INCLUDE ([Stock])
GO
CREATE NONCLUSTERED INDEX [Ind_InventProductLocation_2] ON [dbo].[InventProductLocation] ([ModifiedDateTime] ASC) INCLUDE ([Stock])
GO
