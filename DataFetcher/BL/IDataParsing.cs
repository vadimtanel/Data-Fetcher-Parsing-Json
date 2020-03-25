using DataFetcher.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataFetcher.BL
{
    public interface IDataParsing
    {
        List<Product> ToProductList(String data);
    }
}
