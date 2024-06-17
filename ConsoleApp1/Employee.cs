public class Employee
{
    public string WorkShift { get; set; }
    public string Category { get; set; }
    public double MinimumWage { get; set; }
    public double HoursWorkedPerMonth { get; set; }
    private double GrossSalary { get; set; }

    public Employee(string workShift, string category, double minimumWage, double hoursWorkedPerMonth)
    {
        WorkShift = workShift;
        Category = category;
        MinimumWage = minimumWage;
        HoursWorkedPerMonth = hoursWorkedPerMonth;
    }

    public void PrintInformation()
    {
        Console.WriteLine($"\n-Work Shift: {WorkShift}");
        Console.WriteLine($"Category: {Category}");
        Console.WriteLine($"Minimum Wage: {MinimumWage:C2}");
        Console.WriteLine($"Hours worked per month: {HoursWorkedPerMonth} hours");
    }

    public double CalculateCoefficient()
    {
        return WorkShift == "Matutinal" ? (10 * MinimumWage / 100) :
               WorkShift == "Vespertine" ? (15 * MinimumWage / 100) :
               WorkShift == "Nocturnal" ? (12 * MinimumWage / 100) :
               0;
    }

    public double CalculateGrossSalary()
    {
        double coefficient = CalculateCoefficient();
        GrossSalary = coefficient * HoursWorkedPerMonth;
        return GrossSalary;
    }

    public static double CalculateTax(double grossSalary, string category)
    {
        if (category == "Operator")
        {
            return grossSalary >= 300 ? (5 *  grossSalary) /100 : (3 * grossSalary) /100;
        }

        if (category == "Manager")
        {
            return grossSalary >= 400 ? (6 * grossSalary) /100 : (4 * grossSalary) /100;
        }

        return 0;
    }

    public double CalculateGratification()
    {
        return WorkShift == "Nocturnal" && HoursWorkedPerMonth >= 80 ? 50 : 30;
    }

    public double CalculateMealAllowance()
    {
        double coefficient = CalculateCoefficient();
        return Category == "Operator" || coefficient <= 25 ? (GrossSalary / 3) : (GrossSalary / 2);
    }

    public double CalculateNetWage(double grossSalary, double taxes,
        double gratification, double mealAllowance)
    {
        return grossSalary - taxes + gratification + mealAllowance;
    }

    public void ShowInfosAbouJob()
    {
        double grossSalary = CalculateGrossSalary();

        Console.WriteLine($"Coefficient: {CalculateCoefficient():C2}");
        Console.WriteLine($"\nGross Salary: {grossSalary:C2}");

        double taxAmount = CalculateTax(grossSalary,Category);
        Console.WriteLine($"Taxes: {taxAmount:C2}");

        double gratification = CalculateGratification();
        Console.WriteLine($"Gratification: {gratification:C2}");

        double mealAllowance = CalculateMealAllowance();
        Console.WriteLine($"Meal Allowance: {mealAllowance:C2}");

        double netWage = CalculateNetWage(grossSalary, taxAmount, gratification, mealAllowance);
        Console.WriteLine($"=====\nTotal Net Wage: {netWage:C2}");
    }

    
}