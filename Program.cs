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

            //Logic flags
            bool programRunning = true;

            //Variables
            string cityName = "";

            //Initialise classes
            CitySearch citySearch = new CitySearch();

            //Initiealise cities list
            List<string> cities = new List<string>();

            //Add some data

            //Main program starts here.
            //All code written after this point is executed - unless its an exception.
            while (programRunning == true)
            {
                Console.Write("Please enter a city name: ");
                cityName = Console.ReadLine();

                citySearch.Search(cityName);

                //Return cities
                Console.WriteLine("Cities returned starting with {0}", cityName);
                Console.WriteLine("City List: a, b, c");

                //Return names
                Console.WriteLine("Next letters to use after your current search term {0}", cityName);
                Console.WriteLine("Character List: a, b, c");

            }
        }
    }

    class CitySearch : ICityFinder, ICityResult
    {
        public List<string> NextLetters { get; set; }
        public List<string> NextCities { get; set; }

        public void Search(string searchString)
        {
        }
    }
}


/// <summary>
/// Interfaces to use.
/// Included in the main search class.
/// </summary>

namespace CityFinder
{
    public interface ICityResult
    {
        List<string> NextLetters { get; set; }

        List<string> NextCities { get; set; }
    }
}

namespace CityFinder
{
    public interface ICityFinder
    {
        void Search(string searchString);
    }
}

