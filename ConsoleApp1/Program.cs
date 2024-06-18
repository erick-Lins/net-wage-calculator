using System.IO;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        /*Employee erickLins = new Employee("Erick","Matutinal", "Operator", 350, 80);
        Employee robertoCarrara = new Employee("Roberto Carrara","Vespertine", "Manager", 490, 65);
        //erickLins.PrintInformation();
        //ShowInfosAbouJob(erickLins);

        Console.WriteLine(erickLins.Serialize());
        Employee[] employeeList = { erickLins, robertoCarrara };
        TxtWriter(employeeList);*/
        Employee[] employee = TxtRead().ToArray();

        foreach (Employee e in employee)
        {
            e.ShowInfosAbouJob();
        }

        //adding a comment to test github XOxo! 
    }

    public static void TxtWriter(Employee[] employeeList)
    {
        string path = "C:\\Users\\clone\\OneDrive\\Área de Trabalho\\teste.txt";
        
        using (StreamWriter sw = new StreamWriter(path))
        {
            foreach (Employee employee in employeeList)
            {
                sw.WriteLine(employee.Serialize());
            }
        }

        Console.WriteLine($"File wrote succesfully");
    }

    public static List<Employee> TxtRead()
    {
        List<Employee> employeeList = new List<Employee>();
        string path = "C:\\Users\\clone\\OneDrive\\Área de Trabalho\\teste.txt";
        StreamReader sr = new StreamReader(path);
        
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            string[] arrayTest = line.Split(',');
            employeeList.Add(new Employee(arrayTest[0], arrayTest[1], arrayTest[2], Convert.ToDouble(arrayTest[3]), Convert.ToDouble(arrayTest[4])));
        }
        return employeeList;
    }
}

