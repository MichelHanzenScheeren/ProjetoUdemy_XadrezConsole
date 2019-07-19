using Estrutura;
using System;

namespace Xadrez
{
    public class PartidaDeXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; }
        public bool Terminada { get; private set; }
        private int _turno; //Quantidade de jogadas da partida
        private Cor _jogadorAtual;
        

        public PartidaDeXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Terminada = false;
            _turno = 1;
            _jogadorAtual = Cor.Azul;
            ColocarPecas();
        }

        private void ColocarPecas()
        {
            Tabuleiro.ColocarPeca(new Rei(Cor.Azul, Tabuleiro), new PosicaoXadrez('c', 2).ToPosicao());  
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = Tabuleiro.RemoverPeca(origem);
            peca.IncrementarQtdMovimentos();
            Peca pecaCapturada = Tabuleiro.RemoverPeca(destino);
            Tabuleiro.ColocarPeca(peca, destino);
        } 
    }
}
