using System.Collections;

Console.WriteLine("\t \t \t \t \t  Welcome to Expense tracker");
Console.WriteLine("\t \t \t \t \t...............................");
int start;
do
{
    Console.WriteLine("Write 1 to run the program or 0 to end the program");
    start = int.Parse(Console.ReadLine());
    if (start == 1)
    {
        ArrayList entries = new ArrayList();
        int amount = 0;
        string description = "";
        string date = "";
        int totalAmount = 0;
        do
        {
            Console.WriteLine("Type 1,2,3,4 for Add,Edit,Delete,View expense entries respectivly.");
            int choice = 0;
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Write the description of the new expense that you want to add.");
                    try
                    {
                        description = Console.ReadLine();
                        if (description.Length == 0)
                            throw new Exception("Invalid Empty description");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    try
                    {
                        Console.WriteLine("Write the amount you want to add");
                        amount = int.Parse(Console.ReadLine());
                        if (amount < 0)
                            throw new Exception("Invalid Number");
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    Console.WriteLine("Write the date");
                    date = Console.ReadLine();
                    if (date.Length != 10 || date[2] != '/' || date[5] != '/')
                    {
                        Console.WriteLine("Invalid Date");
                    }

                    AddExpense(entries, amount, description, date);
                    totalAmount += amount;
                    break;

                case 2:
                    Console.WriteLine("Write 1 to change amount, 2 for description, 3 for date");
                    int input = int.Parse(Console.ReadLine());
                    if (input == 1 && entries.Count > 0)
                    {
                        int oldAmount = amount;
                        Console.WriteLine("Write the new value");
                        amount = int.Parse(Console.ReadLine());
                        EditExpenseAmount(entries, amount, oldAmount);

                        if (amount < oldAmount) totalAmount -= oldAmount - amount;
                        else if (amount > oldAmount) totalAmount += amount - oldAmount;
                    }
                    else if (input == 2 && entries.Count > 0)
                    {
                        string oldDescription = description;
                        Console.WriteLine("Write the new value");
                        description = Console.ReadLine();
                        EditExpenseDescription(entries, description, oldDescription);
                    }
                    else if (input == 3 && entries.Count > 0)
                    {
                        string oldDate = date;
                        Console.WriteLine("Write the new value");
                        date = Console.ReadLine();
                        EditExpenseDate(entries, date, oldDate);
                    }
                    else Console.WriteLine("Invalid input");
                    break;

                case 3:
                    Console.WriteLine("Write the amount you want to delete");
                    int deleteAmount = int.Parse(Console.ReadLine());

                    Console.WriteLine("Write the description you want to delete");
                    string deleteDescription = Console.ReadLine();

                    Console.WriteLine("Write the date you want to delete");
                    string deleteDate = Console.ReadLine();
                    DeleteExpense(entries, deleteAmount, deleteDescription, deleteDate);
                    break;

                case 4:
                    ViewExpenses(entries);
                    break;
                default:
                    Console.WriteLine("Invalid!");
                    break;
            }
            Console.WriteLine("Total amount spent = " + totalAmount);

            Console.WriteLine("To end type 0, To continue type any other number.");
            start = int.Parse(Console.ReadLine());

        } while (start != 0);
    }



}
while (start != 0 && start != 1);


// Functions
static ArrayList AddExpense(ArrayList exp, int amount, string description, string date)
{
    exp.Add(amount);
    exp.Add(description);
    exp.Add(date);
    return exp;

}
static ArrayList EditExpenseAmount(ArrayList exp, int amount, int oldAmount)
{
    int index = exp.IndexOf(oldAmount);
    exp[index] = amount;
    return exp;
}
static ArrayList EditExpenseDescription(ArrayList exp, string description, string oldDescription)
{
    int index = exp.IndexOf(oldDescription);
    exp[index] = description;
    return exp;
}
static ArrayList EditExpenseDate(ArrayList exp, string date, string oldDate)
{
    int index = exp.IndexOf(oldDate);
    exp[index] = date;
    return exp;
}
static ArrayList DeleteExpense(ArrayList exp, int amount, string description, string date)
{
    exp.Remove(amount);
    exp.Remove(description);
    exp.Remove(date);
    return exp;
}
static void ViewExpenses(ArrayList exp)
{
    for (int i = 0; i < exp.Count; i++)
    {
        Console.Write(exp[i] + " ");
        if (i % 3 == 0 && i != 0)
            Console.WriteLine();
    }
    Console.WriteLine();
}