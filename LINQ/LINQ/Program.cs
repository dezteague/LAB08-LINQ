using System;
using System.IO;
using System.Collections.Generic;
using LINQ.classes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string path = "../../../../LINQ.json";
            string text = "";

            //read in the file
            using (StreamReader reader = File.OpenText(path))
            {
                text = reader.ReadToEnd();
            }

            //invoke method, bringing in the contents to convert
            ConvertJSON(text);
        }

        //bring in json data, convert to c# object
        static void ConvertJSON(string data)
        {
            //set up the object
            RootObject obj = JsonConvert.DeserializeObject<RootObject>(data);

            var feats = obj.features;

            var item = from n in feats
                       select n;

            int counter = 0;
            foreach(var i in item)
            {
                Console.WriteLine($"{ counter++}.{i.properties.neighborhood.ToString()}");
            }
        }
 

        


    }
}

//LINQ LOGIC
//      foreach(Properties n in result)

//   
//      result = from n in list
//      where n.neighborhood.Length != 0
//      select n;


//       result = from n in list
//       where n.Duplicate == false
//       select n;

//    4. Rewrite the queries from above, and consolidate all into one single query.
//    5. Rewrite at least one of these questions only using the opposing method(example: Use LINQ instead of a Lambda and vice versa.)