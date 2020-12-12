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
using Microsoft.AspNetCore; // ++
using Microsoft.AspNetCore.Hosting; /// ++

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
/*
        public ActionResult Editar(int id){
            return View(_context.Resultado.Where(s => s.numerorecpcion == id).First());
        }
        [HttpPost]
        public ActionResult Editar(Resultado resu){
            Resultado d = _context.Resultado.Where(s => s.numerorecpcion == resu.numerorecpcion).First();
            d.valor = resu.valor;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));        
            //return RedirectToAction("Index","Resultado");
        }*/

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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("valor")] Resultado resu)
        {
            if (ModelState.IsValid)
            {
                Resultado d = _context.Resultado.Where(s => s.numerorecpcion == resu.numerorecpcion).First();
                d.valor = resu.valor;
                _context.Update(resu);                
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));        
            }
        return View(resu);
        
        }
       /*  public async Task<IActionResult> Editar(int id, [Bind("valor")] Resultado result)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(result).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        return View(result);
        }*/
        
    }
}
