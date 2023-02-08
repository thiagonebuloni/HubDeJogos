using HubDeJogos.JogoDaVelha.Utils;
using HubDeJogos.BatalhaNaval.Utils;
using HubDeJogos.Views;

namespace HubDeJogos.JogoDaVelha {

    
    class Program {

        
        
        
        public static void Main(string[] args)
        {

            List<Jogador> jogadores = new List<Jogador>();
            ManipulaArquivo.LeArquivo(jogadores);
            List<string> jogadoresLogin = new List<string>();
            bool isLogged = false;
        
            int opcao = -1;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[1] - Ver ranking de Jogadores(as)");
                Console.WriteLine("[2] - Registrar jogadores(as)");
                Interface.ICores("[3] - Jogo da Velha\n", ConsoleColor.Yellow);
                Interface.ICores("[4] - Batalha Naval\n", ConsoleColor.Yellow);
                Interface.ICores("[5] - Login\n", ConsoleColor.DarkGreen);
                Interface.ICores("[6] - Logout\n", ConsoleColor.DarkGreen);
                Interface.ICores("[0] - Sair\n", ConsoleColor.DarkGreen);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nEscolha: ");
                try
                {
                    opcao = int.Parse(Console.ReadLine()!);
                }
                catch
                {
                    Interface.ICores("Opção inválida. Aperte Enter para tentar novamente. ", ConsoleColor.Red);
                    Console.ReadKey();
                    continue;
                }

                switch (opcao)
                {
                    case 0:
                        break;
                    case 1:
                        Console.WriteLine("Mostrando jogadores(a) ");
                        Jogador.IVerRankingMain(jogadores);
                        break;
                    case 2:
                        Console.WriteLine("Registrando jogadores(a) ");
                        Jogador.RegistrarJogador(jogadores, jogadores.Count());
                        break;
                    case 3:
                        if (Jogador.IsLogged(jogadores, jogadoresLogin))
                        {
                            InicioJV jogoDaVelha = new InicioJV();
                            jogoDaVelha.JogoDaVelhaInicio();
                        }
                        else
                        {
                            Jogador.Login(jogadores, jogadoresLogin);
                        }
                        break;
                    case 4:
                        if (Jogador.IsLogged(jogadores, jogadoresLogin))
                        {
                            BatalhaNaval.InicioBN batalhaNaval = new BatalhaNaval.InicioBN();
                            batalhaNaval.BatalhaNavalInicio();
                        }
                        else
                        {
                            Jogador.Login(jogadores, jogadoresLogin);
                        }
                        break;
                    case 5:
                        isLogged = Jogador.IsLogged(jogadores, jogadoresLogin);
                        break;
                    case 6:
                        Jogador.Logout(jogadoresLogin);
                        break;
                    default:
                        Interface.ICores("Opção inválida. Aperte enter para tentar novamente.", ConsoleColor.Red);
                        Console.ReadKey();
                        break;
                }
            }
            while (opcao != 0);

        }
    }
}