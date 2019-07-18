using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estrutura;
using Excessoes;
using Exibir;
using Xadrez;

namespace Projeto_JogoXadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Tabuleiro tabuleiro = new Tabuleiro(8, 8);
                tabuleiro.ColocarPeca(new Rei(Cor.Azul, tabuleiro), new Posicao(2, 2));
                tabuleiro.ColocarPeca(new Rei(Cor.Vermelho, tabuleiro), new Posicao(3, 6));
                Tela.ImprimirTabuleiro(tabuleiro);
            }
            catch (TabuleiroException erro)
            {
                Console.WriteLine(erro.Message);
            }
            

            Console.ReadKey();
        }
    }
}
