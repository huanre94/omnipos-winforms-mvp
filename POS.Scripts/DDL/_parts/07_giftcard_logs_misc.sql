/* =====================================================================
   DDL PART 07 - GiftCard, Guias de Remision, Logs y Miscelaneos
   Incluye: GiftCardBlockTable, GiftCardBlockLine, GiftCardTable,
            GiftCardLine, GiftCardLineProduct, GiftCardTrans,
            SalesRemissionTable, SalesRemissionLine,
            LogType, CancelReason, SalesLog,
            PhysicalStockCountingTable, PhysicalStockCountingLine,
            TmpPromoReward, ProductCategoryTEMP, TransactionLog,
            Program, UserProfile, UserProfileProgram, UserLoginUserProfile
   ===================================================================== */

USE POSDB
GO

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
 CONSTRAINT [FK__GiftCardTable_Location]          FOREIGN KEY ([LocationId])       REFERENCES [Location]          ([LocationId]),
 CONSTRAINT [FK__GiftCardTable_LocationOrigin]    FOREIGN KEY ([LocationIdOrigin]) REFERENCES [Location]          ([LocationId]),
 CONSTRAINT [FK__GiftCardTable_GiftCardBlockTable] FOREIGN KEY ([GiftCardBlockId]) REFERENCES [GiftCardBlockTable] ([GiftCardBlockId]),
 CONSTRAINT [FK__GiftCardTable_Customer]           FOREIGN KEY ([CustomerId])      REFERENCES [Customer]           ([CustomerId])
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
 CONSTRAINT [FK__GiftCardLine_Customer]      FOREIGN KEY ([CustomerId]) REFERENCES [Customer]      ([CustomerId])
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
 CONSTRAINT [FK__GiftCardLineProduct_GiftCardLine] FOREIGN KEY ([GiftCardId], [Sequence]) REFERENCES [GiftCardLine]  ([GiftCardId], [Sequence]),
 CONSTRAINT [FK__GiftCardLineProduct_Product]      FOREIGN KEY ([ProductId])             REFERENCES [Product]       ([ProductId])
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
 CONSTRAINT [PK__SalesRemissionTable]                  PRIMARY KEY CLUSTERED ([SalesRemissionId]),
 CONSTRAINT [FK__SalesRemissionTable_Location]         FOREIGN KEY ([LocationId])       REFERENCES [Location]         ([LocationId]),
 CONSTRAINT [FK__SalesRemissionTable_Transport]        FOREIGN KEY ([TransportId])       REFERENCES [Transport]        ([TransportId]),
 CONSTRAINT [FK__SalesRemissionTable_TransportDriver]  FOREIGN KEY ([TransportDriverId]) REFERENCES [TransportDriver]  ([TransportDriverId]),
 CONSTRAINT [FK__SalesRemissionTable_EmissionPoint]    FOREIGN KEY ([EmissionPointId])   REFERENCES [EmissionPoint]    ([EmissionPointId]),
 CONSTRAINT [FK__SalesRemissionTable_TransportReason]  FOREIGN KEY ([TransportReasonId]) REFERENCES [TransportReason]  ([TransportReasonId])
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

/* ---- LogType ---- */
CREATE TABLE [dbo].[LogType]
([LogTypeId]		INT            NOT NULL,
 [Name]				[varchar](50)  Collate Database_Default NULL,
 [Status]			[Char](1)      Collate Database_Default NULL,
 [CreatedBy]		INT            NOT NULL,
 [CreatedDatetime]	DATETIME       NOT NULL,
 [ModifiedBy]		INT            NULL,
 [ModifiedDatetime]	DATETIME       NULL,
 [Workstation]		VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__LogType] PRIMARY KEY CLUSTERED ([LogTypeId])
) ON [PRIMARY]
GO

/* ---- CancelReason ---- */
CREATE TABLE [dbo].[CancelReason]
([ReasonId]			INT            NOT NULL,
 [ReasonType]		INT            NULL,
 [Name]				[varchar](50)  Collate Database_Default NULL,
 [Status]			[Char](1)      Collate Database_Default NULL,
 [CreatedBy]		INT            NOT NULL,
 [CreatedDatetime]	DATETIME       NOT NULL,
 [ModifiedBy]		INT            NULL,
 [ModifiedDatetime]	DATETIME       NULL,
 [Workstation]		VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__CancelReason] PRIMARY KEY CLUSTERED ([ReasonId])
) ON [PRIMARY]
GO

