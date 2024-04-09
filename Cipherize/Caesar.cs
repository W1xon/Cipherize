using System;
using System.Linq;
using static Cipher.StrManage;
namespace Cipher
{
    public class Caesar : Cypher, ICryptoActionWithKey
    {
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
                    Console.Write("Введите ключ: ");
                    KeyInt = int.Parse(Console.ReadLine());
                    Console.WriteLine("Результат шифрования: " + Encryption(Text.ToString(), KeyInt));
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
                    Console.Write("Введите ключ: ");
                    KeyInt = int.Parse(Console.ReadLine());
                    Console.WriteLine("Результат расшифровки: " + Decryption(Cryptogram.ToString(), KeyInt));
                    break;
            }
            Clear();
        }
        public string Encryption(string text, int key)
        {
            DefineLocalAlphabet(text.ToLower());
            foreach (char c in text)
            {
                int index = 0;
                if (alphabetLocalLetters.Contains(c.ToString().ToLower()[0]))
                {
                    index = Array.IndexOf(alphabetLocalLetters, c.ToString().ToLower()[0]);
                    if (index + key >= alphabetLocalLetters.Length)
                    {
                        Cryptogram.Append(RegistorCorrection(c, alphabetLocalLetters[(index + key) % alphabetLocalLetters.Length]));
                    }
                    else
                        Cryptogram.Append(RegistorCorrection(c, alphabetLocalLetters[index + key]));
                }
                else
                    Cryptogram.Append(c);
            }
            return Cryptogram.ToString();
        }
        public  string Decryption(string cryptogram, int key)
        {
            DefineLocalAlphabet(cryptogram.ToLower());
            foreach (char c in cryptogram)
            {
                int index = 0;
                if (alphabetLocalLetters.Contains(c.ToString().ToLower()[0]))
                {
                    index = Array.IndexOf(alphabetLocalLetters, c.ToString().ToLower()[0]);
                    if (index - key < 0)
                    {
                        Text.Append(RegistorCorrection(c, alphabetLocalLetters[alphabetLocalLetters.Length - (key - index)]));
                    }
                    else
                        Text.Append(RegistorCorrection(c, alphabetLocalLetters[index - key]));
                }
                else
                    Text.Append(c);
            }
            return Text.ToString();
        }
    }
}
