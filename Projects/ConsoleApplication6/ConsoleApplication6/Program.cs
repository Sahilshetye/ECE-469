using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    public class Program
    {

        static string rec;
        static string[] ip, op, tbl, opta;

        public static void main()
        {
            ip = System.IO.File.ReadAllLines(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c432ip.txt");
            op = System.IO.File.ReadAllLines(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c432op.txt");
            tbl = System.IO.File.ReadAllLines(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c432table.txt");

            for (int k = 0; k < op.Length; k++)
            {

                opta[k] = findrel(op[k]);
                Console.WriteLine(opta[k]);
            }


        }

        static string findrel(string str)
        {
            try
            {
                for (int i = 0; i < tbl.Length; i++)
                {

                    if (tbl[0].Contains(str))
                    {
                        rec = null;
                        string[] temp = System.Text.RegularExpressions.Regex.Split(tbl[i], @"\D+", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                        if (temp[0].Contains(str))
                        {

                            for (int j = 1; j < temp.Length; j++)
                            {
                                string v = findrel(temp[j]) + ",";
                                //return and recursive function
                                rec = string.Concat(rec, v);
                            }
                        }
                        else
                        {
                            //we have reached an input
                            rec = string.Concat(rec, str);

                        }
                    }

                    else
                    {
                        return " Value sent not found";//replace this is for next line check
                    }
                }
                //return rec;
            }
            catch
            {
                Console.Write("error found");
                rec = "error";
            }
            return rec;
        }
    }
}
