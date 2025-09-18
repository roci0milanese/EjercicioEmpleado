using ClasesEjercicioPrueba.Data1;
using ClasesEjercicioPrueba.Models;
using Microsoft.EntityFrameworkCore;

namespace ClasesEjercicioPrueba.Repository
{
    public static class EmpleadoRepository
    {
        public static void GuardarEmpleado(Empleado emp)
        {
            using var context = new ApplicationDbContext();

            if (context.Empleados.Any(e => e.Email == emp.Email))
            {
                Console.WriteLine("Ya existe un empleado con ese email.");
                return;
            }

            if (!context.Departamentos.Any(d => d.Id == emp.DepartamentoId))
            {
                Console.WriteLine("El departamento especificado no existe.");
                return;
            }

            context.Empleados.Add(emp);
            context.SaveChanges();
        }

        public static Empleado ObtenerEmpleadoPorEmail(string email)
        {
            using var context = new ApplicationDbContext();
            return context.Empleados.FirstOrDefault(e => e.Email == email);
        }

        public static void ActualizarEmpleado(Empleado emp)
        {
            using var context = new ApplicationDbContext();
            context.Empleados.Update(emp);
            context.SaveChanges();
        }

        public static void EliminarEmpleado(Empleado emp)
        {
            using var context = new ApplicationDbContext();
            context.Empleados.Remove(emp);
            context.SaveChanges();
        }

        public static List<Empleado> ObtenerEmpleados()
        {
            using var context = new ApplicationDbContext();
            return context.Empleados.Include(e => e.Departamento).ToList();
        }

        public static decimal ObtenerSalarioPromedio()
        {
            using var context = new ApplicationDbContext();
            return context.Empleados.Any() ? context.Empleados.Average(e => e.Salario) : 0;
        }

        public static decimal ObtenerSalarioMaximo()
        {
            using var context = new ApplicationDbContext();
            return context.Empleados.Any() ? context.Empleados.Max(e => e.Salario) : 0;
        }

        public static decimal ObtenerSalarioMinimo()
        {
            using var context = new ApplicationDbContext();
            return context.Empleados.Any() ? context.Empleados.Min(e => e.Salario) : 0;
        }

        public static List<Empleado> ObtenerEmpleadosPorDepartamento(int departamentoId)
        {
            using var context = new ApplicationDbContext();
            return context.Empleados.Where(e => e.DepartamentoId == departamentoId).ToList();
        }
    }
}

