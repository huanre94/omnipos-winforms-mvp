# 🌳 Estrategia de Branching - OmniPOS

> Estrategia basada en Git Flow para gestión de releases y desarrollo

---

## 📋 Contenido

1. [Estructura de Ramas](#estructura-de-ramas)
2. [Flujo de Trabajo](#flujo-de-trabajo)
3. [Convenciones de Nombres](#convenciones-de-nombres)
4. [Comandos Comunes](#comandos-comunes)
5. [Protección de Ramas](#protección-de-ramas)

---

## 🌲 Estructura de Ramas

### Ramas Principales (permanentes)

#### `master` / `main`
- **Propósito:** Código en producción
- **Protección:** ✅ Protegida - No permite push directo
- **Deploy:** Automático a producción
- **Merge desde:** `develop` (via Pull Request)
- **Tags:** Cada merge a master lleva un tag de versión (v1.0.0, v1.1.0, etc.)

#### `develop`
- **Propósito:** Rama de integración para testing/UAT
- **Protección:** ✅ Protegida - Requiere PR y revisión
- **Deploy:** Automático a entorno de Testing/UAT
- **Merge desde:** Ramas de feature, bugfix, hotfix
- **Merge hacia:** `master` cuando se completa un release

---

## 🔄 Flujo de Trabajo

### 1. Desarrollo de Nueva Funcionalidad

```bash
# Crear rama desde develop
git checkout develop
git pull origin develop
git checkout -b feature/nombre-funcionalidad

# Desarrollar, commitear, push
git add .
git commit -m "feat: descripción del cambio"
git push origin feature/nombre-funcionalidad

# Crear Pull Request hacia develop
```

### 2. Corrección de Bugs (no críticos)

```bash
# Crear rama desde develop
git checkout develop
git pull origin develop
git checkout -b bugfix/descripcion-bug

# Corregir, commitear, push
git add .
git commit -m "fix: corrección de bug"
git push origin bugfix/descripcion-bug

# Crear Pull Request hacia develop
```

### 3. Hotfix (corrección en producción)

```bash
# Crear rama desde master
git checkout master
git pull origin master
git checkout -b hotfix/descripcion-urgente

# Corregir rápidamente
git add .
git commit -m "hotfix: corrección urgente"
git push origin hotfix/descripcion-urgente

# Crear Pull Request hacia master Y develop
```

### 4. Release (paso a producción)

```bash
# Crear rama de release desde develop
git checkout develop
git pull origin develop
git checkout -b release/v1.0.0

# Ajustes finales, actualizar versiones
git add .
git commit -m "chore: prepare release v1.0.0"
git push origin release/v1.0.0

# Pull Request hacia master
# Una vez mergeado en master, mergear también en develop
```

---

## 📛 Convenciones de Nombres

### Prefijos de Ramas

| Tipo | Prefijo | Ejemplo | Descripción |
|------|---------|---------|-------------|
| **Feature** | `feature/` | `feature/customer-search` | Nueva funcionalidad |
| **Bugfix** | `bugfix/` | `bugfix/invoice-calculation` | Corrección de bug no crítico |
| **Hotfix** | `hotfix/` | `hotfix/security-patch` | Corrección urgente en producción |
| **Release** | `release/` | `release/v1.2.0` | Preparación de release |
| **Docs** | `docs/` | `docs/api-documentation` | Solo documentación |
| **Test** | `test/` | `test/integration-tests` | Tests o experimentos |
| **Refactor** | `refactor/` | `refactor/customer-repository` | Refactorización de código |

### Nombres Descriptivos

✅ **Bueno:**
- `feature/customer-credit-card-support`
- `bugfix/invoice-tax-calculation`
- `hotfix/sql-injection-vulnerability`
- `refactor/product-repository-async`

❌ **Malo:**
- `feature/fix`
- `bugfix/bug1`
- `test123`
- `my-branch`

---

## 🔨 Comandos Comunes

### Configuración Inicial

```bash
# Crear rama develop desde master
git checkout master
git pull origin master
git checkout -b develop
git push -u origin develop
```

### Workflow Diario

```bash
# Actualizar develop local
git checkout develop
git pull origin develop

# Crear nueva feature
git checkout -b feature/mi-funcionalidad

# Trabajo, commits...
git add .
git commit -m "feat: implementar búsqueda de clientes"

# Push de la rama
git push -u origin feature/mi-funcionalidad

# Después del PR aprobado y mergeado, eliminar rama local
git checkout develop
git branch -d feature/mi-funcionalidad
```

### Sincronizar con Develop

```bash
# Mientras trabajas en tu feature, sincronizar con develop
git checkout feature/mi-funcionalidad
git fetch origin
git rebase origin/develop

# O merge si prefieres
git merge origin/develop
```

### Limpiar Ramas Antiguas

```bash
# Listar ramas locales
git branch

# Eliminar rama local
git branch -d feature/vieja-funcionalidad

# Eliminar rama remota
git push origin --delete feature/vieja-funcionalidad

# Limpiar referencias remotas obsoletas
git fetch --prune
```

---

## 🛡️ Protección de Ramas

### Configuración en GitHub

#### Para `master`:
1. Settings → Branches → Add rule
2. Branch name pattern: `master`
3. ✅ Require pull request before merging
4. ✅ Require approvals: 1
5. ✅ Require status checks to pass
6. ✅ Require branches to be up to date
7. ✅ Include administrators

#### Para `develop`:
1. Settings → Branches → Add rule
2. Branch name pattern: `develop`
3. ✅ Require pull request before merging
4. ✅ Require approvals: 1 (opcional si eres solo tú)
5. ✅ Require status checks to pass

---

## 📝 Convenciones de Commits

### Formato

```
<tipo>(<scope>): <descripción corta>

[cuerpo opcional]

[footer opcional]
```

### Tipos

| Tipo | Descripción | Ejemplo |
|------|-------------|---------|
| `feat` | Nueva funcionalidad | `feat(customers): add credit card validation` |
| `fix` | Corrección de bug | `fix(invoice): correct tax calculation` |
| `docs` | Solo documentación | `docs: update API documentation` |
| `style` | Formato, semicolons, etc | `style: format code with prettier` |
| `refactor` | Refactorización | `refactor(repository): use async/await` |
| `test` | Agregar tests | `test(customers): add unit tests` |
| `chore` | Mantenimiento | `chore: update dependencies` |
| `perf` | Mejora de performance | `perf(query): optimize customer search` |
| `ci` | CI/CD changes | `ci: add GitHub Actions workflow` |

### Ejemplos

```bash
feat(pos): implement barcode scanning for products
fix(invoice): resolve decimal rounding issue in tax calculation
docs(docker): add troubleshooting section
refactor(api): migrate to .NET 8 minimal APIs
test(customers): add integration tests for CustomerRepository
chore(deps): update Entity Framework to 8.0.11
```

---

## 🚀 Proceso de Release

### Checklist Pre-Release

- [ ] Todos los features del sprint mergeados en `develop`
- [ ] Tests pasando en `develop`
- [ ] UAT completado exitosamente
- [ ] Documentación actualizada
- [ ] CHANGELOG.md actualizado
- [ ] Versión incrementada en archivos relevantes

### Pasos

1. **Crear rama de release**
   ```bash
   git checkout develop
   git pull origin develop
   git checkout -b release/v1.2.0
   ```

2. **Ajustes finales**
   - Actualizar números de versión
   - Actualizar CHANGELOG.md
   - Commits de preparación

3. **Pull Request a master**
   - Crear PR desde `release/v1.2.0` → `master`
   - Revisión final
   - Aprobar y mergear

4. **Tag de versión**
   ```bash
   git checkout master
   git pull origin master
   git tag -a v1.2.0 -m "Release v1.2.0"
   git push origin v1.2.0
   ```

5. **Merge back a develop**
   ```bash
   git checkout develop
   git pull origin develop
   git merge master
   git push origin develop
   ```

6. **Limpiar rama de release**
   ```bash
   git branch -d release/v1.2.0
   git push origin --delete release/v1.2.0
   ```

---

## 🔥 Manejo de Hotfixes

### Proceso

1. **Detectar bug crítico en producción**

2. **Crear hotfix desde master**
   ```bash
   git checkout master
   git pull origin master
   git checkout -b hotfix/critical-security-fix
   ```

3. **Corregir y testear**
   ```bash
   # Hacer los cambios necesarios
   git add .
   git commit -m "hotfix: patch SQL injection vulnerability"
   ```

4. **Push y PR a master**
   ```bash
   git push -u origin hotfix/critical-security-fix
   # Crear PR hacia master
   ```

5. **También PR a develop**
   ```bash
   # Crear PR desde la misma rama hacia develop
   # O mergear directamente después del merge a master
   ```

6. **Tag de versión de patch**
   ```bash
   git checkout master
   git pull origin master
   git tag -a v1.2.1 -m "Hotfix v1.2.1"
   git push origin v1.2.1
   ```

---

## 📊 Diagrama de Flujo

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

---

## 🎯 Resumen Rápido

| Acción | Desde | Hacia | Comando |
|--------|-------|-------|---------|
| Nueva feature | `develop` | `develop` | `git checkout -b feature/xxx` |
| Bugfix normal | `develop` | `develop` | `git checkout -b bugfix/xxx` |
| Hotfix urgente | `master` | `master` + `develop` | `git checkout -b hotfix/xxx` |
| Release | `develop` | `master` | `git checkout -b release/vX.X.X` |

---

## 📚 Referencias

- [Git Flow](https://nvie.com/posts/a-successful-git-branching-model/)
- [Conventional Commits](https://www.conventionalcommits.org/)
- [Semantic Versioning](https://semver.org/)

---

**Última actualización:** 2025-01-27
