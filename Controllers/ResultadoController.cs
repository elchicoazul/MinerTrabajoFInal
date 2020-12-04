using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MinerTrabajoFInal.Data;
using MinerTrabajoFInal.Models;

namespace MinerTrabajoFInal.Controllers
{
    public class ResultadoController : Controller
    {
        private readonly ILogger<ResultadoController> _logger;
        private readonly ApplicationDbContext _context;
        public ResultadoController(ILogger<ResultadoController> logger, ApplicationDbContext context)
        {
            _logger=logger;
            _context=context;
        }

        public IActionResult Index()
        {
            //var resultado=_context.Resultado.ToList();
            //return View(resultado);
            return View();
        }
 
    }
}