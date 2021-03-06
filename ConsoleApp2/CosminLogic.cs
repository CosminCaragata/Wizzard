﻿using System;
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
                });
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

            foreach (var outputIntersection in outputModel.OutputIntersections)
            {

                Dictionary<Street, int> streetScores = new Dictionary<Street, int>();

                foreach (var streetInIntersection in outputIntersection.intersection.StreetsWhichGoToIntersection)
                {

                    streetScores.Add(streetInIntersection, 0);
                    foreach (var c in inputModel.PathsOfCars)
                    {
                        streetScores[streetInIntersection] += c.StreetsOnPath.Where(x => x.StreetName == streetInIntersection.StreetName).Count();

                    }
                }

                foreach (var street1 in outputIntersection.intersection.StreetsWhichGoToIntersection)
                {
                    outputIntersection.ordersOnIntersections.Add(new OrderOnIntersection()
                    {
                        duration = streetScores[street1],
                        street = street1

                    });
                }
            }

            outputModel.WriteToFile();

            outputModel.WriteToFile();
        }



        public class Simulation
        {
            public InputModel InputModel;

            public int TickNumber;

            public List<SimulationIntersectionOrder> SimulationIntersectionOrders = new List<SimulationIntersectionOrder>();

            List<Car> cars = new List<Car>();

        }

        public class SimulationIntersectionOrder
        {
            public Street SelectedStreet;
            public Intersection Intersection;
            public int TimeElapsedUnchanged;
        }
    }
}
