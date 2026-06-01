/* =====================================================================
   DDL PART 06 - POS: Monedas, Cierres de Caja, Ventas y Facturas
   Incluye: CurrencyType, DenominationType, CurrencyDenomination,
            ClosingCashierTable, ClosingCashierLine, ClosingCashierMoney,
            SalesOrigin, TransferStatus, SalesOrderStatus, SalesOrder,
            SalesOrderLine, SalesOrderPayment, SalesOrderText,
            InvoiceTable, InvoiceLine, InvoicePayment, AccountsReceivable
   ===================================================================== */

USE POSDB
GO

/* ---- CurrencyType ---- */
CREATE TABLE [dbo].[CurrencyType]
([CurrencyTypeId]	INT          NOT NULL,
 [Name]				VARCHAR(100) Collate Database_Default NOT NULL,
 [Active]			BIT          NOT NULL,
 [Status]			[Char](1)    Collate Database_Default NULL,
 [CreatedBy]        INT          NOT NULL,
 [CreatedDatetime]  DATETIME     NOT NULL,
 [ModifiedBy]       INT          NULL,
 [ModifiedDatetime] DATETIME     NULL,
 [Workstation]      VARCHAR(20)  Collate Database_Default NOT NULL,
 CONSTRAINT [PK__CurrencyType] PRIMARY KEY CLUSTERED ([CurrencyTypeId])
) ON [PRIMARY]
GO

/* ---- DenominationType ---- */
CREATE TABLE [dbo].[DenominationType]
([DenominationTypeId]	INT          NOT NULL,
 [Name]					VARCHAR(100) Collate Database_Default NOT NULL,
 [Status]				[Char](1)    Collate Database_Default NULL,
 [CreatedBy]			INT          NOT NULL,
 [CreatedDatetime]		DATETIME     NOT NULL,
 [ModifiedBy]			INT          NULL,
 [ModifiedDatetime]		DATETIME     NULL,
 [Workstation]			VARCHAR(20)  Collate Database_Default NOT NULL,
 CONSTRAINT [PK__DenominationType] PRIMARY KEY CLUSTERED ([DenominationTypeId])
) ON [PRIMARY]
GO

/* ---- CurrencyDenomination ---- */
CREATE TABLE [dbo].[CurrencyDenomination]
([CurrencyDenominationId]	INT           NOT NULL,
 [CurrencyTypeId]			INT           NOT NULL,
 [DenominationTypeId]		INT           NOT NULL,
 [Value]					NUMERIC(18,2) NOT NULL,
 [Status]					[Char](1)     Collate Database_Default NULL,
 [CreatedBy]				INT           NOT NULL,
 [CreatedDatetime]			DATETIME      NOT NULL,
 [ModifiedBy]				INT           NULL,
 [ModifiedDatetime]			DATETIME      NULL,
 [Workstation]				VARCHAR(20)   Collate Database_Default NOT NULL,
 CONSTRAINT [PK__CurrencyDenomination] PRIMARY KEY CLUSTERED ([CurrencyDenominationId]),
 CONSTRAINT [FK__CurrencyDenomination_CurrencyType]     FOREIGN KEY ([CurrencyTypeId])     REFERENCES [CurrencyType]     ([CurrencyTypeId]),
 CONSTRAINT [FK__CurrencyDenomination_DenominationType] FOREIGN KEY ([DenominationTypeId]) REFERENCES [DenominationType] ([DenominationTypeId])
) ON [PRIMARY]
GO

