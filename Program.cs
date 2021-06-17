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
            
            citySearch.cities.Add("Lachen");
            citySearch.cities.Add("Lauswitz");
            citySearch.cities.Add("Lattens");
            citySearch.cities.Add("La Plata");
            citySearch.cities.Add("Lippen");
            citySearch.cities.Add("Leeds");

            //Main program starts here.
            //All code written after this point is executed - unless its an exception.
            while (programRunning == true)
            {
                Console.Write("Please enter a city name: ");
                cityName = Console.ReadLine();

                citySearch.Search(cityName);
            }
        }
    }

    class CitySearch : ICityFinder, ICityResult
    {
        public List<string> cities = new List<string>();

        public List<string> NextLetters { get; set; }
        public List<string> NextCities { get; set; }

        public void Search(string searchString)
        {
            //Initialise NextLetters and NextCities lists
            NextLetters = new List<string>();
            NextCities = new List<string>();

            for (int i = 0; i < cities.Count(); i++ )
            {
                string partSearch = "";
                partSearch = cities[i].Substring(0, searchString.Length);

                if (string.Equals(searchString, partSearch))
                {
                    string letter = cities[i].Substring(searchString.Length, 1);

                    NextCities.Add(cities[i]);

                    if (NextLetters.Contains(letter) == false)
                    {
                        NextLetters.Add(letter);
                    }
                }
            }

            Console.Write("Try typing next letters like ");

            for (int i = 0; i < NextLetters.Count(); i++)
            {
                if (i == NextLetters.Count() - 1)
                {
                    Console.Write("'{0}'", NextLetters[i]);
                }
                else
                {
                    Console.Write("'{0}', ", NextLetters[i]);
                }
            }

            Console.Write("\nCities to view are ");

            for (int i = 0; i < NextCities.Count(); i++)
            {
                if (i == NextCities.Count() - 1)
                {
                    Console.Write("'{0}'", NextCities[i]);
                }
                else
                {
                    Console.Write("'{0}', ", NextCities[i]);
                }
            }

            Console.Write("\n");
        }
    }
    
    public interface ICityResult
    {
        List<string> NextLetters { get; set; }

        List<string> NextCities { get; set; }
    }

    public interface ICityFinder
    {
        void Search(string searchString);
    }
}