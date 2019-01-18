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
