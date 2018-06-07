using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGR
{
    public partial class Form1 : Form
    {
       int mins, secs, result; //Минуты, секунды и результат 
        bool mFirstEnter = true; //Первое обращение к Текстовому полю "Минуты" (обновляется после нажатия на кнопку)
        bool sFirstEnter = true; //Первое обращение к Текстовому полю "Секунды" (обновляется после нажатия на кнопку)
        bool iffirstEnter = true; //Первое обращение к Текстовому полю "X" (Для вкладки If) (обновляется после нажатия на кнопку)
        int[] arrA = new int[15]; //Массив A
        int[] arrB = new int[15]; //Массив B
        int[] arrC = new int[15]; //Массив C
        int[] arrBC = new int[15]; //Сумма массивов B+C
        int[,] arrAC = new int[4,4]; //Двумерный массив AC
        Random rand = new Random();
        int count = 0; //Счетчик для подсчета количества входов буквы в строке и количества отрицательных чисел в двумерном массиве
        public Form1()
        {
            InitializeComponent();
            richTxtBoxTaskOOP.Text = "Дано: минуты и секунды. Вывести общее количество секунд"; //Текст задания для вкладки OOP
            richTxtBoxTaskIF.Text = "Выводить решения Y при разных значениях X"; //Текст задания для вкладки IF
            richTxtBoxTaskArr.Text = "При произвольно заданных A, B и C и размерности 15 найти:"; //Текст задания для вкладки Array
            richTxtBoxTaskArr2D.Text = "Определить кол-во отрицательных элементов в каждом столбце"; //Текст задания для вкладки Array 2D
            richTxtBoxTaskString.Text = "Выяснить, все ли буквы, входящие в слово 'шина' есть в тексте и посчитать их кол-во"; //Текст задания для вкладки String
            dGV.Rows.Add(4);
        }
        public int Mins { get => mins; set => mins = value; }
        public int Secs { get => secs; set => secs = value; }
        public int Result { get => result; set => result = value; }
        public bool MFirstEnter { get => mFirstEnter; set => mFirstEnter = value; }
        public bool SFirstEnter { get => sFirstEnter; set => sFirstEnter = value; }
        public bool IffirstEnter { get => iffirstEnter; set => iffirstEnter = value; }
        public int[] ArrA { get => arrA; set => arrA = value; }
        public int[] ArrB { get => arrB; set => arrB = value; }
        public int[] ArrC { get => arrC; set => arrC = value; }
        public int[] ArrBC { get => arrBC; set => arrBC = value; }
        public int[,] ArrAC { get => arrAC; set => arrAC = value; }
        public int Count { get => count; set => count = value; }
        private void txtBoxSeconds_Enter(object sender, EventArgs e)
        {

            if (SFirstEnter)
            {
                txtBoxSeconds.Text = "";
                SFirstEnter = false;
            }
        }
        private void txtBoxMinutes_Enter(object sender, EventArgs e)
        {
            if (MFirstEnter)
            {
                txtBoxMinutes.Text = "";
                MFirstEnter = false;
            }
        }
        private void btnResultOOP_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtBoxMinutes.Text, out int result) || !int.TryParse(txtBoxSeconds.Text, out int result1))
                    MessageBox.Show("Введите числовое значение!", "Ошбка!", MessageBoxButtons.OK);
                else
                {
                    Mins = int.Parse(txtBoxMinutes.Text);
                    Secs = int.Parse(txtBoxSeconds.Text);
                    Result = Mins * 60 + Secs;
                }
                txtBoxResult.Text = Result.ToString();
            }
            catch (Exception i)
            {

            }
            MFirstEnter = true;
            SFirstEnter = true;
        }
        private void btnResultIF_Click(object sender, EventArgs e)
        {
            try
            {
                double X = double.Parse(txtBoxX.Text);
                if (X <= -1)
                {   
                    txtBoxResultIF.Text = (2*Math.Pow(X, 3) + 3*X).ToString();
                }
                else if(X >= (-1) && X < 0) 
                {
                    txtBoxResultIF.Text = (Math.Pow(X, 2) - 4).ToString();
                }
                else if (X >= 0)
                {
                    txtBoxResultIF.Text = Math.Pow(X, 3).ToString();
                }
                else
                {
                    txtBoxResultIF.Text = "Вне диапазона";
                }
                IffirstEnter = true;
            }
            catch(Exception o)
            {

            }
        }
        private void txtBoxX_Enter(object sender, EventArgs e)
        {
            if (IffirstEnter)
            {
                txtBoxX.Text = "";
                IffirstEnter = false;
            }
        }
        private void btnRandArr_Click(object sender, EventArgs e)
        {
            txtBoxArrA.Text = " ";
            txtBoxArrB.Text = " ";
            txtBoxArrC.Text = " ";
            for (int i = 0; i < 15; i++)
            {
                ArrA[i] = rand.Next(1, 16);
                ArrB[i] = rand.Next(1, 16);
                ArrC[i] = rand.Next(1, 16);
            }
            for (int i = 0; i < 15; i++)
            {
                ArrBC[i] = ArrB[i] + ArrC[i];
                txtBoxArrA.Text += ArrA[i].ToString() + " ";
                txtBoxArrB.Text += ArrB[i].ToString() + " ";
                txtBoxArrC.Text += ArrC[i].ToString() + " ";
            }
        }
        private void btnResultArr_Click(object sender, EventArgs e)
        {
            int minB = ArrB.Min();
            int minBC = ArrBC.Min();
            int maxA = ArrA.Max();
            int maxC = ArrC.Max();
            int S = (minB / maxA) + (maxC / minBC);
            txtBoxResultArr.Text = S.ToString();
        }
        private void btnRndArr2D_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    ArrAC[i, j] = rand.Next(-15, 15);
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    dGV.Rows[i].Cells[j].Value = ArrAC[i, j];
        }
        private void btnResultArr2D_Click(object sender, EventArgs e)
        {
            Count = 0;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (ArrAC[i, j] < 0)
                        Count++;
            txtBoxResultArr2D.Text = Count.ToString();
            Count = 0;
            for (int i = 0; i < 4; i++)
                    if (ArrAC[i, 0] < 0)
                        Count++;
            txtBoxCol1.Text = Count.ToString();
            Count = 0;
            for (int i = 0; i < 4; i++)
                if (ArrAC[i, 1] < 0)
                    Count++;
            txtBoxCol2.Text = Count.ToString();
            Count = 0;
            for (int i = 0; i < 4; i++)
                if (ArrAC[i, 2] < 0)
                    Count++;
            txtBoxCol3.Text = Count.ToString();
            Count = 0;
            for (int i = 0; i < 4; i++)
                if (ArrAC[i, 3] < 0)
                    Count++;
            txtBoxCol4.Text = Count.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int cntSh = 0; //Счестчик количества входов буквы "Ш"
            int cntI = 0; //Счестчик количества входов буквы "И"
            int cntN = 0; //Счестчик количества входов буквы "Н"
            int cntA = 0; //Счестчик количества входов буквы "А"
            int Sh = 0; //Используется для проверки наличия буквы "Ш"
            int I = 0; //Используется для проверки наличия буквы "И"
            int N = 0; //Используется для проверки наличия буквы "Н"
            int A = 0; //Используется для проверки наличия буквы "А"
            Count = 0;
            foreach (char c in txtBoxStroke.Text)
            {
                if (c == 'Ш' || c == 'ш') { cntSh++; Sh = 1; }
                else if (c == 'И' || c == 'и') { cntI++; I = 1; }
                else if (c == 'Н' || c == 'н') { cntN++; N = 1; }
                else if (c == 'А' || c == 'а') { cntA++; A = 1; }
            }
            Count = Sh + I + N + A;
            txtBoxResultCountSh.Text = cntSh.ToString();
            txtBoxResultCountI.Text = cntI.ToString();
            txtBoxResultCountN.Text = cntN.ToString();
            txtBoxResultCountA.Text = cntA.ToString();
            if (Count == 4)
            {
                txtBoxSumResultString.Text = "4/4 букв";
            }
            else if (Count == 3)
            {
                txtBoxSumResultString.Text = "3/4 букв";
            }
            else if (Count ==2)
            {
                txtBoxSumResultString.Text = "2/4 букв";
            }
            else if (Count == 1)
            {
                txtBoxSumResultString.Text = "1/4 букв";
            }
            else if (Count == 0)
            {
                txtBoxSumResultString.Text = "0/4 букв";
            }
        }
    }
}