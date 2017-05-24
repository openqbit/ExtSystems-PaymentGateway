﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenQbit.PaymentGateway.Common.Models
{
    public class Responce
    {
        public int Id { get; set; }
        public string status { get; set; }
        public string MessageDetails { get; set; }
        public DateTime RespondTime { get; set; }

        public int RequestId { get; set; }
        
        public virtual Request Request { get; set; }
        
    }
}
