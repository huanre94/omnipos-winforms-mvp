# Git Flow Status Script for OmniPOS
# Muestra el estado actual de las ramas y workflow

# Colores
$colors = @{
	Title = "Green"
	Subtitle = "Yellow"
	Info = "Cyan"
	Success = "Gray"
	Warning = "Magenta"
	Link = "Blue"
}

function Show-Header {
	Write-Host "`n========================================" -ForegroundColor $colors.Title
	Write-Host "      OMNIPOS - GIT FLOW STATUS        " -ForegroundColor $colors.Title
	Write-Host "========================================`n" -ForegroundColor $colors.Title
}

function Show-Repository {
	Write-Host "📦 Repositorio:" -ForegroundColor $colors.Subtitle
	$repoName = (Get-Item -Path $PWD).Name
	Write-Host "  $repoName`n" -ForegroundColor $colors.Info
}

function Show-CurrentBranch {
	Write-Host "✅ Rama Actual:" -ForegroundColor $colors.Subtitle
	$currentBranch = git branch --show-current
	Write-Host "  $currentBranch`n" -ForegroundColor $colors.Info
}

function Show-AllBranches {
	Write-Host "🌳 Todas las Ramas:" -ForegroundColor $colors.Subtitle

	Write-Host "`n  Locales:" -ForegroundColor $colors.Info
	git branch | ForEach-Object {
		$branch = $_.Trim()
		if ($branch -match '^\*') {
			Write-Host "    $branch (actual)" -ForegroundColor Green
		} else {
			Write-Host "    $branch" -ForegroundColor $colors.Success
		}
	}

	Write-Host "`n  Remotas:" -ForegroundColor $colors.Info
	git branch -r | Where-Object { $_ -notmatch 'HEAD' } | ForEach-Object {
		Write-Host "    $_" -ForegroundColor $colors.Success
	}
	Write-Host ""
}

function Show-RecentCommits {
	Write-Host "📊 Últimos 7 Commits:" -ForegroundColor $colors.Subtitle
	git log --oneline --graph --all --decorate -7 | ForEach-Object {
		Write-Host "  $_" -ForegroundColor $colors.Success
	}
	Write-Host ""
}

function Show-Status {
	Write-Host "📝 Estado del Working Directory:" -ForegroundColor $colors.Subtitle

	$status = git status --short
	if ($status) {
		$status | ForEach-Object {
			Write-Host "  $_" -ForegroundColor Yellow
		}
	} else {
		Write-Host "  ✓ Limpio - no hay cambios sin commitear" -ForegroundColor Green
	}
	Write-Host ""
}

function Show-BranchComparison {
	Write-Host "🔍 Comparación de Ramas:" -ForegroundColor $colors.Subtitle

	# develop vs master
	$devAheadMaster = git rev-list --count master..develop 2>$null
	$devBehindMaster = git rev-list --count develop..master 2>$null

	if ($devAheadMaster -or $devBehindMaster) {
		Write-Host "  develop vs master:" -ForegroundColor $colors.Info
		Write-Host "    ↑ $devAheadMaster commits adelante" -ForegroundColor Green
		Write-Host "    ↓ $devBehindMaster commits atrás" -ForegroundColor Yellow
	}

	Write-Host ""
}

function Show-Documentation {
	Write-Host "📚 Documentación Disponible:" -ForegroundColor $colors.Subtitle

	$docs = @(
		"docs/README.md",
		"docs/BRANCHING_STRATEGY.md",
		"docs/GIT_FLOW_QUICK_GUIDE.md",
		"docs/BRANCH_SETUP_SUMMARY.md",
		"docs/DOCKER_GUIDE.md"
	)

	foreach ($doc in $docs) {
		if (Test-Path $doc) {
			Write-Host "  ✓ $doc" -ForegroundColor $colors.Success
		} else {
			Write-Host "  ✗ $doc (no encontrado)" -ForegroundColor Red
		}
	}
	Write-Host ""
}

function Show-QuickCommands {
	Write-Host "🚀 Comandos Rápidos:" -ForegroundColor $colors.Subtitle

	$commands = @(
		@{Command = "git checkout develop"; Description = "Cambiar a rama develop"},
		@{Command = "git checkout -b feature/nombre"; Description = "Crear nueva feature"},
		@{Command = "git status"; Description = "Ver estado actual"},
		@{Command = "git log --oneline -10"; Description = "Ver últimos 10 commits"},
		@{Command = "git pull origin develop"; Description = "Actualizar develop"},
		@{Command = "git push"; Description = "Push de cambios"}
	)

	foreach ($cmd in $commands) {
		Write-Host "  $($cmd.Command)" -ForegroundColor $colors.Info
		Write-Host "    → $($cmd.Description)" -ForegroundColor $colors.Success
	}
	Write-Host ""
}

function Show-Links {
	Write-Host "🔗 Enlaces Útiles:" -ForegroundColor $colors.Subtitle

	$links = @(
		@{Name = "Repositorio"; Url = "https://github.com/huanre94/omnipos-winforms-mvp"},
		@{Name = "Issues"; Url = "https://github.com/huanre94/omnipos-winforms-mvp/issues"},
		@{Name = "Pull Requests"; Url = "https://github.com/huanre94/omnipos-winforms-mvp/pulls"},
		@{Name = "Branch Protection"; Url = "https://github.com/huanre94/omnipos-winforms-mvp/settings/branches"}
	)

	foreach ($link in $links) {
		Write-Host "  $($link.Name): " -NoNewline -ForegroundColor $colors.Info
		Write-Host "$($link.Url)" -ForegroundColor $colors.Link
	}
	Write-Host ""
}

function Show-NextSteps {
	Write-Host "📋 Próximos Pasos Sugeridos:" -ForegroundColor $colors.Warning

	$currentBranch = git branch --show-current

	if ($currentBranch -eq "develop") {
		Write-Host "  1. git checkout -b feature/nombre-funcionalidad" -ForegroundColor White
		Write-Host "  2. Desarrollar tu feature" -ForegroundColor White
		Write-Host "  3. git add . && git commit -m 'feat: descripción'" -ForegroundColor White
		Write-Host "  4. git push -u origin feature/nombre-funcionalidad" -ForegroundColor White
		Write-Host "  5. Crear Pull Request en GitHub" -ForegroundColor White
	} elseif ($currentBranch -match "^feature/") {
		Write-Host "  1. git add . && git commit -m 'feat: descripción'" -ForegroundColor White
		Write-Host "  2. git push" -ForegroundColor White
		Write-Host "  3. Cuando termines: crear Pull Request en GitHub" -ForegroundColor White
	} else {
		Write-Host "  1. git checkout develop" -ForegroundColor White
		Write-Host "  2. git pull origin develop" -ForegroundColor White
		Write-Host "  3. git checkout -b feature/nombre-funcionalidad" -ForegroundColor White
	}

	Write-Host ""
}

# Main execution
try {
	# Verificar que estamos en un repositorio Git
	$gitCheck = git rev-parse --is-inside-work-tree 2>$null

	if ($gitCheck -ne "true") {
		Write-Host "❌ Error: No estás en un repositorio Git" -ForegroundColor Red
		exit 1
	}

	# Mostrar toda la información
	Show-Header
	Show-Repository
	Show-CurrentBranch
	Show-Status
	Show-AllBranches
	Show-RecentCommits
	Show-BranchComparison
	Show-Documentation
	Show-QuickCommands
	Show-Links
	Show-NextSteps

	Write-Host "========================================`n" -ForegroundColor $colors.Title

} catch {
	Write-Host "❌ Error: $_" -ForegroundColor Red
	exit 1
}
