public class Position
{
    public int X;
    public int Y;

    public Position(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public static Position operator +(Position a, Position b) => new Position(a.X + b.X, a.Y + b.Y);

    public static bool operator ==(Position a, Position b) => a.X == b.X && a.Y == b.Y;

    public static Position operator -(Position a) => new Position(-a.X, -a.Y);

    public static bool operator !=(Position a, Position b) => !(a == b);

    public bool Equals(Position other)
    {
        return X == other.X && Y == other.Y;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        return obj is Position other && Equals(other);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return (X * 397) ^ Y;
        }
    }
}