using System;
using TextFile;

namespace Final
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    string? filename = "";
                    Console.Write("Please enter a filename: ");
                    filename = Console.ReadLine();
                    TextFileReader reader = new(filename);
                    Console.WriteLine();
                    Console.WriteLine("----Initial States of the Areas----");
                    reader.ReadLine(out string line);
                    int n = int.Parse(line);
                    List<Areas> areas = new List<Areas>();
                    Humidity h = new Humidity(0);
                    Console.WriteLine(n);
                    for (int i = 0; i < n; ++i)
                    {
                        char[] separators = new char[] { ' ', '\t' };
                        Areas? area = null;

                        if (reader.ReadLine(out line))
                        {
                            string[] tokens = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                            string title1 = tokens[0];
                            string name1 = tokens[1];

                            Owner owner = new Owner
                            {
                                title = title1,
                                name = name1,
                            };

                            char ch = char.Parse(tokens[2]);
                            int water = int.Parse(tokens[3]);

                            switch (ch)
                            {
                                case 'P':
                                    area = new Plain(owner, ch, water);
                                    break;
                                case 'G':
                                    area = new Grass(owner, ch, water);
                                    break;
                                case 'L':
                                    area = new Lake(owner, ch, water);
                                    break;
                                default:
                                    Console.WriteLine("Invalid area type.");
                                    break;
                            }
                        }

                        areas.Add(area);
                    }
                    if(reader.ReadLine(out line))
                    {
                        h.h = double.Parse(line);
                    }
                    // here, we are assigning the one humidity to all the areas
                    foreach(var area in areas) { area.humidity = h; Console.WriteLine(area);}
                    Console.WriteLine("Initial humidity: " + h);
                    Console.WriteLine();


                    // logic
                    #region
                    List<double> seenChanges = new List<double>();
                    int rounds = 1;
                    while (areas.Select(area => area.landType).Distinct().Count() > 1)
                    {
                        double sum = 0;
                        double hhh = 0;
                        Console.WriteLine();
                        Console.WriteLine(" -------------------------");
                        Console.WriteLine("[---Simulation Round ({0})--]", rounds++);
                        Console.WriteLine(" -------------------------");
                        for (int j = 0; j < areas.Count; j++)
                        {
                            areas[j] = areas[j].Respond(h, ref hhh);
                            Console.WriteLine(areas[j]);
                            if (!seenChanges.Contains(hhh))
                            {
                                seenChanges.Add(hhh);
                            }
                        }
                        
                        foreach(double e in seenChanges) { sum += e; }
                        if(h.Rainy()) { h.h = 30.0; }
                        sum += h.h;
                        Console.WriteLine("Overall humidity: " + Math.Round(sum, 2) + "%");
                        Console.WriteLine();
                        
                        h = new(sum);
                        seenChanges.Clear();
                    }
                    Console.WriteLine();
                    Console.WriteLine("Overall, it took {0} rounds of simulation for all the areas to become the same.", rounds-1);
                    #endregion
                    // logic

                    break;
                }

                catch (System.IO.FileNotFoundException)
                {
                    Console.WriteLine("The file could not be found. Try again!");
                }
                catch
                {
                    Console.WriteLine("An unexpected error occured, please try again!");
                }
                finally
                {
                    Console.WriteLine();
                }
            }

        }
    }
}
