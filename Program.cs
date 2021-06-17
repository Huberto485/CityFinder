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
            bool testing = false;

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
                if (testing == true)
                {
                    //Some simple unit testing
                    //Test 1 - List populated
                    try
                    {
                        if (citySearch.cities.Count() != -1)
                        {
                            Console.WriteLine("Test 1 - Pass");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Test 1 - Fail");
                    }

                    //Test 2 - Last value
                    try
                    {
                        if (citySearch.cities[citySearch.cities.Count - 1] != null)
                        {
                            Console.WriteLine("Test 2 - Pass");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Test 2 - Fail");
                    }

                    //Test 3 - First value
                    try
                    {
                        if (citySearch.cities[0] != null)
                        {
                            Console.WriteLine("Test 3 - Pass");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Test 3 - Fail");
                    }

                    //Test 4 - Lower out of bounds
                    try
                    {
                        if (citySearch.cities[-1] != null)
                        {
                            Console.WriteLine("Test 4 - Fail");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Test 4 - Pass");
                    }

                    //Test 5 - Upper out of bounds
                    try
                    {
                        if (citySearch.cities[citySearch.cities.Count] != null)
                        {
                            Console.WriteLine("Test 5 - Fail");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Test 5 - Pass");
                    }

                    //Test 6 - Valid search input
                    try
                    {
                        citySearch.Search("London");

                        Console.WriteLine("Test 6 - Pass");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Test 6 - Fail");
                    }

                    //Test 7 - Invalid search input
                    try
                    {
                        citySearch.Search("Germany");

                        Console.WriteLine("Test 7 - Pass");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Test 7 - Fail");
                    }

                    //Test 8 - NextLetters size is 0
                    try
                    {
                        if (citySearch.NextLetters.Count() != 0)
                        {
                            Console.WriteLine("Test 8 - Fail");
                        }

                        Console.WriteLine("Test 8 - Pass");

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Test 8 - Fail");
                    }

                    //Test 9 - NextCities size is 0
                    try
                    {
                        if (citySearch.NextCities.Count() != 0)
                        {
                            Console.WriteLine("Test 9 - Fail");
                        }

                        Console.WriteLine("Test 9 - Pass");

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Test 9 - Fail");
                    }

                    //Test 10 - Add value "Hamburg" to cities and search "Ham"
                    //Expected output is "b" and "Hamburg"
                    try
                    {
                        citySearch.cities.Add("Hamburg");
                        citySearch.Search("Ham");
                        Console.WriteLine("Test 10 - Pass");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Test 10 - Fail");
                    }

                }

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
                        //Assign the letter after substring to a variable
                        string letter = cities[i].Substring(searchString.Length, 1);

                        NextCities.Add(cities[i]);

                        //Check for pre-existing entries of same letter
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