
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/16/2026 16:53:30
-- Generated from EDMX file: C:\Users\HugoRestrepo\Documents\hrestrepo\omnipos-winforms-mvp\POS.DLL\ModelPOS.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [POSDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__AccountsReceivable_Customer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccountsReceivable] DROP CONSTRAINT [FK__AccountsReceivable_Customer];
GO
IF OBJECT_ID(N'[dbo].[FK__AccountsReceivable_Location]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccountsReceivable] DROP CONSTRAINT [FK__AccountsReceivable_Location];
GO
IF OBJECT_ID(N'[dbo].[FK__BankCreditCard_Bank]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BankCreditCard] DROP CONSTRAINT [FK__BankCreditCard_Bank];
GO
IF OBJECT_ID(N'[dbo].[FK__BankCreditCard_CreditCard]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BankCreditCard] DROP CONSTRAINT [FK__BankCreditCard_CreditCard];
GO
IF OBJECT_ID(N'[dbo].[FK__City_Province]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[City] DROP CONSTRAINT [FK__City_Province];
GO
IF OBJECT_ID(N'[dbo].[FK__ClosingCashierLine_ClosingCashierTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClosingCashierLine] DROP CONSTRAINT [FK__ClosingCashierLine_ClosingCashierTable];
GO
IF OBJECT_ID(N'[dbo].[FK__ClosingCashierLine_PaymMode]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClosingCashierLine] DROP CONSTRAINT [FK__ClosingCashierLine_PaymMode];
GO
IF OBJECT_ID(N'[dbo].[FK__ClosingCashierMoney_CurrencyDenomination]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClosingCashierMoney] DROP CONSTRAINT [FK__ClosingCashierMoney_CurrencyDenomination];
GO
IF OBJECT_ID(N'[dbo].[FK__ClosingCashierTable_Location]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClosingCashierTable] DROP CONSTRAINT [FK__ClosingCashierTable_Location];
GO
IF OBJECT_ID(N'[dbo].[FK__Company_City]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Company] DROP CONSTRAINT [FK__Company_City];
GO
IF OBJECT_ID(N'[dbo].[FK__CurrencyDenomination_CurrencyType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CurrencyDenomination] DROP CONSTRAINT [FK__CurrencyDenomination_CurrencyType];
GO
IF OBJECT_ID(N'[dbo].[FK__CurrencyDenomination_DenominationType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CurrencyDenomination] DROP CONSTRAINT [FK__CurrencyDenomination_DenominationType];
GO
IF OBJECT_ID(N'[dbo].[FK__Customer_City]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Customer] DROP CONSTRAINT [FK__Customer_City];
GO
IF OBJECT_ID(N'[dbo].[FK__Customer_CustomerType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Customer] DROP CONSTRAINT [FK__Customer_CustomerType];
GO
IF OBJECT_ID(N'[dbo].[FK__Customer_IdentType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Customer] DROP CONSTRAINT [FK__Customer_IdentType];
GO
IF OBJECT_ID(N'[dbo].[FK__Customer_Location]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Customer] DROP CONSTRAINT [FK__Customer_Location];
GO
IF OBJECT_ID(N'[dbo].[FK__CustomerAddress_Customer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomerAddress] DROP CONSTRAINT [FK__CustomerAddress_Customer];
GO
IF OBJECT_ID(N'[dbo].[FK__EmissionPoint_InventLocation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmissionPoint] DROP CONSTRAINT [FK__EmissionPoint_InventLocation];
GO
IF OBJECT_ID(N'[dbo].[FK__EmissionPoint_Location]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmissionPoint] DROP CONSTRAINT [FK__EmissionPoint_Location];
GO
IF OBJECT_ID(N'[dbo].[FK__GiftCardBlockLine_GiftCardBlockTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GiftCardBlockLine] DROP CONSTRAINT [FK__GiftCardBlockLine_GiftCardBlockTable];
GO
IF OBJECT_ID(N'[dbo].[FK__GiftCardBlockTable_Location]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GiftCardBlockTable] DROP CONSTRAINT [FK__GiftCardBlockTable_Location];
GO
IF OBJECT_ID(N'[dbo].[FK__GiftCardLine_Customer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GiftCardLine] DROP CONSTRAINT [FK__GiftCardLine_Customer];
GO
IF OBJECT_ID(N'[dbo].[FK__GiftCardLine_GiftCardTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GiftCardLine] DROP CONSTRAINT [FK__GiftCardLine_GiftCardTable];
GO
IF OBJECT_ID(N'[dbo].[FK__GiftCardLineProduct_GiftCardLine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GiftCardLineProduct] DROP CONSTRAINT [FK__GiftCardLineProduct_GiftCardLine];
GO
IF OBJECT_ID(N'[dbo].[FK__GiftCardLineProduct_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GiftCardLineProduct] DROP CONSTRAINT [FK__GiftCardLineProduct_Product];
GO
IF OBJECT_ID(N'[dbo].[FK__GiftCardTable_Customer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GiftCardTable] DROP CONSTRAINT [FK__GiftCardTable_Customer];
GO
IF OBJECT_ID(N'[dbo].[FK__GiftCardTable_GiftCardBlockTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GiftCardTable] DROP CONSTRAINT [FK__GiftCardTable_GiftCardBlockTable];
GO
IF OBJECT_ID(N'[dbo].[FK__GiftCardTable_Location]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GiftCardTable] DROP CONSTRAINT [FK__GiftCardTable_Location];
GO
IF OBJECT_ID(N'[dbo].[FK__GiftCardTable_LocationOrigin]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GiftCardTable] DROP CONSTRAINT [FK__GiftCardTable_LocationOrigin];
GO
IF OBJECT_ID(N'[dbo].[FK__GiftCardTrans_GiftCardLine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GiftCardTrans] DROP CONSTRAINT [FK__GiftCardTrans_GiftCardLine];
GO
IF OBJECT_ID(N'[dbo].[FK__GiftCardTrans_LocationRedeem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GiftCardTrans] DROP CONSTRAINT [FK__GiftCardTrans_LocationRedeem];
GO
IF OBJECT_ID(N'[dbo].[FK__InternalCreditCard_Customer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InternalCreditCard] DROP CONSTRAINT [FK__InternalCreditCard_Customer];
GO
IF OBJECT_ID(N'[dbo].[FK__InternalCreditCardLine_InternalCreditCard]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InternalCreditCardLine] DROP CONSTRAINT [FK__InternalCreditCardLine_InternalCreditCard];
GO
IF OBJECT_ID(N'[dbo].[FK__InternalCreditCardLine_PromotionTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InternalCreditCardLine] DROP CONSTRAINT [FK__InternalCreditCardLine_PromotionTable];
GO
IF OBJECT_ID(N'[dbo].[FK__InventLocation_Location]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InventLocation] DROP CONSTRAINT [FK__InventLocation_Location];
GO
IF OBJECT_ID(N'[dbo].[FK__InventProductLocation_InventLocation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InventProductLocation] DROP CONSTRAINT [FK__InventProductLocation_InventLocation];
GO
IF OBJECT_ID(N'[dbo].[FK__InventProductLocation_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InventProductLocation] DROP CONSTRAINT [FK__InventProductLocation_Product];
GO
IF OBJECT_ID(N'[dbo].[FK__InvoiceLine_InventUnit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvoiceLine] DROP CONSTRAINT [FK__InvoiceLine_InventUnit];
GO
IF OBJECT_ID(N'[dbo].[FK__InvoiceLine_InvoiceTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvoiceLine] DROP CONSTRAINT [FK__InvoiceLine_InvoiceTable];
GO
IF OBJECT_ID(N'[dbo].[FK__InvoiceLine_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvoiceLine] DROP CONSTRAINT [FK__InvoiceLine_Product];
GO
IF OBJECT_ID(N'[dbo].[FK__InvoicePayment_InvoiceTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvoicePayment] DROP CONSTRAINT [FK__InvoicePayment_InvoiceTable];
GO
IF OBJECT_ID(N'[dbo].[FK__InvoicePayment_Location]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvoicePayment] DROP CONSTRAINT [FK__InvoicePayment_Location];
GO
IF OBJECT_ID(N'[dbo].[FK__InvoicePayment_PaymMode]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvoicePayment] DROP CONSTRAINT [FK__InvoicePayment_PaymMode];
GO
IF OBJECT_ID(N'[dbo].[FK__InvoiceTable_Customer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvoiceTable] DROP CONSTRAINT [FK__InvoiceTable_Customer];
GO
IF OBJECT_ID(N'[dbo].[FK__InvoiceTable_EmissionPoint]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvoiceTable] DROP CONSTRAINT [FK__InvoiceTable_EmissionPoint];
GO
IF OBJECT_ID(N'[dbo].[FK__InvoiceTable_Location]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvoiceTable] DROP CONSTRAINT [FK__InvoiceTable_Location];
GO
IF OBJECT_ID(N'[dbo].[FK__InvoiceTable_Salesman]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvoiceTable] DROP CONSTRAINT [FK__InvoiceTable_Salesman];
GO
IF OBJECT_ID(N'[dbo].[FK__InvoiceTable_SalesOrigin]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvoiceTable] DROP CONSTRAINT [FK__InvoiceTable_SalesOrigin];
GO
IF OBJECT_ID(N'[dbo].[FK__InvoiceTable_TransferStatus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvoiceTable] DROP CONSTRAINT [FK__InvoiceTable_TransferStatus];
GO
IF OBJECT_ID(N'[dbo].[FK__Location_City]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Location] DROP CONSTRAINT [FK__Location_City];
GO
IF OBJECT_ID(N'[dbo].[FK__Location_Company]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Location] DROP CONSTRAINT [FK__Location_Company];
GO
IF OBJECT_ID(N'[dbo].[FK__PhysicalStockCountingLine_InventUnit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PhysicalStockCountingLine] DROP CONSTRAINT [FK__PhysicalStockCountingLine_InventUnit];
GO
IF OBJECT_ID(N'[dbo].[FK__PhysicalStockCountingLine_PhysicalStockCountingTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PhysicalStockCountingLine] DROP CONSTRAINT [FK__PhysicalStockCountingLine_PhysicalStockCountingTable];
GO
IF OBJECT_ID(N'[dbo].[FK__PhysicalStockCountingLine_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PhysicalStockCountingLine] DROP CONSTRAINT [FK__PhysicalStockCountingLine_Product];
GO
IF OBJECT_ID(N'[dbo].[FK__PhysicalStockCountingTable_InventLocation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PhysicalStockCountingTable] DROP CONSTRAINT [FK__PhysicalStockCountingTable_InventLocation];
GO
IF OBJECT_ID(N'[dbo].[FK__PhysicalStockCountingTable_Location]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PhysicalStockCountingTable] DROP CONSTRAINT [FK__PhysicalStockCountingTable_Location];
GO
IF OBJECT_ID(N'[dbo].[FK__Product_Brand]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK__Product_Brand];
GO
IF OBJECT_ID(N'[dbo].[FK__Product_InventUnit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK__Product_InventUnit];
GO
IF OBJECT_ID(N'[dbo].[FK__Product_ProductCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK__Product_ProductCategory];
GO
IF OBJECT_ID(N'[dbo].[FK__Product_ProductGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK__Product_ProductGroup];
GO
IF OBJECT_ID(N'[dbo].[FK__Product_VendorId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK__Product_VendorId];
GO
IF OBJECT_ID(N'[dbo].[FK__ProductBarcode_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductBarcode] DROP CONSTRAINT [FK__ProductBarcode_Product];
GO
IF OBJECT_ID(N'[dbo].[FK__ProductModule_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductModule] DROP CONSTRAINT [FK__ProductModule_Product];
GO
IF OBJECT_ID(N'[dbo].[FK__PromotionCustomer_Customer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PromotionCustomer] DROP CONSTRAINT [FK__PromotionCustomer_Customer];
GO
IF OBJECT_ID(N'[dbo].[FK__PromotionCustomer_PromotionTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PromotionCustomer] DROP CONSTRAINT [FK__PromotionCustomer_PromotionTable];
GO
IF OBJECT_ID(N'[dbo].[FK__PromotionPaymMode_PaymMode]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PromotionPaymMode] DROP CONSTRAINT [FK__PromotionPaymMode_PaymMode];
GO
IF OBJECT_ID(N'[dbo].[FK__PromotionPaymMode_PromotionTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PromotionPaymMode] DROP CONSTRAINT [FK__PromotionPaymMode_PromotionTable];
GO
IF OBJECT_ID(N'[dbo].[FK__PromotionProducts_PromotionTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PromotionProducts] DROP CONSTRAINT [FK__PromotionProducts_PromotionTable];
GO
IF OBJECT_ID(N'[dbo].[FK__PromotionReward_PromotionTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PromotionReward] DROP CONSTRAINT [FK__PromotionReward_PromotionTable];
GO
IF OBJECT_ID(N'[dbo].[FK__PromotionTable_PromotionType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PromotionTable] DROP CONSTRAINT [FK__PromotionTable_PromotionType];
GO
IF OBJECT_ID(N'[dbo].[FK__Province_Country]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Province] DROP CONSTRAINT [FK__Province_Country];
GO
IF OBJECT_ID(N'[dbo].[FK__SalesLog_LogType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SalesLog] DROP CONSTRAINT [FK__SalesLog_LogType];
GO
IF OBJECT_ID(N'[dbo].[FK__SalesOrder_Customer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SalesOrder] DROP CONSTRAINT [FK__SalesOrder_Customer];
GO
IF OBJECT_ID(N'[dbo].[FK__SalesOrder_Location]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SalesOrder] DROP CONSTRAINT [FK__SalesOrder_Location];
GO
IF OBJECT_ID(N'[dbo].[FK__SalesOrder_Salesman]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SalesOrder] DROP CONSTRAINT [FK__SalesOrder_Salesman];
GO
IF OBJECT_ID(N'[dbo].[FK__SalesOrder_SalesOrigin]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SalesOrder] DROP CONSTRAINT [FK__SalesOrder_SalesOrigin];
GO
IF OBJECT_ID(N'[dbo].[FK__SalesOrderLine_InventUnit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SalesOrderLine] DROP CONSTRAINT [FK__SalesOrderLine_InventUnit];
GO
IF OBJECT_ID(N'[dbo].[FK__SalesOrderLine_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SalesOrderLine] DROP CONSTRAINT [FK__SalesOrderLine_Product];
GO
IF OBJECT_ID(N'[dbo].[FK__SalesOrderLine_SalesOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SalesOrderLine] DROP CONSTRAINT [FK__SalesOrderLine_SalesOrder];
GO
IF OBJECT_ID(N'[dbo].[FK__SalesOrderPayment_PaymMode]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SalesOrderPayment] DROP CONSTRAINT [FK__SalesOrderPayment_PaymMode];
GO
IF OBJECT_ID(N'[dbo].[FK__SalesOrderPayment_SalesOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SalesOrderPayment] DROP CONSTRAINT [FK__SalesOrderPayment_SalesOrder];
GO
IF OBJECT_ID(N'[dbo].[FK__SalesOrderText_FACTrPedidoCab]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SalesOrderText] DROP CONSTRAINT [FK__SalesOrderText_FACTrPedidoCab];
GO
IF OBJECT_ID(N'[dbo].[FK__SalesOrigin_Salesman]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SalesOrigin] DROP CONSTRAINT [FK__SalesOrigin_Salesman];
GO
IF OBJECT_ID(N'[dbo].[FK__SalesRemissionLine_SalesRemissionTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SalesRemissionLine] DROP CONSTRAINT [FK__SalesRemissionLine_SalesRemissionTable];
GO
IF OBJECT_ID(N'[dbo].[FK__SalesRemissionTable_EmissionPoint]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SalesRemissionTable] DROP CONSTRAINT [FK__SalesRemissionTable_EmissionPoint];
GO
IF OBJECT_ID(N'[dbo].[FK__SalesRemissionTable_Location]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SalesRemissionTable] DROP CONSTRAINT [FK__SalesRemissionTable_Location];
GO
IF OBJECT_ID(N'[dbo].[FK__SalesRemissionTable_Transport]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SalesRemissionTable] DROP CONSTRAINT [FK__SalesRemissionTable_Transport];
GO
IF OBJECT_ID(N'[dbo].[FK__SalesRemissionTable_TransportDriver]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SalesRemissionTable] DROP CONSTRAINT [FK__SalesRemissionTable_TransportDriver];
GO
IF OBJECT_ID(N'[dbo].[FK__SalesRemissionTable_TransportReason]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SalesRemissionTable] DROP CONSTRAINT [FK__SalesRemissionTable_TransportReason];
GO
IF OBJECT_ID(N'[dbo].[FK__SequenceTable_Location]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SequenceTable] DROP CONSTRAINT [FK__SequenceTable_Location];
GO
IF OBJECT_ID(N'[dbo].[FK__SequenceTable_SequenceType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SequenceTable] DROP CONSTRAINT [FK__SequenceTable_SequenceType];
GO
IF OBJECT_ID(N'[dbo].[FK__Supervisor_UserLogin]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Supervisor] DROP CONSTRAINT [FK__Supervisor_UserLogin];
GO
IF OBJECT_ID(N'[dbo].[FK__Vendor_City]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vendor] DROP CONSTRAINT [FK__Vendor_City];
GO
IF OBJECT_ID(N'[dbo].[FK__Vendor_CustIdType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vendor] DROP CONSTRAINT [FK__Vendor_CustIdType];
GO
IF OBJECT_ID(N'[dbo].[FK_PK__ClosingCashierTable_EmissionPoint]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClosingCashierTable] DROP CONSTRAINT [FK_PK__ClosingCashierTable_EmissionPoint];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AccountsReceivable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccountsReceivable];
GO
IF OBJECT_ID(N'[dbo].[Bank]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bank];
GO
IF OBJECT_ID(N'[dbo].[BankCreditCard]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BankCreditCard];
GO
IF OBJECT_ID(N'[dbo].[Brand]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Brand];
GO
IF OBJECT_ID(N'[dbo].[CancelReason]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CancelReason];
GO
IF OBJECT_ID(N'[dbo].[City]', 'U') IS NOT NULL
    DROP TABLE [dbo].[City];
GO
IF OBJECT_ID(N'[dbo].[ClosingCashierLine]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClosingCashierLine];
GO
IF OBJECT_ID(N'[dbo].[ClosingCashierMoney]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClosingCashierMoney];
GO
IF OBJECT_ID(N'[dbo].[ClosingCashierTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClosingCashierTable];
GO
IF OBJECT_ID(N'[dbo].[Company]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Company];
GO
IF OBJECT_ID(N'[dbo].[Country]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Country];
GO
IF OBJECT_ID(N'[dbo].[CreditCard]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CreditCard];
GO
IF OBJECT_ID(N'[dbo].[CurrencyDenomination]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CurrencyDenomination];
GO
IF OBJECT_ID(N'[dbo].[CurrencyType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CurrencyType];
GO
IF OBJECT_ID(N'[dbo].[Customer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customer];
GO
IF OBJECT_ID(N'[dbo].[CustomerAddress]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomerAddress];
GO
IF OBJECT_ID(N'[dbo].[CustomerType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomerType];
GO
IF OBJECT_ID(N'[dbo].[DenominationType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DenominationType];
GO
IF OBJECT_ID(N'[dbo].[EmissionPoint]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmissionPoint];
GO
IF OBJECT_ID(N'[dbo].[GiftCardBlockLine]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GiftCardBlockLine];
GO
IF OBJECT_ID(N'[dbo].[GiftCardBlockTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GiftCardBlockTable];
GO
IF OBJECT_ID(N'[dbo].[GiftCardLine]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GiftCardLine];
GO
IF OBJECT_ID(N'[dbo].[GiftCardLineProduct]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GiftCardLineProduct];
GO
IF OBJECT_ID(N'[dbo].[GiftCardTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GiftCardTable];
GO
IF OBJECT_ID(N'[dbo].[GiftCardTrans]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GiftCardTrans];
GO
IF OBJECT_ID(N'[dbo].[GlobalParameter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GlobalParameter];
GO
IF OBJECT_ID(N'[dbo].[IdentType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IdentType];
GO
IF OBJECT_ID(N'[dbo].[InternalCreditCard]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InternalCreditCard];
GO
IF OBJECT_ID(N'[dbo].[InternalCreditCardLine]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InternalCreditCardLine];
GO
IF OBJECT_ID(N'[dbo].[InventLocation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InventLocation];
GO
IF OBJECT_ID(N'[dbo].[InventProductLocation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InventProductLocation];
GO
IF OBJECT_ID(N'[dbo].[InventTransType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InventTransType];
GO
IF OBJECT_ID(N'[dbo].[InventUnit]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InventUnit];
GO
IF OBJECT_ID(N'[dbo].[InvoiceLine]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvoiceLine];
GO
IF OBJECT_ID(N'[dbo].[InvoicePayment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvoicePayment];
GO
IF OBJECT_ID(N'[dbo].[InvoiceTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvoiceTable];
GO
IF OBJECT_ID(N'[dbo].[Location]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Location];
GO
IF OBJECT_ID(N'[dbo].[LogType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LogType];
GO
IF OBJECT_ID(N'[dbo].[PaymMode]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaymMode];
GO
IF OBJECT_ID(N'[dbo].[PhysicalStockCountingLine]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PhysicalStockCountingLine];
GO
IF OBJECT_ID(N'[dbo].[PhysicalStockCountingTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PhysicalStockCountingTable];
GO
IF OBJECT_ID(N'[dbo].[Product]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product];
GO
IF OBJECT_ID(N'[dbo].[ProductBarcode]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductBarcode];
GO
IF OBJECT_ID(N'[dbo].[ProductCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductCategory];
GO
IF OBJECT_ID(N'[dbo].[ProductGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductGroup];
GO
IF OBJECT_ID(N'[dbo].[ProductModule]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductModule];
GO
IF OBJECT_ID(N'[dbo].[PromotionCustomer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PromotionCustomer];
GO
IF OBJECT_ID(N'[dbo].[PromotionPaymMode]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PromotionPaymMode];
GO
IF OBJECT_ID(N'[dbo].[PromotionProducts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PromotionProducts];
GO
IF OBJECT_ID(N'[dbo].[PromotionReward]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PromotionReward];
GO
IF OBJECT_ID(N'[dbo].[PromotionTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PromotionTable];
GO
IF OBJECT_ID(N'[dbo].[PromotionType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PromotionType];
GO
IF OBJECT_ID(N'[dbo].[Province]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Province];
GO
IF OBJECT_ID(N'[dbo].[RetentionTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RetentionTable];
GO
IF OBJECT_ID(N'[dbo].[SalesLog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SalesLog];
GO
IF OBJECT_ID(N'[dbo].[Salesman]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Salesman];
GO
IF OBJECT_ID(N'[dbo].[SalesOrder]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SalesOrder];
GO
IF OBJECT_ID(N'[dbo].[SalesOrderLine]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SalesOrderLine];
GO
IF OBJECT_ID(N'[dbo].[SalesOrderPayment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SalesOrderPayment];
GO
IF OBJECT_ID(N'[dbo].[SalesOrderStatus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SalesOrderStatus];
GO
IF OBJECT_ID(N'[dbo].[SalesOrderText]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SalesOrderText];
GO
IF OBJECT_ID(N'[dbo].[SalesOrigin]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SalesOrigin];
GO
IF OBJECT_ID(N'[dbo].[SalesRemissionLine]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SalesRemissionLine];
GO
IF OBJECT_ID(N'[dbo].[SalesRemissionTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SalesRemissionTable];
GO
IF OBJECT_ID(N'[dbo].[SequenceTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SequenceTable];
GO
IF OBJECT_ID(N'[dbo].[SequenceType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SequenceType];
GO
IF OBJECT_ID(N'[dbo].[Server]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Server];
GO
IF OBJECT_ID(N'[dbo].[Supervisor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Supervisor];
GO
IF OBJECT_ID(N'[dbo].[TaxTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TaxTable];
GO
IF OBJECT_ID(N'[dbo].[TransferStatus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TransferStatus];
GO
IF OBJECT_ID(N'[dbo].[Transport]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Transport];
GO
IF OBJECT_ID(N'[dbo].[TransportDriver]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TransportDriver];
GO
IF OBJECT_ID(N'[dbo].[TransportReason]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TransportReason];
GO
IF OBJECT_ID(N'[dbo].[UserLogin]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserLogin];
GO
IF OBJECT_ID(N'[dbo].[Vendor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vendor];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AccountsReceivable'
CREATE TABLE [dbo].[AccountsReceivable] (
    [AccountsReceivableId] bigint  NOT NULL,
    [AccountsReceivableIdLocal] bigint  NOT NULL,
    [LocationId] smallint  NOT NULL,
    [TypeDoc] smallint  NOT NULL,
    [CustomerId] bigint  NOT NULL,
    [InvoiceId] bigint  NOT NULL,
    [DocNumber] bigint  NOT NULL,
    [Registration] datetime  NOT NULL,
    [Expiration] datetime  NOT NULL,
    [Amount] decimal(18,2)  NOT NULL,
    [AmountPaid] decimal(18,2)  NOT NULL,
    [Observation] varchar(250)  NOT NULL,
    [StatusAccounts] char(1)  NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'Country'
CREATE TABLE [dbo].[Country] (
    [CountryId] int  NOT NULL,
    [Name] varchar(50)  NULL,
    [Prefix] varchar(4)  NULL,
    [IsLocal] bit  NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'InventLocation'
CREATE TABLE [dbo].[InventLocation] (
    [InventLocationId] int  NOT NULL,
    [Name] varchar(150)  NOT NULL,
    [SAPCode] varchar(20)  NOT NULL,
    [LocationId] smallint  NOT NULL,
    [Type] varchar(2)  NULL,
    [IsMain] bit  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'InventUnit'
CREATE TABLE [dbo].[InventUnit] (
    [InventUnitId] int  NOT NULL,
    [Name] varchar(220)  NULL,
    [SAPCode] varchar(20)  NOT NULL,
    [WeightControl] bit  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'ProductBarcode'
CREATE TABLE [dbo].[ProductBarcode] (
    [ProductId] bigint  NOT NULL,
    [Barcode] varchar(20)  NOT NULL,
    [Quantity] decimal(18,2)  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'ProductCategory'
CREATE TABLE [dbo].[ProductCategory] (
    [ProductCategoryId] int  NOT NULL,
    [ParentId] int  NOT NULL,
    [Name] varchar(220)  NULL,
    [FriendlyName] varchar(220)  NULL,
    [Level] int  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'ProductGroup'
CREATE TABLE [dbo].[ProductGroup] (
    [ProductGroupId] int  NOT NULL,
    [Name] varchar(220)  NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'PromotionCustomer'
CREATE TABLE [dbo].[PromotionCustomer] (
    [PromotionId] bigint  NOT NULL,
    [Sequence] int  NOT NULL,
    [CustomerId] bigint  NOT NULL,
    [Percent] decimal(18,4)  NOT NULL,
    [StatusPromCust] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'PromotionProducts'
CREATE TABLE [dbo].[PromotionProducts] (
    [PromotionId] bigint  NOT NULL,
    [Sequence] int  NOT NULL,
    [Type] varchar(5)  NOT NULL,
    [Origin] varchar(1)  NOT NULL,
    [ProductGroupId] int  NOT NULL,
    [ProductCategoryId] int  NOT NULL,
    [ProductId] bigint  NOT NULL,
    [Percent] decimal(18,4)  NOT NULL,
    [AddCoupon] bit  NOT NULL,
    [StatusPromProd] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'PromotionReward'
CREATE TABLE [dbo].[PromotionReward] (
    [PromotionId] bigint  NOT NULL,
    [Sequence] int  NOT NULL,
    [ProductId] bigint  NOT NULL,
    [StartRange] decimal(24,4)  NOT NULL,
    [FinalRange] decimal(24,4)  NOT NULL,
    [Percent] decimal(12,4)  NOT NULL,
    [LowInventory] bit  NOT NULL,
    [ProductIdReward] bigint  NOT NULL,
    [QuantityReceive] int  NOT NULL,
    [MaxReceive] int  NOT NULL,
    [Caption] varchar(200)  NULL,
    [TotalReward] int  NOT NULL,
    [StockReward] int  NOT NULL,
    [StatusPromRew] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'PromotionTable'
CREATE TABLE [dbo].[PromotionTable] (
    [PromotionId] bigint  NOT NULL,
    [Name] varchar(200)  NOT NULL,
    [PromotionTypeId] int  NOT NULL,
    [ConsumptionOrigin] char(1)  NOT NULL,
    [ConsumptionMax] decimal(18,2)  NOT NULL,
    [Vigence] datetime  NOT NULL,
    [Expiration] datetime  NOT NULL,
    [UseMonday] bit  NOT NULL,
    [UseTuesday] bit  NOT NULL,
    [UseWednesday] bit  NOT NULL,
    [UseThursday] bit  NOT NULL,
    [UseFriday] bit  NOT NULL,
    [UseSaturday] bit  NOT NULL,
    [UseSunday] bit  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'Salesman'
CREATE TABLE [dbo].[Salesman] (
    [SalesmanId] int  NOT NULL,
    [Name] varchar(200)  NOT NULL,
    [SAPCode] varchar(20)  NOT NULL,
    [IsExternal] bit  NOT NULL,
    [ParentId] int  NOT NULL,
    [Type] varchar(2)  NOT NULL,
    [CommissionPercent] decimal(18,4)  NOT NULL,
    [Fulfillment] decimal(18,2)  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'Server'
CREATE TABLE [dbo].[Server] (
    [ServerId] int  NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [IsCentral] bit  NOT NULL,
    [IsLocal] bit  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'TaxTable'
CREATE TABLE [dbo].[TaxTable] (
    [TaxId] int  NOT NULL,
    [Name] varchar(150)  NOT NULL,
    [TaxValue] decimal(18,2)  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'PromotionType'
CREATE TABLE [dbo].[PromotionType] (
    [PromotionTypeId] int  NOT NULL,
    [Name] varchar(150)  NOT NULL,
    [Type] varchar(5)  NOT NULL,
    [UseCoupon] bit  NOT NULL,
    [UseReward] bit  NOT NULL,
    [ControlCoupon] bit  NOT NULL,
    [Status] char(1)  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'InternalCreditCard'
CREATE TABLE [dbo].[InternalCreditCard] (
    [InternalCreditCardId] bigint  NOT NULL,
    [InternalCreditCardIdLocal] bigint  NOT NULL,
    [Barcode] varchar(25)  NOT NULL,
    [Name] varchar(150)  NOT NULL,
    [Type] varchar(1)  NOT NULL,
    [Vigence] datetime  NOT NULL,
    [Expiration] datetime  NOT NULL,
    [CustomerId] bigint  NOT NULL,
    [EmployeeId] bigint  NOT NULL,
    [Quota] decimal(18,2)  NOT NULL,
    [Consumed] decimal(18,2)  NOT NULL,
    [Printed] bit  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'GlobalParameter'
CREATE TABLE [dbo].[GlobalParameter] (
    [GlobalParameterId] int  NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Value] varchar(50)  NOT NULL,
    [Value2] varchar(50)  NOT NULL,
    [Description] varchar(500)  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'InventTransType'
CREATE TABLE [dbo].[InventTransType] (
    [InventTransTypeId] int  NOT NULL,
    [Name] varchar(150)  NULL,
    [SAPCode] varchar(20)  NOT NULL,
    [Type] char(1)  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'Province'
CREATE TABLE [dbo].[Province] (
    [CountryId] int  NOT NULL,
    [ProvinceId] int  NOT NULL,
    [Name] varchar(50)  NULL,
    [Region] varchar(3)  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'Transport'
CREATE TABLE [dbo].[Transport] (
    [TransportId] int  NOT NULL,
    [LicencePlate] varchar(10)  NOT NULL,
    [Description] varchar(100)  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'TransportDriver'
CREATE TABLE [dbo].[TransportDriver] (
    [TransportDriverId] int  NOT NULL,
    [Identification] varchar(20)  NOT NULL,
    [Lastname] varchar(150)  NOT NULL,
    [Firtsname] varchar(150)  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'TransportReason'
CREATE TABLE [dbo].[TransportReason] (
    [TransportReasonId] int  NOT NULL,
    [Name] varchar(150)  NULL,
    [SAPCode] varchar(20)  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'Vendor'
CREATE TABLE [dbo].[Vendor] (
    [VendorId] int  NOT NULL,
    [Name] varchar(150)  NOT NULL,
    [SAPCode] varchar(20)  NOT NULL,
    [IdentTypeId] int  NOT NULL,
    [Identification] varchar(20)  NULL,
    [TaxpayerType] char(1)  NOT NULL,
    [IsSpecialTaxpayer] bit  NULL,
    [Phone] varchar(10)  NOT NULL,
    [Email] varchar(100)  NOT NULL,
    [CityId] int  NOT NULL,
    [Address] varchar(250)  NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'PaymMode'
CREATE TABLE [dbo].[PaymMode] (
    [PaymModeId] int  NOT NULL,
    [Name] varchar(150)  NOT NULL,
    [SAPCode] varchar(20)  NOT NULL,
    [UseRetention] bit  NULL,
    [UseFinanceSystem] bit  NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'RetentionTable'
CREATE TABLE [dbo].[RetentionTable] (
    [RetentionCode] int  NOT NULL,
    [Name] varchar(150)  NOT NULL,
    [SAPCode] varchar(20)  NOT NULL,
    [Percent] decimal(18,2)  NOT NULL,
    [Type] varchar(5)  NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'Supervisor'
CREATE TABLE [dbo].[Supervisor] (
    [UserId] int  NOT NULL,
    [PasswordId] int  NOT NULL,
    [barcode] varchar(20)  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL,
    [AllowEmployeeCredit] bit  NOT NULL
);
GO

-- Creating table 'LogType'
CREATE TABLE [dbo].[LogType] (
    [LogTypeId] int  NOT NULL,
    [Name] varchar(50)  NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'SalesLog'
CREATE TABLE [dbo].[SalesLog] (
    [SalesLogId] bigint IDENTITY(1,1) NOT NULL,
    [LocationId] smallint  NOT NULL,
    [EmissionPointId] int  NOT NULL,
    [InvoiceNumber] bigint  NOT NULL,
    [CustomerId] bigint  NOT NULL,
    [LogTypeId] int  NOT NULL,
    [ReasonId] int  NOT NULL,
    [Authorization] varchar(40)  NOT NULL,
    [XmlLog] nvarchar(max)  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'UserLogin'
CREATE TABLE [dbo].[UserLogin] (
    [UserId] int  NOT NULL,
    [UserName] varchar(20)  NOT NULL,
    [Lastname] varchar(150)  NOT NULL,
    [Firtsname] varchar(150)  NOT NULL,
    [IsProfile] bit  NOT NULL,
    [IsAdministrator] bit  NOT NULL,
    [Type] char(1)  NOT NULL,
    [Password] varbinary(150)  NOT NULL,
    [Email] varchar(60)  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'EmissionPoint'
CREATE TABLE [dbo].[EmissionPoint] (
    [EmissionPointId] int  NOT NULL,
    [LocationId] smallint  NOT NULL,
    [InventLocationId] int  NOT NULL,
    [Establishment] varchar(5)  NOT NULL,
    [Emission] varchar(5)  NOT NULL,
    [Name] varchar(100)  NOT NULL,
    [AddressIP] varchar(20)  NOT NULL,
    [ScaleName] varchar(20)  NOT NULL,
    [ScaleBrand] varchar(20)  NOT NULL,
    [ScanBarcodeName] varchar(20)  NOT NULL,
    [PrinterName] varchar(20)  NOT NULL,
    [ThermalPrinter] bit  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'SequenceTable'
CREATE TABLE [dbo].[SequenceTable] (
    [LocationId] smallint  NOT NULL,
    [SequenceId] int  NOT NULL,
    [SequenceTypeId] int  NOT NULL,
    [EmissionPointId] int  NOT NULL,
    [Sequence] int  NOT NULL,
    [Name] varchar(100)  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'SequenceType'
CREATE TABLE [dbo].[SequenceType] (
    [SequenceTypeId] int  NOT NULL,
    [Name] varchar(50)  NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'ProductModule'
CREATE TABLE [dbo].[ProductModule] (
    [ProductId] bigint  NOT NULL,
    [LocationId] int  NOT NULL,
    [Cost] decimal(24,6)  NOT NULL,
    [PriceReference] decimal(24,6)  NOT NULL,
    [Price] decimal(24,6)  NOT NULL,
    [TaxAmount] decimal(24,6)  NOT NULL,
    [IrbpAmount] decimal(24,6)  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'GiftCardBlockTable'
CREATE TABLE [dbo].[GiftCardBlockTable] (
    [GiftCardBlockId] bigint  NOT NULL,
    [LocationId] smallint  NOT NULL,
    [Year] int  NOT NULL,
    [Type] varchar(2)  NOT NULL,
    [Observation] varchar(200)  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'GiftCardTable'
CREATE TABLE [dbo].[GiftCardTable] (
    [GiftCardId] bigint  NOT NULL,
    [GiftCardIdLocal] bigint  NOT NULL,
    [LocationId] smallint  NOT NULL,
    [LocationIdOrigin] smallint  NOT NULL,
    [Year] int  NOT NULL,
    [GiftCardBlockId] bigint  NOT NULL,
    [Registration] datetime  NOT NULL,
    [Expiration] datetime  NOT NULL,
    [Type] varchar(2)  NOT NULL,
    [UseCode] varchar(4)  NOT NULL,
    [CustomerId] bigint  NOT NULL,
    [InvoiceId] bigint  NOT NULL,
    [GiftCardNumberStart] bigint  NOT NULL,
    [GiftCardNumberFinal] bigint  NOT NULL,
    [Quantity] int  NOT NULL,
    [Total] decimal(18,2)  NOT NULL,
    [Observation] varchar(200)  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'PromotionPaymMode'
CREATE TABLE [dbo].[PromotionPaymMode] (
    [PromotionId] bigint  NOT NULL,
    [Sequence] int  NOT NULL,
    [PaymModeId] int  NOT NULL,
    [BankId] int  NOT NULL,
    [CreditCardId] int  NOT NULL,
    [Percent] decimal(18,4)  NOT NULL,
    [StatusPromPaym] char(1)  NULL,
    [RewardMultiplierType] varchar(1)  NOT NULL,
    [RewardMultiplierValue] int  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'TransferStatus'
CREATE TABLE [dbo].[TransferStatus] (
    [TransferStatusId] int  NOT NULL,
    [Name] varchar(50)  NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'Customer'
CREATE TABLE [dbo].[Customer] (
    [CustomerId] bigint  NOT NULL,
    [CustomerIdLocal] bigint IDENTITY(1,1) NOT NULL,
    [Lastname] varchar(150)  NOT NULL,
    [Firtsname] varchar(150)  NOT NULL,
    [SAPCode] varchar(20)  NOT NULL,
    [LocationId] smallint  NOT NULL,
    [IdentTypeId] int  NOT NULL,
    [Identification] varchar(20)  NULL,
    [Gender] varchar(1)  NULL,
    [PersonType] char(1)  NOT NULL,
    [IsSpecialTaxpayer] bit  NULL,
    [IsEmployee] bit  NOT NULL,
    [EmployeeId] int  NOT NULL,
    [Phone] varchar(10)  NOT NULL,
    [Email] varchar(150)  NOT NULL,
    [CityId] int  NOT NULL,
    [Address] varchar(250)  NULL,
    [CustomerTypeId] int  NOT NULL,
    [UseRetention] bit  NULL,
    [IsCredit] bit  NULL,
    [CreditLimit] decimal(18,2)  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'Location'
CREATE TABLE [dbo].[Location] (
    [LocationId] smallint  NOT NULL,
    [CompanyId] smallint  NOT NULL,
    [Name] varchar(120)  NULL,
    [Establishment] varchar(5)  NOT NULL,
    [Phone] varchar(10)  NULL,
    [CityId] int  NOT NULL,
    [Address] varchar(150)  NULL,
    [IsMain] bit  NULL,
    [ServerId] int  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'PhysicalStockCountingLine'
CREATE TABLE [dbo].[PhysicalStockCountingLine] (
    [PhysicalStockCountingId] int  NOT NULL,
    [Sequence] int  NOT NULL,
    [ProductId] bigint  NOT NULL,
    [InventUnitId] int  NOT NULL,
    [StockQuantity] decimal(24,6)  NOT NULL,
    [CountedQuantity] decimal(24,6)  NOT NULL,
    [Cost] decimal(24,6)  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'PhysicalStockCountingTable'
CREATE TABLE [dbo].[PhysicalStockCountingTable] (
    [PhysicalStockCountingId] int  NOT NULL,
    [PhysicalStockCountingIdLocal] int IDENTITY(1,1) NOT NULL,
    [LocationId] smallint  NOT NULL,
    [EmissionPointId] int  NOT NULL,
    [InventLocationId] int  NOT NULL,
    [CountingDate] datetime  NOT NULL,
    [Type] char(1)  NULL,
    [StockCountingId] int  NOT NULL,
    [ERPId] int  NULL,
    [Observation] varchar(150)  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'Bank'
CREATE TABLE [dbo].[Bank] (
    [BankId] int  NOT NULL,
    [Name] varchar(150)  NOT NULL,
    [SAPCode] varchar(20)  NOT NULL,
    [GaranchekCode] int  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'BankCreditCard'
CREATE TABLE [dbo].[BankCreditCard] (
    [BankId] int  NOT NULL,
    [CreditCardId] int  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'Brand'
CREATE TABLE [dbo].[Brand] (
    [BrandId] int  NOT NULL,
    [Name] varchar(220)  NULL,
    [SAPCode] varchar(20)  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'CancelReason'
CREATE TABLE [dbo].[CancelReason] (
    [ReasonId] int  NOT NULL,
    [ReasonType] int  NULL,
    [Name] varchar(50)  NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'City'
CREATE TABLE [dbo].[City] (
    [CityId] int  NOT NULL,
    [ProvinceId] int  NOT NULL,
    [CityCode] int  NOT NULL,
    [Name] varchar(50)  NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'Company'
CREATE TABLE [dbo].[Company] (
    [CompanyId] smallint  NOT NULL,
    [Name] varchar(250)  NULL,
    [Identification] varchar(13)  NULL,
    [Phone] varchar(10)  NULL,
    [CityId] int  NOT NULL,
    [Address] varchar(150)  NULL,
    [IsTaxpayerSpecial] bit  NOT NULL,
    [HasRISE] bit  NOT NULL,
    [HasTaxback] bit  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'CreditCard'
CREATE TABLE [dbo].[CreditCard] (
    [CreditCardId] int  NOT NULL,
    [Name] varchar(150)  NOT NULL,
    [SAPCode] varchar(20)  NOT NULL,
    [IsCredit] bit  NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'CurrencyDenomination'
CREATE TABLE [dbo].[CurrencyDenomination] (
    [CurrencyDenominationId] int  NOT NULL,
    [CurrencyTypeId] int  NOT NULL,
    [DenominationTypeId] int  NOT NULL,
    [Value] decimal(18,2)  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'CurrencyType'
CREATE TABLE [dbo].[CurrencyType] (
    [CurrencyTypeId] int  NOT NULL,
    [Name] varchar(100)  NOT NULL,
    [Active] bit  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'CustomerAddress'
CREATE TABLE [dbo].[CustomerAddress] (
    [CustomerAddressId] bigint  NOT NULL,
    [CustomerAddressIdLocal] bigint IDENTITY(1,1) NOT NULL,
    [CustomerId] bigint  NOT NULL,
    [Sequence] int  NOT NULL,
    [Address] varchar(max)  NOT NULL,
    [AddressReference] varchar(max)  NOT NULL,
    [Coordinates] varchar(100)  NOT NULL,
    [Telephone] varchar(100)  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'CustomerType'
CREATE TABLE [dbo].[CustomerType] (
    [CustomerTypeId] int  NOT NULL,
    [Name] varchar(220)  NULL,
    [ParentId] int  NOT NULL,
    [Level] int  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'DenominationType'
CREATE TABLE [dbo].[DenominationType] (
    [DenominationTypeId] int  NOT NULL,
    [Name] varchar(100)  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'GiftCardBlockLine'
CREATE TABLE [dbo].[GiftCardBlockLine] (
    [GiftCardBlockId] bigint  NOT NULL,
    [Sequence] int  NOT NULL,
    [GiftCardNumberStart] bigint  NOT NULL,
    [GiftCardNumberFinal] bigint  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'GiftCardLine'
CREATE TABLE [dbo].[GiftCardLine] (
    [GiftCardId] bigint  NOT NULL,
    [Sequence] int  NOT NULL,
    [Year] int  NOT NULL,
    [GiftCardNumber] varchar(20)  NOT NULL,
    [CustomerId] bigint  NOT NULL,
    [RedeemIdentification] varchar(20)  NOT NULL,
    [RedeemCustomer] varchar(200)  NOT NULL,
    [Amount] decimal(18,4)  NOT NULL,
    [AmountConsumed] decimal(18,4)  NOT NULL,
    [StatusLine] char(1)  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'GiftCardLineProduct'
CREATE TABLE [dbo].[GiftCardLineProduct] (
    [GiftCardId] bigint  NOT NULL,
    [Sequence] int  NOT NULL,
    [ProdSeq] int  NOT NULL,
    [ProductId] bigint  NOT NULL,
    [Quantity] decimal(24,6)  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'GiftCardTrans'
CREATE TABLE [dbo].[GiftCardTrans] (
    [GiftCardId] bigint  NOT NULL,
    [Sequence] int  NOT NULL,
    [TrnsSeq] int  NOT NULL,
    [LocationIdRedeem] smallint  NOT NULL,
    [RedeemDate] datetime  NOT NULL,
    [TrnsType] varchar(2)  NOT NULL,
    [TrnsStatus] char(1)  NOT NULL,
    [TrnsId] bigint  NOT NULL,
    [TrnsAmount] decimal(18,4)  NOT NULL,
    [ProductId] bigint  NOT NULL,
    [Quantity] decimal(24,6)  NOT NULL,
    [RedeemQuantity] decimal(24,6)  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'IdentType'
CREATE TABLE [dbo].[IdentType] (
    [IdentTypeId] int  NOT NULL,
    [Name] varchar(50)  NULL,
    [Prefix] char(1)  NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'InternalCreditCardLine'
CREATE TABLE [dbo].[InternalCreditCardLine] (
    [InternalCreditCardId] bigint  NOT NULL,
    [Sequence] int  NOT NULL,
    [PromotionId] bigint  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'InvoiceLine'
CREATE TABLE [dbo].[InvoiceLine] (
    [InvoiceId] bigint  NOT NULL,
    [Sequence] int  NOT NULL,
    [ProductId] bigint  NOT NULL,
    [Barcode] varchar(20)  NOT NULL,
    [InventUnitId] int  NOT NULL,
    [IsDeductible] bit  NOT NULL,
    [UseTax] bit  NOT NULL,
    [TaxProductAmount] decimal(18,4)  NOT NULL,
    [DiscountProductAmount] decimal(18,4)  NOT NULL,
    [Quantity] decimal(18,6)  NOT NULL,
    [QuantityCW] int  NOT NULL,
    [Returned] int  NOT NULL,
    [Cost] decimal(18,4)  NOT NULL,
    [Price] decimal(18,4)  NOT NULL,
    [BaseAmount] decimal(18,4)  NOT NULL,
    [BaseTaxAmount] decimal(18,4)  NOT NULL,
    [LinePercent] decimal(5,2)  NOT NULL,
    [LineDiscount] decimal(18,4)  NOT NULL,
    [TaxPercent] decimal(5,2)  NOT NULL,
    [TaxAmount] decimal(18,4)  NOT NULL,
    [IrbpAmount] decimal(18,4)  NOT NULL,
    [LineAmount] decimal(18,4)  NOT NULL,
    [PromotionId] bigint  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'InvoicePayment'
CREATE TABLE [dbo].[InvoicePayment] (
    [InvoiceId] bigint  NOT NULL,
    [LocationId] smallint  NOT NULL,
    [Sequence] int  NOT NULL,
    [PaymModeId] int  NOT NULL,
    [Amount] decimal(18,2)  NOT NULL,
    [Received] decimal(18,2)  NOT NULL,
    [Change] decimal(18,2)  NOT NULL,
    [PaymentDate] datetime  NOT NULL,
    [BankId] int  NOT NULL,
    [CreditCardId] int  NOT NULL,
    [AccountNumber] varchar(20)  NOT NULL,
    [CkeckNumber] int  NOT NULL,
    [CkeckType] varchar(2)  NOT NULL,
    [CkeckDate] datetime  NOT NULL,
    [CheckOwner] varchar(100)  NOT NULL,
    [Authorization] varchar(40)  NOT NULL,
    [IsProtest] bit  NOT NULL,
    [ProtestDate] datetime  NOT NULL,
    [InternalCreditCardId] bigint  NOT NULL,
    [GiftCardNumber] varchar(20)  NOT NULL,
    [RetentionCode] int  NOT NULL,
    [RetentionNumber] varchar(15)  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'SalesOrderLine'
CREATE TABLE [dbo].[SalesOrderLine] (
    [SalesOrderId] bigint  NOT NULL,
    [Sequence] int  NOT NULL,
    [ProductId] bigint  NOT NULL,
    [Barcode] varchar(20)  NOT NULL,
    [InventUnitId] int  NOT NULL,
    [UseTax] bit  NOT NULL,
    [TaxProductAmount] decimal(18,4)  NOT NULL,
    [DiscountProductAmount] decimal(18,4)  NOT NULL,
    [Quantity] decimal(18,6)  NOT NULL,
    [QuantityCW] int  NOT NULL,
    [Returned] int  NOT NULL,
    [Cost] decimal(18,4)  NOT NULL,
    [Price] decimal(18,4)  NOT NULL,
    [BaseAmount] decimal(18,4)  NOT NULL,
    [BaseTaxAmount] decimal(18,4)  NOT NULL,
    [LinePercent] decimal(5,2)  NOT NULL,
    [LineDiscount] decimal(18,4)  NOT NULL,
    [TaxPercent] decimal(5,2)  NOT NULL,
    [TaxAmount] decimal(18,4)  NOT NULL,
    [IrbpAmount] decimal(18,4)  NOT NULL,
    [LineAmount] decimal(18,4)  NOT NULL,
    [PromotionId] bigint  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'SalesOrderPayment'
CREATE TABLE [dbo].[SalesOrderPayment] (
    [SalesOrderId] bigint  NOT NULL,
    [Sequence] int  NOT NULL,
    [PaymModeId] int  NOT NULL,
    [Amount] decimal(18,2)  NOT NULL,
    [BankId] int  NOT NULL,
    [CreditCardId] int  NOT NULL,
    [LocationId] smallint  NOT NULL,
    [Received] decimal(18,2)  NOT NULL,
    [Change] decimal(18,2)  NOT NULL,
    [PaymentDate] datetime  NOT NULL,
    [AccountNumber] varchar(20)  NOT NULL,
    [CkeckNumber] int  NOT NULL,
    [CkeckType] varchar(2)  NOT NULL,
    [CkeckDate] datetime  NOT NULL,
    [CheckOwner] varchar(100)  NOT NULL,
    [Authorization] varchar(40)  NOT NULL,
    [IsProtest] bit  NOT NULL,
    [ProtestDate] datetime  NOT NULL,
    [InternalCreditCardId] bigint  NOT NULL,
    [GiftCardNumber] varchar(20)  NOT NULL,
    [RetentionCode] int  NOT NULL,
    [RetentionNumber] varchar(15)  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'SalesOrderText'
CREATE TABLE [dbo].[SalesOrderText] (
    [SalesOrderId] bigint  NOT NULL,
    [Sequence] int  NOT NULL,
    [SalesOrderText1] varchar(max)  NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'SalesOrder'
CREATE TABLE [dbo].[SalesOrder] (
    [SalesOrderId] bigint  NOT NULL,
    [SalesOrderIdLocal] bigint IDENTITY(1,1) NOT NULL,
    [LocationId] smallint  NOT NULL,
    [CustomerId] bigint  NOT NULL,
    [SalesmanId] int  NOT NULL,
    [OrderDate] datetime  NOT NULL,
    [SalesOriginId] int  NOT NULL,
    [OrderECommerce] bigint  NOT NULL,
    [DeliveryAddress] varchar(200)  NOT NULL,
    [DeliveryDate] datetime  NOT NULL,
    [Recipient] varchar(200)  NOT NULL,
    [BaseAmount] decimal(18,4)  NOT NULL,
    [BaseTaxAmount] decimal(18,4)  NOT NULL,
    [Discount] decimal(18,4)  NOT NULL,
    [TaxPercent] decimal(5,2)  NOT NULL,
    [TaxAmount] decimal(18,4)  NOT NULL,
    [IrbpAmount] decimal(18,4)  NOT NULL,
    [Total] decimal(18,4)  NOT NULL,
    [ShippingFree] bit  NOT NULL,
    [ShippingAmount] decimal(18,2)  NOT NULL,
    [Observation] varchar(250)  NOT NULL,
    [CustomerAddressId] bigint  NULL,
    [OrderXml] varchar(max)  NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'SalesRemissionLine'
CREATE TABLE [dbo].[SalesRemissionLine] (
    [SalesRemissionId] bigint  NOT NULL,
    [Sequence] int  NOT NULL,
    [SalesOrderId] bigint  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'SalesOrderStatus'
CREATE TABLE [dbo].[SalesOrderStatus] (
    [SalesOrderStatusId] int  NOT NULL,
    [ShortCode] char(1)  NOT NULL,
    [Name] varchar(200)  NOT NULL,
    [Observation] varchar(200)  NOT NULL,
    [PreviousStatus] varchar(200)  NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'SalesRemissionTable'
CREATE TABLE [dbo].[SalesRemissionTable] (
    [SalesRemissionId] bigint  NOT NULL,
    [SalesRemissionIdLocal] bigint IDENTITY(1,1) NOT NULL,
    [LocationId] smallint  NOT NULL,
    [TypeDoc] smallint  NOT NULL,
    [EmissionPointId] int  NOT NULL,
    [Establishment] varchar(5)  NOT NULL,
    [RemissionNumber] bigint  NULL,
    [Emission] varchar(5)  NOT NULL,
    [TransportDriverId] int  NOT NULL,
    [TransportId] int  NOT NULL,
    [TransportReasonId] int  NOT NULL,
    [SalesRemissionDate] datetime  NOT NULL,
    [DeliveryDate] datetime  NOT NULL,
    [Observation] varchar(250)  NOT NULL,
    [KeyAccessSri] varchar(50)  NOT NULL,
    [TransferStatusId] int  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'InventProductLocation'
CREATE TABLE [dbo].[InventProductLocation] (
    [ProductId] bigint  NOT NULL,
    [LocationId] int  NOT NULL,
    [InventLocationId] int  NOT NULL,
    [MinStock] decimal(12,2)  NOT NULL,
    [MaxStock] decimal(12,2)  NOT NULL,
    [Stock] decimal(24,6)  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'SalesOrigin'
CREATE TABLE [dbo].[SalesOrigin] (
    [SalesOriginId] int  NOT NULL,
    [Name] varchar(100)  NOT NULL,
    [SalesmanId] int  NOT NULL,
    [IsECommerce] bit  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL,
    [AllowCredit] bit  NOT NULL
);
GO

-- Creating table 'Product'
CREATE TABLE [dbo].[Product] (
    [ProductId] bigint  NOT NULL,
    [SAPCode] varchar(20)  NOT NULL,
    [Name] varchar(220)  NULL,
    [Description] varchar(150)  NOT NULL,
    [InventUnitId] int  NOT NULL,
    [ProductGroupId] int  NOT NULL,
    [ProductCategoryId] int  NOT NULL,
    [Type] varchar(1)  NOT NULL,
    [IsDeductible] bit  NOT NULL,
    [UseTax] bit  NOT NULL,
    [UseIrbp] bit  NOT NULL,
    [IsECommerce] bit  NOT NULL,
    [UseCatchWeight] bit  NOT NULL,
    [CatchWeightMax] decimal(24,6)  NOT NULL,
    [CatchWeightMin] decimal(24,6)  NOT NULL,
    [VendorId] int  NULL,
    [BrandId] int  NULL,
    [ProductOldCode] varchar(20)  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'ClosingCashierLine'
CREATE TABLE [dbo].[ClosingCashierLine] (
    [ClosingCashierId] bigint  NOT NULL,
    [Sequence] int  NOT NULL,
    [PaymModeId] int  NOT NULL,
    [CashierAmount] decimal(18,2)  NOT NULL,
    [SystemAmount] decimal(18,2)  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'ClosingCashierMoney'
CREATE TABLE [dbo].[ClosingCashierMoney] (
    [ClosingCashierId] bigint  NOT NULL,
    [Sequence] int  NOT NULL,
    [CurrencyDenominationId] int  NOT NULL,
    [Quantity] decimal(18,2)  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- Creating table 'ClosingCashierTable'
CREATE TABLE [dbo].[ClosingCashierTable] (
    [ClosingCashierId] bigint  NOT NULL,
    [ClosingCashierIdLocal] bigint IDENTITY(1,1) NOT NULL,
    [LocationId] smallint  NOT NULL,
    [EmissionPointId] int  NOT NULL,
    [UserId] int  NOT NULL,
    [ClosingCashierDate] datetime  NOT NULL,
    [Type] char(1)  NULL,
    [ClosingCashierIdParent] bigint  NOT NULL,
    [OpeningAmount] decimal(18,2)  NOT NULL,
    [Authorization] varchar(40)  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL,
    [ReasonId] int  NULL,
    [AccountingCode] varchar(20)  NULL
);
GO

-- Creating table 'InvoiceTable'
CREATE TABLE [dbo].[InvoiceTable] (
    [InvoiceId] bigint  NOT NULL,
    [InvoiceIdLocal] bigint IDENTITY(1,1) NOT NULL,
    [LocationId] smallint  NOT NULL,
    [TypeDoc] smallint  NOT NULL,
    [InvoiceIdReference] bigint  NOT NULL,
    [EmissionPointId] int  NOT NULL,
    [Establishment] varchar(5)  NOT NULL,
    [Emission] varchar(5)  NOT NULL,
    [InvoiceNumber] bigint  NOT NULL,
    [CustomerId] bigint  NOT NULL,
    [SalesmanId] int  NOT NULL,
    [IsCredit] bit  NOT NULL,
    [InvoiceDate] datetime  NOT NULL,
    [Expiration] datetime  NOT NULL,
    [BaseAmount] decimal(18,4)  NOT NULL,
    [BaseTaxAmount] decimal(18,4)  NOT NULL,
    [Discount] decimal(18,4)  NOT NULL,
    [TaxPercent] decimal(5,2)  NOT NULL,
    [TaxAmount] decimal(18,4)  NOT NULL,
    [IrbpAmount] decimal(18,4)  NOT NULL,
    [Total] decimal(18,4)  NOT NULL,
    [ShippingFree] bit  NOT NULL,
    [ShippingAmount] decimal(18,2)  NOT NULL,
    [Returned] decimal(18,2)  NOT NULL,
    [SalesOriginId] int  NOT NULL,
    [IsECommerce] bit  NOT NULL,
    [SalesOrderId] bigint  NOT NULL,
    [ClosingCashierId] bigint  NOT NULL,
    [Observation] varchar(250)  NOT NULL,
    [KeyAccessSri] varchar(50)  NOT NULL,
    [TransferStatusId] int  NOT NULL,
    [Status] char(1)  NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDatetime] datetime  NULL,
    [Workstation] varchar(20)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AccountsReceivableId] in table 'AccountsReceivable'
ALTER TABLE [dbo].[AccountsReceivable]
ADD CONSTRAINT [PK_AccountsReceivable]
    PRIMARY KEY CLUSTERED ([AccountsReceivableId] ASC);
GO

-- Creating primary key on [CountryId] in table 'Country'
ALTER TABLE [dbo].[Country]
ADD CONSTRAINT [PK_Country]
    PRIMARY KEY CLUSTERED ([CountryId] ASC);
GO

-- Creating primary key on [InventLocationId] in table 'InventLocation'
ALTER TABLE [dbo].[InventLocation]
ADD CONSTRAINT [PK_InventLocation]
    PRIMARY KEY CLUSTERED ([InventLocationId] ASC);
GO

-- Creating primary key on [InventUnitId] in table 'InventUnit'
ALTER TABLE [dbo].[InventUnit]
ADD CONSTRAINT [PK_InventUnit]
    PRIMARY KEY CLUSTERED ([InventUnitId] ASC);
GO

-- Creating primary key on [ProductId], [Barcode] in table 'ProductBarcode'
ALTER TABLE [dbo].[ProductBarcode]
ADD CONSTRAINT [PK_ProductBarcode]
    PRIMARY KEY CLUSTERED ([ProductId], [Barcode] ASC);
GO

-- Creating primary key on [ProductCategoryId] in table 'ProductCategory'
ALTER TABLE [dbo].[ProductCategory]
ADD CONSTRAINT [PK_ProductCategory]
    PRIMARY KEY CLUSTERED ([ProductCategoryId] ASC);
GO

-- Creating primary key on [ProductGroupId] in table 'ProductGroup'
ALTER TABLE [dbo].[ProductGroup]
ADD CONSTRAINT [PK_ProductGroup]
    PRIMARY KEY CLUSTERED ([ProductGroupId] ASC);
GO

-- Creating primary key on [PromotionId], [Sequence] in table 'PromotionCustomer'
ALTER TABLE [dbo].[PromotionCustomer]
ADD CONSTRAINT [PK_PromotionCustomer]
    PRIMARY KEY CLUSTERED ([PromotionId], [Sequence] ASC);
GO

-- Creating primary key on [PromotionId], [Sequence] in table 'PromotionProducts'
ALTER TABLE [dbo].[PromotionProducts]
ADD CONSTRAINT [PK_PromotionProducts]
    PRIMARY KEY CLUSTERED ([PromotionId], [Sequence] ASC);
GO

-- Creating primary key on [PromotionId], [Sequence] in table 'PromotionReward'
ALTER TABLE [dbo].[PromotionReward]
ADD CONSTRAINT [PK_PromotionReward]
    PRIMARY KEY CLUSTERED ([PromotionId], [Sequence] ASC);
GO

-- Creating primary key on [PromotionId] in table 'PromotionTable'
ALTER TABLE [dbo].[PromotionTable]
ADD CONSTRAINT [PK_PromotionTable]
    PRIMARY KEY CLUSTERED ([PromotionId] ASC);
GO

-- Creating primary key on [SalesmanId] in table 'Salesman'
ALTER TABLE [dbo].[Salesman]
ADD CONSTRAINT [PK_Salesman]
    PRIMARY KEY CLUSTERED ([SalesmanId] ASC);
GO

-- Creating primary key on [ServerId] in table 'Server'
ALTER TABLE [dbo].[Server]
ADD CONSTRAINT [PK_Server]
    PRIMARY KEY CLUSTERED ([ServerId] ASC);
GO

-- Creating primary key on [TaxId] in table 'TaxTable'
ALTER TABLE [dbo].[TaxTable]
ADD CONSTRAINT [PK_TaxTable]
    PRIMARY KEY CLUSTERED ([TaxId] ASC);
GO

-- Creating primary key on [PromotionTypeId] in table 'PromotionType'
ALTER TABLE [dbo].[PromotionType]
ADD CONSTRAINT [PK_PromotionType]
    PRIMARY KEY CLUSTERED ([PromotionTypeId] ASC);
GO

-- Creating primary key on [InternalCreditCardId] in table 'InternalCreditCard'
ALTER TABLE [dbo].[InternalCreditCard]
ADD CONSTRAINT [PK_InternalCreditCard]
    PRIMARY KEY CLUSTERED ([InternalCreditCardId] ASC);
GO

-- Creating primary key on [GlobalParameterId] in table 'GlobalParameter'
ALTER TABLE [dbo].[GlobalParameter]
ADD CONSTRAINT [PK_GlobalParameter]
    PRIMARY KEY CLUSTERED ([GlobalParameterId] ASC);
GO

-- Creating primary key on [InventTransTypeId] in table 'InventTransType'
ALTER TABLE [dbo].[InventTransType]
ADD CONSTRAINT [PK_InventTransType]
    PRIMARY KEY CLUSTERED ([InventTransTypeId] ASC);
GO

-- Creating primary key on [ProvinceId] in table 'Province'
ALTER TABLE [dbo].[Province]
ADD CONSTRAINT [PK_Province]
    PRIMARY KEY CLUSTERED ([ProvinceId] ASC);
GO

-- Creating primary key on [TransportId] in table 'Transport'
ALTER TABLE [dbo].[Transport]
ADD CONSTRAINT [PK_Transport]
    PRIMARY KEY CLUSTERED ([TransportId] ASC);
GO

-- Creating primary key on [TransportDriverId] in table 'TransportDriver'
ALTER TABLE [dbo].[TransportDriver]
ADD CONSTRAINT [PK_TransportDriver]
    PRIMARY KEY CLUSTERED ([TransportDriverId] ASC);
GO

-- Creating primary key on [TransportReasonId] in table 'TransportReason'
ALTER TABLE [dbo].[TransportReason]
ADD CONSTRAINT [PK_TransportReason]
    PRIMARY KEY CLUSTERED ([TransportReasonId] ASC);
GO

-- Creating primary key on [VendorId] in table 'Vendor'
ALTER TABLE [dbo].[Vendor]
ADD CONSTRAINT [PK_Vendor]
    PRIMARY KEY CLUSTERED ([VendorId] ASC);
GO

-- Creating primary key on [PaymModeId] in table 'PaymMode'
ALTER TABLE [dbo].[PaymMode]
ADD CONSTRAINT [PK_PaymMode]
    PRIMARY KEY CLUSTERED ([PaymModeId] ASC);
GO

-- Creating primary key on [RetentionCode] in table 'RetentionTable'
ALTER TABLE [dbo].[RetentionTable]
ADD CONSTRAINT [PK_RetentionTable]
    PRIMARY KEY CLUSTERED ([RetentionCode] ASC);
GO

-- Creating primary key on [UserId], [PasswordId] in table 'Supervisor'
ALTER TABLE [dbo].[Supervisor]
ADD CONSTRAINT [PK_Supervisor]
    PRIMARY KEY CLUSTERED ([UserId], [PasswordId] ASC);
GO

-- Creating primary key on [LogTypeId] in table 'LogType'
ALTER TABLE [dbo].[LogType]
ADD CONSTRAINT [PK_LogType]
    PRIMARY KEY CLUSTERED ([LogTypeId] ASC);
GO

-- Creating primary key on [SalesLogId] in table 'SalesLog'
ALTER TABLE [dbo].[SalesLog]
ADD CONSTRAINT [PK_SalesLog]
    PRIMARY KEY CLUSTERED ([SalesLogId] ASC);
GO

-- Creating primary key on [UserId] in table 'UserLogin'
ALTER TABLE [dbo].[UserLogin]
ADD CONSTRAINT [PK_UserLogin]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [EmissionPointId] in table 'EmissionPoint'
ALTER TABLE [dbo].[EmissionPoint]
ADD CONSTRAINT [PK_EmissionPoint]
    PRIMARY KEY CLUSTERED ([EmissionPointId] ASC);
GO

-- Creating primary key on [LocationId], [SequenceId] in table 'SequenceTable'
ALTER TABLE [dbo].[SequenceTable]
ADD CONSTRAINT [PK_SequenceTable]
    PRIMARY KEY CLUSTERED ([LocationId], [SequenceId] ASC);
GO

-- Creating primary key on [SequenceTypeId] in table 'SequenceType'
ALTER TABLE [dbo].[SequenceType]
ADD CONSTRAINT [PK_SequenceType]
    PRIMARY KEY CLUSTERED ([SequenceTypeId] ASC);
GO

-- Creating primary key on [ProductId], [LocationId] in table 'ProductModule'
ALTER TABLE [dbo].[ProductModule]
ADD CONSTRAINT [PK_ProductModule]
    PRIMARY KEY CLUSTERED ([ProductId], [LocationId] ASC);
GO

-- Creating primary key on [GiftCardBlockId] in table 'GiftCardBlockTable'
ALTER TABLE [dbo].[GiftCardBlockTable]
ADD CONSTRAINT [PK_GiftCardBlockTable]
    PRIMARY KEY CLUSTERED ([GiftCardBlockId] ASC);
GO

-- Creating primary key on [GiftCardId] in table 'GiftCardTable'
ALTER TABLE [dbo].[GiftCardTable]
ADD CONSTRAINT [PK_GiftCardTable]
    PRIMARY KEY CLUSTERED ([GiftCardId] ASC);
GO

-- Creating primary key on [PromotionId], [Sequence] in table 'PromotionPaymMode'
ALTER TABLE [dbo].[PromotionPaymMode]
ADD CONSTRAINT [PK_PromotionPaymMode]
    PRIMARY KEY CLUSTERED ([PromotionId], [Sequence] ASC);
GO

-- Creating primary key on [TransferStatusId] in table 'TransferStatus'
ALTER TABLE [dbo].[TransferStatus]
ADD CONSTRAINT [PK_TransferStatus]
    PRIMARY KEY CLUSTERED ([TransferStatusId] ASC);
GO

-- Creating primary key on [CustomerId] in table 'Customer'
ALTER TABLE [dbo].[Customer]
ADD CONSTRAINT [PK_Customer]
    PRIMARY KEY CLUSTERED ([CustomerId] ASC);
GO

-- Creating primary key on [LocationId] in table 'Location'
ALTER TABLE [dbo].[Location]
ADD CONSTRAINT [PK_Location]
    PRIMARY KEY CLUSTERED ([LocationId] ASC);
GO

-- Creating primary key on [PhysicalStockCountingId], [Sequence] in table 'PhysicalStockCountingLine'
ALTER TABLE [dbo].[PhysicalStockCountingLine]
ADD CONSTRAINT [PK_PhysicalStockCountingLine]
    PRIMARY KEY CLUSTERED ([PhysicalStockCountingId], [Sequence] ASC);
GO

-- Creating primary key on [PhysicalStockCountingId] in table 'PhysicalStockCountingTable'
ALTER TABLE [dbo].[PhysicalStockCountingTable]
ADD CONSTRAINT [PK_PhysicalStockCountingTable]
    PRIMARY KEY CLUSTERED ([PhysicalStockCountingId] ASC);
GO

-- Creating primary key on [BankId] in table 'Bank'
ALTER TABLE [dbo].[Bank]
ADD CONSTRAINT [PK_Bank]
    PRIMARY KEY CLUSTERED ([BankId] ASC);
GO

-- Creating primary key on [BankId], [CreditCardId] in table 'BankCreditCard'
ALTER TABLE [dbo].[BankCreditCard]
ADD CONSTRAINT [PK_BankCreditCard]
    PRIMARY KEY CLUSTERED ([BankId], [CreditCardId] ASC);
GO

-- Creating primary key on [BrandId] in table 'Brand'
ALTER TABLE [dbo].[Brand]
ADD CONSTRAINT [PK_Brand]
    PRIMARY KEY CLUSTERED ([BrandId] ASC);
GO

-- Creating primary key on [ReasonId] in table 'CancelReason'
ALTER TABLE [dbo].[CancelReason]
ADD CONSTRAINT [PK_CancelReason]
    PRIMARY KEY CLUSTERED ([ReasonId] ASC);
GO

-- Creating primary key on [CityId] in table 'City'
ALTER TABLE [dbo].[City]
ADD CONSTRAINT [PK_City]
    PRIMARY KEY CLUSTERED ([CityId] ASC);
GO

-- Creating primary key on [CompanyId] in table 'Company'
ALTER TABLE [dbo].[Company]
ADD CONSTRAINT [PK_Company]
    PRIMARY KEY CLUSTERED ([CompanyId] ASC);
GO

-- Creating primary key on [CreditCardId] in table 'CreditCard'
ALTER TABLE [dbo].[CreditCard]
ADD CONSTRAINT [PK_CreditCard]
    PRIMARY KEY CLUSTERED ([CreditCardId] ASC);
GO

-- Creating primary key on [CurrencyDenominationId] in table 'CurrencyDenomination'
ALTER TABLE [dbo].[CurrencyDenomination]
ADD CONSTRAINT [PK_CurrencyDenomination]
    PRIMARY KEY CLUSTERED ([CurrencyDenominationId] ASC);
GO

-- Creating primary key on [CurrencyTypeId] in table 'CurrencyType'
ALTER TABLE [dbo].[CurrencyType]
ADD CONSTRAINT [PK_CurrencyType]
    PRIMARY KEY CLUSTERED ([CurrencyTypeId] ASC);
GO

-- Creating primary key on [CustomerAddressId] in table 'CustomerAddress'
ALTER TABLE [dbo].[CustomerAddress]
ADD CONSTRAINT [PK_CustomerAddress]
    PRIMARY KEY CLUSTERED ([CustomerAddressId] ASC);
GO

-- Creating primary key on [CustomerTypeId] in table 'CustomerType'
ALTER TABLE [dbo].[CustomerType]
ADD CONSTRAINT [PK_CustomerType]
    PRIMARY KEY CLUSTERED ([CustomerTypeId] ASC);
GO

-- Creating primary key on [DenominationTypeId] in table 'DenominationType'
ALTER TABLE [dbo].[DenominationType]
ADD CONSTRAINT [PK_DenominationType]
    PRIMARY KEY CLUSTERED ([DenominationTypeId] ASC);
GO

-- Creating primary key on [GiftCardBlockId], [Sequence] in table 'GiftCardBlockLine'
ALTER TABLE [dbo].[GiftCardBlockLine]
ADD CONSTRAINT [PK_GiftCardBlockLine]
    PRIMARY KEY CLUSTERED ([GiftCardBlockId], [Sequence] ASC);
GO

-- Creating primary key on [GiftCardId], [Sequence] in table 'GiftCardLine'
ALTER TABLE [dbo].[GiftCardLine]
ADD CONSTRAINT [PK_GiftCardLine]
    PRIMARY KEY CLUSTERED ([GiftCardId], [Sequence] ASC);
GO

-- Creating primary key on [GiftCardId], [Sequence], [ProdSeq] in table 'GiftCardLineProduct'
ALTER TABLE [dbo].[GiftCardLineProduct]
ADD CONSTRAINT [PK_GiftCardLineProduct]
    PRIMARY KEY CLUSTERED ([GiftCardId], [Sequence], [ProdSeq] ASC);
GO

-- Creating primary key on [GiftCardId], [Sequence], [TrnsSeq] in table 'GiftCardTrans'
ALTER TABLE [dbo].[GiftCardTrans]
ADD CONSTRAINT [PK_GiftCardTrans]
    PRIMARY KEY CLUSTERED ([GiftCardId], [Sequence], [TrnsSeq] ASC);
GO

-- Creating primary key on [IdentTypeId] in table 'IdentType'
ALTER TABLE [dbo].[IdentType]
ADD CONSTRAINT [PK_IdentType]
    PRIMARY KEY CLUSTERED ([IdentTypeId] ASC);
GO

-- Creating primary key on [InternalCreditCardId], [Sequence] in table 'InternalCreditCardLine'
ALTER TABLE [dbo].[InternalCreditCardLine]
ADD CONSTRAINT [PK_InternalCreditCardLine]
    PRIMARY KEY CLUSTERED ([InternalCreditCardId], [Sequence] ASC);
GO

-- Creating primary key on [InvoiceId], [Sequence] in table 'InvoiceLine'
ALTER TABLE [dbo].[InvoiceLine]
ADD CONSTRAINT [PK_InvoiceLine]
    PRIMARY KEY CLUSTERED ([InvoiceId], [Sequence] ASC);
GO

-- Creating primary key on [InvoiceId], [Sequence] in table 'InvoicePayment'
ALTER TABLE [dbo].[InvoicePayment]
ADD CONSTRAINT [PK_InvoicePayment]
    PRIMARY KEY CLUSTERED ([InvoiceId], [Sequence] ASC);
GO

-- Creating primary key on [SalesOrderId], [Sequence] in table 'SalesOrderLine'
ALTER TABLE [dbo].[SalesOrderLine]
ADD CONSTRAINT [PK_SalesOrderLine]
    PRIMARY KEY CLUSTERED ([SalesOrderId], [Sequence] ASC);
GO

-- Creating primary key on [SalesOrderId], [Sequence] in table 'SalesOrderPayment'
ALTER TABLE [dbo].[SalesOrderPayment]
ADD CONSTRAINT [PK_SalesOrderPayment]
    PRIMARY KEY CLUSTERED ([SalesOrderId], [Sequence] ASC);
GO

-- Creating primary key on [SalesOrderId], [Sequence] in table 'SalesOrderText'
ALTER TABLE [dbo].[SalesOrderText]
ADD CONSTRAINT [PK_SalesOrderText]
    PRIMARY KEY CLUSTERED ([SalesOrderId], [Sequence] ASC);
GO

-- Creating primary key on [SalesOrderId] in table 'SalesOrder'
ALTER TABLE [dbo].[SalesOrder]
ADD CONSTRAINT [PK_SalesOrder]
    PRIMARY KEY CLUSTERED ([SalesOrderId] ASC);
GO

-- Creating primary key on [SalesRemissionId], [Sequence] in table 'SalesRemissionLine'
ALTER TABLE [dbo].[SalesRemissionLine]
ADD CONSTRAINT [PK_SalesRemissionLine]
    PRIMARY KEY CLUSTERED ([SalesRemissionId], [Sequence] ASC);
GO

-- Creating primary key on [SalesOrderStatusId] in table 'SalesOrderStatus'
ALTER TABLE [dbo].[SalesOrderStatus]
ADD CONSTRAINT [PK_SalesOrderStatus]
    PRIMARY KEY CLUSTERED ([SalesOrderStatusId] ASC);
GO

-- Creating primary key on [SalesRemissionId] in table 'SalesRemissionTable'
ALTER TABLE [dbo].[SalesRemissionTable]
ADD CONSTRAINT [PK_SalesRemissionTable]
    PRIMARY KEY CLUSTERED ([SalesRemissionId] ASC);
GO

-- Creating primary key on [ProductId], [LocationId], [InventLocationId] in table 'InventProductLocation'
ALTER TABLE [dbo].[InventProductLocation]
ADD CONSTRAINT [PK_InventProductLocation]
    PRIMARY KEY CLUSTERED ([ProductId], [LocationId], [InventLocationId] ASC);
GO

-- Creating primary key on [SalesOriginId] in table 'SalesOrigin'
ALTER TABLE [dbo].[SalesOrigin]
ADD CONSTRAINT [PK_SalesOrigin]
    PRIMARY KEY CLUSTERED ([SalesOriginId] ASC);
GO

-- Creating primary key on [ProductId] in table 'Product'
ALTER TABLE [dbo].[Product]
ADD CONSTRAINT [PK_Product]
    PRIMARY KEY CLUSTERED ([ProductId] ASC);
GO

-- Creating primary key on [ClosingCashierId], [Sequence] in table 'ClosingCashierLine'
ALTER TABLE [dbo].[ClosingCashierLine]
ADD CONSTRAINT [PK_ClosingCashierLine]
    PRIMARY KEY CLUSTERED ([ClosingCashierId], [Sequence] ASC);
GO

-- Creating primary key on [ClosingCashierId], [Sequence] in table 'ClosingCashierMoney'
ALTER TABLE [dbo].[ClosingCashierMoney]
ADD CONSTRAINT [PK_ClosingCashierMoney]
    PRIMARY KEY CLUSTERED ([ClosingCashierId], [Sequence] ASC);
GO

-- Creating primary key on [ClosingCashierId] in table 'ClosingCashierTable'
ALTER TABLE [dbo].[ClosingCashierTable]
ADD CONSTRAINT [PK_ClosingCashierTable]
    PRIMARY KEY CLUSTERED ([ClosingCashierId] ASC);
GO

-- Creating primary key on [InvoiceId] in table 'InvoiceTable'
ALTER TABLE [dbo].[InvoiceTable]
ADD CONSTRAINT [PK_InvoiceTable]
    PRIMARY KEY CLUSTERED ([InvoiceId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PromotionId] in table 'PromotionCustomer'
ALTER TABLE [dbo].[PromotionCustomer]
ADD CONSTRAINT [FK__PromotionCustomer_PromotionTable]
    FOREIGN KEY ([PromotionId])
    REFERENCES [dbo].[PromotionTable]
        ([PromotionId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [PromotionId] in table 'PromotionProducts'
ALTER TABLE [dbo].[PromotionProducts]
ADD CONSTRAINT [FK__PromotionProducts_PromotionTable]
    FOREIGN KEY ([PromotionId])
    REFERENCES [dbo].[PromotionTable]
        ([PromotionId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [PromotionId] in table 'PromotionReward'
ALTER TABLE [dbo].[PromotionReward]
ADD CONSTRAINT [FK__PromotionReward_PromotionTable]
    FOREIGN KEY ([PromotionId])
    REFERENCES [dbo].[PromotionTable]
        ([PromotionId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [PromotionTypeId] in table 'PromotionTable'
ALTER TABLE [dbo].[PromotionTable]
ADD CONSTRAINT [FK__PromotionTable_PromotionType]
    FOREIGN KEY ([PromotionTypeId])
    REFERENCES [dbo].[PromotionType]
        ([PromotionTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__PromotionTable_PromotionType'
CREATE INDEX [IX_FK__PromotionTable_PromotionType]
ON [dbo].[PromotionTable]
    ([PromotionTypeId]);
GO

-- Creating foreign key on [CountryId] in table 'Province'
ALTER TABLE [dbo].[Province]
ADD CONSTRAINT [FK__Province_Country]
    FOREIGN KEY ([CountryId])
    REFERENCES [dbo].[Country]
        ([CountryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Province_Country'
CREATE INDEX [IX_FK__Province_Country]
ON [dbo].[Province]
    ([CountryId]);
GO

-- Creating foreign key on [LogTypeId] in table 'SalesLog'
ALTER TABLE [dbo].[SalesLog]
ADD CONSTRAINT [FK__SalesLog_LogType]
    FOREIGN KEY ([LogTypeId])
    REFERENCES [dbo].[LogType]
        ([LogTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__SalesLog_LogType'
CREATE INDEX [IX_FK__SalesLog_LogType]
ON [dbo].[SalesLog]
    ([LogTypeId]);
GO

-- Creating foreign key on [UserId] in table 'Supervisor'
ALTER TABLE [dbo].[Supervisor]
ADD CONSTRAINT [FK__Supervisor_UserLogin]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserLogin]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [InventLocationId] in table 'EmissionPoint'
ALTER TABLE [dbo].[EmissionPoint]
ADD CONSTRAINT [FK__EmissionPoint_InventLocation]
    FOREIGN KEY ([InventLocationId])
    REFERENCES [dbo].[InventLocation]
        ([InventLocationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__EmissionPoint_InventLocation'
CREATE INDEX [IX_FK__EmissionPoint_InventLocation]
ON [dbo].[EmissionPoint]
    ([InventLocationId]);
GO

-- Creating foreign key on [SequenceTypeId] in table 'SequenceTable'
ALTER TABLE [dbo].[SequenceTable]
ADD CONSTRAINT [FK__SequenceTable_SequenceType]
    FOREIGN KEY ([SequenceTypeId])
    REFERENCES [dbo].[SequenceType]
        ([SequenceTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__SequenceTable_SequenceType'
CREATE INDEX [IX_FK__SequenceTable_SequenceType]
ON [dbo].[SequenceTable]
    ([SequenceTypeId]);
GO

-- Creating foreign key on [GiftCardBlockId] in table 'GiftCardTable'
ALTER TABLE [dbo].[GiftCardTable]
ADD CONSTRAINT [FK__GiftCardTable_GiftCardBlockTable]
    FOREIGN KEY ([GiftCardBlockId])
    REFERENCES [dbo].[GiftCardBlockTable]
        ([GiftCardBlockId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__GiftCardTable_GiftCardBlockTable'
CREATE INDEX [IX_FK__GiftCardTable_GiftCardBlockTable]
ON [dbo].[GiftCardTable]
    ([GiftCardBlockId]);
GO

-- Creating foreign key on [PaymModeId] in table 'PromotionPaymMode'
ALTER TABLE [dbo].[PromotionPaymMode]
ADD CONSTRAINT [FK__PromotionPaymMode_PaymMode]
    FOREIGN KEY ([PaymModeId])
    REFERENCES [dbo].[PaymMode]
        ([PaymModeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__PromotionPaymMode_PaymMode'
CREATE INDEX [IX_FK__PromotionPaymMode_PaymMode]
ON [dbo].[PromotionPaymMode]
    ([PaymModeId]);
GO

-- Creating foreign key on [PromotionId] in table 'PromotionPaymMode'
ALTER TABLE [dbo].[PromotionPaymMode]
ADD CONSTRAINT [FK__PromotionPaymMode_PromotionTable]
    FOREIGN KEY ([PromotionId])
    REFERENCES [dbo].[PromotionTable]
        ([PromotionId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [CustomerId] in table 'AccountsReceivable'
ALTER TABLE [dbo].[AccountsReceivable]
ADD CONSTRAINT [FK__AccountsReceivable_Customer]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customer]
        ([CustomerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__AccountsReceivable_Customer'
CREATE INDEX [IX_FK__AccountsReceivable_Customer]
ON [dbo].[AccountsReceivable]
    ([CustomerId]);
GO

-- Creating foreign key on [CustomerId] in table 'GiftCardTable'
ALTER TABLE [dbo].[GiftCardTable]
ADD CONSTRAINT [FK__GiftCardTable_Customer]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customer]
        ([CustomerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__GiftCardTable_Customer'
CREATE INDEX [IX_FK__GiftCardTable_Customer]
ON [dbo].[GiftCardTable]
    ([CustomerId]);
GO

-- Creating foreign key on [CustomerId] in table 'InternalCreditCard'
ALTER TABLE [dbo].[InternalCreditCard]
ADD CONSTRAINT [FK__InternalCreditCard_Customer]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customer]
        ([CustomerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__InternalCreditCard_Customer'
CREATE INDEX [IX_FK__InternalCreditCard_Customer]
ON [dbo].[InternalCreditCard]
    ([CustomerId]);
GO

-- Creating foreign key on [CustomerId] in table 'PromotionCustomer'
ALTER TABLE [dbo].[PromotionCustomer]
ADD CONSTRAINT [FK__PromotionCustomer_Customer]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customer]
        ([CustomerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__PromotionCustomer_Customer'
CREATE INDEX [IX_FK__PromotionCustomer_Customer]
ON [dbo].[PromotionCustomer]
    ([CustomerId]);
GO

-- Creating foreign key on [LocationId] in table 'AccountsReceivable'
ALTER TABLE [dbo].[AccountsReceivable]
ADD CONSTRAINT [FK__AccountsReceivable_Location]
    FOREIGN KEY ([LocationId])
    REFERENCES [dbo].[Location]
        ([LocationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__AccountsReceivable_Location'
CREATE INDEX [IX_FK__AccountsReceivable_Location]
ON [dbo].[AccountsReceivable]
    ([LocationId]);
GO

-- Creating foreign key on [LocationId] in table 'Customer'
ALTER TABLE [dbo].[Customer]
ADD CONSTRAINT [FK__Customer_Location]
    FOREIGN KEY ([LocationId])
    REFERENCES [dbo].[Location]
        ([LocationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Customer_Location'
CREATE INDEX [IX_FK__Customer_Location]
ON [dbo].[Customer]
    ([LocationId]);
GO

-- Creating foreign key on [LocationId] in table 'EmissionPoint'
ALTER TABLE [dbo].[EmissionPoint]
ADD CONSTRAINT [FK__EmissionPoint_Location]
    FOREIGN KEY ([LocationId])
    REFERENCES [dbo].[Location]
        ([LocationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__EmissionPoint_Location'
CREATE INDEX [IX_FK__EmissionPoint_Location]
ON [dbo].[EmissionPoint]
    ([LocationId]);
GO

-- Creating foreign key on [LocationId] in table 'GiftCardBlockTable'
ALTER TABLE [dbo].[GiftCardBlockTable]
ADD CONSTRAINT [FK__GiftCardBlockTable_Location]
    FOREIGN KEY ([LocationId])
    REFERENCES [dbo].[Location]
        ([LocationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__GiftCardBlockTable_Location'
CREATE INDEX [IX_FK__GiftCardBlockTable_Location]
ON [dbo].[GiftCardBlockTable]
    ([LocationId]);
GO

-- Creating foreign key on [LocationId] in table 'GiftCardTable'
ALTER TABLE [dbo].[GiftCardTable]
ADD CONSTRAINT [FK__GiftCardTable_Location]
    FOREIGN KEY ([LocationId])
    REFERENCES [dbo].[Location]
        ([LocationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__GiftCardTable_Location'
CREATE INDEX [IX_FK__GiftCardTable_Location]
ON [dbo].[GiftCardTable]
    ([LocationId]);
GO

-- Creating foreign key on [LocationIdOrigin] in table 'GiftCardTable'
ALTER TABLE [dbo].[GiftCardTable]
ADD CONSTRAINT [FK__GiftCardTable_LocationOrigin]
    FOREIGN KEY ([LocationIdOrigin])
    REFERENCES [dbo].[Location]
        ([LocationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__GiftCardTable_LocationOrigin'
CREATE INDEX [IX_FK__GiftCardTable_LocationOrigin]
ON [dbo].[GiftCardTable]
    ([LocationIdOrigin]);
GO

-- Creating foreign key on [LocationId] in table 'InventLocation'
ALTER TABLE [dbo].[InventLocation]
ADD CONSTRAINT [FK__InventLocation_Location]
    FOREIGN KEY ([LocationId])
    REFERENCES [dbo].[Location]
        ([LocationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__InventLocation_Location'
CREATE INDEX [IX_FK__InventLocation_Location]
ON [dbo].[InventLocation]
    ([LocationId]);
GO

-- Creating foreign key on [LocationId] in table 'SequenceTable'
ALTER TABLE [dbo].[SequenceTable]
ADD CONSTRAINT [FK__SequenceTable_Location]
    FOREIGN KEY ([LocationId])
    REFERENCES [dbo].[Location]
        ([LocationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [InventLocationId] in table 'PhysicalStockCountingTable'
ALTER TABLE [dbo].[PhysicalStockCountingTable]
ADD CONSTRAINT [FK__PhysicalStockCountingTable_InventLocation]
    FOREIGN KEY ([InventLocationId])
    REFERENCES [dbo].[InventLocation]
        ([InventLocationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__PhysicalStockCountingTable_InventLocation'
CREATE INDEX [IX_FK__PhysicalStockCountingTable_InventLocation]
ON [dbo].[PhysicalStockCountingTable]
    ([InventLocationId]);
GO

-- Creating foreign key on [InventUnitId] in table 'PhysicalStockCountingLine'
ALTER TABLE [dbo].[PhysicalStockCountingLine]
ADD CONSTRAINT [FK__PhysicalStockCountingLine_InventUnit]
    FOREIGN KEY ([InventUnitId])
    REFERENCES [dbo].[InventUnit]
        ([InventUnitId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__PhysicalStockCountingLine_InventUnit'
CREATE INDEX [IX_FK__PhysicalStockCountingLine_InventUnit]
ON [dbo].[PhysicalStockCountingLine]
    ([InventUnitId]);
GO

-- Creating foreign key on [LocationId] in table 'PhysicalStockCountingTable'
ALTER TABLE [dbo].[PhysicalStockCountingTable]
ADD CONSTRAINT [FK__PhysicalStockCountingTable_Location]
    FOREIGN KEY ([LocationId])
    REFERENCES [dbo].[Location]
        ([LocationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__PhysicalStockCountingTable_Location'
CREATE INDEX [IX_FK__PhysicalStockCountingTable_Location]
ON [dbo].[PhysicalStockCountingTable]
    ([LocationId]);
GO

-- Creating foreign key on [PhysicalStockCountingId] in table 'PhysicalStockCountingLine'
ALTER TABLE [dbo].[PhysicalStockCountingLine]
ADD CONSTRAINT [FK__PhysicalStockCountingLine_PhysicalStockCountingTable]
    FOREIGN KEY ([PhysicalStockCountingId])
    REFERENCES [dbo].[PhysicalStockCountingTable]
        ([PhysicalStockCountingId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [BankId] in table 'BankCreditCard'
ALTER TABLE [dbo].[BankCreditCard]
ADD CONSTRAINT [FK__BankCreditCard_Bank]
    FOREIGN KEY ([BankId])
    REFERENCES [dbo].[Bank]
        ([BankId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [CreditCardId] in table 'BankCreditCard'
ALTER TABLE [dbo].[BankCreditCard]
ADD CONSTRAINT [FK__BankCreditCard_CreditCard]
    FOREIGN KEY ([CreditCardId])
    REFERENCES [dbo].[CreditCard]
        ([CreditCardId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__BankCreditCard_CreditCard'
CREATE INDEX [IX_FK__BankCreditCard_CreditCard]
ON [dbo].[BankCreditCard]
    ([CreditCardId]);
GO

-- Creating foreign key on [ProvinceId] in table 'City'
ALTER TABLE [dbo].[City]
ADD CONSTRAINT [FK__City_Province]
    FOREIGN KEY ([ProvinceId])
    REFERENCES [dbo].[Province]
        ([ProvinceId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__City_Province'
CREATE INDEX [IX_FK__City_Province]
ON [dbo].[City]
    ([ProvinceId]);
GO

-- Creating foreign key on [CityId] in table 'Company'
ALTER TABLE [dbo].[Company]
ADD CONSTRAINT [FK__Company_City]
    FOREIGN KEY ([CityId])
    REFERENCES [dbo].[City]
        ([CityId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Company_City'
CREATE INDEX [IX_FK__Company_City]
ON [dbo].[Company]
    ([CityId]);
GO

-- Creating foreign key on [CityId] in table 'Customer'
ALTER TABLE [dbo].[Customer]
ADD CONSTRAINT [FK__Customer_City]
    FOREIGN KEY ([CityId])
    REFERENCES [dbo].[City]
        ([CityId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Customer_City'
CREATE INDEX [IX_FK__Customer_City]
ON [dbo].[Customer]
    ([CityId]);
GO

-- Creating foreign key on [CityId] in table 'Location'
ALTER TABLE [dbo].[Location]
ADD CONSTRAINT [FK__Location_City]
    FOREIGN KEY ([CityId])
    REFERENCES [dbo].[City]
        ([CityId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Location_City'
CREATE INDEX [IX_FK__Location_City]
ON [dbo].[Location]
    ([CityId]);
GO

-- Creating foreign key on [CityId] in table 'Vendor'
ALTER TABLE [dbo].[Vendor]
ADD CONSTRAINT [FK__Vendor_City]
    FOREIGN KEY ([CityId])
    REFERENCES [dbo].[City]
        ([CityId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Vendor_City'
CREATE INDEX [IX_FK__Vendor_City]
ON [dbo].[Vendor]
    ([CityId]);
GO

-- Creating foreign key on [CompanyId] in table 'Location'
ALTER TABLE [dbo].[Location]
ADD CONSTRAINT [FK__Location_Company]
    FOREIGN KEY ([CompanyId])
    REFERENCES [dbo].[Company]
        ([CompanyId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Location_Company'
CREATE INDEX [IX_FK__Location_Company]
ON [dbo].[Location]
    ([CompanyId]);
GO

-- Creating foreign key on [CurrencyTypeId] in table 'CurrencyDenomination'
ALTER TABLE [dbo].[CurrencyDenomination]
ADD CONSTRAINT [FK__CurrencyDenomination_CurrencyType]
    FOREIGN KEY ([CurrencyTypeId])
    REFERENCES [dbo].[CurrencyType]
        ([CurrencyTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__CurrencyDenomination_CurrencyType'
CREATE INDEX [IX_FK__CurrencyDenomination_CurrencyType]
ON [dbo].[CurrencyDenomination]
    ([CurrencyTypeId]);
GO

-- Creating foreign key on [DenominationTypeId] in table 'CurrencyDenomination'
ALTER TABLE [dbo].[CurrencyDenomination]
ADD CONSTRAINT [FK__CurrencyDenomination_DenominationType]
    FOREIGN KEY ([DenominationTypeId])
    REFERENCES [dbo].[DenominationType]
        ([DenominationTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__CurrencyDenomination_DenominationType'
CREATE INDEX [IX_FK__CurrencyDenomination_DenominationType]
ON [dbo].[CurrencyDenomination]
    ([DenominationTypeId]);
GO

-- Creating foreign key on [CustomerTypeId] in table 'Customer'
ALTER TABLE [dbo].[Customer]
ADD CONSTRAINT [FK__Customer_CustomerType]
    FOREIGN KEY ([CustomerTypeId])
    REFERENCES [dbo].[CustomerType]
        ([CustomerTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Customer_CustomerType'
CREATE INDEX [IX_FK__Customer_CustomerType]
ON [dbo].[Customer]
    ([CustomerTypeId]);
GO

-- Creating foreign key on [IdentTypeId] in table 'Customer'
ALTER TABLE [dbo].[Customer]
ADD CONSTRAINT [FK__Customer_IdentType]
    FOREIGN KEY ([IdentTypeId])
    REFERENCES [dbo].[IdentType]
        ([IdentTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Customer_IdentType'
CREATE INDEX [IX_FK__Customer_IdentType]
ON [dbo].[Customer]
    ([IdentTypeId]);
GO

-- Creating foreign key on [CustomerId] in table 'CustomerAddress'
ALTER TABLE [dbo].[CustomerAddress]
ADD CONSTRAINT [FK__CustomerAddress_Customer]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customer]
        ([CustomerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__CustomerAddress_Customer'
CREATE INDEX [IX_FK__CustomerAddress_Customer]
ON [dbo].[CustomerAddress]
    ([CustomerId]);
GO

-- Creating foreign key on [CustomerId] in table 'GiftCardLine'
ALTER TABLE [dbo].[GiftCardLine]
ADD CONSTRAINT [FK__GiftCardLine_Customer]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customer]
        ([CustomerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__GiftCardLine_Customer'
CREATE INDEX [IX_FK__GiftCardLine_Customer]
ON [dbo].[GiftCardLine]
    ([CustomerId]);
GO

-- Creating foreign key on [GiftCardBlockId] in table 'GiftCardBlockLine'
ALTER TABLE [dbo].[GiftCardBlockLine]
ADD CONSTRAINT [FK__GiftCardBlockLine_GiftCardBlockTable]
    FOREIGN KEY ([GiftCardBlockId])
    REFERENCES [dbo].[GiftCardBlockTable]
        ([GiftCardBlockId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [GiftCardId] in table 'GiftCardLine'
ALTER TABLE [dbo].[GiftCardLine]
ADD CONSTRAINT [FK__GiftCardLine_GiftCardTable]
    FOREIGN KEY ([GiftCardId])
    REFERENCES [dbo].[GiftCardTable]
        ([GiftCardId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [GiftCardId], [Sequence] in table 'GiftCardLineProduct'
ALTER TABLE [dbo].[GiftCardLineProduct]
ADD CONSTRAINT [FK__GiftCardLineProduct_GiftCardLine]
    FOREIGN KEY ([GiftCardId], [Sequence])
    REFERENCES [dbo].[GiftCardLine]
        ([GiftCardId], [Sequence])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [GiftCardId], [Sequence] in table 'GiftCardTrans'
ALTER TABLE [dbo].[GiftCardTrans]
ADD CONSTRAINT [FK__GiftCardTrans_GiftCardLine]
    FOREIGN KEY ([GiftCardId], [Sequence])
    REFERENCES [dbo].[GiftCardLine]
        ([GiftCardId], [Sequence])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [LocationIdRedeem] in table 'GiftCardTrans'
ALTER TABLE [dbo].[GiftCardTrans]
ADD CONSTRAINT [FK__GiftCardTrans_LocationRedeem]
    FOREIGN KEY ([LocationIdRedeem])
    REFERENCES [dbo].[Location]
        ([LocationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__GiftCardTrans_LocationRedeem'
CREATE INDEX [IX_FK__GiftCardTrans_LocationRedeem]
ON [dbo].[GiftCardTrans]
    ([LocationIdRedeem]);
GO

-- Creating foreign key on [IdentTypeId] in table 'Vendor'
ALTER TABLE [dbo].[Vendor]
ADD CONSTRAINT [FK__Vendor_CustIdType]
    FOREIGN KEY ([IdentTypeId])
    REFERENCES [dbo].[IdentType]
        ([IdentTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Vendor_CustIdType'
CREATE INDEX [IX_FK__Vendor_CustIdType]
ON [dbo].[Vendor]
    ([IdentTypeId]);
GO

-- Creating foreign key on [InternalCreditCardId] in table 'InternalCreditCardLine'
ALTER TABLE [dbo].[InternalCreditCardLine]
ADD CONSTRAINT [FK__InternalCreditCardLine_InternalCreditCard]
    FOREIGN KEY ([InternalCreditCardId])
    REFERENCES [dbo].[InternalCreditCard]
        ([InternalCreditCardId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [PromotionId] in table 'InternalCreditCardLine'
ALTER TABLE [dbo].[InternalCreditCardLine]
ADD CONSTRAINT [FK__InternalCreditCardLine_PromotionTable]
    FOREIGN KEY ([PromotionId])
    REFERENCES [dbo].[PromotionTable]
        ([PromotionId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__InternalCreditCardLine_PromotionTable'
CREATE INDEX [IX_FK__InternalCreditCardLine_PromotionTable]
ON [dbo].[InternalCreditCardLine]
    ([PromotionId]);
GO

-- Creating foreign key on [InventUnitId] in table 'InvoiceLine'
ALTER TABLE [dbo].[InvoiceLine]
ADD CONSTRAINT [FK__InvoiceLine_InventUnit]
    FOREIGN KEY ([InventUnitId])
    REFERENCES [dbo].[InventUnit]
        ([InventUnitId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__InvoiceLine_InventUnit'
CREATE INDEX [IX_FK__InvoiceLine_InventUnit]
ON [dbo].[InvoiceLine]
    ([InventUnitId]);
GO

-- Creating foreign key on [InventUnitId] in table 'SalesOrderLine'
ALTER TABLE [dbo].[SalesOrderLine]
ADD CONSTRAINT [FK__SalesOrderLine_InventUnit]
    FOREIGN KEY ([InventUnitId])
    REFERENCES [dbo].[InventUnit]
        ([InventUnitId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__SalesOrderLine_InventUnit'
CREATE INDEX [IX_FK__SalesOrderLine_InventUnit]
ON [dbo].[SalesOrderLine]
    ([InventUnitId]);
GO

-- Creating foreign key on [LocationId] in table 'InvoicePayment'
ALTER TABLE [dbo].[InvoicePayment]
ADD CONSTRAINT [FK__InvoicePayment_Location]
    FOREIGN KEY ([LocationId])
    REFERENCES [dbo].[Location]
        ([LocationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__InvoicePayment_Location'
CREATE INDEX [IX_FK__InvoicePayment_Location]
ON [dbo].[InvoicePayment]
    ([LocationId]);
GO

-- Creating foreign key on [PaymModeId] in table 'InvoicePayment'
ALTER TABLE [dbo].[InvoicePayment]
ADD CONSTRAINT [FK__InvoicePayment_PaymMode]
    FOREIGN KEY ([PaymModeId])
    REFERENCES [dbo].[PaymMode]
        ([PaymModeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__InvoicePayment_PaymMode'
CREATE INDEX [IX_FK__InvoicePayment_PaymMode]
ON [dbo].[InvoicePayment]
    ([PaymModeId]);
GO

-- Creating foreign key on [PaymModeId] in table 'SalesOrderPayment'
ALTER TABLE [dbo].[SalesOrderPayment]
ADD CONSTRAINT [FK__SalesOrderPayment_PaymMode]
    FOREIGN KEY ([PaymModeId])
    REFERENCES [dbo].[PaymMode]
        ([PaymModeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__SalesOrderPayment_PaymMode'
CREATE INDEX [IX_FK__SalesOrderPayment_PaymMode]
ON [dbo].[SalesOrderPayment]
    ([PaymModeId]);
GO

-- Creating foreign key on [CustomerId] in table 'SalesOrder'
ALTER TABLE [dbo].[SalesOrder]
ADD CONSTRAINT [FK__SalesOrder_Customer]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customer]
        ([CustomerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__SalesOrder_Customer'
CREATE INDEX [IX_FK__SalesOrder_Customer]
ON [dbo].[SalesOrder]
    ([CustomerId]);
GO

-- Creating foreign key on [LocationId] in table 'SalesOrder'
ALTER TABLE [dbo].[SalesOrder]
ADD CONSTRAINT [FK__SalesOrder_Location]
    FOREIGN KEY ([LocationId])
    REFERENCES [dbo].[Location]
        ([LocationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__SalesOrder_Location'
CREATE INDEX [IX_FK__SalesOrder_Location]
ON [dbo].[SalesOrder]
    ([LocationId]);
GO

-- Creating foreign key on [SalesmanId] in table 'SalesOrder'
ALTER TABLE [dbo].[SalesOrder]
ADD CONSTRAINT [FK__SalesOrder_Salesman]
    FOREIGN KEY ([SalesmanId])
    REFERENCES [dbo].[Salesman]
        ([SalesmanId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__SalesOrder_Salesman'
CREATE INDEX [IX_FK__SalesOrder_Salesman]
ON [dbo].[SalesOrder]
    ([SalesmanId]);
GO

-- Creating foreign key on [SalesOrderId] in table 'SalesOrderLine'
ALTER TABLE [dbo].[SalesOrderLine]
ADD CONSTRAINT [FK__SalesOrderLine_SalesOrder]
    FOREIGN KEY ([SalesOrderId])
    REFERENCES [dbo].[SalesOrder]
        ([SalesOrderId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [SalesOrderId] in table 'SalesOrderPayment'
ALTER TABLE [dbo].[SalesOrderPayment]
ADD CONSTRAINT [FK__SalesOrderPayment_SalesOrder]
    FOREIGN KEY ([SalesOrderId])
    REFERENCES [dbo].[SalesOrder]
        ([SalesOrderId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [SalesOrderId] in table 'SalesOrderText'
ALTER TABLE [dbo].[SalesOrderText]
ADD CONSTRAINT [FK__SalesOrderText_FACTrPedidoCab]
    FOREIGN KEY ([SalesOrderId])
    REFERENCES [dbo].[SalesOrder]
        ([SalesOrderId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [EmissionPointId] in table 'SalesRemissionTable'
ALTER TABLE [dbo].[SalesRemissionTable]
ADD CONSTRAINT [FK__SalesRemissionTable_EmissionPoint]
    FOREIGN KEY ([EmissionPointId])
    REFERENCES [dbo].[EmissionPoint]
        ([EmissionPointId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__SalesRemissionTable_EmissionPoint'
CREATE INDEX [IX_FK__SalesRemissionTable_EmissionPoint]
ON [dbo].[SalesRemissionTable]
    ([EmissionPointId]);
GO

-- Creating foreign key on [LocationId] in table 'SalesRemissionTable'
ALTER TABLE [dbo].[SalesRemissionTable]
ADD CONSTRAINT [FK__SalesRemissionTable_Location]
    FOREIGN KEY ([LocationId])
    REFERENCES [dbo].[Location]
        ([LocationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__SalesRemissionTable_Location'
CREATE INDEX [IX_FK__SalesRemissionTable_Location]
ON [dbo].[SalesRemissionTable]
    ([LocationId]);
GO

-- Creating foreign key on [SalesRemissionId] in table 'SalesRemissionLine'
ALTER TABLE [dbo].[SalesRemissionLine]
ADD CONSTRAINT [FK__SalesRemissionLine_SalesRemissionTable]
    FOREIGN KEY ([SalesRemissionId])
    REFERENCES [dbo].[SalesRemissionTable]
        ([SalesRemissionId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [TransportId] in table 'SalesRemissionTable'
ALTER TABLE [dbo].[SalesRemissionTable]
ADD CONSTRAINT [FK__SalesRemissionTable_Transport]
    FOREIGN KEY ([TransportId])
    REFERENCES [dbo].[Transport]
        ([TransportId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__SalesRemissionTable_Transport'
CREATE INDEX [IX_FK__SalesRemissionTable_Transport]
ON [dbo].[SalesRemissionTable]
    ([TransportId]);
GO

-- Creating foreign key on [TransportDriverId] in table 'SalesRemissionTable'
ALTER TABLE [dbo].[SalesRemissionTable]
ADD CONSTRAINT [FK__SalesRemissionTable_TransportDriver]
    FOREIGN KEY ([TransportDriverId])
    REFERENCES [dbo].[TransportDriver]
        ([TransportDriverId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__SalesRemissionTable_TransportDriver'
CREATE INDEX [IX_FK__SalesRemissionTable_TransportDriver]
ON [dbo].[SalesRemissionTable]
    ([TransportDriverId]);
GO

-- Creating foreign key on [TransportReasonId] in table 'SalesRemissionTable'
ALTER TABLE [dbo].[SalesRemissionTable]
ADD CONSTRAINT [FK__SalesRemissionTable_TransportReason]
    FOREIGN KEY ([TransportReasonId])
    REFERENCES [dbo].[TransportReason]
        ([TransportReasonId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__SalesRemissionTable_TransportReason'
CREATE INDEX [IX_FK__SalesRemissionTable_TransportReason]
ON [dbo].[SalesRemissionTable]
    ([TransportReasonId]);
GO

-- Creating foreign key on [InventLocationId] in table 'InventProductLocation'
ALTER TABLE [dbo].[InventProductLocation]
ADD CONSTRAINT [FK__InventProductLocation_InventLocation]
    FOREIGN KEY ([InventLocationId])
    REFERENCES [dbo].[InventLocation]
        ([InventLocationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__InventProductLocation_InventLocation'
CREATE INDEX [IX_FK__InventProductLocation_InventLocation]
ON [dbo].[InventProductLocation]
    ([InventLocationId]);
GO

-- Creating foreign key on [SalesmanId] in table 'SalesOrigin'
ALTER TABLE [dbo].[SalesOrigin]
ADD CONSTRAINT [FK__SalesOrigin_Salesman]
    FOREIGN KEY ([SalesmanId])
    REFERENCES [dbo].[Salesman]
        ([SalesmanId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__SalesOrigin_Salesman'
CREATE INDEX [IX_FK__SalesOrigin_Salesman]
ON [dbo].[SalesOrigin]
    ([SalesmanId]);
GO

-- Creating foreign key on [SalesOriginId] in table 'SalesOrder'
ALTER TABLE [dbo].[SalesOrder]
ADD CONSTRAINT [FK__SalesOrder_SalesOrigin]
    FOREIGN KEY ([SalesOriginId])
    REFERENCES [dbo].[SalesOrigin]
        ([SalesOriginId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__SalesOrder_SalesOrigin'
CREATE INDEX [IX_FK__SalesOrder_SalesOrigin]
ON [dbo].[SalesOrder]
    ([SalesOriginId]);
GO

-- Creating foreign key on [BrandId] in table 'Product'
ALTER TABLE [dbo].[Product]
ADD CONSTRAINT [FK__Product_Brand]
    FOREIGN KEY ([BrandId])
    REFERENCES [dbo].[Brand]
        ([BrandId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Product_Brand'
CREATE INDEX [IX_FK__Product_Brand]
ON [dbo].[Product]
    ([BrandId]);
GO

-- Creating foreign key on [ProductId] in table 'GiftCardLineProduct'
ALTER TABLE [dbo].[GiftCardLineProduct]
ADD CONSTRAINT [FK__GiftCardLineProduct_Product]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Product]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__GiftCardLineProduct_Product'
CREATE INDEX [IX_FK__GiftCardLineProduct_Product]
ON [dbo].[GiftCardLineProduct]
    ([ProductId]);
GO

-- Creating foreign key on [ProductId] in table 'InventProductLocation'
ALTER TABLE [dbo].[InventProductLocation]
ADD CONSTRAINT [FK__InventProductLocation_Product]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Product]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [InventUnitId] in table 'Product'
ALTER TABLE [dbo].[Product]
ADD CONSTRAINT [FK__Product_InventUnit]
    FOREIGN KEY ([InventUnitId])
    REFERENCES [dbo].[InventUnit]
        ([InventUnitId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Product_InventUnit'
CREATE INDEX [IX_FK__Product_InventUnit]
ON [dbo].[Product]
    ([InventUnitId]);
GO

-- Creating foreign key on [ProductId] in table 'InvoiceLine'
ALTER TABLE [dbo].[InvoiceLine]
ADD CONSTRAINT [FK__InvoiceLine_Product]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Product]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__InvoiceLine_Product'
CREATE INDEX [IX_FK__InvoiceLine_Product]
ON [dbo].[InvoiceLine]
    ([ProductId]);
GO

-- Creating foreign key on [ProductId] in table 'PhysicalStockCountingLine'
ALTER TABLE [dbo].[PhysicalStockCountingLine]
ADD CONSTRAINT [FK__PhysicalStockCountingLine_Product]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Product]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__PhysicalStockCountingLine_Product'
CREATE INDEX [IX_FK__PhysicalStockCountingLine_Product]
ON [dbo].[PhysicalStockCountingLine]
    ([ProductId]);
GO

-- Creating foreign key on [ProductCategoryId] in table 'Product'
ALTER TABLE [dbo].[Product]
ADD CONSTRAINT [FK__Product_ProductCategory]
    FOREIGN KEY ([ProductCategoryId])
    REFERENCES [dbo].[ProductCategory]
        ([ProductCategoryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Product_ProductCategory'
CREATE INDEX [IX_FK__Product_ProductCategory]
ON [dbo].[Product]
    ([ProductCategoryId]);
GO

-- Creating foreign key on [ProductGroupId] in table 'Product'
ALTER TABLE [dbo].[Product]
ADD CONSTRAINT [FK__Product_ProductGroup]
    FOREIGN KEY ([ProductGroupId])
    REFERENCES [dbo].[ProductGroup]
        ([ProductGroupId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Product_ProductGroup'
CREATE INDEX [IX_FK__Product_ProductGroup]
ON [dbo].[Product]
    ([ProductGroupId]);
GO

-- Creating foreign key on [VendorId] in table 'Product'
ALTER TABLE [dbo].[Product]
ADD CONSTRAINT [FK__Product_VendorId]
    FOREIGN KEY ([VendorId])
    REFERENCES [dbo].[Vendor]
        ([VendorId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Product_VendorId'
CREATE INDEX [IX_FK__Product_VendorId]
ON [dbo].[Product]
    ([VendorId]);
GO

-- Creating foreign key on [ProductId] in table 'ProductBarcode'
ALTER TABLE [dbo].[ProductBarcode]
ADD CONSTRAINT [FK__ProductBarcode_Product]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Product]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ProductId] in table 'ProductModule'
ALTER TABLE [dbo].[ProductModule]
ADD CONSTRAINT [FK__ProductModule_Product]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Product]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ProductId] in table 'SalesOrderLine'
ALTER TABLE [dbo].[SalesOrderLine]
ADD CONSTRAINT [FK__SalesOrderLine_Product]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Product]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__SalesOrderLine_Product'
CREATE INDEX [IX_FK__SalesOrderLine_Product]
ON [dbo].[SalesOrderLine]
    ([ProductId]);
GO

-- Creating foreign key on [ClosingCashierId] in table 'ClosingCashierLine'
ALTER TABLE [dbo].[ClosingCashierLine]
ADD CONSTRAINT [FK__ClosingCashierLine_ClosingCashierTable]
    FOREIGN KEY ([ClosingCashierId])
    REFERENCES [dbo].[ClosingCashierTable]
        ([ClosingCashierId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [PaymModeId] in table 'ClosingCashierLine'
ALTER TABLE [dbo].[ClosingCashierLine]
ADD CONSTRAINT [FK__ClosingCashierLine_PaymMode]
    FOREIGN KEY ([PaymModeId])
    REFERENCES [dbo].[PaymMode]
        ([PaymModeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ClosingCashierLine_PaymMode'
CREATE INDEX [IX_FK__ClosingCashierLine_PaymMode]
ON [dbo].[ClosingCashierLine]
    ([PaymModeId]);
GO

-- Creating foreign key on [CurrencyDenominationId] in table 'ClosingCashierMoney'
ALTER TABLE [dbo].[ClosingCashierMoney]
ADD CONSTRAINT [FK__ClosingCashierMoney_CurrencyDenomination]
    FOREIGN KEY ([CurrencyDenominationId])
    REFERENCES [dbo].[CurrencyDenomination]
        ([CurrencyDenominationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ClosingCashierMoney_CurrencyDenomination'
CREATE INDEX [IX_FK__ClosingCashierMoney_CurrencyDenomination]
ON [dbo].[ClosingCashierMoney]
    ([CurrencyDenominationId]);
GO

-- Creating foreign key on [LocationId] in table 'ClosingCashierTable'
ALTER TABLE [dbo].[ClosingCashierTable]
ADD CONSTRAINT [FK__ClosingCashierTable_Location]
    FOREIGN KEY ([LocationId])
    REFERENCES [dbo].[Location]
        ([LocationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ClosingCashierTable_Location'
CREATE INDEX [IX_FK__ClosingCashierTable_Location]
ON [dbo].[ClosingCashierTable]
    ([LocationId]);
GO

-- Creating foreign key on [EmissionPointId] in table 'ClosingCashierTable'
ALTER TABLE [dbo].[ClosingCashierTable]
ADD CONSTRAINT [FK_PK__ClosingCashierTable_EmissionPoint]
    FOREIGN KEY ([EmissionPointId])
    REFERENCES [dbo].[EmissionPoint]
        ([EmissionPointId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PK__ClosingCashierTable_EmissionPoint'
CREATE INDEX [IX_FK_PK__ClosingCashierTable_EmissionPoint]
ON [dbo].[ClosingCashierTable]
    ([EmissionPointId]);
GO

-- Creating foreign key on [CustomerId] in table 'InvoiceTable'
ALTER TABLE [dbo].[InvoiceTable]
ADD CONSTRAINT [FK__InvoiceTable_Customer]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customer]
        ([CustomerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__InvoiceTable_Customer'
CREATE INDEX [IX_FK__InvoiceTable_Customer]
ON [dbo].[InvoiceTable]
    ([CustomerId]);
GO

-- Creating foreign key on [EmissionPointId] in table 'InvoiceTable'
ALTER TABLE [dbo].[InvoiceTable]
ADD CONSTRAINT [FK__InvoiceTable_EmissionPoint]
    FOREIGN KEY ([EmissionPointId])
    REFERENCES [dbo].[EmissionPoint]
        ([EmissionPointId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__InvoiceTable_EmissionPoint'
CREATE INDEX [IX_FK__InvoiceTable_EmissionPoint]
ON [dbo].[InvoiceTable]
    ([EmissionPointId]);
GO

-- Creating foreign key on [InvoiceId] in table 'InvoiceLine'
ALTER TABLE [dbo].[InvoiceLine]
ADD CONSTRAINT [FK__InvoiceLine_InvoiceTable]
    FOREIGN KEY ([InvoiceId])
    REFERENCES [dbo].[InvoiceTable]
        ([InvoiceId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [InvoiceId] in table 'InvoicePayment'
ALTER TABLE [dbo].[InvoicePayment]
ADD CONSTRAINT [FK__InvoicePayment_InvoiceTable]
    FOREIGN KEY ([InvoiceId])
    REFERENCES [dbo].[InvoiceTable]
        ([InvoiceId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [LocationId] in table 'InvoiceTable'
ALTER TABLE [dbo].[InvoiceTable]
ADD CONSTRAINT [FK__InvoiceTable_Location]
    FOREIGN KEY ([LocationId])
    REFERENCES [dbo].[Location]
        ([LocationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__InvoiceTable_Location'
CREATE INDEX [IX_FK__InvoiceTable_Location]
ON [dbo].[InvoiceTable]
    ([LocationId]);
GO

-- Creating foreign key on [SalesmanId] in table 'InvoiceTable'
ALTER TABLE [dbo].[InvoiceTable]
ADD CONSTRAINT [FK__InvoiceTable_Salesman]
    FOREIGN KEY ([SalesmanId])
    REFERENCES [dbo].[Salesman]
        ([SalesmanId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__InvoiceTable_Salesman'
CREATE INDEX [IX_FK__InvoiceTable_Salesman]
ON [dbo].[InvoiceTable]
    ([SalesmanId]);
GO

-- Creating foreign key on [SalesOriginId] in table 'InvoiceTable'
ALTER TABLE [dbo].[InvoiceTable]
ADD CONSTRAINT [FK__InvoiceTable_SalesOrigin]
    FOREIGN KEY ([SalesOriginId])
    REFERENCES [dbo].[SalesOrigin]
        ([SalesOriginId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__InvoiceTable_SalesOrigin'
CREATE INDEX [IX_FK__InvoiceTable_SalesOrigin]
ON [dbo].[InvoiceTable]
    ([SalesOriginId]);
GO

-- Creating foreign key on [TransferStatusId] in table 'InvoiceTable'
ALTER TABLE [dbo].[InvoiceTable]
ADD CONSTRAINT [FK__InvoiceTable_TransferStatus]
    FOREIGN KEY ([TransferStatusId])
    REFERENCES [dbo].[TransferStatus]
        ([TransferStatusId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__InvoiceTable_TransferStatus'
CREATE INDEX [IX_FK__InvoiceTable_TransferStatus]
ON [dbo].[InvoiceTable]
    ([TransferStatusId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------