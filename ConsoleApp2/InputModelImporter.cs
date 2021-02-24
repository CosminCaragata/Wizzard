using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class InputModelImporter
    {
        public List<InputModel> ReadAll()
        {
            string source = "D:\\Test\\";
            List<InputModel> models = new List<InputModel>();

            models.Add(this.Read(source + "a.in"));
            models.Add(this.Read(source + "b.in"));
            models.Add(this.Read(source + "c.in"));
            models.Add(this.Read(source + "d.in"));
            models.Add(this.Read(source + "e.in"));

            return models;
        }



        public InputModel Read(string filename)
        {
            int counter = 0;
            string line;

            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(filename);

          //  string wholeFile = file.ReadToEnd();

            InputModel InputModel = new InputModel();
            string line1 = file.ReadLine();
            List<string> Splits = line1.Split(' ').ToList();

            InputModel.numbeOfPizzas = int.Parse(Splits[0]);
            InputModel.IngredientTypes = new List<string>();
            InputModel.Pizzas = new List<Pizza>();

            InputModel.Teams = new List<Team>();
            InputModel.Teams.Add(new Team()
            {
                NumberOfTeams = int.Parse(Splits[1]),
                TeamTypeNumber = 2
            });

            InputModel.Teams.Add(new Team()
            {
                NumberOfTeams = int.Parse(Splits[2]),
                TeamTypeNumber = 3
            });

            InputModel.Teams.Add(new Team()
            {
                NumberOfTeams = int.Parse(Splits[3]),
                TeamTypeNumber = 4

            });

            for (int i = 0; i < InputModel.numbeOfPizzas; i++)
            {
                line1 = file.ReadLine();
                var splits = line1.Split(' ');

                List<String> IncredientsOnPizza = new List<String>();
                for (int j = 1; j < int.Parse(splits[0]); j++)
                {
                    IncredientsOnPizza.Add(splits[j]);

                    if (!InputModel.IngredientTypes.Contains(splits[j]))
                    {
                        InputModel.IngredientTypes.Add(splits[j]);
                    }

                }

                InputModel.Pizzas.Add(new Pizza()
                {
                    NumberOfIncredients = int.Parse(splits[0]),
                    Ingredients = IncredientsOnPizza,
                    PizzaIndex = i
                }); ;
            }     

            file.Close();            
            return InputModel;
            

        }
 
    }
}
