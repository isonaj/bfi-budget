using Xunit;

using BFI.Domain.Extensions;

using System.IO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BFI.Domain.Tests.Extensions
{
    public class TransactionImporterTests
    {
        [Fact]
        public void CanFailUnknownData()
        {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes("Random Data"));

            Assert.Throws<Exception>(() => stream.ToTransactions("test"));
        }

        [Fact]
        public void CanAcceptQifData()
        {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes("!Type:Bank\n"));

            var txns = stream.ToTransactions("test");

            Assert.Empty(txns);
        }

        [Fact]
        public void CanReadQifDataRow()
        {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(@"!Type:Bank
D19/04/2019
PDESCRIPTION - Internal Transfer - Receipt 12345 Savings Maximiser 0123456789
T-66.77
^
"));

            var txns = stream.ToTransactions("test").ToList();

            Assert.Single(txns);
            Assert.Equal(new DateTime(2019, 4, 19), txns[0].Date);
            Assert.Equal("DESCRIPTION - Internal Transfer - Receipt 12345 Savings Maximiser 0123456789", txns[0].Description);
            Assert.Equal(-66.77M, txns[0].Amount);
        }

        [Fact]
        public void CanReadTwoQifDataRow()
        {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(@"!Type:Bank
D19/04/2019
PDESCRIPTION - Internal Transfer - Receipt 12345 Savings Maximiser 0123456789
T-66.77
^
D20/04/2019
PDESCRIPTION TWO - Internal Transfer - Receipt 12346 Savings Maximiser 0123456789
T-77.66
^
"));

            var txns = stream.ToTransactions("test").ToList();

            Assert.Equal(2, txns.Count);
            Assert.Equal(new DateTime(2019, 4, 19), txns[0].Date);
            Assert.Equal("DESCRIPTION - Internal Transfer - Receipt 12345 Savings Maximiser 0123456789", txns[0].Description);
            Assert.Equal(-66.77M, txns[0].Amount);
            Assert.Equal(new DateTime(2019, 4, 20), txns[1].Date);
            Assert.Equal("DESCRIPTION TWO - Internal Transfer - Receipt 12346 Savings Maximiser 0123456789", txns[1].Description);
            Assert.Equal(-77.66M, txns[1].Amount);
        }

        [Fact]
        public void CanAcceptOfxData()
        {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes("OFXHEADER:100\n"));

            var txns = stream.ToTransactions("test");

            Assert.Empty(txns);
        }

        [Fact]
        public void CanReadOfxDataRow()
        {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(@"OFXHEADER:100
DATA:OFXSGML
<OFX>
<SIGNONMSGSRSV1>
<SONRS>
<STATUS>
<CODE>0
<SEVERITY>INFO
</STATUS>
<DTSERVER>20190419170955
<LANGUAGE>ENG
</SONRS>
</SIGNONMSGSRSV1>
<BANKMSGSRSV1>
<STMTTRNRS>
<TRNUID>1
<STATUS>
<CODE>0
<SEVERITY>INFO
</STATUS>
<STMTRS>
<CURDEF>AUD
<BANKTRANLIST>
<STMTTRN>
<TRNTYPE>DEBIT
<DTPOSTED>20190419000000
<TRNAMT>-66.77
<FITID>12345
<MEMO>DESCRIPTION - Internal Transfer - Receipt 12345 Savings Maximiser 0123456789
</STMTTRN>
"));

            var txns = stream.ToTransactions("test").ToList();

            Assert.Single(txns);
            Assert.Equal(new DateTime(2019, 4, 19), txns[0].Date);
            Assert.Equal("DESCRIPTION - Internal Transfer - Receipt 12345 Savings Maximiser 0123456789", txns[0].Description);
            Assert.Equal(-66.77M, txns[0].Amount);
        }
    }
}
