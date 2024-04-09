using System;

namespace Cipher
{
    internal class Vernam : Cypher, ICryptoActionWithWord, ICryptoActionKeyBit
    {
        public string Encryption(string text, string key)
        {
            string signature = CreateSignature(key, text.Length);
            string binaryCrypptogram = "";
            for (int i = 0; i < text.Length; i++)
            {
                char encryptLetter = (char)(text[i] ^ signature[i]);
                binaryCrypptogram += Convert.ToString(encryptLetter, 2);
                if (char.IsControl(encryptLetter))
                {
                    Cryptogram.Append(string.Format("\\u{0:X2}", (int)encryptLetter));
                }
                else
                    Cryptogram.Append(encryptLetter.ToString());
            }
            return Cryptogram.ToString() + "\n" + binaryCrypptogram;
        }
        public string Decryption(string cryptogram, string key)
        {
            string signature = CreateSignature(key, cryptogram.Length);
            for (int i = 0; i < cryptogram.Length; i++)
            {
                char encryptLetter = (char)(cryptogram[i] ^ signature[i]);
                if (char.IsControl(encryptLetter))
                {
                    Text.Append(string.Format("\\u{0:X2}", (int)encryptLetter));
                }
                else
                    Text.Append(encryptLetter.ToString());
            }
            return Text.ToString();
        }
        public string EncryptionBit(string text, string key)
        {
            string signature = CreateSignature(key, text.Length);
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsNumber(text[i]))
                    Cryptogram.Append(int.Parse(text[i].ToString()) ^ int.Parse(signature[i].ToString()));
                else Cryptogram.Append(text[i]);
            }
            return Cryptogram.ToString();
        }
        public string DecryptionBit(string cryptogram, string key)
        {
            string signature = CreateSignature(key, cryptogram.Length);
            for (int i = 0; i < cryptogram.Length; i++)
            {
                if (char.IsNumber(cryptogram[i]))
                    Text.Append(int.Parse(cryptogram[i].ToString()) ^ int.Parse(signature[i].ToString()));
                else Text.Append(cryptogram[i]);
            }
            return Text.ToString();
        }
        public override void Handler(string text = "")
        {
            Console.WriteLine("Что хотите выбрать?\n" +
                "1) Зашифровать\n" +
                "2) Расшифровать\n" +
                "3) Зшифровать биты\n" +
                "4) Расшифровать биты");
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
                case "3":
                    if (text != "")
                    {
                        Console.WriteLine("Исходный текст в битовом формате: " + text);
                        Text.Append(text);
                    }
                    else
                    {
                        Console.Write("Введите текст в битовом формате: ");
                        Text.Append(Console.ReadLine());
                    }
                    Console.Write("Введите ключ: ");
                    KeyStr = Console.ReadLine();
                    Console.WriteLine("Результат шифрования: " + EncryptionBit(Text.ToString(), KeyStr));
                    break;
                case "4":
                    if (text != "")
                    {
                        Console.WriteLine("Исходная криптограмма в битовом формате: " + text);
                        Cryptogram.Append(text);
                    }
                    else
                    {
                        Console.Write("Введите криптограмму в битовом формате: ");
                        Cryptogram.Append(Console.ReadLine());
                    }
                    Console.Write("Введите ключ: ");
                    KeyStr = Console.ReadLine();
                    Console.WriteLine("Результат расшифровки: " + DecryptionBit(Cryptogram.ToString(), KeyStr));
                    break;
            }
            Clear();
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
    }
}
