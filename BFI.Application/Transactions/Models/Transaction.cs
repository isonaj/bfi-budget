using System;
using System.Collections.Generic;
using System.Text;

namespace BFI.Application.Transactions.Models
{
    public class Transaction
    {
        public string Account { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }

    }
}
