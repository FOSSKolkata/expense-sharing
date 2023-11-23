using SplitWiseDesign.Models;

namespace SplitWiseDesign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ExpenseManager expenseManager = new ExpenseManager();

            expenseManager.AddUser(new User("u1", "User1", "gaurav@workat.tech", "9876543210"));
            expenseManager.AddUser(new User("u2", "User2", "sagar@workat.tech", "9876543210"));
            expenseManager.AddUser(new User("u3", "User3", "hi@workat.tech", "9876543210"));
            expenseManager.AddUser(new User("u4", "User4", "mock-interviews@workat.tech", "9876543210"));

            while (true)
            {
                String command = Console.ReadLine();
                String[] commands = command.Split(" ");
                String commandType = commands[0];

                switch (commandType)
                {
                    case "SHOW":
                        if (commands.Length == 1)
                        {
                            expenseManager.ShowBalances();
                        }
                        else
                        {
                            expenseManager.ShowBalance(commands[1]);
                        }
                        break;
                    case "EXPENSE":
                        String paidBy = commands[1];
                        Double amount = Double.Parse(commands[2]);
                        int noOfUsers = Int32.Parse(commands[3]);
                        String expenseType = commands[4 + noOfUsers];
                  
                        switch (expenseType)
                        {
                            case "EQUAL":
                                {
                                    List<User> sharedBy = new List<User>();
                                    for (int i = 0; i < noOfUsers; i++)
                                    {
                                        sharedBy.Add(expenseManager.UserMap[commands[4 + i]]);
                                    }
                                    ExpenseArguments expenseArguments = new ExpenseArguments();
                                    expenseArguments.ExpenseType = ExpenseType.EQUAL;
                                    expenseArguments.PaidBy = expenseManager.UserMap[paidBy];
                                    expenseArguments.Amount = amount;
                                    expenseArguments.SharedBy = sharedBy;
                                    expenseManager.AddExpense(expenseArguments);
                                }
                                break;
                            
                            case "EXACT":
                                {
                                    List<User> sharedBy = new List<User>();
                                    List<double> exactAmounts = new List<double>();
                                    for (int i = 0; i < noOfUsers; i++)
                                    {
                                        sharedBy.Add(expenseManager.UserMap[commands[4 + i]]);
                                        exactAmounts.Add(double.Parse(commands[5 + noOfUsers + i]));
                                    }
                                    ExpenseArguments expenseArguments = new ExpenseArguments();
                                    expenseArguments.ExpenseType = ExpenseType.EXACT;
                                    expenseArguments.PaidBy = expenseManager.UserMap[paidBy];
                                    expenseArguments.Amount = amount;
                                    expenseArguments.SharedBy = sharedBy;
                                    expenseArguments.ExactAmounts = exactAmounts;
                                    expenseManager.AddExpense(expenseArguments);
                                }
                                break;
                            
                            case "PERCENT":
                                {
                                    List<User> sharedBy = new List<User>();
                                    List<double> percentages = new List<double>();
                                    for (int i = 0; i < noOfUsers; i++)
                                    {
                                        sharedBy.Add(expenseManager.UserMap[commands[4 + i]]);
                                        percentages.Add(double.Parse(commands[5 + noOfUsers + i]));
                                    }
                                    ExpenseArguments expenseArguments = new ExpenseArguments();
                                    expenseArguments.ExpenseType = ExpenseType.PERCENT;
                                    expenseArguments.PaidBy = expenseManager.UserMap[paidBy];
                                    expenseArguments.Amount = amount;
                                    expenseArguments.SharedBy = sharedBy;
                                    expenseArguments.Percentages = percentages;
                                    expenseManager.AddExpense(expenseArguments);
                                }
                                break;
                        }
                        break;
                }
            }
        }
    }
}