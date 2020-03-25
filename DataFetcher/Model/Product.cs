using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataFetcher.Model
{
    public class Product
    {
        public string productId { get; set; }
        public string subject { get; set; }
        public string image { get; set; }
        public string moqUnit { get; set; }
        public string trackInfo { get; set; }
        public string moq { get; set; }
        public string detailWap { get; set; }
        public string promotionMoq { get; set; }
        public string price { get; set; }
        public string minPrice { get; set; }
        public string detail { get; set; }
    }
}
