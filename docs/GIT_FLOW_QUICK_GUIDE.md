# 🚀 Guía Rápida de Git Flow - OmniPOS

> Comandos esenciales para trabajar con Git Flow en el día a día

---

## 🎯 Comandos Más Usados

### 🆕 Comenzar Nueva Funcionalidad

```bash
# 1. Actualizar develop
git checkout develop
git pull origin develop

# 2. Crear rama de feature
git checkout -b feature/nombre-descriptivo

# 3. Trabajar y commitear
git add .
git commit -m "feat: descripción del cambio"

# 4. Push primera vez
git push -u origin feature/nombre-descriptivo

# 5. Push subsecuentes
git push
```

---

## 🔄 Mantener Feature Actualizada

Mientras trabajas en tu feature, mantenerla actualizada con `develop`:

```bash
# Opción 1: Rebase (recomendado - mantiene historial limpio)
git checkout feature/mi-funcionalidad
git fetch origin
git rebase origin/develop

# Si hay conflictos, resolverlos y continuar
git add .
git rebase --continue

# Push (requiere force si ya habías pusheado antes)
git push --force-with-lease

# Opción 2: Merge (más seguro si hay dudas)
git checkout feature/mi-funcionalidad
git merge origin/develop

# Resolver conflictos si los hay
git add .
git commit -m "merge: sync with develop"
git push
```

---

## ✅ Finalizar Feature (Pull Request)

### Desde GitHub Web UI

1. **Ir a GitHub**: https://github.com/huanre94/omnipos-winforms-mvp/pulls
2. **Click "New Pull Request"**
3. **Base**: `develop` ← **Compare**: `feature/tu-rama`
4. **Agregar**:
   - Título descriptivo
   - Descripción de cambios
   - Screenshots si aplica
   - Referencias a issues: "Closes #123"
5. **Crear PR**
6. **Esperar aprobación** (si aplica)
7. **Merge** cuando esté listo
8. **Eliminar rama** después del merge

### Desde GitHub CLI

```bash
# Crear PR hacia develop
gh pr create --base develop --title "feat: título descriptivo" --body "Descripción detallada"

# Ver PRs
gh pr list

# Ver detalles de un PR
gh pr view [NUMBER]

# Mergear PR (si tienes permisos)
gh pr merge [NUMBER] --squash
```

---

## 🐛 Corregir Bug No Crítico

```bash
# 1. Desde develop
git checkout develop
git pull origin develop

# 2. Crear rama bugfix
git checkout -b bugfix/descripcion-bug

# 3. Corregir y commitear
git add .
git commit -m "fix: descripción de la corrección"

# 4. Push y PR hacia develop
git push -u origin bugfix/descripcion-bug
```

---

## 🔥 Hotfix Urgente (Producción)

```bash
# 1. Desde master
git checkout master
git pull origin master

# 2. Crear rama hotfix
git checkout -b hotfix/descripcion-urgente

# 3. Corregir rápidamente
git add .
git commit -m "hotfix: corrección crítica"

# 4. Push
git push -u origin hotfix/descripcion-urgente

# 5. Crear PR hacia master (urgente)
# 6. Después de mergear en master, también mergear en develop
git checkout develop
git pull origin develop
git merge master
git push origin develop
```

---

## 🏷️ Release (Pasar a Producción)

```bash
# 1. Crear rama release desde develop
git checkout develop
git pull origin develop
git checkout -b release/v1.2.0

# 2. Ajustes finales (versiones, CHANGELOG, etc)
git add .
git commit -m "chore: prepare release v1.2.0"
git push -u origin release/v1.2.0

# 3. PR hacia master
# Crear PR en GitHub: release/v1.2.0 → master

# 4. Después del merge en master, crear tag
git checkout master
git pull origin master
git tag -a v1.2.0 -m "Release v1.2.0"
git push origin v1.2.0

# 5. Mergear master de vuelta a develop
git checkout develop
git pull origin develop
git merge master
git push origin develop

# 6. Eliminar rama release
git branch -d release/v1.2.0
git push origin --delete release/v1.2.0
```

---

## 🔍 Ver Estado y Ramas

```bash
# Ver rama actual y estado
git status

# Ver todas las ramas locales
git branch

# Ver todas las ramas (locales y remotas)
git branch -a

# Ver ramas remotas
git branch -r

# Ver última commit de cada rama
git branch -v

# Ver historial
git log --oneline --graph --decorate --all

# Ver historial simplificado
git log --oneline -10
```

---

## 🧹 Limpiar Ramas Locales

```bash
# Eliminar rama local (debe estar mergeada)
git branch -d feature/vieja-funcionalidad

# Forzar eliminación (si no está mergeada)
git branch -D feature/experimental

# Actualizar lista de ramas remotas
git fetch --prune

# Ver ramas que ya fueron mergeadas en develop
git checkout develop
git branch --merged

# Eliminar todas las ramas locales ya mergeadas (excepto develop y master)
git branch --merged | grep -v "\*\|master\|develop" | xargs -n 1 git branch -d
```

