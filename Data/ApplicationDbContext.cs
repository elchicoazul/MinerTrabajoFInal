﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace MinerTrabajoFInal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MinerTrabajoFInal.Models.Cliente> Clientes { get; set; }

        public DbSet<MinerTrabajoFInal.Models.Resultado> Resultado { get; set; }
        public DbSet<MinerTrabajoFInal.Models.Muestras> Muestras { get; set; } 
        // public DbSet<MinerTrabajoFInal.Models.Recepcion> Recepcion { get; set; }

    }
}
