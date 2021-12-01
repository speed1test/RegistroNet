using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Data.SqlClient;

namespace Db.Models
{
    public class BaseDeDatos
    {
        public static int GuardarAlumno(AlumnoModel alumno)
        {
            SqlConnection con = new SqlConnection(GetConString.ConString());
            // string query = "INSERT INTO ALM_ALUMNO(alm_codigo, alm_nombre, alm_edad, alm_sexo, alm_id_grd, alm_observacion) values ('" + alm_codigo + "','" + alm_nombre + "','" + alm_edad + "','" + alm_sexo + "','" + alm_id_grd + "','" + alm_observacion + "')";
            string query = "INSERT INTO ALM_ALUMNO(alm_codigo, alm_nombre, alm_edad, alm_sexo, alm_observacion) values ('" + alumno.alm_codigo + "','" + alumno.alm_nombre + "','" + alumno.alm_edad + "','" + alumno.alm_sexo + "','" + alumno.alm_observacion + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public static List<AlumnoModel> VerAlumnos()
        {
            List<AlumnoModel> alumnos = new List<AlumnoModel>(){};
            SqlConnection con = new SqlConnection(GetConString.ConString());
            string query = "SELECT [ALM_ID], [ALM_ID_GRD], [ALM_CODIGO], [ALM_NOMBRE], [ALM_EDAD], [ALM_SEXO], [ALM_OBSERVACION] FROM [Registro].[dbo].[ALM_ALUMNO];";
            SqlCommand comando = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                AlumnoModel alumno = new AlumnoModel();
                alumno.alm_id = reader.GetInt32(0);
                alumno.alm_codigo = reader.GetString(2);
                alumno.alm_nombre = reader.GetString(3);
                alumno.alm_edad = reader.GetInt32(4);
                alumno.alm_sexo = reader.GetString(5);
                alumno.alm_id_grd = 1;
                alumno.alm_observacion = reader.GetString(6);
                alumnos.Add(alumno);
            }
            return alumnos;
        }
        public static int EliminarAlumno(int idAlumno)
        {
            SqlConnection con = new SqlConnection(GetConString.ConString());
            string query = "DELETE FROM ALM_ALUMNO WHERE ALM_ID = "+idAlumno+";";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
    public static class GetConString
    {
        public static string ConString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var config = builder.Build();
            string constring = config.GetConnectionString("DefaultConnection");
            return constring;
        }
    }
}