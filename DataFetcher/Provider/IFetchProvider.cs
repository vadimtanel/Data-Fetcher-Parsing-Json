using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataFetcher.Provider
{
    public interface IFetchProvider
    {
        Task<string> Get(String url);
    }
}
