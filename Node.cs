using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Node
    {
        public (uint X, uint Y) Coordinates { get; internal set; }

        public char Letter { get; internal set; }

        public List<Node> Neighbors { get; set; } = new List<Node>();

        public Node((uint X, uint Y) coordinates, char letter)
        {
            Coordinates = coordinates;
            Letter = letter;
        }

        public void Add(IEnumerable<Node> neighbors)
        {
            Neighbors.AddRange(neighbors);
        }
    }
}