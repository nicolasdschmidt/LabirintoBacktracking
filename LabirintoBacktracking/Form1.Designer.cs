namespace LabirintoBacktracking
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEncontrar = new System.Windows.Forms.Button();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.dgvLabirinto = new System.Windows.Forms.DataGridView();
            this.dgvCaminhos = new System.Windows.Forms.DataGridView();
            this.lblLabirinto = new System.Windows.Forms.Label();
            this.lblCaminhos = new System.Windows.Forms.Label();
            this.dlgAbrirArquivo = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabirinto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaminhos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEncontrar
            // 
            this.btnEncontrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEncontrar.Location = new System.Drawing.Point(641, 12);
            this.btnEncontrar.Name = "btnEncontrar";
            this.btnEncontrar.Size = new System.Drawing.Size(75, 39);
            this.btnEncontrar.TabIndex = 0;
            this.btnEncontrar.Text = "Encontrar caminhos";
            this.btnEncontrar.UseVisualStyleBackColor = true;
            this.btnEncontrar.Click += new System.EventHandler(this.btnEncontrar_Click);
            // 
            // btnAbrir
            // 
            this.btnAbrir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbrir.Location = new System.Drawing.Point(560, 12);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(75, 39);
            this.btnAbrir.TabIndex = 1;
            this.btnAbrir.Text = "Abrir arquivo";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // dgvLabirinto
            // 
            this.dgvLabirinto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvLabirinto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLabirinto.Location = new System.Drawing.Point(12, 98);
            this.dgvLabirinto.Name = "dgvLabirinto";
            this.dgvLabirinto.Size = new System.Drawing.Size(300, 300);
            this.dgvLabirinto.TabIndex = 2;
            // 
            // dgvCaminhos
            // 
            this.dgvCaminhos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCaminhos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCaminhos.Location = new System.Drawing.Point(318, 98);
            this.dgvCaminhos.Name = "dgvCaminhos";
            this.dgvCaminhos.Size = new System.Drawing.Size(398, 300);
            this.dgvCaminhos.TabIndex = 3;
            // 
            // lblLabirinto
            // 
            this.lblLabirinto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLabirinto.AutoSize = true;
            this.lblLabirinto.Location = new System.Drawing.Point(13, 79);
            this.lblLabirinto.Name = "lblLabirinto";
            this.lblLabirinto.Size = new System.Drawing.Size(47, 13);
            this.lblLabirinto.TabIndex = 4;
            this.lblLabirinto.Text = "Labirinto";
            // 
            // lblCaminhos
            // 
            this.lblCaminhos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCaminhos.AutoSize = true;
            this.lblCaminhos.Location = new System.Drawing.Point(315, 79);
            this.lblCaminhos.Name = "lblCaminhos";
            this.lblCaminhos.Size = new System.Drawing.Size(115, 13);
            this.lblCaminhos.TabIndex = 5;
            this.lblCaminhos.Text = "Caminhos encontrados";
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 410);
            this.Controls.Add(this.lblCaminhos);
            this.Controls.Add(this.lblLabirinto);
            this.Controls.Add(this.dgvCaminhos);
            this.Controls.Add(this.dgvLabirinto);
            this.Controls.Add(this.btnAbrir);
            this.Controls.Add(this.btnEncontrar);
            this.Name = "FormPrincipal";
            this.Text = "Caminhos em Labirinto";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabirinto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaminhos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEncontrar;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.DataGridView dgvLabirinto;
        private System.Windows.Forms.DataGridView dgvCaminhos;
        private System.Windows.Forms.Label lblLabirinto;
        private System.Windows.Forms.Label lblCaminhos;
        private System.Windows.Forms.OpenFileDialog dlgAbrirArquivo;
    }
}

