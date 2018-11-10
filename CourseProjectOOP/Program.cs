using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovoy_oop_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Picture pic = new Picture();
            do
            {
                Console.WriteLine($"---------------- Вариант 1.4 ------------------" + Environment.NewLine);
                Console.WriteLine("Создайте свою собственную коллекцию треугольников!");
                
                Console.WriteLine("Для ПРОДОЛЖЕНИЯ ввода элементов коллекции нажмите любую клавишу. Для ЗАВЕРШЕНИЯ ввода нажмите ESC.");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        public Triangle createTriangle()
        {
            
            return new Equilateral_triangle();
        }
    }
}

public abstract class Triangle
{
    protected double a, b, c, angle;
    public double A { get; set; }
    public double B { get; set; }
    public double Angle { get; set; }
    public double C
    {
        get { return c; }
        set
        {
            c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2) - 2 * a * b * Math.Cos(angle));
        }
    }
    public Triangle() { }
    public Triangle(double a, double b, double angle)
    {
        A = a;
        B = b;
        Angle = angle;
    }

    public Triangle Input()
    {
        Console.Write("Введите сторону A:");
        A = Double.Parse(Console.ReadKey().ToString());
        Console.Write("Введите сторону B:");
        B = Double.Parse(Console.ReadKey().ToString());
        Console.Write("Введите угол между сторонами A и B:");
        Angle = Double.Parse(Console.ReadKey().ToString());
        Triangle tr = new Triangle(A, B, Angle);
    }
    public abstract double Perimeter();
    public abstract double Area();
}

public class Equilateral_triangle : Triangle
{
    private double h;
    public double H
    {
        get { return h; }
        set
        {
            h = A * Math.Sqrt(3.0) / 2.0;
        }
    }
    public override double Perimeter()
    {
        return A * 3;
    }
    public override double Area()
    {
        return 0.5 * A * H;
    }
}
public class Isosceles_triangle : Triangle
{
    private double h;
    public double H
    {
        get { return h; }
        set
        {
            h = Math.Sqrt((Math.Pow(A, 2) - Math.Pow(B, 2)) / 4.0);
        }
    }
    public override double Perimeter()
    {
        return 2 * A + C;
    }

    public override double Area()
    {
        return (C * Math.Sqrt(H)) / 2.0;
    }
}
public class Right_triangle : Triangle
{
    public override double Perimeter()
    {
        return A + B + C;
    }

    public override double Area()
    {
        return 0.5 * a * b;
    }
}
public class Picture
{
    public List<Triangle> picture;
    private double sum = 0;
    public Picture()
    {
        picture = new List<Triangle>();
    }

    public void InputElements()
    {
        int index = 1;
        foreach (Triangle tr in picture)
        {
            Console.WriteLine($"Треугольник №{index}: ");
            picture.Add(tr.Input());
            index++;
        }
    }
    public double Total_area()
    {
        foreach (Triangle tr in picture)
        {
            sum += tr.Area();
        }
        return sum;
    }
}
