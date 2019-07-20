using Estrutura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez
{
    public class Cavalo : Peca
    {
        public Cavalo(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }

        public override string ToString()
        {
            return "C";
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

            aux.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna - 2);
            if (Tabuleiro.VerificarPosicao(aux) && PodeMover(aux))
                movimentos[aux.Linha, aux.Coluna] = true;

            aux.DefinirPosicao(Posicao.Linha - 2, Posicao.Coluna - 1);
            if (Tabuleiro.VerificarPosicao(aux) && PodeMover(aux))
                movimentos[aux.Linha, aux.Coluna] = true;

            aux.DefinirPosicao(Posicao.Linha - 2, Posicao.Coluna + 1);
            if (Tabuleiro.VerificarPosicao(aux) && PodeMover(aux))
                movimentos[aux.Linha, aux.Coluna] = true;

            aux.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna + 2);
            if (Tabuleiro.VerificarPosicao(aux) && PodeMover(aux))
                movimentos[aux.Linha, aux.Coluna] = true;

            aux.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna + 2);
            if (Tabuleiro.VerificarPosicao(aux) && PodeMover(aux))
                movimentos[aux.Linha, aux.Coluna] = true;

            aux.DefinirPosicao(Posicao.Linha + 2, Posicao.Coluna + 1);
            if (Tabuleiro.VerificarPosicao(aux) && PodeMover(aux))
                movimentos[aux.Linha, aux.Coluna] = true;

            aux.DefinirPosicao(Posicao.Linha + 2, Posicao.Coluna - 1);
            if (Tabuleiro.VerificarPosicao(aux) && PodeMover(aux))
                movimentos[aux.Linha, aux.Coluna] = true;

            aux.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna - 2);
            if (Tabuleiro.VerificarPosicao(aux) && PodeMover(aux))
                movimentos[aux.Linha, aux.Coluna] = true;

            return movimentos;
        }
    }
}
