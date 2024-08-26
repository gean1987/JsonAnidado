namespace WebApplication1.Models
{
    public class Secciones
    {
        public int idSeccion { get; set; }
        public int AulaId { get; set; }
        public int CursoId { get; set; }
        public string Turno { get; set; }
        public TimeSpan? Horainicio { get; set; }
        public TimeSpan? HoraFin { get; set; }
    }
}
