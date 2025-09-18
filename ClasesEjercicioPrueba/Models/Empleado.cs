using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClasesEjercicioPrueba.Data1;

namespace ClasesEjercicioPrueba.Models
{
    public class Empleado
    {
        public int Id { get; set; } 
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
        public decimal Salario { get; set; }

        
        public Empleado(string nombre, string email, int departamentoId, decimal salario)
        {
            Nombre = nombre;
            Email = email;
            DepartamentoId = departamentoId;
            Salario = salario;
        }

        
        public Empleado() { }
    }
}

