using System;
using System.Runtime.CompilerServices;

namespace Cipher
{
    internal class Atbash : Cypher, ICryptoActionWithoutKey
    {
        public string Encryption(string text)
        {
            int index;
            DefineLocalAlphabet(text.ToLower());
            foreach (char letter in text)
            {
                index = Array.IndexOf(alphabetLocalLetters, letter.ToString().ToLower()[0]);
                if (index == -1)
                    Cryptogram.Append(letter);
                else
                    Cryptogram.Append(StrManage.RegistorCorrection(letter, alphabetLocalLetters[alphabetLocalLetters.Length - (index + 1)]));
            }
            return Cryptogram.ToString();
        }
        public string Decryption(string cryptogram)
        {
            int index;
            DefineLocalAlphabet(cryptogram.ToLower());
            foreach (char letter in cryptogram)
            {
                index = Array.IndexOf(alphabetLocalLetters, letter.ToString().ToLower()[0]);
                if (index == -1)
                    Text.Append(letter);
                else
                    Text.Append(StrManage.RegistorCorrection(letter, alphabetLocalLetters[alphabetLocalLetters.Length - (index + 1)]));
            }
            return Text.ToString();
        }

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
    }
}
