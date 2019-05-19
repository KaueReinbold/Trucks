using Trucks.Domain.Models.Enumerables;

namespace Trucks.Domain.Models
{
    /// <summary>
    /// Class that represents a Truck Model.
    /// </summary>
    public class Truck
    {
        public Truck(
            string chassis,
            EnumModel model,
            string modelComplement,
            int year,
            int modelYear)
        {
            Chassis = chassis;
            Model = model;
            ModelComplement = modelComplement;
            Year = year;
            ModelYear = modelYear;
        }

        public Truck() { }

        public int Id { get; set; }
        public string Chassis { get; set; }
        public EnumModel Model { get; set; }
        public string ModelComplement { get; set; }
        public int Year { get; set; }
        public int ModelYear { get; set; }
    }
}
