namespace web_avanzada_fe.Entities
{
    public class Empleado
    {
       
            public string idEmpleado { get; set; } = string.Empty;
            public string Contrasenna { get; set; } = string.Empty;
            public string NombreE { get; set; } = string.Empty;
            public string ApellidosE { get; set; } = string.Empty;
            public int idRol { get; set; } = 0;
            public string Correo { get; set; } = string.Empty;
            public string Token { get; set; } = string.Empty;
        
    }
}
