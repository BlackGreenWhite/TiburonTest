using Microsoft.EntityFrameworkCore;
using Storage.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Storage
{
    public class TiburonTestApiContext: DbContext
    {
        public TiburonTestApiContext(DbContextOptions<TiburonTestApiContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasAlternateKey(u => u.UserIP);
        }
        public virtual DbSet<Statistic> Statistics { get; set; }
        public virtual DbSet<Banner> Banners { get; set; }
        public virtual DbSet<SiteBanner> SiteBanners { get; set; }
        public virtual DbSet<Site> Sites { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
