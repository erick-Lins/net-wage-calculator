
class Program
{
    static void Main(string[] args)
    {
        Employee erickLins = new Employee("Matutinal", "Operator", 350, 80);
        Employee robertoCarrara = new Employee("Vespertine", "Manager", 490, 65);
        //erickLins.PrintInformation();
        //ShowInfosAbouJob(erickLins);

        robertoCarrara.PrintInformation();
        robertoCarrara.ShowInfosAbouJob();
    }
}