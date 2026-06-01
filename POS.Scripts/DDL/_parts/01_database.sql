/* =====================================================================
   DDL PART 01 - Creacion de la base de datos POSDB
   ===================================================================== */

USE MASTER
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = 'POSDB')
BEGIN
    ALTER DATABASE POSDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE
    DROP DATABASE POSDB
END
GO

CREATE DATABASE POSDB
    ON  ( NAME = POSDB_Data, FILENAME = '/var/opt/mssql/data/POSDB.mdf' )
LOG ON  ( NAME = POSDB_Log,  FILENAME = '/var/opt/mssql/data/POSDB_log.ldf' )
COLLATE SQL_Latin1_General_CP1_CI_AS
GO

USE POSDB
GO

ALTER DATABASE POSDB SET RECOVERY SIMPLE
GO
