namespace ImmutableType
{
    public class ImmutablePoint
    {
        public int X { get; }
        public int Y { get; }

        public ImmutablePoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public ImmutablePoint ChangeX(int newX)
        {
            return new ImmutablePoint(newX, Y);
        }
        
        public ImmutablePoint ChangeY(int newY)
        {
            return new ImmutablePoint(X, newY);
        }

        public override string ToString()
        {
            return "ImmutablePoint(" + X + ", " + Y + ")";
        }
    }
}