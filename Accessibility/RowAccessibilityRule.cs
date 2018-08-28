using System.Collections.Generic;

namespace ConsoleApplication.Accessibility
{
    public class RowAccessibilityRule : AbstractAccessibilityRule
    {
        public RowAccessibilityRule() : base(
            ((uint X, uint Y) coordinates) =>
                new HashSet<(uint X, uint Y)>() {
                    (coordinates.X, coordinates.Y + 1)
                }
        )
        { }
    }
}