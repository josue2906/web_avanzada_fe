using System.ComponentModel;

namespace web_avanzada_fe.Entities
{
    public class Mascota
    {
        [DisplayName("#")]
        public int IdMascota { get; set; }
        [DisplayName("Nombre")]
        public string NombreM { get; set; } = string.Empty;
        public decimal Peso { get; set; }
        public string Raza { get; set; } = string.Empty;
        [DisplayName("Nacimiento")]
        public string FechaNacimiento { get; set; } = String.Empty;
        [DisplayName("Dueño")]
        public int idDueno { get; set; }
    }
}
