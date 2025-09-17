namespace ClasesEjercicioPrueba.Models
{
    public class Vehiculo
    {

        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int CapacidadCargaKg { get; set; }
        public string Patente { get; set; }

        public Vehiculo ( string Marca, string Modelo, int CapacidadCargaKg, string Patente)
        {
            this.Marca = Marca;
            this.Modelo = Modelo;
            this.CapacidadCargaKg = CapacidadCargaKg;
            this.Patente = Patente;
        }


    }
}
