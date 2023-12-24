/// <summary>
/// Апаркин Матвей Максимович 
/// БПИ238
/// Вариант 14
/// </summary>
using Libruary;
using System.Collections.Generic;
using System.Net.Sockets;

class Program
{
    static void Main()
    {
        do
        {
            CustomMenu.Solve();
        }
        while (Console.ReadKey().Key == ConsoleKey.Enter);
    }
}