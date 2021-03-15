using EscrowFPS.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.Linq;

namespace EscrowFPS.Mvc.Services
{
    public interface ILoanService
    {
        Task<IEnumerable<Loan>> GetAsync(IEnumerable<string> loanIds);

        Task<HttpStatusCode> Unlock(IEnumerable<UnlockRequest> loans);

        Task<HttpStatusCode> ExtendLockAsync(IEnumerable<ExtendLockRequest> loans);
    }

    public class FakeLoanService : ILoanService
    {
        public async Task<HttpStatusCode> ExtendLockAsync(IEnumerable<ExtendLockRequest> loans)
        {
            return HttpStatusCode.OK;
        }

        public async Task<IEnumerable<Loan>> GetAsync(IEnumerable<string> loanIds)
        {
            var loans = loanIds.Select(x => new Loan
            {
                Id = Guid.NewGuid(),
                Name = $"Loan {x}",
                Rate = 2,
                Amount = 500000,
                State = "Blah",
                Status = "Blah",
                Product = "Blah",
                LTV = "Blah",
                LockDays = 2,
                Expires = DateTime.Today.AddDays(2),
            });

            return loans;
        }

        public async Task<HttpStatusCode> Unlock(IEnumerable<UnlockRequest> loans)
        {
            return HttpStatusCode.OK;
        }
    }
}
