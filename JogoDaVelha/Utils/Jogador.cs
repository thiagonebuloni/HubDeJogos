namespace HubDeJogos.JogoDaVelha.Utils
{

    public class Jogador
    {
        public string NomeJogador { get; set; } = null!;
        public int Vitorias { get; private set; }
        public int Derrotas { get; private set; }
        public int Empates { get; private set; }

        public Jogador(string nomeJogador, int vitorias, int derrotas, int empates)
        {
            NomeJogador = nomeJogador;
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


        public static void RegistrarJogador(List<Jogador> jogadores, int numeroJogador)
        {
            Console.Clear();
            
            Console.Write($"Digite o nome do(a) jogador(a) {numeroJogador + 1}: ");
            string nomeJogador = Console.ReadLine()!;

            if (string.IsNullOrEmpty(nomeJogador))
            {
                Jogador novoJogador = new Jogador($"Jogador(a) {jogadores.Count() + 1}", 0, 0, 0);
                jogadores.Add(novoJogador);
            }
            else
            {
                Jogador novoJogador = new Jogador(nomeJogador, 0, 0, 0);
                jogadores.Add(novoJogador);
            }
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
    }
}