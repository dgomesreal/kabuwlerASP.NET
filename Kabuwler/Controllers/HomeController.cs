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

        private static List<Product> list;
        public HomeController(HomeDAO dao)
        {
            this.dao = dao;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> ShowProducts(Product p)
        {
            //Get thread
            var url = @"https://www.kabum.com.br/"; 
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);


            //Html Parser
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var divs = htmlDocument.DocumentNode.Descendants("div")
                        .Where(node => node.GetAttributeValue("class", "")
                        .Equals("versions-item")).ToList();

            foreach (var div in divs)
            {
                var productItem = new Product
                {
                    Title = div?.Descendants("h2")?.FirstOrDefault()?.InnerText,
                    Description = div?.Descendants("div")?.FirstOrDefault()?.InnerText,
                    Price = div?.Descendants("div")?.FirstOrDefault()?.InnerText,
                    ImageURL = div?.Descendants("img")?.FirstOrDefault()?.ChildAttributes("src")?.FirstOrDefault()?.Value,
                    Comments = div?.Descendants("div")?.FirstOrDefault()?.InnerText
                };

                list.Add(productItem);
                
            }

            dao.AddProducts(p);

            list = dao.List();

            return View("Result", list);
        }
    }
}
