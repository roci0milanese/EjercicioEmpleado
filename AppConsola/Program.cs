using ClasesEjercicioPrueba.Models;
using ClasesEjercicioPrueba.Repository;
using System.ComponentModel.DataAnnotations;

List<Vehiculo> vehiculos = new(); //lista de vehículos

int opcion = 0;
do
{
    Console.WriteLine("BIENVENIDO");
    Console.WriteLine("Elija una opcion: ");
    Console.WriteLine("1- Registrar nuevo vehículo");
    Console.WriteLine("2- Registrar nuevo viaje");
    Console.WriteLine("3- Actualizar capacidad de carga de un vehículo");
    Console.WriteLine("4- Eliminar vehículo");
    Console.WriteLine("5- Eliminar viaje");
    Console.WriteLine("6- Listar todos los vehículos con sus viajes");
    Console.WriteLine("7- Estadísticas de viajes");
    Console.WriteLine("8- Salir del sistema");
    opcion = int.Parse(Console.ReadLine());
    Console.Clear();

    switch (opcion)
    {
        case 1:
           
            Console.WriteLine("Ingrese la marca del vehículo:");
            string Marca = Console.ReadLine();
            Console.WriteLine("Ingrese el modelo del vehículo:");
            string Modelo = Console.ReadLine();
            Console.WriteLine("Ingrese la capacidad de carga en kg:");
            int CapacidadCargaKg = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la patente del vehículo:");
            string Patente = Console.ReadLine();
            if (vehiculos.Any(v => v.Patente == Patente)) // el any devuelve true si encuentra al menos un elemento que cumple la condición
            {
                Console.WriteLine("Error: Ya existe un vehículo con esa patente.");
                break; // Salir del case sin registrar el vehículo
            }
            else
            {
                Vehiculo vehiculo = new( Marca, Modelo, CapacidadCargaKg, Patente);
                vehiculos.Add(vehiculo);
                Console.WriteLine("Vehículo registrado con éxito.");
                VehiculoRepository.GuardarVehiculo(vehiculo); // Guarda el vehículo usando el repositorio
            }
            break;


        case 2:
           
            Console.WriteLine("Ingrese la patenete de el vehiculo al que se le asignará un viaje: ");
            string patenteViaje = Console.ReadLine();
            if (vehiculos.Any(v => v.Patente == patenteViaje)) // Verifica si existe un vehículo con esa patente
            {
                Console.WriteLine("Ingrese el origen del viaje: ");
                string origen = Console.ReadLine();
                Console.WriteLine("Ingrese el destino del viaje: ");
                string destino = Console.ReadLine();
                Console.WriteLine("Ingrese la fecha del viaje (dd/mm/aaaa): ");
                string fecha = Console.ReadLine();
                Console.WriteLine("Ingrese la distancia en km del viaje: ");
                int distanciaKm = int.Parse(Console.ReadLine());
                // Obtener el Id del vehículo correspondiente a la patente ingresada
                int vehiculoId = vehiculos.First(v => v.Patente == patenteViaje).Id; // el First devuelve el primer elemento que cumple la condición
                Viaje viaje = new(origen, destino, fecha, distanciaKm, vehiculoId); // Crea el viaje

                ViajeRepository.GuardarViaje(viaje); // Guarda el viaje usando el repositorio

                Console.WriteLine("Viaje registrado con éxito.");
            }
            else
            {
                Console.WriteLine("Error: No existe un vehículo con esa patente.");
            }

            break;
        case 3:
           
            Console.WriteLine("Ingrese la patente del vehículo que desea actualizar la capacidad de carga: ");
            string patenteActualizar = Console.ReadLine();
            Vehiculo vehiculoActualizar = vehiculos.FirstOrDefault(v => v.Patente == patenteActualizar); // Busca el vehículo con la patente ingresada
            if (vehiculoActualizar != null) // Si se encontró el vehículo
            {
                Console.WriteLine("Ingrese la nueva capacidad de carga en kg: ");
                int nuevaCapacidad = int.Parse(Console.ReadLine());
                vehiculoActualizar.CapacidadCargaKg = nuevaCapacidad; // Actualiza la capacidad de carga
                VehiculoRepository.ActualizarVehiculo(vehiculoActualizar); // Actualiza el vehículo en la base de datos
                Console.WriteLine("Capacidad de carga actualizada con éxito.");
            }
            else
            {
                Console.WriteLine("Error: No existe un vehículo con esa patente.");
            }

            break;
        case 4:
            
            Console.WriteLine("Ingrese la Patente: ");
            string patenteEliminar = Console.ReadLine();
            Vehiculo vehiculoEliminar = vehiculos.FirstOrDefault(v => v.Patente == patenteEliminar); // Busca el vehículo con la patente ingresada
            if (vehiculoEliminar != null) // Si se encontró el vehículo
            {
                vehiculos.Remove(vehiculoEliminar); // Elimina el vehículo de la lista
                VehiculoRepository.EliminarVehiculo(vehiculoEliminar); // Elimina el vehículo de la base de datos
                Console.WriteLine("Vehículo eliminado con éxito.");
            }

          break;
        case 5:
           
            Console.WriteLine("Ingrese el Id del viaje que desea eliminar: ");
            int idViajeEliminar = int.Parse(Console.ReadLine());
            Viaje viajeEliminar = ViajeRepository.ObtenerViajes().FirstOrDefault(v => v.Id == idViajeEliminar); // Busca el viaje con el Id ingresado
            if (viajeEliminar != null) // Si se encontró el viaje
            {
                ViajeRepository.EliminarViaje(viajeEliminar); // Elimina el viaje de la base de datos
                Console.WriteLine("Viaje eliminado con éxito.");
            }
            else
            {
                Console.WriteLine("Error: No existe un viaje con ese Id.");
            }


            break;
        case 6:
           
              foreach (var veh in vehiculos)
            {
                Console.WriteLine(veh.Patente + " - " + veh.Marca + " " + veh.Modelo + " - " + veh.CapacidadCargaKg + "kg");
                List<Viaje> viajesDelVehiculo = ViajeRepository.ObtenerViajes().Where(v => v.VehiculoId == veh.Id).ToList(); // Obtiene los viajes del vehículo
                foreach (var viaje in viajesDelVehiculo)
                {
                    Console.WriteLine("   Viaje: " + viaje.Origen + " → " + viaje.Destino + " (" + viaje.DistanciaKm + " km)");
                }
            }

            break;
        case 7:
          
            List<Viaje> todosLosViajes = ViajeRepository.ObtenerViajes(); // Obtiene todos los viajes
            int cantidadTotalViajes = todosLosViajes.Count; // Cantidad total de viajes
            int distanciaTotalRecorrida = todosLosViajes.Sum(v => v.DistanciaKm); // Distancia total recorrida
            double promedioDistanciaPorViaje = cantidadTotalViajes > 0 ? (double)distanciaTotalRecorrida / cantidadTotalViajes : 0; // Promedio de distancia por viaje
            var vehiculoConMayorCantidadDeViajes = vehiculos.OrderByDescending(v => todosLosViajes.Count(t => t.VehiculoId == v.Id)).FirstOrDefault(); // Vehículo con mayor cantidad de viajes
            var vehiculoConMayorDistanciaRecorrida = vehiculos.OrderByDescending(v => todosLosViajes.Where(t => t.VehiculoId == v.Id).Sum(t => t.DistanciaKm)).FirstOrDefault(); // Vehículo con mayor distancia total recorrida
            Console.WriteLine("Cantidad total de viajes: " + cantidadTotalViajes);
            Console.WriteLine("Distancia total recorrida por todos los vehículos: " + distanciaTotalRecorrida + " km");
            Console.WriteLine("Promedio de distancia por viaje: " + promedioDistanciaPorViaje + " km");
            Console.WriteLine("Vehículo con mayor cantidad de viajes: " + (vehiculoConMayorCantidadDeViajes != null ? vehiculoConMayorCantidadDeViajes.Patente : "N/A"));
            Console.WriteLine("Vehículo con mayor distancia total recorrida: " + (vehiculoConMayorDistanciaRecorrida != null ? vehiculoConMayorDistanciaRecorrida.Patente : "N/A"));
           
            break;

        case 8:

            Console.WriteLine("Saliendo del sistema...");
            break;

        default:
            Console.WriteLine("Opción no válida. Intente de nuevo.");
            break;
    }

} while (opcion != 8); //mientras no sea 8 lo repite


