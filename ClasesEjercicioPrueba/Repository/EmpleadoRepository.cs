using ClasesEjercicioPrueba.Data1;
using ClasesEjercicioPrueba.Models;
using Microsoft.EntityFrameworkCore;

namespace ClasesEjercicioPrueba.Repository
{
    public static class EmpleadoRepository
    {
        public static void GuardarEmpleado(Empleado emp) // metodo para guardar empleado
        {
            using var context = new ApplicationDbContext(); // Usar 'using' para asegurar la correcta gestión del contexto

            if (context.Empleados.Any(e => e.Email == emp.Email)) // Verificar si ya existe un empleado con el mismo email
            {
                Console.WriteLine("Ya existe un empleado con ese email.");
                return;
            }

            if (!context.Departamentos.Any(d => d.Id == emp.DepartamentoId)) // Verificar si el departamento existe
            {
                Console.WriteLine("El departamento especificado no existe.");
                return;
            }

            context.Empleados.Add(emp); // Agregar el empleado al contexto
            context.SaveChanges(); // Guardar los cambios en la base de datos
        }

        public static Empleado ObtenerEmpleadoPorEmail(string email)
        {
            using var context = new ApplicationDbContext();
            return context.Empleados.FirstOrDefault(e => e.Email == email); // Retorna el empleado o null si no se encuentra
        }

        public static void ActualizarEmpleado(Empleado emp)
        {
            using var context = new ApplicationDbContext();
            context.Empleados.Update(emp); // Actualiza el empleado en el contexto
            context.SaveChanges();
        }

        public static void EliminarEmpleado(Empleado emp)
        {
            using var context = new ApplicationDbContext();
            context.Empleados.Remove(emp); // Elimina el empleado del contexto
            context.SaveChanges();
        }

        public static List<Empleado> ObtenerEmpleados()
        {
            using var context = new ApplicationDbContext();
            return context.Empleados.Include(e => e.Departamento).ToList(); // Incluye el departamento relacionado
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
            return context.Empleados.Any() ? context.Empleados.Min(e => e.Salario) : 0; // Evitar excepción si no hay empleados
        }

        public static List<Empleado> ObtenerEmpleadosPorDepartamento(int departamentoId)
        {
            using var context = new ApplicationDbContext();
            return context.Empleados.Where(e => e.DepartamentoId == departamentoId).ToList();
        }

        public static string ObtenerEmpleadosOrdenadosPorNombreAlfabeticamente()
        {
            using var context = new ApplicationDbContext();
            var empleados = context.Empleados.OrderBy(e => e.Nombre).ToList();
            return string.Join(", ", empleados.Select(e => e.Nombre));
        }
        public static string MostrarNombreseEmails()
        {
            using var context = new ApplicationDbContext();
            var empleados = context.Empleados.ToList();
            return string.Join(", ", empleados.Select(e => $"{e.Nombre} ({e.Email})"));
        }
        public static string ObtenerEmpleadoConSalarioMasAlto()
        {
            using var context = new ApplicationDbContext();
            var empleado = context.Empleados.OrderByDescending(e => e.Salario).FirstOrDefault();
            return empleado != null ? $"{empleado.Nombre} ({empleado.Email}) - Salario: {empleado.Salario}" : "No hay empleados.";
        }
        public static string EmpleadosConSalarioMayorA100000()
        {
            using var context = new ApplicationDbContext();
            var empleados = context.Empleados.Where(e => e.Salario > 100000).ToList();
            return empleados.Any() ? string.Join(", ", empleados.Select(e => $"{e.Nombre} ({e.Email}) - Salario: {e.Salario}")) : "No hay empleados con salario mayor a 100000.";
        }
        public static string MostrarNombreEmpleadosDelDepartamentoDesarrollo()
        {
            using var context = new ApplicationDbContext();
            var empleados = context.Empleados
                .Include(e => e.Departamento)
                .Where(e => e.Departamento.Nombre == "Desarrollo")
                .ToList();
            return empleados.Any() ? string.Join(", ", empleados.Select(e => $"{e.Nombre} ({e.Email}) - Departamento: {e.Departamento.Nombre}")) : "No hay empleados en el departamento de Desarrollo.";
        }
        public static string MostrarEmpleadosEmail()
        {
            using var context = new ApplicationDbContext(); // Usar 'using' para asegurar la correcta gestión del contexto
            var empleados = context.Empleados.ToList(); // Obtener todos los empleados

            foreach (var emp in empleados)
            {
                if (emp.Email == "@gmail.com")
                {
                    Console.WriteLine($"Nombre: {emp.Nombre}, Email: {emp.Email} (Es Gmail)");
                    Console.WriteLine(emp.Email);
                }
                else
                {
                    Console.WriteLine($"Nombre: {emp.Nombre}, Email: {emp.Email} (No es Gmail)");
                    Console.WriteLine(emp.Email);
                }

            }
            return "";

        }
        public static string MostrarEmpleadosConA()
        {
            using var context = new ApplicationDbContext();
            var empleados = context.Empleados
                .Where(e => e.Nombre.StartsWith("A"))
                .ToList();
            return empleados.Any() ? string.Join(", ", empleados.Select(e => $"{e.Nombre} ({e.Email})")) : "No hay empleados cuyo nombre empiece con 'A'.";

        }

