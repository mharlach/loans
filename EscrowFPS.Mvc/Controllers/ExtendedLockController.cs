using EscrowFPS.Mvc.Models;
using EscrowFPS.Mvc.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace EscrowFPS.Mvc.Controllers
{
    public class ExtendedLockController : Controller
    {
        private ILoanService loanService;
        private ILogger<ExtendedLockController> log;

        public ExtendedLockController(ILoanService loanService, ILogger<ExtendedLockController> log)
        {
            this.loanService = loanService;
            this.log = log;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("Index", new ExtendedLockViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Search(ExtendedLockViewModel state)
        {
            var parsedRequest = state.LoanSearch
                .Split(new[] { Environment.NewLine, " ", ",", ";" }, StringSplitOptions.RemoveEmptyEntries)
                .Distinct();
            var loans = await loanService.GetAsync(parsedRequest);
            state.Loans = loans.Select(x => new ExtendedLoanItem(x) { ExtendDate = x.Expires }).ToList();

            return View("Index", state);
        }

        [HttpPost]
        public async Task<IActionResult> ExtendedLock(ExtendedLockViewModel state)
        {
            var requests = state.Loans
                .Where(x => x.Selected && x.ExtendDate > x.Expires)
                .Select(x => new ExtendLockRequest
            {
                LoanId = x.Id,
                ExtendDate = x.ExtendDate,
            });

            var response = await loanService.ExtendLockAsync(requests);

            return View("Index", state);
        }


    }
}
