# RFC-001: base de infraestructura (Fase 1)

## 1. Identificación

| Campo | Valor |
|---|---|
| ID | RFC-001 |
| Solicitante | NEW-Jeiferson (A) |
| Fecha | 2026-11-27 |
| Tipo | Normal |
| Prioridad | Alta |
| Estado | En revisión |
| Fase | 1 |
| Rama y pull request | feature/infraestructura hacia develop |

## 2. Descripción del cambio

Crear la aplicación de consola que detecta archivos de configuración sin salir de la carpeta elegida, sus pruebas, el Docker inicial, el modelo de RFC, la propuesta de contrato del informe y los documentos de entorno y gestión de la configuración.

## 3. Justificación

Es la base de la que dependen el backend (formato del informe) y el frontend (cómo mostrarlo), según el reparto de la Fase 1.

## 4. Elementos de configuración afectados

| Elemento | Ruta | Acción |
|---|---|---|
| CLI del escáner | feature-infraestructura/clases | Modificar y crear |
| Pruebas | feature-infraestructura/pruebas | Crear |
| Solución | EnvDoctor.sln | Modificar |
| Compose | feature-infraestructura/docker | Crear |
| Imagen web | feature-frontend/Dockerfile | Crear |
| Documentos | docs y feature-infraestructura/docs | Crear y modificar |

## 5. Análisis de impacto

| Aspecto | Impacto |
|---|---|
| Alcance | Corresponde a la Fase 1; no incluye reglas de versiones, puertos ni Docker (Fase 2) |
| Cronograma | Sin cambios |
| Otros integrantes | B debe revisar el contrato; C tiene un Dockerfile nuevo en su carpeta |
| Seguridad | Solo se leen nombres de archivos; no se ejecuta código del proyecto analizado |

## 6. Riesgos

| Riesgo | Probabilidad | Impacto | Mitigación |
|---|---|---|---|
| El contrato cambie al revisarlo B | Media | Medio | Versionado del esquema (0.1) |
| Lectura fuera de la carpeta por enlaces | Baja | Alto | PathGuard y prueba específica |
| El servicio de API aún no existe | Alta | Bajo | Compose solo con web y base de datos |

## 7. Plan de implementación

1. Subir los cambios a feature/infraestructura.
2. Abrir un pull request hacia develop.
3. Revisión de un compañero y CI en verde.

## 8. Plan de pruebas y criterios de aceptación

- build-dotnet compila y ejecuta las pruebas.
- build-frontend pasa.
- El CLI devuelve un informe JSON conforme al contrato.
- No se listan archivos fuera de la carpeta elegida.

## 9. Plan de reversión

Revertir el pull request con un nuevo pull request (git revert). No hay datos ni despliegues que restaurar.

## 10. Aprobaciones

| Integrante | Rol | Decisión | Fecha | Comentarios |
|---|---|---|---|---|
| | A | Solicitante | 2026-11-27 | |
| | B | Pendiente | | |
| | C | Pendiente | | |

## 11. Cierre

| Campo | Valor |
|---|---|
| Fecha de implementación | Pendiente |
| Resultado | Pendiente |
| Versión o etiqueta | v0.1.0 |
