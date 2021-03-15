using EscrowFPS.Mvc.Models;
using EscrowFPS.Mvc.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace EscrowFPS.Mvc.Controllers
{
    public class UnlockController: Controller
    {
        private ILoanService loanService;
        private ILogger<UnlockController> log;

        public UnlockController(ILoanService loanService, ILogger<UnlockController> log)
        {
            this.loanService = loanService;
            this.log = log;
        }

        public IActionResult Index()
        {
            return View("Index", new UnlockViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Search(UnlockViewModel state)
        {
            var parsedRequest = state.LoanSearch
                .Split(new[] { Environment.NewLine, " ", ",", ";" }, StringSplitOptions.RemoveEmptyEntries)
                .Distinct();

            var loans = await loanService.GetAsync(parsedRequest);
            state.Loans = loans.Select(x => new UnlockLoanItem(x)).ToList();

            return View("Index", state);
        }

        [HttpPost]
        public async Task<IActionResult> Unlock(UnlockViewModel state)
        {
            var requests = state.Loans
                .Where(x => x.Selected)
                .Select(x => new UnlockRequest
                {
                    LoanId = x.Id
                });

            var response = await loanService.Unlock(requests);
            return View("Index", state);
        }
    }
}
