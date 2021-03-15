namespace EscrowFPS.Mvc.Models
{
    public class UnlockLoanItem : Loan
    {
        public UnlockLoanItem()
        {

        }

        public UnlockLoanItem(Loan l)
        {
            this.Id = l.Id;
            this.Name = l.Name;
            this.Rate = l.Rate;
            this.Amount = l.Amount;
            this.State = l.State;
            this.Status = l.Status;
            this.Product = l.Product;
            this.LTV = l.LTV;
            this.LockDays = l.LockDays;
            this.Expires = l.Expires;
        }

        public bool Selected { get; set; }
    }
}
