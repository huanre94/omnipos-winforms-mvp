/* =====================================================================
   DDL PART 05 - Promociones, Tarjetas Internas y Secuencias
   Incluye: PromotionType, PromotionTable, PromotionCustomer,
            PromotionPaymMode, PromotionProducts, PromotionReward,
            InternalCreditCard, InternalCreditCardLine,
            EmissionPoint, SequenceType, SequenceTable
   ===================================================================== */

USE POSDB
GO

/* ---- PromotionType ---- */
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

/* ---- PromotionTable ---- */
CREATE TABLE [dbo].[PromotionTable]
([PromotionId]       BIGINT         NOT NULL,
 [Name]              VARCHAR(200)   Collate Database_Default NOT NULL,
 [PromotionTypeId]   INT            NOT NULL,
 [ConsumptionOrigin] CHAR(1)        NOT NULL,
 [ConsumptionMax]    NUMERIC(18,2)  NOT NULL,
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
 CONSTRAINT [PK__PromotionTable] PRIMARY KEY CLUSTERED ([PromotionId]),
 CONSTRAINT [FK__PromotionTable_PromotionType] FOREIGN KEY ([PromotionTypeId]) REFERENCES [PromotionType] ([PromotionTypeId])
) ON [PRIMARY]
GO

/* ---- PromotionCustomer ---- */
CREATE TABLE [dbo].[PromotionCustomer]
([PromotionId]		BIGINT         NOT NULL,
 [Sequence]			INT            NOT NULL,
 [CustomerId]		BIGINT         NOT NULL,
 [Percent]			numeric(18,4)  NOT NULL,
 [StatusPromCust]	[Char](1)      Collate Database_Default NULL,
 [CreatedBy]        INT            NOT NULL,
 [CreatedDatetime]  DATETIME       NOT NULL,
 [ModifiedBy]       INT            NULL,
 [ModifiedDatetime] DATETIME       NULL,
 [Workstation]      VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__PromotionCustomer] PRIMARY KEY CLUSTERED ([PromotionId], [Sequence]),
 CONSTRAINT [FK__PromotionCustomer_PromotionTable] FOREIGN KEY ([PromotionId]) REFERENCES [PromotionTable] ([PromotionId]),
 CONSTRAINT [FK__PromotionCustomer_Customer]       FOREIGN KEY ([CustomerId])  REFERENCES [Customer]       ([CustomerId])
) ON [PRIMARY]
GO

/* ---- PromotionPaymMode ---- */
CREATE TABLE [dbo].[PromotionPaymMode]
([PromotionId]				BIGINT         NOT NULL,
 [Sequence]					INT            NOT NULL,
 [PaymModeId]				INT            NOT NULL,
 [BankId]					[INT]          NOT NULL,
 [CreditCardId]				[INT]          NOT NULL,
 [Percent]					numeric(18,4)  NOT NULL,
 [StatusPromPaym]			[Char](1)      Collate Database_Default NULL,
 [RewardMultiplierType]		varchar(1)     NOT NULL,
 [RewardMultiplierValue]	[INT]          NOT NULL,
 [CreatedBy]				INT            NOT NULL,
 [CreatedDatetime]			DATETIME       NOT NULL,
 [ModifiedBy]				INT            NULL,
 [ModifiedDatetime]			DATETIME       NULL,
 [Workstation]				VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__PromotionPaymMode] PRIMARY KEY CLUSTERED ([PromotionId], [Sequence]),
 CONSTRAINT [FK__PromotionPaymMode_PromotionTable] FOREIGN KEY ([PromotionId]) REFERENCES [PromotionTable] ([PromotionId]),
 CONSTRAINT [FK__PromotionPaymMode_PaymMode]       FOREIGN KEY ([PaymModeId])  REFERENCES [PaymMode]       ([PaymModeId])
) ON [PRIMARY]
GO

