using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Registro.Models;

namespace Registro.Controllers;

public class MateriaController : Controller
{
    private readonly ILogger<MateriaController> _logger;

    public MateriaController(ILogger<MateriaController> logger)
    {
        _logger = logger;
    }
}