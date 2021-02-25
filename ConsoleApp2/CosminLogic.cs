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
        }


        public static void GameOn(InputModel inputModel)
        {
            OutputModel outputModel = new OutputModel();
            outputModel.InputModel = inputModel;
            var Simulation = new Simulation();
            Simulation.InputModel = inputModel;

            foreach (var inter in inputModel.Intersections)
            {
                Simulation.SimulationIntersectionOrders.Add(new SimulationIntersectionOrder()
                {
                //    IntersectionNumber = inter.IntersectionNumnber,
                    SelectedStreet = inter.StreetsWhichGoToIntersection.First()
                });
            }

            for (int i = 0; i < inputModel.DurationOfSimulation; i++)
            {
                Simulation.TickNumber++;

                

                outputModel.IntersectionOrders.Add(new IntersectionOrders()
                {
                 //   intersection 
                });
            }

        }


        public class Simulation
        {
            public InputModel InputModel;

            public int TickNumber;

            public List<SimulationIntersectionOrder> SimulationIntersectionOrders;
        }

        public class SimulationIntersectionOrder
        {            
            public Street SelectedStreet;
            public Intersection intersection;
        }
    }
}
