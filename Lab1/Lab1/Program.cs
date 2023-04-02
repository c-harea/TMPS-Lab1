using System;

interface IShape
{
    void Draw(int x, int y, int size);
}

class Square : IShape
{
    public void Draw(int x, int y, int size)
    {

        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                if (row == 0 || row == size - 1 || col == 0 || col == size - 1)
                {
                    Console.SetCursorPosition(x + col, y + row);
                    Console.Write("*");
                }
            }
        }

        Console.SetCursorPosition(x, y + 20);
    }
}

class Triangle : IShape
{
    public void Draw(int x, int y, int size)
    {
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col <= row; col++)
            {
                Console.SetCursorPosition(x + col, y + row);
                Console.Write("*");
            }
        }

        Console.SetCursorPosition(x, y + 20);
    }
}

class ShapeFactory
{
    public IShape GetShape(string shapeType)
    {

        switch (shapeType)
        {
            case "Square": return new Square();

            case "Triangle": return new Triangle();

            default: return null;
        }

    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.SetBufferSize(1920, 1080);

        ShapeFactory shapeFactory = new ShapeFactory();

        IShape shape1 = shapeFactory.GetShape("Square");
        IShape shape2 = shapeFactory.GetShape("Triangle");
        IShape shape3 = shapeFactory.GetShape("Square");
        IShape shape4 = shapeFactory.GetShape("Triangle");

        shape1.Draw(5, 5, 5);
        shape2.Draw(20, 10, 9);
        shape3.Draw(20, 3, 4);
        shape4.Draw(35, 7, 3);


    }
}
