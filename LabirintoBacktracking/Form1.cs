using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LabirintoBacktracking
{
    public partial class FormPrincipal : Form
    {
        Labirinto lab;
        Solucionador solucionador;

        int solucoes = 0;

        int solucaoAtual = -1;
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
            LabirintoParaDataGridView();
            ColorirDataGridView();
            btnEncontrar.Enabled = true;
        }

        private void btnEncontrar_Click(object sender, EventArgs e)
        {
            btnAbrir.Enabled = false;
            btnEncontrar.Enabled = false;
            solucionador = new Solucionador(lab);
            tmrSleep.Enabled = true;
            selecionarSolucoes = false;
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

        private void ArquivoParaLabirinto (string arquivo)
        {
            StreamReader reader = new StreamReader(arquivo);

            int colunas = int.Parse(reader.ReadLine().Trim());
            int linhas = int.Parse(reader.ReadLine().Trim());
            char[,] dados = new char[linhas, colunas];

            for (int i = 0; i < linhas; i++)
            {
                string linhaLida = reader.ReadLine();

                for (int j = 0; j < colunas; j++)
                    dados[i,j] = linhaLida[j];
            }

            lab = new Labirinto(dados);
        }

        private void LabirintoParaDataGridView()
        {
            int linhas = lab.Linhas;
            int colunas = lab.Colunas;

            dgvLabirinto.Rows.Clear();
            dgvLabirinto.Refresh();

            dgvLabirinto.ColumnCount = colunas;

            dgvCaminhos.Rows.Clear();
            dgvCaminhos.ColumnCount = 1;
            dgvCaminhos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvCaminhos.Rows.Add("...");
            dgvCaminhos.Refresh();

            for (int i = 0; i < colunas; i++)
            {
                dgvLabirinto.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            for (int i = 0; i < linhas; i++)
            {
                string[] linhaAtual = new string[colunas];

                for (int j = 0; j < colunas; j++)
                {
                    string atual = lab.Dados[i, j] + "";
                    if (atual != "#")
                        linhaAtual[j] = atual;
                    else linhaAtual[j] = " ";
                }

                dgvLabirinto.Rows.Add(linhaAtual);
            }

            dgvLabirinto.Refresh();
        }

        private void tmrSleep_Tick(object sender, EventArgs e)
        {
            dgvLabirinto[solucionador.GetColunaAtual(), solucionador.GetLinhaAtual()].Style.BackColor = Color.LightSkyBlue;

            bool achouSaida, fimDaLinha;
            solucionador.DarUmPasso(out achouSaida, out fimDaLinha);

            dgvLabirinto[solucionador.GetColunaAtual(), solucionador.GetLinhaAtual()].Style.BackColor = Color.DeepSkyBlue;

            if (achouSaida)
            {
                Pilha<Movimento> solucao = solucionador.Solucoes.GetFim();

                dgvCaminhos.Rows.Add(solucao.ToString());
                solucoes++;
            }

            if (fimDaLinha)
            {
                tmrSleep.Enabled = false;
                if (solucoes == 0)
                {
                    MessageBox.Show("Este labirinto não têm nenhuma saída!", "Sem saída", MessageBoxButtons.OK);
                }
                else {
                    dgvCaminhos.Rows[0].Cells[0].Value = "Selecione uma solução para visualizar";
                    selecionarSolucoes = true;
                }

                btnAbrir.Enabled = true;
            }
        }

        private void dgvLabirinto_SelectionChanged(object sender, EventArgs e)
        {
            dgvLabirinto.ClearSelection();
        }

        private void dgvCaminhos_SelectionChanged(object sender, EventArgs e)
        {
            int row = dgvCaminhos.CurrentRow.Index;

            if (selecionarSolucoes && row > 0 && row != solucaoAtual)
            {
                solucionador.SelecionarSolucao(row - 1);

                while (solucionador.PassoSolucao()) { }
            }
        }
    }
}
