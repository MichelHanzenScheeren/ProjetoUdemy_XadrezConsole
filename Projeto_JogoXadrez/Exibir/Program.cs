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
                        Console.Clear();
                        Tela.ImprimirTabuleiro(partidaDeXadrez.Tabuleiro);

                        //ORIGEM
                        Console.WriteLine("\n  Turno: " + partidaDeXadrez.Turno);
                        Console.WriteLine("  Aguardando Jogada: " + partidaDeXadrez.JogadorAtual);
                        Console.Write("  Origem: ");
                        PosicaoXadrez posicaoXadrez = Tela.LerPosicaoXadrez();
                        Posicao origem = posicaoXadrez.ToPosicao();
                        partidaDeXadrez.ValidarOrigem(origem);
                        bool[,] movimentos = partidaDeXadrez.Tabuleiro.ObterPeca(origem).MovimentosPossiveis();
                        Console.Clear();
                        Tela.ImprimirTabuleiro(partidaDeXadrez.Tabuleiro, movimentos, origem);

                        //DESTINO
                        Console.WriteLine("\n  Turno: " + partidaDeXadrez.Turno);
                        Console.WriteLine("  Aguardando Jogada: " + partidaDeXadrez.JogadorAtual);
                        Console.WriteLine("  Origem: " + posicaoXadrez);
                        Console.Write("  Destino: ");
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
            }
            catch (TabuleiroException erro)
            {
                Console.WriteLine(erro.Message);
            }         
            Console.ReadKey();
        }
    }
}
