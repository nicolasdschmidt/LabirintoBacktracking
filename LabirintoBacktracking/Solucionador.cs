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
        private List<Pilha<Movimento>> solucoes;// uma lista com todas as soluções possiveis

        private int colunaAtual;//as coordenadas 
        private int linhaAtual;//atuais

        private bool achouASaida;//

        // TODO: Construtor que aceita Labirinto e guarda
        public Solucionador(Labirinto labirinto)
        {
            this.lab = labirinto;   //recebe o labirinto

            this.passos = new Pilha<Movimento>(); //instancia os movimentos

            colunaAtual = 1;    //define as coordenadas
            linhaAtual = 1;     //iniciais do labirinto

            achouASaida = false;//define que a saida ainda não foi encontrada
        }

       
        public int GetColunaAtual() { return colunaAtual; }

        public int GetLinhaAtual() { return linhaAtual; }

        public bool GetAchouSaida() { return achouASaida; }


        /* TODO: Algoritmo de resolução por passos, um método Passo vai executar apenas 1 passo de tentativa de solução
         * (tem que ser em passos pra conseguirmos mostrar a solução sendo processada no DataGridView)
         */
        public bool DarUmPasso()//tenta dar um passo. se conseguir retorna true e, se não, retorna false
        {

            for (int i = -1; i<=1; i++)
            {
                for (int o = -1; o <= 1; o++)
                {
                    //se a posição que ele achou não for uma parede e 
                    //nem uma posição ja explorada do labirinto
                    
                    if (this.lab.Dados[linhaAtual + i, colunaAtual + o] != '#' && this.lab.Dados[linhaAtual + i, colunaAtual + o] != 'p')
                    {
                        this.linhaAtual += i;   //define as novas
                        this.colunaAtual += o;  //coordenadas

                        if (this.lab.Dados[linhaAtual, colunaAtual] == 'S')
                            this.achouASaida = true;


                        this.lab.Dados[linhaAtual, colunaAtual] = 'p'; //marca que já passou                      

                        this.passos.Adicionar(new Movimento(i, o)); //adiciona o movimento que acabou de ser feito

                        return true; //retorna que achou caminho
                        
                    }                
                }
            }
            return false;
        }

        public void VoltarUmPasso()
        {
            Movimento aux = passos.Desempilhar();
            this.linhaAtual += -aux.AlteradorLinha;
            this.colunaAtual += -aux.AlteradorColuna;
        }

        
    }
}

