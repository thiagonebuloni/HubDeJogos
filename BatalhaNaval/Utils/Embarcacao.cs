namespace HubDeJogos.BatalhaNaval.Utils;

public class Embarcacao
{

    public int Id { get; private set; }
    public string[,] TabuleiroPosicoes { get; set; }
    public int[] Posicao { get; set; } = null!;
    public bool IsAlive { get; set; } = true;

    public Embarcacao(int id, string[,] tabuleiroPosicoes, int posicaoX, int posicaoY)
    {
        Id = id;
        Posicao = new int[2] {posicaoX, posicaoY};
        tabuleiroPosicoes[posicaoX, posicaoY] = "\u25A7";
        IsAlive = true;
    }

    

    public enum Embarcacoes
    {
        PORTAAVIOES,
        NAVIOTANQUE,
        CONTRATORPEDEIRO,
        SUBMARINO,
        NULL
    }   

}