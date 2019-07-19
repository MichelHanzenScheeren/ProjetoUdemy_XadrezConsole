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
                PartidaDeXadrez partidaDeXadrez = new PartidaDeXadrez();
                while(!partidaDeXadrez.Terminada)
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partidaDeXadrez.Tabuleiro);
                    Console.WriteLine();

                    Console.Write("  Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                    Console.Write("  Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                    partidaDeXadrez.ExecutaMovimento(origem, destino);

                } 
            }
            catch (TabuleiroException erro)
            {
                Console.WriteLine(erro.Message);
            }
            

            Console.ReadKey();
        }
    }
}
