using System;
using System.Collections.Generic;
using ConsoleApplication.Accessibility;

namespace ConsoleApplication
{
    public class PlayingRules
    {
        public IComparer<Coordinates> EndResultSortingRule;

        public HashSet<AbstractStartingPointRule> StartingPointRules { get; internal set; }

        public HashSet<AbstractAccessibilityRule> AccessibilityRules{get; internal set;}
    }
}