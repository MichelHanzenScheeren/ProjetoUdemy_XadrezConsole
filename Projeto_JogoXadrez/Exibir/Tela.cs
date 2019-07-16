using System;
using Estrutura;

namespace Exibir
{
    class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            Console.WriteLine();
            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                Console.Write("\t");
                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    if(tabuleiro.ObterPeca(i,j) == null)
                        Console.Write("- ");
                    else
                        Console.Write(tabuleiro.ObterPeca(i, j) + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
