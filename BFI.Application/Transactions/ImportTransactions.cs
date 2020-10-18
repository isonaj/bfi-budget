using BFI.Application.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BFI.Application.Transactions
{
    public class ImportTransactions: IRequest<Unit>
    {
        Stream _stream;
        public ImportTransactions(Stream stream)
        {
            _stream = stream;
        }

        public class ImportTransactionsHandler: IRequestHandler<ImportTransactions>
        {
            BFIDbContext _db;

            public ImportTransactionsHandler(BFIDbContext db)
            {
                _db = db;
            }

            public async Task<Unit> Handle(ImportTransactions request, CancellationToken cancellationToken)
            {
                using (var reader = new StreamReader(request._stream))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {

                        line = reader.ReadLine();
                    }
                }

                await _db.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
