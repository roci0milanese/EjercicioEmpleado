using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClasesEjercicioPrueba.Data1;

namespace ClasesEjercicioPrueba.Models
{
    public class Departamento
    {
        public int Id { get; set; }  
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public List<Empleado> Empleados { get; set; } = new();

       
        public Departamento(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }

        public Departamento() { }
    }
}
