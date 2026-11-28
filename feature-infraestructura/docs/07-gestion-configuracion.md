# Plan de gestión de la configuración

**Responsable:** A (con todos)  
**Versión:** 0.1  
**Fecha:** 2026-11-27

## Elementos de configuración

| Elemento | Ubicación | Responsable |
|---|---|---|
| CLI y reglas | feature-infraestructura/ | A |
| API y datos | feature-backend/ | B |
| Interfaz | feature-frontend/ | C |
| Workflows | .github/workflows/ | A |
| Docker | feature-infraestructura/docker/ y Dockerfile de cada parte | A |
| Documentos y RFC | docs/ y docs/ de cada parte | Todos |

## Organización de carpetas

| Carpeta | Contenido |
|---|---|
| feature-infraestructura/ | src/, tests/, docker/, docs/ y ramas/ |
| feature-backend/ | src/ (Controllers, Services, Data, Ai, Security) y docs/ |
| feature-frontend/ | index.html, styles.css, src/ (api, components), Dockerfile y docs/ |

## Estrategia de ramas

main (estable), develop (integración) y feature/*. Detalle en feature-infraestructura/ramas/GUIA_RAMAS.md.

## Versionado

Etiquetas vX.Y.Z: v0.1.0, v0.2.0 y v1.0.0 al cierre de cada fase.

## Control de cambios

1. Copiar docs/rfc/RFC-000-plantilla.md como RFC-NNN-nombre.md.
2. Incluir el RFC en el pull request del cambio.
3. Revisión en el pull request: develop exige 1 aprobación y main 2, con CI en verde.
4. Registrar la decisión en la sección de aprobaciones y cerrar el RFC al unir.

## Líneas base

La etiqueta de cada fase en main.

## Auditoría

Al cierre de cada fase: comparar los RFC cerrados con el historial de pull requests y las ejecuciones de CI.
