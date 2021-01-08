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
            Resultado resultado = new Resultado();
            dynamic model = new ExpandoObject();
            model.r = resultado;
            model.Muestras = LisMuestras;
            model.cli=LisClientes;
          
            return View(model);
               
        }
        [HttpPost]
        public IActionResult Registrar(int idcliente, int numerorecpcion,string tipo_analisis, string Envoltura, double precio,int cantidad)
        {
        
           Resultado res = new Resultado();
           res.idcliente=idcliente;
           res.numerorecpcion=numerorecpcion;
           res.tipo_analisis=tipo_analisis;
           res.Envoltura=Envoltura;
           res.precio=precio;
           res.cantidad=cantidad;

               _context.Add(res);
            
                _context.SaveChanges();
                return RedirectToAction("Confirmacion");
               //return View();
            
           
        }
          public IActionResult Confirmacion()
        {
            return View();
        }
 
    }
}