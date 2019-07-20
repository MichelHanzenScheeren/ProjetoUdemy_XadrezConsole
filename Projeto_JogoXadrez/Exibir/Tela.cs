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
                    ImprimirPeca(tabuleiro.ObterPeca(i, j));
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
                throw new TabuleiroException("A POSIÇÃO INFORMADA NÃO É VÁLIDA!");

            char coluna = char.ToLower(posicao[0]);
            
            int linha = Convert.ToInt32(posicao[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        public static void JogadaEspecialPromocao(Posicao posicao)
        {
            Console.WriteLine("\n  JOGADA ESPECIAL 'PROMOÇÃO' DETECTADA! O PEÃO " + posicao + " SERÁ SUBSTITUÍDO!");
            Console.Write("  PELAS REGRAS: QUANDO UM PEÃO ALCANÇA O FIM DO TABULEIRO ADVERSÁRIO, É SUBSTITUÍDO POR UMA DAMA!");
            Console.ReadKey();
        }
    }
}
