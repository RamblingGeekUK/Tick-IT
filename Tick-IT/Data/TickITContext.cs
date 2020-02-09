using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tick_IT.Models;

namespace Tick_IT.Data
{
    public class TickITContext : DbContext
    {
        public TickITContext(DbContextOptions<TickITContext> options)
            :base(options)
        {
        }

        public DbSet<Issue> Issues { get; set; }
        public DbSet<Response> Responses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("Issues_Number")
                .StartsAt(10001)
                .IncrementsBy(1);
            modelBuilder.Entity<Issue>()
            .Property(i => i.Issues_Number)
            .HasDefaultValueSql("NEXT VALUE FOR Issues_Number");

            modelBuilder.Entity<Response>()
                .HasOne(i => i.Issue)
                .WithMany(r => r.Responses);
        }

    }
}
