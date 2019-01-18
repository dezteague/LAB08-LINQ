using System;
using System.IO;
using System.Collections.Generic;
using LINQ.classes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using (StreamReader reader = File.OpenText(@"../../../../LINQ.json"))
            {
                JObject obj = (JObject)JToken.ReadFrom(new JsonTextReader(reader));
                Console.WriteLine(obj);
            }
        }
    }
}

//LINQ LOGIC
//    1. Output all of the neighborhoods in this data list
//      foreach(Properties n in result)

//    2. Filter out all the neighborhoods that do not have any names
//      result = from n in list
//      where n.neighborhood.Length != 0
//      select n;

//    3. Remove the Duplicates
//       result = from n in list
//       where n.Duplicate == false
//       select n;

//    4. Rewrite the queries from above, and consolidate all into one single query.
//    5. Rewrite at least one of these questions only using the opposing method(example: Use LINQ instead of a Lambda and vice versa.)