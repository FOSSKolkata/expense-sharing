using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplitWiseDesign.Models;

namespace SplitWiseDesign
{
    internal class ExpenseFactory
    {
        // What benefit am I getting, making it a generic function. Even the generic type parameter needs to 
        // be decided by the caller based on user inputs. This code also has conditional logic. So why to 
        // conditional logic at two places. 
        // I think the factory should recieve parameters which are user input agnostic. Now in the 
        // factory only we can have coditionl logic that would decide which subclass of Expense needs to
        // be instantiated.
        internal static Expense CreateExpense(ExpenseArguments args)
        {
            Expense? expense = null;
            switch (args.ExpenseType)
            {
                case ExpenseType.EQUAL:
                    expense = new EqualExpense(Guid.NewGuid().ToString(), args.Amount, args.PaidBy, args.SharedBy);
                    break;
                case ExpenseType.EXACT:
                    expense = new ExactExpense(Guid.NewGuid().ToString(), args.Amount, args.PaidBy, args.SharedBy, args.ExactAmounts);
                    break;
                case ExpenseType.PERCENT:
                    expense = new PercentExpense(Guid.NewGuid().ToString(), args.Amount, args.PaidBy, args.SharedBy, args.Percentages);
                    break;
                default:
                    throw new ArgumentException("Ivalid expense arguments");
            }

            expense.InitSplits();
            return expense;
        }
    }
}
