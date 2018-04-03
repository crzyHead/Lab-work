using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CShCalc
{
    public partial class Form1 : Form
    {
        Calculator calculator;
        bool isLastButtonOperation = false;

        public Form1()
        {
            InitializeComponent();
            calculator = new Calculator();
        }

        private void AddDigitToDisplay(String digit)
        {
            if (isLastButtonOperation)
                Display.Text = "";

            if (Display.Text.Equals("0"))
                Display.Text = digit;
            else
                Display.Text += digit;
            isLastButtonOperation = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Btn1_Click_1(object sender, EventArgs e)
        {
            AddDigitToDisplay(((Button)sender).Text);
        }

        private void btn2_Click_1(object sender, EventArgs e)
        {
            AddDigitToDisplay(((Button)sender).Text);
        }

        private void btn3_Click_1(object sender, EventArgs e)
        {
            AddDigitToDisplay(((Button)sender).Text);
        }

        private void btn4_Click_1(object sender, EventArgs e)
        {
            AddDigitToDisplay(((Button)sender).Text);
        }

        private void btn5_Click_1(object sender, EventArgs e)
        {
            AddDigitToDisplay(((Button)sender).Text);
        }

        private void btn6_Click_1(object sender, EventArgs e)
        {
            AddDigitToDisplay(((Button)sender).Text);
        }

        private void btn7_Click_1(object sender, EventArgs e)
        {
            AddDigitToDisplay(((Button)sender).Text);
        }

        private void btn8_Click_1(object sender, EventArgs e)
        {
            AddDigitToDisplay(((Button)sender).Text);
        }

        private void btn9_Click_1(object sender, EventArgs e)
        {
            AddDigitToDisplay(((Button)sender).Text);
        }

        private void btn0_Click_1(object sender, EventArgs e)
        {
            AddDigitToDisplay(((Button)sender).Text);
        }

        private void btnComma_Click_1(object sender, EventArgs e)
        {
            if (!Display.Text.Contains(","))
                AddDigitToDisplay(((Button)sender).Text);
        }

        private void btnClearLastSymbol_Click_1(object sender, EventArgs e)
        {
            Display.Text = Display.Text.Remove(Display.Text.Length - 1, 1);
            if (Display.Text.Length == 0)
                Display.Text = Convert.ToString(0);
        }

        private void btnMemoryClear_Click_1(object sender, EventArgs e)
        {
            calculator.Memory = 0;
            Display.Text = Convert.ToString(0);
        }

        private void btnMemoryMinus_Click_1(object sender, EventArgs e)
        {
            calculator.Memory -= Convert.ToDouble(Display.Text);
            Display.Text = Convert.ToString(calculator.Memory);
        }

        private void btnMemoryPlus_Click_1(object sender, EventArgs e)
        {
            calculator.Memory += Convert.ToDouble(Display.Text);
            Display.Text = Convert.ToString(calculator.Memory);
        }

        private void btnMemory_Click_1(object sender, EventArgs e)
        {
            calculator.Memory = Convert.ToDouble(Display.Text);
        }

        private void btnReverse_Click_1(object sender, EventArgs e)
        {
            Display.Text = (1 / Convert.ToDouble(Display.Text)).ToString();
        }

        private void btnPercent_Click_1(object sender, EventArgs e)
        {
            calculator.Operand1 = Convert.ToDouble(Display.Text);
            calculator.Operation = 7;
            isLastButtonOperation = true;
        }

        private void btnPow_Click_1(object sender, EventArgs e)
        {
            calculator.Operand1 = Convert.ToDouble(Display.Text);
            calculator.Operation = 6;
            isLastButtonOperation = true;
        }

        private void btnSquareRoot_Click_1(object sender, EventArgs e)
        {
            calculator.Operand1 = Convert.ToDouble(Display.Text);
            calculator.Operation = 5;
            isLastButtonOperation = true;
            calculator.Calculate();
            Display.Text = calculator.Result;
        }

        private void btnSign_Click_1(object sender, EventArgs e)
        {
            Display.Text = (-1 * Convert.ToDouble(Display.Text)).ToString();
        }

        private void btnClearLast_Click_1(object sender, EventArgs e)
        {
            Display.Text = Convert.ToString(0);
        }

        private void btnClearAll_Click_1(object sender, EventArgs e)
        {
            calculator.Operand1 = 0;
            calculator.Operand2 = 0;
            Display.Text = Convert.ToString(0);
        }

        private void btnCalculate_Click_1(object sender, EventArgs e)
        {
            calculator.Operand2 = Convert.ToDouble(Display.Text);
            calculator.Calculate();
            Display.Text = Convert.ToString(calculator.Result);
        }

        private void btnDivide_Click_1(object sender, EventArgs e)
        {
            calculator.Operand1 = Convert.ToDouble(Display.Text);
            calculator.Operation = 4;
            isLastButtonOperation = true;
        }

        private void btnMultiply_Click_1(object sender, EventArgs e)
        {
            calculator.Operand1 = Convert.ToDouble(Display.Text);
            calculator.Operation = 3;
            isLastButtonOperation = true;
        }

        private void btnMinus_Click_1(object sender, EventArgs e)
        {
            calculator.Operand1 = Convert.ToDouble(Display.Text);
            calculator.Operation = 2;
            isLastButtonOperation = true;
        }

        private void btnPlus_Click_1(object sender, EventArgs e)
        {
            calculator.Operand1 = Convert.ToDouble(Display.Text);
            calculator.Operation = 1;
            isLastButtonOperation = true;
        }
    }
}
