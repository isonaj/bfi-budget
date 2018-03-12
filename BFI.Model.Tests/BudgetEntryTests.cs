using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BFI.Model.Tests
{
    [TestClass]
    public class BudgetEntryTests
    {
        [TestMethod]
        public void CanConvertWeekToYear()
        {
            var entry = new BudgetEntry(true, "Test", "Group", 1M, 1, Period.Week);
            var output = entry.ConvertTo(Period.Year);

            Assert.AreEqual(52M, output);
        }

        [TestMethod]
        public void CanConvertMonthToYear()
        {
            var entry = new BudgetEntry(true, "Test", "Group", 1M, 1, Period.Month);
            var output = entry.ConvertTo(Period.Year);

            Assert.AreEqual(12M, output);
        }
    }
}
