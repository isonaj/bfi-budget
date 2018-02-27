using System;
using System.Collections.Generic;
using System.Linq;

namespace BFI.Model
{
    public class Budget : IEntity<Guid>
    {
        public Guid Id { get; }
        public Period Period { get; }
        private List<BudgetEntry> _budgetEntries = new List<BudgetEntry>();
        public IEnumerable<BudgetEntry> BudgetEntries { get { return _budgetEntries; } }

        public decimal Total { get { return BudgetEntries.Select(e => (e.Income ? 1M : -1M) * e.ConvertTo(Period)).Sum(); } }

        public Budget(Guid id, Period period)
        {
            Id = id;
            Period = period;
        }

        public void AddEntry(BudgetEntry entry)
        {
            _budgetEntries.Add(entry);
        }

        public void RemoveEntry(BudgetEntry entry)
        {
            _budgetEntries.Remove(entry);
        }
    }
}
