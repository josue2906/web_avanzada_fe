namespace web_avanzada_fe.Entities
{
    public class Cita
    {
        public int idCita { get; set; }
        public int idMascota { get; set; }
        public string NombreM { get; set; } = string.Empty;
        public int idServicio { get; set; }
        public string DescripcionServicio { get; set; } = string.Empty;
        public string idEmpleado { get; set; } = string.Empty;
        public string Empleado { get; set; } = string.Empty;
        public DateTime FechaCita { get; set; }
        public bool Estado { get; set; }
        public decimal PrecioCita { get; set; }
    }
}
