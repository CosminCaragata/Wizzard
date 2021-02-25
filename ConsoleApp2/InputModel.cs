using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class InputModel
    {
        public int DurationOfSimulation = 0;
        public int NumberOfIntersections;
        public int NumberOfStreets = 0;
        public int numberOfCars;
        public int BonusPoints;

        public List<Street> SteetsInProblem = new List<Street>();

        List<PathOfCar> PathsOfCars = new List<PathOfCar>();
    }


    public class Street
    {
        public string StreetName;
        public int StartingIntersection;
        public int EndingIntersection;
        public int TimeToCross;
    }

    public class PathOfCar
    {
        public int CardIndexNumber;
        public int NumberOfStreetsOnCar;
        public List<Street>  StreetsOnPath;
    }

}
