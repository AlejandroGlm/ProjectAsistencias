using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAsistencia.Controllers;
using ApiAsistencia.Entity;


namespace ApiAsistencia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersAsistController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersAsistController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Usuarios user)
        {
            if (user == null)
            {
                return BadRequest("Invalid user data.");
            }

            var existingUser = await _context.Usuarios.FirstOrDefaultAsync(u => u.email == user.email);
            if (existingUser != null)
            {
                return Conflict("User with this email already exists.");
            }

            _context.Usuarios.Add(user);
            await _context.SaveChangesAsync();

            var userResponse = new UserResponse
            {
                nombre = user.nombre,
                email = user.email,
                password = user.password,
                rol = user.rol
            };

            return CreatedAtAction(nameof(GetUserById), new { id = user.id_Usuario }, userResponse);
        }


         [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _context.Usuarios.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }


        [HttpGet]
        [Route("AsistenciasConNombres")]
        public async Task<ActionResult<IEnumerable<object>>> GetAsistenciasConNombres()
        {
            var asistencias = await _context.Asist_Usuarios
                .Include(a => a.Usuario)
                .Select(a => new
                {
                    a.Id_Asistencia_Us,
                    a.Check_Entrada,
                    a.Check_Salida,
                    UsuarioNombre = a.Usuario.nombre 
                })
                .ToListAsync();

            return Ok(asistencias);
        }
         
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.email) || string.IsNullOrEmpty(loginRequest.password))
            {
                return BadRequest("Invalid client request");
            }

            var user = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.email == loginRequest.email && u.password == loginRequest.password);

            if (user == null)
            {
                return Unauthorized("Usuario o contraseña incorrectos");
            }

            var asistencia = await _context.Asist_Usuarios
                .Where(a => a.Id_Usuario == user.id_Usuario && a.Check_Salida == null)
                .OrderByDescending(a => a.Check_Entrada)
                .FirstOrDefaultAsync();

            if (asistencia != null)
            {
                 asistencia.Check_Salida = DateTime.Now;
                _context.Asist_Usuarios.Update(asistencia);
                await _context.SaveChangesAsync();
            }
            else
            {
                 var nuevaAsistencia = new Asist_Usuarios
                {
                    Id_Usuario = user.id_Usuario,
                    Check_Entrada = DateTime.Now
                };

                _context.Asist_Usuarios.Add(nuevaAsistencia);
                await _context.SaveChangesAsync();
            }

            var response = new LoginResponse
            {
                Id_Usuario = user.id_Usuario,
                nombre = user.nombre,
                email = user.email,
                rol = user.rol
            };

            return Ok(response);
        }
    }
}