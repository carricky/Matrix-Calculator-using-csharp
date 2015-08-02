using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Main
{
    public class CzVector
    {
        public double[] values;
        public int length;
        public double sum2 = 0;
        public double prod = 1;


        public int Length
        {
            get
            {
                return length;
            }
        }
        public double Sum
        {
            get
            {
                return sum2;
            }
        }

        public double Prod
        {
            get
            {
                return prod;
            }
        }
        public double this[int j]
        {
            get
            {
                return values[j];
            }
            set
            {
                values[j] = value;
            }
        }
        public CzVector(int length)
        {
            values = new double[length];
            this.length = length;
        }
        public CzVector(params double[] dArray)
        {
            this.values= new double[dArray.Length];
            for (int i = 0; i < dArray.Length; i++)
            {
                this.values[i] = dArray[i];
            }
            foreach (double m in dArray)
            {
                sum2 += m;
                prod *= m;
            }
            this.length = dArray.Length;
        }

        public static CzVector Parse(string s)
        {
            double c;
            string[] ss = s.Split(' ');
            CzVector v = new CzVector(ss.Length);
            for (int i = 0; i < v.Length; i++)
            {
                if (!double.TryParse(ss[i], out c))
                    throw new FormatException();
                else
                    v.values[i] = double.Parse(ss[i]);
            }
            return v;
        }
        public static bool TryParse(string s, out CzVector v)
        {
            double c;
            string[] ss = s.Split(' ');
            v = new CzVector(ss.Length);
            for (int i = 0; i < v.Length; i++)
            {
                if (!double.TryParse(ss[i], out c))
                    return false;
                else
                    v.values[i] = double.Parse(ss[i]);
            }
            return true;
        }

        public override string ToString()
        {
            string s = "";
            foreach (double m in this.values)
            {
                s += m.ToString();
                s += " ";
            }
            return s;
        }
        public static CzVector operator +(CzVector v1, CzVector v2)
        {
            if (v1.Length != v2.Length)
                throw new ArgumentException();
            CzVector result = new CzVector(v1.Length);
            for (int i = 0; i < v1.Length; i++)
                result[i] = v1[i] + v2[i];
            return result;
        }
        public static CzVector operator -(CzVector v1, CzVector v2)
        {
            if (v1.Length != v2.Length)
                throw new ArgumentException();
            CzVector result = new CzVector(v1.Length);
            for (int i = 0; i < v1.Length; i++)
                result[i] = v1[i] - v2[i];
            return result;
        }
        public static double operator *(CzVector v1, CzVector v2)
        {
            if (v1.Length != v2.Length)
                throw new ArgumentException();
            double sum = 0;
            for (int i = 0; i < v1.Length; i++)
                sum += v1[i] * v2[i];
            return sum;
        }
        public static CzVector operator *(CzVector v2, double l)
        {
            CzVector result = new CzVector(v2.Length);
            for (int i = 0; i < v2.Length; i++)
                result[i] = l * v2[i];
            return result;
        }
        public static bool operator ==(CzVector v1, CzVector v2)
        {
            if (v1.Length != v2.Length) return false;
            for (int i = 0; i < v1.Length; i++)
                if (v1[i] != v2[i]) return false;
            return true;
        }
        public static bool operator !=(CzVector v1, CzVector v2)
        {
            if (v1.Length != v2.Length) return true;
            for (int i = 0; i < v1.Length; i++)
                if (v1[i] != v2[i]) return true;
            return false;
        }
        public static double max(CzVector v)
        {
            double rmax = Math.Abs(v.values[0]);
            for (int i = 1; i < v.Length; i++)
            {
                if (Math.Abs(v.values[i]) > rmax)
                    rmax = Math.Abs(v.values[i]);
            }
            return rmax;
        }
        public void Output()
        {
            Console.Write("<");
            for (int k = 0; k < values.Length - 1; k++)
                Console.Write("{0},", values[k]);
            Console.Write(values[values.Length - 1]);
            Console.Write(">");
            Console.WriteLine();
        }
    }
}
