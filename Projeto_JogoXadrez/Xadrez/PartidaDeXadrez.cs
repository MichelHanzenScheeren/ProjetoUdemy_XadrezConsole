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
            InserirPecaPosicao('a', 1, new Rei(Cor.Vermelho, Tabuleiro));
            InserirPecaPosicao('d', 8, new Rei(Cor.Azul, Tabuleiro));


            InserirPecaPosicao('a', 2, new Torre(Cor.Azul, Tabuleiro));
            InserirPecaPosicao('b', 2, new Torre(Cor.Azul, Tabuleiro));
            InserirPecaPosicao('h', 1, new Torre(Cor.Azul, Tabuleiro));
            //InserirPecaPosicao('a', 1, new Torre(Cor.Azul, Tabuleiro));

        }

        public void NovaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = ExecutaMovimento(origem, destino);
            if (EstaEmXeque())
            {
                DesfazerMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("UM JOGADOR NÃO PODE SE COLOCAR EM XEQUE!");
            }
            AlteraJogador();

            if (EstaXequeMate())
                Terminada = true;
            else
                IncrementaTurno();
        }

        private void DesfazerMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca peca = Tabuleiro.RemoverPeca(destino);
            peca.DecrementarQtdMovimentos();
            if(pecaCapturada != null)
            {
                Tabuleiro.ColocarPeca(pecaCapturada, destino);
                _pecasCapturadas.Remove(pecaCapturada);
            }
            Tabuleiro.ColocarPeca(peca, origem);
        }

        private Peca ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = Tabuleiro.RemoverPeca(origem);
            peca.IncrementarQtdMovimentos();
            Peca pecaCapturada = Tabuleiro.RemoverPeca(destino);
            Tabuleiro.ColocarPeca(peca, destino);
            if (pecaCapturada != null)
                _pecasCapturadas.Add(pecaCapturada);

            return pecaCapturada;
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

        public bool EstaEmXeque() //Cor do jogador que será verificado se está em xeque
        {
            Peca rei = BuscarRei();
            if (rei == null)
                throw new TabuleiroException("O JOGADOR ATUAL NÃO POSSUI REI!");
            foreach (var item in PecasEmJogo(JogadorAdversario()))
            {
                bool[,] movimentos = item.MovimentosPossiveis();
                if (movimentos[rei.Posicao.Linha, rei.Posicao.Coluna] == true)
                    return true;
            }
            return false;
        }

        private Peca BuscarRei()
        {
            foreach (var item in PecasEmJogo(JogadorAtual))
            {
                if (item is Rei)
                    return item;
            }
            return null;
        }

        public Cor JogadorAdversario()
        {
            if (JogadorAtual == Cor.Azul)
                return Cor.Vermelho;
            return Cor.Azul;   
        }

        private bool EstaXequeMate()
        {
            if (!EstaEmXeque())
                return false;

            foreach (var item in PecasEmJogo(JogadorAtual))
            {
                bool[,] movimentos = item.MovimentosPossiveis();
                for (int i = 0; i < Tabuleiro.Linhas; i++)
                {
                    for (int j = 0; j < Tabuleiro.Colunas; j++)
                    {
                        if (movimentos[i, j])
                        {
                            Posicao origem = item.Posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = ExecutaMovimento(origem, destino);
                            bool testeXeque = EstaEmXeque();
                            DesfazerMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque)
                                return false;
                        }
                    }
                }
            }
            return true;
        }


    }
}
