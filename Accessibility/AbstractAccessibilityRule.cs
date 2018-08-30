using System;
using System.Collections.Generic;

namespace ConsoleApplication.Accessibility
{
    public abstract class AbstractAccessibilityRule
    {
        public Func<Coordinates, ISet<Coordinates>> GenerateAdjacentCoordinates { get; private set; }

        protected AbstractAccessibilityRule(Func<Coordinates, ISet<Coordinates>> lambda)
        {
            GenerateAdjacentCoordinates = lambda;
        }
    }
}