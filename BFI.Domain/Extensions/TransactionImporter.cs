using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BFI.Domain.Extensions
{
    public static class TransactionImporters
    {
        public static IEnumerable<Transaction> ToTransactions(this Stream stream, string name)
        {
            using (var reader = new StreamReader(stream))
            {
                var header = reader.ReadLine();
                if (header == "!Type:Bank")
                    return LoadQifTransactions(reader, name);
                else if (header == "OFXHEADER:100")
                    return LoadOfxTransactions(reader, name);

                throw new Exception("Unknown file type");
            }
        }

        private static IEnumerable<Transaction> LoadQifTransactions(StreamReader reader, string name)
        {
            var result = new List<Transaction>();

            long lineNo = 1;
            string date = "";
            string description = "";
            string amount = "";
            while (!reader.EndOfStream)
            {
                var row = reader.ReadLine();
                lineNo++;
                switch(row[0])
                {
                    case 'D': date = row.Substring(1); break;
                    case 'P': description = row.Substring(1); break;
                    case 'T': amount = row.Substring(1); break;
                    case '^':
                        result.Add(new Transaction
                        {
                            Account = name,
                            Date = DateTime.Parse(date),
                            Description = description,
                            Amount = Decimal.Parse(amount)
                        });

                        date = "";
                        description = "";
                        amount = "";
                        break;
                    default:
                        throw new Exception("Unknown record on line: {lineNo}");
                }
            }
            return result;
        }

        private static IEnumerable<Transaction> LoadOfxTransactions(StreamReader reader, string name)
        {
            var result = new List<Transaction>();

            long lineNo = 1;
            string date = "";
            string description = "";
            string amount = "";
            string reference = "";
            while (!reader.EndOfStream)
            {
                var row = reader.ReadLine();
                lineNo++;
                if (row == "</STMTTRN>")
                {
                    result.Add(new Transaction
                    {
                        Account = name,
                        Date = DateTime.ParseExact(date.Substring(0, 8), "yyyyMMdd", null),
                        Description = description,
                        Amount = Decimal.Parse(amount)
                    });

                    date = "";
                    description = "";
                    amount = "";
                }
                else if (row.Length >= 6 && row.Substring(0, 6) == "<MEMO>")
                    description = row.Substring(6);
                else if (row.Length >= 10 && row.Substring(0, 10) == "<DTPOSTED>")
                    date = row.Substring(10);
                else if (row.Length >= 8 && row.Substring(0, 8) == "<TRNAMT>")
                    amount = row.Substring(8);
                else if (row.Length >= 7 && row.Substring(0, 7) == "<FITID>")
                    reference = row.Substring(7);
            }
            return result;
        }
    }
}
