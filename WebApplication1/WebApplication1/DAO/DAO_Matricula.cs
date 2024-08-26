
using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using WebApplication1.Models;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Net.Mail;
using WebApplication1.Datos;
namespace WebApplication1.DAO
{
    public class DAO_Matricula
    {
        private readonly ConexionDB cn = new ConexionDB();

        readonly string _cadena;

        public DAO_Matricula()
        {
            _cadena = cn.getCadenaSQL();
        }

        public IEnumerable<Matricula> ListarMatriculas()
        {
            List<Matricula> matriculas = new List<Matricula>();

            using (var con = new SqlConnection(_cadena))
            {
                SqlCommand cmd = new SqlCommand("SELECT*FROM matriculas", con);
                cmd.CommandType = CommandType.Text;

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int idMatricula = dr.GetInt32(0);

                    Matricula matricula = new Matricula()
                    {
                        idMatricula = dr.GetInt32(0),
                        idAlumno = dr.GetInt32(1),
                        idCurso = dr.GetInt32(2),
                        idSeccion = dr.GetInt32(3),
                        fechaMatricula = dr.GetDateTime(4),
                    };

                    matriculas.Add(matricula);
                }
                dr.Close();
            }

            return matriculas;
        }

        // Método para obtener los alumnos por matrícula
        public IEnumerable<Alumno> ListarAlumnos(int idMatricula)
        {
            List<Alumno> alumnos = new List<Alumno>();

            using (var con = new SqlConnection(_cadena))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Alumnos  WHERE id = @id", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", idMatricula);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Alumno alumno = new Alumno()
                    {
                        AlumnoId = dr.GetInt32(0),
                        nombre = dr.IsDBNull(1) ? "-" : dr.GetString(1),
                        apellido = dr.IsDBNull(2) ? "-" : dr.GetString(2),
                        correo = dr.IsDBNull(3) ? "-" : dr.GetString(3),
                    };
                    alumnos.Add(alumno);
                }
                dr.Close();
            }

            return alumnos;
        }
        //metodo de secciones
        public IEnumerable<Secciones> ListarSecciones(int idMatricula)
        {
            List<Secciones> alumnos = new List<Secciones>();

            using (var con = new SqlConnection(_cadena))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM secciones  WHERE id = @id", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", idMatricula);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Secciones alumno = new Secciones()
                    {
                        idSeccion = dr.GetInt32(0),
                        AulaId = dr.GetInt32(1),
                        CursoId = dr.GetInt32(2),
                        Turno = dr.IsDBNull(3) ? "-" : dr.GetString(3),
                        Horainicio = dr.IsDBNull(4) ? (TimeSpan?)null : dr.GetTimeSpan(4),
                        HoraFin = dr.IsDBNull(5) ? (TimeSpan?)null : dr.GetTimeSpan(5),
                    };
                    alumnos.Add(alumno);
                }
                dr.Close();
            }

            return alumnos;
        }

        public IEnumerable<Cursos> ListarCursos(int idMatricula)
        {
            List<Cursos> alumnos = new List<Cursos>();

            using (var con = new SqlConnection(_cadena))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM cursos  WHERE id = @id", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", idMatricula);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Cursos alumno = new Cursos()
                    {
                        idCurso = dr.GetInt32(0),
                        Nombre = dr.IsDBNull(1) ? "-" : dr.GetString(1),
                       
                    };
                    alumnos.Add(alumno);
                }
                dr.Close();
            }

            return alumnos;
        }


    }
}
