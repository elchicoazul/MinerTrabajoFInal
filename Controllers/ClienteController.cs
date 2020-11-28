using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var lista = _context.Clientes.ToList();
            return View(lista);
        }

        [HttpPost]
        public IActionResult Registrar(Cliente objCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(objCliente);
                _context.SaveChanges();
                return RedirectToAction("Confirmacion");

            }
            return View("Crear", objCliente);
        }

        public IActionResult Confirmacion()
        {
            return View();
        }

        public IActionResult Crear()
        {
            return View();
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("id,razonsocial,dni,direccion,telefono,correo")] Cliente objCliente)
        {   
            if (id != objCliente.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(objCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(objCliente);
        }

        public IActionResult Delete(int? id)
        {
            var contacto = _context.Clientes.Find(id);
            _context.Clientes.Remove(contacto);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}