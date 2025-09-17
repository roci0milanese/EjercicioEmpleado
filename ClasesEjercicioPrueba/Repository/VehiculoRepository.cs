using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesEjercicioPrueba.Data1;
using ClasesEjercicioPrueba.Models;

namespace ClasesEjercicioPrueba.Repository
{
    public static class VehiculoRepository
    {
        public static void GuardarVehiculo(Vehiculo vehiculo)
        {
            using var context = new ApplicationDbContext();
            context.vehiculos.Add(vehiculo);

            context.SaveChanges();
        }

        public static List<Vehiculo> ObtenerVehiculos()
        {
            using var context = new ApplicationDbContext();
            return context.vehiculos.ToList();
        }

        public static void ActualizarVehiculo(Vehiculo vehiculo)
        {
            using var context = new ApplicationDbContext();
            context.vehiculos.Update(vehiculo);
            context.SaveChanges();
        }
        public static void EliminarVehiculo(Vehiculo vehiculo)
        {
            using var context = new ApplicationDbContext();
            context.vehiculos.Remove(vehiculo);
            context.SaveChanges();
        }
    }
}
