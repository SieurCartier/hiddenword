using System.Collections.Generic;

namespace ConsoleApplication.Accessibility
{
    internal class ReverseColumnAccessibilityRule : AbstractAccessibilityRule
    {
        public ReverseColumnAccessibilityRule() : base(
            (Coordinates coordinates) =>
                new HashSet<Coordinates>() {
                    (coordinates.X - 1, coordinates.Y)
                }
        )
        { }
    }
}