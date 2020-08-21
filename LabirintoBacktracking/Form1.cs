using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        private void btnEncontrar_Click(object sender, EventArgs e)
        {

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

            dgvLabirinto.ColumnCount = colunas;

            for (int i = 0; i < colunas; i++)
            {
                dgvLabirinto.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            for (int i = 0; i < linhas; i++)
            {
                string[] linhaAtual = new string[colunas];

                for (int j = 0; j < colunas; j++)
                    linhaAtual[j] = lab.Dados[i, j] + "";
                
                dgvLabirinto.Rows.Add(linhaAtual);
            }
        }
    }
}
