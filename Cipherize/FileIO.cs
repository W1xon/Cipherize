using System.IO;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
namespace Cipher
{
    public class FileIO
    {
        static OpenFileDialog openFileDialog;
        static SaveFileDialog saveFileDialog;
        static StreamWriter sw;
        static StreamReader sr;
        private static string Read(string path)
        {
            string text;
            using (sr = new StreamReader(path))
            {
                text = sr.ReadToEnd();
            }
            return text;
        }
        private static void Write(string path, string text)
        {
            using (sw = new StreamWriter(path))
            {
                sw.Write(text);
            }
        }
        public static string OpenFile()
        {
            string text = "";
            using (openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Текстовый файл(*.txt) | *.txt";
                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    text = Read(openFileDialog.FileName);
                }
            }
            return text;
        }
        public static void SaveFile(string text)
        {
            using (saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Текстовый файл(*.txt) | *.txt";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                   Write(saveFileDialog.FileName, text);
                }
            }
        }
    }
}
