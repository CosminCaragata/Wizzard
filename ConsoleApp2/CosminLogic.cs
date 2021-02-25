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
    }
}
