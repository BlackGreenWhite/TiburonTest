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
            modelBuilder.Entity<User>().HasIndex(i => i.UserIP).IsUnique();
            modelBuilder.Entity<Site>().HasIndex(i => i.Url).IsUnique();
            modelBuilder.Entity<Banner>().HasIndex(i => new { i.BannerUrl, i.BannerName }).IsUnique();
            modelBuilder.Entity<Statistic>().HasIndex(i => new { i.UserId, i.SiteBannerId }).IsUnique();
            modelBuilder.Entity<SiteBanner>().HasIndex(i => new { i.BannerId, i.SiteId }).IsUnique();

            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Statistic> Statistics { get; set; }
        public virtual DbSet<Banner> Banners { get; set; }
        public virtual DbSet<SiteBanner> SiteBanners { get; set; }
        public virtual DbSet<Site> Sites { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
