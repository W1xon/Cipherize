using System;
using static System.Net.Mime.MediaTypeNames;

namespace Cipher
{
    internal class ROT13 : Cypher, ICryptoActionWithoutKey
    {
        private Caesar caesar13 = new Caesar();
        public override void Handler(string text = "")
        {
            Console.WriteLine("Что хотите выбрать?\n" +
                "1) Зашифровать\n" +
                "2) Расшифровать");

            switch (Console.ReadLine())
            {
                case "1":
                    if (text != "")
                    {
                        Console.WriteLine("Исходный текст: " + text);
                        Text.Append(text);
                    }
                    else
                    {
                        Console.Write("Введите текст: ");
                        Text.Append(Console.ReadLine());
                    }
                    Console.WriteLine("Результат шифрования: " + Encryption(Text.ToString()));
                    break;
                case "2":
                    if (text != "")
                    {
                        Console.WriteLine("Исходная криптограмма: " + text);
                        Cryptogram.Append(text);
                    }
                    else
                    {
                        Console.Write("Введите криптограмму: ");
                        Cryptogram.Append(Console.ReadLine());
                    }
                    Console.WriteLine("Результат расшифровки: " + Decryption(Cryptogram.ToString()));
                    break;
            }
            Clear();
        }
        public string Encryption(string text)
        {
            string cryptogram = caesar13.Encryption(text, 13);
            caesar13.Clear();
            return cryptogram;
        }
        public  string Decryption(string cryptogram)
        {
            string text = caesar13.Decryption(cryptogram, 13);
            caesar13.Clear();
            return text;
        }
    }
}
