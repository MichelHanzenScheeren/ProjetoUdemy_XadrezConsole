using System;
using System.Collections.Generic;
using Estrutura;
using Excessoes;
using Xadrez;

namespace Exibir
{
    class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            Console.Clear();
            Console.WriteLine("\n          XADREZ DO MIXÉU");
            string[] legenda = new string[tabuleiro.Linhas];
            PreencherLegenda(legenda, tabuleiro.Linhas);
            Console.WriteLine();
            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                Console.Write("   ");
                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    ImprimirPeca(tabuleiro.ObterPeca(i, j), i, j);
                }
                Console.Write(" " + (tabuleiro.Linhas - i) + "  ");
                Console.WriteLine("\t\t\t" + legenda[i]);
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
            ConsoleColor novoFundo = ConsoleColor.Yellow;

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
                            Console.BackgroundColor = ConsoleColor.Green;
                        else
                            Console.BackgroundColor = fundoOriginal;
                    }

                    ImprimirPeca(tabuleiro.ObterPeca(i, j), i, j);
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
            Console.WriteLine("\n  Turno: " + partidaDeXadrez.Turno + "º");
            if (!partidaDeXadrez.Terminada)
            {
                Console.WriteLine("  Aguardando Jogada: " + partidaDeXadrez.JogadorAtual);
                if (partidaDeXadrez.EstaEmXeque())
                    Console.WriteLine("\n  O JOGADOR ATUAL ESTÁ EM XEQUE!");
                Console.Write("\n  Origem: ");
            }
            else
            {
                Console.WriteLine("\n  XEQUE-MATE!");
                Console.Write("  Vencedor: Jogador " + partidaDeXadrez.JogadorAdversario());
            }
        }

        public static void ImprimirJogadaParte2(PosicaoXadrez posicaoXadrez)
        {
            Console.WriteLine(posicaoXadrez);
            Console.Write("  Destino: ");
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

        private static void PreencherLegenda(string[] legenda, int tamanho)
        {
            legenda[0] = "LEGENDA:";
            legenda[1] = "";
            legenda[2] = "R = Rei            D = Dama";
            legenda[3] = "B = Bispo          T = Torre";
            legenda[4] = "C = Cavalo         P = Peão";
            legenda[5] = "Fundo Amarelo = Peça Selecionada;";
            legenda[6] = "Fundo Cinza = Movimentos Possíveis.";

            for (int i = 7; i < tamanho; i++)
            {
                legenda[i] = "";
            }
        }

        public static void ImprimirPeca(Peca peca, int linha, int coluna)
        {
            if(Console.BackgroundColor == ConsoleColor.Black)
                AlterarFundo(linha, coluna);

            if (peca == null)
                Console.Write("   ");
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
            VoltarFundo();
        }

        private static void AlterarFundo(int linha, int coluna)
        {
            if(linha % 2 == 0)
            {
                if(coluna % 2 == 0)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                }
            }
            else
            {
                if (coluna % 2 == 0)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.White;
                }
            }
        }

        public static void VoltarFundo()
        {
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string posicao = Console.ReadLine();

            if( (char.IsLetter(posicao[0]) && char.IsNumber(posicao[1])) || (char.IsLetter(posicao[1]) && char.IsNumber(posicao[0])) )
            {
                char coluna;
                int linha;
                if (char.IsLetter(posicao[0]))
                {
                    coluna = char.ToLower(posicao[0]);
                    linha = Convert.ToInt32(posicao[1] + "");
                }
                else
                {
                    coluna = char.ToLower(posicao[1]);
                    linha = Convert.ToInt32(posicao[0] + "");
                }
                return new PosicaoXadrez(coluna, linha);
            }
            else
                throw new TabuleiroException("A POSIÇÃO INFORMADA NÃO É VÁLIDA!");
        }

        public static void JogadaEspecialPromocao()
        {
            Console.WriteLine("\n  JOGADA ESPECIAL 'PROMOÇÃO' DETECTADA!");
            Console.Write("  NO XADREZ, QUANDO UM PEÃO ALCANÇA O FIM DO TABULEIRO ADVERSÁRIO É SUBSTITUÍDO POR UMA DAMA!");
            Console.ReadKey();
        }
    }
}
