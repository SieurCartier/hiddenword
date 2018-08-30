using System.Collections.Generic;

namespace ConsoleApplication.Accessibility
{
    public class ColumnAccessibilityRule : AbstractAccessibilityRule
    {
        public ColumnAccessibilityRule() : base(
            (Coordinates coordinates) =>
                new HashSet<Coordinates>() {
                    (coordinates.X + 1, coordinates.Y)
                }
        )
        { }
    }
}