using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class OutputModel
    {
        public int NumberOfScheduledIntersections { get; set; }
        public InputModel inputModel = new InputModel();
        public OutputIntersection[] OutputIntersections;
        public OutputModel(InputModel inputModel)
        {
            OutputIntersections = new OutputIntersection[inputModel.Intersections.Count];
            foreach (var intersect in inputModel.Intersections)
            {
                OutputIntersections[intersect.IntersectionNumnber] = new OutputIntersection()
                {
                    intersection = intersect,
                    ordersOnIntersections = new List<OrderOnIntersection>()
                };
            }
        }

        
    }


    public class OutputIntersection
    {
        public Intersection intersection = new Intersection();
        public List<OrderOnIntersection> ordersOnIntersections = new List<OrderOnIntersection>();

    }

    public class OrderOnIntersection
    {
        public Street street;
        public int duration;
    }

}
