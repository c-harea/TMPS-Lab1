using System;
using System.Collections.Generic;

public interface IObjectPool<T>
{
    T Acquire();
    void Release(T obj);
}

public class Square
{
    public void Draw(int x, int y, int size)
    {
        // Loop over rows
        for (int row = 0; row < size; row++)
        {
            // Loop over columns
            for (int col = 0; col < size; col++)
            {
                if (row == 0 || row == size - 1 || col == 0 || col == size - 1)
                {
                    Console.SetCursorPosition(x + col, y + row); // set cursor position
                    Console.Write("*"); // draw asterisk
                }
            }
        }

        Console.SetCursorPosition(x, y + 20);
    }
}

public class ShapePool : IObjectPool<Square>
{
    private Queue<Square> pool = new Queue<Square>();
    private int poolSize;

    public ShapePool(int poolSize)
    {
        this.poolSize = poolSize;
    }

    public Square Acquire()
    {
        if (pool.Count > 0)
        {
            return pool.Dequeue();
        }
        else
        {
            return new Square();
        }
    }

    public void Release(Square obj)
    {
        if (pool.Count < poolSize)
        {
            pool.Enqueue(obj);
        }
        else
        {
            obj = null;
        }
    }
}

public class GraphicsEngine
{
    private IObjectPool<Square> shapePool;

    public GraphicsEngine(int poolSize)
    {
        shapePool = new ShapePool(poolSize);
    }

    public void DrawSquare(int x, int y, int size)
    {
        Square square = null;

        try
        {
            square = shapePool.Acquire();
            square.Draw(x, y, size);
        }
        finally
        {
            if (square != null)
            {
                shapePool.Release(square);
            }
        }
    }
}

public class Program
{
    public static void Main()
    {
        Console.SetBufferSize(1920, 1080);

        GraphicsEngine engine = new GraphicsEngine(5);
        engine.DrawSquare(10, 2, 5);
        engine.DrawSquare(5, 12, 8);
    }
}