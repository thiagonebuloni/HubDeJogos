using HubDeJogos.BatalhaNaval.Utils;
using HubDeJogos.Views;

namespace HubDeJogos.BatalhaNaval.Utils;


    public class LogicaBatalhaNaval
    {
        public static void Jogar(List<Jogador> jogadores)
        {
            int indexJogadorAtivo1 = -1;
            int indexJogadorAtivo2 = -1;
            int naviosAliveJogador1 = 4;
            int naviosAliveJogador2 = 4;
            // string embarcacao = "\u25A7";
            // string abatido = "\u2612";


            // se não existirem jogadores registrados, cria 2 novos
            if (jogadores.Count() == 0)
            {    
                Jogador.RegistrarJogador(jogadores, jogadores.Count());
                Jogador.RegistrarJogador(jogadores, jogadores.Count());
                indexJogadorAtivo1 = 0;
                indexJogadorAtivo2 = 1;
            }
            else if (jogadores.Count() == 1)
            {   // se existir apenas 1 jogador criado, cria o segundo
                Jogador.RegistrarJogador(jogadores, 1);

            }
            else    // seleciona jogadores já cadastrados
            {
                while (true)
                {
                    // usuário seleciona os jogadores
                    while (indexJogadorAtivo1 < 0 || indexJogadorAtivo1 >= jogadores.Count())    // valida entrada para jogador 1
                    {
                        Console.Clear();
                        for (int i = 0; i < jogadores.Count(); i++)
                        {
                            if (i % 2 == 0) Console.ForegroundColor = ConsoleColor.DarkGreen;
                            else Console.ForegroundColor = ConsoleColor.Green;

                            Console.WriteLine($"{i + 1} - {jogadores[i].NomeJogador}");
                        }
                        Console.ForegroundColor = ConsoleColor.Green;

                        try
                        {
                            Console.Write("Selecione o jogador(a) 1: ");
                            indexJogadorAtivo1 = (int.Parse(Console.ReadLine()!) - 1);
                        }
                        catch (Exception)
                        {
                            Interface.ICores("Número de jogador inválido. Escolha novamente.\n", ConsoleColor.Red);
                            Interface.ICores("Aperte qualquer tecla para continuar...", ConsoleColor.Red);
                            Console.ReadKey();
                        }
                    }

                    while (indexJogadorAtivo2 < 0 || indexJogadorAtivo2 >= jogadores.Count() || indexJogadorAtivo2 == indexJogadorAtivo1)    // valida entrada para jogador 2
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;

                        Console.Clear();
                        for (int i = 0; i < jogadores.Count(); i++)
                        {
                            if (i % 2 == 0) Console.ForegroundColor = ConsoleColor.DarkGreen;
                            else Console.ForegroundColor = ConsoleColor.Green;

                            Console.WriteLine($"{i + 1} - {jogadores[i].NomeJogador}");
                        }
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        
                        try
                        {
                            Console.Write("Selecione o jogador(a) 2: ");
                            indexJogadorAtivo2 = (int.Parse(Console.ReadLine()!) - 1);
                            if (indexJogadorAtivo1 == indexJogadorAtivo2)
                            {
                                Interface.ICores("Jogador(a) 2 deve ser diferente de jogador(a) 1.\nAperte qualquer tecla para continuar. ", ConsoleColor.Red);
                                Console.ReadKey();
                            }

                        }
                        catch (Exception)
                        {
                            Interface.ICores("Número de jogador inválido. Escolha novamente.\n", ConsoleColor.Red);
                            Interface.ICores("Aperte qualquer tecla para continuar...", ConsoleColor.Red);
                            Console.ReadKey();
                        }

                    }
                    Jogador.OrdenarJogadores(jogadores);
                    break;
                }

                // cria e popula posicoes de 1 a 25 nos tabuleiros dos dois jogadores
                string[,] posicoesJogador1 = new string[5,5];
                string[,] posicoesJogador2 = new string[5,5];
                
                // jogador 1
                int contador = 1;
                for (int i = 0; i < 5; i++) {
                    for (int j = 0; j < 5; j++) {
                        if (contador < 10)
                        {
                            posicoesJogador1[i,j] = $" {contador}";
                        }
                        else
                        {
                            posicoesJogador1[i,j] = $"{contador}";
                        }
                        contador++;
                    }
                }

                // jogador 2
                int contador2 = 1;
                for (int i = 0; i < 5; i++) {
                    for (int j = 0; j < 5; j++) {
                        if (contador2 < 10)
                        {
                            posicoesJogador2[i,j] = $" {contador2}";
                        }
                        else
                        {
                            posicoesJogador2[i,j] = $"{contador2}";
                        }
                        contador2++;
                    }
                }

                GeraEmbarcacoes(posicoesJogador1, posicoesJogador2);

                int jogadorTurno = indexJogadorAtivo1;

                // laço do jogo
                while (true)
                {
                    if (jogadorTurno == indexJogadorAtivo1)
                    {
                        Interface.IMostraTabuleiroAtualBN(posicoesJogador1);
                    }
                    else
                    {
                        Interface.IMostraTabuleiroAtualBN(posicoesJogador2);
                    }
                    
                    // bool jogada = false;

                    do
                    {
                        if (jogadorTurno == indexJogadorAtivo1)
                        {
                            if (ValidaJogada(jogadores, posicoesJogador1, jogadorTurno, naviosAliveJogador1))
                            naviosAliveJogador2--;
                            break;
                        }
                        else
                        {
                            if (ValidaJogada(jogadores, posicoesJogador2, jogadorTurno, naviosAliveJogador2))
                            naviosAliveJogador1--;
                            break;
                        }
                    }
                    while (true);

                    // alterna turnos
                    if (naviosAliveJogador1 == 0)
                    {
                        Interface.ICores($"Parabéns {jogadores[indexJogadorAtivo2].NomeJogador}! Você ganhou!", ConsoleColor.Yellow);
                        jogadores[indexJogadorAtivo1].IncrementaVitorias();
                        jogadores[indexJogadorAtivo2].IncrementaDerrotas();
                        Console.ReadKey();
                        break;
                    }
                    else if(naviosAliveJogador2 == 0)
                    {
                        Interface.ICores($"Parabéns {jogadores[indexJogadorAtivo1].NomeJogador}! Você ganhou!", ConsoleColor.Yellow);
                        jogadores[indexJogadorAtivo2].IncrementaVitorias();
                        jogadores[indexJogadorAtivo1].IncrementaDerrotas();
                        Console.ReadKey();
                        break;
                    }

                    if (jogadorTurno == indexJogadorAtivo1) jogadorTurno = indexJogadorAtivo2;
                    else jogadorTurno = indexJogadorAtivo1;

                }

                Jogador.OrdenarJogadores(jogadores);
                ManipulaArquivo.AtualizaArquivo(jogadores);

            }
        }

    private static void GeraEmbarcacoes(string[,] posicoesJogador1, string[,] posicoesJogador2)
    {
        // gera embarcacoes para o jogador 1
        Embarcacao contraTorpedeiro = new Embarcacao(0, posicoesJogador1, 0, 0);
        Embarcacao navioTanque = new Embarcacao(1, posicoesJogador1, 1, 1);
        Embarcacao portaAvioes = new Embarcacao(2, posicoesJogador1, 2, 2);
        Embarcacao Submarino = new Embarcacao(3, posicoesJogador1, 3, 3);

        // gera embarcacoes para o jogador 2
        Embarcacao contraTorpedeiro2 = new Embarcacao(4, posicoesJogador2, 0, 0);
        Embarcacao navioTanque2 = new Embarcacao(5, posicoesJogador2, 4, 4);
        Embarcacao portaAvioes2 = new Embarcacao(6, posicoesJogador2, 3, 3);
        Embarcacao Submarino2 = new Embarcacao(7, posicoesJogador2, 2, 2);
        
    }

    private static bool ValidaJogada(List<Jogador> jogadores, string[,] posicoes, int jogadorTurno, int naviosAlive)
    {
        Console.Write($"\n[{jogadores[jogadorTurno].NomeJogador}] Selecione em qual quadrante jogar a bomba: ");
        int input = int.Parse(Console.ReadLine()!);

        if (input > 25 || input < 1)
        {
            Interface.ICores("Escolha entre 1 e 25 apenas. Aperte Enter para tentar novamente.", ConsoleColor.Red);
            Console.ReadKey();
            return false;
        }
        
        int contador = 1;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (contador == input) {      // valida casa já acertada
                        if (posicoes[i,j] == "\u2612" || posicoes[i,j] == "X") {
                            Interface.ICores("Não é possível escolher esse quadrante, ele já foi acertado. \nAperte Enter para tentar novamente", ConsoleColor.Red);
                            Console.ReadKey();
                            return false;
                        }
                        
                        if (posicoes[i,j] == "\u25A7") {                          // preenche casa escolhida
                            posicoes[i,j] = " \u2612";
                            naviosAlive--;
                            Interface.ICores("Parabéns! Você acertou um navio!\nAperte enter para continuar", ConsoleColor.Green);
                            Console.ReadKey();
                            return true;
                        }

                        Interface.ICores("Você acertou apenas água =(\nAperte enter para continuar", ConsoleColor.DarkGreen);
                        Console.ReadKey();
                    }
                    contador++;
                }
            }
            return false;

    }
}