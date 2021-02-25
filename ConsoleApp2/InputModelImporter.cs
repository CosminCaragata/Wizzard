using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class InputModelImporter
    {
        public List<InputModel> ReadAll()
        {
            string source = "D:\\Test\\";
            List<InputModel> models = new List<InputModel>();

            models.Add(this.Read(source + "a.in"));
            models.Add(this.Read(source + "b.in"));
            models.Add(this.Read(source + "c.in"));
            models.Add(this.Read(source + "d.in"));
            models.Add(this.Read(source + "e.in"));

            return models;
        }



        public InputModel Read(string filename)
        {
            int counter = 0;
            string line;

            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(filename);

            string wholeFile = file.ReadToEnd();
            file.Close();            
            return null;            
        }
 
    }
}
