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
    public class MuestrasController : Controller
    {
        private readonly ILogger<MuestrasController> _logger;
        private readonly ApplicationDbContext _context;

        public MuestrasController(ILogger<MuestrasController> logger , ApplicationDbContext context)
        {
            _logger = logger;

            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(Muestras objMuestra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(objMuestra);
                _context.SaveChanges();
               return RedirectToAction("Index", "Home");

            }
           return View("Index", objMuestra);
        }
    }
}