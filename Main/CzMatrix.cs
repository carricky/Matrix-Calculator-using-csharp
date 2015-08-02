using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Main
{
    public class CzMatrix
    {
        
       
        public CzVector[] col;
        public CzVector[] row;
        public int nrow, ncol;
         public double[,] matrix;

        public CzMatrix(int nrow,int ncol)//无参数构造函数
        {
            this.nrow = nrow;
            this.ncol = ncol;
            this.matrix = new double[nrow, ncol];
            this.col = new CzVector[ncol];
            this.row = new CzVector[nrow];
        }

        public CzMatrix(params CzVector[] a)//矩阵构造
        {
           
            nrow = a.Length;
            int temp = a[0].length;
            foreach (CzVector b in a)
            {
                if (temp != b.length)
                    throw new ArgumentException("矩阵向量长度不一致");
            }
            ncol = temp;
            col = new CzVector[ncol];
            row = new CzVector[nrow];
            double[] temp1 = new double[ncol];
            double[] temp2 = new double[nrow];
            matrix = new double[nrow, ncol];
            for (int i = 0; i < nrow; i++)
            {
                for (int j = 0; j < ncol; j++)
                {
                    temp1[j] = a[i].values[j];
                    matrix[i, j] = a[i].values[j];
                }
                row[i]=(new CzVector(temp1));
            }
            for (int i = 0; i < ncol; i++)
            {
                for (int j = 0; j < nrow; j++)
                    temp2[j] = matrix[j, i];
                col[i] = new CzVector(temp2);
            }
        }

        protected static void rowrefresh(CzMatrix m)//行向量更新方法
        {
            double[] temp=new double[m.nrow];
            for (int i = 0; i < m.nrow; i++)
            {
                for (int j = 0; j < m.ncol; j++)
                    m.matrix[i, j] = m.row[i].values[j];
            }
            for (int i = 0; i < m.ncol; i++)
            {
                for (int j = 0; j < m.nrow; j++)
                    temp[j] = m.matrix[j, i];
                 m.col[i] = new CzVector(temp);
            }
        }

        protected static void colrefresh(CzMatrix m)
        {
            double[] temp = new double[m.ncol];
            for (int i = 0; i < m.ncol; i++)
            {
                for (int j = 0; j < m.nrow; j++)
                    m.matrix[j, i] = m.col[i].values[j];
            }
            for (int i = 0; i < m.nrow; i++)
            {
                for (int j = 0; j < m.ncol; j++)
                    temp[j] = m.matrix[i,j];
                m.row[i] = new CzVector(temp);
            }
        }//列向量更新方法

        protected static void  matrixrefresh(CzMatrix m)//矩阵元素更新方法
        {
            double[] temp1 = new double[m.ncol];
            double[] temp2 = new double[m.nrow];
            for (int i = 0; i < m.nrow; i++)
            {
                for (int j = 0; j < m.ncol; j++)
                {
                    temp1[j] = m.matrix[i,j];
                }
               m.row[i] = new CzVector(temp1);
            }
            for (int i = 0; i < m.ncol; i++)
            {
                for (int j = 0; j < m.nrow; j++)
                    temp2[j] = m.matrix[j, i];
                m.col[i] = new CzVector(temp2);
            }
        }

        public static CzMatrix operator +(CzMatrix m1, CzMatrix m2)//加法重载
        {

            if (m1.ncol != m2.ncol || m1.nrow != m2.nrow)
                throw new ArgumentException("矩阵加法时维数不同");
            CzMatrix Mresult = new CzMatrix(m1.nrow, m1.ncol);
            for (int i = 0; i < m1.nrow; i++)
            {
                Mresult.row[i] = m1.row[i] + m2.row[i];
            }
            rowrefresh(Mresult);
            return Mresult;
        }

        public static CzMatrix operator -(CzMatrix m1, CzMatrix m2)//减法重载
        {

            if (m1.ncol != m2.ncol || m1.nrow != m2.nrow)
                throw new ArgumentException("矩阵减法时维数不同");
            CzMatrix Mresult = new CzMatrix(m1.nrow, m1.ncol);
            for (int i = 0; i < m1.nrow; i++)
            {
                    Mresult.row[i] = m1.row[i]-m2.row[i];
            }
            rowrefresh(Mresult);
            return Mresult;
        }

        public static CzMatrix operator *(double a, CzMatrix m)//数乘重载
        {
            for (int i = 0; i < m.nrow; i++)
            {              
                for (int j = 0; j < m.ncol; j++)               
                    m.matrix[i, j] *= a;               
            }
            matrixrefresh(m);
            return m;
        }

        public static CzMatrix operator *(CzMatrix m1, CzMatrix m2)//矩阵乘法重载
        {
            CzVector[] Vresult;
            double[] varray=new double[m2.ncol];
            if (m1.ncol != m2.nrow)
                throw new ArgumentException("矩阵乘法时维数不同");
            Vresult = new CzVector[m1.nrow];
            for (int i = 0; i < m1.nrow; i++)
            {               
                for (int j=0;j<m2.ncol;j++)           
                        varray[j] =m1.row[i]*m2.col[j];               
                Vresult[i] = new CzVector(varray); 
            }
        return new CzMatrix(Vresult);
        }

        public static bool operator ==(CzMatrix m1, CzMatrix m2)//等号重载
        {
            if (m1.nrow != m2.nrow||m1.ncol!=m2.ncol) return false;
            for (int i = 0; i < m1.nrow; i++)
                for (int j = 0; j < m1.ncol;j++ )
                    if (m1.matrix[i,j] != m2.matrix[i,j]) return false;
            return true;
        }

        public static bool operator !=(CzMatrix m1, CzMatrix m2)//不等号重载
        {
            if (m1.nrow != m2.nrow || m1.ncol != m2.ncol) return true;
            for (int i = 0; i < m1.nrow; i++)
                for (int j = 0; j < m1.ncol; j++)
                    if (m1.matrix[i, j] != m2.matrix[i, j]) return true;
            return false;
        }

        public static CzMatrix transposition(CzMatrix m)//矩阵转置
        {

            CzMatrix Mresult=new CzMatrix(m.ncol,m.nrow);
            for (int i = 0; i < m.ncol; i++)
            {
                for (int j = 0; j < m.nrow; j++)
                    Mresult.matrix[i, j] = m.matrix[j, i];
            }
            matrixrefresh(Mresult);
            return Mresult;
        }

        public static implicit operator CzMatrix(CzVector v)//隐式转换
        {
            return new CzMatrix(v);
        }

        public static explicit operator CzVector(CzMatrix m)
        {
            if (m.nrow != 1)
                throw new ArgumentException("多行矩阵不能转换为向量");
            else
            {
                double[] a = new double[m.ncol];
                for (int i = 0; i < m.ncol; i++)
                {
                    a[i] = m.matrix[0, i];
                }
                return new CzVector(a);
            }
        }//显式转换

        public static CzMatrix Exchangerow(CzMatrix m, int a, int b)//初等行变换
        {
            CzVector temp = m.row[a];
            m.row[a] = m.row[b];
            m.row[b] = temp;
            rowrefresh(m);
            return m;
        }

        public static CzMatrix Exchangecol(CzMatrix m, int a, int b)//初等列变换
        {
            CzVector temp = m.col[a];
            m.col[a] = m.col[b];
            m.col[b] = temp;
            colrefresh(m);
            return m;
        }

        public CzMatrix Mutiplyrow(CzMatrix m, int a, double c)//初等行数乘变换
        {
            for (int i = 0; i < m.row[a].length; i++)
            {
                m.row[a][i] *= c;
            }
            rowrefresh(m);
            return m;
        }

        public CzMatrix Mutiplycol(CzMatrix m, int a, double c)//初等列数乘变换
        {
            for (int i = 0; i < m.col[a].length; i++)
            {
                m.col[a][i] *= c;
            }
            colrefresh(m);
            return m;
        }

        public static void Multiplyaddrow(CzMatrix m, int a, int b, double c)//静态初等行消法变换,第a行乘c加到第b行上
        {
            for (int i = 0; i < m.row[b].length; i++)
            {
                m.row[b][i] += c * m.row[a][i];
            }
            rowrefresh(m);
        }

        public static void Multiplyaddcol(CzMatrix m, int a, int b, double c)//静态初等列消法变换,第a列乘c加到第b列上
        {
            for (int i = 0; i < m.col[b].length; i++)
            {
                m.col[b][i] += c * m.col[a][i];
            }
            colrefresh(m);
        }

        public static void Removerow(CzMatrix m, int a)//静态删除行
        {
            List<CzVector> list = m.row.ToList();
            list.RemoveAt(a);
            m.row = list.ToArray();
            m.nrow -= 1;
            rowrefresh(m);
        }

        public static void Removecol(CzMatrix m, int a)//静态删除列
        {
            List<CzVector> list = m.col.ToList();
            list.RemoveAt(a);
            m.col = list.ToArray();
            m.ncol -= 1;
            colrefresh(m);
        }

        public CzMatrix Removerow( int a)//删除行
        {
            CzMatrix Mresult;
            List<CzVector> list = this.row.ToList();
            list.RemoveAt(a);
            CzVector[] row = list.ToArray();
            //for (int i = a ; i < this.nrow-1;i++ )
            //this.row[i] = new CzVector(this.row[i + 1].values);
            this.nrow -= 1;
            rowrefresh(this);
            Mresult = new CzMatrix(row);
            return Mresult;
        }

        public CzMatrix Removecol( int a)//删除列
        {
            for (int i = a ; i < this.ncol-1; i++)
                this.col[i] = new CzVector(this.col[i + 1].values);
            this.ncol -= 1;
            colrefresh(this);
            return this;
        }

        public override string ToString()//重载ToString方法
        {
            string s="";
            for (int i=0;i<nrow;i++)
            {
                for (int j=0;j<ncol;j++)
                {
                   s=s+Math.Round(matrix[i,j],4)+" ";
                }
                s += Environment.NewLine;
            }
            return s;
        }

        public static CzMatrix Parse(string s)//重载Parse方法
        {
            CzVector[] Vresult;
            string[] ss = s.Split(';');
            Vresult = new CzVector[ss.Length];
            for (int i = 0; i < ss.Length; i++)
            {
                Vresult[i] = CzVector.Parse(ss[i]);
            }
            return (new CzMatrix(Vresult));
        }

        public static bool TryParse(string s, out CzMatrix Mresult)//重载TryParse方法
        {
            CzVector[] Vresult;
            string[] ss = s.Split(';');
            Vresult = new CzVector[ss.Length];
            for (int i = 0; i < ss.Length; i++)
            {
                if (!CzVector.TryParse(ss[i], out Vresult[i]))
                {
                    Mresult = null;
                    return false;
                }
                else
                    Vresult[i] = CzVector.Parse(ss[i]);
            }
            Mresult = new CzMatrix(Vresult);
            return true;
        }
    }

}
