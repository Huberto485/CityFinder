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
            
            //Cities with L
            citySearch.cities.Add("London");
            citySearch.cities.Add("Lublin");
            citySearch.cities.Add("Lucca");
            citySearch.cities.Add("La Plata");
            citySearch.cities.Add("Lippen");
            citySearch.cities.Add("Leeds");

            //Cities with B
            citySearch.cities.Add("Birmingham");
            citySearch.cities.Add("Brussels");
            citySearch.cities.Add("Bremen");
            citySearch.cities.Add("Bialystok");
            citySearch.cities.Add("Barcelona");

            //Cities with D
            citySearch.cities.Add("Dresden");
            citySearch.cities.Add("Detroit");
            citySearch.cities.Add("Dortmund");
            citySearch.cities.Add("Dusseldorf");
            citySearch.cities.Add("Drawno");
            citySearch.cities.Add("Dublin");
            citySearch.cities.Add("Dover");

            //Sort cities into an alphabetical order
            citySearch.cities.Sort();

            //Main program starts here.
            //All code written after this point is executed - unless its an exception.
            while (programRunning == true)
            {
                //Wait for user input
                Console.Write("Please enter a city name: ");
                cityName = Console.ReadLine();

                //Use the search algorithm
                citySearch.Search(cityName);

                //Purge console when ready
                Console.ReadLine();
                Console.Clear();
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

            //Set a variable to hold city substring data
            string partSearch;

            //Use a linear search to find cities
            for (int i = 0; i < cities.Count(); i++ )
            {
                
                //Make sure words shorter than the search string are not included
                if (searchString.Length < cities[i].Length)
                {
                    partSearch = cities[i].Substring(0, searchString.Length);
                    
                    //Check if substring matches 
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
            }

            //Show a list of next characters the user can type
            if (NextLetters.Count() > 0 && NextLetters.Count() <= 5)
            {   
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
            }
            else if (NextLetters.Count() > 5)
            {
                Console.Write("Try typing next letters like ");

                for (int i = 0; i < 5; i++)
                {
                    if (i == 5 - 1)
                    {
                        Console.Write("'{0}'", NextLetters[i]);
                    }
                    else
                    {
                        Console.Write("'{0}', ", NextLetters[i]);
                    }
                }
            }
            else
            {
                //Show output if there are no characters to suggest
                Console.Write("\nThere are no character suggestions!");
            }

            //Show a list cities corresponding to user input
            if (NextCities.Count() > 0 && NextCities.Count() <= 5)
            {
                //Inform the user of cities
                Console.Write("\nCities to view are ");

                //Show all the exact cities
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
            }
            else if (NextCities.Count() > 5)
            {
                Console.Write("\nSome cities to view are ");

                //Output first 5 cities in the list
                for (int i = 0; i < 5; i++)
                {
                    if (i == 5 - 1)
                    {
                        Console.Write("'{0}'", NextCities[i]);
                    }
                    else
                    {
                        Console.Write("'{0}', ", NextCities[i]);
                    }
                }
            }
            else
            {
                //Show output if there are no cities to suggest
                Console.Write("\nThere are no city suggestions!");
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