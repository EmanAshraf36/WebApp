using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.ViewComponents
{
    [ViewComponent]
    public class TransactionsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string userName)
        {
            //Console.WriteLine(userName);
            var transactions = TransactionsRepository.GetByDayAndCashier(userName, DateTime.Now);
            //Console.WriteLine(transactions);
            return View(transactions);
        }
    }
}