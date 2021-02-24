using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class InputModel
    {
        public int numbeOfPizzas;
        public List<Team> Teams;
        public List<String> IngredientTypes;
        public List<Pizza> Pizzas;
        
    }

    public  class Team
    {
        public int TeamNumber;
        public int NumberOfTeams;
    }

    public class Pizza
    {
        public int NumberOfIncredients;
        public List<String> Ingredients;
        public int PizzaIndex;
    }
}
