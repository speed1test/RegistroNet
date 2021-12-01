
 
namespace Db.Models
{
    public class AlumnoModel
    {
        public int alm_id { get; set; }
        public string alm_codigo { get; set; }
        public string alm_nombre { get; set; }
        public int alm_edad { get; set; }
        public string alm_sexo { get; set; }
        public int alm_id_grd { get; set; }
        public string alm_observacion {get; set;}

 
        // public int GuardarAlumno()
        // {
        //     SqlConnection con = new SqlConnection(GetConString.ConString());
        //     // string query = "INSERT INTO ALM_ALUMNO(alm_codigo, alm_nombre, alm_edad, alm_sexo, alm_id_grd, alm_observacion) values ('" + alm_codigo + "','" + alm_nombre + "','" + alm_edad + "','" + alm_sexo + "','" + alm_id_grd + "','" + alm_observacion + "')";
        //     string query = "INSERT INTO ALM_ALUMNO(alm_codigo, alm_nombre, alm_edad, alm_sexo, alm_observacion) values ('" + alm_codigo + "','" + alm_nombre + "','" + alm_edad + "','" + alm_sexo + "','" + alm_observacion + "')";
        //     SqlCommand cmd = new SqlCommand(query, con);
        //     con.Open();
        //     int i = cmd.ExecuteNonQuery();
        //     con.Close();
        //     return i;
        // }
        // public AlumnoModel VerAlumno()
        // {

        // }
    }
}