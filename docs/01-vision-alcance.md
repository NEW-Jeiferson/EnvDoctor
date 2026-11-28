# Visión y alcance

**Responsable:** Todos  
**Versión:** 0.1  
**Fecha:** 2026-11-27

**Estado:** borrador de A a partir de la propuesta; falta revisión de B y C.

## Problema

Un proyecto funciona en una computadora y falla en otra por diferencias de versiones, dependencias, variables, puertos o servicios.

## Objetivos

- Detectar los archivos de configuración de un proyecto sin ejecutar su código.
- Entregar hallazgos priorizados con evidencia y recomendación.
- Explicar los hallazgos con ayuda de IA, con consentimiento del usuario.

## Dentro del alcance

Escaneo local, reglas deterministas para .NET y Node.js, informe web y asistente con IA.

## Fuera del alcance

Reparaciones automáticas, ejecución de scripts del proyecto analizado y reglas para Python en la primera versión.

## Criterios de éxito

Las comprobaciones se demuestran en vivo sobre proyectos con fallos intencionales y no se envían secretos a la IA.
