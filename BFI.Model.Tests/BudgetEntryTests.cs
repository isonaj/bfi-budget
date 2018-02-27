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
        public void CanConvertDayToYear()
        {
            var entry = new BudgetEntry(true, "Test", "Group", 1M, 1, Period.Day);
            var output = entry.ConvertTo(Period.Year);
            Assert.AreEqual(365.25M, output);
        }

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

        [TestMethod]
        public void CanConvertYearToDay()
        {
            var entry = new BudgetEntry(true, "Test", "Group", 1000M, 1, Period.Year);
            var output = entry.ConvertTo(Period.Day);

            Assert.AreEqual(2.74M, output);
        }

        [TestMethod]
        public void CanConvertMonthToDay()
        {
            var entry = new BudgetEntry(true, "Test", "Group", 1000M, 1, Period.Month);
            var output = entry.ConvertTo(Period.Day);

            Assert.AreEqual(32.85M, output);
        }

        [TestMethod]
        public void CanConvertWeekToDay()
        {
            var entry = new BudgetEntry(true, "Test", "Group", 1000M, 1, Period.Week);
            var output = entry.ConvertTo(Period.Day);

            Assert.AreEqual(142.37M, output);
        }
    }
}
