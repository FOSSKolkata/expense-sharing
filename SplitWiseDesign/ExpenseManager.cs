using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplitWiseDesign.Models;

namespace SplitWiseDesign
{
    internal class ExpenseManager
    {
        List<Expense> expenses;
        Dictionary<string, User> userMap;
        Dictionary<string, Dictionary<string, double>> balanceSheet;
        public ExpenseManager()
        {
            expenses = new List<Expense>();
            userMap = new Dictionary<string, User>();
            balanceSheet = new Dictionary<string, Dictionary<string, double>>();
        }

        public Dictionary<string, User> UserMap => userMap;

        public void AddUser(User user)
        {
            userMap.Add(user.Id, user);
            balanceSheet.Add(user.Id, new Dictionary<string, double>());
        }

        public void AddExpense(ExpenseArguments args)
        {
            Expense expense = ExpenseFactory.CreateExpense(args);

            expenses.Add(expense);
            string paidBy = expense.PaidBy.Id;
            foreach (Split split in expense.Splits)
            {
                string paidTo = split.SharedBy.Id;
                Dictionary<string, double> balances = balanceSheet[paidBy];
                if (!balances.ContainsKey(paidTo))
                {
                    balances.Add(paidTo, 0.0);
                }
                balances.Add(paidTo, balances[paidTo] + split.Amount);

                balances = balanceSheet[paidTo];
                if (!balances.ContainsKey(paidBy))
                {
                    balances.Add(paidBy, 0.0);
                }
                balances.Add(paidBy, balances[paidBy] - split.Amount);
            }
        }

        public void ShowBalance(string userId)
        {
            bool isEmpty = true;
            foreach (var userBalance in balanceSheet[userId])
            {
                if (userBalance.Value != 0)
                {
                    isEmpty = false;
                    PrintBalance(userId, userBalance.Key, userBalance.Value);
                }
            }

            if (isEmpty)
            {
                Console.WriteLine("No balances");
            }
        }


        public void ShowBalances()
        {
            bool isEmpty = true;
            foreach (var allBalances in balanceSheet)
            {
                foreach (var userBalance in allBalances.Value)
                {
                    if (userBalance.Value > 0)
                    {
                        isEmpty = false;
                        PrintBalance(allBalances.Key, userBalance.Key, userBalance.Value);
                    }
                }
            }

            if (isEmpty)
            {
                Console.WriteLine("No balances");
            }
        }

        private void PrintBalance(string user1, string user2, double amount)
        {
            string user1Name = userMap[user1].Name;
            string user2Name = userMap[user2].Name;
            if (amount < 0)
            {
                Console.WriteLine(user1Name + " owes " + user2Name + ": " + Math.Abs(amount));
            }
            else if (amount > 0)
            {
                Console.WriteLine(user2Name + " owes " + user1Name + ": " + Math.Abs(amount));
            }
        }
    }
}
