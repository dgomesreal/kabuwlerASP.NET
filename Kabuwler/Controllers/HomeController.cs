using HtmlAgilityPack;
using Kabuwler.DAO;
using Kabuwler.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Kabuwler.Controllers
{
    public class HomeController : Controller
    {
        private HomeDAO dao;

        public HomeController(HomeDAO dao)
        {
            this.dao = dao;
        }

        public ActionResult Index(Product product)
        {
            return View();
        }
        public async Task<ActionResult> ShowProducts(Product p)
        {
            var url = "https://www.kabum.com.br/";

            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var divs = htmlDocument.DocumentNode.Descendants("div")
                        .Where(node => node.GetAttributeValue("Id", "")
                        .Equals("pag-detalhes")).ToList();

            var productsList = new List<Product>();

            foreach (var div in divs)
            {
                var productItem = new Product
                {
                    Title = div?.Descendants("h1")?.FirstOrDefault()?.InnerText,
                    Description = div?.Descendants("div")?.FirstOrDefault()?.InnerText,
                    Price = div?.Descendants("div")?.FirstOrDefault()?.InnerHtml,
                    ImageURL = div?.Descendants("img")?.FirstOrDefault()?.ChildAttributes("src")?.FirstOrDefault()?.Value,
                    Comments = div?.Descendants("div")?.FirstOrDefault()?.InnerText
                };

                productsList.Add(productItem);
                dao.AddProducts(productItem);
            }

            List<Product> list = dao.List();

            return View("Result", list);
        }
    }
}
