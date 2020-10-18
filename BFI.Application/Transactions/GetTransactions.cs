using BFI.Application.Data;
using BFI.Application.Transactions.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BFI.Application.Transactions
{
    public class GetTransactions: IRequest<List<Transaction>>
    {
        public class GetTransactionsHandler: IRequestHandler<GetTransactions, List<Transaction>>
        {
            BFIDbContext _db;

            public GetTransactionsHandler(BFIDbContext db)
            {
                _db = db;
            }

            public async Task<List<Transaction>> Handle(GetTransactions request, CancellationToken cancellationToken)
            {
                return await _db.Transactions
                    .Select(t => new Transaction
                    { 
                        Account = t.Account,
                        Date = t.Date,
                        Description = t.Description,
                        Amount = t.Amount,
                    })
                    .ToListAsync(cancellationToken);
            }
        }
    }
}
