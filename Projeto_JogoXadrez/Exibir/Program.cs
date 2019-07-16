using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estrutura;
using Exibir;

namespace Projeto_JogoXadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tabuleiro = new Tabuleiro(8,8);
            Tela.ImprimirTabuleiro(tabuleiro);


            Console.ReadKey();
        }
    }
}
