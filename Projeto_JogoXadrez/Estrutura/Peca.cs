namespace Estrutura
{
    public abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdMovimentos { get; protected set; }
        public Tabuleiro Tabuleiro { get; protected set; }

        public Peca(Cor cor, Tabuleiro tabuleiro)
        {
            Cor = cor;
            Tabuleiro = tabuleiro;
            Posicao = null;
            QtdMovimentos = 0;
        }

        public void IncrementarQtdMovimentos()
        {
            QtdMovimentos++;
        }

        public abstract bool[,] MovimentosPossiveis();

        public bool ExisteMovimentoPossivel()
        {
            bool[,] movimentos = MovimentosPossiveis();
            for (int i = 0; i < movimentos.GetLength(0); i++)
            {
                for (int j = 0; j < movimentos.GetLength(1); j++)
                {
                    if (movimentos[i, j])
                        return true;
                }
            }
            return false;
        }

        public bool PodeMoverPara(Posicao posicao)
        {
            return this.MovimentosPossiveis()[posicao.Linha, posicao.Coluna];
        }
    }
}
