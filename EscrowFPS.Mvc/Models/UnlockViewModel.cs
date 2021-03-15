using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EscrowFPS.Mvc.Models
{
    public class UnlockViewModel
    {
        public string LoanSearch { get; set; } = string.Empty;

        [Description("Error Message")]
        public string ErrorMessage { get; set; } = string.Empty;

        public List<UnlockLoanItem> Loans { get; set; } = new List<UnlockLoanItem>();
    }
}
