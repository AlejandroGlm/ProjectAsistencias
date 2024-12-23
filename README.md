# Project Asistencia

Project Asistencia es una aplicación para gestionar asistencias de usuarios. Este proyecto consiste de dos proyectos: la API (`ApiAsistencia`) y la aplicación cliente (`ProjectAsistencia`).

## Configuración del Proyecto

### Modificar el Servidor en `appsettings.json`

Para configurar la conexión a la base de datos en el proyecto `ApiAsistencia`, es necesario modificar el archivo `appsettings.json`. Actualizar la cadena de conexión `DefaultConnection` con el nombre de tu servidor.

#### Ubicación del archivo

`ApiAsistencia/appsettings.json`

#### Ejemplo de Configuración

```json
{
    "ConnectionStrings": {
        "DefaultConnection": "Server=DESKTOP-M8JNN75;Database=Asistencias;Trusted_Connection=True;TrustServerCertificate=True;"
    },
    "Logging": {
        "LogLevel": {
            "Default": "Information",
            "Microsoft.AspNetCore": "Warning"
        }
    },
    "AllowedHosts": "*"
}
```
Server: Cambia DESKTOP-M8JNN75 por el nombre de tu servidor SQL.
Database: El nombre de la base de datos debe ser Asistencias.

### Modificar la URL Base de la API
En el proyecto ProjectAsistencia, es posible que se necesite modificar la URL base de la API para que apunte a la dirección correcta. Esto se hace en el archivo UsersServices.cs.

#### Ubicación del archivo
ProjectAsistencia/Services/UsersServices.cs

```
public class UsersServices
    {
        private readonly HttpClient _httpClient;

        // Modificar si es necesario, para manejar la URL de la API
        private const string BaseUrl = "https://localhost:44341/api/UsersAsist";

        public UsersServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
```


