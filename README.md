# ProjectCoreAI

Esempio di progetto **ASP.NET Core MVC** in C# con approccio **DB-First** e integrazione Bootstrap + DataTables.

## Struttura

- `ProjectCoreAI`: progetto web MVC.
- `Data/ApplicationDbContext.cs`: DbContext (pronto per uso DB-First).
- `Models/Database`: classi entità (placeholder, sovrascrivibili via scaffold).
- `Controllers/BootstrapComponentController.cs`: action `Paginazione` con dati demo.
- `Views/BootstrapComponent/Paginazione.cshtml`: DataTable con paginazione a 20 record.

## Avvio

```bash
dotnet restore
dotnet run --project ProjectCoreAI
```

## Setup DB-First (Entity Framework Core)

1. Imposta la connection string in `ProjectCoreAI/appsettings.json`.
2. Esegui lo scaffold del modello dal database:

```bash
dotnet tool install --global dotnet-ef

dotnet ef dbcontext scaffold "<CONNECTION_STRING>" Microsoft.EntityFrameworkCore.SqlServer \
  --project ProjectCoreAI \
  --output-dir Models/Database \
  --context-dir Data \
  --context ApplicationDbContext \
  --use-database-names \
  --data-annotations \
  --force
```

## Scaffold CRUD (controller + view)

Per generare un controller MVC con viste CRUD usando il modello scaffoldato:

```bash
dotnet tool install --global dotnet-aspnet-codegenerator

dotnet aspnet-codegenerator controller \
  -name ProductsController \
  -m Product \
  -dc ApplicationDbContext \
  --relativeFolderPath Controllers \
  --useDefaultLayout \
  --referenceScriptLibraries \
  --project ProjectCoreAI
```

## Demo richiesta: BootstrapComponent/Paginazione

La pagina `BootstrapComponent/Paginazione` usa DataTables con:
- paginazione abilitata,
- `pageLength: 20`,
- dati demo (120 record) per testare il page switching.
