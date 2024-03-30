namespace Cipher
{
    internal class CipherBase
    {
        public static Dictionary<string, Cypher> ciphers = new Dictionary<string, Cypher>() { { "Цезарь", new Caesar() }, { "ROT13", new ROT13() }, {"Столбчатого транспонирования", new Columnar() },
            { "Виженёр", new Vigenere()}, {"Атбаш", new Atbash() }, {"Вернам", new Vernam() } };
        public static void ShowName()
        {
            int counter = 0;
            foreach (string key in ciphers.Keys)
            {
                Console.WriteLine($"{++counter}) {key}.");
            }
        }
        public static Cypher GetCypher(string nameOrNumber)
        {
            if (ciphers.ContainsKey(nameOrNumber))
                return ciphers.First(x => x.Key == nameOrNumber).Value;
            else
                return ciphers[ciphers.Keys.ToList()[int.Parse(nameOrNumber) - 1]];
        }
    }
}
