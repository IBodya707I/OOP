using System;
interface IRectahgle
{
    bool Contains(Point p);
}
class Point
{
    public int x;
    public int y;
    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}
class Rectangle : IRectahgle
{
    public Point bottomLeft;
    public Point topRight;
    public Rectangle(int xleft, int yleft, int xright,  int yright)
    {
        bottomLeft = new Point(xleft, yleft);
        topRight = new Point(xright, yright);
    }
    public bool Contains(Point p)
    {
        if(p.x>=bottomLeft.x&&p.x<=topRight.x&&p.y<=topRight.y&&p.y>=bottomLeft.y)
            return true;
        else
            return false;
    }
}
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("< bottomLeftX > < bottomLeftY > < topRightX > < topRightY >");
            string[] x = Console.ReadLine().Split(' ');
            int xleft = int.Parse(x[0]);
            int yleft = int.Parse(x[1]);
            int xbottom = int.Parse(x[2]);
            int ybottom = int.Parse(x[3]);
            Rectangle rectangle = new Rectangle(xleft, yleft, xbottom, ybottom);
            Console.Write("Enter n: ");
            int n = int.Parse(Console.ReadLine());
            List<Point> points = new List<Point>();
            Console.WriteLine("    x y");
            for(int i = 0; i < n; i++)
            {
                Console.Write(i + 1 + " - ");
                string[] x1 = Console.ReadLine().Split(" ");
                int X = int.Parse(x1[0]);
                int Y;
                if (x1.Length > 1)
                    Y = int.Parse(x1[1]);
                else
                    Y = 0;
                    points.Add(new Point(X, Y));
            }
            for(int i = 0;i < n; i++)
            {
                Console.Write(i + 1 + " - ");
                if (rectangle.Contains(points[i]) == true)
                    Console.WriteLine("true");
                else
                    Console.WriteLine("false");
            }
        }
    }

