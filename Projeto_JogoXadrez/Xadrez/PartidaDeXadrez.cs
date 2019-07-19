using Estrutura;
using Excessoes;
using System;

namespace Xadrez
{
    public class PartidaDeXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; }
        public bool Terminada { get; private set; }
        public int Turno { get; private set; } //Quantidade de jogadas da partida
        public Cor JogadorAtual { get; private set; }


        public PartidaDeXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Terminada = false;
            Turno = 1;
            JogadorAtual = Cor.Azul;
            ColocarPecas();
        }

        private void ColocarPecas()
        {
            Tabuleiro.ColocarPeca(new Rei(Cor.Azul, Tabuleiro), new PosicaoXadrez('c', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Rei(Cor.Azul, Tabuleiro), new PosicaoXadrez('d', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Rei(Cor.Vermelho, Tabuleiro), new PosicaoXadrez('b', 2).ToPosicao());

            Tabuleiro.ColocarPeca(new Torre(Cor.Azul, Tabuleiro), new PosicaoXadrez('g', 5).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.Azul, Tabuleiro), new PosicaoXadrez('f', 5).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.Azul, Tabuleiro), new PosicaoXadrez('h', 5).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.Azul, Tabuleiro), new PosicaoXadrez('g', 4).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.Azul, Tabuleiro), new PosicaoXadrez('g', 6).ToPosicao());
        }

        public void NovaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            IncrementaTurno();
            AlteraJogador();
        }

        private void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = Tabuleiro.RemoverPeca(origem);
            peca.IncrementarQtdMovimentos();
            Peca pecaCapturada = Tabuleiro.RemoverPeca(destino);
            Tabuleiro.ColocarPeca(peca, destino);
        } 

        private void IncrementaTurno()
        {
            Turno++;
        }

        private void AlteraJogador()
        {
            if (JogadorAtual == Cor.Azul)
                JogadorAtual = Cor.Vermelho;
            else
                JogadorAtual = Cor.Azul;
        }

        public void ValidarOrigem(Posicao posicao)
        {
            if(!Tabuleiro.VerificarPosicao(posicao))
                throw new TabuleiroException("A POSIÇÃO INFORMADA É INVÁLIDA!");
            if (Tabuleiro.ExistePeca(posicao))
                throw new TabuleiroException("NÃO EXISTEM PEÇAS NA POSIÇÃO INFORMADA!");
            if(Tabuleiro.ObterPeca(posicao).Cor != JogadorAtual)
                throw new TabuleiroException("A PEÇA ESCOLHIDA É DE OUTRO JOGADOR!");
            if(!Tabuleiro.ObterPeca(posicao).ExisteMovimentoPossivel())
                throw new TabuleiroException("A PEÇA ESCOLHIDA NÃO POSSUI MOVIMENTOS DISPONÍVEIS!");
        }

        public void ValidarDestino(Posicao origem, Posicao destino)
        {
            if (!Tabuleiro.VerificarPosicao(destino))
                throw new TabuleiroException("A POSIÇÃO INFORMADA É INVÁLIDA!");
            if (!Tabuleiro.ObterPeca(origem).PodeMoverPara(destino))
                throw new TabuleiroException("A PEÇA SELECIONADA NÂO PODE MOVER PARA ESSA POSIÇÃO!");
        }
            
    }
}
