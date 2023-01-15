using HubDeJogos.JogoDaVelha.Utils;

namespace HubDeJogos.JogoDaVelha {

    
    class Program {
        
        public static void Main(string[] args)
        {
            int opcao = -1;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[1] - Ver Jogadores(a)");
                Console.WriteLine("[2] - Registrar jogadores(a)");
                Console.WriteLine("[3] - Jogo da Velha");
                Console.WriteLine("[4] - Jogo Misterioso");
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
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Registrando jogadores(a) ");
                        Console.ReadKey();
                        break;
                    case 3:
                        Inicio jogoDaVelha = new Inicio();
                        jogoDaVelha.JogoDaVelhaInicio();
                        break;
                    case 4:
                        Console.WriteLine("Jogo Misterioso ");
                        Console.ReadKey();
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