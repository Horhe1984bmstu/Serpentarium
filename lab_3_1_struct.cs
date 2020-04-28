using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seminar_3_1_struct_
{
    class Program
    {
//----------------Структура Point (точка)-----------------------------------------
        struct Point
        {
            public int X;//Координаты точки X и Y
            public int Y;

            //Конструктор структуры Point
            public Point(int x, int y)
             {
                X = x;
                Y = y;
             }

            
            public void Distance()
            {
                double len;
                len = Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
               Console.WriteLine("Расстояние до точки = {0:F2}", len);
            }
        }

//----------------Структура Line (линия)-----------------------------------------
        struct Line
        {
            public int X1;
            public int Y1;

            public int X2;
            public int Y2;

            //Конструктор структуры Line
            public Line(int x1, int y1, int x2, int y2)
            {
                X1 = x1; Y1 = y1;//Координаты точки начала линии
                X2 = x2; Y2 = y2;//Координаты точки конца линии
            }

            //Метод Exist определяющий принадлежность заданной точки с координатами (X;Y) нашей линии 
            //Если (Y-Y1)/(Y2-Y1) = (X-X1)/(X2-X1) то точка принадлежит линии (уравнение линии из двух точек)
            public bool Exist(int X, int Y)
            {
               if ((((double)Y-(double)Y1)/((double)Y2-(double)Y1)) == (((double)X-(double)X1)/((double)X2-(double)X1)) && (X <= X2) && (X >= X1) && (Y <= Y2) && (Y >= Y1)) 
                      return true;
                else return false;
            }

            //Метод Length вычисляющий длину линии с координатами ((X1;Y1),(X2;Y2)) по теореме Пифагора
            public void Length()
            {
                double len;
                len = Math.Sqrt(Math.Pow((X2 - X1), 2) + Math.Pow((Y2 - Y1), 2));
                Console.WriteLine("Длина линии  = {0:F2}", len);
            }
        }

//------------Структура Square квадрат на плоскости со сторонами, параллельными осям координат----------
        struct Square
        {
            public int X;//Координаты левой нижней точки (угла) X и Y квадрата
            public int Y;
            public int H;//Размер стороны квадрата

            //Конструктор структуры Square
            public Square(int x, int y, int h)
            {
                X = x;
                Y = y;
                H = h;
            }

             
            public bool Exist(int x, int y)
            {
                if (((x <= (X+H)) && (y <= (Y+H))) && ((x >= X) && (y >= Y))) return true;
                else return false;
            }

            //Метод ViewParam вычисляющий площадь и периметр квадрата
            public void ViewParam()
            {
                Console.WriteLine("Площадь квадрата  = {0:F2}\nПериметр квадрата = {1:F2}",Math.Pow(H,2), 4*H);
            }
        }

//------------Структура Circle круг на плоскостик с центом в точке (X;Y) и радиусом R ----------
        struct Circle
        {
            public int X;//Координаты центра круга X и Y
            public int Y;
            public int R;//Радиус круга

            //Конструктор структуры Circle
            public Circle(int x, int y, int r)
            {
                X = x;
                Y = y;
                R = r;
            }

             
            public bool Exist(int x, int y)
            {
                double len;//Расстояние от заданной точки до центра круга - вычисляем аналогично методу Length
                //структуры Line вычисляющего длину линии с координатами ((X1;Y1),(X2;Y2))
                len = Math.Sqrt(Math.Pow((X - x), 2) + Math.Pow((Y - y), 2));

                if (len <= R) return true;
                else return false;
            }

            //Метод ViewParam вычисляющий площадь и периметр круга
            public void ViewParam()
            {
                Console.WriteLine("Площадь круга  = {0:F2}\nПериметр круга = {1:F2}", Math.PI * Math.Pow(R, 2), 2 * Math.PI * R);
            }
        }

        //------------Структура Rectangle прямоугольник на плоскости со сторонами, параллельными осям координат----------
        struct Rectangle
        {
            public int X;//Координаты левой нижней точки (угла) X и Y прямоугольника
            public int Y;
            public int H;//Размеры сторон прямоугольника H (по горизонтале- ширина) и V (по вертикале - высота)
            public int V;

            //Конструктор структуры Rectangle
            public Rectangle(int x, int y, int h, int v)
            {
                X = x;
                Y = y;
                H = h;
                V = v;
            }

            //Метод Exist определяющий принадлежность заданной точки с координатами (X;Y) нашему прямоугольнику 
            public bool Exist(int x, int y)
            {
                if (((x <= (X + H)) && (y <= (Y + V))) && ((x >= X) && (y >= Y))) return true;
                else return false;
            }

            //Метод ViewParam вычисляющий площадь и периметр прямоугольника
            public void ViewParam()
            {
                Console.WriteLine("Площадь прямоугольника  = {0:F2}\nПериметр прямоугольника = {1:F2}", H * V, 2 * (H + V));
            }
        }

//------------Структура Rhomb ромб на плоскости с осями, параллельными осям координат----------
        struct Rhomb
        {
            public int X;//Координаты левой точки (угла) X и Y ромба
            public int Y;
            public int H;//Размер горизонтальной диагонали ромба
            public int V;//Размер вертикальной диагонали ромба

            //Конструктор структуры Rhomb
            public Rhomb(int x, int y, int h, int v)
            {
                X = x;
                Y = y;
                H = h;
                V = v;
            }//Конец конструктора структуры Rhomb

            //Метод Exist определяющий принадлежность заданной точки с координатами (X;Y) нашему ромбу 
            public bool Exist(int x, int y)
            {
                int X1,X2,X3,X4;
                int Y1,Y2,Y3,Y4;

                //Определим координаты точек всех вершин начиная с исходной (X1,Y1) по часовой стрелке до (X4,Y4)
                X1 = X;            //левая вершина
                Y1 = Y;

                X2 = X1 + H / 2;  //верхняя вершина
                Y2 = Y1 + V / 2;

                X3 = X1 + H;     //правая вершина
                Y3 = Y1;

                X4 = X1 + H / 2; //нижняя вершина
                Y4 = Y1 - V / 2;

          // Будем определять расположение искомой точки относительно сторон ромба начиная с левой верхней (между точками 1 и 2) далее по часовой стрелке
          // Для левой верхней и правой нижней сторон - если ((Y-Y1)/(Y2-Y1) - (X-X1)/(X2-X1)) > 0, то точка выше (левее) линии, если < 0, то точка ниже (правее) линии
          // Для правой верхней и левой нижней сторон - если ((Y-Y1)/(Y2-Y1) - (X-X1)/(X2-X1)) > 0, то точка ниже(левее) линии, если < 0, то точка выше (правее) линии
          // Для любой стороны - если = 0, то точка на линии
                double d;

                //1-левая верхняя сторона ромба
                d = (((double)y - (double)Y1) / ((double)Y2 - (double)Y1)) - (((double)x - (double)X1) / ((double)X2 - (double)X1));
                if (d > 0) return false;//Точка выше (левее) стороны - точка не принадлежит ромбу
                else if (d == 0) return true;//Точка находится на стороне ромба - принадлежит ромбу

                //2-правая верхняя сторона ромба
                d = (((double)y - (double)Y2) / ((double)Y3 - (double)Y2)) - (((double)x - (double)X2) / ((double)X3 - (double)X2));
                if (d < 0) return false;//Точка выше (правее) стороны - точка не принадлежит ромбу
                else if (d == 0) return true;//Точка находится на стороне ромба - принадлежит ромбу

                //3-правая нижняя сторона ромба
                d = (((double)y - (double)Y4) / ((double)Y3 - (double)Y4)) - (((double)x - (double)X4) / ((double)X3 - (double)X4));
                if (d < 0) return false;//Точка ниже (правее) стороны - точка не принадлежит ромбу
                else if (d == 0) return true;//Точка находится на стороне ромба - принадлежит ромбу

                //4-левая нижняя сторона ромба
                d = (((double)y - (double)Y1) / ((double)Y4 - (double)Y1)) - (((double)x - (double)X1) / ((double)X4 - (double)X1));
                if (d > 0) return false;//Точка ниже (левее) стороны - точка не принадлежит ромбу;
                else if (d == 0) return true;//Точка находится на стороне ромба - принадлежит ромбу

                return true;//Точка находится внутри ромба
            }//Конец метода Exist

            //Метод ViewParam вычисляющий площадь и периметр ромба
            public void ViewParam()
            {
                double len;//Длина стороны ромба
                len = Math.Sqrt(Math.Pow(H, 2)/4 + Math.Pow(V, 2)/4);

                Console.WriteLine("Площадь ромба  = {0:F2}\nПериметр ромба = {1:F2}", (H * V) / 2, 4 * len);
            }
        }
//--------------------------------------------------------------------------------------------------
        static void Main(string[] args)
        {
            int x, y;//Координаты точки для проверки принадлежности геометрической к фигуре

            //Структура Point (точка)
            Point point11 = new Point(10, 20);
            Console.WriteLine("Структура Point (точка)");
            Console.WriteLine("x = {0}  y = {1}", point11.X, point11.Y);
            point11.Distance();
         
            //Структура Line (линия)
            Line line1 = new Line(-5, -4, 11, 4);
             Console.WriteLine("\nСтруктура Line (линия)");
            Console.WriteLine("x1 = {0}  y1 = {1}    x2 = {2} y2 = {3}", line1.X1, line1.Y1, line1.X2, line1.Y2);
            line1.Length();
            x = 5; y = 4;
            if(line1.Exist(x,y) == true) Console.WriteLine ("Точка М({0},{1}) принадлежит линии",x,y);
            else Console.WriteLine("Точка М({0},{1}) НЕ принадлежит линии", x, y);

            x = 3; y = 0;
            if (line1.Exist(x, y) == true) Console.WriteLine("Точка М({0},{1}) принадлежит линии", x, y);
            else Console.WriteLine("Точка М({0},{1}) НЕ принадлежит линии", x, y); 

           //Структура Square (квадрат)
            Square square1 = new Square(-4, -3, 7); 
            Console.WriteLine("\nСтруктура Square (квадрат)");
            Console.WriteLine("X = {0}  Y = {1}   H = {2}", square1.X, square1.Y, square1.H);
            square1.ViewParam();
            x = -2; y = -2;
            if (square1.Exist(x, y) == true) Console.WriteLine("Точка М({0},{1}) принадлежит квадрату", x, y);
            else Console.WriteLine("Точка М({0},{1}) НЕ принадлежит квадрату", x, y); 

            //Структура Circle (круг)
            Circle circle1 = new Circle(-2, 3, 5);
            Console.WriteLine("\nСтруктура Circle (круг)");
            Console.WriteLine("X = {0}  Y = {1}   R = {2}", circle1.X, circle1.Y, circle1.R);
            circle1.ViewParam();
            x = 1; y = -2;
            if (circle1.Exist(x, y) == true) Console.WriteLine("Точка М({0},{1}) принадлежит кругу", x, y);
            else Console.WriteLine("Точка М({0},{1}) НЕ принадлежит кругу", x, y); 

           //Структура Rectangle (прямоугольник)
            Rectangle rectangle1 = new Rectangle(-2, -1, 3, 4); 
            Console.WriteLine("\nСтруктура Rectangle (прямоугольник)");
            Console.WriteLine("X = {0}  Y = {1}   H = {2}  V = {3}", rectangle1.X, rectangle1.Y, rectangle1.H, rectangle1.V);
            rectangle1.ViewParam();
            x = 0; y = 3;
            if (rectangle1.Exist(x, y) == true) Console.WriteLine("Точка М({0},{1}) принадлежит прямоугольнику", x, y);
            else Console.WriteLine("Точка М({0},{1}) НЕ принадлежит прямоугольнику", x, y);

            //Структура Rhomb (ромб)
            Rhomb rhomb1 = new Rhomb(-2, -1, 6, 4);
            Console.WriteLine("\nСтруктура Rhomb (ромб)");
            Console.WriteLine("X = {0}  Y = {1}   H = {2}  V = {3}", rhomb1.X, rhomb1.Y, rhomb1.H, rhomb1.V);
            rhomb1.ViewParam();
            x = -1; y = -1;
            if (rhomb1.Exist(x, y) == true) Console.WriteLine("Точка М({0},{1}) принадлежит ромбу", x, y);
            else Console.WriteLine("Точка М({0},{1}) НЕ принадлежит ромбу", x, y); 

            Console.ReadKey();
        }
    }
}
