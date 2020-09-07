using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LabirintoBacktracking
{
    public partial class FormPrincipal : Form
    {
        Labirinto lab;

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
            // TODO: Instanciar um Solucionador passando o Labirinto lab, e fazer um loop de resolução
            Solucionador solucionador = new Solucionador(lab);
            
                for(int i = 0; i<45; i++)
                {
                    solucionador.DarUmPasso();
                    dgvLabirinto[solucionador.GetColunaAtual(), solucionador.GetLinhaAtual()].Style.BackColor = Color.Blue;
                }
            
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
    }
}
