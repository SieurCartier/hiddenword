using System;

namespace ConsoleApplication
{
    public abstract class AbstractStartingPointRule
    {
        public Func<(uint X, uint Y), Graph, bool> Match { get; private set; }

        protected AbstractStartingPointRule(Func<(uint X, uint Y), Graph, bool> lambda)
        {
            Match = lambda;
        }
    }
}