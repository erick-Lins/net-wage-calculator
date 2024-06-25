using ConsoleApp1;
using System.IO;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        
        Crud crud = new Crud();
        List<Employee> employees = crud.TxtRead();
        
        foreach (Employee e in employees)
        {
            e.ShowInfosAbouJob();
        }

        Console.WriteLine("Type 1 to Update");
        Console.WriteLine("Type 2 to Delete");

        int response = Convert.ToInt32(Console.ReadLine());

        switch (response)
        {
            case 1:
                crud.Update();
                break;
            case 2:
                crud.Delete();
                break;
            default:
                throw new Exception("Insert a valid option you fucker");
        }

        //adding a comment to test github XOxo! 
    }
}

