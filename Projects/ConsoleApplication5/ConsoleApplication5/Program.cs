using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            ///*
            int i, j;
            // Read the file as one string.
            System.IO.File.Delete(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c7552op.txt");
            string[] text = System.IO.File.ReadAllLines(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c7552.bench");
            // Display the file contents by using a foreach loop.
            System.Console.WriteLine("Contents of WriteLines2.txt = ");
            // string[,] arr;

            j = 0;
            foreach (string line in text)
            {

                if (System.Text.RegularExpressions.Regex.IsMatch(line, "OUTPUT", System.Text.RegularExpressions.RegexOptions.None))
                {
                    try
                    {
                        string[] temp = System.Text.RegularExpressions.Regex.Split(line, @"\D+", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                        //  string[] temp2 = System.Text.RegularExpressions.Regex.Split(temp[1], ('Open'), System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                        //       string[] temp3 = System.Text.RegularExpressions.Regex.Split(temp2[1], "())", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                        for (i = 0; i < temp.Length - 1; i++)
                        {

                            // Use a tab to indent each line of the file.
                            Console.Write(temp[i]);
                            Console.Write(" ");
                            string v = temp[i];
                            // arr[j,i]= v;
                            System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c7552op.txt", temp[i]);
                        }
                        System.IO.File.AppendAllText(@"C:\Users\ANUJSHETYE\Desktop\ATALANTA\call_atalanta\c7552op.txt", System.Environment.NewLine);
                        Console.Write(System.Environment.NewLine);
                        j++;
                    }
                    catch { Console.WriteLine("error found"); }
                }
                else
                {

                }
            }
                // */
            //     Class1.main();
                Console.WriteLine("Press any key to exit.");
                System.Console.ReadKey();






            }
        }
    }

