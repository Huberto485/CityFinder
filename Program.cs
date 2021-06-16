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

            //Main program starts here.
            //All code written after this point is executed - unless its an exception.
            while (programRunning == true)
            {
                Console.Write("Please enter a city name: ");
                cityName = Console.ReadLine();

                //citySearch.Search(cityName);

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
            try
            {
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while searching for cities!");
            }

            //Simple error message
            Console.WriteLine("Invalid input!");
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

