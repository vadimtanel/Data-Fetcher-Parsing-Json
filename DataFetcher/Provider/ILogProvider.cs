using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataFetcher.Provider
{
    public interface ILogProvider
    {
        void Info(String message);

        void Error(String message);

        void Worning(String message);
    }
}