/* ---- PromotionProducts ---- */
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
 CONSTRAINT [PK__PromotionProducts] PRIMARY KEY CLUSTERED ([PromotionId], [Sequence]),
 CONSTRAINT [FK__PromotionProducts_PromotionTable] FOREIGN KEY ([PromotionId]) REFERENCES [PromotionTable] ([PromotionId])
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [Ind_PromotionProducts_1]
    ON [dbo].[PromotionProducts] ([Type] ASC, [StatusPromProd] ASC)
    INCLUDE ([Origin], [ProductCategoryId], [ProductId])
GO

/* ---- PromotionReward ---- */
CREATE TABLE [dbo].[PromotionReward]
([PromotionId]       BIGINT         NOT NULL,
 [Sequence]          INT            NOT NULL,
 [ProductId]         BIGINT         NOT NULL,
 [StartRange]        NUMERIC(24,4)  NOT NULL,
 [FinalRange]        NUMERIC(24,4)  NOT NULL,
 [Percent]           NUMERIC(12,4)  NOT NULL,
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
 CONSTRAINT [PK__PromotionReward] PRIMARY KEY CLUSTERED ([PromotionId], [Sequence]),
 CONSTRAINT [FK__PromotionReward_PromotionTable] FOREIGN KEY ([PromotionId]) REFERENCES [PromotionTable] ([PromotionId])
) ON [PRIMARY]
GO

/* ---- InternalCreditCard ---- */
CREATE TABLE [dbo].[InternalCreditCard]
([InternalCreditCardId]       BIGINT         NOT NULL,
 [InternalCreditCardIdLocal]  BIGINT         NOT NULL,
 [Barcode]                    VARCHAR(25)    Collate Database_Default NOT NULL,
 [Name]                       VARCHAR(150)   Collate Database_Default NOT NULL,
 [Type]                       VARCHAR(1)     NOT NULL,
 [Vigence]                    DATETIME       NOT NULL,
 [Expiration]                 DATETIME       NOT NULL,
 [CustomerId]                 BIGINT         NOT NULL,
 [EmployeeId]                 BIGINT         NOT NULL,
 [Quota]                      NUMERIC(18,2)  NOT NULL,
 [Consumed]                   NUMERIC(18,2)  NOT NULL,
 [Printed]                    BIT            NOT NULL,
 [Status]                     [Char](1)      Collate Database_Default NULL,
 [CreatedBy]                  INT            NOT NULL,
 [CreatedDatetime]            DATETIME       NOT NULL,
 [ModifiedBy]                 INT            NULL,
 [ModifiedDatetime]           DATETIME       NULL,
 [Workstation]                VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__InternalCreditCard] PRIMARY KEY CLUSTERED ([InternalCreditCardId]),
 CONSTRAINT [FK__InternalCreditCard_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [Customer] ([CustomerId])
) ON [PRIMARY]
GO

/* ---- InternalCreditCardLine ---- */
CREATE TABLE [dbo].[InternalCreditCardLine]
([InternalCreditCardId] BIGINT   NOT NULL,
 [Sequence]             INT      NOT NULL,
 [PromotionId]          BIGINT   NOT NULL,
 [CreatedBy]			INT      NOT NULL,
 [CreatedDatetime]		DATETIME NOT NULL,
 [ModifiedBy]			INT      NULL,
 [ModifiedDatetime]		DATETIME NULL,
 [Workstation]			VARCHAR(20) Collate Database_Default NOT NULL,
 CONSTRAINT [PK__InternalCreditCardLine] PRIMARY KEY CLUSTERED ([InternalCreditCardId], [Sequence]),
 CONSTRAINT [FK__InternalCreditCardLine_InternalCreditCard] FOREIGN KEY ([InternalCreditCardId]) REFERENCES [InternalCreditCard] ([InternalCreditCardId]),
 CONSTRAINT [FK__InternalCreditCardLine_PromotionTable]     FOREIGN KEY ([PromotionId])          REFERENCES [PromotionTable]     ([PromotionId])
) ON [PRIMARY]
GO

