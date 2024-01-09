using System.Text;

namespace ConsoleApp1
{
    internal class WordFinder
    {
        private IEnumerable<string> _matrix;
        public WordFinder(IEnumerable<string> matrix)
        {
            this._matrix = matrix;

            foreach (var item in matrix)
                Console.WriteLine(item);
        }
        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            var frecPalabras = new Dictionary<string, int>();

            foreach (var word in wordstream)
            {
                var esta = BuscaPalabra(word);
                if (esta)
                {
                    // Cuenta cada palabra una vez sola
                    if (!frecPalabras.ContainsKey(word))
                        frecPalabras.Add(word, 1);
                }
            }

            // top 10 mas repetidas
            var topWords = frecPalabras.OrderByDescending(kv => kv.Value).Take(10).Select(kv => kv.Key);

            return topWords;
        }
        private bool BuscaPalabra(string word)
        {
            //busca horizontalmente de derecha a izquierda
            foreach (string d in this._matrix)
            {
                if (d.ToLower().Contains(word.ToLower()))
                    return true;
            }

            //busca horizontalmente de izquierda a derechad
            foreach (string d in this._matrix)
            {
                if (reverse(d).Contains(word.ToLower()))
                    return true;
            }

            //busca verticalmente
            StringBuilder caracteresVerticales = new StringBuilder();
            for (int col = 0; col < 4; col++)
            {
                foreach (string d in this._matrix)
                    caracteresVerticales.Append(d.Substring(col, 1));

                if (caracteresVerticales.ToString().ToLower().Contains(word.ToLower()))
                    return true;

                if (reverse(caracteresVerticales.ToString()).ToLower().Contains(word.ToLower()))
                    return true;
            }

            return false;
        }
        public static string GenerarStringAleatorio(int longitud)
        {
            Random random = new Random();
            const string alfabeto = "abcdefghijklmnopqrstuvwxyz";

            char[] caracteresAleatorios = new char[longitud];

            for (int i = 0; i < longitud; i++)
            {
                int indice = random.Next(alfabeto.Length);
                caracteresAleatorios[i] = alfabeto[indice];
            }

            return new string(caracteresAleatorios);
        }
        public string reverse(string str)
        {
            return new string(str.Reverse().ToArray());
        }
    }
}

