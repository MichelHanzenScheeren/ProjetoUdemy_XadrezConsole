using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabuleiro;

namespace Projeto_JogoXadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            Posicao posicao = new Posicao(2, 4);
            Console.WriteLine(posicao);

            Console.ReadKey();
        }
    }
}
