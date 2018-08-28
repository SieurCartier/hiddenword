using System.Collections.Generic;

namespace ConsoleApplication.Accessibility
{
    internal class ReverseLeftDiagonalAccessibilityRule : AbstractAccessibilityRule
    {
        public ReverseLeftDiagonalAccessibilityRule() : base(
            ((uint X, uint Y) coordinates) =>
                new HashSet<(uint X, uint Y)>() {
                    (coordinates.X - 1, coordinates.Y - 1)
                }
        )
        { }
    }
}