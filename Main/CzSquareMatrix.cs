using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Main
{
    public class CzSquareMatrix : CzMatrix
    {
        int dim;

        public CzSquareMatrix(int nrow,int ncol)//CzSquareMatrix无参构造函数
            : base(nrow,ncol)
        {
            if (nrow != ncol)
                throw new ArgumentException("该矩阵不是方阵");
            else
                dim = nrow;
        }

        public CzSquareMatrix(CzVector[] a)//CzSquareMatrix带参构造函数
            : base(a)
        {
            if (a.Length != a[0].Length) throw new ArgumentException("该矩阵不是方阵");
            CzSquareMatrix UnitMatrix = new CzSquareMatrix(a.Length,a.Length);
            CzSquareMatrix ZeroMatrix = new CzSquareMatrix(a.Length,a.Length);
            dim = this.nrow;
            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    ZeroMatrix.matrix[i, j] = 0;
                    if (i != j)
                        UnitMatrix.matrix[i, j] = 0;
                    else
                        UnitMatrix.matrix[i, i] = 1;
                }
            }
        }
                          
        public static double CoDet(CzSquareMatrix m,int i,int j)//计算代数余子式
        {
            CzSquareMatrix m2 = new CzSquareMatrix(m.row);
            CzMatrix.Removerow(m2,i);
            CzMatrix.Removecol(m2,j);
            return Math.Pow(-1,i+j)*Determinant(m2);
        }

        public static double Determinant(CzSquareMatrix mfactor)//列变换计算行列式的值
        {
            CzMatrix m = new CzMatrix(mfactor.row);
            int dim = m.nrow;
            int count=0;//count用来记录矩阵行列变换引起的行列式值的变化
            for (int i = dim-1; i >= 0; i--)
            {
                if (m.matrix[i, i] == 0)
                {
                    int k = i;
                    while (m.matrix[k, i] == 0)
                    {
                        k--;
                        if (k < 0)
                            break;
                    }
                    if (k >= 0)
                    {
                        CzMatrix.Exchangerow(m, k, i);
                        count++;
                    }
                }
                for(int j=dim-1;j>i;j--)
                {
                    if (m.matrix[j, j] != 0)
                    {
                        Multiplyaddcol(m, j, i, -m.matrix[j, i] / m.matrix[j, j]);
                        colrefresh(m);
                    }
                }
            }
            colrefresh(m);
            double product=1;
            for (int i=0;i<dim;i++)
                product*=m.matrix[i,i];
            return product*Math.Pow(-1,count);
        }
       
        public static CzSquareMatrix Inverse(CzSquareMatrix m)
        {
            if (Determinant(m) == 0)
                throw new ArithmeticException("矩阵不可逆");
            else
            {
                double d=CzSquareMatrix.Determinant(m);
                CzSquareMatrix Mresult = new CzSquareMatrix(m.dim,m.dim);
                for (int i = 0; i < m.dim; i++)
                {
                    for (int j = 0; j < m.dim; j++)
                    {
                        double a = CzSquareMatrix.CoDet(m, i, j);
                        Mresult.matrix[j, i] = a /d ;
                    }
                }
                matrixrefresh(Mresult);
                return Mresult;
            }
        }//矩阵求逆

        public static double Det(CzSquareMatrix m)
        {
            double result = 0;
            for (int i=0; i < m.dim; i++)
            {
                result += m.matrix[0, i] * CoDet(m,0,i);
            }
            return result;
        }//拉普拉斯变换求行列式的值

        public static double Characteristic(CzSquareMatrix m,double eps, int N)//幂法求矩阵绝对值最大的特征值
        {
            int k=1;
            double[] a=new double[m.dim];
            for (int i = 0; i < m.dim; i++)
			{
			    a[i]=1;
			}
            CzVector v = new CzVector(a);
            CzVector v1 = (CzVector)transposition(m*transposition((CzMatrix)v));
            double b = CzVector.max(v1);
            double z = 0;
            while (Math.Abs(z - b) > eps && k < N)
                {
                    k = k + 1;
                    z = b;
                    if (CzVector.max(v1)==0)
                        throw new DivideByZeroException("幂法求解过程中出现全0向量，请检查输入数据后重新运算！");
                    double mv = CzVector.max(v1);
                    v1 = v1 * (1 / mv);
                    v1 = (CzVector)transposition(m * transposition((CzMatrix)v1));
                    b = CzVector.max(v1);
                }
                return b;
            }
    }
}
