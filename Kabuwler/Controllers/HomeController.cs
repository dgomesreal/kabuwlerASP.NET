using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Kabuwler.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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
