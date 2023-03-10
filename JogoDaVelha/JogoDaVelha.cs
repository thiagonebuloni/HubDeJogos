using HubDeJogos.JogoDaVelha.Utils;
using HubDeJogos.Views;
using System.Text.Json;

namespace HubDeJogos.JogoDaVelha {

    public class InicioJV
    {

        public static string path = @"data/";
        public static string file = @"ranking.json";
        public string FullPath { get; private set; } = null!;

        public static string Arquivo()
        {
            return System.IO.Path.Combine(path, file);
        }

        string fullPath = Arquivo();
        
        public void JogoDaVelhaInicio()
        {

            // Criando listas de usuários
            List<Jogador> jogadores = new List<Jogador>();            

            
            ManipulaArquivo.LeArquivo(jogadores);


            int opcao = 1;
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
                        LogicaJogoDaVelha.Jogar(jogadores, fullPath);
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
}