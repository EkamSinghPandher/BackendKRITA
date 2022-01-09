using ITComm.Models;
using Microsoft.EntityFrameworkCore;
using SOC_IR.Model;

namespace SOC_IR.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<OTPToken> OTPTokens { get; set; }
        public DbSet<Activity> Activities { get; set; }
    }

}