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
    public class ClienteController : Controller
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly ApplicationDbContext _context;

        public ClienteController(ILogger<ClienteController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Cliente objClientes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(objClientes);
                _context.SaveChanges();
                return RedirectToAction("Confirmacion");

            }
            return View("index",objClientes);
        }

        public IActionResult Confirmacion()
        {
            return View();
        }
    }
}