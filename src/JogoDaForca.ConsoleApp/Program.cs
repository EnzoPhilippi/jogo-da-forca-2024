    using System;

    namespace ForcaGame
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Inicializa o jogo
                JogoForca jogo = new JogoForca();
                jogo.Iniciar();
            }
        }

        class JogoForca
        {
            private string[] palavras = {"ABACATE", "ABACAXI", "ACEROLA", "AÇAÍ", "ARAÇA", "BACABA",
                                 "BACURI", "BANANA", "CAJÁ", "CAJÚ", "CARAMBOLA", "CUPUAÇU",
                                 "GRAVIOLA", "GOIABA", "JABUTICABA", "JENIPAPO", "MAÇÃ",
                                 "MANGABA", "MANGA", "MARACUJÁ", "MURICI", "PEQUI", "PITANGA",
                                 "PITAYA", "SAPOTI", "TANGERINA", "UMBU", "UVA", "UVAIA"};

            private string palavraEscolhida;
            private char[] letrasDaPalavra;
            private char[] letrasCorretas;
            private int letrasErradas;

            public void Iniciar()
            {
                Random random = new Random();
                palavraEscolhida = palavras[random.Next(palavras.Length)];
                letrasDaPalavra = palavraEscolhida.ToCharArray();
                letrasCorretas = new char[letrasDaPalavra.Length];
                for (int i = 0; i < letrasCorretas.Length; i++)
                {
                    letrasCorretas[i] = '_';
                }
                letrasErradas = 0;
                Jogar();
            }

            private void Jogar()
            {
                while (true)
                {
                    MostrarForca();

                    if (VerificarFimJogo())
                        break;

                    Console.Write("Digite uma letra: ");
                    char letra = char.ToUpper(Console.ReadKey().KeyChar);

                    if (VerificarLetraEscolhida(letra))
                        continue;

                    if (VerificarLetraNaPalavra(letra))
                        Console.WriteLine("\nLetra encontrada na palavra!");
                    else
                    {
                        Console.WriteLine("\nLetra não encontrada na palavra.");
                        letrasErradas++;
                    }

                    if (VerificarVitoria())
                    {
                        Console.WriteLine("Parabéns! Você acertou a palavra: " + palavraEscolhida);
                        break;
                    }

                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }

                Console.ReadLine();
            }

            private void MostrarForca()
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
            }

            private bool VerificarFimJogo()
            {
                if (letrasErradas >= 5)
                {
                    Console.WriteLine("Você perdeu! A palavra era: " + palavraEscolhida);
                    return true;
                }
                return false;
            }

            private bool VerificarLetraEscolhida(char letra)
            {
                if (letrasCorretas.Contains(letra))
                {
                    Console.WriteLine("\nVocê já escolheu essa letra. Tente outra.");
                    return true;
                }
                return false;
            }

            private bool VerificarLetraNaPalavra(char letra)
            {
                bool letraEncontrada = false;
                for (int i = 0; i < letrasDaPalavra.Length; i++)
                {
                    if (letrasDaPalavra[i] == letra)
                    {
                        letrasCorretas[i] = letra;
                        letraEncontrada = true;
                    }
                }
                return letraEncontrada;
            }

            private bool VerificarVitoria()
            {
                if (!letrasCorretas.Contains('_'))
                    return true;
                return false;
            }
        }
    }