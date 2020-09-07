using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirintoBacktracking
{
    class Solucionador
    {
        private Labirinto lab;// o labirinto
        private Pilha<Movimento> passos;// os movimentos de uma solução
        public Lista<Pilha<Movimento>> Solucoes { get; }

        private int colunaAtual;//as coordenadas 
        private int linhaAtual;//atuais

        private bool achouASaida;//

        Pilha<Movimento> solucaoAtual;

        public Solucionador(Labirinto labirinto)
        {
            this.lab = labirinto;   //recebe o labirinto

            this.passos = new Pilha<Movimento>(); //instancia os movimentos
            Solucoes = new Lista<Pilha<Movimento>>();

            colunaAtual = 1;    //define as coordenadas
            linhaAtual = 1;     //iniciais do labirinto

            achouASaida = false;//define que a saida ainda não foi encontrada
        }

       
        public int GetColunaAtual() { return colunaAtual; }

        public int GetLinhaAtual() { return linhaAtual; }

        public bool GetAchouSaida() { return achouASaida; }


        /* Algoritmo de resolução por passos, um método Passo vai executar apenas 1 passo de tentativa de solução
         * (tem que ser em passos pra conseguirmos mostrar a solução sendo processada no DataGridView)
         */
        //public bool DarUmPasso()//tenta dar um passo. se conseguir retorna true e, se não, retorna false
        //{

        //    for (int i = -1; i <= 1; i++)
        //    {
        //        for (int o = -1; o <= 1; o++)
        //        {
        //            //se a posição que ele achou não for uma parede e 
        //            //nem uma posição ja explorada do labirinto
                    
        //            if (this.lab.Dados[linhaAtual + i, colunaAtual + o] != '#' && this.lab.Dados[linhaAtual + i, colunaAtual + o] != 'p')
        //            {
        //                this.linhaAtual += i;   //define as novas
        //                this.colunaAtual += o;  //coordenadas

        //                if (this.lab.Dados[linhaAtual, colunaAtual] == 'S')
        //                    this.achouASaida = true;

        //                this.lab.Dados[linhaAtual, colunaAtual] = 'p'; //marca que já passou                      

        //                this.passos.Adicionar(new Movimento(i, o)); //adiciona o movimento que acabou de ser feito

        //                return true; //retorna que achou caminho
                        
        //            }                
        //        }
        //    }
        //    return false;
        //}

        public void DarUmPasso(out bool achouSaida, out bool fimDaLinha)
        {
            fimDaLinha = false;
            achouSaida = false;

            bool temCaminho = Verificar();
            if (achouASaida)
            {
                achouSaida = true;
            }
            
            if (!temCaminho)
            {
                bool temComoVoltar = VoltarUmPasso();
                if (!temComoVoltar)
                {
                    fimDaLinha = true;
                }
            }
        }

        private bool Verificar()
        {
            achouASaida = false;
            lab.Dados[linhaAtual, colunaAtual] = 'p';
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue;
                    if (lab.Dados[linhaAtual + i, colunaAtual + j] == 'S')
                    {
                        passos.Adicionar(new Movimento(linhaAtual + i, colunaAtual + j));
                        Solucoes.InserirNoFim(passos);
                        achouASaida = true;
                    } else if (lab.Dados[linhaAtual + i, colunaAtual + j] != '#' && lab.Dados[linhaAtual + i, colunaAtual + j] != 'p')
                    {
                        linhaAtual += i;
                        colunaAtual += j;

                        passos.Adicionar(new Movimento(linhaAtual, colunaAtual));
                        
                        lab.Dados[linhaAtual, colunaAtual] = 'p';

                        return true;
                    }
                }
            }
            return false;
        }

        public bool VoltarUmPasso()
        {
            if (passos.Vazia())
                return false;

            Movimento aux = passos.Desempilhar();
            linhaAtual = aux.Linha;
            colunaAtual = aux.Coluna;

            return true;
        }

        public void SelecionarSolucao(int index)
        {
            linhaAtual = colunaAtual = 1;
            solucaoAtual = Solucoes.Get(index);
        }

        public bool PassoSolucao()
        {
            if (solucaoAtual.Vazia())
                return false;

            Movimento atual = solucaoAtual.Desempilhar();
            linhaAtual = atual.Linha;
            colunaAtual = atual.Coluna;

            return true;
        }
    }
}

