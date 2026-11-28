# EnvDoctor

**El médico de los entornos de desarrollo.**

EnvDoctor es una herramienta que diagnostica problemas de configuración en proyectos de software. Ayuda a identificar por qué un proyecto no compila, no inicia o se comporta distinto entre computadoras, sin revisar manualmente versiones, variables de entorno, dependencias y servicios.

Al seleccionar la carpeta de un proyecto, EnvDoctor ejecuta comprobaciones controladas y genera un informe priorizado con evidencia, posibles causas y pasos de solución. Combina reglas deterministas, que verifican hechos concretos, con un asistente de IA que ayuda a interpretarlos.

## Funcionalidades principales

- **Escaneo del proyecto:** identifica archivos como `.csproj`, `.sln`, `package.json`, `requirements.txt`, `pyproject.toml`, `Dockerfile` y `docker-compose.yml`.
- **Validación de dependencias:** compara las dependencias declaradas con los archivos de bloqueo o metadatos y señala inconsistencias.
- **Informe de salud:** agrupa los hallazgos por gravedad e indica qué se detectó, dónde y qué impacto podría tener.
- **Asistente con IA:** responde preguntas sobre los hallazgos, con referencias a su origen.

## Seguridad y privacidad

- No ejecuta el código del repositorio ni sus scripts de instalación.
- Solo lee dentro de la carpeta seleccionada.
- Excluye por defecto archivos sensibles (`.env`, claves, certificados, tokens) del contenido enviado a la IA.
- Pide consentimiento antes de enviar datos a un proveedor externo de IA.

> Proyecto académico de Ingeniería de Software, desarrollado por un equipo de 3 integrantes.