/* ---- SalesLog ---- */
CREATE TABLE [dbo].[SalesLog]
([SalesLogId]		BIGINT         IDENTITY NOT NULL,
 [LocationId]		SMALLINT       NOT NULL,
 [EmissionPointId]	INT            NOT NULL,
 [InvoiceNumber]	BIGINT         NOT NULL,
 [CustomerId]		BIGINT         NOT NULL,
 [LogTypeId]		INT            NOT NULL,
 [ReasonId]			INT            NOT NULL,
 [Authorization]    VARCHAR(40)    Collate Database_Default NOT NULL,
 [XmlLog]			XML            NOT NULL,
 [Status]			[Char](1)      Collate Database_Default NULL,
 [CreatedBy]		INT            NOT NULL,
 [CreatedDatetime]	DATETIME       NOT NULL,
 [ModifiedBy]		INT            NULL,
 [ModifiedDatetime]	DATETIME       NULL,
 [Workstation]		VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__SalesLog] PRIMARY KEY CLUSTERED ([SalesLogId]),
 CONSTRAINT [FK__SalesLog_LogType] FOREIGN KEY ([LogTypeId]) REFERENCES [LogType] ([LogTypeId])
) ON [PRIMARY]
GO

/* ---- PhysicalStockCountingTable ---- */
CREATE TABLE [dbo].[PhysicalStockCountingTable]
([PhysicalStockCountingId]      INT           NOT NULL,
 [PhysicalStockCountingIdLocal] INT           IDENTITY (1, 1) NOT NULL,
 [LocationId]                   SMALLINT      NOT NULL,
 [EmissionPointId]              INT           NOT NULL,
 [InventLocationId]             INT           NOT NULL,
 [CountingDate]                 DATETIME      NOT NULL,
 [Type]                         CHAR(1)       NULL,
 [StockCountingId]              INT           NOT NULL,
 [ERPId]                        INT           NULL,
 [Observation]                  VARCHAR(150)  NOT NULL,
 [Status]                       CHAR(1)       NULL,
 [CreatedBy]                    INT           NOT NULL,
 [CreatedDatetime]              DATETIME      NOT NULL,
 [ModifiedBy]                   INT           NULL,
 [ModifiedDatetime]             DATETIME      NULL,
 [Workstation]                  VARCHAR(20)   NOT NULL,
 CONSTRAINT [PK__PhysicalStockCountingTable] PRIMARY KEY CLUSTERED ([PhysicalStockCountingId] ASC),
 CONSTRAINT [FK__PhysicalStockCountingTable_InventLocation] FOREIGN KEY ([InventLocationId]) REFERENCES [dbo].[InventLocation] ([InventLocationId]),
 CONSTRAINT [FK__PhysicalStockCountingTable_Location]       FOREIGN KEY ([LocationId])       REFERENCES [dbo].[Location]       ([LocationId])
)
GO

/* ---- PhysicalStockCountingLine ---- */
CREATE TABLE [dbo].[PhysicalStockCountingLine]
([PhysicalStockCountingId]	INT            NOT NULL,
 [Sequence]					INT            NOT NULL,
 [ProductId]				BIGINT         NOT NULL,
 [InventUnitId]				INT            NOT NULL,
 [StockQuantity]			NUMERIC(24,6)  NOT NULL,
 [CountedQuantity]			NUMERIC(24,6)  NOT NULL,
 [Cost]						NUMERIC(24,6)  NOT NULL,
 [Status]					[Char](1)      Collate Database_Default NULL,
 [CreatedBy]				INT            NOT NULL,
 [CreatedDatetime]			DATETIME       NOT NULL,
 [ModifiedBy]				INT            NULL,
 [ModifiedDatetime]			DATETIME       NULL,
 [Workstation]				VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__PhysicalStockCountingLine] PRIMARY KEY CLUSTERED ([PhysicalStockCountingId] ASC, [Sequence] ASC),
 CONSTRAINT [FK__PhysicalStockCountingLine_InventUnit]              FOREIGN KEY ([InventUnitId])            REFERENCES [dbo].[InventUnit]               ([InventUnitId]),
 CONSTRAINT [FK__PhysicalStockCountingLine_PhysicalStockCountingTable] FOREIGN KEY ([PhysicalStockCountingId]) REFERENCES [dbo].[PhysicalStockCountingTable] ([PhysicalStockCountingId]),
 CONSTRAINT [FK__PhysicalStockCountingLine_Product]                 FOREIGN KEY ([ProductId])               REFERENCES [dbo].[Product]                  ([ProductId])
)
GO

/* ---- TmpPromoReward (temporary working table, no audit columns) ---- */
CREATE TABLE [dbo].[TmpPromoReward]
([PromotionId]		BIGINT          NULL,
 [RewardDate]		DATETIME        NULL,
 [CustomerId]		BIGINT          NULL,
 [ProductId]		BIGINT          NULL,
 [Quantity]			NUMERIC(18,4)   NULL,
 [Percent]			NUMERIC(18,2)   NULL,
 [RewardProductId]	BIGINT          NULL,
 [QuantityReceive]	INT             NULL,
 [QuantityTotal]	INT             NULL
)
GO

