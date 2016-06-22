using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace input_sequence
{
    class Program
    {
        static string[] ip, ior;
        static string fi = "7552";
        static void Main(string[] args)
        {
            System.IO.File.Delete(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "frip.txt");
            ip = System.IO.File.ReadAllLines(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "ip.txt");
            ior= System.IO.File.ReadAllLines(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "iorel.txt");
            for (int i = 0; i < ior.Length ; i++)
            {
                string[] temp = System.Text.RegularExpressions.Regex.Split(ior[i], "(=)", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                if (temp[0] != "")
                {
                    Console.Write(temp[0] + "= ");
                    System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "frip.txt", temp[0] + "= ");

                    for (int j = 0; j < ip.Length ; j++)
                    {
                        int k; ;
                        k = System.Text.RegularExpressions.Regex.Matches(temp[2], String.Concat(@"(^|\s)", ip[j], @"(\s|$)")).Count;
                        Console.Write(k + " ");
                        System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "frip.txt",k+" " );
                    }
                    Console.Write(System.Environment.NewLine);
                    System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "frip.txt",System.Environment.NewLine);

                }
            }
            Console.Write("end");
            Console.ReadKey();
        }
    }
}
