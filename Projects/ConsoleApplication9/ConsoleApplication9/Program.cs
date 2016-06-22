using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication9
{
    class Program
    {
        static string fi = "880";
        static string[] ip, ior, opr, tbl;
        static void Main(string[] args)
        {
            System.IO.File.Delete(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "frel.txt");
            tbl = System.IO.File.ReadAllLines(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "table.txt");
            ip = System.IO.File.ReadAllLines(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "ip.txt");
            ior = System.IO.File.ReadAllLines(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "iorel.txt");
            opr = System.IO.File.ReadAllLines(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "oprel.txt");
            for (int i = 0; i < ip.Length; i++)
            {
                string str1 = amount(ip[i]);
                Console.Write(System.Environment.NewLine);
                System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "frel.txt", System.Environment.NewLine);

            }
            Console.Write(System.Environment.NewLine);
            Console.Write(System.Environment.NewLine);
            Console.Write(System.Environment.NewLine);
            for (int i = 0; i < tbl.Length; i++)
            {
                string[] temp2 = System.Text.RegularExpressions.Regex.Split(tbl[i], @"(^\d+)", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                string str1 = amountop(temp2[1]);
                Console.Write(System.Environment.NewLine);
                System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "frel.txt", System.Environment.NewLine);

                // Console.Write(temp2[2]);
            }

            //string str1 = amountop("135");

            Console.Write("Exit");
            Console.ReadKey();
        }
        static string amount(string str)
        {
            Console.Write(str + "=");
            System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "frel.txt", str + "=");

            for (int j = 0; j < ior.Length - 1; j = j + 2)
            {
                string[] temp = System.Text.RegularExpressions.Regex.Split(ior[j], "(=)", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                int count = System.Text.RegularExpressions.Regex.Matches(temp[2], String.Concat(@"(^|\s)", str, @"(\s|$)")).Count;
                Console.Write(count + "\t");
                System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "frel.txt", count + "\t");


            }

            return str;

        }
        static string amountop(string str)
        {
            Console.Write(str + "=");
            System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "frel.txt", str + "=");

            for (int j = 0; j < opr.Length - 1; j = j + 2)
            {
                string[] temp = System.Text.RegularExpressions.Regex.Split(opr[j], "(=)", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                int count = System.Text.RegularExpressions.Regex.Matches(temp[2], String.Concat(@"(^|\s)", str, @"(\s|$)")).Count;
                Console.Write(count + "\t");
                System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "frel.txt", count + "\t");


            }

            return str;

        }
    }
}
