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
                    try
                    {
                        Tela.ImprimirTabuleiro(partidaDeXadrez.Tabuleiro);

                        //ORIGEM
                        Tela.ImprimirJogadaParte1(partidaDeXadrez);
                        PosicaoXadrez posicaoXadrez = Tela.LerPosicaoXadrez();
                        Posicao origem = posicaoXadrez.ToPosicao();
                        partidaDeXadrez.ValidarOrigem(origem);
                        bool[,] movimentos = partidaDeXadrez.Tabuleiro.ObterPeca(origem).MovimentosPossiveis();
                        Tela.ImprimirTabuleiro(partidaDeXadrez.Tabuleiro, movimentos, origem);

                        //DESTINO
                        Tela.ImprimirJogadaParte1(partidaDeXadrez);
                        Tela.ImprimirJogadaParte2(posicaoXadrez);
                        Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                        partidaDeXadrez.ValidarDestino(origem, destino);
                        partidaDeXadrez.NovaJogada(origem, destino);
                    }
                    catch (TabuleiroException erro)
                    {
                        Console.Write("\n  " + erro.Message);
                        Console.ReadKey();
                    }
                }
                Tela.ImprimirTabuleiro(partidaDeXadrez.Tabuleiro);
                Tela.ImprimirJogadaParte1(partidaDeXadrez);
            }
            catch (TabuleiroException erro)
            {
                Console.WriteLine(erro.Message);
            }         
            Console.ReadKey();
        }
    }
}
