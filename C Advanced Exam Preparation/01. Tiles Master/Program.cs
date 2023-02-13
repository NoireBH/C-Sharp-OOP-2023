using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Tiles_Master
{
    internal class Program
    {
        static void Main(string[] args)
        {              
            var whiteTiles = new Stack<int>(Console.ReadLine()
                .Split(" ").Select(int.Parse).ToArray());
            var greyTiles = new Queue<int>(Console.ReadLine()
                .Split(" ").Select(int.Parse).ToArray());

            var areas = new Dictionary<string, int>
            {
                {"Sink", 40 },
                {"Oven", 50 },
                {"Countertop", 60 },
                {"Wall", 70 },
            };

            var paintedAreas = new Dictionary<string, int>();

            while (greyTiles.Count > 0 && whiteTiles.Count > 0)
            {                
                if (greyTiles.Peek() == whiteTiles.Peek())
                {
                    var tileValue = whiteTiles.Peek() + greyTiles.Peek();

                    if (areas.Any(a => a.Value == tileValue))
                    {
                        var areaToAdd = areas.First(a => a.Value == tileValue);

                        if (!paintedAreas.ContainsKey(areaToAdd.Key))
                        {
                            paintedAreas[areaToAdd.Key] = 0;
                        }

                        paintedAreas[areaToAdd.Key]++;
                        whiteTiles.Pop();
                        greyTiles.Dequeue();
                    }

                    else
                    {
                        if (!paintedAreas.ContainsKey("Floor"))
                        {
                            paintedAreas["Floor"] = 0;
                        }

                        whiteTiles.Pop();
                        greyTiles.Dequeue();
                        paintedAreas["Floor"]++;
                    }
                }

                else
                {
                    int whiteTileDecreased = whiteTiles.Pop() / 2;
                    whiteTiles.Push(whiteTileDecreased);
                    greyTiles.Enqueue(greyTiles.Dequeue());

                }
            }

            var whiteTilesLeft = whiteTiles.Count == 0 ? "none" : string.Join(", ", whiteTiles);
            var greyTilesLeft = greyTiles.Count == 0 ? "none" : string.Join(", ", greyTiles);

            Console.WriteLine($"White tiles left: {whiteTilesLeft}");
            Console.WriteLine($"Grey tiles left: {greyTilesLeft}");
            foreach (var (location,count) in paintedAreas.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{location}: {count}");
            }

        }
    }
}
