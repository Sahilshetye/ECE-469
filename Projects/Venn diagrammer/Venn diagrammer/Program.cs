using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venn_diagrammer
{
    class Program
    { static string fi = "7552";
        static string[] tva, tvb, tvc, flt,ai,bi,ci,aib,aic,bic;
        static int a = 155, b = 180, c = 209,  total = 524;
        static void Main(string[] args)
        {
            System.IO.File.Delete(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c"+fi+"ABC.txt");
            System.IO.File.Delete(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "A.txt");
            System.IO.File.Delete(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "B.txt");
            System.IO.File.Delete(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "C.txt");
            System.IO.File.Delete(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "AIC.txt");
            System.IO.File.Delete(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "AIB.txt");
            System.IO.File.Delete(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "BIC.txt");
            System.IO.File.Delete(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "AICD.txt");
            System.IO.File.Delete(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "AIBD.txt");
            System.IO.File.Delete(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "BICD.txt");
            flt = System.IO.File.ReadAllLines(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + ".flt");
            tva = System.IO.File.ReadAllLines(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\TVa.ud");
            tvb = System.IO.File.ReadAllLines(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\TVb.ud");
            tvc = System.IO.File.ReadAllLines(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\TVc.ud");
            /////To find A union
            for (int i = 0; i < flt.Length - 1; i++)
            {
                bool t1 = false, t2 = false;
                string s = flt[i];
                for (int j = 0; j < tva.Length - 1; j++)
                {

                    if ((System.Text.RegularExpressions.Regex.IsMatch(tva[j],String.Concat(@"(^)",flt[i],@"(\s|$)"))))
                    { t1 = true;
                    }
                    else
                    {
                        //string s = flt[i];
                       // Console.Write(flt[i]+"    ");
                        // System.IO.File.AppendAllLines(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c432A.txt", flt[i]);

                    }
                    
                }
                if (t1 == false)
                {
                    Console.Write(flt[i] + "    ");
                    System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "A.txt", flt[i] + " ");
                    System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "A.txt", System.Environment.NewLine);
                }
                
            }
            ///to find unin b
            for (int i = 0; i < flt.Length - 1; i++)
            {
                bool t1 = false, t2 = false;
                string s = flt[i];
                for (int j = 0; j < tvb.Length - 1; j++)
                {

                    if ((System.Text.RegularExpressions.Regex.IsMatch(tvb[j], String.Concat(@"(^)", flt[i], @"(\s|$)"))))
                    {
                        t1 = true;
                    }
                    else
                    {
                        //string s = flt[i];
                        // Console.Write(flt[i]+"    ");
                        // System.IO.File.AppendAllLines(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c432A.txt", flt[i]);

                    }

                }
                if (t1 == false)
                {
                    Console.Write(flt[i] + "    ");
                    System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "B.txt", flt[i] + " ");
                    System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "B.txt", System.Environment.NewLine);
                }

            }
            //To find Union c
            for (int i = 0; i < flt.Length - 1; i++)
            {
                bool t1 = false, t2 = false;
                string s = flt[i];
                for (int j = 0; j < tvc.Length - 1; j++)
                {

                    if ((System.Text.RegularExpressions.Regex.IsMatch(tvc[j], String.Concat(@"(^)", flt[i], @"(\s|$)"))))
                    {
                        t1 = true;
                    }
                    else
                    {
                        //string s = flt[i];
                        // Console.Write(flt[i]+"    ");
                        // System.IO.File.AppendAllLines(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c432A.txt", flt[i]);

                    }

                }
                if (t1 == false)
                {
                    Console.Write(flt[i] + "    ");
                    System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "C.txt", flt[i] + " ");
                    System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "C.txt", System.Environment.NewLine);
                }

            }
            ///////////////////////////////////////////////New input////////////////////////////////////
            ai = System.IO.File.ReadAllLines(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "A.txt");
            bi = System.IO.File.ReadAllLines(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "B.txt");
            ci = System.IO.File.ReadAllLines(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "C.txt");
            ///////////////////////////////////////////////////////////////////////////////
            // AIB
            for (int i = 0; i < ai.Length - 1; i++)
            {
                bool t1 = false, t2 = false;
                string s = ai[i];
                for (int j = 0; j < bi.Length - 1; j++)
                {

                    if ((System.Text.RegularExpressions.Regex.IsMatch(bi[j], String.Concat(@"(^)", ai[i], @"(\s|$)"))))
                    {
                        t1 = true;
                    }
                    else
                    {
                        //string s = flt[i];
                        // Console.Write(flt[i]+"    ");
                        // System.IO.File.AppendAllLines(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c432A.txt", flt[i]);

                    }

                }
                if (t1 == true)
                {
                    Console.Write(ai[i] + "    ");
                    System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "AIB.txt", ai[i] + " ");
                    System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "AIB.txt", System.Environment.NewLine);
                }
                else
                {
                    Console.Write(ai[i] + "    ");
                    System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "AIBD.txt", ai[i] + " ");
                    System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "AIBD.txt", System.Environment.NewLine);
                }

            }
            // AIC
            for (int i = 0; i < ai.Length - 1; i++)
            {
                bool t1 = false, t2 = false;
                string s = flt[i];
                for (int j = 0; j < ci.Length - 1; j++)
                {

                    if ((System.Text.RegularExpressions.Regex.IsMatch(ci[j], String.Concat(@"(^)", ai[i], @"(\s|$)"))))
                    {
                        t1 = true;
                    }
                    else
                    {
                        //string s = flt[i];
                        // Console.Write(flt[i]+"    ");
                        // System.IO.File.AppendAllLines(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c432A.txt", flt[i]);

                    }

                }
                if (t1 == true)
                {
                    Console.Write(ai[i] + "    ");
                    System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "AIC.txt", ai[i] + " ");
                    System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "AIC.txt", System.Environment.NewLine);
                }
                else
                {
                    Console.Write(ai[i] + "    ");
                    System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "AICD.txt", ai[i] + " ");
                    System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "AICD.txt", System.Environment.NewLine);
                }

            }
            // BIC
            for (int i = 0; i < bi.Length - 1; i++)
            {
                bool t1 = false, t2 = false;
                string s = flt[i];
                for (int j = 0; j < ci.Length - 1; j++)
                {

                    if ((System.Text.RegularExpressions.Regex.IsMatch(ci[j], String.Concat(@"(^)", bi[i], @"(\s|$)"))))
                    {
                        t1 = true;
                    }
                    else
                    {
                        //string s = flt[i];
                        // Console.Write(flt[i]+"    ");
                        // System.IO.File.AppendAllLines(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c432A.txt", flt[i]);

                    }

                }
                if (t1 == true)
                {
                    Console.Write(bi[i] + "    ");
                    System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "BIC.txt", bi[i] + " ");
                    System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "BIC.txt", System.Environment.NewLine);
                }
                else
                {
                    Console.Write(bi[i] + "    ");
                    System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "BICD.txt", bi[i] + " ");
                    System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "BICD.txt", System.Environment.NewLine);
                }

            }
            
            ///////////////////////////////////////////////New input////////////////////////////////////
            aib = System.IO.File.ReadAllLines(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "AIB.txt");
            aic = System.IO.File.ReadAllLines(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "AIC.txt");
            bic = System.IO.File.ReadAllLines(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "BIC.txt");

            // AIBIC
            for (int i = 0; i < aib.Length - 1; i++)
            {
                bool t1 = false, t2 = false;
                string s = aib[i];
                for (int j = 0; j < aic.Length - 1; j++)
                {

                    if ((System.Text.RegularExpressions.Regex.IsMatch(aic[j], String.Concat(@"(^)", aib[i], @"(\s|$)"))))
                    {
                        t1 = true;
                        
                    }
                    else
                    {
                        //string s = flt[i];
                        // Console.Write(flt[i]+"    ");
                        // System.IO.File.AppendAllLines(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c432A.txt", flt[i]);

                    }


                }
                for (int j = 0; j < bic.Length - 1; j++)
                {

                    if ((System.Text.RegularExpressions.Regex.IsMatch(bic[j], String.Concat(@"(^)", aib[i], @"(\s|$)"))))
                    {
                        t2 = true;

                    }
                    else
                    {
                        //string s = flt[i];
                        // Console.Write(flt[i]+"    ");
                        // System.IO.File.AppendAllLines(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c432A.txt", flt[i]);

                    }


                }
                if (t1 == true && t2== true)
                {
                    Console.Write(bi[i] + "    ");
                    System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "ABC.txt", aib[i] + " ");
                    System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c" + fi + "ABC.txt", System.Environment.NewLine);
                }
                else 
                {
                   
                }

            }
            Console.ReadKey();


        }
    }
}
