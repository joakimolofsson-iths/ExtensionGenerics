using System;

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

            Console<string, int, string> myConsole = new Console<string, int, string>("Sony", 2020, "PS5");
            Console<string, string, string> myConsole2 = new Console<string, string, string>("Microsoft", "2020", "Xbox X");
            myConsole.ConsoleInfo();
            myConsole2.ConsoleInfo();
        }
    }

    class Console<T1, T2, T3>
    {
        public T1 Manufacturer;
        public T2 Year;
        public T3 Model;

        public Console(T1 manufacturer, T2 year, T3 model)
        {
            Manufacturer = manufacturer;
            Year = year;
            Model = model;
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

    static class Utillites
    {
        public static void ShowVehicle(this IVehicle vehicle)
        {
            Console.WriteLine($"{vehicle.Manufacturer} {vehicle.Model}");
        }

        public static void ConsoleInfo<T1,T2,T3>(this Console<T1,T2,T3> console)
        {
            Console.WriteLine($"{console.Manufacturer}, {console.Year}, {console.Model}");
        }
    }
}
