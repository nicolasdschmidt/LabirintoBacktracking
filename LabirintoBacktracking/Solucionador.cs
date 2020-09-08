using System;
using System.Drawing;
using System.Windows.Forms;

namespace LabirintoBacktracking
{
    class Solucionador
    {
        private Labirinto lab;
        private DataGridView dgv;
        private Pilha<Movimento> passos;
        private Movimento passoAtual;
        public Lista<Pilha<Movimento>> Solucoes { get; }

        private (int, int)[] direcoes = { (-1, 1), (0, 1), (1, 1), (1, 0), (1, -1), (0, -1), (-1, -1), (-1, 0) };

        private int colunaAtual;
        private int linhaAtual;

        private bool naoMostrarProcesso;

        public Solucionador(Labirinto lab, DataGridView dgv, bool naoMostrarProcesso)
        {
            this.lab = lab;
            this.dgv = dgv;
            this.naoMostrarProcesso = naoMostrarProcesso;
            linhaAtual = colunaAtual = 1;
            Solucoes = new Lista<Pilha<Movimento>>();
        }

        public void Solucionar()
        {
            passos = new Pilha<Movimento>();
            passoAtual = new Movimento(1, 1); // começamos sempre na posição (1,1), desconsiderando a letra I no arquivo
            passos.Adicionar(passoAtual);
            AtualizarDataGridView(false);

            if (lab.Dados[linhaAtual, colunaAtual] == '#')
                throw new Exception("(1,1) não está vazio");

            bool aindaTemCaminhos = true;

            while (aindaTemCaminhos)
            {
                bool andou = Avancar();
                if (!andou)
                    aindaTemCaminhos = Voltar();
            }
        }

        private bool Avancar()
        {
            int inicio = 0;
            char atual = lab.Dados[linhaAtual, colunaAtual];
            if (atual != ' ' && atual != 'I')
                inicio = int.Parse(atual + "") + 1;

            for (int i = inicio; i < direcoes.Length; i++)
            {
                int linha = linhaAtual + direcoes[i].Item1;
                int coluna = colunaAtual + direcoes[i].Item2;

                passoAtual = new Movimento(linha, coluna, i);

                char pos = lab.Dados[linha, coluna];
                if (pos == ' ')
                {
                    lab.Dados[linhaAtual, colunaAtual] = passoAtual.Direcao.ToString()[0];
                    linhaAtual = passoAtual.Linha;
                    colunaAtual = passoAtual.Coluna;
                    passos.Adicionar(passoAtual);
                    AtualizarDataGridView(false);
                    return true;
                }
                else if (pos == 'S')
                {
                    GuardarSolucao();
                    return false;
                }
            }
            return false;
        }

        private bool Voltar()
        {
            passoAtual = passos.Desempilhar();
            lab.Dados[passoAtual.Linha, passoAtual.Coluna] = ' ';
            AtualizarDataGridView(true);

            if (passos.Vazia())
                return false;

            Movimento anterior = passos.Espiar();
            linhaAtual = anterior.Linha;
            colunaAtual = anterior.Coluna;
            return true;
        }

        private void GuardarSolucao()
        {
            passos.Adicionar(passoAtual);
            Solucoes.InserirNoFim((Pilha<Movimento>)passos.Clone());
            passos.Desempilhar();
        }

        private void AtualizarDataGridView(bool backtrack)
        {
            if (naoMostrarProcesso)
                return;

            if (backtrack)
                dgv[passoAtual.Coluna, passoAtual.Linha].Style.BackColor = Color.White;
            else
                dgv[passoAtual.Coluna, passoAtual.Linha].Style.BackColor = Color.LightSkyBlue;

            Application.DoEvents();
        }
    }
}

