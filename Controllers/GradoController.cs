using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Registro.Models;

namespace Registro.Controllers;

public class GradoController : Controller
{
    private readonly ILogger<GradoController> _logger;

    public GradoController(ILogger<GradoController> logger)
    {
        _logger = logger;
    }
    [Route("/Pagina/Grado")]
    public IActionResult Grados()
    {
        //Console.WriteLine("Entro");
        return View("/Views/Pages/Grados.cshtml");
    }
}