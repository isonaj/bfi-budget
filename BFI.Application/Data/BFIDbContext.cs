using BFI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BFI.Application.Data
{
    public class BFIDbContext: DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }

        public BFIDbContext(DbContextOptions<BFIDbContext> options) : base(options) { }
    }
}
