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
    public class RecepcionController : Controller
    {
        private readonly ILogger<RecepcionController> _logger;
        private readonly ApplicationDbContext _context;
        public RecepcionController(ILogger<RecepcionController> logger, ApplicationDbContext context)
        {
            _logger=logger;
            _context=context;
        }
public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registrar(Resultado objRecepcion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(objRecepcion);
                _context.SaveChanges();
                return RedirectToAction("Validar");
               //return View();
            }
            return View("Index", objRecepcion);
        }
 
    }
}