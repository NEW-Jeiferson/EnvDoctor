# Entorno de desarrollo

**Responsable:** A  
**Versión:** 0.1  
**Fecha:** 2026-11-27

## Requisitos

| Herramienta | Versión | Para qué |
|---|---|---|
| .NET SDK | 10 | CLI y API |
| Node.js | 26 | TypeScript |
| Docker con Compose | reciente | Web y base de datos |
| Git | reciente | Control de versiones |

## Instalación

    git clone https://github.com/NEW-Jeiferson/EnvDoctor.git
    cd EnvDoctor
    dotnet build EnvDoctor.sln

## Variables de entorno

| Nombre | Descripción |
|---|---|
| POSTGRES_PASSWORD | Contraseña local de la base de datos. No se sube al repositorio |

## Ejecución local

Escáner:

    dotnet run --project feature-infraestructura/clases -- RUTA_DEL_PROYECTO

Pruebas:

    dotnet test feature-infraestructura/pruebas

Web (puerto 8080) y base de datos, en PowerShell:

    $env:POSTGRES_PASSWORD = "elige-una"
    docker compose -f feature-infraestructura/docker/docker-compose.yml up --build

## Problemas frecuentes

| Síntoma | Solución |
|---|---|
| "Define POSTGRES_PASSWORD" | Definir la variable antes de levantar Compose |
| El puerto 8080 está ocupado | Cerrar el proceso o cambiar el puerto en el compose |
