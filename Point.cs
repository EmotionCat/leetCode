using System;

public class Point
{
    public int x { get; }
    public int y { get; }

    public Point (int x, int y)
    {
        (this.x, this.y) = (x ,y);
    }

    public void WorkerMethod()
    {
        for (int i = 0; i < 1000; i++)
        {
            
        }
    }

}