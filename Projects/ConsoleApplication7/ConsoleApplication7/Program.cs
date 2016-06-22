using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication7
{
    class Program
    {
        static string rec, s="880";
         static string[] ip, op, tbl; 
         static string opta;
        static int d;
         static void Main(string[] args)
        {
            ip = System.IO.File.ReadAllLines(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c"+s+"ip.txt");
            op = System.IO.File.ReadAllLines(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c"+s+"op.txt");
            tbl = System.IO.File.ReadAllLines(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c"+s+"table.txt");
            System.IO.File.Delete(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + s + "iorel.txt");
            System.IO.File.Delete(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + s + "oprel.txt");
            string[] temp = System.Text.RegularExpressions.Regex.Split(tbl[1], @"\D|\s", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
             for (int k = 0; k < op.Length; k++)
             {
                System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + s + "iorel.txt", op[k]+"=" );
               System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + s + "oprel.txt", op[k]+"=");
                //Console.Write(op[k]+" ");
                 opta = findrel(op[k]);
                //Console.WriteLine(opta+"   "+ temp[1]);
               System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + s + "iorel.txt", System.Environment.NewLine );
               System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + s + "oprel.txt", System.Environment.NewLine);
                System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + s + "iorel.txt", System.Environment.NewLine);
                System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + s + "oprel.txt", System.Environment.NewLine);


            }
            string a = "1";
            
            string g=String.Concat(@"(^)", a, @"(\s)");
            //bool b = System.Text.RegularExpressions.Regex.IsMatch(tbl[0], g);
            rec = null;
            //opta = findrel("223");
           // Console.Write(opta);
            Console.Write("press any key to exit ");
            Console.ReadKey();
        }
         static string findrel(string str)
        {
            rec = null;
            int m = 0;
            try
            {
                
                for (int i = 0; i < tbl.Length; i++)
                {
                    // Console.Write(i);
                    if (System.Text.RegularExpressions.Regex.IsMatch(tbl[i], String.Concat(@"(^)", str, @"(\s)")))
                    {
                        //Console.Write(i+"  ");
                        //rec = null;
                        string[] temp = System.Text.RegularExpressions.Regex.Split(tbl[i], @"\D+", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                        //Console.Write("temp"+temp[1]+"  ");
                        if (System.Text.RegularExpressions.Regex.IsMatch(temp[0], String.Concat(@"(^|\s)", str, @"(\s|$)")))
                        {
                            // Console.Write("innner"+temp[0]+"  ");
                            for (int j = 1; j <= temp.Length - 2; j++)
                            {
                                Console.Write(temp[j] + " ");
                                System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + s + "oprel.txt", temp[j] + " ");
                                string v = findrel(temp[j]);
                                //return and recursive function
                                rec = string.Concat(temp[j]+" ");
                                //Console.Write( v+" ");
                                System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + s + "iorel.txt", v + " ");

                            }

                        }
                        else
                        {
                            //we have reached an input
                            

                        }
                    }

                    else
                    {
                        //replace this is for next line check
                            m++;
                    }
                }
                //return rec;
            }
            catch
            {
                Console.Write("error found");
                rec = "error"; }
            d = tbl.Length - m;
            if ( m.Equals(tbl.Length)) { return str; }
            else { return " " ; }
            
        }

    }

}