/* ---- EmissionPoint ---- */
CREATE TABLE [dbo].[EmissionPoint]
([EmissionPointId]      INT          NOT NULL,
 [LocationId]           SMALLINT     NOT NULL,
 [InventLocationId]     INT          NOT NULL,
 [Establishment]        [varchar](5) Collate Database_Default NOT NULL,
 [Emission]             [varchar](5) Collate Database_Default NOT NULL,
 [Name]                 VARCHAR(100) Collate Database_Default NOT NULL,
 [AddressIP]            VARCHAR(20)  Collate Database_Default NOT NULL,
 [ScaleName]            VARCHAR(20)  Collate Database_Default NOT NULL,
 [ScaleBrand]           VARCHAR(20)  Collate Database_Default NOT NULL,
 [ScanBarcodeName]      VARCHAR(20)  Collate Database_Default NOT NULL,
 [PrinterName]          VARCHAR(20)  Collate Database_Default NOT NULL,
 [ThermalPrinter]       BIT          NOT NULL,
 [Status]               [Char](1)    Collate Database_Default NULL,
 [CreatedBy]            INT          NOT NULL,
 [CreatedDatetime]      DATETIME     NOT NULL,
 [ModifiedBy]           INT          NULL,
 [ModifiedDatetime]     DATETIME     NULL,
 [Workstation]          VARCHAR(20)  Collate Database_Default NOT NULL,
 CONSTRAINT [PK__EmissionPoint] PRIMARY KEY CLUSTERED ([EmissionPointId]),
 CONSTRAINT [FK__EmissionPoint_Location]      FOREIGN KEY ([LocationId])      REFERENCES [Location]      ([LocationId]),
 CONSTRAINT [FK__EmissionPoint_InventLocation] FOREIGN KEY ([InventLocationId]) REFERENCES [InventLocation] ([InventLocationId])
) ON [PRIMARY]
GO
CREATE UNIQUE INDEX Ind_EmissionPoint ON EmissionPoint ([LocationId], [Establishment], [Emission])
GO

/* ---- SequenceType ---- */
CREATE TABLE [dbo].[SequenceType]
([SequenceTypeId]	Int          NOT NULL,
 [Name]				[varchar](50) Collate Database_Default NULL,
 [Status]			[Char](1)    Collate Database_Default NULL,
 [CreatedBy]        INT          NOT NULL,
 [CreatedDatetime]  DATETIME     NOT NULL,
 [ModifiedBy]       INT          NULL,
 [ModifiedDatetime] DATETIME     NULL,
 [Workstation]      VARCHAR(20)  Collate Database_Default NOT NULL,
 CONSTRAINT [PK__SequenceType] PRIMARY KEY CLUSTERED ([SequenceTypeId])) ON [PRIMARY]
GO

/* ---- SequenceTable ---- */
CREATE TABLE [dbo].[SequenceTable]
([LocationId]		SMALLINT     NOT NULL,
 [SequenceId]		INT          NOT NULL,
 [SequenceTypeId]	INT          NOT NULL,
 [EmissionPointId]  INT          NOT NULL,
 [Sequence]			INT          NOT NULL,
 [Name]             VARCHAR(100) Collate Database_Default NOT NULL,
 [Status]			[Char](1)    Collate Database_Default NULL,
 [CreatedBy]        INT          NOT NULL,
 [CreatedDatetime]  DATETIME     NOT NULL,
 [ModifiedBy]       INT          NULL,
 [ModifiedDatetime] DATETIME     NULL,
 [Workstation]      VARCHAR(20)  Collate Database_Default NOT NULL,
 CONSTRAINT [PK__SequenceTable] PRIMARY KEY CLUSTERED ([LocationId], [SequenceId]),
 CONSTRAINT [FK__SequenceTable_Location]     FOREIGN KEY ([LocationId])    REFERENCES [Location]    ([LocationId]),
 CONSTRAINT [FK__SequenceTable_SequenceType] FOREIGN KEY ([SequenceTypeId]) REFERENCES [SequenceType] ([SequenceTypeId])
) ON [PRIMARY]
GO
CREATE UNIQUE INDEX Ind_SequenceTable ON [SequenceTable] ([LocationId], [SequenceTypeId], [EmissionPointId])
GO
