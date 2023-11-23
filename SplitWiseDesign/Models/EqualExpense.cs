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
            this.CalculateSplits(sharedBy);
        }

        public override void CalculateSplits(List<User> sharedBy)
        {

            if (sharedBy.Count == 0)
                throw new ArgumentException("Number of sharing users cannot be nil");

            double totalAmt = 0;
            for (int i = 0; i < sharedBy.Count; i++)
            {
                double amt = Math.Round(this.amount / sharedBy.Count, 2);
                totalAmt += amt;
                this.splits.Add(new Split(sharedBy[i], amt));
            }

            if (this.amount > totalAmt)
            {
                this.splits[0] = new Split(this.splits[0].SharedBy,
                    Math.Round(this.splits[0].Amount + (this.amount - totalAmt), 2));
            }
        }
    }
}
