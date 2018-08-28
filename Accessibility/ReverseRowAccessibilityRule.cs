using System.Collections.Generic;

namespace ConsoleApplication.Accessibility
{
    internal class ReverseRowAccessibilityRule : AbstractAccessibilityRule
    {
        public ReverseRowAccessibilityRule() : base(
            ((uint X, uint Y) coordinates) =>
                new HashSet<(uint X, uint Y)>() {
                    (coordinates.X, coordinates.Y - 1)
                }
        )
        { }
    }
}