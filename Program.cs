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
            CitySearch citySearch = new CitySearch();

            citySearch.Search(" ");
        }
    }

    class CitySearch : ICityFinder, ICityResult
    {
        public ICollection<string> NextLetters { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); 
        }

        public ICollection<string> NextCities { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); 
        }

        public ICityResult Search(string searchString)
        {
            while (1 > 0)
            {
                Console.Write("Enter a city name: ");
                searchString = Console.ReadLine();

                Console.WriteLine("You entered {0}", searchString);
            }
            

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

