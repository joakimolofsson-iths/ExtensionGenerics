namespace ExtensionGenerics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IVehicle myCar = new Car("Volvo", "V70");
            IVehicle myBoat = new Boat("Cornwall", "Endurance");

            myCar.ShowVehicle();
            myBoat.ShowVehicle();
        }
    }

    interface IVehicle
    {
        string Manufacturer { get; }
        string Model { get; }

    }
    class Car : IVehicle
    {
        public string Manufacturer { get; private set; }
        public string Model { get; private set; }

        public Car(string manufacturer, string model)
        {
            Manufacturer = manufacturer;
            Model = model;
        }
    }

    class Boat : IVehicle
    {
        public string Manufacturer { get; private set; }
        public string Model { get; private set; }

        public Boat(string manufacturer, string model)
        {
            Manufacturer = manufacturer;
            Model = model;
        }
    }

    static class VehicleExtension
    {
        public static void ShowVehicle(this IVehicle vehicle)
        {
            Console.WriteLine($"{vehicle.Manufacturer} {vehicle.Model}");
        }
    }
}
