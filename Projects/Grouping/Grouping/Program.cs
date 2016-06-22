using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grouping
{
    class Program
    {
        static int g,l=0;
        static int[] tem;
        static string fi = "880";
        static string[] ip, a, b, c;
        static void Main(string[] args)
        {
            System.IO.File.Delete(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "otruth.txt");

            System.IO.File.Delete(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "grp.txt");
            ip = System.IO.File.ReadAllLines(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c"+fi+"frel.txt");
            a = new string[ip.Length];
            b = new string[ip.Length];

            for (int i = 0; i < ip.Length; i++)
            {
                string[] temp = System.Text.RegularExpressions.Regex.Split(ip[i], "(=)", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                a[i] = temp[0];
                //Console.Write(a[i] +"<<value");
                b[i] = temp[2];
                // Console.Write(b[i] + "<<value");

            }
            ///////////////////// other part////////////////////////////
            int grpn = 0;
            for (int j = 0; j < b.Length; j++)
            {

                if (!(b[j].Equals("picked")))
                {
                      Console.Write("GRoup no:"+grpn+" ");
                    Console.Write(a[j]);
                    System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "grp.txt", "GRoup no:" + grpn + " ");
                   // System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "otruth.txt", "GRoup no:" + grpn + " ");
                    System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "grp.txt",a[j]);
                    string[] temp1 = System.Text.RegularExpressions.Regex.Split(b[j], @"\s+", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                    tem = new int[temp1.Length - 1];
                    for (int k=1;k< temp1.Length -2; k++) {
                      tem[k] = Int32.Parse(temp1[k]);
                         int n = tem.Max();
                        if (g != n) { g = n; l = k + 1; }
                           // Console.Write("max->" + l);
                        
                    }
                    System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "otruth.txt", String.Concat(l));

                    for (int i = j + 1; i < b.Length; i++)
                    {
                        if ((b[i].Equals(b[j])))
                        {
                            Console.Write(","+a[i]+" ");
                            System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "grp.txt", "," + a[i] + " ");
                            b[i] = "picked";
                        }
                        else
                        {

                        }
                    }
                    b[j] = "picked";
                    grpn++;
                    Console.Write(System.Environment.NewLine);
                    System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "grp.txt", System.Environment.NewLine);
                    System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "otruth.txt", System.Environment.NewLine);


                }

                //Console.Write(System.Environment.NewLine);
            }

           
        Console.ReadKey();

        }
    }
}
