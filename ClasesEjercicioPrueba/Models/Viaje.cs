using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesEjercicioPrueba.Models
{
    public class Viaje
    {
        public int Id { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public string Fecha { get; set; }
        public int DistanciaKm { get; set; }
        public int VehiculoId { get; set; }

        public Viaje ( string origen, string destino, string fecha, int distanciaKm, int vehiculoId)
        {
            Origen = origen;
            Destino = destino;
            Fecha = fecha;
            DistanciaKm = distanciaKm;
            VehiculoId = vehiculoId;
        }
    }
}
