using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Node
    {
        public Coordinates Coordinates { get; internal set; }

        public char Letter { get; internal set; }

        public List<Node> Neighbors { get; set; } = new List<Node>();

        public Node(Coordinates coordinates, char letter)
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