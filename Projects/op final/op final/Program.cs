using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace op_final
{
    class Program
    {
        static string[] it,ot;
        static string fi = "7552";
        static int g, d;
        static void Main(string[] args)
        {


            System.IO.File.Delete(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "pat.pat");
            it = System.IO.File.ReadAllLines(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "itruth.txt");
            //ot = System.IO.File.ReadAllLines(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "otruth.txt");
            for (int i = 0; i < it.Length; i++)
            {
                int[] tem;
                int ttt = 0;
                string[] temp = Regex.Split(it[i], "(=)", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
               // string[] t = temp[2].ToCharArray;
                MatchCollection ma =Regex.Matches(temp[2], "1", System.Text.RegularExpressions.RegexOptions.None);
                string strr;
                Random m = new Random();
                int ig = ma.Count;
                tem = new  int[ig+1];
                foreach(Match mi in ma) { 
                
                    tem[ttt] = mi.Index;
                    ttt++;
                }
                tem[ttt] = 0;
                for (int j=0;j< temp[2].Length; j++)
                {
                    int p = 0;
                    //Console.Write();
                    if (tem[p]!= j)
                    {
                        p++;
                        //Console.Write("here");
                        strr = Convert.ToString(m.Next(0, 2));
                        Console.Write(strr);
                        System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "pat.pat", strr);
                    }
                    else
                    {
                        Console.Write("1");
                        System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "pat.pat", "1");
                    }
                    //string str = Convert.ToString(strr);

                }
                Console.Write(System.Environment.NewLine);
                System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "pat.pat", System.Environment.NewLine);

            }
            Console.ReadKey();
        }
    }
}
