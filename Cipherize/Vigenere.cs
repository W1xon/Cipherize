using System;
using System.Collections.Generic;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Cipher
{
    internal class Vigenere : Cypher, ICryptoActionWithWord
    {
        private char[,] square;
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
                    KeyStr = Console.ReadLine();
                    Console.WriteLine("Результат шифрования: " + Encryption(Text.ToString(), KeyStr));
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
                    KeyStr = Console.ReadLine();
                    Console.WriteLine("Результат расшифровки: " + Decryption(Cryptogram.ToString(), KeyStr));
                    break;
            }
            Clear();
        }
        public string Encryption(string text, string key)
        {
            key = key.ToLower();
            string signature = CreateSignature(key, text.Length);
            DefineLocalAlphabet(text.ToLower());
            CreateSquare(alphabetLocalLetters);
            for (int i = 0; i < text.Length; i++)
            {
                int index = Array.IndexOf(alphabetLocalLetters, text.ToString().ToLower()[i]);
                if (index == -1)
                    Cryptogram.Append(text[i]);
                else
                {
                    Cryptogram.Append(StrManage.RegistorCorrection(text[i], square[Array.IndexOf(alphabetLocalLetters, signature[i]), Array.IndexOf(alphabetLocalLetters, text.ToLower()[i])]));

                }
            }
            //Вывод квадрата виженера
            ShowSquare(text, key);
            return Cryptogram.ToString();
        }
        public void ShowSquare(string text, string key)
        {
            for (int i = 0; i < square.GetLength(0); i++)
            {
                for (int j = 0; j < square.GetLength(1); j++)
                {
                    if (text.ToLower().Contains(square[i, j]) && i == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(square[i, j] + "  ");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }
                    else if (key.ToLower().Contains(square[i, j]) && j == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(square[i, j] + "  ");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }
                    else
                        Console.Write(square[i, j] + "  ");
                }
                Console.WriteLine();
            }
        }
        public string Decryption(string cryptogram, string key)
        {
            key = key.ToLower();
            string signature = CreateSignature(key, cryptogram.Length);
            DefineLocalAlphabet(cryptogram.ToLower());
            CreateSquare(alphabetLocalLetters);
            for (int i = 0; i < cryptogram.Length; i++)
            {
                int index = Array.IndexOf(alphabetLocalLetters, cryptogram.ToString().ToLower()[i]);
                if (index == -1)
                    Text.Append(cryptogram[i]);
                else
                {
                    string offsetAlphabet = "";
                    for (int j = 0; j < alphabetLocalLetters.Length; j++)
                    {
                        offsetAlphabet += square[Array.IndexOf(alphabetLocalLetters, signature[i]), j];
                    }
                    Text.Append(square[0, offsetAlphabet.IndexOf(cryptogram.ToLower()[i])]);
                }
            }
            return Text.ToString();
        }
        private string CreateSignature(string key, int textLen)
        {
            string signature = "";
            for (int i = 0; i < textLen; i++)
            {
                signature += key[i % key.Length];
            }
            return signature;
        }
        private void CreateSquare(char[] alphabet)
        {
            List<char> letters = alphabet.ToList();
            square = new char[alphabet.Length, alphabet.Length];
            for (int i = 0; i < square.GetLength(0); i++)
            {
                for (int j = 0; j < square.GetLength(1); j++)
                {
                    square[i, j] = letters[j];
                }
                char let = letters[0];
                letters.RemoveAt(0);
                letters.Add(let);
            }
        }
    }
}
