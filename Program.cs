using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            CitySearch search = new CitySearch();
        }
    }

    class CitySearch : ICityFinder
    {
        public ICityResult Search(string searchString)
        {
            throw new NotImplementedException();
        }
    }
}

namespace CityFinder
{
    public interface ICityResult
    {
        ICollection<string> NextLetters { get; set; }

        ICollection<string> NextCities { get; set; }
    }
}

namespace CityFinder
{
    public interface ICityFinder
    {
        ICityResult Search(string searchString);
    }
}

