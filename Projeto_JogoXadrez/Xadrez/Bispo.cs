using Estrutura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez
{
    public class Bispo : Peca
    {
        public Bispo(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }

        public override string ToString()
        {
            return "B";
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

            aux.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna - 1);
            while (Tabuleiro.VerificarPosicao(aux) && PodeMover(aux))
            {
                movimentos[aux.Linha, aux.Coluna] = true;
                if (Tabuleiro.ObterPeca(aux) != null && Tabuleiro.ObterPeca(aux).Cor != this.Cor)
                    break;
                aux.Linha -= 1;
                aux.Coluna -= 1;
            }

            aux.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna + 1);
            while (Tabuleiro.VerificarPosicao(aux) && PodeMover(aux))
            {
                movimentos[aux.Linha, aux.Coluna] = true;
                if (Tabuleiro.ObterPeca(aux) != null && Tabuleiro.ObterPeca(aux).Cor != this.Cor)
                    break;
                aux.Linha += 1;
                aux.Coluna += 1;
            }

            aux.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna + 1);
            while (Tabuleiro.VerificarPosicao(aux) && PodeMover(aux))
            {
                movimentos[aux.Linha, aux.Coluna] = true;
                if (Tabuleiro.ObterPeca(aux) != null && Tabuleiro.ObterPeca(aux).Cor != this.Cor)
                    break;
                aux.Coluna += 1;
                aux.Linha -= 1;
            }

            aux.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna - 1);
            while (Tabuleiro.VerificarPosicao(aux) && PodeMover(aux))
            {
                movimentos[aux.Linha, aux.Coluna] = true;
                if (Tabuleiro.ObterPeca(aux) != null && Tabuleiro.ObterPeca(aux).Cor != this.Cor)
                    break;
                aux.Coluna -= 1;
                aux.Linha += 1;
            }

            return movimentos;
        }
    }
}
