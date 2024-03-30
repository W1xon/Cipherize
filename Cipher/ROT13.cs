namespace Cipher
{
    internal class ROT13 : Cypher, ICryptoActionWithoutKey
    {
        private Caesar caesar13 = new Caesar();
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
                    Console.WriteLine(Encryption(Text.ToString()));
                    break;
                case "2":
                    Console.Write("Введите криптограмму: ");
                    Cryptogram.Append(Console.ReadLine());
                    Console.WriteLine(Decryption(Cryptogram.ToString()));
                    break;
            }
            Clear();
        }
        public  string Encryption(string text)
        {
            return caesar13.Encryption(text, 13);
        }
        public  string Decryption(string cryptogram)
        {
            return caesar13.Decryption(cryptogram, 13);
        }
    }
}
