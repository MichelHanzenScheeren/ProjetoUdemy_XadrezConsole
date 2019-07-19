using System;
using Estrutura;
using Xadrez;

namespace Exibir
{
    class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            Console.WriteLine();
            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                Console.Write("   ");
                for (int j = 0; j < tabuleiro.Colunas; j++)
                {

                    if (tabuleiro.ObterPeca(i, j) == null)
                        Console.Write("- ");
                    else
                        ImprimirPeca(tabuleiro.ObterPeca(i, j));
                }
                Console.Write(tabuleiro.Linhas - i + "  ");
                Console.WriteLine();
            }
            Console.Write("   ");
            char aux = 'a';
            for (int i = 0; i < tabuleiro.Colunas; i++)
            {
                Console.Write(aux + " ");
                aux = Convert.ToChar(aux + 1);
            }
            Console.WriteLine();
        }

        public static void ImprimirPeca(Peca peca)
        {
            ConsoleColor consoleColor = Console.ForegroundColor;

            if(peca.Cor == Cor.Azul)
                Console.ForegroundColor = ConsoleColor.Blue;
            else
                Console.ForegroundColor = ConsoleColor.Red;

            Console.Write(peca + " ");
            Console.ForegroundColor = consoleColor;

        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string posicao = Console.ReadLine();
            char coluna = posicao[0];
            int linha = Convert.ToInt32(posicao[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }
    }
}
