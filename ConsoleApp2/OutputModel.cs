using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class OutputModel
    {
        public InputModel InputModel = new InputModel();
        public List<IntersectionOrders> IntersectionOrders = new List<IntersectionOrders>();


        
    }


    public class IntersectionOrders
    {
        public Intersection intersection = new Intersection();
        List<IntersectionOrder> orders = new List<IntersectionOrder>();

        public void ToToString()
        {
            string Result = string.Empty;

            Result += intersection.IntersectionNumnber + "\n";
            Result += orders.Count;
            foreach (var streetOrder in orders)
            {
                Result += streetOrder.street.StreetName + " " + streetOrder.Duration + "\n";
            }
        }
    }

    public class IntersectionOrder
    {
        public int Duration;
        public Street street;
    }

}
