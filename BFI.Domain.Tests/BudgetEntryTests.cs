using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

using BFI.Domain;

namespace BFI.Domain.Tests
{
    public class BudgetEntryTests
    {
        [Fact]
        public void CanConvertWeekToYear()
        {
            var entry = new BudgetEntry(true, "Test", "Group", 1M, 1, Period.Week);
            var output = entry.ConvertTo(Period.Year);

            Assert.Equal(52M, output);
        }

        [Fact]
        public void CanConvertMonthToYear()
        {
            var entry = new BudgetEntry(true, "Test", "Group", 1M, 1, Period.Month);
            var output = entry.ConvertTo(Period.Year);

            Assert.Equal(12M, output);
        }
    }
}
