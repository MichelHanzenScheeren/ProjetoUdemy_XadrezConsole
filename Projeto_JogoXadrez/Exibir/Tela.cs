using System;
using System.Collections.Generic;
using Estrutura;
using Excessoes;
using Xadrez;

namespace Exibir
{
    class Tela
    {
        public static void ImprimirJogadaParte1(PartidaDeXadrez partidaDeXadrez)
        {
            ConsoleColor padrao = Console.ForegroundColor;
            Console.WriteLine("\n  Peças Capturadas:");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("  Azuis: ");
            ImprimirPecasCapturadas(partidaDeXadrez.PecasCapturadas(Cor.Azul));
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("  Vermelhas: ");
            ImprimirPecasCapturadas(partidaDeXadrez.PecasCapturadas(Cor.Vermelho));
            Console.ForegroundColor = padrao;
            Console.WriteLine("\n  Turno: " + partidaDeXadrez.Turno);
            Console.WriteLine("  Aguardando Jogada: " + partidaDeXadrez.JogadorAtual);
            if(partidaDeXadrez.EstaEmXeque())
                Console.WriteLine("\n  O JOGADOR ATUAL ESTÁ EM XEQUE!");
            Console.Write("\n  Origem: ");
        }

        private static void ImprimirPecasCapturadas(HashSet<Peca> capturadas)
        {
            Console.Write("[ ");
            foreach (var item in capturadas)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("]");
        }

        public static void ImprimirJogadaParte2(PosicaoXadrez posicaoXadrez)
        {
            Console.WriteLine(posicaoXadrez);
            Console.Write("  Destino: ");
        }

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            Console.Clear();
            Console.WriteLine("\n          JOGO DE XADREZ");
            string[] legenda = new string[tabuleiro.Linhas];
            PreencherLegenda(legenda, tabuleiro.Linhas);
            Console.WriteLine();
            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                Console.Write("   ");
                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    ImprimirPeca(tabuleiro.ObterPeca(i, j));
                }
                Console.Write(" " + (tabuleiro.Linhas - i) + "  ");
                Console.WriteLine("\t\t" + legenda[i]);
            }
            Console.Write("   ");
            char aux = 'a';
            for (int i = 0; i < tabuleiro.Colunas; i++)
            {
                Console.Write(" " + aux + " ");
                aux = Convert.ToChar(aux + 1);
            }
            Console.WriteLine();
        }

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro, bool[,] movimentos, Posicao pecaSelecionada)
        {
            Console.Clear();
            string[] legenda = new string[tabuleiro.Linhas];
            PreencherLegenda(legenda, tabuleiro.Linhas);

            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor novoFundo = ConsoleColor.DarkGray;

            Console.WriteLine("\n          JOGO DE XADREZ");
            Console.WriteLine();
            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                Console.Write("   ");
                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    if (movimentos[i, j])
                        Console.BackgroundColor = novoFundo;
                    else
                    {
                        if (pecaSelecionada.Linha == i && pecaSelecionada.Coluna == j)
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                        else
                            Console.BackgroundColor = fundoOriginal;
                    }
                        
                    
                    ImprimirPeca(tabuleiro.ObterPeca(i, j));
                }
                Console.BackgroundColor = fundoOriginal;
                Console.Write(" " + (tabuleiro.Linhas - i));
                Console.WriteLine("\t\t" + legenda[i]);
            }
            Console.Write("   ");
            char aux = 'a';
            for (int i = 0; i < tabuleiro.Colunas; i++)
            { 
                Console.Write(" " + aux + " ");
                aux = Convert.ToChar(aux + 1);
            }
            Console.WriteLine();
        }

        private static void PreencherLegenda(string[] legenda, int tamanho)
        {
            legenda[0] = "'R' = Rei;";
            legenda[1] = "'D' = Dama(Rainha);";
            legenda[2] = "'T' = Torre;";
            legenda[3] = "'B' = Bispo;";
            legenda[4] = "'C' = Cavalo;";
            legenda[5] = "'P' = Peão.";
            legenda[6] = "Amarelo  = Peça Selecionada;";
            legenda[7] = "Cinza  = Movimentos Possíveis.";
            for (int i = 8; i < tamanho; i++)
            {
                legenda[i] = "";
            }
        }

        public static void ImprimirPeca(Peca peca)
        {

            if (peca == null)
                Console.Write(" - ");
            else
            {
                ConsoleColor consoleColor = Console.ForegroundColor;
                if (peca.Cor == Cor.Azul)
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                else
                    Console.ForegroundColor = ConsoleColor.DarkRed;

                Console.Write(" " + peca + " ");
                Console.ForegroundColor = consoleColor;
            }
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string posicao = Console.ReadLine();
            if(!char.IsLetter(posicao[0]) || !char.IsNumber(posicao[1]))
                throw new TabuleiroException("A POSIÇÃO INFORMADA É INVÁLIDA!");

            char coluna = char.ToLower(posicao[0]);
            
            int linha = Convert.ToInt32(posicao[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }
    }
}
