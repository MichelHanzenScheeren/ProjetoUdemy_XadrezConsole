using Excessoes;

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

        public Peca ObterPeca(Posicao posicao)
        {
            return _pecas[posicao.Linha, posicao.Coluna];
        }

        public void ColocarPeca(Peca peca, Posicao posicao)
        {
            Validar(posicao);

            _pecas[posicao.Linha, posicao.Coluna] = peca;
            peca.Posicao = posicao;
        }

        public bool VerificarPosicao(Posicao posicao)
        {
            if (posicao.Linha < 0 || posicao.Coluna < 0 || posicao.Linha >= Linhas || posicao.Coluna >= Colunas)
                return false;
           return true;
        }

        public bool ExistePeca(Posicao posicao)
        {
            if (_pecas[posicao.Linha, posicao.Coluna] != null)
                return false;
            return true;
        }

        public void Validar(Posicao posicao)
        {
            if(!VerificarPosicao(posicao))
                throw new TabuleiroException("POSIÇÃO INVÁLIDA!");
            if (!ExistePeca(posicao))
                throw new TabuleiroException("JÁ EXISTE UMA PEÇA NESSA POSIÇÃO!");
        }


    }
}
