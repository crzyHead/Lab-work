using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CShCalc
{
    class Calculator
    {
        double operand1, operand2, memory;
        string result;
        byte operation; // 1+, 2-, 3*, 4/, 5-sqrt, 6-pow, 7-1/a

        public Calculator()
        {
        }

        public void Calculate()
        {
            switch (this.operation)
            {
                case 1:
                    result = (this.operand1 + this.operand2).ToString();
                    break;
                case 2:
                    result = (this.operand1 - this.operand2).ToString();
                    break;
                case 3:
                    result = (this.operand1 * this.operand2).ToString();
                    break;
                case 4:
                    result = (this.operand1 / this.operand2).ToString();
                    break;
                case 5:
                    result = this.operand1 >= 0 ? Math.Sqrt(this.operand1).ToString() : "Square root of negative number";
                    break;
                case 6:
                    result = Math.Pow(this.operand1, this.operand2).ToString();
                    break;
                case 7:
                    result = (this.operand1 / 100 * this.operand2).ToString();
                    break;
                default:
                    break;
            }
        }

        public double Operand1 { get => operand1; set => operand1 = value; }
        public double Operand2 { get => operand2; set => operand2 = value; }
        public double Memory { get => memory; set => memory = value; }
        public string Result { get => result; set => result = value; }
        public byte Operation { get => operation; set => operation = value; }
    }
}
