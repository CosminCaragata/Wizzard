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

        public List<Street> StreetsInProblem = new List<Street>();

        public List<PathOfCar> PathsOfCars = new List<PathOfCar>();

        public List<Intersection> Intersections = new List<Intersection>();

        public List<Car> Cars = new List<Car>();
    }

    public class Street
    {
        public string StreetName;
        public int StartingIntersection;
        public int EndingIntersection;
        public int TimeToCross;

        public override string ToString()
        {
            return StreetName;
        }
    }

    public class PathOfCar
    {
        public int CardIndexNumber;
        public int NumberOfStreetsOnCar;
        public List<Street> StreetsOnPath;
    }

    public class Car
    {
        public PathOfCar path = new PathOfCar();
        public string currentStreet;
        public int duration;
    }


    public class Intersection
    {
        public int IntersectionNumnber;
        public List<Street> StreetsWhichGoToIntersection;
        public List<Street> StreetsWhichStartFromIntersection;
        public LightStatus LightStatus = LightStatus.Red;
    }


    public enum LightStatus
    { 
        Red = 0,
        Green = 1

    }


    public class Status : InputModel
    {

    }

}
