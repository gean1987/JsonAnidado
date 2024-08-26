using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DAO;
using WebApplication1.Models;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    public class MatriculaController : Controller
    {
        private readonly DAO_Matricula gestionMatricula;

        public MatriculaController()
        {
            gestionMatricula = new DAO_Matricula();
        }

        [HttpGet]
        public IActionResult ListarMatriculasConAlumnos()
        {
            var matriculas = gestionMatricula.ListarMatriculas();

            foreach (var matricula in matriculas)
            {
                List<Alumno> alumnos = gestionMatricula.ListarAlumnos(matricula.idAlumno).ToList();
                matricula.alumnos = alumnos;

                List<Cursos> cursos = gestionMatricula.ListarCursos (matricula.idCurso).ToList();
                matricula.cursos = cursos;

                List<Secciones> secciones = gestionMatricula.ListarSecciones(matricula.idSeccion).ToList();
                matricula.secciones = secciones;
            }

            string jsonResultado = JsonConvert.SerializeObject(matriculas, Formatting.Indented);

            // Devolver el JSON
            return Content(jsonResultado, "application/json");
        }
    }
}