/* ---- ClosingCashierTable ---- */
CREATE TABLE [dbo].[ClosingCashierTable]
([ClosingCashierId]			BIGINT         NOT NULL,
 [ClosingCashierIdLocal]	BIGINT         IDENTITY NOT NULL,
 [LocationId]				SMALLINT       NOT NULL,
 [EmissionPointId]			INT            NOT NULL,
 [UserId]					INT            NOT NULL,
 [ClosingCashierDate]		DATETIME       NOT NULL,
 [Type]						[Char](1)      Collate Database_Default NULL,
 [ClosingCashierIdParent]	BIGINT         NOT NULL,
 [OpeningAmount]			NUMERIC(18,2)  NOT NULL,
 [Authorization]			VARCHAR(40)    Collate Database_Default NOT NULL,
 [Status]					[Char](1)      Collate Database_Default NULL,
 [CreatedBy]				INT            NOT NULL,
 [CreatedDatetime]			DATETIME       NOT NULL,
 [ModifiedBy]				INT            NULL,
 [ModifiedDatetime]			DATETIME       NULL,
 [Workstation]				VARCHAR(20)    Collate Database_Default NOT NULL,
 [ReasonId]					INT            NULL,
 CONSTRAINT [PK__ClosingCashierTable] PRIMARY KEY CLUSTERED ([ClosingCashierId]),
 CONSTRAINT [FK__ClosingCashierTable_EmissionPoint] FOREIGN KEY ([EmissionPointId]) REFERENCES [EmissionPoint] ([EmissionPointId]),
 CONSTRAINT [FK__ClosingCashierTable_Location]      FOREIGN KEY ([LocationId])      REFERENCES [Location]      ([LocationId])
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [Ind_ClosingCashierTable_1] ON [dbo].[ClosingCashierTable] ([LocationId] ASC, [EmissionPointId] ASC, [UserId] ASC, [Type] ASC, [ClosingCashierIdParent] ASC, [Status] ASC, [ClosingCashierDate] ASC)
GO
CREATE NONCLUSTERED INDEX [Ind_ClosingCashierTable_2] ON [dbo].[ClosingCashierTable] ([LocationId] ASC, [EmissionPointId] ASC, [UserId] ASC, [Type] ASC, [Status] ASC) INCLUDE ([ClosingCashierDate], [CreatedDatetime])
GO
CREATE NONCLUSTERED INDEX [Ind_ClosingCashierTable_3] ON [dbo].[ClosingCashierTable] ([ClosingCashierIdParent] ASC, [Status] ASC)
GO
CREATE NONCLUSTERED INDEX [Ind_ClosingCashierTable_4] ON [dbo].[ClosingCashierTable] ([Type] ASC, [ClosingCashierIdParent] ASC, [Status] ASC)
GO
CREATE NONCLUSTERED INDEX [Ind_ClosingCashierTable_5] ON [dbo].[ClosingCashierTable] ([ClosingCashierIdLocal] ASC)
GO
CREATE NONCLUSTERED INDEX [Ind_ClosingCashierTable_6] ON [dbo].[ClosingCashierTable] ([ClosingCashierDate] ASC) INCLUDE ([EmissionPointId], [UserId])
GO

/* ---- ClosingCashierLine ---- */
CREATE TABLE [dbo].[ClosingCashierLine]
([ClosingCashierId]		BIGINT         NOT NULL,
 [Sequence]				INT            NOT NULL,
 [PaymModeId]			INT            NOT NULL,
 [CashierAmount]		NUMERIC(18,2)  NOT NULL,
 [SystemAmount]			NUMERIC(18,2)  NOT NULL,
 [Status]				[Char](1)      Collate Database_Default NULL,
 [CreatedBy]			INT            NOT NULL,
 [CreatedDatetime]		DATETIME       NOT NULL,
 [ModifiedBy]			INT            NULL,
 [ModifiedDatetime]		DATETIME       NULL,
 [Workstation]			VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__ClosingCashierLine] PRIMARY KEY CLUSTERED ([ClosingCashierId], [Sequence]),
 CONSTRAINT [FK__ClosingCashierLine_ClosingCashierTable] FOREIGN KEY ([ClosingCashierId]) REFERENCES [ClosingCashierTable] ([ClosingCashierId]),
 CONSTRAINT [FK__ClosingCashierLine_PaymMode]            FOREIGN KEY ([PaymModeId])       REFERENCES [PaymMode]            ([PaymModeId])
) ON [PRIMARY]
GO

