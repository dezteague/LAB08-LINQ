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
            Console.WriteLine("NEIGHBORHOODS IN MANHATTAN");
            ConvertJSON();
        }

        //convert json data into c# object
        static void ConvertJSON()
        {
            string path = "../../../../LINQ.json";
            string text = "";

            //read in the file
            using (StreamReader reader = File.OpenText(path))
            {
                text = reader.ReadToEnd();
            }

            //set up the deserialized object
            var obj = JsonConvert.DeserializeObject<RootObject>(text);

            //1. print all neighborhoods
            var allneighborhoods = obj.Features.Select(f => f.Properties.Neighborhood);

            Console.WriteLine(">>>>>all neighborhoods<<<<<");
            foreach (var prop in allneighborhoods)
            {
                Console.WriteLine(prop);
            }

            //2. filter out neighborhoods without names
            var hoodswithnames = from n in allneighborhoods
                                     //name is not empty
                                 where n != ""
                                 select n;

            Console.WriteLine(">>>>>Display neighborhoods with names<<<<<");
            foreach (var prop in hoodswithnames)
            {
                Console.WriteLine(prop);
            }

            //3. remove duplicates
            var nodupes = hoodswithnames.Distinct();

            Console.WriteLine(">>>>>Remove neighborhoods duplicates<<<<<");
            foreach (var prop in hoodswithnames)
            {
                Console.WriteLine(prop);
            }

            //4. consolidate previous queries into a single query
            var consolidatedqueries = obj.Features.Where(n => n.Properties.Neighborhood.Length > 0)
                .GroupBy(g => g.Properties.Neighborhood)
                .Select(s => s.First());
            Console.WriteLine(">>>>>Consolidate queries<<<<<");

            foreach (var prop in consolidatedqueries)
            {
                Console.WriteLine(prop.Properties.Neighborhood);
            }

            //5. rewrite a question using LINQ, not lambda statement
            var rewrite = allneighborhoods.Where(i => i != "");
            Console.WriteLine(">>>>>Rewrite 2nd query<<<<<");

            foreach (var prop in hoodswithnames)
            {
                Console.WriteLine(prop);
            }
        }
    }
}