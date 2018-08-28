using System.Collections.Generic;

namespace ConsoleApplication.Accessibility
{
    public class ColumnAccessibilityRule : AbstractAccessibilityRule
    {
        public ColumnAccessibilityRule() : base(
            ((uint X, uint Y) coordinates) =>
                new HashSet<(uint X, uint Y)>() {
                    (coordinates.X + 1, coordinates.Y)
                }
        )
        { }
    }
}