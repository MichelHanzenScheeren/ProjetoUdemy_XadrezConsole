using Estrutura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez
{
    public class Peao : Peca
    {
        public Peao(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }

        public override string ToString()
        {
            return "P";
        }

        private bool ExisteInimigo(Posicao posicao)
        {
            Peca peca = Tabuleiro.ObterPeca(posicao);
            return peca != null && peca.Cor != Cor;
        }

        private bool Livre(Posicao posicao)
        {
            return Tabuleiro.ObterPeca(posicao) == null;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] movimentos = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao aux = new Posicao(0, 0);
            Posicao aux2 = new Posicao(0, 0);

            if(Cor == Cor.Vermelho)
            {
                aux.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna);
                if (Tabuleiro.VerificarPosicao(aux) && Livre(aux))
                    movimentos[aux.Linha, aux.Coluna] = true;

                aux.DefinirPosicao(Posicao.Linha - 2, Posicao.Coluna);
                aux2.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna);
                if (Tabuleiro.VerificarPosicao(aux) && Livre(aux) && Livre(aux2) && QtdMovimentos == 0)
                    movimentos[aux.Linha, aux.Coluna] = true;

                aux.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tabuleiro.VerificarPosicao(aux) && ExisteInimigo(aux))
                    movimentos[aux.Linha, aux.Coluna] = true;

                aux.DefinirPosicao(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tabuleiro.VerificarPosicao(aux) && ExisteInimigo(aux))
                    movimentos[aux.Linha, aux.Coluna] = true;
            }
            else
            {
                aux.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna);
                if (Tabuleiro.VerificarPosicao(aux) && Livre(aux))
                    movimentos[aux.Linha, aux.Coluna] = true;

                aux.DefinirPosicao(Posicao.Linha + 2, Posicao.Coluna);
                aux2.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna);
                if (Tabuleiro.VerificarPosicao(aux) && Livre(aux) && Livre(aux2) && QtdMovimentos == 0)
                    movimentos[aux.Linha, aux.Coluna] = true;

                aux.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tabuleiro.VerificarPosicao(aux) && ExisteInimigo(aux))
                    movimentos[aux.Linha, aux.Coluna] = true;

                aux.DefinirPosicao(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tabuleiro.VerificarPosicao(aux) && ExisteInimigo(aux))
                    movimentos[aux.Linha, aux.Coluna] = true;
            }
            return movimentos;
        }
    }
}
