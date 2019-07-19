using Estrutura;
using System;

namespace Xadrez
{
    public class Rei : Peca
    {
        public Rei(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }

        public override string ToString()
        {
            return "R";
        }

        private bool PodeMover(Posicao posicao)
        {
            Peca peca = Tabuleiro.ObterPeca(posicao);
            return peca == null || peca.Cor != this.Cor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] movimentos = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao aux = new Posicao(0, 0);

            aux.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna);
            if (Tabuleiro.VerificarPosicao(aux) && PodeMover(aux))
                movimentos[aux.Linha, aux.Coluna] = true;

            aux.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tabuleiro.VerificarPosicao(aux) && PodeMover(aux))
                movimentos[aux.Linha, aux.Coluna] = true;

            aux.DefinirPosicao(Posicao.Linha, Posicao.Coluna + 1);
            if (Tabuleiro.VerificarPosicao(aux) && PodeMover(aux))
                movimentos[aux.Linha, aux.Coluna] = true;

            aux.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tabuleiro.VerificarPosicao(aux) && PodeMover(aux))
                movimentos[aux.Linha, aux.Coluna] = true;

            aux.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna);
            if (Tabuleiro.VerificarPosicao(aux) && PodeMover(aux))
                movimentos[aux.Linha, aux.Coluna] = true;

            aux.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tabuleiro.VerificarPosicao(aux) && PodeMover(aux))
                movimentos[aux.Linha, aux.Coluna] = true;

            aux.DefinirPosicao(Posicao.Linha, Posicao.Coluna - 1);
            if (Tabuleiro.VerificarPosicao(aux) && PodeMover(aux))
                movimentos[aux.Linha, aux.Coluna] = true;

            aux.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tabuleiro.VerificarPosicao(aux) && PodeMover(aux))
                movimentos[aux.Linha, aux.Coluna] = true;

            return movimentos;
        }
    }
}
