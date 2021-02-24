using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            InputModelImporter inputModelImporter = new InputModelImporter();

            List<InputModel> inputModels = inputModelImporter.ReadAll();




        }


        public void ProcessInputModel(InputModel inputModel)
        {
            inputModel.Pizzas = inputModel.Pizzas.OrderByDescending(x => x.NumberOfIncredients).ToList();           

        }


        public static int GetPizzaScore(List<Pizza> pizzas)
        {
            return pizzas.Select(x => x.Ingredients).ToList().Distinct().Count();
        }

        public static int GetWasteScore(List<Pizza> pizzas)
        { 
            return pizzas.Select(x => x.Ingredients).Count() - pizzas.Select(x => x.Ingredients).ToList().Distinct().Count();
        }


    }
}
