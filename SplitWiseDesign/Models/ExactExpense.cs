using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWiseDesign.Models
{
    internal class ExactExpense : Expense
    {
        private List<double> exactAmounts;
        public ExactExpense(string id, double amount, User paidBy, List<User> sharedBy, List<double> exactAmounts)
            : base(id, amount, paidBy, sharedBy)
        {
            this.exactAmounts = exactAmounts;
        }

        public override void CalculateSplits(List<User> sharedBy)
        {
         
            // write the logic of equally splitting the amount
            throw new NotImplementedException();
        }
    }
}
