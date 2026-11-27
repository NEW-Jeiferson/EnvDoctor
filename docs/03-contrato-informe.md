# Contrato del informe (CLI, API y web)

**Responsable:** A y B (revisa C)  
**Versión:** 0.1  
**Fecha:** 2026-11-27

**Estado:** propuesta de A, pendiente de acuerdo con B.

## Formato

```json
{
  "schemaVersion": "0.1",
  "projectName": "mi-proyecto",
  "generatedAt": "2026-11-27T22:00:00+00:00",
  "files": [{ "path": "src/App.csproj", "type": "dotnet-project" }],
  "findings": [
    {
      "id": "SCAN001",
      "severity": "warning",
      "category": "escaneo",
      "message": "No se encontraron archivos de configuración compatibles.",
      "file": null,
      "recommendation": "Verifica que elegiste la carpeta raíz del proyecto."
    }
  ]
}
```

## Campos

| Campo | Tipo | Obligatorio | Descripción |
|---|---|---|---|
| schemaVersion | texto | Sí | Versión del contrato |
| projectName | texto | Sí | Nombre de la carpeta, sin la ruta completa |
| generatedAt | fecha ISO 8601 | Sí | Momento del análisis (UTC) |
| files[].path | texto | Sí | Ruta relativa con / |
| files[].type | texto | Sí | dotnet-project, dotnet-solution, dotnet-sdk, node, node-lock, python, dockerfile, compose |
| findings[].id | texto | Sí | Código de la regla |
| findings[].severity | texto | Sí | info, warning o error |
| findings[].category | texto | Sí | Área del hallazgo |
| findings[].message | texto | Sí | Qué se detectó |
| findings[].file | texto o null | No | Ruta relativa |
| findings[].recommendation | texto o null | No | Cómo resolverlo |

## Niveles de gravedad

- **info:** dato útil, sin acción obligatoria.
- **warning:** puede causar fallos.
- **error:** impide compilar o iniciar.

## Versionado

Todo cambio al contrato se solicita con un RFC y sube schemaVersion.
