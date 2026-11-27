# Ramas y restricciones

## Ramas
| Rama | Sale de | Entra a | Uso |
|---|---|---|---|
| main | - | - | Versión estable, una etiqueta por fase |
| develop | main | main | Integración del equipo |
| feature/infraestructura | develop | develop | Trabajo de A |
| feature/backend | develop | develop | Trabajo de B |
| feature/frontend | develop | develop | Trabajo de C |
| docs/nombre | develop | develop | Solo documentación |
| hotfix/nombre | main | main y luego develop | Corrección urgente |

## Restricciones
| Regla | main | develop |
|---|---|---|
| Cambios solo por pull request | Sí | Sí |
| Aprobaciones | 2 | 1 |
| Anular aprobación si hay cambios nuevos | Sí | Sí |
| Resolver todas las conversaciones | Sí | Sí |
| Prohibido push forzado y borrado | Sí | Sí |
| CI en verde (paso 5) | Sí | Sí |

Además, solo se pueden crear ramas con los nombres de la tabla (y las de Dependabot).

## Antes de empezar
Los rulesets funcionan en repositorios **públicos** con GitHub Free. Para un repositorio **privado** se necesita GitHub Pro, Team o Enterprise.

## Paso 1: crear el repositorio (A)
Crear el repositorio en GitHub, agregar a B y C en Settings > Collaborators y subir el primer commit a main:

    git init -b main
    git add .
    git commit -m "chore: estructura inicial"
    git remote add origin URL_DEL_REPOSITORIO
    git push -u origin main

## Paso 2: crear develop (A)

    git switch -c develop
    git push -u origin develop

Luego en Settings > General > Default branch, elegir develop.

## Paso 3: importar las reglas (A, administrador)
1. Settings > Rules > Rulesets.
2. New ruleset > Import a ruleset.
3. Subir proteger-main.json y pulsar Create.
4. Repetir con proteger-develop.json y nombres-de-ramas.json.
5. Confirmar que los tres estén en estado Active y con la lista de bypass vacía.

## Paso 4: comprobar que funcionan
- `git push origin develop` con un commit directo: debe ser rechazado.
- `git push origin HEAD:prueba`: debe ser rechazado por el nombre.
- Abrir un PR sin aprobación: no debe permitir el merge.

Guarden capturas como evidencia.

## Paso 5: exigir el CI (después de que A cree el workflow)
Ejecutar el workflow al menos una vez. Después editar proteger-main y proteger-develop, activar **Require status checks to pass** y agregar los jobs (sugeridos: build-dotnet y build-frontend).

## Flujo diario

    git switch develop
    git pull
    git switch -c feature/infraestructura   # o backend / frontend
    # trabajar
    git add .
    git commit -m "feat: descripcion corta"
    git push -u origin feature/infraestructura

Abrir el PR hacia develop. Al cierre de cada fase, abrir un PR de develop a main (usar merge commit) y etiquetar:

    git switch main
    git pull
    git tag v0.1.0
    git push origin v0.1.0

Mensajes de commit: feat, fix, docs, test, ci, chore.
