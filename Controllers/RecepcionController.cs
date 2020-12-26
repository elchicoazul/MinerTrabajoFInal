using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MinerTrabajoFInal.Data;
using MinerTrabajoFInal.Models;
using System.Dynamic;


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
               
     var LisMuestras=_context.Muestras.ToList();
     var LisClientes=_context.Clientes.ToList();
     var resultados=_context.Resultado.ToList();
            Resultado resultado = new Resultado();
            dynamic model = new ExpandoObject();
            model.r = resultado;
            model.Muestras = LisMuestras;
            model.cli=LisClientes;
            model.res=resultados;
            return View(model);
               
        }
        [HttpPost]
        public IActionResult Registrar(Resultado objRecepcion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(objRecepcion);
                _context.SaveChanges();
                return RedirectToAction("Confirmacion");
               //return View();
            }
            return View("Index", objRecepcion);
        }
          public IActionResult Confirmacion()
        {
            return View();
        }
 
    }
}