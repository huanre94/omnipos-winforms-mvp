# 📜 Scripts - OmniPOS

> Scripts de automatización y utilidades para el desarrollo

---

## 📋 Scripts Disponibles

### 1. `git-flow-status.ps1`

**Propósito:** Muestra el estado completo del repositorio y workflow de Git Flow

**Uso:**
```powershell
# Desde la raíz del proyecto
.\scripts\git-flow-status.ps1
```

**Información que muestra:**
- ✅ Rama actual
- 📝 Estado del working directory (archivos modificados)
- 🌳 Todas las ramas (locales y remotas)
- 📊 Últimos 7 commits con gráfico
- 🔍 Comparación entre `develop` y `master`
- 📚 Documentación disponible
- 🚀 Comandos rápidos más usados
- 🔗 Enlaces útiles de GitHub
- 📋 Próximos pasos sugeridos según tu rama actual

**Cuándo usarlo:**
- Al iniciar tu día de trabajo
- Antes de crear una nueva feature
- Para verificar el estado antes de un release
- Cuando necesites un resumen rápido del proyecto

---

### 2. `create-github-issues-v2.ps1`

**Propósito:** Crea o regenera GitHub Issues para el proyecto

**Uso:**
```powershell
.\scripts\create-github-issues-v2.ps1
```

**Nota:** Requiere GitHub CLI (`gh`) instalado y autenticado.

---

## 🚀 Uso Común

### Workflow Típico del Día

```powershell
# 1. Ver estado al iniciar
.\scripts\git-flow-status.ps1

# 2. Actualizar develop
git checkout develop
git pull origin develop

# 3. Crear feature
git checkout -b feature/mi-funcionalidad

# 4. Trabajar, commitear...
git add .
git commit -m "feat: descripción"
git push -u origin feature/mi-funcionalidad

# 5. Ver estado antes de crear PR
.\scripts\git-flow-status.ps1
```

---

## 📦 Crear Tus Propios Scripts

### Template Básico

```powershell
# Mi Script Custom
# Descripción de lo que hace

param(
	[Parameter(Mandatory=$false)]
	[string]$Parameter1
)

# Verificar que estamos en un repo Git
$gitCheck = git rev-parse --is-inside-work-tree 2>$null
if ($gitCheck -ne "true") {
	Write-Host "Error: No estás en un repositorio Git" -ForegroundColor Red
	exit 1
}

# Tu lógica aquí
Write-Host "Script ejecutándose..." -ForegroundColor Green

# Finalización
Write-Host "Completado!" -ForegroundColor Green
```

### Guardar Script

1. Crear archivo en `scripts/mi-script.ps1`
2. Hacer ejecutable (si es necesario)
3. Documentar en este README
4. Commitear:
   ```bash
   git add scripts/mi-script.ps1 scripts/README.md
   git commit -m "feat: add mi-script automation"
   ```

---

## 🔧 Configuración de Ejecución de Scripts

### Habilitar Ejecución de Scripts PowerShell

Si recibes error de "execution policy":

```powershell
# Ver política actual
Get-ExecutionPolicy

# Cambiar a RemoteSigned (recomendado)
Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser

# O ejecutar script con bypass temporal
powershell -ExecutionPolicy Bypass -File .\scripts\git-flow-status.ps1
```

---

## 📚 Recursos Relacionados

- [📖 Git Flow Quick Guide](../docs/GIT_FLOW_QUICK_GUIDE.md)
- [📖 Branching Strategy](../docs/BRANCHING_STRATEGY.md)
- [📖 GitHub CLI Guide](../docs/GITHUB_CLI_GUIDE.md)

---

## 💡 Ideas para Futuros Scripts

Posibles scripts a agregar:

- [ ] `setup-environment.ps1` - Configurar entorno de desarrollo completo
- [ ] `check-code-quality.ps1` - Ejecutar linters y formatters
- [ ] `run-all-tests.ps1` - Ejecutar suite completa de tests
- [ ] `prepare-release.ps1` - Automatizar preparación de release
- [ ] `sync-with-develop.ps1` - Sincronizar feature con develop
- [ ] `clean-branches.ps1` - Limpiar ramas locales mergeadas

---

## 🆘 Troubleshooting

### Script no se ejecuta

**Problema:** `File cannot be loaded because running scripts is disabled`

**Solución:**
```powershell
Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser
```

### Git no encontrado

**Problema:** `git: command not found`

**Solución:**
- Verificar que Git esté instalado
- Agregar Git al PATH de Windows
- Reiniciar terminal

### Error de permisos

**Problema:** `Access denied`

**Solución:**
- Ejecutar PowerShell como Administrador (si es necesario)
- Verificar permisos del archivo

---

## 📝 Changelog de Scripts

### v1.0.0 (2025-01-27)
- ✅ Agregado `git-flow-status.ps1`
- ✅ Documentación inicial de scripts

---

**Última actualización:** 2025-01-27
