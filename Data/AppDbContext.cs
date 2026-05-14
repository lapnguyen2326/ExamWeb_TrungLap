using Microsoft.EntityFrameworkCore;
using ExamWeb_TrungLap.Models;

namespace ExamWeb_TrungLap.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<DiaNhac> DiaNhacs { get; set; }
    }
}
