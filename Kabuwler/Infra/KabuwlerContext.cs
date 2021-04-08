using Microsoft.EntityFrameworkCore;

namespace Kabuwler.Infra
{
    public class KabuwlerContext : DbContext
    {
        public KabuwlerContext(DbContextOptions<KabuwlerContext> options) : base(options) { }
    }
}
