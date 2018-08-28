using System.Collections.Generic;

namespace ConsoleApplication.Accessibility
{
    internal class ReverseColumnAccessibilityRule : AbstractAccessibilityRule
    {
        public ReverseColumnAccessibilityRule() : base(
            ((uint X, uint Y) coordinates) =>
                new HashSet<(uint X, uint Y)>() {
                    (coordinates.X - 1, coordinates.Y)
                }
        )
        { }
    }
}