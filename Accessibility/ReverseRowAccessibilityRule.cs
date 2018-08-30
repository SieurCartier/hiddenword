using System.Collections.Generic;

namespace ConsoleApplication.Accessibility
{
    internal class ReverseRowAccessibilityRule : AbstractAccessibilityRule
    {
        public ReverseRowAccessibilityRule() : base(
            (Coordinates coordinates) =>
                new HashSet<Coordinates>() {
                    (coordinates.X, coordinates.Y - 1)
                }
        )
        { }
    }
}