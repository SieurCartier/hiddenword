using System.Collections.Generic;

namespace ConsoleApplication.Accessibility
{
    internal class ReverseLeftDiagonalAccessibilityRule : AbstractAccessibilityRule
    {
        public ReverseLeftDiagonalAccessibilityRule() : base(
            (Coordinates coordinates) =>
                new HashSet<Coordinates>() {
                    (coordinates.X - 1, coordinates.Y - 1)
                }
        )
        { }
    }
}