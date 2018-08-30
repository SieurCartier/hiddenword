using System;

namespace ConsoleApplication
{
    public class EdgePointStartingPointRule : AbstractStartingPointRule
    {
        public EdgePointStartingPointRule() : base(
            (Coordinates coo, Graph graph) => 
                coo.X == 0
                || coo.Y == 0
                || coo.X + 1 >= graph.Width
                || coo.Y + 1 >= graph.Height
        )
        { }
    }
}