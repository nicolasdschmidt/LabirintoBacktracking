using System;
using System.Drawing;
using System.Windows.Forms;

namespace LabirintoBacktracking
{
    /// <summary>
    /// Representa uma classe capaz de procurar por soluções para um determinado Labirinto.
    /// </summary>
    class Solucionador
    {
        private Labirinto lab;              // Labirinto a ser resolvido
        private DataGridView dgv;           // DataGridView onde devemos exibir o processo, caso naoMostrarProcesso == false
        private Pilha<Movimento> passos;    // passos que compoem a tentativa atual
        private Movimento passoAtual;       // último passo dado
        public Lista<Pilha<Movimento>> Solucoes { get; }    // lista de soluções encontradas

        // array de tuplas (ValueTuple) representando as 8 direções possíveis para um Movimento
        private (int, int)[] direcoes = { (-1, 1), (0, 1), (1, 1), (1, 0), (1, -1), (0, -1), (-1, -1), (-1, 0) };

        // posição atual do Solucionador no Labirinto
        private int colunaAtual;
        private int linhaAtual;

        // caso true, resolve sem mostrar o processo de procura (muito mais rápido)
        private bool naoMostrarProcesso;

        /// <summary>
        /// Instancia um novo objeto da classe Solucionador.
        /// </summary>
        /// <param name="lab">labirinto</param>
        /// <param name="dgv">dataGridView</param>
        /// <param name="naoMostrarProcesso">naoMostrarProcesso</param>
        public Solucionador(Labirinto lab, DataGridView dgv, bool naoMostrarProcesso)
        {
            this.lab = lab;
            this.dgv = dgv;
            this.naoMostrarProcesso = naoMostrarProcesso;
            linhaAtual = colunaAtual = 1;
            Solucoes = new Lista<Pilha<Movimento>>();
        }

        /// <summary>
        /// Tenta resolver o labirinto.
        /// </summary>
        public void Solucionar()
        {
            passos = new Pilha<Movimento>();
            passoAtual = new Movimento(1, 1);   // começamos sempre na posição (1,1), desconsiderando a letra I no arquivo
            passos.Adicionar(passoAtual);       // sempre adicionamos o passoAtual à lista de passos, depois de fazer as operações necessárias
            AtualizarDataGridView(false);

            // como devemos começar em (1,1), devemos garantir que essa posição está livre
            if (lab.Dados[linhaAtual, colunaAtual] == '#')
                throw new Exception("(1,1) não está livre");

            bool aindaTemCaminhos = true;

            // enquanto o backtracking não chegou de volta ao início, continue procurando caminhos
            while (aindaTemCaminhos)
            {
                bool andou = Avancar();
                if (!andou)
                    aindaTemCaminhos = Voltar();
            }
        }

        /// <summary>
        /// Tenta "ir para frente" na tentativa atual.
        /// </summary>
        /// <returns>Se conseguiu avançar</returns>
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

        /// <summary>
        /// Efetua um "backtrack", assim desfazendo o último passo.
        /// </summary>
        /// <returns>Se conseguiu voltar</returns>
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

        /// <summary>
        /// Armazena a lista de passos atual como uma das soluções.
        /// </summary>
        private void GuardarSolucao()
        {
            passos.Adicionar(passoAtual);
            Solucoes.InserirNoFim((Pilha<Movimento>)passos.Clone());
            passos.Desempilhar();
        }

        /// <summary>
        /// Atualiza a visualização do DataGridView.
        /// </summary>
        /// <param name="backtrack"></param>
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