/* ---- ClosingCashierMoney ---- */
CREATE TABLE [dbo].[ClosingCashierMoney]
([ClosingCashierId]			BIGINT         NOT NULL,
 [Sequence]					INT            NOT NULL,
 [CurrencyDenominationId]	INT            NOT NULL,
 [Quantity]					NUMERIC(18,2)  NOT NULL,
 [Status]					[Char](1)      Collate Database_Default NULL,
 [CreatedBy]				INT            NOT NULL,
 [CreatedDatetime]			DATETIME       NOT NULL,
 [ModifiedBy]				INT            NULL,
 [ModifiedDatetime]			DATETIME       NULL,
 [Workstation]				VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__ClosingCashierMoney] PRIMARY KEY CLUSTERED ([ClosingCashierId], [Sequence]),
 CONSTRAINT [FK__ClosingCashierMoney_CurrencyDenomination] FOREIGN KEY ([CurrencyDenominationId]) REFERENCES [CurrencyDenomination] ([CurrencyDenominationId])
) ON [PRIMARY]
GO

/* ---- SalesOrigin ---- */
CREATE TABLE [dbo].[SalesOrigin]
([SalesOriginId]	INT          NOT NULL,
 [Name]				VARCHAR(100) Collate Database_Default NOT NULL,
 [SalesmanId]		INT          NOT NULL,
 [IsECommerce]		[BIT]        NOT NULL,
 [AllowCredit]		[BIT]        NOT NULL,
 [Status]			[Char](1)    Collate Database_Default NULL,
 [CreatedBy]		INT          NOT NULL,
 [CreatedDatetime]	DATETIME     NOT NULL,
 [ModifiedBy]		INT          NULL,
 [ModifiedDatetime]	DATETIME     NULL,
 [Workstation]		VARCHAR(20)  Collate Database_Default NOT NULL,
 CONSTRAINT [PK__SalesOrigin] PRIMARY KEY CLUSTERED ([SalesOriginId]),
 CONSTRAINT [FK__SalesOrigin_Salesman] FOREIGN KEY ([SalesmanId]) REFERENCES [Salesman] ([SalesmanId])
) ON [PRIMARY]
GO

/* ---- TransferStatus ---- */
CREATE TABLE [dbo].[TransferStatus]
([TransferStatusId]		INT          NOT NULL,
 [Name]					[varchar](50) Collate Database_Default NULL,
 [Status]				[Char](1)    Collate Database_Default NULL,
 [CreatedBy]			INT          NOT NULL,
 [CreatedDatetime]		DATETIME     NOT NULL,
 [ModifiedBy]			INT          NULL,
 [ModifiedDatetime]		DATETIME     NULL,
 [Workstation]			VARCHAR(20)  Collate Database_Default NOT NULL,
 CONSTRAINT [PK__TransferStatus] PRIMARY KEY CLUSTERED ([TransferStatusId])) ON [PRIMARY]
GO

/* ---- SalesOrderStatus ---- */
CREATE TABLE [dbo].[SalesOrderStatus]
([SalesOrderStatusId]	INT           NOT NULL,
 [ShortCode]			CHAR(1)       NOT NULL,
 [Name]					VARCHAR(200)  NOT NULL,
 [Observation]			VARCHAR(200)  NOT NULL,
 [PreviousStatus]		VARCHAR(200)  NULL,
 [Status]				CHAR(1)       DEFAULT ('A') NULL,
 [CreatedBy]			INT           NOT NULL,
 [CreatedDatetime]		DATETIME      NOT NULL,
 [ModifiedBy]			INT           NULL,
 [ModifiedDatetime]		DATETIME      NULL,
 [Workstation]			VARCHAR(20)   Collate Database_Default NOT NULL,
 CONSTRAINT [PK__SalesOrderStatus] PRIMARY KEY CLUSTERED ([SalesOrderStatusId])
) ON [PRIMARY]
GO

