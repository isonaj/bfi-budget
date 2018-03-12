using System;
using System.Collections.Generic;
using System.Text;

namespace BFI.Model
{
    public class BudgetEntry : IEntity<int>
    {
        public int Id { get; }
        public bool Income { get; private set; }
        public string Description { get; private set; }
        public string Group { get; private set; }
        public decimal Amount { get; private set; }
        public int PeriodQty { get; private set; }
        public Period Period { get; private set; }

        public BudgetEntry(bool income, string description, string group, decimal amount, int periodQty, Period period)
        {
            Income = income;
            Description = description;
            Group = group;
            Amount = amount;
            PeriodQty = periodQty;
            Period = period;
        }

        public decimal ConvertTo(Period period)
        {
            decimal amount = Amount;
            switch (Period)
            {
                case Period.Week: amount = amount * 52; break;
                case Period.Month: amount = amount * 12; break;
            }
            amount = amount / PeriodQty;
            switch (period)
            {
                case Period.Week: amount = amount / 52; break;
                case Period.Month: amount = amount / 12; break;
            }

            return Math.Round(amount, 2);
        }
    }
}
