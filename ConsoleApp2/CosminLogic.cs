using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class CosminLogic
    {
        public static void Process(InputModel inputModel)
        {
            CreteIntersection(inputModel);
        }


        public static void CreteIntersection(InputModel inputModel)
        {
            inputModel.Intersections = new List<Intersection>();
            for (int i = 0; i < inputModel.NumberOfIntersections; i++)
            {
                inputModel.Intersections.Add(new Intersection()
                {
                    StreetsWhichGoToIntersection = new List<Street>(),
                    StreetsWhichStartFromIntersection = new List<Street>(),
                    IntersectionNumnber = i,
                    LightStatus = LightStatus.Red
                }) ;
            }
            foreach (var street in inputModel.StreetsInProblem)
            {
                inputModel.Intersections[street.StartingIntersection].StreetsWhichStartFromIntersection.Add(street);
                inputModel.Intersections[street.EndingIntersection].StreetsWhichGoToIntersection.Add(street);
            }

            GameOn(inputModel);
        }


        public static void GameOn(InputModel inputModel)
        {
            OutputModel outputModel = new OutputModel(inputModel);
            outputModel.inputModel = inputModel;
            var Simulation = new Simulation();
            Simulation.InputModel = inputModel;

            foreach (var inter in inputModel.Intersections)
            {
                Simulation.SimulationIntersectionOrders.Add(new SimulationIntersectionOrder()
                {
                    Intersection = inter,
                    SelectedStreet = inter.StreetsWhichGoToIntersection.First()
                });
            }

            for (int i = 0; i < inputModel.DurationOfSimulation; i++)
            {
                foreach (var intersectionInSimulation in Simulation.SimulationIntersectionOrders)
                {
                    int index = intersectionInSimulation.Intersection.StreetsWhichGoToIntersection.IndexOf(intersectionInSimulation.SelectedStreet);
                    index = (index + 1) % intersectionInSimulation.Intersection.StreetsWhichGoToIntersection.Count;
                    intersectionInSimulation.SelectedStreet = intersectionInSimulation.Intersection.StreetsWhichGoToIntersection[index];

                    outputModel.OutputIntersections[intersectionInSimulation.Intersection.IntersectionNumnber].ordersOnIntersections.Add(new OrderOnIntersection()
                    {
                        duration = 1,
                        street = intersectionInSimulation.SelectedStreet
                    });
                }
            }

            //squashTime
            foreach (var outputIntersection in outputModel.OutputIntersections)
            {
                string lastStreetName = string.Empty;
                for (int i = 0; i < outputIntersection.ordersOnIntersections.Count() - 1; )
                {
                    string currentStreetName = outputIntersection.ordersOnIntersections[i].street.StreetName;
                    if (outputIntersection.ordersOnIntersections[i + 1].street.StreetName == currentStreetName)
                    {
                        outputIntersection.ordersOnIntersections[i].duration += outputIntersection.ordersOnIntersections[i + 1].duration;
                        outputIntersection.ordersOnIntersections.Remove(outputIntersection.ordersOnIntersections[i + 1]);
                    }
                    else
                    { i++; }
                }

            }

        }


        public class Simulation
        {
            public InputModel InputModel;

            public int TickNumber;

            public List<SimulationIntersectionOrder> SimulationIntersectionOrders = new List<SimulationIntersectionOrder>();
        }

        public class SimulationIntersectionOrder
        {            
            public Street SelectedStreet;
            public Intersection Intersection;
            public int TimeElapsedUnchanged;
        }
    }
}
