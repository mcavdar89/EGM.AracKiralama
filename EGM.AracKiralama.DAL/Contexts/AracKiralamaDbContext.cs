using EGM.AracKiralama.Model.Entities;
using Infra.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGM.AracKiralama.DAL.Contexts
{
    public class AracKiralamaDbContext : DbContext
    {
        public AracKiralamaDbContext(DbContextOptions<AracKiralamaDbContext> options) : base(options)
        {

        }

        public DbSet<Brand> Brand { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<LogTable> LogTable { get; set; }
        public DbSet<PersonelSepet> PersonelSepet { get; set; }
        public DbSet<MiktarTur> MiktarTur { get; set; }
        public DbSet<Urun> Urun { get; set; }
        public DbSet<Unvan> Unvan { get; set; }
        public DbSet<Birim> Birim { get; set; }
        public DbSet<Personel> Personel { get; set; }
        public DbSet<PersonelSepetUrun> PersonelSepetUrun { get; set; }
        public DbSet<Market> Market { get; set; }
        public DbSet<MarketUrun> MarketUrun { get; set; }



        //Tablo ismiyle entity ismi aynı olmak zorunda değil
        public virtual DbSet<BrandModel> Model { get; set; }




    }
}