/* ---- SalesOrder ---- */
CREATE TABLE [dbo].[SalesOrder]
([SalesOrderId]			BIGINT         NOT NULL,
 [SalesOrderIdLocal]	BIGINT         IDENTITY NOT NULL,
 [LocationId]			SMALLINT       NOT NULL,
 [CustomerId]			BIGINT         NOT NULL,
 [SalesmanId]			INT            NOT NULL,
 [OrderDate]			DATETIME       NOT NULL,
 [SalesOriginId]		INT            NOT NULL,
 [OrderECommerce]		BIGINT         NOT NULL,
 [DeliveryAddress]		VARCHAR(200)   Collate Database_Default NOT NULL,
 [DeliveryDate]			DATETIME       NOT NULL,
 [Recipient]			VARCHAR(200)   Collate Database_Default NOT NULL,
 [BaseAmount]			NUMERIC(18,4)  NOT NULL,
 [BaseTaxAmount]		NUMERIC(18,4)  NOT NULL,
 [Discount]				NUMERIC(18,4)  NOT NULL,
 [TaxPercent]			NUMERIC(5,2)   NOT NULL,
 [TaxAmount]			NUMERIC(18,4)  NOT NULL,
 [IrbpAmount]			NUMERIC(18,4)  NOT NULL,
 [Total]				NUMERIC(18,4)  NOT NULL,
 [ShippingFree]			BIT            NOT NULL,
 [ShippingAmount]		NUMERIC(18,2)  NOT NULL,
 [Observation]			VARCHAR(250)   Collate Database_Default NOT NULL,
 [CustomerAddressId]	BIGINT         NULL,
 [OrderXml]				VARCHAR(MAX)   NULL,
 [Status]				[Char](1)      Collate Database_Default NULL,
 [CreatedBy]			INT            NOT NULL,
 [CreatedDatetime]		DATETIME       NOT NULL,
 [ModifiedBy]			INT            NULL,
 [ModifiedDatetime]		DATETIME       NULL,
 [Workstation]			VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__SalesOrder] PRIMARY KEY CLUSTERED ([SalesOrderId]),
 CONSTRAINT [FK__SalesOrder_Location]    FOREIGN KEY ([LocationId])    REFERENCES [Location]    ([LocationId]),
 CONSTRAINT [FK__SalesOrder_Customer]    FOREIGN KEY ([CustomerId])    REFERENCES [Customer]    ([CustomerId]),
 CONSTRAINT [FK__SalesOrder_Salesman]    FOREIGN KEY ([SalesmanId])    REFERENCES [Salesman]    ([SalesmanId]),
 CONSTRAINT [FK__SalesOrder_SalesOrigin] FOREIGN KEY ([SalesOriginId]) REFERENCES [SalesOrigin] ([SalesOriginId])
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [Ind_SalesOrder_1] ON [dbo].[SalesOrder] ([CustomerId] ASC)
GO
CREATE NONCLUSTERED INDEX [Ind_SalesOrder_2] ON [dbo].[SalesOrder] ([LocationId] ASC) INCLUDE ([CustomerId], [OrderDate], [SalesOriginId], [OrderECommerce], [Status])
GO
CREATE NONCLUSTERED INDEX [Ind_SalesOrder_3] ON [dbo].[SalesOrder] ([LocationId] ASC, [Status] ASC) INCLUDE ([CustomerId], [OrderDate], [SalesOriginId], [OrderECommerce])
GO
CREATE NONCLUSTERED INDEX [Ind_SalesOrder_4] ON [dbo].[SalesOrder] ([OrderDate] ASC, [Observation] ASC) INCLUDE ([LocationId], [CustomerId], [DeliveryAddress], [CustomerAddressId])
GO
CREATE NONCLUSTERED INDEX [Ind_SalesOrder_5] ON [dbo].[SalesOrder] ([OrderECommerce] ASC)
GO
CREATE NONCLUSTERED INDEX [Ind_SalesOrder_6] ON [dbo].[SalesOrder] ([SalesOrderIdLocal] ASC)
GO
CREATE NONCLUSTERED INDEX [Ind_SalesOrder_7] ON [dbo].[SalesOrder] ([Status] ASC) INCLUDE ([CustomerId], [OrderDate], [SalesOriginId], [CustomerAddressId])
GO

