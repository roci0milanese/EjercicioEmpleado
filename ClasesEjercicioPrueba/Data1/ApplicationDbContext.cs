using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClasesEjercicioPrueba.Models;

namespace ClasesEjercicioPrueba.Data1
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost;Database=EjPruebaProgramacion;Trusted_Connection=True;TrustServerCertificate=True;"
            );
        }



    }
}
