using HubDeJogos.BatalhaNaval.Utils;
using HubDeJogos.Views;
using System.Text.Json;

namespace HubDeJogos.BatalhaNaval;

    public class InicioBN
    {

        public static string path = @"data/";
        public static string file = @"ranking.json";
        public string FullPath { get; private set; } = null!;

        public static string Arquivo()
        {
            return System.IO.Path.Combine(path, file);
        }

        string fullPath = Arquivo();

        public void BatalhaNavalInicio()
        {

            List<Jogador> jogadores = new List<Jogador>();
            

            
            ManipulaArquivo.LeArquivo(jogadores);

            int opcao = -1;
            do
            {
                Interface.IShowMenu();
                Console.Write("O que você quer fazer? ");
                    try
                    {
                        opcao = int.Parse(Console.ReadLine()!);
                    }
                    catch (Exception)
                    {
                        Interface.ICores("Opção inválida. Aperte Enter para tentar novamente.", ConsoleColor.Red);
                        Console.ReadKey();
                        continue;
                    }

                switch (opcao){
                    case 0:
                        break;
                    case 1:
                        LogicaBatalhaNaval.Jogar(jogadores);
                        break;
                    case 2:
                        Jogador.RegistrarJogador(jogadores, jogadores.Count());
                        break;
                    case 3:
                        Interface.IVerRanking(jogadores);
                        break;
                    default:
                        Interface.ICores("Opção inválida. Aperte enter para tentar novamente.", ConsoleColor.Red);
                        Console.ReadKey();
                        break;
                }
                    

            } while (opcao != 0);

        }
}