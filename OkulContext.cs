using Microsoft.EntityFrameworkCore;
using OkulSistemi.Models;

namespace OkulSistemi
{
    public class OkulContext : DbContext
    {
        public OkulContext(DbContextOptions<OkulContext> options) : base(options) { }

        public DbSet<Kullanici> Kullanicilar { get; set; }
    }
}