/* ---- ProductCategoryTEMP (staging/import table) ---- */
CREATE TABLE [dbo].[ProductCategoryTEMP]
([Id]          BIGINT         NULL,
 [ParentID]    BIGINT         NULL,
 [Nivel]       INT            NULL,
 [CodGrupo]    VARCHAR(4)     COLLATE Modern_Spanish_CI_AS NULL,
 [Grupo]       VARCHAR(150)   COLLATE Modern_Spanish_CI_AS NULL,
 [CodSubGrupo] VARCHAR(4)     COLLATE Modern_Spanish_CI_AS NULL,
 [SubGrupo]    VARCHAR(150)   COLLATE Modern_Spanish_CI_AS NULL,
 [path]        VARCHAR(1000)  COLLATE Modern_Spanish_CI_AS NULL
)
GO

/* ---- TransactionLog ---- */
CREATE TABLE [dbo].[TransactionLog]
([TransactionLogId]	BIGINT         IDENTITY (1, 1) NOT NULL,
 [UserId]           [Int]          NULL,
 [CreatedDatetime]  DATETIME       NOT NULL,
 [TrLogType]		[char](1)      NULL,
 [TableName]		[varchar](50)  NULL,
 [ColumnName]		[varchar](50)  NULL,
 [PrimaryKey]		[varchar](50)  NULL,
 [ValueBefore]		[varchar](255) NULL,
 [ValueAfter]		[varchar](255) NULL,
 [Reference]		[varchar](128) NULL,
 CONSTRAINT [PK__TransactionLog] PRIMARY KEY CLUSTERED ([TransactionLogId])
) ON [PRIMARY]
GO

/* ---- Program ---- */
CREATE TABLE [dbo].[Program]
([ProgramId]		INT          NOT NULL,
 [Name]				VARCHAR(50)  NOT NULL,
 [Description]		VARCHAR(100) NOT NULL,
 [Status]			CHAR(1)      Collate Database_Default NULL,
 [CreatedBy]		INT          NOT NULL,
 [CreatedDatetime]	DATETIME     NOT NULL,
 [ModifiedBy]		INT          NULL,
 [ModifiedDatetime]	DATETIME     NULL,
 [Workstation]		VARCHAR(20)  Collate Database_Default NOT NULL,
 CONSTRAINT [PK__Program] PRIMARY KEY CLUSTERED ([ProgramId])
) ON [PRIMARY]
GO

/* ---- UserProfile ---- */
CREATE TABLE [dbo].[UserProfile]
([UserProfileId]	INT          NOT NULL,
 [Name]				VARCHAR(50)  NOT NULL,
 [Status]			CHAR(1)      Collate Database_Default NULL,
 [CreatedBy]		INT          NOT NULL,
 [CreatedDatetime]	DATETIME     NOT NULL,
 [ModifiedBy]		INT          NULL,
 [ModifiedDatetime]	DATETIME     NULL,
 [Workstation]		VARCHAR(20)  Collate Database_Default NOT NULL,
 CONSTRAINT [PK__UserProfile] PRIMARY KEY CLUSTERED ([UserProfileId])
) ON [PRIMARY]
GO

/* ---- UserProfileProgram ---- */
CREATE TABLE [dbo].[UserProfileProgram]
([UserProfileId]	INT      NOT NULL,
 [ProgramId]		INT      NOT NULL,
 [Status]			CHAR(1)  Collate Database_Default NULL,
 CONSTRAINT [PK__UserProfileProgram] PRIMARY KEY CLUSTERED ([UserProfileId], [ProgramId]),
 CONSTRAINT [FK__UserProfileProgram_UserProfile] FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([UserProfileId]),
 CONSTRAINT [FK__UserProfileProgram_Program]     FOREIGN KEY ([ProgramId])     REFERENCES [Program]     ([ProgramId])
) ON [PRIMARY]
GO

/* ---- UserLoginUserProfile ---- */
CREATE TABLE [dbo].[UserLoginUserProfile]
([UserId]			INT      NOT NULL,
 [UserProfileId]	INT      NOT NULL,
 [Status]			CHAR(1)  Collate Database_Default NULL,
 CONSTRAINT [PK__UserLoginUserProfile] PRIMARY KEY CLUSTERED ([UserId], [UserProfileId]),
 CONSTRAINT [FK__UserLoginUserProfile_UserLogin]    FOREIGN KEY ([UserId])        REFERENCES [UserLogin]    ([UserId]),
 CONSTRAINT [FK__UserLoginUserProfile_UserProfile]  FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile]  ([UserProfileId])
) ON [PRIMARY]
GO
