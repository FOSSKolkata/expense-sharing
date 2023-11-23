using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWiseDesign.Models
{
    internal class EqualExpense : Expense
    {

        public EqualExpense(string id, double amount, User paidBy, List<User> sharedBy) 
            : base(id, amount, paidBy, sharedBy)
        {
        }

        public override void CalculateSplits(List<User> sharedBy)
        {
            // write the logic of equally splitting the amount
            throw new NotImplementedException();
        }
    }
}
