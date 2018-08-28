using System;
using System.Collections.Generic;

namespace ConsoleApplication.Accessibility
{
    public abstract class AbstractAccessibilityRule
    {
        public Func<(uint X, uint Y), ISet<(uint X, uint Y)>> GenerateAdjacentCoordinates { get; private set; }

        protected AbstractAccessibilityRule(Func<(uint X, uint Y), ISet<(uint X, uint Y)>> lambda)
        {
            GenerateAdjacentCoordinates = lambda;
        }
    }
}