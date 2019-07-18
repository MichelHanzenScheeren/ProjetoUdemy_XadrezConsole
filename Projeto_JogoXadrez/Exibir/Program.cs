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
            PosicaoXadrez posicaoXadrez = new PosicaoXadrez('C', 7);

            Console.WriteLine(posicaoXadrez);
            Console.WriteLine(posicaoXadrez.ToPosicao());
            

            Console.ReadKey();
        }
    }
}
