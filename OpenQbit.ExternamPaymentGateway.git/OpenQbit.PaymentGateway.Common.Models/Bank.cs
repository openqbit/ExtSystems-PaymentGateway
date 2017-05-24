using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenQbit.PaymentGateway.Common.Models
{
    public class Bank
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public string CreaditCardSequence { get; set; }
    }
}
