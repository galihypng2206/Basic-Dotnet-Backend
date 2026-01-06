using KeretaApiBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace KeretaApiBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Kereta> Keretas => Set<Kereta>();
        public DbSet<Tiket> Tikets => Set<Tiket>();
        public DbSet<Test> Tests => Set<Test>();
    }
}