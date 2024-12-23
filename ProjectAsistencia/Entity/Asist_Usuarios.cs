using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAsistencia.Entity
{
    public class Asist_Usuarios
    {
        public DateTime check_entrada { get; set; }
        public DateTime? check_salida { get; set; }

        public string UsuarioNombre { get; set; }
    }
}
