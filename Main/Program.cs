using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("欢迎使用MiniMatLab,Ver1.0.0\n" + "===========================================================\n" + "Copyright (c) 2014\n" + "2014 CarRicky Software Foundation.  All rights reserved.\n" + "Arthor:\nCarRicky www.renren.com/siyuangao\n===========================================================\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("该程序可以实现基本的矩阵运算以及有唯一解的线性方程组的求解\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            while (true)
            {
                Console.WriteLine("请问您想进行的操作是？");
                Console.WriteLine("1.矩阵运算      2.方程组求解      3.退出        4.清屏\n" + "===========================================================\n");
                string a = Console.ReadLine();
                if (a == "1")
                {
                    Console.WriteLine("请问您想进行哪种矩阵运算？");
                    Console.WriteLine("1.矩阵加法\n2.矩阵减法\n3.矩阵乘法\n4.矩阵求逆\n5.矩阵转置\n6.矩阵行列式求值（行列变换求解)\n7.矩阵行列式求值（拉普拉斯变换求值)\n8.计算矩阵元素代数余子式\n9.幂法求矩阵绝对值最大的特征值\n10.返回\n" + "===========================================================\n");
                    string b = Console.ReadLine();
                    switch (b)
                    {
                        case "1":
                            {
                                CzMatrix m1, m2;
                                Console.WriteLine("请按照要求输入相应信息：（保证两矩阵维数相同）");
                                Console.WriteLine("请输入矩阵1的元素，实例：1 2 3;1 2 3;1 2 3这是一个行元素全为1 2 3的3*3矩阵\n" + "===========================================================\n");
                                try
                                {
                                while (!CzMatrix.TryParse(Console.ReadLine(), out m1))
                                Console.WriteLine("输入错误，请重新输入!");
                                Console.WriteLine("请输入矩阵2的元素，实例：1 2 3;1 2 3;1 2 3这是一个行元素全为1 2 3的3*3矩阵\n" + "===========================================================\n");
                                while (!CzMatrix.TryParse(Console.ReadLine(), out m2))
                                    Console.WriteLine("输入错误，请重新输入!");
                                
                                    Console.WriteLine("两矩阵和为\n" + "===========================================================\n" + (m1 + m2));
                                }
                                catch (Exception exp)
                                {
                                    Console.WriteLine("运算过程中出错 " + exp.Message);
                                }
                            }
                            break;
                        case "2":
                            {
                                CzMatrix m1, m2;
                                Console.WriteLine("请按照要求输入相应信息：（保证两矩阵维数相同）");
                                Console.WriteLine("请输入矩阵1的元素，实例：1 2 3;1 2 3;1 2 3这是一个行元素全为1 2 3的3*3矩阵\n" + "===========================================================\n");
                                try
                                {
                                while (!CzMatrix.TryParse(Console.ReadLine(), out m1))
                                    Console.WriteLine("输入错误，请重新输入!");
                                Console.WriteLine("请输入矩阵2的元素，实例：1 2 3;1 2 3;1 2 3这是一个行元素全为1 2 3的3*3矩阵\n" + "===========================================================\n");
                                while (!CzMatrix.TryParse(Console.ReadLine(), out m2))
                                    Console.WriteLine("输入错误，请重新输入!");
                                
                                    Console.WriteLine("两矩阵差为\n" + "===========================================================\n" + (m1 - m2));
                                }
                                catch (Exception exp)
                                {
                                    Console.WriteLine("运算过程中出错 " + exp.Message);
                                }
                            }
                            break;
                        case "3":
                            {
                                CzMatrix m1, m2;
                                Console.WriteLine("请按照要求输入相应信息：（保证第一个矩阵列数与第二个矩阵行数对应）");
                                Console.WriteLine("请输入矩阵1的元素，实例：1 2 3;1 2 3;1 2 3这是一个行元素全为1 2 3的3*3矩阵\n" + "===========================================================\n");
                                try
                                {
                                while (!CzMatrix.TryParse(Console.ReadLine(), out m1))
                                    Console.WriteLine("输入错误，请重新输入!");
                                Console.WriteLine("请输入矩阵2的元素，实例：1 2 3;1 2 3;1 2 3这是一个行元素全为1 2 3的3*3矩阵\n" + "===========================================================\n");
                                while (!CzMatrix.TryParse(Console.ReadLine(), out m2))
                                    Console.WriteLine("输入错误，请重新输入!");
                                    Console.WriteLine("两矩阵积为\n" + "===========================================================\n" + (m1 * m2));
                                }
                                catch (Exception exp)
                                {
                                    Console.WriteLine("运算过程中出错 " + exp.Message);
                                }
                            }
                            break;
                        case "4":
                            {
                                CzSquareMatrix m2;
                                CzMatrix m1;
                                Console.WriteLine("请按照要求输入相应信息：（保证矩阵是方阵且可逆）");
                                Console.WriteLine("请输入矩阵的元素，实例：1 2 3;1 2 3;1 2 3这是一个行元素全为1 2 3的3*3矩阵\n" + "===========================================================\n");
                                try
                                {
                                while (!CzSquareMatrix.TryParse(Console.ReadLine(), out m1))
                                    Console.WriteLine("输入错误，请重新输入!");
                                     m2 = new CzSquareMatrix(m1.row);
                                    Console.WriteLine("逆矩阵为\n" + "===========================================================\n" + CzSquareMatrix.Inverse(m2));
                                }
                                catch (Exception exp)
                                {
                                    Console.WriteLine("运算过程中出错 " + exp.Message);
                                }
                            }
                            break;
                        case "5":
                            {
                                CzMatrix m1;
                                Console.WriteLine("请按照要求输入相应信息：（保证矩阵是方阵且可逆）");
                                Console.WriteLine("请输入矩阵的元素，实例：1 2 3;1 2 3;1 2 3这是一个行元素全为1 2 3的3*3矩阵\n" + "===========================================================\n");
                                try
                                {
                                while (!CzSquareMatrix.TryParse(Console.ReadLine(), out m1))
                                    Console.WriteLine("输入错误，请重新输入!");
                               
                                    Console.WriteLine("逆矩阵为\n" + "===========================================================\n" + CzMatrix.transposition(m1));
                                }
                                catch (Exception exp)
                                {
                                    Console.WriteLine("运算过程中出错 " + exp.Message);
                                }
                            }
                            break;
                        case "6":
                            {
                                CzSquareMatrix m2;
                                CzMatrix m1;
                                Console.WriteLine("请按照要求输入相应信息：（保证矩阵是方阵）");
                                Console.WriteLine("请输入矩阵的元素，实例：1 2 3;1 2 3;1 2 3这是一个行元素全为1 2 3的3*3矩阵\n" + "===========================================================\n");
                                try
                                {
                                while (!CzSquareMatrix.TryParse(Console.ReadLine(), out m1))
                                    Console.WriteLine("输入错误，请重新输入!");                               
                                    m2 = new CzSquareMatrix(m1.row);
                                    Console.WriteLine("逆矩阵为\n" + "===========================================================\n" + CzSquareMatrix.Determinant(m2));
                                }
                                catch (Exception exp)
                                {
                                    Console.WriteLine("运算过程中出错 " + exp.Message);
                                }
                            }
                            break;
                        case "7":
                            {
                                CzSquareMatrix m2;
                                CzMatrix m1;
                                Console.WriteLine("请按照要求输入相应信息：（保证矩阵是方阵）");
                                Console.WriteLine("请输入矩阵的元素，实例：1 2 3;1 2 3;1 2 3这是一个行元素全为1 2 3的3*3矩阵\n" + "===========================================================\n");
                                try
                                {
                                while (!CzSquareMatrix.TryParse(Console.ReadLine(), out m1))
                                    Console.WriteLine("输入错误，请重新输入!");                                                        
                                    m2 = new CzSquareMatrix(m1.row);
                                    Console.WriteLine("逆矩阵为\n" + "===========================================================\n" + CzSquareMatrix.Det(m2));
                                }
                                catch (Exception exp)
                                {
                                    Console.WriteLine("运算过程中出错 " + exp.Message);
                                }
                            }
                            break;
                        case "8":
                            {
                                int i, j;
                                CzSquareMatrix m2;
                                CzMatrix m1;
                                Console.WriteLine("请按照要求输入相应信息");
                                Console.WriteLine("请输入矩阵的元素，实例：1 2 3;1 2 3;1 2 3这是一个行元素全为1 2 3的3*3矩阵\n" + "===========================================================\n");
                                try
                                {
                                while (!CzSquareMatrix.TryParse(Console.ReadLine(), out m1))
                                    Console.WriteLine("输入错误，请重新输入!");
                                while (true)
                                {
                                    Console.WriteLine("请输入待求代数余子式元素的位置坐标，实例：0,2，表示第0行第2列元素，上例中的'3'\n" + "===========================================================\n");
                                    string s = Console.ReadLine();
                                    string[] ss = s.Split(',');
                                    if (ss.Length == 2)
                                        if (!int.TryParse(ss[0], out i) || !int.TryParse(ss[1], out j))
                                            Console.WriteLine("输入错误！");
                                        else
                                            break;
                                    else
                                        Console.WriteLine("输入错误！");
                                }

                                
                                    m2 = new CzSquareMatrix(m1.row);
                                    Console.WriteLine("代数余子式为\n" + "===========================================================\n" + CzSquareMatrix.CoDet(m2, i, j));
                                }
                                catch (Exception exp)
                                {
                                    Console.WriteLine("运算过程中出错 " + exp.Message);
                                }
                            }
                            break;
                        case "9":
                            {
                                double eps=0;
                                int N=0;
                                CzSquareMatrix m2;
                                CzMatrix m1;
                                Console.WriteLine("请按照要求输入相应信息");
                                Console.WriteLine("请输入矩阵的元素，实例：1 2 3;1 2 3;1 2 3这是一个行元素全为1 2 3的3*3矩阵\n" + "===========================================================\n");
                                try
                                {
                                    while (!CzSquareMatrix.TryParse(Console.ReadLine(), out m1))
                                        Console.WriteLine("输入错误，请重新输入!");
                                    while(true)
                                    {
                                    Console.WriteLine("请输入允许误差和最大迭代步数，以逗号分隔，输入完成后按回车\n" + "===========================================================\n");
                                    string s = Console.ReadLine();
                                    string[] ss = s.Split(',');
                                    if (ss.Length == 2)
                                        if (!double.TryParse(ss[0], out eps) || !int.TryParse(ss[1], out N))
                                            Console.WriteLine("输入错误！");
                                        else
                                            break;
                                    else
                                        Console.WriteLine("输入错误！");
                                    }
                                    m2 = new CzSquareMatrix(m1.row);
                                    Console.WriteLine("矩阵绝对值最大的特征值为\n" + CzSquareMatrix.Characteristic(m2, eps, N));
                                }
                                catch (Exception exp)
                                {
                                    Console.WriteLine("运算过程中出错 " + exp.Message);
                                }
                               
                                break;
                            }
                        case "10":
                            break;
                        default:
                            {
                                Console.WriteLine("指令错误！");
                                break;
                            }
                    }
                }
                else
                    if (a == "2")
                    {
                        CzSquareMatrix m2;
                        CzMatrix m1;
                        CzVector m3;                                               
                        Console.WriteLine("请按照要求输入相应信息：（保证系数矩阵是方阵，非齐次项为列向量）");
                        Console.WriteLine("请输入系数矩阵的元素，实例：1 2 3;1 2 3;1 2 3这是一个行元素全为1 2 3的3*3矩阵\n" + "===========================================================\n");
                        try
                        {
                            while (!CzSquareMatrix.TryParse(Console.ReadLine(), out m1))
                                Console.WriteLine("输入错误，请重新输入!");
                            m2 = new CzSquareMatrix(m1.row);
                            Console.WriteLine("请按照要求输入相应信息：（保证系数矩阵是方阵，非齐次项为列向量）");
                            Console.WriteLine("请输入非齐次项列向量的元素，实例：1 2 3这是一个元素为1 2 3的列向量\n" + "===========================================================\n");
                            while (!CzVector.TryParse(Console.ReadLine(), out m3))
                                Console.WriteLine("输入错误，请重新输入!");
                            LinearEquations  l1 = new LinearEquations(m2, m3);                                                
                            Console.WriteLine("该方程解为\n" + "===========================================================\n" + LinearEquations.Solve(l1));
                        }
                        catch (Exception exp)
                        {
                            Console.WriteLine("求解过程中出错 " + exp.Message);
                        }
                    }
                    else
                        if (a == "3")
                            break;
                        else
                            if (a == "4")
                                Console.Clear();
                            else
                            Console.WriteLine("请输入正确指令！");
            }
        }
    }
}
