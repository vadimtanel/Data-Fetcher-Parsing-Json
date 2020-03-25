using DataFetcher.BL;
using DataFetcher.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataFetcher.Provider
{
    public class ProductProvider : IProductProvider
    {
        private readonly ILogProvider _logProvider;
        private readonly IFetchProvider _fetchProvider;
        private readonly IDataParsing _dataParsing;

        public ProductProvider(ILogProvider _logProvider, IFetchProvider _fetchProvider, IDataParsing _dataParsing)
        {
            this._logProvider = _logProvider;
            this._fetchProvider = _fetchProvider;
            this._dataParsing = _dataParsing;
        }

        public async Task<List<Product>> GetProduct()
        {
            List<Product> result = new List<Product>();
            string url = $"https://insights.alibaba.com/openservice/gatewayService?deliveryId=&modelId=500&categoryIds=7&cardId=&deliveryBomId=&appKey=vee8meczxjj3hugfjlmg0t4zh4skimd3&appName=asinHomePage&offerLimit=2&pageSize=20&pageNo=1&pageId=546f6dd60b565d575e6f4caa170e2c37ae61a42d7c&topOfferIds=&endpoint=pc&__bb_name__=a27aq.13891069_%2F%2Finsights.alibaba.com%2Fopenservice%2FgatewayService_500&__bb_rate__=100&__bb_level__=1&currency=ILS&pageDeduplicateId=eywffwptmxqcavrv1584352426168225a7fdc2ed16&callback=jsonp_1584352428179_41615&_=1584352428179";
            //Have your using statements within a try/catch block

            string dataResponse = await _fetchProvider.Get(url);
            if (dataResponse == null)
            {
                _logProvider.Info("No products fetch for url: " + url);

            } else {
                result = _dataParsing.ToProductList(dataResponse);
            }

            return result;
        }
    }
}
