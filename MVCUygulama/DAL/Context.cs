using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using MVCUygulama.Models;

namespace MVCUygulama.DAL
{
    public class Context:DbContext
    {
        //Veritabanı tablolar
        public DbSet<MYazar> MYazars { get; set;}
        public DbSet <kitap>kitaps { get; set; }
        public DbSet<Ogrenci> ogrencis { get; set; }
        public DbSet<Ders>ders { get; set; }

        //1'e-Çok İlişki oluşturma 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {   
            modelBuilder.Entity<kitap>()
                .HasRequired<MYazar>(k => k.MYazar)
                .WithMany(y => y.kitaps)
                .HasForeignKey<int>(k => k.YazarID);
        }

        //Çoka Çok İlişki Oluşturma
        /*
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ogrenci>()
                .HasMany<Ders>(o => o.ders)
                .WithMany(d => d.ogrencis);
        }*/

    }
    
}