/* ---- SalesOrderLine ---- */
CREATE TABLE [dbo].[SalesOrderLine]
([SalesOrderId]				BIGINT         NOT NULL,
 [Sequence]					INT            NOT NULL,
 [ProductId]				BIGINT         NOT NULL,
 [Barcode]					[varchar](20)  Collate Database_Default NOT NULL,
 [InventUnitId]				Int            NOT NULL,
 [UseTax]					[BIT]          NOT NULL,
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
 CONSTRAINT [PK__SalesOrderLine] PRIMARY KEY CLUSTERED ([SalesOrderId], [Sequence]),
 CONSTRAINT [FK__SalesOrderLine_SalesOrder] FOREIGN KEY ([SalesOrderId]) REFERENCES [SalesOrder]  ([SalesOrderId]),
 CONSTRAINT [FK__SalesOrderLine_Product]    FOREIGN KEY ([ProductId])    REFERENCES [Product]     ([ProductId]),
 CONSTRAINT [FK__SalesOrderLine_InventUnit] FOREIGN KEY ([InventUnitId]) REFERENCES [InventUnit]  ([InventUnitId])
) ON [PRIMARY]
GO

/* ---- SalesOrderPayment ---- */
CREATE TABLE [dbo].[SalesOrderPayment]
([SalesOrderId]			BIGINT         NOT NULL,
 [Sequence]				INT            NOT NULL,
 [PaymModeId]			INT            NOT NULL,
 [Amount]				NUMERIC(18,2)  NOT NULL,
 [BankId]               INT            DEFAULT ('') NOT NULL,
 [CreditCardId]         INT            DEFAULT ('') NOT NULL,
 [LocationId]           SMALLINT       NOT NULL,
 [Received]             NUMERIC(18,2)  NOT NULL,
 [Change]               NUMERIC(18,2)  NOT NULL,
 [PaymentDate]          DATETIME       NOT NULL,
 [AccountNumber]        VARCHAR(20)    NOT NULL,
 [CkeckNumber]          INT            NOT NULL,
 [CkeckType]            VARCHAR(2)     NOT NULL,
 [CkeckDate]            DATETIME       NOT NULL,
 [CheckOwner]           VARCHAR(100)   NOT NULL,
 [Authorization]        VARCHAR(40)    NOT NULL,
 [IsProtest]            BIT            NOT NULL,
 [ProtestDate]          DATETIME       NOT NULL,
 [InternalCreditCardId] BIGINT         NOT NULL,
 [GiftCardNumber]       VARCHAR(20)    NOT NULL,
 [RetentionCode]        INT            NOT NULL,
 [RetentionNumber]      VARCHAR(15)    NOT NULL,
 [Status]				[Char](1)      Collate Database_Default NULL,
 [CreatedBy]			INT            NOT NULL,
 [CreatedDatetime]		DATETIME       NOT NULL,
 [ModifiedBy]			INT            NULL,
 [ModifiedDatetime]		DATETIME       NULL,
 [Workstation]			VARCHAR(20)    Collate Database_Default NOT NULL,
 CONSTRAINT [PK__SalesOrderPayment] PRIMARY KEY CLUSTERED ([SalesOrderId], [Sequence]),
 CONSTRAINT [FK__SalesOrderPayment_SalesOrder] FOREIGN KEY ([SalesOrderId]) REFERENCES [SalesOrder] ([SalesOrderId]),
 CONSTRAINT [FK__SalesOrderPayment_PaymMode]   FOREIGN KEY ([PaymModeId])   REFERENCES [PaymMode]   ([PaymModeId])
) ON [PRIMARY]
GO

/* ---- SalesOrderText ---- */
CREATE TABLE [dbo].[SalesOrderText]
([SalesOrderId]		BIGINT         NOT NULL,
 [Sequence]			INT            NOT NULL,
 [SalesOrderText]	VARCHAR(MAX)   Collate Database_Default NULL,
 [Status]			[Char](1)      Collate Database_Default NULL,
 [CreatedBy]		INT            NOT NULL,
 [CreatedDatetime]	DATETIME       NOT NULL,
 [ModifiedBy]		INT            NULL,
 [ModifiedDatetime]	DATETIME       NULL,
 [Workstation]		VARCHAR(20)    Collate Database_Default NOT NULL,
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
