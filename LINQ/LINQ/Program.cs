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

        static void Question(Feature[] features)
        {
            //1. print all neighborhoods
            var allneighborhoods = from f in features
                                   select f.properties.neighborhood;
            foreach(var prop in allneighborhoods)
            {
                Console.WriteLine(prop);
            }

            Console.WriteLine();
            Console.WriteLine("-----------------------");
            Console.WriteLine();

            //2. filter out neighborhoods without names
            var hoodswithnames = from n in allneighborhoods
                                    //name is not empty
                                    where n != ""
                                    select n;
            foreach(var prop in hoodswithnames)
            {
                Console.WriteLine(prop);
            }

            Console.WriteLine();
            Console.WriteLine("-----------------------");
            Console.WriteLine();

            //3. remove duplicates
            var nodupes = hoodswithnames.Distinct();
            foreach(var prop in hoodswithnames)
            {
                Console.WriteLine(prop);
            }

            Console.WriteLine();
            Console.WriteLine("-----------------------");
            Console.WriteLine();

            //4. consolidate previous queries into a single query
            var consolidatedqueries = features.Where(n => n.properties.neighborhood.Length > 0)
                .GroupBy(g => g.properties.neighborhood)
                .Select(s => s.First());
            foreach(var prop in consolidatedqueries)
            {
                Console.WriteLine(prop.properties.neighborhood);
            }

            Console.WriteLine();
            Console.WriteLine("-----------------------");
            Console.WriteLine();

            //5. rewrite a question using LINQ, not lambda statement
            var rewrite = allneighborhoods.Where(i => i != "");
        }
    }
}