namespace WebApplication1.Models
{
    public class Matricula
    {
        public int idMatricula { get; set; }
        public int idCurso { get; set; }
        public int idAlumno { get; set; }
        public int idSeccion { get; set; }
       
        public List<Alumno> alumnos { get; set; }
        public List<Cursos> cursos { get; set; }
        public List<Secciones> secciones { get; set; }
        public DateTime fechaMatricula { get; set; }
    }
}
