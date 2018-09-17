using System.Collections.Generic;

public class EndResultSortingRule : Comparer<Coordinates>
{
    public override int Compare(Coordinates pointA, Coordinates pointB)
    {
        var compareX = pointA.X.CompareTo(pointB.X);
        var compareY = pointA.Y.CompareTo(pointB.Y);
        
        return compareX != 0 ?
               compareX :
               compareY != 0 ?
               compareY :
               0;
    }
}