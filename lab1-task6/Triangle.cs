using System;

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
        private string strg = "Треугольник не является равносторонним";

        public double[] Side { get => side; set => side = value; }
        public double[] X { get => x; set => x = value; }
        public double[] Y { get => y; set => y = value; }
        public string Strg { get => strg; set => strg = value; }

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
                this.X[i] = double.Parse(X);
            return result;
        }
        public void setX2(int i, double X)
        {
            this.X[i] = Math.Round(X, 3);

        }
        public void setY2(int i, double Y)
        {
            this.Y[i] = Math.Round(Y, 3);
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
                this.Y[i] = double.Parse(Y);
            return result2;
        }

        public double getX(int i)
        {
            return this.X[i];
        }
        public double getY(int i)
        {
            return this.Y[i];
        }

        public Triangle(double[] x, double[] y, int i)
        {

        }
        public void setSide(int i)
        {
            if (i < 2)
            {
                this.Side[i] = Math.Round(Math.Sqrt(Math.Pow(this.X[i] - this.X[i + 1], 2) + Math.Pow(this.Y[i] - this.Y[i + 1], 2)), 2);
            }
            else
            {
                this.Side[i] = Math.Round(Math.Sqrt(Math.Pow(this.X[i] - this.X[0], 2) + Math.Pow(this.Y[i] - this.Y[0], 2)), 2);
            }
        }
        public double getSide(int i)
        {
            return this.Side[i];
        }

        public Triangle()
        {
        }

        public void CalculatePerimeter(int j)
        {
            for (int i = 0; i < 3; i++)
                this.P[j] += this.Side[i];
            this.P[j] = Math.Round(this.P[j], 2);
        }
        public double getP(int i)
        {
            return this.P[i];
        }
        public void CalculateSquare(int i)
        {
            double p = this.P[i] / 2;
            double k = p * (p - this.Side[0]) * (p - this.Side[1]) * (p - this.Side[2]);
            this.S = Math.Round(Math.Sqrt(k), 2);
        }
        public double getS()
        {
            return this.S;
        }
        public void AngleA()
        {
            this.a = Math.Round(Math.Acos((this.Side[0] * this.Side[0] + this.Side[2] * this.Side[2] - this.Side[1] * this.Side[1]) / (2 * this.Side[0] * this.Side[2])), 2);
        }
        public void AngleB()
        {
            this.b = Math.Round(Math.Acos((this.Side[0] * this.Side[0] + this.Side[1] * this.Side[1] - this.Side[2] * this.Side[2]) / (2 * this.Side[0] * this.Side[1])), 2);
        }
        public void AngleC()
        {
            this.c = Math.Round(Math.Acos((this.Side[1] * this.Side[1] + this.Side[2] * this.Side[2] - this.Side[0] * this.Side[0]) / (2 * this.Side[1] * this.Side[2])), 2);
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
            this.M[0] = Math.Round((Math.Sqrt(2 * Math.Pow(this.Side[0], 2) + 2 * Math.Pow(this.Side[1], 2) - Math.Pow(this.Side[2], 2)) / 2), 2);
            this.M[1] = Math.Round((Math.Sqrt(2 * Math.Pow(this.Side[0], 2) + 2 * Math.Pow(this.Side[2], 2) - Math.Pow(this.Side[1], 2)) / 2), 2);
            this.M[2] = Math.Round((Math.Sqrt(2 * Math.Pow(this.Side[1], 2) + 2 * Math.Pow(this.Side[2], 2) - Math.Pow(this.Side[0], 2)) / 2), 2);
        }
        public double retMed(int i)
        {
            return this.M[i];
        }
        public void setStrg()
        {
            double b;
            b = Math.Round((Side[0] + Side[1] + Side[2]) / (3 * Side[0]), 1);
            if (b == 1)
            {
                Strg = "Треугольник является равносторонним";
            }
            else
            {
                if (Side[0] == Side[1] || Side[0] == Side[2] || Side[1] == Side[2])
                {
                    Strg = "Треугольник является равнобоким";
                }

                else
                {
                    Strg = "Треугольник не является ни равносторонним ни равнобоким";
                }
            }
        }
        public string retStrg()
        {
            return Strg;
        }
    }
}