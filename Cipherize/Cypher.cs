using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cipher
{

    public interface ICryptoActionWithKey
    {
        string Encryption(string text, int key);
        string Decryption(string cryptogram, int key);
    }
    public interface ICryptoActionWithWord
    {
        string Encryption(string text, string key);
        string Decryption(string cryptogram, string key);
    }
    public interface ICryptoActionWithoutKey
    {
        string Encryption(string text);
        string Decryption(string cryptogram);
    }
    public interface ICryptoActionKeyBit
    {
        string EncryptionBit(string text, string key);
        string DecryptionBit(string cryptogram, string key);
    }
    public class Cypher
    {
        public Cypher()
        {
            Text = new StringBuilder();
            Cryptogram = new StringBuilder();
        }
        private char[] alphabetRuLetters = {
            'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я'};
        private char[] alphabetEnLetters = {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        protected char[] alphabetLocalLetters;
        protected StringBuilder Text { get; set; }
        protected StringBuilder Cryptogram { get; set; }
        protected string KeyStr { get; set; }
        protected int KeyInt { get; set; }
        public virtual void Handler(string text = "")
        {
        }
        protected void DefineLocalAlphabet(string message)
        {
            for (int i = 0; i < message.Length; i++)
            {
                if (alphabetEnLetters.Contains(message[i]))
                {
                    alphabetLocalLetters = alphabetEnLetters;
                    return;
                }
                else if (alphabetRuLetters.Contains(message[i]))
                {
                    alphabetLocalLetters = alphabetRuLetters;
                    return;
                }
            }
            alphabetLocalLetters = alphabetRuLetters;
        }
        public void Clear()
        {
            Text.Clear();
            Cryptogram.Clear();
            KeyStr = "";
            KeyInt = 0;
        }
    }
}
