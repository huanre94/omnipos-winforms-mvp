# OmniPOS — Documentación

> 📖 Documentación completa para la migración de OmniPOS de WinForms a Clean Architecture + API REST

## 🚀 Inicio Rápido

**¿Primera vez aquí?** Lee **[00-RESUMEN-COMPLETO.md](00-RESUMEN-COMPLETO.md)** para una visión general de todo lo disponible.

## Índice

| Archivo | Descripción |
|---------|-------------|
| [00-RESUMEN-COMPLETO.md](00-RESUMEN-COMPLETO.md) | ⭐ Resumen ejecutivo de toda la documentación y tareas creadas |
| [01-architecture.md](01-architecture.md) | Arquitectura general: As-Is vs To-Be, stack tecnológico, módulos |
| [02-modules-backend.md](02-modules-backend.md) | Módulos del backend: entidades, reglas de negocio, validaciones, endpoints |
| [03-migration-plan.md](03-migration-plan.md) | Plan de migración en 3 fases, mapeo Forms→API, deuda técnica |
| [04-screen-prompts.md](04-screen-prompts.md) | Prompts por pantalla para implementar el nuevo frontend con IA |
| [05-project-structure.md](05-project-structure.md) | Estructura de proyectos y carpetas propuesta, convenciones |
| [06-phase1-implementation-guide.md](06-phase1-implementation-guide.md) | Guía detallada paso a paso para implementar la Fase 1 |
| [GITHUB_ISSUES_SUMMARY.md](GITHUB_ISSUES_SUMMARY.md) | Resumen de los 26 GitHub Issues creados para la Fase 1 |
| [GITHUB_CLI_GUIDE.md](GITHUB_CLI_GUIDE.md) | Guía completa de comandos de GitHub CLI para gestionar issues |
| [index.html](index.html) | Lector centralizado de toda la documentación en formato web |

## Guía de uso rápido

### Para empezar la migración
1. Lee `01-architecture.md` para entender el panorama completo.
2. Revisa `03-migration-plan.md` — empieza por la **Fase 1** (implementar Clean Architecture).
3. Consulta `06-phase1-implementation-guide.md` para la guía paso a paso con código de ejemplo.
4. Usa `02-modules-backend.md` como referencia al implementar cada Controller/Service.

### Para gestionar las tareas de implementación
1. Revisa `GITHUB_ISSUES_SUMMARY.md` para ver los 26 issues creados organizados en 5 Epics.
2. Ve a https://github.com/huanre94/omnipos-winforms-mvp/issues para ver el backlog.
3. Filtra por milestone "Fase 1 - Clean Architecture + API REST".
4. Asígnate los issues que vas a trabajar: `gh issue edit [ISSUE_NUMBER] --add-assignee @me`

### Para implementar el frontend
1. Elige la tecnología en `01-architecture.md` (sección "Fase 2").
2. Abre `04-screen-prompts.md` y usa el prompt de cada pantalla en tu asistente IA.
3. Ajusta la tecnología en el prompt según tu elección.

### Para entender la estructura de código
1. Consulta `05-project-structure.md` para saber dónde va cada archivo.

### Scripts disponibles
- `scripts/create-github-issues-v2.ps1` — Regenerar labels e issues si es necesario
