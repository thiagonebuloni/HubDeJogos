using HubDeJogos.Views;

namespace HubDeJogos;

public class Jogador
{

    public string NomeJogador { get; private set; } = null!;
    public string Senha { get; private set; } = null!;
    public int Vitorias { get; set; }
    public int Derrotas { get; set; }
    public int Empates { get; set; }

    
    public Jogador(string nomeJogador, string senha, int vitorias, int derrotas, int empates)
    {
        NomeJogador = nomeJogador;
        Senha = senha;
        Vitorias = vitorias;
        Derrotas = derrotas;
        Empates = empates;
    }

    public void IncrementaVitorias()
    {
        Vitorias++;
    }

    public void IncrementaDerrotas()
    {
        Derrotas++;
    }

    public void IncrementaEmpates()
    {
        Empates++;
    }

    private static string GetPass()
    {
        string pass = string.Empty;
        ConsoleKey key;

        do
        {
            var keyInfo = Console.ReadKey(intercept: true);
            key = keyInfo.Key;

            if (key == ConsoleKey.Backspace && pass.Length > 0)
            {
                Console.Write("\b \b");
                pass = pass[0..^1];
            }
            else if (!char.IsControl(keyInfo.KeyChar))
            {
                Console.Write("*");
                pass += keyInfo.KeyChar;
            }
        } while (key != ConsoleKey.Enter);
        
        Console.WriteLine();
        return pass;
    }

    public static void RegistrarJogador(List<Jogador> jogadores, int numeroJogador)
    {
        Console.Clear();
        
        string nomeJogador = "";

        do
        {
            Console.Write($"Digite o nome do(a) jogador(a) {numeroJogador + 1}: ");
            nomeJogador = Console.ReadLine()!;
            
            if (string.IsNullOrEmpty(nomeJogador))
            {
                Interface.ICores("Digite nome válido\n Não pode ser vazio.", ConsoleColor.Red);
                Interface.ICores("Tecle qualquer coisa para continuar", ConsoleColor.Red);
                Console.ReadKey();
            }
        }
        while (string.IsNullOrEmpty(nomeJogador));

        string senha = "";
        bool pass = false;

        do
        {
            Console.Write($"Digite uma senha: ");
            senha = GetPass();

            if (string.IsNullOrEmpty(senha))
            {
                Interface.ICores("Digite uma senha válida\n Mínimo 8 caracteres e não pode ser vazia.", ConsoleColor.Red);
                Interface.ICores("Tecle qualquer coisa para continuar", ConsoleColor.Red);
                Console.ReadKey();
            }
            else pass = true;

            if (senha.Length < 8)
            {
                pass = false;
                Interface.ICores("Digite uma senha válida\n Mínimo 8 caracteres.", ConsoleColor.Red);
                Interface.ICores("Tecle qualquer coisa para continuar", ConsoleColor.Red);
                Console.ReadKey();
            }
            else pass = true;
        }
        while (!pass);


        Jogador novoJogador = new Jogador(nomeJogador, senha, 0, 0, 0);
        jogadores.Add(novoJogador);
        ManipulaArquivo.AtualizaArquivo(jogadores);
        Console.WriteLine($"{senha}");
        Console.ReadKey();
    }

    public static void OrdenarJogadores(List<Jogador> jogadores)
    {
        
        for (int i = 0; i < jogadores.Count() - 1; i++)
        {
            for (int j = i + 1; j < jogadores.Count(); j++)
            {
                if (jogadores[i].Vitorias < jogadores[j].Vitorias)
                {
                    Jogador tmp = jogadores[i];
                    jogadores[i] = jogadores[j];
                    jogadores[j] = tmp;
                }
            }
        }
    }
    
    public static void IVerRankingMain(List<Jogador> jogadores)
    {
            
            string tab = "\t";
            Console.Clear();
            for (int i = 0; i < jogadores.Count(); i++)
            {
                if (jogadores[i].NomeJogador.Length > 7)
                {
                    tab += "\t";
                    break;
                }
            }

            Console.WriteLine("\nJogadores" + tab + "| Vitórias");
            Console.WriteLine("=================================================================");

            for (int i = 0; i < jogadores.Count(); i++) {
                // alterna cores na tabela
                if (i % 2 == 0) Console.ForegroundColor = ConsoleColor.DarkGreen;
                else Console.ForegroundColor = ConsoleColor.Green;

                if (jogadores[i].NomeJogador.Length > 14)
                {
                    Console.WriteLine($"{jogadores[i].NomeJogador}");
                }
                else if (jogadores[i].NomeJogador.Length < 8)
                {
                    Console.WriteLine($"{jogadores[i].NomeJogador}");
                }
                else
                {
                    Console.WriteLine($"{jogadores[i].NomeJogador}");
                }
                
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }


        public static bool IsLogged(List<Jogador> jogadores, List<int> jogadorLogin)
        {

            if (jogadores.Count != 0)
            {
                Interface.ICores("\nJogador já está logado.", ConsoleColor.Green);
                Console.ReadKey();
                return true;
            }
            else if (Login(jogadores, jogadorLogin)) return true;
            else return false;

        }

        public static bool Login(List<Jogador> jogadores, List<int> jogadorLogin)
        {
            
            Console.Write("Digite seu nome de usuário: ");
            string nomeParaApresentar = Console.ReadLine()!;
            int indexParaPesquisar = -1;
            for (int i  = 0; i < jogadores.Count(); i++)
            {
                if (nomeParaApresentar == jogadores[i].NomeJogador)
                {
                    indexParaPesquisar = i;
                    break;
                }
            }
            
            //int indexParaPesquisar = jogadores.FindIndex(nome => jogadores.IndexOf(JogadorMain).Equals(nomeParaApresentar));
            //listaJogadores.ForEach(jogador => jogadores.Add(jogador));

            if (indexParaPesquisar == -1)
            {
                Interface.ICores("Jogador não encontrado.\n" +
                "Volte e registre um jogador\n" +
                "Pressione qualquer tecla para voltar."
                , ConsoleColor.Red);
                Console.ReadKey();
                return false;
            }
            else
            {
                Console.Write("Digite sua senha: ");
                string senhaParaComparar = GetPass();
                if (senhaParaComparar == jogadores[indexParaPesquisar].Senha)
                {
                    // jogadorLogin.Add(1);
                    jogadorLogin.Add(indexParaPesquisar);
                    return true;
                }
                else if (senhaParaComparar != jogadores[indexParaPesquisar].Senha)
                {
                    Interface.ICores("\nSenha incorreta.\nPressione qualquer tecla para voltar.", ConsoleColor.Red);
                    Console.ReadKey();
                    return false;
                }
                return false;
            }
            
        }
        
}

