using HubDeJogos.JogoDaVelha.Utils;
using HubDeJogos.BatalhaNaval.Utils;
using HubDeJogos.Views;

namespace HubDeJogos.JogoDaVelha {

    
    class Program {

        
        
        
        public static void Main(string[] args)
        {

            List<Jogador> jogadores = new List<Jogador>();
            ManipulaArquivo.LeArquivo(jogadores);
            List<int> jogadorLogin = new List<int>();
            bool isLogged = false;
        
            int opcao = -1;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[1] - Ver Jogadores(a)");
                Console.WriteLine("[2] - Registrar jogadores(a)");
                Console.WriteLine("[3] - Jogo da Velha");
                Console.WriteLine("[4] - Batalha Naval");
                Console.WriteLine("[0] - Sair\n");

                Console.Write("Escolha: ");
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
                        InicioJV jogoDaVelha = new InicioJV();
                        jogoDaVelha.JogoDaVelhaInicio();
                        break;
                    case 4:
                        if (Jogador.IsLogged(jogadores, jogadorLogin))
                        {
                            // LogicaBatalhaNaval batalhaNaval = new LogicaBatalhaNaval();
                            BatalhaNaval.InicioBN batalhaNaval = new BatalhaNaval.InicioBN();
                            batalhaNaval.BatalhaNavalInicio();
                        }
                        else
                        {
                            Jogador.Login(jogadores, jogadorLogin);
                        }
                        break;
                    case 5:
                        Console.WriteLine("Login");
                        isLogged = Jogador.IsLogged(jogadores, jogadorLogin);
                        break;
                    case 6:
                        Console.WriteLine("Ranking");
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