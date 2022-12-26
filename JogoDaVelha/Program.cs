
using System;
using System.Net.NetworkInformation;

namespace JogoDaVelha
{
    public class Program
    {

        static void ShowMenu()
        {
            Console.WriteLine("1 - Inserir novo jogador");
            Console.WriteLine("2 - Novo Jogo");
            Console.WriteLine("3 - Deletar um jogador");
            Console.WriteLine("4 - Listar todas os jogadores");
            Console.WriteLine("5 - Detalhar um jogador");
            Console.WriteLine("6 - Mostrar Historico de jogadas");
            Console.WriteLine("0 - Para sair do jogo");
            Console.Write("Digite a opção desejada: ");
        }

        static void CadastrarPlayer(List<string> player, List<int> vitorias, List<int> derrotas, List<int> empates)
        {
            
            Console.Write("Digite o nome do player a ser adicionado: ");            
            player.Add(Console.ReadLine());
            vitorias.Add(0);
            derrotas.Add(0);
            empates.Add(0);
        }

        static void RemoverPlayer(List<string> player, List<int> vitorias, List<int> derrotas, List<int> empates)
        {
            Console.Write("Digite o nome do player a ser removido: ");
            string nome = Console.ReadLine();
            int indexParaDeletar = player.FindIndex(playerUm => playerUm == nome);

            if (indexParaDeletar == -1)
            {
                Console.WriteLine("Não foi possível deletar esta Jogador");
                Console.WriteLine("MOTIVO: Jogador não encontrado.");
            }

            player.Remove(nome);
            vitorias.Remove(indexParaDeletar);
            derrotas.Remove(indexParaDeletar);
            empates.Remove(indexParaDeletar);

            
        }

