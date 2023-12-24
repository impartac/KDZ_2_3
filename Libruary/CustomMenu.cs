using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libruary
{
    /// <summary>
    /// Class for user's interface and decomposing Main program.
    /// Any other beauty parts .
    /// </summary>
    public static class CustomMenu
    {
        // Hehe...
        public static void HackEXE(string href)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var v in $"{Path.GetFileName(href)} has been hacked....") 
            {
                Console.Write(v);
                Thread.Sleep(10);
            }
            Console.WriteLine();
        }

        //Loading bar .
        public static void Loading() 
        {

            Console.Write("Loading file... ");
            Console.WriteLine();
            for (int i = 0; i < 101; i++) 
            {
                for (int j = 0; j < i; j++) 
                {
                    Console.Write("\u2551");
                }
                Console.Write(i + " / 100");
                Console.SetCursorPosition(0, Console.CursorTop);
                Thread.Sleep(10);
            }
            Console.WriteLine();
            Console.WriteLine("Done.");
        }

        public static void GetMenu()
        {
            Console.WriteLine("Press the key to select.");
            Console.WriteLine("1. Sample by fullname.");
            Console.WriteLine("2. Sample by metrostations");
            Console.WriteLine("3. Sort by Street in descending order");
            Console.WriteLine("4. Sort by Street in ascending order");
            Console.WriteLine("5. First N strings.");
            Console.WriteLine("6. Last N strings.");
            Console.WriteLine("7. Exit.");
        }

        // Select action with data from menu . 
        public static void SelectAction(ConsoleKey key)
        {
            Console.WriteLine();
            switch (key.ToString())
            {
                case "D1":
                    {
                        Console.WriteLine("Write fullname.");
                        return;
                    }
                case "D2":
                    {
                        Console.WriteLine("Write metrostations");
                        return;
                    }
                case "D3":
                    {
                        Console.WriteLine("Descending.");
                        return;
                    }
                case "D4":
                    {
                        Console.WriteLine("Ascending.");
                        return;
                    }
                case "D5":
                    {
                        return;
                    }
                case "D6":
                    {
                        return;
                    }
                case "D7":
                    {
                        Console.WriteLine("Exiting...");
                        return;
                    }
                default:
                    {
                        Console.WriteLine("Incorrect key.");
                        return;
                    }
            }
        }
        public static void SavingOption()
        {
            Console.WriteLine("Select saving option.");
            Console.WriteLine("1. Saving new file.");
            Console.WriteLine("2. Resave file.");
            Console.WriteLine("3. Add in file.");
        }

        // Select save option with data from action menu . 
        public static void SelectSaveOption(List<string> notarys)
        {
            if (notarys.Count == 0)
            {
                Console.WriteLine("No such lines found.");
                return;
            }
            CustomMenu.SavingOption();
            ConsoleKey key = Console.ReadKey().Key;
            Console.WriteLine();
            if (!new string[] { "D1", "D2","D3" }.Contains( key.ToString())) 
            {
                Console.WriteLine("Incorrect command.");
                return;
            }
            Console.WriteLine("Write file path.");
            string href = Console.ReadLine();
            try
            {
                switch (key.ToString())
                {
                    case "D1":
                        {
                            CsvSaving.SaveNew(href, notarys);
                            return;
                        }
                    case "D2":
                        {
                            CsvSaving.Resave(href, notarys);
                            return;
                        }
                    case "D3":
                        {
                            CsvSaving.Add(href, notarys);
                            return;
                        }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Incorrect file.");
            }
        }

        // Decomposing main program .
        public static void BeautyNStrings(List<Notary> data,CsvProcessing.DisplayMode mode,List<string> notarys) 
        {
            Console.WriteLine("Write N.");
            int N = -1;
            do
            {
                int.TryParse(Console.ReadLine(), out N);
                if (N <= 1 || N > data.Count())
                {
                    Console.WriteLine("Incorrect N. Try again.");
                }
            }
            while (N <= 1 || N > data.Count());
            notarys = CsvProcessing.GetNStrings(data, mode, N);
            CustomMenu.Print(notarys);
            CustomMenu.SelectSaveOption(notarys);
        }

        public static void BeautySample(List<string> notarys, List<Notary> data, string field) 
        {
            string sample = Console.ReadLine();
            notarys = CsvProcessing.Sample(data, sample, field);
            CustomMenu.Print(notarys);
            CustomMenu.SelectSaveOption(notarys);
        }
        public static void BeautySort(List<string> notarys, List<Notary> data, bool reverse) 
        {
            notarys = CsvProcessing.SortIn(data, reverse);
            CustomMenu.Print(notarys);
            CustomMenu.SelectSaveOption(notarys);
        }

        public static void BeautyRealizationMenu(ConsoleKey key, List<string> notarys, List<Notary> data) 
        {
            switch (key.ToString())
            {
                case "D1":
                    {
                        CustomMenu.BeautySample(notarys, data, "fullname");
                        break;
                    }
                case "D2":
                    {
                        CustomMenu.BeautySample(notarys, data, "metrostations");
                        break;
                    }
                case "D3":
                    {
                        CustomMenu.BeautySort(notarys, data, true);
                        break;
                    }
                case "D4":
                    {
                        CustomMenu.BeautySort(notarys, data, true);
                        break;
                    }
                case "D5":
                    {
                        CustomMenu.BeautyNStrings(data, CsvProcessing.DisplayMode.Top, notarys);
                        break;
                    }
                case "D6":
                    {
                        CustomMenu.BeautyNStrings(data, CsvProcessing.DisplayMode.Bottom, notarys);
                        break;
                    }
                case "D7":
                    {
                        return;
                    }
                default:
                    {
                        break;
                    }
            }

        }

        public static void Solve() 
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter the path to the file.");
            string? href = Console.ReadLine();
            List<Notary> data;
            try
            {
                data = CsvReading.Read(href);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not read data: {href}");
                Console.WriteLine("Press Enter to restart.");
                return;
            }
            CustomMenu.HackEXE(href);
            CustomMenu.Loading();

            CustomMenu.GetMenu();
            ConsoleKey key = Console.ReadKey().Key;
            CustomMenu.SelectAction(key);

            List<string> notarys = new List<string>();
            string? sample;
            CustomMenu.BeautyRealizationMenu(key, notarys, data);

            Console.WriteLine("Press Enter to restart.");
        }

        // Print beauty strings in console .
        public static void Print(List<string> notarys) 
        {
            Console.WriteLine(CsvReading.header);
            foreach (string notary in notarys) 
            {
                Console.WriteLine(new string('-',40));
                Console.WriteLine(notary);
            }
            Console.WriteLine(new string('-', 40));
        }
    }
}
