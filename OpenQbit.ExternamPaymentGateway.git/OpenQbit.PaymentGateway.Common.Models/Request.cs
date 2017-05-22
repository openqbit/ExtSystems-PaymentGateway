using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenQbit.PaymentGateway.Common.Models
{
    public class Request
    {
        public int RequestId { get; set; }
        public string CreaditCardNo { get; set; }
        public string CreaditCardCCV { get; set; }
        public string CreaditCardName { get; set; }        
        public DateTime ExpiaryDate { get; set; }
        public double Amount { get; set; }
        public DateTime RequestTime { get; set; }
        public string IPAddress { get; set; }

        public int MarchantId { get; set; }

        public int ResponceId { get; set; }
        public virtual Merchant Marchant { get; set; }
        public virtual Responce Responce { get; set; }
    }
}
