using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpenQubit.PaymentGateway.Presentation.Web.Controllers
{
    public class transactionOnlineController : Controller
    {
        // GET: transactionOnline
        public ActionResult OnlinePayment()
        {
            return View();
        }
    }
}