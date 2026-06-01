-- ============================================================
-- DML Part 03: Inventory Data
-- Tables: Vendor, Brand, InventLocation, InventUnit,
--         ProductCategory, ProductGroup
-- ============================================================

USE POSDB
GO

-- Vendor
INSERT INTO [Vendor]
SELECT 0, 'NINGUNO', '', 5, '', '', 0, '', '', 1, '', 'A', 1, 0, NULL, NULL, 'SERVER'
GO

-- Brand
INSERT INTO [Brand]
SELECT 0, 'NINGUNO', '', 'A', 1, 0, NULL, NULL, 'SERVER'
GO

-- InventLocation
INSERT INTO [InventLocation]
SELECT *, 'A', 1, 0, NULL, NULL, 'SERVER'
FROM (
	  SELECT  1 [InventLocationId], 'SUPERMERCADOS SAMBORONDON'          [Name], '' [SAPCode], 1 [LocationId], '' [Type], 1 [IsMain]
UNION SELECT  2, 'SECOS SAMBORONDON',                                            '', 1, '', 0
UNION SELECT  3, 'CARNICOS SAMBORONDON',                                         '', 1, '', 0
UNION SELECT  4, 'LEGUMBRES SAMBORONDON',                                        '', 1, '', 0
UNION SELECT  5, 'MATERIALES Y SUMINISTROS SAMBORONDON',                         '', 1, '', 0
UNION SELECT  6, 'DEVOLUCIONES SAMBORONDON',                                     '', 1, '', 0
UNION SELECT  7, 'COCINA SAMBORONDON',                                           '', 1, '', 0
UNION SELECT  8, 'TRANSITO SAMBORONDON',                                         '', 1, '', 0
UNION SELECT  9, 'TEMPORADA SAMBORONDON',                                        '', 1, '', 0
UNION SELECT 10, 'COMPRAS SAMBORONDON',                                          '', 1, '', 0
-- LA JOYA
UNION SELECT 11, 'SUPERMERCADOS LA JOYA',                                        '', 2, '', 1
UNION SELECT 12, 'SECOS LA JOYA',                                                '', 2, '', 0
UNION SELECT 13, 'CARNICOS LA JOYA',                                             '', 2, '', 0
UNION SELECT 14, 'LEGUMBRES LA JOYA',                                            '', 2, '', 0
UNION SELECT 15, 'MATERIALES Y SUMINISTROS LA JOYA',                             '', 2, '', 0
UNION SELECT 16, 'DEVOLUCIONES LA JOYA',                                         '', 2, '', 0
UNION SELECT 17, 'COCINA LA JOYA',                                               '', 2, '', 0
UNION SELECT 18, 'TRANSITO LA JOYA',                                             '', 2, '', 0
UNION SELECT 19, 'TEMPORADA LA JOYA',                                            '', 2, '', 0
UNION SELECT 20, 'COMPRAS LA JOYA',                                              '', 2, '', 0
-- ALBORADA
UNION SELECT 21, 'SUPERMERCADOS ALBORADA',                                       '', 3, '', 1
UNION SELECT 22, 'SECOS ALBORADA',                                               '', 3, '', 0
UNION SELECT 23, 'CARNICOS ALBORADA',                                            '', 3, '', 0
UNION SELECT 24, 'LEGUMBRES ALBORADA',                                           '', 3, '', 0
UNION SELECT 25, 'MATERIALES Y SUMINISTROS ALBORADA',                            '', 3, '', 0
UNION SELECT 26, 'DEVOLUCIONES ALBORADA',                                        '', 3, '', 0
UNION SELECT 27, 'COCINA ALBORADA',                                              '', 3, '', 0
UNION SELECT 28, 'TRANSITO ALBORADA',                                            '', 3, '', 0
UNION SELECT 29, 'TEMPORADA ALBORADA',                                           '', 3, '', 0
UNION SELECT 30, 'COMPRAS ALBORADA',                                             '', 3, '', 0
-- AMERICAS
UNION SELECT 31, 'SUPERMERCADOS AMERICAS',                                       '', 4, '', 1
UNION SELECT 32, 'SECOS AMERICAS',                                               '', 4, '', 0
UNION SELECT 33, 'CARNICOS AMERICAS',                                            '', 4, '', 0
UNION SELECT 34, 'LEGUMBRES AMERICAS',                                           '', 4, '', 0
UNION SELECT 35, 'MATERIALES Y SUMINISTROS AMERICAS',                            '', 4, '', 0
UNION SELECT 36, 'DEVOLUCIONES AMERICAS',                                        '', 4, '', 0
UNION SELECT 37, 'COCINA AMERICAS',                                              '', 4, '', 0
UNION SELECT 38, 'TRANSITO AMERICAS',                                            '', 4, '', 0
UNION SELECT 39, 'TEMPORADA AMERICAS',                                           '', 4, '', 0
UNION SELECT 40, 'COMPRAS AMERICAS',                                             '', 4, '', 0
) VIRT
GO

-- InventUnit
INSERT INTO [InventUnit]
      SELECT '01', 'UNIDAD',    '', 0, 'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT '02', 'KILOGRAMO', '', 1, 'A', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT '03', 'LIBRA',     '', 1, 'I', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT '04', 'LITRO',     '', 0, 'I', 1, 0, NULL, NULL, 'SERVER'
UNION SELECT '05', 'METRO',     '', 0, 'I', 1, 0, NULL, NULL, 'SERVER'
GO

-- ProductCategory
INSERT INTO [ProductCategory]
SELECT 0, 0, 'NINGUNO', '', 0, 'A', 1, 0, NULL, NULL, 'SERVER'
GO

-- ProductGroup
INSERT INTO [ProductGroup]
SELECT 0, 'NINGUNO', 'A', 1, 0, NULL, NULL, 'SERVER'
GO
