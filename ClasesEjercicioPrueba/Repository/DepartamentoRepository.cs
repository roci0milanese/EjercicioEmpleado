
using ClasesEjercicioPrueba.Data1;
using ClasesEjercicioPrueba.Models;

namespace ClasesEjercicioPrueba.Repository
{
    public static class DepartamentoRepository
    {
        public static void GuardarDepartamento(Departamento dep)
        {
            using var context = new ApplicationDbContext();

            if (context.Departamentos.Any(d => d.Nombre == dep.Nombre))
            {
                Console.WriteLine("Ya existe un departamento con ese nombre.");
                return;
            }

            context.Departamentos.Add(dep);
            context.SaveChanges();
        }

        public static List<Departamento> ObtenerDepartamentos()
        {
            using var context = new ApplicationDbContext();
            return context.Departamentos.ToList();
        }

        public static string ObetenerNombreDepartamentoMax()
        {
            using var context = new ApplicationDbContext();

            var nombreDepartamento = context.Departamentos
                .OrderByDescending(d => d.Empleados.Count)
                .FirstOrDefault().Nombre;

            if (nombreDepartamento != null)
            {
                return nombreDepartamento;
            }

            return "";
        }
    }

}
