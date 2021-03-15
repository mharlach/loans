using System.Collections.Generic;

namespace EscrowFPS.Mvc.Models
{
    public class ExtendedLockViewModel
    {
        public string LoanSearch { get; set; } = string.Empty;

        public string ErrorMessage { get; set; } = string.Empty;

        public List<ExtendedLoanItem> Loans { get; set; } = new List<ExtendedLoanItem>();
    }
}
