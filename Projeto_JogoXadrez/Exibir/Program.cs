using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estrutura;
using Exibir;
using Xadrez;

namespace Projeto_JogoXadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tabuleiro = new Tabuleiro(8,8);
            tabuleiro.ColocarPeca(new Rei(Cor.Azul, tabuleiro), new Posicao(2,2));
            Tela.ImprimirTabuleiro(tabuleiro);

            Console.ReadKey();
        }
    }
}
