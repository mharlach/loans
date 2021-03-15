using System;

namespace EscrowFPS.Mvc.Models
{
    public class ExtendedLoanItem : Loan
    {
        public ExtendedLoanItem()
        {

        }

        public ExtendedLoanItem(Loan loan)
        {
            this.Id = loan.Id;
            this.Name = loan.Name;
            this.Rate = loan.Rate;
            this.Amount = loan.Amount;
            this.State = loan.State;
            this.Status = loan.Status;
            this.Product = loan.Product;
            this.LTV = loan.LTV;
            this.LockDays = loan.LockDays;
            this.Expires = loan.Expires;
        }

        public bool Selected { get; set; }

        public DateTime ExtendDate { get; set; }
    }
}
