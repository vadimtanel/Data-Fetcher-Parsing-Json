using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataFetcher.Provider
{
    public class LogProvider : ILogProvider
    {
        public void Error(string message)
        {
            Console.WriteLine("Error: "+  message);
        }

        public void Info(string message)
        {
            Console.WriteLine("Information: " + message);
        }

        public void Worning(string message)
        {
            Console.WriteLine("Worning: " + message);
        }
    }
}
