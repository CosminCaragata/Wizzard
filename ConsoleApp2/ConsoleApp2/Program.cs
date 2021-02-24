using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            InputModelImporter inputModelImporter = new InputModelImporter();
            List<InputModel> inputModels = inputModelImporter.ReadAll();



        }



    }
}
