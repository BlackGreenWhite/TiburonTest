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
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=TiburonTestDb;Username=postgres;Password=123qq321");
        //}

        public virtual DbSet<Statistic> Statistics { get; set; }
        public virtual DbSet<Banner> Banners { get; set; }
        public virtual DbSet<SiteBanner> SiteBanners { get; set; }
        public virtual DbSet<Site> Sites { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
