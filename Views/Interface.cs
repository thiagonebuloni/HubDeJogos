namespace HubDeJogos.Views {

    public class Interface {

        public static void IShowMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[1] - Jogar");
            Console.WriteLine("[2] - Registrar jogador");
            Console.WriteLine("[3] - Ver ranking");
            Console.WriteLine("[0] - Sair\n");
            
        }


        public static void ICores(string txt, ConsoleColor color) {
            // printa texto na cor selecionada e reseta para cor padrão
            Console.ForegroundColor = color;
            Console.Write(txt);
            Console.ResetColor();
        }


        public static void IVerRanking(List<Jogador> jogadores) {
            
            // ordena jogadores

            // tenta definir a distância entre campos da tabela com base no comprimento dos nomes dos jogadores
            string tab = "\t";
            Console.Clear();
            for (int i = 0; i < jogadores.Count(); i++) {
                if (jogadores[i].NomeJogador.Length > 7) {
                    tab += "\t";
                    break;
                }
            }
            Console.WriteLine("\nJogadores" + tab + "| Vitórias\t| Derrotas\t| Empates");
            Console.WriteLine("=================================================================");

            for (int i = 0; i < jogadores.Count(); i++) {
                // alterna cores na tabela
                if (i % 2 == 0) Console.ForegroundColor = ConsoleColor.DarkGreen;
                else Console.ForegroundColor = ConsoleColor.Green;

                if (jogadores[i].NomeJogador.Length > 14) {
                    Console.WriteLine($"{jogadores[i].NomeJogador}{tab}| {jogadores[i].Vitorias}\t\t| {jogadores[i].Derrotas}\t\t| {jogadores[i].Empates}");
                }
                else if (jogadores[i].NomeJogador.Length < 8){
                    Console.WriteLine($"{jogadores[i].NomeJogador}{tab}\t| {jogadores[i].Vitorias}\t\t| {jogadores[i].Derrotas}\t\t| {jogadores[i].Empates}");
                }
                else {
                    Console.WriteLine($"{jogadores[i].NomeJogador}{tab}| {jogadores[i].Vitorias}{tab}| {jogadores[i].Derrotas}{tab}| {jogadores[i].Empates}");
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }


        public static void IMostraTabuleiroAtualBN(string[,] posicoes)
        {   
            Console.Clear();
            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            
            Console.WriteLine("");

            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 5; j++) {
                    Console.Write("|");
                    Console.Write($"{posicoes[i,j]}");
                }
                Console.WriteLine("|");
            }
            Console.ResetColor();
            Console.Write("");


        }

        public static void IMostraTabuleiroAtualJV(string[,] posicoes)
        {   
            Console.Clear();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < 3; i++) {
                Console.Write(" ");
                for (int j = 0; j < 3; j++) {
                    if (posicoes[i,j] == "_X_") Interface.ICores($"{posicoes[i,j]}", ConsoleColor.DarkBlue);
                    else if (posicoes[i,j] == "_O_") Interface.ICores($"{posicoes[i,j]}", ConsoleColor.DarkRed);
                    else Interface.ICores($"{posicoes[i,j]}", ConsoleColor.DarkGreen);
                    if (j != 2) Interface.ICores("|", ConsoleColor.DarkGreen);
                }
                Console.WriteLine("");
            }

        }


    }
}