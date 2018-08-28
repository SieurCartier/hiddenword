using System.Collections.Generic;

namespace ConsoleApplication.Accessibility
{
    internal class RightDiagonalAccessibilityRule : AbstractAccessibilityRule
    {
        public RightDiagonalAccessibilityRule() : base(
            ((uint X, uint Y) coordinates) =>
                new HashSet<(uint X, uint Y)>() {
                    (coordinates.X - 1, coordinates.Y + 1)
                }
        )
        { }
    }
}