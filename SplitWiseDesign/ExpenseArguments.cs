using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplitWiseDesign.Models;

namespace SplitWiseDesign
{
    internal class ExpenseArguments
    {
        public ExpenseType ExpenseType { get; set; }
        public User PaidBy { get; set; }
        public double Amount { get; set; }
        public List<User> SharedBy { get; set; }
        public List<double> ExactAmounts { get; set; } = new List<double>(); 
        public List<double> Percentages { get; set; } = new List<double>();
    }
}
