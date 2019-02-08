using System;
using System.Globalization;
using Course.Entities;
using Course.Entities.Enums;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string department = Console.ReadLine();

            Console.WriteLine("Enter the worker data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());

            Console.Write("Base Salary: ");
            double salary = double.Parse(Console.ReadLine());

            Console.Write("How many contracts to this worker? ");
            int num = int.Parse(Console.ReadLine());

            Department dept = new Department(department);
            Worker worker = new Worker(name, level, salary, dept);

            for(int i = 1; i <= num; i++)
            {
                Console.WriteLine("Enter #" + i + "contract data:");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine());
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);
            }

            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string dateString = Console.ReadLine();
            int month = int.Parse(dateString.Substring(0, 2));
            int year = int.Parse(dateString.Substring(3));

            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: "+ worker.Department.Name);
            Console.WriteLine("Income for " + dateString + ": " + worker.Income(year, month));

        }
    }
}
