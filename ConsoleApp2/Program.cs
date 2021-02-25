using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            InputModelImporter inputModelImporter = new InputModelImporter();
            List<InputModel> inputModels = inputModelImporter.ReadAll();

            ProcessInputModel(inputModels[1]);
        }


        public static void ProcessInputModel(InputModel inputModel)
        {
            CosminLogic.Process(inputModel);

        }

        public static void ProcessMatches(int margin, InputModel inputModel, int numberOfIncredientsOnPizzaOne, int numberOfIncredientsOnPizzaTwo)
        {

        }
 
    }
}
