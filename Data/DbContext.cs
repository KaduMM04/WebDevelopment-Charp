using Microsoft.EntityFrameworkCore;
using ProjetoDBZ.Models;

namespace ProjetoDBZ.Data
{
    public class AppDbContext : DbContext {

        public AppDbContext(DbContextOptions options) : base(options) {}

        public DbSet<Character> Characters { get; set; }

    }
}