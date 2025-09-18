using ClasesEjercicioPrueba.Models;
using ClasesEjercicioPrueba.Repository;

List<Empleado> empleados = new();
List<Departamento> departamentos = new();
int opcion = 0;

do
{
    Console.WriteLine("BIENVENIDO");
    Console.WriteLine("Elija una opción: ");
    Console.WriteLine("1- Registrar nuevo empleado");
    Console.WriteLine("2- Actualizar salario de empleado");
    Console.WriteLine("3- Eliminar empleado");
    Console.WriteLine("4- Registrar nuevo departamento");
    Console.WriteLine("5- Estadísticas de empleados");
    Console.WriteLine("6- Salir.");

    opcion = int.Parse(Console.ReadLine() ?? "0");
    Console.Clear();

    switch (opcion)
    {
        case 1:
            {
                Console.WriteLine("Ingrese el nombre del empleado:");
                string nombre = Console.ReadLine();

                Console.WriteLine("Ingrese el email del empleado:");
                string email = Console.ReadLine();

                Console.WriteLine("Ingrese el salario del empleado:");
                decimal salario = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese el ID del departamento del empleado:");
                int departamentoId = int.Parse(Console.ReadLine());

                Empleado nuevoEmpleado = new(nombre, email, departamentoId, salario);

                EmpleadoRepository.GuardarEmpleado(nuevoEmpleado);
                Console.WriteLine("Empleado guardado exitosamente.");
            }
            break;

        case 2:
            Console.WriteLine("Ingrese el email del empleado a actualizar:");
            string emailActualizar = Console.ReadLine();

            var empleadoActualizar = EmpleadoRepository.ObtenerEmpleadoPorEmail(emailActualizar);
            if (empleadoActualizar != null)
            {
                Console.WriteLine("Ingrese el nuevo salario:");
                decimal nuevoSalario = decimal.Parse(Console.ReadLine());
                empleadoActualizar.Salario = nuevoSalario;
                EmpleadoRepository.ActualizarEmpleado(empleadoActualizar);
                Console.WriteLine("Salario actualizado exitosamente.");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
            break;

        case 3:
            Console.WriteLine("Ingrese el email del empleado a eliminar:");
            string emailEliminar = Console.ReadLine();

            var empleadoEliminar = EmpleadoRepository.ObtenerEmpleadoPorEmail(emailEliminar);
            if (empleadoEliminar != null)
            {
                EmpleadoRepository.EliminarEmpleado(empleadoEliminar);
                Console.WriteLine("Empleado eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
            break;

        case 4:
            Console.WriteLine("Ingrese el nombre del departamento:");
            string nombreDept = Console.ReadLine();

            Console.WriteLine("Ingrese la descripción del departamento:");
            string descripcionDept = Console.ReadLine();

            Departamento nuevoDepartamento = new(nombreDept, descripcionDept);

            DepartamentoRepository.GuardarDepartamento(nuevoDepartamento);
            Console.WriteLine("Departamento registrado exitosamente.");
            break;

        case 5:
            Console.WriteLine($"Total de empleados registrados: {EmpleadoRepository.ObtenerEmpleados().Count}");
            Console.WriteLine($"Promedio de salario general: {EmpleadoRepository.ObtenerSalarioPromedio()}");
            Console.WriteLine($"Salario máximo: {EmpleadoRepository.ObtenerSalarioMaximo()}");
            Console.WriteLine($"Salario mínimo: {EmpleadoRepository.ObtenerSalarioMinimo()}");

            foreach (var dept in DepartamentoRepository.ObtenerDepartamentos())
            {
                int cantidadEmpleados = EmpleadoRepository.ObtenerEmpleadosPorDepartamento(dept.Id).Count;
                Console.WriteLine($"Departamento: {dept.Nombre}, Cantidad de empleados: {cantidadEmpleados}");
            }
            break;

        case 6:
            Console.WriteLine("Saliendo del sistema...");
            break;

        default:
            Console.WriteLine("Opción no válida. Intente de nuevo.");
            break;
    }

} while (opcion != 6);





