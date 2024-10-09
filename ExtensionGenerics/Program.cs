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

            var myConsole = new Console<string, int, string, int>("Sony", 2020, "PS5");
            var myConsole2 = new Console<string, string, string, string>("Microsoft", "2020", "Xbox X");
            myConsole.ConsoleInfo();
            myConsole2.ConsoleInfo();

            myConsole.AddItem(10);
            myConsole.AddItem(20);
            myConsole.AddItem(30);
            myConsole.DisplayItems();
            myConsole.RemoveItem(20);
            myConsole.DisplayItems();
        }
    }

    class Console<T1, T2, T3, T4>
    {
        public T1 Manufacturer;
        public T2 Year;
        public T3 Model;

        private List<T4> items = new List<T4>();

        public Console(T1 manufacturer, T2 year, T3 model)
        {
            Manufacturer = manufacturer;
            Year = year;
            Model = model;
        }

        public void AddItem(T4 item)
        {
            items.Add(item);
            Console.WriteLine($"{item} has been added.");
        }

        public bool RemoveItem(T4 item)
        {
            bool removed = items.Remove(item);
            if (removed)
            {
                Console.WriteLine($"{item} has been removed.");
            }
            else
            {
                Console.WriteLine($"{item} not found in the collection.");
            }
            return removed;
        }

        public void DisplayItems()
        {
            Console.WriteLine("Collection items:");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
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

        public static void ConsoleInfo<T1,T2,T3,T4>(this Console<T1,T2,T3,T4> console)
        {
            Console.WriteLine($"{console.Manufacturer}, {console.Year}, {console.Model}");
        }
    }
}
