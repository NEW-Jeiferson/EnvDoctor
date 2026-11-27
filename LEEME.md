# EnvDoctor: paquete inicial

- EnvDoctor_Tareas_ABC.pdf: qué hace cada persona en las 3 fases.
- feature-infraestructura/ (A): clases del escáner, docs y ramas.
- feature-backend/ (B): clases y docs.
- feature-frontend/ (C): HTML, CSS, TypeScript y docs.
- docs/: plantillas compartidas.

No hay proyectos ni arquitectura creados: cada quien arma los suyos.

## Solución
EnvDoctor.sln muestra las carpetas como elementos de solución (no se compilan). Al crear cada proyecto:

    dotnet sln EnvDoctor.sln add RUTA/Proyecto.csproj

Al mover una clase a su proyecto, quiten su entrada de la solución.
