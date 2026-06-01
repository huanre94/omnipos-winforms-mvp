# 📘 GitHub CLI - Guía de Comandos Útiles

> Comandos útiles de GitHub CLI (`gh`) para gestionar los issues de la migración OmniPOS.

---

## 📋 Ver Issues

### Ver todos los issues del repositorio
```bash
gh issue list
```

### Ver issues de la Fase 1 (por milestone)
```bash
gh issue list --milestone "Fase 1 - Clean Architecture + API REST"
```

### Ver issues abiertos
```bash
gh issue list --state open
```

### Ver issues cerrados
```bash
gh issue list --state closed
```

### Filtrar por label
```bash
# Por capa
gh issue list --label "domain"
gh issue list --label "application"
gh issue list --label "infrastructure"
gh issue list --label "api"

# Por tipo
gh issue list --label "enhancement"
gh issue list --label "testing"
gh issue list --label "documentation"

# Por fase
gh issue list --label "phase-1"
gh issue list --label "phase-2"
gh issue list --label "phase-3"
```

### Ver issues asignados a ti
```bash
gh issue list --assignee @me
```

### Ver un issue específico
```bash
gh issue view 1
gh issue view 5 --web  # Abrir en el navegador
```

---

## ✏️ Gestionar Issues

### Asignarte un issue
```bash
gh issue edit 1 --add-assignee @me
```

### Asignar a otro usuario
```bash
gh issue edit 1 --add-assignee usuario
```

### Agregar labels a un issue
```bash
gh issue edit 1 --add-label "domain,backend"
```

### Cambiar el milestone
```bash
gh issue edit 1 --milestone "Fase 2 - Frontend Replacement"
```

### Cerrar un issue
```bash
gh issue close 1
gh issue close 1 --comment "✅ Implementado y testeado correctamente"
```

### Reabrir un issue
```bash
gh issue reopen 1
```

---

## 💬 Comentar Issues

### Agregar un comentario
```bash
gh issue comment 1 --body "Trabajando en esto ahora"
```

### Agregar un comentario con archivo
```bash
gh issue comment 1 --body-file mensaje.txt
```

---

## 🏷️ Gestionar Labels

### Listar labels
```bash
gh label list
```

### Crear un label
```bash
gh label create "bug" --color "d73a4a" --description "Something isn't working"
```

### Editar un label
```bash
gh label edit "bug" --color "ff0000" --description "Critical bug"
```

### Eliminar un label
```bash
gh label delete "old-label"
```

---

## 📊 Gestionar Milestones

### Listar milestones
```bash
gh api repos/huanre94/omnipos-winforms-mvp/milestones | jq '.[] | {title: .title, open_issues: .open_issues, closed_issues: .closed_issues}'
```

### Ver progreso de un milestone
```bash
gh issue list --milestone "Fase 1 - Clean Architecture + API REST" --json number,title,state | jq 'group_by(.state) | map({state: .[0].state, count: length})'
```

---

## 🔍 Búsquedas Avanzadas

### Issues con múltiples labels
```bash
gh issue list --label "domain" --label "phase-1"
```

### Issues creados por ti
```bash
gh issue list --author @me
```

### Issues mencionando a alguien
```bash
gh issue list --mention usuario
```

### Buscar en el contenido
```bash
gh issue list --search "CustomerRepository"
```

---

## 📦 Crear Issues (manual)

### Crear un issue nuevo
```bash
gh issue create --title "Fix bug en AuthController" --body "Descripción del bug" --label "bug,api"
```

### Crear con un template
```bash
gh issue create --web  # Abrir en navegador con template
```

---

## 📈 Reportes y Estadísticas

### Contar issues abiertos por label
```bash
echo "Domain: $(gh issue list --label 'domain' --state open --json number | jq 'length')"
echo "Application: $(gh issue list --label 'application' --state open --json number | jq 'length')"
echo "Infrastructure: $(gh issue list --label 'infrastructure' --state open --json number | jq 'length')"
echo "API: $(gh issue list --label 'api' --state open --json number | jq 'length')"
```

### Ver issues por assignee
```bash
gh issue list --json assignees,title | jq '.[] | {title: .title, assignees: [.assignees[].login]}'
```

### Ver tiempo hasta cierre promedio (requiere jq)
```bash
gh issue list --state closed --json createdAt,closedAt | jq '[.[] | ((.closedAt | fromdateiso8601) - (.createdAt | fromdateiso8601)) / 86400] | add / length'
```

---

## 🔗 Trabajar con Pull Requests

### Ver PRs relacionados con issues
```bash
gh pr list --search "closes #1"
```

### Crear un PR que cierra un issue
```bash
gh pr create --title "Implementar POS.Domain" --body "Closes #1, #2, #3" --label "phase-1"
```

---

## 🚀 Workflow Recomendado

### 1. Listar issues pendientes de la Fase 1
```bash
gh issue list --milestone "Fase 1 - Clean Architecture + API REST" --state open
```

### 2. Asignarte el siguiente issue
```bash
gh issue edit 1 --add-assignee @me
```

### 3. Crear un branch para el issue
```bash
git checkout -b feature/issue-1-domain-setup
```

### 4. Trabajar en el issue...

### 5. Crear un PR que cierra el issue
```bash
gh pr create --title "[Fase 1.1] Configurar POS.Domain" --body "Closes #1" --label "domain,phase-1"
```

### 6. Después de merge, cerrar manualmente si no se cerró automáticamente
```bash
gh issue close 1 --comment "✅ Merged en main"
```

---

## 🎯 Atajos Útiles

### Alias de PowerShell para comandos comunes

Agregar al perfil de PowerShell (`$PROFILE`):

```powershell
# Alias para GitHub CLI
function ghi { gh issue list --milestone "Fase 1 - Clean Architecture + API REST" --state open }
function ghim { gh issue list --assignee @me --state open }
function ghic { param($num) gh issue close $num --comment "✅ Completado" }
function ghiv { param($num) gh issue view $num }
function ghie { param($num) gh issue edit $num --add-assignee @me }
```

Luego usar:
```bash
ghi      # Ver issues de Fase 1
ghim     # Ver mis issues
ghiv 1   # Ver issue #1
ghie 1   # Asignarme issue #1
ghic 1   # Cerrar issue #1
```

---

## 📚 Recursos Adicionales

- **GitHub CLI Docs:** https://cli.github.com/manual/
- **GitHub CLI Repo:** https://github.com/cli/cli
- **Issues del proyecto:** https://github.com/huanre94/omnipos-winforms-mvp/issues
- **Milestones:** https://github.com/huanre94/omnipos-winforms-mvp/milestones
- **Labels:** https://github.com/huanre94/omnipos-winforms-mvp/labels

---

## 💡 Tips

1. **Usa `--web` para abrir en el navegador**: `gh issue view 1 --web`
2. **Combina con `jq` para filtros avanzados**: `gh issue list --json title,labels | jq '.[] | select(.labels[].name == "domain")'`
3. **Usa `--json` para exportar datos**: `gh issue list --json number,title,state > issues.json`
4. **Configura aliases** en PowerShell para agilizar tu workflow
5. **Revisa el progreso del milestone regularmente**: `gh issue list --milestone "Fase 1 - Clean Architecture + API REST"`

---

**¡Trabaja eficientemente con GitHub CLI! 🚀**
