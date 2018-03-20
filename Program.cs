using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace figure
{
    class Triangle
    {
        private double a, b, c, S;
        private double[] M = new double[3];
        private double[] P = new double[3];
        private double[] side = new double[3];
        private double[] x = new double[3];
        private double[] y = new double[3];

        public bool setX(string X, int i)
        {
            bool result = false;
            try
            {
                result = ((double.TryParse(X, out double res)) ? true : false);
            }
            catch (Exception e)
            { }
            if (result != false)
            this.x[i] = double.Parse(X);
            return result;
        }
        public bool setY(string Y, int i)
        {
            bool result2 = false;
            try
            {
                result2 = ((double.TryParse(Y, out double res)) ? true : false);
            }
            catch (Exception e)
            { }
            if (result2 != false)
            this.y[i] = double.Parse(Y);
            return result2;
        }

        public double getX(int i)
        {
            return this.x[i];
        }
        public double getY(int i)
        {
            return this.y[i];
        }

        public Triangle(double[] x, double[] y, int i)
        {

        }
        public void setSide(int i)
        {
            if (i < 2)
            {
                this.side[i] = Math.Sqrt(Math.Pow(this.x[i] - this.x[i + 1], 2) + Math.Pow(this.y[i] - this.y[i + 1], 2));
            }
            else
            {
                this.side[i] = Math.Sqrt(Math.Pow(this.x[i] - this.x[0], 2) + Math.Pow(this.y[i] - this.y[0], 2));
            }
        }
        public double getSide(int i)
        {
            return this.side[i];
        }

        public Triangle()
        {
        }

        public void CalculatePerimeter(int j)
        {
            for(int i = 0; i < 3; i++)
            this.P[j] += this.side[i];
        }
        public double getP(int i)
        {
            return this.P[i];
        }
        public void CalculateSquare(int i)
        {
            double p = this.P[i]/2;
            double k = p * (p - this.side[0]) * (p - this.side[1]) * (p - this.side[2]);
            this.S = Math.Sqrt(k);
        }
        public double getS()
        {
            return this.S;
        }
        public void AngleA()
        {
            this.a = Math.Acos((this.side[0] * this.side[0] + this.side[2] * this.side[2] - this.side[1] * this.side[1]) / (2 * this.side[0] * this.side[2]));
        }
        public void AngleB()
        {
            this.b = Math.Acos((this.side[0] * this.side[0] + this.side[1] * this.side[1] - this.side[2] * this.side[2]) / (2 * this.side[0] * this.side[1]));
        }
        public void AngleC()
        {
            this.c = Math.Acos((this.side[1] * this.side[1] + this.side[2] * this.side[2] - this.side[0] * this.side[0]) / (2 * this.side[1] * this.side[2]));
        }
        public double getAngleA()
        {
            return this.a;
        }
        public double getAngleB()
        {
            return this.b;
        }
        public double getAngleC()
        {
            return this.c;
        }
        public void setMed()
        {
            this.M[0] = Math.Sqrt(2 * Math.Pow(this.side[0], 2) + 2 * Math.Pow(this.side[1], 2) - Math.Pow(this.side[2], 2)) / 2;
            this.M[1] = Math.Sqrt(2 * Math.Pow(this.side[0], 2) + 2 * Math.Pow(this.side[2], 2) - Math.Pow(this.side[1], 2)) / 2;
            this.M[2] = Math.Sqrt(2 * Math.Pow(this.side[1], 2) + 2 * Math.Pow(this.side[2], 2) - Math.Pow(this.side[0], 2)) / 2;
        }
        public double retMed(int i)
        {
            return this.M[i];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = 3;
            bool O = false;
            double r = 0;
            String x = "";
            String y = "";

            Triangle[] tr = new Triangle[n];
            for (int i = 0; i < n; i++)
            {
                int k = 1;
                tr[i] = new Triangle();
                for (int j = 0; j < n; j++)
                {
                    do
                    {
                        Console.WriteLine("Введите координату X (для вещественных чисел использовать запятую):");
                        x = Console.ReadLine();
                    } while (tr[i].setX(x, j) != true);
                    do
                    {
                        Console.WriteLine("Введите координату Y (для вещественных чисел использовать запятую):");
                        y = Console.ReadLine();
                    } while (tr[i].setY(y, j) != true);
                }
                for (int j = 0; j < n; j++)
                {
                    tr[i].setSide(j);
                }
                tr[i].CalculatePerimeter(i);
                tr[i].CalculateSquare(i);
                tr[i].setMed();
                tr[i].AngleA();
                tr[i].AngleB();
                tr[i].AngleC();
                if (tr[i].getS() > 0)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.WriteLine("Длина стороны " + k + ": " + tr[i].getSide(j));
                        k++;
                    }
                    k = 1;
                    for (int j = 0; j < n; j++)
                    {
                        Console.WriteLine("Точка " + k + ": (" + tr[i].getX(j) + ";" + tr[i].getY(j) + ")");
                        k++;
                    }
                    Console.WriteLine("Периметр: " + tr[i].getP(i));
                    Console.WriteLine("Площадь: " + tr[i].getS());
                    Console.WriteLine("Угол A : " + tr[i].getAngleA()+ " радиан");
                    Console.WriteLine("Угол B : " + tr[i].getAngleB() + " радиан");
                    Console.WriteLine("Угол C : " + tr[i].getAngleC() + " радиан");
                    r = ((tr[i].getSide(0) + tr[i].getSide(1) + tr[i].getSide(2)) / (3 * tr[i].getSide(0)));
                    O = (r == 1) ? true : false;
                    if(O == true)
                        Console.WriteLine("Треугольник равносторонний");
                }
                else
                {
                    Console.WriteLine("Трeугольник не существует!");
                }
                Console.WriteLine("-------------------------------------");
            }
            
            int indexMin = 0;
            int numbMin = 0;
            for (int i = 1; i < n; i++)
                for (int j = 1; j < n; j++)
                    if (tr[i].retMed(j) < tr[indexMin].retMed(numbMin))
                    {
                        indexMin = i;
                        numbMin = j;
                    }
            Console.WriteLine("\n\nТреугольник с минимальной медианой (" + tr[indexMin].retMed(numbMin) + ") находится на " + (indexMin + 1) + " позиции под номером " + (numbMin + 1));
            Console.ReadLine();
        }
    }
}