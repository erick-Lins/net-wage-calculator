using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    public class Crud
    {
        string path = "C:\\Users\\clone\\OneDrive\\Área de Trabalho\\teste.txt";
        public void TxtWriter(List<Employee> employeeList)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (Employee employee in employeeList)
                {
                    sw.WriteLine(employee.Serialize());
                }
            }

            Console.WriteLine("Archive wrote successfully");
        }
        public List<Employee> TxtRead()
        {
            List<Employee> employeeList = new List<Employee>();
            string line;
            using (StreamReader sr = new StreamReader(path))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    string[] entries = line.Split(',');
                    employeeList.Add(new Employee(entries[0], entries[1], entries[2], Convert.ToDouble(entries[3]), Convert.ToDouble(entries[4])));
                }
            }
            return employeeList;
        }
        public void Update()
        {
            List<Employee> employees = TxtRead();

            Console.Clear();
            Console.Write("Select the line: ");
            int lineIndex = Convert.ToInt32(Console.ReadLine());

            if (lineIndex < 1 && lineIndex > employees.Count)
            {
                Console.WriteLine("Invalid index");
                return;
            }

            Console.WriteLine("\nSelect a number you want to update");
            string[] fileProperties = { "Name", "Work Shift", "Category", "Minimum Wage", "Hours Worked" };

            for (int i = 0; i < fileProperties.Length; i++)
            {
                Console.WriteLine($"[{i+1}] {fileProperties[i]}");
            }

            Console.WriteLine("Response: ");
            int response = Convert.ToInt32(Console.ReadLine());
            
            if (response < 1 || response > fileProperties.Length)
            {
                Console.WriteLine("Invalid index");
                return;
            }

            Console.Write("Insert the altered information: ");
            string newInformation = Console.ReadLine()!.Trim();

            Employee property = employees[lineIndex - 1];

            switch (response)
            {
                case 1: 
                    property.Name = newInformation;
                    break;
                case 2:
                    property.WorkShift = newInformation;
                    break;
                case 3:
                    property.Category = newInformation;
                    break;
                case 4:
                    property.MinimumWage = Convert.ToDouble(newInformation);
                    break;
                case 5:
                    property.HoursWorkedPerMonth = Convert.ToDouble(newInformation);
                    break;
                default:
                    Console.WriteLine("Invalid response");
                    return;
            }

            TxtWriter(employees);
        }

        public void Delete()
        {
            List<Employee> employeeList = TxtRead();

            Console.Clear();
            Console.Write("Select the line: ");
            int lineIndex = Convert.ToInt32(Console.ReadLine());

            if (lineIndex < 1 && lineIndex > employeeList.Count)
            {
                Console.WriteLine("Invalid index");
                return;
            }

            Console.WriteLine("\nSelect a number you want the information to be deleted");
            string[] fileProperties = { "Name", "Work Shift", "Category", "Minimum Wage", "Hours Worked" };

            for (int i = 0; i < fileProperties.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] {fileProperties[i]}");
            }

            Console.Write("Response: ");
            int response = Convert.ToInt32(Console.ReadLine());

            //if (response < 1 || response > employees.Count)
            //{
            //    throw new Exception("Invalid response, insert a number based on the list range!");
            //}

            Employee property = employeeList[lineIndex - 1];
            
            switch (response)
            {
                case 1:
                    property.Name = null!;
                    break;
                case 2:
                    property.WorkShift = null!;
                    break;
                case 3:
                    property.Category = null!;
                    break;
                case 4:
                    property.MinimumWage = null;
                    break;
                case 5:
                    property.HoursWorkedPerMonth = null;
                    break;
                default:
                    Console.WriteLine("Invalid response");
                    return;
            }

            TxtWriter(employeeList);
        }
    }
}
