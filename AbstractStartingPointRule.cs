using System;

namespace ConsoleApplication
{
    public abstract class AbstractStartingPointRule
    {
        public Func<Coordinates, Graph, bool> Match { get; private set; }

        protected AbstractStartingPointRule(Func<Coordinates, Graph, bool> lambda)
        {
            Match = lambda;
        }
    }
}