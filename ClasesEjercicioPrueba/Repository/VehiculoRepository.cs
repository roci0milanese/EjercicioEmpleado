
using ClasesEjercicioPrueba.Data1;
using ClasesEjercicioPrueba.Models;

namespace ClasesEjercicioPrueba.Repository
{
    public static class VehiculoRepository
    {
        public static void Agregar(Vehiculo vehiculo)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Vehiculo.Add(vehiculo);
                context.SaveChanges();
            }
        }
        public static List<Vehiculo> ObtenerTodos()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Vehiculo.ToList();
            }
        }
      

    }

}
