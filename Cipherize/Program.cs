using System;
using static System.Net.Mime.MediaTypeNames;

namespace Cipher
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            string selectCyph;
            Console.WriteLine("Добро пожаловать!!!");
            while (true)
            {
                Console.WriteLine("Режим работы:\n1) Консоль 2) Чтение из файла ");
                string mode = Console.ReadLine();
                string text = "";
                do
                {
                    if (mode == "2") text = FileIO.OpenFile();
                    Console.WriteLine("Выбирите шифр из предложенных ниже");
                    Console.ForegroundColor = ConsoleColor.Red;
                    CipherBase.ShowName();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    selectCyph = Console.ReadLine();
                    do
                    {
                        if (mode == "1")
                            CipherBase.GetCypher(selectCyph).Handler();
                        else
                            CipherBase.GetCypher(selectCyph).Handler(text);
                        Console.WriteLine("Меню шифров: \"<\". Продолжить \"Enter\"");
                    }
                    while (Console.ReadLine() != "<");
                    Console.WriteLine("Метод обработки: \"<\". Продолжить \"Enter\"");
                } while (Console.ReadLine() != "<");
            }

        }
    }
}