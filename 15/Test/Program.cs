using System.Collections.Concurrent;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task task1 = new Task(() => { });
            Task task2 = new Task(() => { });
            Task task3 = new Task(() => { });

            Console.WriteLine($"{task1.Id} {task2.Id} {task3.Id}");




        }



        
    }
}