using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Main
{
    class LinearEquations
    {
        CzSquareMatrix m;
        CzMatrix c;
        public LinearEquations(CzSquareMatrix A, CzVector b)//LinearEquations构造函数
        {
            this.m = A;
            this.c = CzMatrix.transposition((CzMatrix)b);
        }

        public static CzMatrix Solve(LinearEquations equation)//方程组求解
        {
            if ((CzSquareMatrix.Determinant(equation.m)) == 0)
            {
                throw new ArithmeticException("系数矩阵不可逆");
            }
            else
            {
                return (CzSquareMatrix.Inverse(equation.m) * equation.c);
            }
        }

    }
}
