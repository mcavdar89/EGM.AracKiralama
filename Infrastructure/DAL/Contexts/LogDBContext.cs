using Infra.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.DAL.Contexts
{
    public class LogDBContext : DbContext
    {
        public LogDBContext(DbContextOptions<LogDBContext> options) : base(options)
        {

        }
        public virtual DbSet<LogTable> LogTable { get; set; }
        public virtual DbSet<ErrorLogTable> ErrorLogTable { get; set; }



    }
}
