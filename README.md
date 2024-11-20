# GestionCitasMicroservicios
# Gestión de Citas - Microservicios

Este repositorio contiene tres microservicios (`Personas`, `Citas`, `Recetas`) y los scripts para la creación de las bases de datos correspondientes.

## Estructura del Proyecto

La estructura de cada solucion se realiza de la siguiente forma

├── GestionCitas.Personas.API              // Proyecto principal para la API
├── GestionCitas.Personas.Dominio           // Proyecto para la lógica y reglas del dominio
├── GestionCitas.Personas.Infraestructura    // Proyecto para acceso a datos (EntityFramework) y servicios externos

├── GestionCitas.Citas.API              // Proyecto principal para la API
├── GestionCitas.Citas.Dominio           // Proyecto para la lógica y reglas del dominio
├── GestionCitas.Citas.Infraestructura    // Proyecto para acceso a datos (EntityFramework) y servicios externos

├── GestionCitas.Recetas.API              // Proyecto principal para la API
├── GestionCitas.Recetas.Dominio           // Proyecto para la lógica y reglas del dominio
├── GestionCitas.Recetas.Infraestructura    // Proyecto para acceso a datos (EntityFramework) y servicios externos

## Tecnologías utilizadas
Lenguaje: C#
Framework: .Net Framework 4.8
Base de Datos: SQL Server 
Versionado: Git
IDE: Visual Studio 2022

# Prerrequisitos
.Net Framework 4.8
SQL Server (puedes utilizar SQL Server Express) 
Visual Studio 2022 o Visual Studio Code.
Git instalado.

# Pasos para la instalacion
1. Clonar el repositorio
   https://github.com/Cypher850413/GestionCitasMicroservicios.git
2. Asegúrate de tener una instancia de SQL Server en ejecución. Sigue estos pasos para configurar la conexión:

Actualiza la cadena de conexión en appsettings.json para que coincida con tu entorno de base de datos. La configuración debería verse así:

"ConnectionStrings": {
  "DefaultConnection": "Server=TU_SERVIDOR;Database=TU_BASE_DE_DATOS;User Id=USUARIO;Password=CONTRASEÑA;"
}
3.Ejecutar los scripts de base de datos de la carpeta BaseDatos en esta se encuentran en orden de ejcución siendo el primer script la creacion de las tres bases de datos y lo siguientes scripts son las tablas que se manejan en cada una
