using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SplitWiseDesign.Models
{
    internal class PercentExpense : Expense
    {
        private List<double> percentages;
        public PercentExpense(string id, double amount, User paidBy, List<User> sharedBy, List<double> percentages)
            : base(id, amount, paidBy, sharedBy)
        {
            this.percentages = percentages;
        }

        public override void InitSplits()
        {
            if (sharedBy.Count != percentages.Count)
                throw new ArgumentException("The number of percentages does not match with number of users");

            if (sharedBy.Count == 0)
                throw new ArgumentException("Number of sharing users cannot be nil");
            
            double totalPercentage = 0;
            foreach(double percentage in percentages)
            {
                totalPercentage += percentage;
            }

            if (totalPercentage != 100.0) throw new ArgumentException("Invalid percentages");
            
            double totalAmt = 0;
            for(int i = 0; i < percentages.Count; i++)
            {
                double amt = Math.Round(this.amount * percentages[i] / 100.0, 2);
                totalAmt += amt;
                this.splits.Add(new Split(sharedBy[i], amt));
            }

            if(this.amount > totalAmt)
            {
                this.splits[0] = new Split(this.splits[0].SharedBy,
                    Math.Round(this.splits[0].Amount + (this.amount - totalAmt), 2));
            }
        }
    }
}
