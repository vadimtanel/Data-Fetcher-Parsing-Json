using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataFetcher.Provider
{
    public class FetchProvider : IFetchProvider
    {
        private readonly ILogProvider _logProvider;

        public FetchProvider(ILogProvider logProvider)
        {
            _logProvider = logProvider;
        }

        public async Task<string> Get(string url)
        {
            string result = null;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(url))
                    {
                        string statusCodeMessage = String.Format("Resposne with statusCode: {0} for url: {1}", res.StatusCode, url);
                        _logProvider.Info(statusCodeMessage);
                        using (HttpContent content = res.Content)
                        {
                            if (content != null)
                            {
                                result = await content.ReadAsStringAsync();
                                string message = String.Format("Fetched data from url: {0} , data: {1}", url, result);
                                _logProvider.Info(message);
                            }
                            else
                            {
                                _logProvider.Info("NO Data for url: " + url);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                string errorMessage = String.Format("Exception for url: {0} , exception: {1}", url, exception);
            }

            return result;
        }
    }
}
