using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


namespace Pattern_maker
{
    class Program
    {
        static int so = 206;
        static void Main(string[] args)
        {
            BigInteger pat = BigInteger.Pow(2, 2206);
            string s = pat.ToString();

            BigInteger pat1;
            //Console.Write(pat);
            //string s = ToNBase(pat,2);
            //Console.Write(s+s.Length);
            


            for (int i = 5; i <= 7; i++)
            {
                double b = i;
                System.IO.File.Delete(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\pat75r" + Math.Pow(2.00, b) + ".txt");

                for (double j = 0; j < Math.Pow(2.00, b); j++)
                {
                    string strr;
                    Random m= new Random();
                    for (int k = 0; k < so; k++)
                    {
                        //Console.Write(strr[k]);
                        strr = Convert.ToString(m.Next(0, 2));
                        Console.Write(strr);
                        System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\pat75r" + Math.Pow(2.00, b) + ".txt", strr);
                    }
                    //string str = Convert.ToString(strr);
                    System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\pat75r" + Math.Pow(2.00, b) + ".txt",System.Environment.NewLine);

                }

                

            }
            Console.ReadKey();
        }
      

            static public BigInteger getRandom(int length)
        {
            Random random = new Random();
            byte[] data = new byte[length];
            random.NextBytes(data);
            return new BigInteger(data);
        }
        public static string ToNBase(BigInteger a, int n)
        {
            StringBuilder sb = new StringBuilder();
            while (a > 0)
            {
                sb.Insert(0, a % n);
                a /= n;
            }
            return sb.ToString();
        }
    }
}
