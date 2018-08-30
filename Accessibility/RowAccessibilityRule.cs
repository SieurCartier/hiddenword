using System.Collections.Generic;

namespace ConsoleApplication.Accessibility
{
    public class RowAccessibilityRule : AbstractAccessibilityRule
    {
        public RowAccessibilityRule() : base(
            (Coordinates coordinates) =>
                new HashSet<Coordinates>() {
                   (coordinates.X, coordinates.Y + 1)
                }
        )
        { }
    }
}