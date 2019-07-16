namespace Tabuleiro
{
    public class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }

        private Peca[,] _pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            Colunas = colunas;
            Linhas = linhas;
        }


    }
}
