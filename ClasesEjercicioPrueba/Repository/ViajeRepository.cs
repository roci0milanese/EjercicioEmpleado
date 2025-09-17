using ClasesEjercicioPrueba.Data1;
using ClasesEjercicioPrueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ClasesEjercicioPrueba.Repository
{
    public static class ViajeRepository
    {

        public static void GuardarViaje(Viaje viaje)
        {
            using var context = new ApplicationDbContext();
            context.Viaje.Add(viaje);

            context.SaveChanges();
        }

        public static List<Viaje> ObtenerViajes()
        {
            using var context = new ApplicationDbContext();
            return context.Viaje.ToList();
        }

        public static void ActualizarViaje(Viaje viaje)
        {
            using var context = new ApplicationDbContext();
            context.Viaje.Update(viaje);
            context.SaveChanges();
        }
        public static void EliminarViaje(Viaje viaje)
        {
            using var context = new ApplicationDbContext();
            context.Viaje.Remove(viaje);
            context.SaveChanges();
        }
    }
}
