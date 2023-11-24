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

        public override void InitSplits()
        {

            if (sharedBy.Count != exactAmounts.Count)
                throw new ArgumentException("The number of exact amounts does not match with number of users");

            if (sharedBy.Count == 0)
                throw new ArgumentException("Number of sharing users cannot be nil");

            double totalAmt = 0;
            foreach (double exactAmt in exactAmounts)
            {
                totalAmt += exactAmt;
            }

            if (totalAmt != this.amount) throw new ArgumentException("Invalid exact amounts");


            for (int i = 0; i < sharedBy.Count; i++)
            {
                this.splits.Add(new Split(sharedBy[i], exactAmounts[i]));
            }
        }
    }
}
