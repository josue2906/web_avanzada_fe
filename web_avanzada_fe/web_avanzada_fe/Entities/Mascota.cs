namespace web_avanzada_fe.Entities
{
    public class Mascota
    {
        public int IdMascota { get; set; }
        public string NombreM { get; set; } = string.Empty;
        public decimal Peso { get; set; }
        public string Raza { get; set; } = string.Empty;
        public string FechaNacimiento { get; set; } = String.Empty; 
        public int idDueno { get; set; }
    }
}
