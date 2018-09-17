using System;
using System.Collections.Generic;
using ConsoleApplication.Accessibility;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordsToFind = new List<string>();

            Console.Write("Number of words : ");
            uint n = uint.Parse(Console.ReadLine());

            for (uint i = 0; i < n; i++)
            {
                Console.Write($"{i + 1} : ");
                wordsToFind.Add(Console.ReadLine());
            }

            Console.Write("Dimensions (height width) : ");
            string[] inputs = Console.ReadLine().Split(' ');
            uint height = uint.Parse(inputs[0]);
            uint width = uint.Parse(inputs[1]);

            var array = new char[height][];

            for (uint i = 0; i < height; i++)
            {
                array[i] = Console.ReadLine().ToCharArray();
            }

            Game.Rules = new PlayingRules
            {
                StartingPointRules = new HashSet<AbstractStartingPointRule> {
                    new EdgePointStartingPointRule()
                },
                AccessibilityRules = new HashSet<AbstractAccessibilityRule> {
                    new ColumnAccessibilityRule(),
                    new ReverseColumnAccessibilityRule(),
                    new RowAccessibilityRule(),
                    new ReverseRowAccessibilityRule(),
                    new LeftDiagonalAccessibilityRule(),
                    new ReverseLeftDiagonalAccessibilityRule(),
                    new RightDiagonalAccessibilityRule(),
                    new ReverseRightDiagonalAccessibilityRule(),
                },
                EndResultSortingRule = new EndResultSortingRule()
            };

            var graph = new Graph(wordsToFind, height, width, array);

            Console.WriteLine(graph.Evaluate());

            PrintArray(array);















        }

        private static void PrintArray(char[][] array)
        {
            var temp = string.Empty;
            for (int i = 0; i < array[0].Length; i++)
            {
                temp += "_";
            }
            Console.WriteLine(temp);

            for (int i = 0; i < array[0].Length; i++)
            {
                Console.WriteLine("| " + string.Join(" | ", array[i]) + " |"); 
            }

            Console.WriteLine(temp);
        }
    }
}