        static void ListarTodosOsPlayer(List<string> player)
        {
            foreach (var item in player)
            {
                Console.WriteLine(item);
            }

        }
        static void DetalharPlayer(List<string> player, List<int> vitorias, List<int> derrotas, List<int> empates)
        {
            Console.Write("Digite o nome do player: ");
            string nome = Console.ReadLine();
            int index = player.FindIndex(nomePlayer => nomePlayer == nome);
            Console.WriteLine($"Nome = {player[index]} | Vitorias = {vitorias[index]} | Derrotas = {derrotas[index]} | Empates ={empates[index]} ");
        }
        static void MostrarHitorico(List<string> historico)
        {
            foreach (var item in historico)
            {
                Console.WriteLine(item);
            }
        }
        static bool VeririficarVelha(int cont)
        {
            if (cont == 9)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        static bool VerificarDiagonais(string[,] board)
        {
            bool diagonalPrincipal = board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] != "";
            bool diagonalSecundaria = board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[0, 2] != "";

            if (diagonalPrincipal == true || diagonalSecundaria == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool VerificarHorizontais(string[,] board)
        {
            bool horizontalZero = board[0, 0] == board[0, 1] && board[0, 1] == board[0, 2] && board[0, 0] != "";
            bool horizontalUm = board[0, 0] == board[0, 1] && board[0, 1] == board[0, 2] && board[0, 0] != "";
            bool horizontalDois = board[2, 0] == board[2, 1] && board[2, 1] == board[2, 2] && board[2, 0] != "";

            if (horizontalZero == true || horizontalUm == true || horizontalDois == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool VerificarVerticais(string[,] board)
        {
            bool verticalZero = board[0, 0] == board[1, 0] && board[1, 0] == board[2, 0] && board[0, 0] != "";
            bool verticalUm = board[0, 1] == board[1, 1] && board[1, 1] == board[2, 1] && board[0, 1] != "";
            bool verticalDois = board[0, 2] == board[1, 2] && board[1, 2] == board[2, 2] && board[0, 2] != "";
            if (verticalZero == true || verticalUm == true || verticalDois == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool FimDeJogo(int cont, string[,] board)
        {
            
            if (VeririficarVelha(cont)  ||  VerificarHorizontais(board) || VerificarVerticais(board) || VerificarDiagonais(board))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static string ValidarJogador(List<string> player)
        {
            bool gameOver = false; 
            bool nomeUm = false, nomeDois = false;
            int indexParaJogarUm, indexParaJogarDois;                        
           
                    Console.Write("Digite o nome do Jogador: ");
                    string nomePlayerUm = Console.ReadLine();
                    while (nomeUm == false)
                    {
                        indexParaJogarUm = player.FindIndex(playerUm => playerUm == nomePlayerUm);

                        if (indexParaJogarUm == -1)
                        {
                            Console.WriteLine("Jogador não cadastrado!");
                            Console.WriteLine("Digite 1 para inserir o nome de um jogador cadastrado!");
                            Console.WriteLine("Caso nao tenha cadastro digite 2 e volte ao menu principal para cadastrar.");
                            int aux = int.Parse(Console.ReadLine());

                            if (aux == 1)
                            {
                                Console.Write("Digite o nome do Jogador:");
                                nomePlayerUm = Console.ReadLine();
                            }
                            else if (aux == 2)
                            {
                                nomeUm = true;
                                gameOver = true;
                            }
                        }
                        else
                        {
                            nomeUm = true;
                        }

                    }
            return nomePlayerUm;
        }

        static void JogoDaVelaha(List<string> player, List<int> vitorias, List<int> derrotas, List<int> empates, List<string> historico)
        {
            string[,] board = { { "", "", "" }, { "", "", "" }, { "", "", "" } };

            bool gameOver = false, verificarVelha = false;
            int contadorVelha = 0;
            string jogadorUm = "X", jogadorDois = "O";
            bool nomeUm = false, nomeDois = false;
            int indexParaJogarUm, indexParaJogarDois;

            string playerUm = ValidarJogador(player);
            string playerDois = ValidarJogador(player);
            int indexPlayerUm = player.FindIndex(playerUm => playerUm == playerUm);
            int indexPlayerDois = player.FindIndex(playerDois => playerDois == playerDois);


            Console.WriteLine("Current board:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }

            while (gameOver == false)
            {

                for (int i = 0; i == 0;)
                {
                    // Prompt the current player to make a move
                    Console.WriteLine($"Jogador {jogadorUm}, insira a linha e a coluna para a sua jogada: ");
                    string[] move = Console.ReadLine().Split();
                    int row = int.Parse(move[0]);
                    int col = int.Parse(move[1]);

                    Console.WriteLine();

                    if (board[row, col] == "")
                    {
                        // Update the board with the player's move
                        board[row, col] = jogadorUm;
                        i = 1;
                        contadorVelha++;

                        Console.WriteLine("Current board:");
                        Console.WriteLine();
                        for (int k = 0; k < 3; k++)
                        {
                            for (int j = 0; j < 3; j++)
                            {

                                Console.Write(board[k, j] + " ");
                            }
                            Console.WriteLine();

                        }
                    ;
                        verificarVelha = VeririficarVelha(contadorVelha);

                        if (verificarVelha == true)
                        {
                            Console.WriteLine("Deu velha!");
                            gameOver = true;
                            empates[indexPlayerUm] += 1;
                            empates[indexPlayerDois] += 1;
                            historico.Add($"Jogo entre {playerUm} e {playerDois}: Velha.");
                        }
                        gameOver = FimDeJogo(contadorVelha, board);
                        if (gameOver == true && verificarVelha == false)
                        {
                            Console.WriteLine("Fimde Jogo!");
                            Console.WriteLine("Jogador 1 (X) ganhou!");

                            vitorias[indexPlayerUm] += 1;
                            derrotas[indexPlayerDois] += 1;
                            historico.Add($"Jogo entre {playerUm} e {playerDois}: {playerUm} ganhou!");

                        }
                    }
                    else
                    {
                        Console.WriteLine("Posição ocupada.");
                        Console.WriteLine("Por Favor digite uma nova posição:");
                    }

                }

                if (verificarVelha == false)
                {
                    for (int i = 0; i == 0;)
                    {
                        // Prompt the current player to make a move
                        Console.WriteLine($"Jogador {jogadorDois}, insira a linha e a coluna para a sua jogada: ");
                        string[] move = Console.ReadLine().Split();
                        int row = int.Parse(move[0]);
                        int col = int.Parse(move[1]);
                        Console.WriteLine();

                        if (board[row, col] == "")
                        {
                            // Update the board with the player's move
                            board[row, col] = jogadorDois;
                            i = 1;
                            contadorVelha++;

                            for (int k = 0; k < 3; k++)
                            {
                                for (int j = 0; j < 3; j++)
                                {

                                    Console.Write(board[k, j] + " ");
                                }
                                Console.WriteLine();
                            }
                            verificarVelha = VeririficarVelha(contadorVelha);

                            if (verificarVelha == true)
                            {
                                Console.WriteLine("Deu velha!");
                                gameOver = true;
                                empates[indexPlayerUm] += 1;
                                empates[indexPlayerDois] += 1;
                                historico.Add($"Jogo entre {playerUm} e {playerDois}: Velha.");
                            }

                            gameOver = FimDeJogo(contadorVelha, board);
                            if (gameOver == true && verificarVelha == false)
                            {
                                Console.WriteLine("Fimde Jogo!");
                                Console.WriteLine("Jogador 2 (O) ganhou!");

                                vitorias[indexPlayerDois] += 1;
                                derrotas[indexPlayerUm] += 1;
                                historico.Add($"Jogo entre {playerUm} e {playerDois}: {playerDois} ganhou!");

                            }

                        }
                        else
                        {
                            Console.WriteLine("Posição ocupada.");
                            Console.WriteLine("Por Favor digite uma nova posição:");

                        }

                    }
                }
            }
        }
        
        public static void Main(string[] args)
        {
            List<string> player = new List<string>();
            List<string> historico = new List<string>();
            List<int> vitorias = new List<int>();
            List<int> derrotas = new List<int>();
            List<int> empates = new List<int>();
            int[,] jogo = new int[2, 2];

            int option;

            do
            {
                ShowMenu();
                option = int.Parse(Console.ReadLine());

                Console.WriteLine("-----------------");

                switch (option)
                {
                    case 0:
                        Console.WriteLine("Estou encerrando o programa...");
                        break;
                    case 1:
                        CadastrarPlayer(player, vitorias, derrotas, empates);
                        break;
                    case 2:
                        JogoDaVelaha(player, vitorias, derrotas, empates, historico);
                        break;
                    case 3:
                        Console.WriteLine("Digite ");
                        RemoverPlayer(player, vitorias, derrotas, empates);
                        break;
                    case 4:
                        ListarTodosOsPlayer(player);
                        break;
                    case 5:
                        DetalharPlayer(player, vitorias, derrotas, empates);
                            break;
                    case 6:
                        MostrarHitorico(historico);
                        break;
                }

                Console.WriteLine("-----------------");

            } while (option != 0);






            

        } 
    }
}
