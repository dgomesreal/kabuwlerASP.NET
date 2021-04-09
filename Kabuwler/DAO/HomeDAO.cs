using Kabuwler.Infra;
using Kabuwler.Models;

namespace Kabuwler.DAO
{
    public class HomeDAO
    {
        public KabuwlerContext context { get; set; }

        public HomeDAO(KabuwlerContext context)
        {
            this.context = context;
        }
        public void ProductAdd(Product add)
        {
            context.Products.Add(add);
            context.SaveChanges();
        } 
    }
}
