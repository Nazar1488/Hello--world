using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Завдання_4__String_
{
    static class Program
    {
        public static int counting(string a)
        {
            const string loud = "AaEeIiOoYyUu";
            int cnt = 0;
            for (int i = 0; i < a.Length; ++i)
            {
                for (int j = 0; j < golosni.Length; ++j)
                {
                    if (a[i] == golosni[j])
                    {
                        ++cnt;
                    }
                }
            }
            return cnt;

        }
        public static void task(string a)
        {
            String[] substrings = a.Split(',');
            int max = counting(substrings[0]);
            for (int i = 0; i < substrings.Length; i++)
            {
                if (max < counting(substrings[i]))
                {
                    max = counting(substrings[i]);
                }
            }
            if (max == 0)
            {
                Console.WriteLine("There is no element with GOLOSNA letter\n");
            }
            else
            {
                for (int i = 0; i < substrings.Length; i++)
                {
                    if (max == counting(substrings[i]))
                    {
                        Console.WriteLine(substrings[i]);
                    }
                }
            }
        }
        public static void Menu(string Mainstring)
        {
            while (true)

            {
                string choose;
                Console.Clear();
                Console.WriteLine("<**************Task 4**************>\n\n MENU");
                Console.WriteLine("1. *Read string from file\n2. *Read string from console \n3. *Print string\n4. *Do the task\n5. *Exit");
                choose = Console.ReadLine();
                if (choose == "1")
                {
                    if (String.IsNullOrEmpty(Mainstring))
                    {
                        try
                        {
                            StreamReader sr = new StreamReader(File.Open("Text.txt", FileMode.Open));
                            Mainstring = sr.ReadLine();
                            Console.Clear();
                            Console.WriteLine("<**************SUCCESS**************>\n\nUploaded!");
                            sr.Close();
                            Console.ReadKey();
                            continue;
                        }
                        catch (FileNotFoundException)
                        {
                            Console.Clear();
                            Console.WriteLine("<**************ERROR**************>\n\nFile not found!");
                            Console.ReadKey();
                            continue;
                        }
                    }
                    else
                    {
                        Console.Write("String is not empty , do you want to delete prewious? y-Yes n-No");
                        choose = Console.ReadLine();
                        if (choose == "y")
                        {
                            Mainstring = String.Empty;
                            Console.WriteLine("<**************SUCCESS**************>\n\nDeleted!");
                            Console.ReadKey();
                            continue;
                        }
                        if (choose == "n")
                        {
                            Console.WriteLine("<**************SUCCESS**************>\n\nSaved!");
                            Console.ReadKey();
                            continue;
                        }
                    }

                }
                if (choose == "2")
                {
                    Console.Clear();
                    if (String.IsNullOrEmpty(Mainstring))
                    {
                        Console.WriteLine("Input words one by one dividing by ',' and put . int the end ");
                        Mainstring = Console.ReadLine();
                        Console.WriteLine("<**************SUCCESS**************>\n\nUploaded!");
                        Console.ReadKey();
                        continue;
                    }
                    else
                    {
                        Console.Write("String is not empty , do you want to delete prewious? y-Yes n-No\n");
                        choose = Console.ReadLine();
                        if (choose == "y")
                        {
                            Mainstring=String.Empty;
                            Console.WriteLine("<**************SUCCESS**************>\n\nDeleted!");
                            Console.ReadKey();
                            continue;
                        }
                        if (choose == "n")
                        {
                            Console.WriteLine("<**************SUCCESS**************>\n\nSaved!");
                            Console.ReadKey();
                            continue;
                        }
                    }
                }
                if (choose == "3")
                {
                    Console.Clear();
                    if (!String.IsNullOrEmpty(Mainstring))
                    {
                        Console.WriteLine(Mainstring);
                        Console.ReadKey();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("String is empty!!!\n");
                        Console.ReadKey();
                        continue;
                    }

                }
                if (choose == "4")
                {
                    Console.Clear();
                    if (String.IsNullOrEmpty(Mainstring))
                    {
                        Console.WriteLine("String is empty!!!\n");
                        Console.ReadKey();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("There are words with max quantity of Golosni\n");
                        task(Mainstring);
                        Console.ReadKey();
                        continue;
                    }
                }
                else if (choose == "5")
                {
                    Environment.Exit(0);
                }
            }
        }
        static void Main(string[] args)

        static void Main()

        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
