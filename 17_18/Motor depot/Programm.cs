using Motor_depot.Builder;
using Motor_depot.Prototype;
using System.Runtime.CompilerServices;

namespace Motor_depot
{
    internal class Programm
    {
        static void Main(string[] args)
        {
            //Singleton.Singleton s1 = Singleton.Singleton.Initialize();

            //Console.WriteLine(s1.GetHashCode());

            //Singleton.Singleton s2 = Singleton.Singleton.Initialize();

            //Console.WriteLine(s2.GetHashCode());

            //s1.CBC();
            /////////////////////////////////////////////////////////////////
            //IAnimal sheepDonor = new Sheep();
            //sheepDonor.SetName("Долли");

            //IAnimal sheepClone = sheepDonor.Clone();

            //Console.WriteLine(sheepDonor.GetName());
            //Console.WriteLine(sheepClone.GetName());


             System testSystem = new System();
            Dispatcher testDispatcher = new Dispatcher();
            Driver testDriver = new Driver();


            testSystem.register("Nikita", 123456);
            testSystem.register("Artem", 228228);
            testSystem.register("Danila", 133713);

            testSystem.SignIn("Nikita", 123456);
            testSystem.SignIn("Artem", 228228);
            testSystem.SignIn("Danila", 133713);

            testSystem.ViewAvailCars("Artem");

            uint OrderID_1 = testSystem.MakeSentOrder("Artem", 10, 90);
            uint OrderID_2 = testSystem.MakeSentOrder("Danila", 50, 70);
            uint OrderID_3 = testSystem.MakeSentOrder("Nikita", 90, 50);

            testSystem.DeleteSentOrder("Danila", OrderID_2);


            ///////////////////////////////////////////////////////////////////////
            Console.WriteLine();
            Console.WriteLine();


            //testDispatcher.ViewOrders();

            var testBuilder = new OrdersDisplayBuilder(Databases.OrderList);
            testBuilder.BuildHeader();
            testBuilder.BuildBody();
            testBuilder.BuildFooter();

            var display = testBuilder.GetReport();
            Console.WriteLine(display);


            (string driverName, uint orderID) driverNameID = testDispatcher.FindDriver(Databases.OrderList[0]);

            //Попробуй переделать с событиями!!!
            //testDispatcher.DistOrderToDriver(driverNameID.orderID, driverNameID.driverName);

            Dispatcher.DistOrderToDriver(driverNameID.orderID, driverNameID.driverName);

            testDriver.FlightReport(driverNameID.driverName, driverNameID.orderID, true, true);

            foreach (var item in Databases.UsersUccounts)
            {

            }

            foreach (var item in Databases.CarsList)
            {

            }

            foreach (var item in Databases.OrderList)
            {

            }
        }
    }
}