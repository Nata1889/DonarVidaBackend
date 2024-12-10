namespace BackendFinal.Models
{
    public class ProgramaDonacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFin { get; set; }
        public int CentroDonacionId { get; set; }
        public CentroDonacion? CentroDonacion { get; set; }
        public string TipoSangreSolicitada { get; set; }
    }
}
