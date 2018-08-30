using System.Collections.Generic;

namespace ConsoleApplication.Accessibility
{
    internal class LeftDiagonalAccessibilityRule : AbstractAccessibilityRule
    {
        public LeftDiagonalAccessibilityRule() : base(
            (Coordinates coordinates) =>
                new HashSet<Coordinates>() {
                    (coordinates.X + 1, coordinates.Y + 1)
                }
        )
        { }
    }
}