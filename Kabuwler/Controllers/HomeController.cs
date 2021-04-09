using HtmlAgilityPack;
using Kabuwler.DAO;
using Kabuwler.Models;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {            
            return View();
        }

        [HttpPost]
        public IActionResult ProductAdd(Product product)
        {
            dao.ProductAdd(product);
            return RedirectToAction("Index");
        }

        private static async Task StartCrawlerAsync()
        {
            var url = "https://www.kabum.com.br/";

            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var divs = htmlDocument.DocumentNode.Descendants("div")
                        .Where(node => node.GetAttributeValue("Id", "")
                        .Equals("pag-detalhes")).ToList();

            foreach(var div in divs)
            {
                var title =  div.Descendants("h1").FirstOrDefault().InnerText;
                var description = div.Descendants("div").Where(div => div.GetAttributeValue("class", "").Equals("content_tab")).FirstOrDefault().InnerText;

            }
        }
    }
}
