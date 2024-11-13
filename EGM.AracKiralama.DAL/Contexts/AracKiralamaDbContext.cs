using EGM.AracKiralama.Model.Entities;
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

        public virtual DbSet<Brand> Brand { get; set; }

        //Tablo ismiyle entity ismi aynı olmak zorunda değil
        public virtual DbSet<BrandModel> Model { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }

        public virtual DbSet<LogTable> LogTable { get; set; }



    }
}
