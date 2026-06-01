# 🐳 Guía Docker para OmniPOS

> Configuración de Docker para desarrollo local con SQL Server

---

## 📋 Contenido

1. [Prerequisitos](#prerequisitos)
2. [Servicios incluidos](#servicios-incluidos)
3. [Comandos básicos](#comandos-básicos)
4. [Configuración de conexión](#configuración-de-conexión)
5. [Scripts de inicialización](#scripts-de-inicialización)
6. [Troubleshooting](#troubleshooting)

---

## 🔧 Prerequisitos

### Instalar Docker Desktop

**Windows:**
1. Descargar desde: https://www.docker.com/products/docker-desktop
2. Instalar Docker Desktop
3. Reiniciar si es necesario
4. Verificar instalación:
   ```bash
   docker --version
   docker-compose --version
   ```

**Requisitos mínimos:**
- Windows 10 Pro/Enterprise/Education (Build 19041 o superior) o Windows 11
- WSL 2 habilitado
- Virtualization habilitada en BIOS
- 4 GB RAM mínimo (8 GB recomendado)
- 20 GB espacio en disco

---

## 🚀 Servicios incluidos

### 1. SQL Server 2022 Developer Edition
- **Puerto:** `1433`
- **Usuario:** `sa`
- **Password:** `YourStrong!Passw0rd` ⚠️ (cambiar en producción)
- **Volume:** `sqlserver_data` (datos persistentes)
- **Health check:** Verifica cada 10s que SQL Server esté respondiendo

### 2. Adminer (opcional)
- **Puerto:** `8080`
- **Uso:** Interfaz web para gestionar la base de datos
- **URL:** http://localhost:8080

---

## 🎮 Comandos básicos

### Iniciar servicios
```bash
# Iniciar solo SQL Server
docker-compose up -d sqlserver

# Iniciar todos los servicios (SQL Server + Adminer)
docker-compose up -d

# Ver logs en tiempo real
docker-compose logs -f sqlserver
```

### Verificar estado
```bash
# Ver servicios en ejecución
docker-compose ps

# Ver logs
docker-compose logs sqlserver

# Ver salud del contenedor
docker inspect omnipos-sqlserver --format='{{.State.Health.Status}}'
```

### Detener servicios
```bash
# Detener todos los servicios
docker-compose stop

# Detener y eliminar contenedores (mantiene datos)
docker-compose down

# Detener y eliminar TODO (incluye volúmenes de datos) ⚠️
docker-compose down -v
```

### Reiniciar servicios
```bash
# Reiniciar SQL Server
docker-compose restart sqlserver

# Recrear contenedor (útil para cambios en docker-compose.yml)
docker-compose up -d --force-recreate sqlserver
```

---

## 🔌 Configuración de conexión

### Connection String para desarrollo local

#### .NET / Entity Framework Core
```json
{
  "ConnectionStrings": {
	"DefaultConnection": "Server=localhost,1433;Database=OmniPOS;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;MultipleActiveResultSets=true"
  }
}
```

#### POS.Api / appsettings.Development.json
```json
{
  "ConnectionStrings": {
	"DefaultConnection": "Server=localhost,1433;Database=OmniPOS;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;MultipleActiveResultSets=true"
  },
  "Logging": {
	"LogLevel": {
	  "Default": "Information",
	  "Microsoft.AspNetCore": "Warning",
	  "Microsoft.EntityFrameworkCore.Database.Command": "Information"
	}
  }
}
```

#### WinForms (POS.DLL)
```csharp
// En Program.cs o donde se configure
customConnectionString = "Server=localhost,1433;Database=OmniPOS;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;MultipleActiveResultSets=true";
```

### Conectar desde SQL Server Management Studio (SSMS)
- **Server name:** `localhost,1433` o `127.0.0.1,1433`
- **Authentication:** SQL Server Authentication
- **Login:** `sa`
- **Password:** `YourStrong!Passw0rd`

### Conectar desde Visual Studio
1. **Server Explorer** → **Add Connection**
2. **Data source:** Microsoft SQL Server
3. **Server name:** `localhost,1433`
4. **Authentication:** SQL Server Authentication
5. **User name:** `sa`
6. **Password:** `YourStrong!Passw0rd`
7. **Database:** OmniPOS

### Conectar desde Adminer Web UI
1. Abrir http://localhost:8080
2. **System:** MS SQL
3. **Server:** `sqlserver` (nombre del contenedor)
4. **Username:** `sa`
5. **Password:** `YourStrong!Passw0rd`
6. **Database:** OmniPOS

---

## 📜 Scripts de inicialización

### Opción 1: Restaurar backup existente

Si tienes un backup `.bak`:

1. Colocar el archivo en `docker/sql-backup/`:
   ```
   docker/
   └── sql-backup/
	   └── OmniPOS.bak
   ```

2. Actualizar `docker-compose.yml`:
   ```yaml
   volumes:
	 - sqlserver-data:/var/opt/mssql
	 - ./docker/sql-backup:/var/opt/mssql/backup:ro
   ```

3. Restaurar desde el contenedor:
   ```bash
   docker exec -it omnipos-sqlserver /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "YourStrong!Passw0rd" -Q "RESTORE DATABASE [OmniPOS] FROM DISK='/var/opt/mssql/backup/OmniPOS.bak' WITH MOVE 'OmniPOS' TO '/var/opt/mssql/data/OmniPOS.mdf', MOVE 'OmniPOS_log' TO '/var/opt/mssql/data/OmniPOS_log.ldf', REPLACE"
   ```

### Opción 2: Ejecutar scripts SQL

Si tienes scripts `.sql`:

1. Crear carpeta para scripts:
   ```bash
   mkdir -p docker/sql-init
   ```

2. Colocar scripts en `docker/sql-init/`:
   ```
   docker/
   └── sql-init/
	   ├── 01-create-database.sql
	   ├── 02-create-tables.sql
	   └── 03-seed-data.sql
   ```

3. Ejemplo `01-create-database.sql`:
   ```sql
   IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'OmniPOS')
   BEGIN
	   CREATE DATABASE OmniPOS;
   END
   GO
   ```

4. Ejecutar manualmente:
   ```bash
   docker exec -i omnipos-sqlserver /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "YourStrong!Passw0rd" < docker/sql-init/01-create-database.sql
   ```

### Opción 3: Usar Entity Framework Migrations

1. Crear migración inicial:
   ```bash
   cd POS.Infrastructure
   dotnet ef migrations add InitialCreate --startup-project ../POS.Api
   ```

2. Aplicar migración:
   ```bash
   dotnet ef database update --startup-project ../POS.Api
   ```

---

## 🛠️ Troubleshooting

### SQL Server no inicia

**Síntoma:** El contenedor se reinicia constantemente.

**Solución:**
```bash
# Ver logs detallados
docker logs omnipos-sqlserver

# Verificar que la password cumple requisitos de complejidad
# Debe tener: mayúsculas, minúsculas, números y símbolos
# Mínimo 8 caracteres

# Verificar recursos de Docker Desktop
# Settings → Resources → Memory (mínimo 2 GB para SQL Server)
```

### Error "Login failed for user 'sa'"

**Solución:**
```bash
# Verificar que la password sea correcta
# Verificar que TrustServerCertificate=True esté en el connection string

# Resetear password de sa
docker exec -it omnipos-sqlserver /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "YourStrong!Passw0rd" -Q "ALTER LOGIN sa WITH PASSWORD = 'NewPassword@2024!'"
```

### No puedo conectar desde el host

**Solución:**
```bash
# Verificar que el puerto esté mapeado
docker-compose ps

# Verificar que el firewall permita conexiones al puerto 1433
# Windows: Settings → Firewall → Advanced settings → Inbound Rules

# Verificar que SQL Server Browser esté habilitado (no necesario en Docker)

# Usar 127.0.0.1 en lugar de localhost si hay problemas DNS
```

### "Cannot open database" o "Database does not exist"

**Solución:**
```bash
# Listar bases de datos disponibles
docker exec -it omnipos-sqlserver /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "YourStrong!Passw0rd" -Q "SELECT name FROM sys.databases"

# Crear la base de datos manualmente
docker exec -it omnipos-sqlserver /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "YourStrong!Passw0rd" -Q "CREATE DATABASE OmniPOS"
```

### Contenedor se queda en "starting"

**Solución:**
```bash
# Verificar health check
docker inspect omnipos-sqlserver --format='{{json .State.Health}}'

# Esperar 30-60 segundos (SQL Server tarda en iniciar)

# Si persiste, recrear contenedor
docker-compose down
docker-compose up -d sqlserver
```

### Error "Cannot connect to Docker daemon"

**Solución:**
- Verificar que Docker Desktop esté ejecutándose
- Reiniciar Docker Desktop
- En PowerShell como admin:
  ```powershell
  Restart-Service docker
  ```

### Volumen de datos corrupto

**Solución:**
```bash
# ⚠️ Esto eliminará TODOS los datos
docker-compose down -v
docker volume rm omnipos-sqlserver-data

# Recrear desde cero
docker-compose up -d sqlserver

# Restaurar backup o aplicar migraciones
```

---

## 📊 Monitoreo y mantenimiento

### Ver uso de recursos
```bash
# Ver estadísticas en tiempo real
docker stats omnipos-sqlserver

# Ver tamaño del volumen
docker system df -v
```

### Backup manual de la base de datos
```bash
# Crear directorio para backups
mkdir -p docker/sql-backup

# Hacer backup
docker exec -it omnipos-sqlserver /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "YourStrong!Passw0rd" -Q "BACKUP DATABASE [OmniPOS] TO DISK = '/var/opt/mssql/backup/OmniPOS_$(date +%Y%m%d_%H%M%S).bak' WITH FORMAT, INIT, NAME = 'OmniPOS-full', SKIP, NOREWIND, NOUNLOAD, STATS = 10"
```

### Limpiar contenedores y volúmenes viejos
```bash
# Limpiar contenedores detenidos
docker container prune

# Limpiar volúmenes no usados
docker volume prune

# Limpiar todo (⚠️ cuidado)
docker system prune -a
```

---

## 🔐 Seguridad

### Cambiar password de SA

**Importante:** Cambiar la password por defecto antes de usar en entornos compartidos.

1. Editar `docker-compose.yml`:
   ```yaml
   environment:
	 - SA_PASSWORD=TuPasswordSegura@2024!
   ```

2. Actualizar connection strings en:
   - `POS.Api/appsettings.Development.json`
   - `POS.Infrastructure/appsettings.json`
   - `POS/App.config` (si aplica)

3. Recrear contenedor:
   ```bash
   docker-compose down
   docker-compose up -d
   ```

### Variables de entorno (.env)

Crear archivo `.env` en la raíz:

```env
# .env
SA_PASSWORD=MiPasswordSegura@2024!
MSSQL_PID=Developer
```

Actualizar `docker-compose.yml`:
```yaml
environment:
  - SA_PASSWORD=${SA_PASSWORD}
  - MSSQL_PID=${MSSQL_PID}
```

⚠️ **Agregar `.env` al `.gitignore`**

---

## 🚀 Comandos útiles rápidos

```bash
# Iniciar todo
docker-compose up -d

# Ver logs
docker-compose logs -f sqlserver

# Conectar con sqlcmd
docker exec -it omnipos-sqlserver /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "YourStrong!Passw0rd"

# Listar bases de datos
docker exec -it omnipos-sqlserver /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "YourStrong!Passw0rd" -Q "SELECT name FROM sys.databases"

# Crear base de datos
docker exec -it omnipos-sqlserver /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "YourStrong!Passw0rd" -Q "CREATE DATABASE OmniPOS"

# Detener todo
docker-compose down

# Reiniciar todo (mantiene datos)
docker-compose restart

# Ver estado de salud
docker inspect omnipos-sqlserver --format='{{.State.Health.Status}}'
```

---

## 📚 Recursos adicionales

- **Docker Documentation:** https://docs.docker.com/
- **SQL Server on Docker:** https://learn.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker
- **Docker Compose Documentation:** https://docs.docker.com/compose/
- **Adminer Documentation:** https://www.adminer.org/

---

**¡Listo para desarrollo local con Docker! 🐳**
