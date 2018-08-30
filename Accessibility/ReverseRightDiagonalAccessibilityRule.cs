using System.Collections.Generic;

namespace ConsoleApplication.Accessibility
{
    internal class ReverseRightDiagonalAccessibilityRule : AbstractAccessibilityRule
    {
        public ReverseRightDiagonalAccessibilityRule() : base(
            (Coordinates coordinates) =>
                new HashSet<Coordinates>() {
                    (coordinates.X + 1, coordinates.Y - 1)
                }
        )
        { }
    }
}