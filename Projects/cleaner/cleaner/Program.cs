using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cleaner
{
    class Program
    {
        static string[] cl,cp;
        static int c;
        static string fi = "7552";
        static void Main(string[] args)
        {
            //System.IO.File.Delete(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "patf.pat");
            cl = System.IO.File.ReadAllLines(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "pat.pat");
            cp = cl;
            for (int i=0; i < cl.Length; i++)
            { bool b1 = false;
                for (int j = i+1; j < cl.Length; j++)
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(cl[i],cp[j]))
                    {
                       // Console.Write(c);

                        c++;
                        b1 = true;
                        cp[i] = "taken";
            }
                }
                if  (b1== true) { }
                cp[i] = "taken";

            }
            Console.Write(c);
            Console.ReadKey();
        }
    }
}
