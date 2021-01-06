using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var resultado=_context.Resultado.ToList();
            return View(resultado);
            //return View();
        }
        [HttpPost]        
        public IActionResult Buscar(int valor)
        {
            var resultado=_context.Resultado.Where(x=>x.numerorecpcion==valor).ToList();
            //var contactos = _context.Contactos.Where(x => x.Mensaje != null).ToList();
            return View("index",resultado);
            //return View();
        }
 
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _context.Resultado.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }


/*         public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _context.Resultado.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }*/
         [HttpPost]
        [ValidateAntiForgeryToken]        
        public async Task<IActionResult> Editar(int id, [Bind("Id,idcliente,numerorecpcion,tipo_analisis,muestra,precio,cantidad,valor")] Resultado res)
        {   
            if (id != res.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(res);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(res);
        }
        /*
         public async Task<IActionResult> Editar(int? id)
        {
            var resultado = await _context.Resultado.FindAsync(id);
            
            if (resultado == null)
            {
                return NotFound();
            }
            return View();
        }
        */
        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("valor")] Resultado objCliente)
        {   
            if (id != objCliente.numerorecpcion)
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
        */
    }
}