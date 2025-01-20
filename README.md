# TaskManagement API

**TaskManagement API** es un sistema para gestionar tareas y estados utilizando .NET Core y Entity Framework Core con una arquitectura modular y escalable. Este proyecto incluye soporte para operaciones CRUD sobre tareas y estados, con relaciones definidas en la base de datos.

---

## **Características Principales**
- Gestión de tareas con propiedades como descripción, fecha límite y estado.
- Relación entre tareas y estados (uno a muchos).
- Arquitectura modular con controladores, servicios y repositorios.
- Soporte para operaciones CRUD.

---

## **Requisitos Previos**
Asegúrate de tener las siguientes herramientas instaladas antes de comenzar:

1. **.NET SDK** (7.0 o superior) - [Descargar aquí](https://dotnet.microsoft.com/download)
2. **SQL Server** (local o en la nube) - [Descargar aquí](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
3. **Entity Framework Core Tools** - Incluido en las dependencias.
4. **Un editor o IDE**:
   - Visual Studio (Recomendado)
   - Visual Studio Code

---

## **Dependencias**

El proyecto requiere las siguientes dependencias NuGet. Estas se instalarán automáticamente si están definidas en el archivo `.csproj`. Si deseas instalarlas manualmente, usa los comandos de `dotnet add package`.

### **Dependencias de NuGet**
```bash
dotnet add package Microsoft.EntityFrameworkCore --version 7.0.0
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 7.0.0
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 7.0.0
dotnet add package Swashbuckle.AspNetCore --version 6.4.0
