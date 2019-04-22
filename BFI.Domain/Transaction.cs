using System;
using System.Collections.Generic;
using System.Text;

namespace BFI.Domain
{
    public class Transaction
    {
        public long Id { get; set; }
        public string Account { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}
