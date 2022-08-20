namespace web_avanzada_fe.Entities
{
    public class Bitacora
    {

        public int codigoError { get; set; }
        public string descripcionError { get; set; } = string.Empty;
        public string origen { get; set; } = string.Empty;
        public DateTime fechaBitarora { get; set; }
        public int idEmpleado { get; set; }

    }
}
