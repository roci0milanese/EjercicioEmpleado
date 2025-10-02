using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClasesEjercicioPrueba.Data1;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClasesEjercicioPrueba.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
         
        public Vehiculo(string marca, string modelo, int anio)
        {
            this.Marca = marca; 
            this.Modelo = modelo;
            this.Anio = anio;
        }

        
        public Vehiculo() { }

    }
}
