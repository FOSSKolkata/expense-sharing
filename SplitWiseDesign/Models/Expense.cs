using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWiseDesign.Models
{
    internal abstract class Expense
    {
        protected String id;
        protected double amount;
        protected User paidBy;
        protected List<Split> splits;

        public Expense(string id, double amount, User paidBy, List<User> sharedBy)
        {
            this.id = id;
            this.amount = amount;
            this.paidBy = paidBy;
            splits = new List<Split>();
            CalculateSplits(sharedBy);
        }

        public List<Split> Splits { get { return splits; } }

        public User PaidBy { get => paidBy; }

        public abstract void CalculateSplits(List<User> sharedBy);
    }
}
