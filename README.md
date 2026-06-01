# 🎯 OmniPOS - Sistema de Punto de Venta

> Sistema WinForms modernizado con arquitectura Clean Architecture y API REST

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=.net)](https://dotnet.microsoft.com/)
[![SQL Server](https://img.shields.io/badge/SQL_Server-2022-CC2927?logo=microsoft-sql-server)](https://www.microsoft.com/sql-server)
[![Docker](https://img.shields.io/badge/Docker-Ready-2496ED?logo=docker)](https://www.docker.com/)

---

## 📋 Tabla de Contenido

- [Acerca del Proyecto](#-acerca-del-proyecto)
- [Estructura de Ramas](#-estructura-de-ramas)
- [Tecnologías](#️-tecnologías)
- [Comenzando](#-comenzando)
- [Documentación](#-documentación)
- [Contribuir](#-contribuir)

---

## 🚀 Acerca del Proyecto

OmniPOS es un sistema de punto de venta empresarial construido con WinForms, migrando hacia una arquitectura moderna con Clean Architecture, Domain-Driven Design y APIs REST.

### Características Principales

- ✅ **WinForms Legacy**: Sistema de punto de venta completo funcional
- 🆕 **API REST**: Nueva capa de API con endpoints modernos
- 🏗️ **Clean Architecture**: Domain, Application, Infrastructure layers
- 🐳 **Docker Support**: Entorno de desarrollo con SQL Server containerizado
- 🔄 **Entity Framework Core**: ORM moderno para acceso a datos
- 📊 **SQL Server 2022**: Base de datos empresarial

---

## 🌳 Estructura de Ramas

Este proyecto utiliza **Git Flow** para gestión de código:

### Ramas Principales

| Rama | Propósito | Entorno | Protección |
|------|-----------|---------|------------|
| **`master`** | Código en producción | 🟢 Production | 🔒 Protegida |
| **`develop`** | Integración y testing | 🟡 UAT/Testing | 🔒 Protegida |
| **`toBeReleased`** | Rama histórica (legacy) | - | ⚠️ Deprecated |

### Ramas de Trabajo

- `feature/*` - Nuevas funcionalidades
- `bugfix/*` - Corrección de bugs no críticos
- `hotfix/*` - Correcciones urgentes en producción
- `release/*` - Preparación de releases

**Documentación completa:** [📖 Estrategia de Branching](docs/BRANCHING_STRATEGY.md)

### Flujo de Trabajo Rápido

```bash
# Crear nueva funcionalidad
git checkout develop
git checkout -b feature/mi-funcionalidad

# Desarrollar y commitear
git add .
git commit -m "feat: descripción"
git push origin feature/mi-funcionalidad

# Crear Pull Request hacia develop en GitHub
```

---

## 🛠️ Tecnologías

### Backend
- **.NET Framework 4.7.2** - Sistema WinForms legacy
- **.NET 8** - Nueva API REST
- **Entity Framework 6** - ORM legacy
- **Entity Framework Core 8** - ORM moderno
- **SQL Server 2022** - Base de datos
- **DevExpress 20.1.3** - Componentes UI (legacy)

### Infraestructura
- **Docker & Docker Compose** - Contenedores para desarrollo
- **Git & GitHub** - Control de versiones
- **Visual Studio 2022** - IDE principal

---

## 🚀 Comenzando

### Prerequisitos

- Visual Studio 2022 Community o superior
- .NET Framework 4.7.2 SDK
- .NET 8 SDK
- Docker Desktop (para desarrollo local)
- SQL Server 2022 (o usar Docker)
- DevExpress 20.1.3 (para WinForms legacy)

### Instalación

1. **Clonar el repositorio**
   ```bash
   git clone https://github.com/huanre94/omnipos-winforms-mvp.git
   cd omnipos-winforms-mvp
   ```

2. **Checkout a rama de desarrollo**
   ```bash
   git checkout develop
   ```

3. **Iniciar SQL Server con Docker**
   ```bash
   docker-compose up -d sqlserver
   ```

   Ver guía completa: [🐳 Docker Guide](docs/DOCKER_GUIDE.md)

4. **Restaurar NuGet packages**
   ```bash
   dotnet restore
   ```

5. **Configurar Connection String**

   Editar `POS.Api/appsettings.Development.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost,1433;Database=OmniPOS;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True"
     }
   }
   ```

6. **Ejecutar migraciones (opcional)**
   ```bash
   cd POS.Infrastructure
   dotnet ef database update --startup-project ../POS.Api
   ```

7. **Ejecutar la aplicación**

   **API:**
   ```bash
   cd POS.Api
   dotnet run
   ```

   **WinForms:**
   - Abrir `POS.sln` en Visual Studio
   - Set `POS` como startup project
   - F5 para ejecutar

---

## 📚 Documentación

| Documento | Descripción |
|-----------|-------------|
| [📖 Branching Strategy](docs/BRANCHING_STRATEGY.md) | Estrategia de ramas y Git Flow |
| [🐳 Docker Guide](docs/DOCKER_GUIDE.md) | Configuración de Docker para desarrollo |
| [🏗️ Architecture](docs/01-architecture.md) | Arquitectura del sistema |
| [📦 Backend Modules](docs/02-modules-backend.md) | Módulos y responsabilidades |
| [🗺️ Migration Plan](docs/03-migration-plan.md) | Plan de migración a arquitectura moderna |
| [📋 Project Structure](docs/05-project-structure.md) | Estructura de proyectos |
| [🛠️ Implementation Guide](docs/06-phase1-implementation-guide.md) | Guía de implementación Fase 1 |

### Índice de Documentación

Navegar toda la documentación: [📖 docs/README.md](docs/README.md)

---

## 🤝 Contribuir

### Proceso de Contribución

1. **Fork** el proyecto (opcional para colaboradores externos)
2. **Crear rama de feature** desde `develop`
   ```bash
   git checkout develop
   git pull origin develop
   git checkout -b feature/amazing-feature
   ```
3. **Commit** los cambios siguiendo convenciones
   ```bash
   git commit -m 'feat: add amazing feature'
   ```
4. **Push** a la rama
   ```bash
   git push origin feature/amazing-feature
   ```
5. **Abrir Pull Request** hacia `develop`

### Convenciones de Commits

Usamos [Conventional Commits](https://www.conventionalcommits.org/):

```
feat: nueva funcionalidad
fix: corrección de bug
docs: solo documentación
style: formato, semicolons, etc
refactor: refactorización de código
test: agregar tests
chore: mantenimiento, dependencias
```

**Ejemplos:**
```bash
feat(pos): implement barcode scanning
fix(invoice): resolve tax calculation rounding
docs(docker): add troubleshooting section
refactor(api): migrate to minimal APIs
```

Ver más en: [📖 Branching Strategy - Commits](docs/BRANCHING_STRATEGY.md#-convenciones-de-commits)

---

## 🔀 Workflow de Ramas

```
master    ──●────────────●─────────────●──────>  (v1.0)  (v1.1)  (v2.0)
             │             │             │
             │             │             │
develop   ───●─────●───●───●─────●───────●────>
                   │   │         │
                   │   │         │
feature/x         ●───●          │
                                 │
bugfix/y                        ●───●
```

- **`master`** → Producción estable con tags de versión
- **`develop`** → Integración continua para testing
- **`feature/*`** → Desarrollo de nuevas funcionalidades
- **`bugfix/*`** → Corrección de bugs
- **`hotfix/*`** → Parches urgentes desde master

---

## 📞 Soporte

Para reportar bugs o solicitar features:

- **GitHub Issues**: https://github.com/huanre94/omnipos-winforms-mvp/issues
- **Milestone**: [Fase 1 - Clean Architecture + API REST](https://github.com/huanre94/omnipos-winforms-mvp/milestones)

---

## 📄 Licencia

Este proyecto es privado y propiedad de [Tu Empresa].

---

## 🙏 Agradecimientos

- Equipo de desarrollo OmniPOS
- Comunidad .NET

---

## 🗂️ Estructura del Proyecto

```
omnipos-winforms-mvp/
├── POS/                      # WinForms Application (Legacy)
├── POS.DLL/                  # Business Logic Layer (Legacy)
├── POS.Domain/               # Domain Entities (Clean Architecture)
├── POS.Application/          # Application Services
├── POS.Infrastructure/       # Data Access & External Services
├── POS.Api/                  # REST API (.NET 8)
├── POS.Scripts/              # SQL Scripts (DDL, DML)
├── docker-compose.yml        # Docker configuration
├── docs/                     # Documentation
└── scripts/                  # Automation scripts
```

---

## 🔧 Build Routes

### DEV
> 192.168.17.120\shared\OmniPOS\

### Amr
> 192.168.15.10\shared\OmniPOS\

### Alb
> 192.168.16.10\shared\OmniPOS
        
### Smb
> \\\ 192.168.18.10\shared\OmniPOS

### Jya
> 192.168.19.10\sige\OmniPOS

