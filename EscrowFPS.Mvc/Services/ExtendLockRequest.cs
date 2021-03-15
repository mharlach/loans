using System;

namespace EscrowFPS.Mvc.Services
{
    public class ExtendLockRequest
    {
        public Guid LoanId { get; set; }

        public DateTime ExtendDate { get; set; }
    }
}
