using EGM.AracKiralama.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGM.AracKiralama.DAL.Contexts
{
    public class LogDBContext : DbContext
    {
        public LogDBContext(DbContextOptions<LogDBContext> options) : base(options)
        {

        }
        public virtual DbSet<LogTable> LogTable { get; set; }



    }
}
