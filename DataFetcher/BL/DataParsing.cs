using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataFetcher.Model;
using DataFetcher.Provider;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DataFetcher.BL
{
    public class DataParsing : IDataParsing
    {
        private readonly ILogProvider _logProvider;

        public DataParsing(ILogProvider _logProvider)
        {
            this._logProvider = _logProvider;
        }

        public List<Product> ToProductList(string data)
        {
            List<Product> result = new List<Product>();

            string jsonData = ClearJSONP(data);
            _logProvider.Info("JSON data extract from jsonp: " + jsonData);

            //Parse your data into a object.
            var dataObj = JObject.Parse(jsonData);
            var productListObj = dataObj["data"]["list"];
            result = JsonConvert.DeserializeObject<List<Product>>(productListObj.ToString());
            _logProvider.Info(String.Format("Parsed {0} products", jsonData));
            return result;
        }

        private string ClearJSONP(string data)
        {
            int callbackFuncStart = data.IndexOf("(");
            string jsonData = data.Remove(data.Length - 2).Remove(0, callbackFuncStart + 1);
            return jsonData;
        }
    }
}
