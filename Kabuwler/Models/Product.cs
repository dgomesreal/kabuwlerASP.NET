using System.ComponentModel.DataAnnotations.Schema;

namespace Kabuwler.Models
{
    [Table("PRODUCT")] public class Product
    {
        public int ProductID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string Comments { get; set; }
        public string Price { get; set; }
        public string CrawlerVar{ get; set; }
    }
}
