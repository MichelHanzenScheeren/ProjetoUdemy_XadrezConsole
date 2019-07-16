namespace Estrutura
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
            _pecas = new Peca[linhas, colunas];
        }

        public Peca ObterPeca(int linha, int coluna)
        {
            return _pecas[linha, coluna];
        }

        public void ColocarPeca(Peca peca, Posicao posicao)
        {
            _pecas[posicao.Linha, posicao.Coluna] = peca;
            peca.Posicao = posicao;

        }


    }
}
