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


        public ClienteController(ILogger<ResultadoController> logger, ApplicationDbContext context )
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            //var contactos = _context.Contactos.Where(x => x.Mensaje != null).ToList();
            var resultado=_context.resultado().ToList();
            return View(resultado);
        }
        //borrar
        [HttpPost]
        public IActionResult Crear(Cliente objClientes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(objClientes);
                _context.SaveChanges();
                objClientes.respuesta = "Registro exitoso my friend!";
            }
            return View(objClientes);
        }
    }
}