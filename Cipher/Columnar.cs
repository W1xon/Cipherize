namespace Cipher
{
    internal class Columnar : Cypher, ICryptoActionWithKey
    {
        char[,] table;
        public override void Handler()
        {
            Console.WriteLine("Что хотите выбрать?\n" +
                "1) Зашифровать\n" +
                "2) Расшифровать");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Введите текст: ");
                    Text.Append(Console.ReadLine());
                    Console.Write("Введите ключ: ");
                    KeyInt = int.Parse(Console.ReadLine());
                    Console.WriteLine("Результат шифрования: " + Encryption(Text.ToString(), KeyInt));
                    break;
                case "2":
                    Console.Write("Введите криптограмму: ");
                    Cryptogram.Append(Console.ReadLine());
                    Console.Write("Введите ключ: ");
                    KeyInt = int.Parse(Console.ReadLine());
                    Console.WriteLine("Результат расшифровки: " + Decryption(Cryptogram.ToString(), KeyInt)); 
                    break;
            }
            Clear();
        }
        public string Encryption(string Text, int KeyInt)
        {
            table = CreateTable(Text.Length, KeyInt);
            int counter = 0;
            for (int i = 0; i < table.GetLength(1) && counter < Text.Length; i++)
            {
                for (int j = 0; j < table.GetLength(0) && counter < Text.Length; j++)
                {
                    table[j, i] = Text[counter];
                    counter++;
                }
            }

            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    Cryptogram.Append(table[i, j]);
                }
            }
            return Cryptogram.ToString();
        }
        public string Decryption(string Cryptogram, int KeyInt)
        {
            table = CreateTable(Cryptogram.Length, KeyInt);
            int counter = 0;
            for (int i = 0; i < table.GetLength(0) && counter < Cryptogram.Length; i++)
            {
                for (int j = 0; j < table.GetLength(1) && counter < Cryptogram.Length; j++)
                {
                    table[i, j] = Cryptogram[counter];
                    counter++;
                }
            }
            for (int i = 0; i < table.GetLength(1); i++)
            {
                for (int j = 0; j < table.GetLength(0); j++)
                {
                     Text.Append(table[j, i]);
                }
            }
            return Text.ToString();
        }
        private char[,] CreateTable(double len, int size)
        {
            return new char[(int)Math.Ceiling(len / size), size];
        }
    }
}
