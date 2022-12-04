using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace tv_series_app.Models
{

    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<TVSeries> TVSeries { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TVSeries>()
            .Property<string>("UserId");

            modelBuilder.Entity<TVSeries>()
                .HasOne(tv => tv.User)
                .WithMany(u => u.TVSeries)
                .HasForeignKey(p => p.UserId);



        }
    }
}

