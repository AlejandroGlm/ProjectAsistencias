using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAsistencia.Entity
{
    [Table("Asist_Usuarios")]
    public class Asist_Usuarios
    {
        [Key]
        public int Id_Asistencia_Us { get; set; }  

        public int Id_Usuario { get; set; }
        public DateTime Check_Entrada { get; set; } = DateTime.Now;
        public DateTime? Check_Salida { get; set; }

        [ForeignKey("Id_Usuario")]
        public Usuarios Usuario { get; set; }
    }
}
