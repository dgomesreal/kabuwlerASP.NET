using Kabuwler.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kabuwler.Infra
{
    public class KabuwlerContext : DbContext
    {
        public KabuwlerContext(DbContextOptions<KabuwlerContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}
