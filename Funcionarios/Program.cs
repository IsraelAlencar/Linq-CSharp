using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Funcionarios.Entities;

namespace Funcionarios {
    class Program {
        static void Main(string[] args) {
            Console.Write("Enter full fle path: ");
            string path = Console.ReadLine();

            List<Employee> list = new List<Employee>();

            using (StreamReader sr = File.OpenText(path)) {
                while (!sr.EndOfStream) {
                    string[] data = sr.ReadLine().Split(',');
                    string name = data[0];
                    string email = data[1];
                    double salary = double.Parse(data[2], CultureInfo.InvariantCulture);

                    list.Add(new Employee(name, email, salary));
                }
            }

            Console.Write("Enter salary: ");
            double salaryCap = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            var aboveCap = list.Where(p => p.Salary > salaryCap).Select(p => p.Email);
            Console.WriteLine("Email of people whose salary is more than " + salaryCap + ":");
            foreach (string email in aboveCap) {
                Console.WriteLine(email);
            }

            var sum = list.Where(p => p.Name[0] == 'M').Sum(p => p.Salary);
            Console.WriteLine("Sum of salary of people whose name starts with 'M': " + sum);
        }
    }
}
