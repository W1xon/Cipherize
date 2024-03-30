namespace Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            string selectCyph;
            Console.WriteLine("Добро пожаловать!!!");
            while (true)
            {
                Console.WriteLine("Выбирите шифр из предложенных ниже");
                Console.ForegroundColor = ConsoleColor.Red;
                CipherBase.ShowName();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                selectCyph = Console.ReadLine();
                do
                {
                    CipherBase.GetCypher(selectCyph).Handler();
                    Console.WriteLine("Главное меню: \"<\". Продолжить \"Enter\"");
                }
                while (Console.ReadLine() != "<");
            }


        }
    }
}