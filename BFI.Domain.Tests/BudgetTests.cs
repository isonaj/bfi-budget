using System;
using System.Linq;
using Xunit;

using BFI.Domain;

namespace BFI.Domain.Tests
{
    public class BudgetTests
    {
        [Fact]
        public void CanAddBudgetEntry()
        {
            var budget = new Budget(Guid.NewGuid(), Period.Week);
            budget.AddEntry(new BudgetEntry(true, "Test", "Group", 2M, 1, Period.Week));

            Assert.Single(budget.BudgetEntries);
        }

        [Fact]
        public void CanSumIncome()
        {
            var budget = new Budget(Guid.NewGuid(), Period.Week);
            budget.AddEntry(new BudgetEntry(true, "Test", "Group", 2M, 1, Period.Week));
            budget.AddEntry(new BudgetEntry(true, "Test", "Group", 3M, 1, Period.Week));

            Assert.Equal(5M, budget.Total);
        }

        [Fact]
        public void CanSumExpenses()
        {
            var budget = new Budget(Guid.NewGuid(), Period.Week);
            budget.AddEntry(new BudgetEntry(false, "Test", "Group", 2M, 1, Period.Week));
            budget.AddEntry(new BudgetEntry(false, "Test", "Group", 3M, 1, Period.Week));

            Assert.Equal(-5M, budget.Total);
        }
    }
}
