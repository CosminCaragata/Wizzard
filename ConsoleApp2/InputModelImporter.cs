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

            models.Add(this.Read(source + "a.txt"));
            models.Add(this.Read(source + "b.txt"));
            models.Add(this.Read(source + "c.txt"));
            models.Add(this.Read(source + "d.txt"));
            models.Add(this.Read(source + "e.txt"));
            models.Add(this.Read(source + "f.txt"));

            return models;
        }



        public InputModel Read(string filename)
        {
            int counter = 0;
            string line;

            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(filename);

            string wholeFile = file.ReadToEnd();

            var lineSplits = wholeFile.Split('\n');
            int index = 0;

            InputModel inputModel = new InputModel();

            var lineSplit = lineSplits[0].Split(' ');
            inputModel.DurationOfSimulation = int.Parse(lineSplit[0]);
            inputModel.NumberOfIntersections = int.Parse(lineSplit[1]);
            inputModel.NumberOfStreets = int.Parse(lineSplit[2]);
            inputModel.numberOfCars = int.Parse(lineSplit[3]);
            inputModel.BonusPoints = int.Parse(lineSplit[4]);



            for (int i = 0; i < inputModel.NumberOfStreets; i++)
            {
                index++;
                var intersectionSplits = lineSplits[index].Split(' ');
                inputModel.StreetsInProblem.Add(new Street()
                {
                    StartingIntersection = int.Parse(intersectionSplits[0]),
                    EndingIntersection = int.Parse(intersectionSplits[1]),
                    StreetName = intersectionSplits[2],
                    TimeToCross = int.Parse(intersectionSplits[3])
                }); ;
            }

            for (int i = 0; i < inputModel.numberOfCars; i++)
            {
                index++;
                var carSplits = lineSplits[index].Split(' ');

                var pathOfCAr = new PathOfCar()
                {
                    CardIndexNumber = i,
                    NumberOfStreetsOnCar = carSplits.Length - 1,
                    StreetsOnPath = new List<Street>()
                };


                for (int j = 1; j < carSplits.Length; j++)
                {
                    pathOfCAr.StreetsOnPath.Add(inputModel.StreetsInProblem.First(x => x.StreetName == carSplits[j]));
                }

                inputModel.PathsOfCars.Add(pathOfCAr);
            }

            file.Close();
            return inputModel;
        }

    }
}
