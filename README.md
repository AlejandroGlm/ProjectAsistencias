# Project Asistencia

Project Asistencia es una aplicación para gestionar asistencias de usuarios. Este proyecto consiste de dos proyectos: la API (`ApiAsistencia`) y la aplicación cliente (`ProjectAsistencia`).
Esta aplicación fue desarrollada en MAUI Net 9

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

### Para iniciar sesión
Ir a la sección login.
Usuario: Juan123
Password: admin123

se mostrara el panel de control y el historial por turnos.

![image](https://github.com/user-attachments/assets/6060afb6-d5fc-4826-9537-03a99753754e)

Al iniciar el turno el reloj comienza a correr.

![image](https://github.com/user-attachments/assets/5f797285-b735-45fc-bd7d-9cb8eb62af9b)

Al finalizar el turno, el tiempo se queda registrado.



## 👨‍💻 Autor

**Osvaldo Gaspar**  
GitHub: [@AlejandroGlm](https://github.com/AlejandroGlm)