        public static string ExisteEmpleadoConSalarioMenorA50000()
        {
            using var context = new ApplicationDbContext();
            bool existe = context.Empleados.Any(e => e.Salario < 50000);
            return existe ? "Sí, existe al menos un empleado con salario menor a 50000." : "No, no existe ningún empleado con salario menor a 50000.";
        }


        public static string ObtenerEmpleadosSinDepartamento()
        {
            using var context = new ApplicationDbContext();
            var empleadosSinDepartamento = context.Empleados
                .Where(e => !context.Departamentos.Any(d => d.Id == e.DepartamentoId))
                .ToList();
            return empleadosSinDepartamento.Any()
                ? string.Join(", ", empleadosSinDepartamento.Select(e => $"{e.Nombre} ({e.Email})"))
                : "No hay empleados sin departamento asignado.";

        }
        
        public static string ObtenerEmpleadosDeVentasOSoporte()
        {
            using var context = new ApplicationDbContext();
            var empleados = context.Empleados
                .Include(e => e.Departamento)
                .Where(e => e.Departamento.Nombre == "Ventas" || e.Departamento.Nombre == "Soporte")
                .ToList();
            return empleados.Any()
                ? string.Join(", ", empleados.Select(e => $"{e.Nombre} ({e.Email}) - Departamento: {e.Departamento.Nombre}"))
                : "No hay empleados en los departamentos de Ventas o Soporte.";
        }
       
        public static string ObtenerEmpleadosConDepartamentosYSalarios()
        {
            using var context = new ApplicationDbContext();
            var empleadosConDepartamentos = context.Empleados
                .Include(e => e.Departamento)
                .Select(e => new
                {
                    e.Nombre,
                    DepartamentoNombre = e.Departamento.Nombre,
                    e.Salario
                })
                .ToList();
            return empleadosConDepartamentos.Any()
                ? string.Join(", ", empleadosConDepartamentos.Select(ed => $"{ed.Nombre} - {ed.DepartamentoNombre} - Salario: {ed.Salario}"))
                : "No hay empleados con departamentos y salarios.";
        }
        
        public static string ListarEmpleadosOrdenadosPorDepartamento()
        {
            using var context = new ApplicationDbContext();
            var empleados = context.Empleados
                .Include(e => e.Departamento)
                .OrderBy(e => e.Departamento.Nombre)
                .ThenBy(e => e.Nombre)
                .ToList();
            return empleados.Any()
                ? string.Join(", ", empleados.Select(e => $"{e.Nombre} - Departamento: {e.Departamento.Nombre}"))
                : "No hay empleados para listar.";
        }
     
        public static string PromedioSalariosPorDepartamento()
        {
            using var context = new ApplicationDbContext();
            var promedios = context.Empleados
                .Include(e => e.Departamento)
                .GroupBy(e => e.Departamento.Nombre)
                .Select(g => new
                {
                    Departamento = g.Key,
                    PromedioSalario = g.Average(e => e.Salario)
                })
                .ToList();
            return promedios.Any()
                ? string.Join(", ", promedios.Select(p => $"{p.Departamento}: Promedio de Salario = {p.PromedioSalario}"))
                : "No hay datos de salarios por departamento.";
        }

        public static string SumaSalariosPorDepartamento()
        {
            using var context = new ApplicationDbContext();
            var sumas = context.Empleados
                .Include(e => e.Departamento)
                .GroupBy(e => e.Departamento.Nombre)
                .Select(g => new
                {
                    Departamento = g.Key,
                    SumaSalarios = g.Sum(e => e.Salario)
                })
                .ToList();
            return sumas.Any()
                ? string.Join(", ", sumas.Select(s => $"{s.Departamento}: Suma de Salarios = {s.SumaSalarios}"))
                : "No hay datos de salarios por departamento.";
        }
     
        public static string MostrarEmpleadosConDepartamentosInclusoSinDepartamento()
        {
            using var context = new ApplicationDbContext();
            var empleados = context.Empleados
                .Include(e => e.Departamento)
                .Select(e => new
                {
                    e.Nombre,
                    DepartamentoNombre = e.Departamento != null ? e.Departamento.Nombre : "Sin Departamento"
                })
                .ToList();
            return empleados.Any()
                ? string.Join(", ", empleados.Select(e => $"{e.Nombre} - Departamento: {e.DepartamentoNombre}"))
                : "No hay empleados para listar.";
        }




    }
}

