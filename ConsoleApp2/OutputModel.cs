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
        List<OutputIntersection> OutputIntersections = new List<OutputIntersection>();
        public OutputModel(InputModel inputModel)
        {
            foreach (var intersection in inputModel.Intersections)
            {
                OutputIntersections.Add(new OutputIntersection()
                {

                })
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
