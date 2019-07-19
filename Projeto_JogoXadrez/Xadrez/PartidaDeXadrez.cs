using Estrutura;
using Excessoes;
using System;
using System.Collections.Generic;

namespace Xadrez
{
    public class PartidaDeXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; }
        public bool Terminada { get; private set; }
        public int Turno { get; private set; } //Quantidade de jogadas da partida
        public Cor JogadorAtual { get; private set; }
        private HashSet<Peca> _pecasNaPartida;
        private HashSet<Peca> _pecasCapturadas;


        public PartidaDeXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Terminada = false;
            Turno = 1;
            JogadorAtual = Cor.Azul;
            _pecasNaPartida = new HashSet<Peca>();
            _pecasCapturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        private void InserirPecaPosicao(char coluna, int linha, Peca peca)
        {
            Tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            _pecasNaPartida.Add(peca);
        }

        private void ColocarPecas()
        {
            InserirPecaPosicao('c', 2, new Rei(Cor.Azul, Tabuleiro));
            InserirPecaPosicao('a', 8, new Torre(Cor.Vermelho, Tabuleiro));
            InserirPecaPosicao('h', 8, new Torre(Cor.Vermelho, Tabuleiro));
            InserirPecaPosicao('h', 1, new Torre(Cor.Azul, Tabuleiro));
            InserirPecaPosicao('a', 1, new Torre(Cor.Azul, Tabuleiro));

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
            if (pecaCapturada != null)
                _pecasCapturadas.Add(pecaCapturada);
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

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> capturadasCor = new HashSet<Peca>();
            foreach (var item in _pecasCapturadas)
            {
                if (item.Cor == cor)
                    capturadasCor.Add(item);
            }
            return capturadasCor;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> emJogoCor = new HashSet<Peca>();
            foreach (var item in _pecasNaPartida)
            {
                if (item.Cor == cor)
                    emJogoCor.Add(item);
            }
            emJogoCor.ExceptWith(PecasCapturadas(cor));
            return emJogoCor;
        }

    }
}
