# EnvDoctor: paquete inicial

- EnvDoctor_Tareas_ABC.pdf: qué hace cada persona en las 3 fases y cómo arrancan B y C.
- feature-infraestructura/ (A): src/, tests/, docker/, docs/ y ramas/.
- feature-backend/ (B): src/ y docs/.
- feature-frontend/ (C): index.html, styles.css, src/ y docs/.
- docs/: plantillas compartidas.

Cada integrante trabaja dentro de su carpeta. A ya tiene su proyecto (EnvDoctor.Cli) y sus pruebas; B crea el de la API y C configura TypeScript.

Compartido por todos: EnvDoctor.sln, docs/, .github/, .gitignore y este archivo.

## Solución
EnvDoctor.sln incluye los proyectos existentes. El resto de archivos aparecen como elementos de solución (no se compilan). Al crear un proyecto nuevo:

    dotnet sln EnvDoctor.sln add RUTA/Proyecto.csproj

Al mover una clase a su proyecto, quiten su entrada de la solución.
