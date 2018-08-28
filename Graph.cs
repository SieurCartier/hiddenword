using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Graph
    {
        private IEnumerable<string> wordsToFind;
        private char[][] array;

        private IDictionary<(uint X, uint Y), Node> nodes = new Dictionary<(uint X, uint Y), Node>() ;
        private ISet<Node> startingNodes = new HashSet<Node>() ;

        public uint Width { get; internal set; }
        public uint Height { get; internal set; }

        public Graph(IEnumerable<string> wordsToFind, uint height, uint width, char[][] array)
        {
            this.wordsToFind = wordsToFind;
            this.Height = height;
            this.Width = width;
            this.array = array;

            Initialize();
        }

        private void Initialize()
        {
            if (array.Length != Height)
                throw new ArgumentException($"Given Height ({Height}) doesn't correspond to grid's height ({array.Length}).");

            foreach ((uint X, uint Y) coordinates in CoordinatesIterator())
            {
                if (coordinates.Y >= array[coordinates.X].Length)
                    throw new ArgumentException($"Given Width ({Width}) doesn't correspond to grid's width ({array[coordinates.X].Length}).");

                var currentNode = NodeFromCoordinates(coordinates);

                var neighbors = FindNeighbors(currentNode);

                currentNode.Add(neighbors);
            }
        }

        private IEnumerable<Node> FindNeighbors(Node currentNode)
        {
            return Game.Rules.AccessibilityRules
                .Select(rule => rule.GenerateAdjacentCoordinates(currentNode.Coordinates))
                .SelectMany(item => item)
                .Where(CoordinatesAreInGrid)
                .Select(NodeFromCoordinates);
        }

        private Node NodeFromCoordinates((uint X, uint Y) coordinates)
        {
            if (!nodes.ContainsKey(coordinates))
                Add(new Node(coordinates, array[coordinates.X][coordinates.Y]));

            return nodes[coordinates];
        }

        private bool CoordinatesAreInGrid((uint X, uint Y) coordinates)
        {
            return coordinates.X < Width
                && coordinates.Y < Height;
        }

        private void Add(Node toAdd)
        {
            if (IsStartingNode(toAdd))
                startingNodes.Add(toAdd);

            nodes.Add(toAdd.Coordinates, toAdd);
        }

        private void Add(IEnumerable<Node> toAdd)
        {
            foreach (var item in toAdd)
            {
                Add(item);
            }
        }

        private bool IsStartingNode(Node toAdd)
        {
            return Game.Rules.StartingPointRules.All(rule => rule.Match(toAdd.Coordinates, this));
        }

        private IEnumerable<(uint X, uint Y)> CoordinatesIterator()
        {
            for (uint i = 0; i < Width; i++)
            {
                for (uint j = 0; j < Height; j++)
                {
                    yield return (i, j);
                }
            }
        }
    }
}