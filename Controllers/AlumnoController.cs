using System.Reflection.Metadata.Ecma335;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Registro.Models;
using Db.Models;

namespace Registro.Controllers;

public class AlumnoController : Controller
{
    private readonly ILogger<AlumnoController> _logger;

    public AlumnoController(ILogger<AlumnoController> logger)
    {
        _logger = logger;
    }
    [Route("/Pagina/Alumno")]
    public IActionResult Ver()
    {
        ViewBag.alumnos = BaseDeDatos.VerAlumnos();
        return View("/Views/Pages/VerAlumno.cshtml");
    }
    [Route("/Pagina/Alumno/Guardar")]
    public IActionResult Crear()
    {
        return View("/Views/Pages/CrearAlumno.cshtml");
    }
    [Route("/Pagina/Alumno/Editar/{idAlumno}")]
    public IActionResult Editar()
    {
        return View("/Views/Pages/EditarAlumno.cshtml");
    }
    [Route("/Pagina/Alumno/Eliminar/{idAlumno}")]
    public IActionResult Eliminar(int idAlumno)
    {
        try
        {
            BaseDeDatos.EliminarAlumno(idAlumno);
        }
        catch
        {
            Console.WriteLine("Algo salio mal...");
        }
        return Redirect("/Pagina/Alumno");
    }
    public IActionResult GuardarEnBd(String alm_codigo, String alm_nombre, int alm_edad, String alm_sexo, int alm_id_grd, string alm_observacion)
    {
        try
        {
            AlumnoModel alumno = new AlumnoModel();
            alumno.alm_codigo = alm_codigo;
            alumno.alm_nombre = alm_nombre;
            alumno.alm_edad = alm_edad;
            alumno.alm_sexo = alm_sexo;
            alumno.alm_id_grd = alm_id_grd;
            alumno.alm_observacion = alm_observacion;
            int resultado = BaseDeDatos.GuardarAlumno(alumno);
            Console.WriteLine(resultado);
        }
        catch
        {
            Console.WriteLine("Fallo");
        }
        return Redirect("/Pagina/Alumno");
    }
}