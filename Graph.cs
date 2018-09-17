using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Graph
    {
        private IEnumerable<string> wordsToFind;

        private char[][] array;

        private IDictionary<Coordinates, Node> nodes = new Dictionary<Coordinates, Node>();

        private ISet<Node> startingNodes = new HashSet<Node>();

        private IList<Node> usedNodes = new List<Node>();

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

            foreach (Coordinates coordinates in CoordinatesIterator())
            {
                if (coordinates.Y >= array[coordinates.X].Length)
                    throw new ArgumentException($"Given Width ({Width}) doesn't correspond to grid's width ({array[coordinates.X].Length}).");

                var currentNode = NodeFromCoordinates(coordinates);

                var neighboors = FindNeighboors(currentNode);

                currentNode.Add(neighboors);
            }
        }

        private IEnumerable<Node> FindNeighboors(Node currentNode)
        {
            return Game.Rules.AccessibilityRules
                .Select(rule => rule.GenerateAdjacentCoordinates(currentNode.Coordinates))
                .SelectMany(item => item)
                .Where(CoordinatesAreInGrid)
                .Select(NodeFromCoordinates);
        }

        private Node NodeFromCoordinates(Coordinates coordinates)
        {
            if (!nodes.ContainsKey(coordinates))
                Add(new Node(coordinates, array[coordinates.X][coordinates.Y]));

            return nodes[coordinates];
        }

        private bool CoordinatesAreInGrid(Coordinates coordinates)
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

        private IEnumerable<Coordinates> CoordinatesIterator()
        {
            for (uint i = 0; i < Width; i++)
            {
                for (uint j = 0; j < Height; j++)
                {
                    yield return (i, j);
                }
            }
        }

        public string Evaluate()
        {
            var ret = string.Empty;

            foreach(var word in wordsToFind){
                Find(word);
            }

            return nodes
                   .Values
                   .Except(usedNodes)
                   .OrderBy(node => node.Coordinates, Game.Rules.EndResultSortingRule)
                   .Select(n => n.Letter)
                   .ToString();
        }

        private void Find(string word)
        {
            // usedNodes.Add
        }
    }
}