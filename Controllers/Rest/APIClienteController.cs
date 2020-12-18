using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MinerTrabajoFInal.Models;
using MinerTrabajoFInal.Data;

namespace MinerTrabajoFInal.Controllers.Rest
{
    public class ApiCliente
    {
        [ApiController]
        [Route("api/clientes")]
        public class APIProductoController : ControllerBase
        {
            private readonly ILogger<APIProductoController> _logger;
            private readonly ApplicationDbContext _context;

            public APIProductoController(ILogger<APIProductoController> logger, ApplicationDbContext context)
            {
                _logger = logger;
                _context = context;
            }

            [HttpGet]
            public IEnumerable<Cliente> Get()
            {
                var listaClientes = _context.Clientes.OrderBy(s => s.id).ToList();   
                return listaClientes.ToArray();
            }
            /*
            [HttpGet("{id}")]
            public Producto GetProduct(int? id)
            {
                var producto =  _context.Productos.Find(id);
                return producto;
            }

            [HttpPost]
            public Producto CreateProduct(Producto producto){
                _context.Add(producto);
                _context.SaveChanges();
                return producto;
            }*/
        }
    }
}