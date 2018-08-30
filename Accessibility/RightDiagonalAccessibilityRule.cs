using System.Collections.Generic;

namespace ConsoleApplication.Accessibility
{
    internal class RightDiagonalAccessibilityRule : AbstractAccessibilityRule
    {
        public RightDiagonalAccessibilityRule() : base(
            (Coordinates coordinates) =>
                new HashSet<Coordinates>() {
                    (coordinates.X - 1, coordinates.Y + 1)
                }
        )
        { }
    }
}