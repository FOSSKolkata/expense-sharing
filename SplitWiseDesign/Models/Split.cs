namespace SplitWiseDesign.Models
{
    internal class Split
    {
       
        private readonly User sharedBy;
        private readonly double amount;

        public Split(User sharedBy, double amount)
        {
            this.sharedBy = sharedBy;
            this.amount = amount;
        }

        public User SharedBy { get {  return sharedBy; } }
        public double Amount { get { return amount; } }
    }
}