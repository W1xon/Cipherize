namespace Cipher
{
    internal class StrManage
    {
        private static char[] alphabetLowerLetters = [
           'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я',

            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
       ];
        public static string RegistorCorrection(char c1, char c2 )
        {
            if (alphabetLowerLetters.Contains(c1)) return c2.ToString().ToLower();
            return c2.ToString().ToUpper();
        }
    }
}
