using Kabuwler.Infra;
using Kabuwler.Models;
using System.Collections.Generic;
using System.Linq;

namespace Kabuwler.DAO
{
    public class HomeDAO
    {
        public KabuwlerContext context { get; set; }

        public HomeDAO(KabuwlerContext context)
        {
            this.context = context;
        }
        public void AddProducts(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }
        public List<Product> List()
        {
            var lista = context.Products.ToList();
            return lista;
        }
    }
}