---

## 🔄 Sincronizar con Remoto

```bash
# Traer cambios de todas las ramas
git fetch origin

# Traer cambios y mergear en rama actual
git pull origin [nombre-rama]

# Traer cambios de develop y mergear en rama actual
git pull origin develop

# Ver diferencias entre local y remoto
git diff origin/develop
```

---

## 🆘 Comandos de Emergencia

### Deshacer último commit (mantener cambios)
```bash
git reset --soft HEAD~1
```

### Deshacer último commit (descartar cambios)
```bash
git reset --hard HEAD~1
```

### Descartar cambios no commiteados
```bash
# Un archivo específico
git checkout -- archivo.cs

# Todos los archivos
git reset --hard
```

### Guardar cambios temporalmente (stash)
```bash
# Guardar cambios
git stash save "descripción"

# Ver stashes guardados
git stash list

# Recuperar último stash
git stash pop

# Recuperar stash específico
git stash apply stash@{0}

# Eliminar stash
git stash drop stash@{0}
```

### Resolver conflictos de merge
```bash
# Después de merge/rebase con conflictos:

# 1. Ver archivos con conflictos
git status

# 2. Editar archivos y resolver conflictos (buscar <<<<<<, =======, >>>>>>>)

# 3. Marcar como resueltos
git add archivo-resuelto.cs

# 4. Continuar merge/rebase
git commit  # Si fue merge
git rebase --continue  # Si fue rebase

# 5. Abortar merge/rebase si no puedes resolver
git merge --abort
git rebase --abort
```

---

## 📝 Convenciones de Commits

### Formato
```
<tipo>(<scope>): <descripción corta>

[cuerpo opcional con más detalles]

[footer opcional: Closes #123]
```

### Tipos
- `feat`: Nueva funcionalidad
- `fix`: Corrección de bug
- `docs`: Cambios en documentación
- `style`: Formato de código (no afecta lógica)
- `refactor`: Refactorización de código
- `test`: Agregar o modificar tests
- `chore`: Mantenimiento (deps, build, etc)
- `perf`: Mejora de performance
- `ci`: Cambios en CI/CD

### Ejemplos
```bash
feat(pos): implement barcode scanning functionality
fix(invoice): correct tax calculation for international sales
docs(api): add swagger documentation for customer endpoints
refactor(repository): convert CustomerRepository to async/await
test(pos): add unit tests for sale transaction validation
chore(deps): update Entity Framework Core to 8.0.11
```

---

## 🔗 Recursos Adicionales

- **Documentación completa**: [docs/BRANCHING_STRATEGY.md](BRANCHING_STRATEGY.md)
- **GitHub Issues**: https://github.com/huanre94/omnipos-winforms-mvp/issues
- **Pull Requests**: https://github.com/huanre94/omnipos-winforms-mvp/pulls

---

## 💡 Tips y Mejores Prácticas

### ✅ Hacer
- ✅ Commits pequeños y frecuentes
- ✅ Mensajes de commit descriptivos
- ✅ Pull de `develop` antes de crear nueva rama
- ✅ Push frecuente para backup
- ✅ Resolver conflictos lo antes posible
- ✅ Eliminar ramas después de mergear

### ❌ Evitar
- ❌ Commits gigantes con muchos cambios
- ❌ Mensajes vagos: "fix", "update", "cambios"
- ❌ Pushear a `master` o `develop` directamente
- ❌ Acumular muchos cambios sin commitear
- ❌ Ignorar conflictos
- ❌ Dejar ramas viejas sin eliminar

---

## 🎓 Escenarios Comunes

### Scenario 1: Empezar nueva feature
```bash
git checkout develop && git pull && git checkout -b feature/customer-search
# ... trabajar ...
git add . && git commit -m "feat: implement customer search"
git push -u origin feature/customer-search
```

### Scenario 2: Actualizar feature con últimos cambios de develop
```bash
git checkout feature/mi-feature
git fetch origin
git rebase origin/develop
# resolver conflictos si los hay
git push --force-with-lease
```

### Scenario 3: Mergear feature completada
```bash
# Desde GitHub web, crear PR: feature/mi-feature → develop
# Después de aprobar y mergear, limpiar:
git checkout develop
git pull origin develop
git branch -d feature/mi-feature
```

### Scenario 4: Hotfix urgente en producción
```bash
git checkout master && git pull
git checkout -b hotfix/critical-bug
# ... fix ...
git commit -am "hotfix: fix critical security vulnerability"
git push -u origin hotfix/critical-bug
# PR hacia master, mergear, luego:
git checkout develop && git merge master && git push
```

---

**Última actualización:** 2025-01-27
