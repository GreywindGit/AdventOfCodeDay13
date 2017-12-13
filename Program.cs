using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AdventOfCodeDay13
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> layers = new Dictionary<int, int>();
            int severity = 0;
            using (StreamReader reader = new StreamReader("data.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Replace(":", "");
                    List<string> parts = line.Split(' ').ToList();
                    int depth = Int16.Parse(parts[0]);
                    int range = Int16.Parse(parts[1]);
                    layers.Add(depth, range);
                }
            }
            foreach (int depth in layers.Keys)
            {
                if (depth % (2 * layers[depth] - 2) == 0)
                    severity += (depth * layers[depth]);
            }
            Console.WriteLine($"Severity: {severity}");
            int delay = 0;
            bool caught = true;
            while (caught)
            {
                caught = false;
                foreach (int depth in layers.Keys)
                {
                    if ((depth + delay) % (2 * layers[depth] - 2) == 0)
                    {
                        caught = true;
                        delay++;
                        break;
                    }

                }
            }
            Console.WriteLine($"Delay: {delay}");
            Console.ReadKey();
        }
    }
}
