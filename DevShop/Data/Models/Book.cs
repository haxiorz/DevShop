using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevShop.Data.Models.JoinTables;

namespace DevShop.Data.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public string ImgPath { get; set; }
        public double UserScore { get; set; }
        public int NumberOfPages { get; set; }
        public DateTime Published { get; set; }
        public bool IsRecommended { get; set; }
        public bool IsOnLimitedSale { get; set; }
        public decimal? LimitedSalePrice { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
