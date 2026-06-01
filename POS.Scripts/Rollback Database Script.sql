/*
   =====================================================================
   ROLLBACK SCRIPT - POSDB
   Elimina todos los objetos creados por "Initial Database Script.sql"
   en orden inverso respetando las dependencias de FK.
   =====================================================================
*/

USE MASTER
GO

-- -------------------------------------------------------
-- OPCION 1 (Recomendada): Drop completo de la base de datos
-- Elimina todos los objetos de una sola vez.
-- -------------------------------------------------------
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'POSDB')
BEGIN
    ALTER DATABASE POSDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE
    DROP DATABASE POSDB
END
GO

/*
-- -------------------------------------------------------
-- OPCION 2: Drop individual de cada objeto (por si se
-- necesita hacer rollback dentro de una base existente).
-- Descomentar si se prefiere esta opcion.
-- -------------------------------------------------------

USE POSDB
GO

-- Indexes independientes
IF EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'Ind_CustomerAddress_2'        AND object_id = OBJECT_ID('CustomerAddress'))        DROP INDEX Ind_CustomerAddress_2        ON [dbo].[CustomerAddress]
IF EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'Ind_SalesRemissionLine_3'     AND object_id = OBJECT_ID('SalesRemissionLine'))      DROP INDEX Ind_SalesRemissionLine_3     ON [dbo].[SalesRemissionLine]
IF EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'Ind_SalesRemissionLine_1'     AND object_id = OBJECT_ID('SalesRemissionLine'))      DROP INDEX Ind_SalesRemissionLine_1     ON [dbo].[SalesRemissionLine]
GO

-- -------------------------------------------------------
-- Tablas hoja (sin dependientes)
-- -------------------------------------------------------
IF OBJECT_ID('dbo.UserLoginUserProfile',          'U') IS NOT NULL DROP TABLE [dbo].[UserLoginUserProfile]
IF OBJECT_ID('dbo.UserProfileProgram',            'U') IS NOT NULL DROP TABLE [dbo].[UserProfileProgram]
IF OBJECT_ID('dbo.SalesLog',                      'U') IS NOT NULL DROP TABLE [dbo].[SalesLog]
IF OBJECT_ID('dbo.PhysicalStockCountingLine',     'U') IS NOT NULL DROP TABLE [dbo].[PhysicalStockCountingLine]
IF OBJECT_ID('dbo.PhysicalStockCountingTable',    'U') IS NOT NULL DROP TABLE [dbo].[PhysicalStockCountingTable]
IF OBJECT_ID('dbo.SalesRemissionLine',            'U') IS NOT NULL DROP TABLE [dbo].[SalesRemissionLine]
IF OBJECT_ID('dbo.SalesRemissionTable',           'U') IS NOT NULL DROP TABLE [dbo].[SalesRemissionTable]
IF OBJECT_ID('dbo.GiftCardTrans',                 'U') IS NOT NULL DROP TABLE [dbo].[GiftCardTrans]
IF OBJECT_ID('dbo.GiftCardLineProduct',           'U') IS NOT NULL DROP TABLE [dbo].[GiftCardLineProduct]
IF OBJECT_ID('dbo.GiftCardLine',                  'U') IS NOT NULL DROP TABLE [dbo].[GiftCardLine]
IF OBJECT_ID('dbo.GiftCardTable',                 'U') IS NOT NULL DROP TABLE [dbo].[GiftCardTable]
IF OBJECT_ID('dbo.GiftCardBlockLine',             'U') IS NOT NULL DROP TABLE [dbo].[GiftCardBlockLine]
IF OBJECT_ID('dbo.GiftCardBlockTable',            'U') IS NOT NULL DROP TABLE [dbo].[GiftCardBlockTable]
IF OBJECT_ID('dbo.AccountsReceivable',            'U') IS NOT NULL DROP TABLE [dbo].[AccountsReceivable]
IF OBJECT_ID('dbo.InvoicePayment',                'U') IS NOT NULL DROP TABLE [dbo].[InvoicePayment]
IF OBJECT_ID('dbo.InvoiceLine',                   'U') IS NOT NULL DROP TABLE [dbo].[InvoiceLine]
IF OBJECT_ID('dbo.InvoiceTable',                  'U') IS NOT NULL DROP TABLE [dbo].[InvoiceTable]
IF OBJECT_ID('dbo.SalesOrderText',                'U') IS NOT NULL DROP TABLE [dbo].[SalesOrderText]
IF OBJECT_ID('dbo.SalesOrderPayment',             'U') IS NOT NULL DROP TABLE [dbo].[SalesOrderPayment]
IF OBJECT_ID('dbo.SalesOrderLine',                'U') IS NOT NULL DROP TABLE [dbo].[SalesOrderLine]
IF OBJECT_ID('dbo.SalesOrder',                    'U') IS NOT NULL DROP TABLE [dbo].[SalesOrder]
IF OBJECT_ID('dbo.SalesOrderStatus',              'U') IS NOT NULL DROP TABLE [dbo].[SalesOrderStatus]
IF OBJECT_ID('dbo.ClosingCashierMoney',           'U') IS NOT NULL DROP TABLE [dbo].[ClosingCashierMoney]
IF OBJECT_ID('dbo.ClosingCashierLine',            'U') IS NOT NULL DROP TABLE [dbo].[ClosingCashierLine]
IF OBJECT_ID('dbo.ClosingCashierTable',           'U') IS NOT NULL DROP TABLE [dbo].[ClosingCashierTable]
IF OBJECT_ID('dbo.SequenceTable',                 'U') IS NOT NULL DROP TABLE [dbo].[SequenceTable]
IF OBJECT_ID('dbo.SequenceType',                  'U') IS NOT NULL DROP TABLE [dbo].[SequenceType]
IF OBJECT_ID('dbo.EmissionPoint',                 'U') IS NOT NULL DROP TABLE [dbo].[EmissionPoint]
IF OBJECT_ID('dbo.InternalCreditCardLine',        'U') IS NOT NULL DROP TABLE [dbo].[InternalCreditCardLine]
IF OBJECT_ID('dbo.InternalCreditCard',            'U') IS NOT NULL DROP TABLE [dbo].[InternalCreditCard]
IF OBJECT_ID('dbo.PromotionReward',               'U') IS NOT NULL DROP TABLE [dbo].[PromotionReward]
IF OBJECT_ID('dbo.PromotionProducts',             'U') IS NOT NULL DROP TABLE [dbo].[PromotionProducts]
IF OBJECT_ID('dbo.PromotionPaymMode',             'U') IS NOT NULL DROP TABLE [dbo].[PromotionPaymMode]
IF OBJECT_ID('dbo.PromotionCustomer',             'U') IS NOT NULL DROP TABLE [dbo].[PromotionCustomer]
IF OBJECT_ID('dbo.PromotionTable',                'U') IS NOT NULL DROP TABLE [dbo].[PromotionTable]
IF OBJECT_ID('dbo.PromotionType',                 'U') IS NOT NULL DROP TABLE [dbo].[PromotionType]
IF OBJECT_ID('dbo.InventProductLocation',         'U') IS NOT NULL DROP TABLE [dbo].[InventProductLocation]
IF OBJECT_ID('dbo.ProductModule',                 'U') IS NOT NULL DROP TABLE [dbo].[ProductModule]
IF OBJECT_ID('dbo.ProductBarcode',                'U') IS NOT NULL DROP TABLE [dbo].[ProductBarcode]
IF OBJECT_ID('dbo.Product',                       'U') IS NOT NULL DROP TABLE [dbo].[Product]
IF OBJECT_ID('dbo.InventTransType',               'U') IS NOT NULL DROP TABLE [dbo].[InventTransType]
IF OBJECT_ID('dbo.InventUnit',                    'U') IS NOT NULL DROP TABLE [dbo].[InventUnit]
IF OBJECT_ID('dbo.InventLocation',                'U') IS NOT NULL DROP TABLE [dbo].[InventLocation]
IF OBJECT_ID('dbo.ProductCategory',               'U') IS NOT NULL DROP TABLE [dbo].[ProductCategory]
IF OBJECT_ID('dbo.ProductGroup',                  'U') IS NOT NULL DROP TABLE [dbo].[ProductGroup]
IF OBJECT_ID('dbo.Brand',                         'U') IS NOT NULL DROP TABLE [dbo].[Brand]
IF OBJECT_ID('dbo.CustomerAddress',               'U') IS NOT NULL DROP TABLE [dbo].[CustomerAddress]
IF OBJECT_ID('dbo.Customer',                      'U') IS NOT NULL DROP TABLE [dbo].[Customer]
IF OBJECT_ID('dbo.CustomerType',                  'U') IS NOT NULL DROP TABLE [dbo].[CustomerType]
IF OBJECT_ID('dbo.Vendor',                        'U') IS NOT NULL DROP TABLE [dbo].[Vendor]
IF OBJECT_ID('dbo.IdentType',                     'U') IS NOT NULL DROP TABLE [dbo].[IdentType]
IF OBJECT_ID('dbo.SalesOrigin',                   'U') IS NOT NULL DROP TABLE [dbo].[SalesOrigin]
IF OBJECT_ID('dbo.Salesman',                      'U') IS NOT NULL DROP TABLE [dbo].[Salesman]
IF OBJECT_ID('dbo.TransferStatus',                'U') IS NOT NULL DROP TABLE [dbo].[TransferStatus]
IF OBJECT_ID('dbo.CurrencyDenomination',          'U') IS NOT NULL DROP TABLE [dbo].[CurrencyDenomination]
IF OBJECT_ID('dbo.DenominationType',              'U') IS NOT NULL DROP TABLE [dbo].[DenominationType]
IF OBJECT_ID('dbo.CurrencyType',                  'U') IS NOT NULL DROP TABLE [dbo].[CurrencyType]
IF OBJECT_ID('dbo.BankCreditCard',                'U') IS NOT NULL DROP TABLE [dbo].[BankCreditCard]
IF OBJECT_ID('dbo.CreditCard',                    'U') IS NOT NULL DROP TABLE [dbo].[CreditCard]
IF OBJECT_ID('dbo.Bank',                          'U') IS NOT NULL DROP TABLE [dbo].[Bank]
IF OBJECT_ID('dbo.PaymMode',                      'U') IS NOT NULL DROP TABLE [dbo].[PaymMode]
IF OBJECT_ID('dbo.RetentionTable',                'U') IS NOT NULL DROP TABLE [dbo].[RetentionTable]
IF OBJECT_ID('dbo.TaxTable',                      'U') IS NOT NULL DROP TABLE [dbo].[TaxTable]
IF OBJECT_ID('dbo.TransportReason',               'U') IS NOT NULL DROP TABLE [dbo].[TransportReason]
IF OBJECT_ID('dbo.TransportDriver',               'U') IS NOT NULL DROP TABLE [dbo].[TransportDriver]
IF OBJECT_ID('dbo.Transport',                     'U') IS NOT NULL DROP TABLE [dbo].[Transport]
IF OBJECT_ID('dbo.Location',                      'U') IS NOT NULL DROP TABLE [dbo].[Location]
IF OBJECT_ID('dbo.Company',                       'U') IS NOT NULL DROP TABLE [dbo].[Company]
IF OBJECT_ID('dbo.Supervisor',                    'U') IS NOT NULL DROP TABLE [dbo].[Supervisor]
IF OBJECT_ID('dbo.UserLoginUserProfile',          'U') IS NOT NULL DROP TABLE [dbo].[UserLoginUserProfile]  -- por si no se dropo arriba
IF OBJECT_ID('dbo.UserProfileProgram',            'U') IS NOT NULL DROP TABLE [dbo].[UserProfileProgram]
IF OBJECT_ID('dbo.UserProfile',                   'U') IS NOT NULL DROP TABLE [dbo].[UserProfile]
IF OBJECT_ID('dbo.Program',                       'U') IS NOT NULL DROP TABLE [dbo].[Program]
IF OBJECT_ID('dbo.UserLogin',                     'U') IS NOT NULL DROP TABLE [dbo].[UserLogin]
IF OBJECT_ID('dbo.Server',                        'U') IS NOT NULL DROP TABLE [dbo].[Server]
IF OBJECT_ID('dbo.City',                          'U') IS NOT NULL DROP TABLE [dbo].[City]
IF OBJECT_ID('dbo.Province',                      'U') IS NOT NULL DROP TABLE [dbo].[Province]
IF OBJECT_ID('dbo.Country',                       'U') IS NOT NULL DROP TABLE [dbo].[Country]
IF OBJECT_ID('dbo.GlobalParameter',               'U') IS NOT NULL DROP TABLE [dbo].[GlobalParameter]
IF OBJECT_ID('dbo.TmpPromoReward',                'U') IS NOT NULL DROP TABLE [dbo].[TmpPromoReward]
IF OBJECT_ID('dbo.ProductCategoryTEMP',           'U') IS NOT NULL DROP TABLE [dbo].[ProductCategoryTEMP]
IF OBJECT_ID('dbo.TransactionLog',                'U') IS NOT NULL DROP TABLE [dbo].[TransactionLog]
IF OBJECT_ID('dbo.CancelReason',                  'U') IS NOT NULL DROP TABLE [dbo].[CancelReason]
IF OBJECT_ID('dbo.LogType',                       'U') IS NOT NULL DROP TABLE [dbo].[LogType]
GO

USE MASTER
GO
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'POSDB')
BEGIN
    ALTER DATABASE POSDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE
    DROP DATABASE POSDB
END
GO
*/
