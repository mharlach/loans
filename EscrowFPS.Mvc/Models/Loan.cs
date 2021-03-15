using System;
using System.ComponentModel.DataAnnotations;

namespace EscrowFPS.Mvc.Models
{
    public class Loan
    {
        [Required]
        public Guid Id { get; set; }
        public string LoanNumber { get; set; }
        public string Name { get; set; } 
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public string State { get; set; }
        public string Status { get; set; }
        public string Product { get; set; }
        public string LTV { get; set; }
        public int LockDays { get; set; }
        public DateTime Expires { get; set; }

    }
}
