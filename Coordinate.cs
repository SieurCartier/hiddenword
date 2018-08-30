using System;

public class Coordinates
{
    public uint X { get; set; }

    public uint Y { get; set; }

    public Coordinates(uint x, uint y) => (X, Y) = (x, y);

    public static implicit operator ValueTuple<uint, uint>(Coordinates coo)
    {
        return (coo.X, coo.Y);
    }

        public static implicit operator Coordinates((uint X, uint Y) coo)
    {
        return new Coordinates(coo.X, coo.Y);
    }
}