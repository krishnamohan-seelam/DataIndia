using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataIndia.Models;

namespace DataIndia.Repository
{
    public class DataIndiaDbContext :DbContext
    {

        public DbSet<State> States;
        public DbSet<District> Districts;

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<State>().ToTable("State");
            modelBuilder.Entity<District>().ToTable("District");
            
            //one-to-many 
            
            modelBuilder.Entity<State>()
                .HasMany<District>( d => d.Districts)
                .WithRequired(s=> s.State)
                .HasForeignKey(s=>s.StateId);

        }
    }
}
