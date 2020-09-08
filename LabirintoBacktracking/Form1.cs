using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LabirintoBacktracking
{
    public partial class FormPrincipal : Form
    {
        Labirinto lab, copia;
        Solucionador solucionador;

        int solucoes = 0;

        int solucaoSelecionada = -1;
        bool selecionarSolucoes = false;

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            dlgAbrirArquivo.ShowDialog();
            Text = "Caminhos em Labirinto - " + dlgAbrirArquivo.FileName;

            ArquivoParaLabirinto(dlgAbrirArquivo.FileName);
            LimparDataGridViewCaminhos();
            LabirintoParaDataGridView(lab);
            ColorirDataGridView();
            btnEncontrar.Enabled = true;
            solucaoSelecionada = -1;
        }

        private void btnEncontrar_Click(object sender, EventArgs e)
        {
            btnAbrir.Enabled = false;
            btnEncontrar.Enabled = false;
            solucionador = new Solucionador(lab, dgvLabirinto, false);
            selecionarSolucoes = false;
            solucionador.Solucionar();

            solucoes = solucionador.Solucoes.GetQtd();

            ExibirSolucoes();

            if (solucoes > 0)
                MessageBox.Show(solucoes + " caminho(s) encontrado(s)", "Solucionado", MessageBoxButtons.OK);
            else
                MessageBox.Show("Nenhum caminho encontrado", "Sem saída", MessageBoxButtons.OK);

            selecionarSolucoes = true;
            btnAbrir.Enabled = true;
        }

        private void ColorirDataGridView()
        {
            for (int i = 0; i < dgvLabirinto.RowCount; i++)
            {
                for (int j = 0; j < dgvLabirinto.ColumnCount; j++)
                {
                    DataGridViewCell celula = dgvLabirinto.Rows[i].Cells[j];
                    char valor = lab.Dados[i, j];

                    switch (valor)
                    {
                        case '#':
                            celula.Style.BackColor = Color.Black;
                            celula.Style.ForeColor = Color.Black;
                            break;

                        case ' ':
                            celula.Style.BackColor = Color.White;
                            celula.Style.ForeColor = Color.White;
                            break;

                        default:
                            celula.Style.BackColor = Color.White;
                            celula.Style.ForeColor = Color.Black;
                            break;
                    }
                }
            }
        }

        private void ArquivoParaLabirinto(string arquivo)
        {
            StreamReader reader = new StreamReader(arquivo);

            int colunas = int.Parse(reader.ReadLine().Trim());
            int linhas = int.Parse(reader.ReadLine().Trim());
            char[,] dados = new char[linhas, colunas];
            char[,] copiaArray = new char[linhas, colunas];

            for (int i = 0; i < linhas; i++)
            {
                string linhaLida = reader.ReadLine();

                for (int j = 0; j < colunas; j++)
                {
                    dados[i, j] = linhaLida[j];
                    copiaArray[i, j] = linhaLida[j];
                }
            }

            lab = new Labirinto(dados);
            copia = new Labirinto(copiaArray);
        }

        private void LabirintoParaDataGridView(Labirinto l)
        {
            int linhas = l.Linhas;
            int colunas = l.Colunas;

            dgvLabirinto.Rows.Clear();
            dgvLabirinto.Refresh();

            dgvLabirinto.ColumnCount = colunas;

            for (int i = 0; i < colunas; i++)
            {
                dgvLabirinto.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            for (int i = 0; i < linhas; i++)
            {
                string[] linhaAtual = new string[colunas];

                for (int j = 0; j < colunas; j++)
                {
                    string atual = l.Dados[i, j] + "";
                    if (atual != "#")
                        linhaAtual[j] = atual;
                    else linhaAtual[j] = " ";
                }

                dgvLabirinto.Rows.Add(linhaAtual);
            }

            dgvLabirinto.Refresh();
            ColorirDataGridView();
        }

        private void LimparDataGridViewCaminhos()
        {
            dgvCaminhos.ColumnCount = 1;
            dgvCaminhos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvCaminhos.Rows.Clear();
            dgvCaminhos.Rows.Add("...");
            dgvCaminhos.Refresh();
        }

        private void ExibirSolucoes()
        {
            for (int i = 0; i < solucoes; i++)
            {
                Lista<Movimento> s = solucionador.Solucoes.Get(i).ParaLista();
                dgvCaminhos.Rows.Add(s.GetQtd() + " passo(s): " + s.ToString());
            }
        }

        private void ExibirSolucao()
        {
            Lista<Movimento> solucao = solucionador.Solucoes.Get(solucaoSelecionada).ParaLista();
            LabirintoParaDataGridView(copia);

            int t = solucao.GetQtd();
            for (int i = 0; i < t; i++)
            {
                Movimento m = solucao.Get(i);
                dgvLabirinto[m.Coluna, m.Linha].Style.BackColor = Color.LightSkyBlue;
            }
        }

        private void dgvLabirinto_SelectionChanged(object sender, EventArgs e)
        {
            dgvLabirinto.ClearSelection();
        }

        private void dgvCaminhos_SelectionChanged(object sender, EventArgs e)
        {
            if (!selecionarSolucoes)
                dgvCaminhos.ClearSelection();

            int row = dgvCaminhos.CurrentRow.Index - 1;

            if (row >= 0 && row != solucaoSelecionada)
            {
                solucaoSelecionada = row;
                ExibirSolucao();
            }
        }
    }
}
