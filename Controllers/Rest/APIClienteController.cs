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
    [ApiController]
    [Route("api/clientes")]
    public class APIClienteController : ControllerBase
    {
       private readonly ILogger<APIClienteController> _logger;
       private readonly ApplicationDbContext _context;

        public APIClienteController(ILogger<APIClienteController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Cliente> ListClientes()
        {
             var listClientes = _context.Clientes.OrderBy(s => s.id).ToList();   
             return listClientes.ToArray();
        }

        [HttpGet("{id}")]
        public Cliente GetClientes(int? id)
        {
            var cliente =  _context.Clientes.Find(id);
            return cliente;
        }

        [HttpPost]
        public Cliente CreateCliente(Cliente c){
            _context.Add(c);
            _context.SaveChanges();
            return c;
        }

    }
}