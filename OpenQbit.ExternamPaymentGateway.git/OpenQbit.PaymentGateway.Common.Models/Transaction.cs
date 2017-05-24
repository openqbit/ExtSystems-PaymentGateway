using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenQbit.PaymentGateway.Common.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int Amount { get; set; }

        public DateTime TransactionTime { get; set; }

        public int BankId { get; set; }
        public int ResponceId { get; set; }

        public virtual Responce Responce { get; set; }
        public virtual Bank Bank { get; set; }

    }
}
