using DataFetcher.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataFetcher.Provider
{
    public interface IProductProvider
    {
        Task<List<Product>> GetProduct();
    }
}
