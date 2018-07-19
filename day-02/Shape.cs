using System;
namespace day_02_ShapeUser
{
    abstract public class Shape
    {
        abstract public void draw();
    }    

    public class Rectangle : Shape
    {
        override public void draw(){
            Console.WriteLine("Rectangle is drawn");
        }
        public void RectangleArea(){
            Console.WriteLine("length * breadth");
        }
    }

    public class SpecialRectangle : Rectangle{
        override public void draw(){
            Console.WriteLine("Special Rectange with 2 triangles drawn");
        }
    }

    public class Circle : Shape
    {
        override public void draw(){
            Console.WriteLine("Circle is drawn");
        }
        public void CircleArea(){
            Console.WriteLine("2*pi*r");
        }
    }
}

namespace day_02_ShapeUser
{
    public class Main
    {
    
        public static void main(){
            // Shape s = new Shape;
            // Rectangle r = new Rectangle();
            // r.draw();

            // Shape r = new Rectangle();
            // Shape c = new Circle();
            // r.draw();
            // c.draw();
            // r.RectangleArea();

            Shape s = new SpecialRectangle();
            s.draw();
            // SpecialRectangle s = new SpecialRectangle();
            // s.draw();

        }
    }
}

