using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MinerTrabajoFInal.Data;
using MinerTrabajoFInal.Models;
using Models;

namespace MinerTrabajoFInal.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ILogger<ClientesController> _logger;
        private readonly ApplicationDbContext _context;


        public ClientesController(ILogger<ClientesController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Clientes objClientes)
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