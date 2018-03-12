using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace BFI.Model.Tests
{
    [TestClass]
    public class BudgetTests
    {
        [TestMethod]
        public void CanAddBudgetEntry()
        {
            var budget = new Budget(Guid.NewGuid(), Period.Week);
            budget.AddEntry(new BudgetEntry(true, "Test", "Group", 2M, 1, Period.Week));

            Assert.AreEqual(1, budget.BudgetEntries.Count());
        }

        [TestMethod]
        public void CanSumIncome()
        {
            var budget = new Budget(Guid.NewGuid(), Period.Week);
            budget.AddEntry(new BudgetEntry(true, "Test", "Group", 2M, 1, Period.Week));
            budget.AddEntry(new BudgetEntry(true, "Test", "Group", 3M, 1, Period.Week));

            Assert.AreEqual(5M, budget.Total);
        }

        [TestMethod]
        public void CanSumExpenses()
        {
            var budget = new Budget(Guid.NewGuid(), Period.Week);
            budget.AddEntry(new BudgetEntry(false, "Test", "Group", 2M, 1, Period.Week));
            budget.AddEntry(new BudgetEntry(false, "Test", "Group", 3M, 1, Period.Week));

            Assert.AreEqual(-5M, budget.Total);
        }
    }
}
