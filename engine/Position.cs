namespace CEngine
{
    public struct Vector2
    {
        //default fields
        public int x { get; set; }
        public int y { get; set; }

        //constructors
        public Vector2()
        {
            x = 0;
            y = 0;
        }

        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        //directions
        public static Vector2 up => new Vector2(0, -1);
        public static Vector2 down => new Vector2(0, 1);
        public static Vector2 left => new Vector2(-1, 0);
        public static Vector2 right => new Vector2(1, 0);

        //operations
        public static Vector2 operator +(Vector2 a, Vector2 b)
            => new Vector2(a.x + b.x, a.y + b.y);

        public static Vector2 operator -(Vector2 a, Vector2 b)
            => new Vector2(a.x - b.x, a.y - b.y);

        public static bool operator ==(Vector2 a, Vector2 b)
            => a.x == b.x && a.y == b.y;

        public static bool operator !=(Vector2 a, Vector2 b)
            => !(a == b);

        public override bool Equals(object obj)
        {
            if (obj is Vector2 other)
                return this == other;
            return false;
        }

        public override int GetHashCode()
            => HashCode.Combine(x, y);

        public override string ToString()
            => $"({x}, {y})";
    }
}
