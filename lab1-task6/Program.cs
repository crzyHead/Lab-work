/*
        Не реализовал наследование, поскольку не нашел метод передачи массива чисел, необходимого для определения 
    является ли равносторонним треугольник, а так же потому что основную функцию наследующего класса уже выполнял родительский класс.
        В этой версии программы реализован выбор между автозаполнением и ручным вводом. Создана проверка на равносторонность(+равнобокость), но не путём наследования.
        Реализованный вариант: №6. Задание варианта: По трём точкам найти стороны, периметр, площадь и определить минимальную медиану 
    (реализованно для всех треугольников в силу сложности и маловероятности получения равностороннего треугольника путем не намеренного ввода)
    + проверка равносторонности/равнобокости и существования треугольника. Суммарное кол-во строк: 400 (не считая комментарий и разделители)
                                                                                                                                        Лисовский М. А., ст. гр. РЗ-171
 */
using System;
using System.Threading;
namespace figure
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 3;
            int k = 1;
            int choVar;
            bool boolVar = false;
            String x = "";
            String y = "";
            Triangle[] tr = new Triangle[n];
            do
            {
                Console.Clear();
                Console.WriteLine("0 - автозаполнение, 1 - ручной ввод");
                choVar = int.Parse(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("Режим: " + (choVar == 1 ? "ручной ввод" : "автозаполнение"));
                if (choVar == 1)
                {
                    for (int i = 0; i < n; i++)
                    {
                        tr[i] = new Triangle();
                        Console.WriteLine("Треугольник № " + (i + 1));
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
                    }
                    boolVar = true;
                }
                else
                {
                    if (choVar == 0)
                    {
                        boolVar = true;
                        int i = 0;
                        int j = 1;
                        int b = 2;
                        tr[i] = new Triangle();
                        tr[j] = new Triangle();
                        tr[b] = new Triangle();
                        //------------
                        tr[i].setX2(i, 0);
                        tr[i].setY2(i, 0);
                        tr[i].setX2(j, (0.5));
                        tr[i].setY2(j, (Math.Sqrt(3) / 2));
                        tr[i].setX2(b, 1);
                        tr[i].setY2(b, 0);
                        //-------------
                        tr[j].setX2(i, -3);
                        tr[j].setY2(i, 0);
                        tr[j].setX2(j, 0);
                        tr[j].setY2(j, 3);
                        tr[j].setX2(b, 0);
                        tr[j].setY2(b, -3);
                        //-------------
                        tr[b].setX2(i, -6);
                        tr[b].setY2(i, 1);
                        tr[b].setX2(j, 2);
                        tr[b].setY2(j, 4);
                        tr[b].setX2(b, 2);
                        tr[b].setY2(b, -6);
                    }
                    else { Console.WriteLine("Введено неверное число"); Thread.Sleep(2000); boolVar = false; Console.Clear(); }
                }
            } while (boolVar != true);
            for (int i = 0; i < n; i++)
            {
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
                tr[i].setStrg();
                if (tr[i].getS() > 0)
                {
                    k = 1;
                    for (int j = 0; j < n; j++)
                    {
                        Console.WriteLine("Длина стороны " + k + ": " + tr[i].getSide(j) + " (см)");
                        k++;
                    }
                    k = 1;
                    for (int j = 0; j < n; j++)
                    {
                        Console.WriteLine("Точка " + k + ": (" + tr[i].getX(j) + ";" + tr[i].getY(j) + ")");
                        k++;
                    }
                    Console.WriteLine("Периметр: " + tr[i].getP(i) + " (см)");
                    Console.WriteLine("Площадь: " + tr[i].getS() + " (см. квадр.)");
                    Console.WriteLine("Угол A : " + tr[i].getAngleA() + " (радиан)");
                    Console.WriteLine("Угол B : " + tr[i].getAngleB() + " (радиан)");
                    Console.WriteLine("Угол C : " + tr[i].getAngleC() + " (радиан)");
                    Console.WriteLine(tr[i].retStrg());
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
