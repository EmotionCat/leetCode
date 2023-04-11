public class Point
{
    public int x { get; }
    public int y { get; }

    public Point (int x, int y)
    {
        (this.x, this.y) = (x ,y);
    }

}