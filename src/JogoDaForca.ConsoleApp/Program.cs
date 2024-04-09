namespace JogoDaForca.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Palavras disponíveis para o jogo
            string[] palavras = {"ABACATE", "ABACAXI", "ACEROLA", "AÇAÍ", "ARAÇA", "BACABA",
                             "BACURI", "BANANA", "CAJÁ", "CAJÚ", "CARAMBOLA", "CUPUAÇU",
                             "GRAVIOLA", "GOIABA", "JABUTICABA", "JENIPAPO", "MAÇÃ",
                             "MANGABA", "MANGA", "MARACUJÁ", "MURICI", "PEQUI", "PITANGA",
                             "PITAYA", "SAPOTI", "TANGERINA", "UMBU", "UVA", "UVAIA"};

            Random random = new Random();
            string palavraEscolhida = palavras[random.Next(palavras.Length)]; // Escolha aleatória da palavra
            char[] letrasDaPalavra = palavraEscolhida.ToCharArray(); // Converte a palavra em um array de caracteres
            MontarForca(1, letrasDaPalavra, palavraEscolhida);
        }

        static void MontarForca(int letrasErradas, char[] letrasDaPalavra, string palavraEscolhida)
        {
            char[] letrasCorretas = new char[letrasDaPalavra.Length]; // Array para armazenar as letras corretas já adivinhadas
            for (int i = 0; i < letrasCorretas.Length; i++)
            {
                letrasCorretas[i] = '_'; // Inicializa com underline para indicar letras ainda não adivinhadas

            }



            bool jogoTerminado = false; // Indicar se o jogo terminou

            while (!jogoTerminado)
            {
                Console.Clear();
                Console.WriteLine("Palavra: " + string.Join(" ", letrasCorretas));


                string cabecaDoBoneco = letrasErradas >= 1 ? " o " : " ";
                string tronco = letrasErradas >= 2 ? "x" : " ";
                string troncoBaixo = letrasErradas >= 2 ? " x " : " ";
                string bracoEsquerdo = letrasErradas >= 3 ? "/" : " ";
                string bracoDireito = letrasErradas >= 3 ? @"\" : " ";
                string pernas = letrasErradas >= 4 ? "/ \\" : " ";


                Console.WriteLine(" ___________        ");
                Console.WriteLine(" |/        |        ");
                Console.WriteLine(" |        {0}       ", cabecaDoBoneco);
                Console.WriteLine(" |        {0}{1}{2} ", bracoEsquerdo, tronco, bracoDireito);
                Console.WriteLine(" |        {0}       ", troncoBaixo);
                Console.WriteLine(" |        {0}       ", pernas);
                Console.WriteLine(" |                  ");
                Console.WriteLine(" |                  ");
                Console.WriteLine("_|____              ");

                // Verifica se o jogador perdeu
                if (letrasErradas >= 5)
                {
                    Console.WriteLine("Você perdeu! A palavra era: " + palavraEscolhida);
                    break;
                }

                Console.Write("Digite uma letra: ");
                char letra = char.ToUpper(Console.ReadKey().KeyChar);

                // Verifica se a letra já foi escolhida
                if (letrasCorretas.Contains(letra))
                {
                    Console.WriteLine("\nVocê já escolheu essa letra. Tente outra.");
                    continue;
                }

                // Verifica se a letra está na palavra
                bool letraEncontrada = false;
                for (int i = 0; i < letrasDaPalavra.Length; i++)
                {
                    if (letrasDaPalavra[i] == letra)
                    {
                        letrasCorretas[i] = letra;
                        letraEncontrada = true;
                    }
                }

                if (!letraEncontrada)
                {
                    Console.WriteLine("\nLetra não encontrada na palavra.");
                    letrasErradas++;
                }
                else
                {
                    Console.WriteLine("\nLetra encontrada na palavra!");
                }

                // Verifica se o jogador ganhou
                if (!letrasCorretas.Contains('_'))
                {
                    Console.WriteLine("Parabéns! Você acertou a palavra: " + palavraEscolhida);
                    break;
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
            Console.ReadLine();
        }
    }
}