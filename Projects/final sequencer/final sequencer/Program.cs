using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_sequencer
{
    class Program
    {
        static string[] ip, frip;
        static string fi = "7552";
        static int g,d;
        static void Main(string[] args)
        {
            System.IO.File.Delete(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "itruth.txt");
            frip = System.IO.File.ReadAllLines(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "frip.txt");
            ip = System.IO.File.ReadAllLines(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "ip.txt");
            for(int i = 0; i < frip.Length ; i++)
            {
                int[] tem;
                string[] temp = System.Text.RegularExpressions.Regex.Split(frip[i], "(=)", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                

                if (temp[0] != "")
                {
                    System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "itruth.txt",temp[0]+"=");
                    //Console.Write(temp[0]+"= "+temp[2] + "= ");

                    string[] temp1 = System.Text.RegularExpressions.Regex.Split(temp[2], String.Concat(@"^|\s+"));
                    tem = new int[temp1.Length - 1];
                    for (int j = 1; j < temp1.Length - 1; j++)
                    { //Console.Write(temp1[j] ); 

                        tem[j] = Int32.Parse(temp1[j]);
                        g = tem.Max();
                        d = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(g)/15));
                    }
                        for (int k = 1; k < temp1.Length - 1; k++)
                        {
                        if (tem[k] < d) { Console.Write(0);
                            System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "itruth.txt","0" );
                        }
                        else {
                            Console.Write(1);
                            // Console.Write(d);
                            System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "itruth.txt", "1");
                        }
                    }
                    
                       //Console.Write(d);
                    Console.Write(System.Environment.NewLine);
                    System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "itruth.txt", System.Environment.NewLine);





                }
            }
            Console.ReadKey();
        }
    }
}
