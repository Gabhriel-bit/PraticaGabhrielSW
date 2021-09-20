
namespace Projeto_ICI.frmConsultas
{
    partial class frmConsultaPai
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaPai));
            this.btn_Pesquisar = new System.Windows.Forms.Button();
            this.txtb_Pesquisa = new System.Windows.Forms.TextBox();
            this.btn_Sair = new System.Windows.Forms.Button();
            this.btn_Excluir = new System.Windows.Forms.Button();
            this.btn_Alterar = new System.Windows.Forms.Button();
            this.btn_Inserir = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.lbl_Pesquisa = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Pesquisar
            // 
            this.btn_Pesquisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Pesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Pesquisar.Image")));
            this.btn_Pesquisar.Location = new System.Drawing.Point(564, 28);
            this.btn_Pesquisar.Name = "btn_Pesquisar";
            this.btn_Pesquisar.Size = new System.Drawing.Size(26, 25);
            this.btn_Pesquisar.TabIndex = 19;
            this.btn_Pesquisar.UseVisualStyleBackColor = true;
            this.btn_Pesquisar.MouseEnter += new System.EventHandler(this.btn_Pesquisar_MouseEnter);
            this.btn_Pesquisar.MouseLeave += new System.EventHandler(this.btn_Pesquisar_MouseLeave);
            // 
            // txtb_Pesquisa
            // 
            this.txtb_Pesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtb_Pesquisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Pesquisa.Location = new System.Drawing.Point(25, 32);
            this.txtb_Pesquisa.Name = "txtb_Pesquisa";
            this.txtb_Pesquisa.Size = new System.Drawing.Size(533, 20);
            this.txtb_Pesquisa.TabIndex = 17;
            // 
            // btn_Sair
            // 
            this.btn_Sair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Sair.Location = new System.Drawing.Point(515, 341);
            this.btn_Sair.Name = "btn_Sair";
            this.btn_Sair.Size = new System.Drawing.Size(75, 23);
            this.btn_Sair.TabIndex = 16;
            this.btn_Sair.Text = "Sair";
            this.btn_Sair.UseVisualStyleBackColor = true;
            this.btn_Sair.Click += new System.EventHandler(this.btn_Sair_Click);
            // 
            // btn_Excluir
            // 
            this.btn_Excluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Excluir.Location = new System.Drawing.Point(357, 341);
            this.btn_Excluir.Name = "btn_Excluir";
            this.btn_Excluir.Size = new System.Drawing.Size(75, 23);
            this.btn_Excluir.TabIndex = 15;
            this.btn_Excluir.Text = "&Excluir";
            this.btn_Excluir.UseVisualStyleBackColor = true;
            // 
            // btn_Alterar
            // 
            this.btn_Alterar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Alterar.Location = new System.Drawing.Point(189, 341);
            this.btn_Alterar.Name = "btn_Alterar";
            this.btn_Alterar.Size = new System.Drawing.Size(75, 23);
            this.btn_Alterar.TabIndex = 14;
            this.btn_Alterar.Text = "&Alterar";
            this.btn_Alterar.UseVisualStyleBackColor = true;
            // 
            // btn_Inserir
            // 
            this.btn_Inserir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Inserir.Location = new System.Drawing.Point(25, 341);
            this.btn_Inserir.Name = "btn_Inserir";
            this.btn_Inserir.Size = new System.Drawing.Size(75, 23);
            this.btn_Inserir.TabIndex = 13;
            this.btn_Inserir.Text = "&Inserir";
            this.btn_Inserir.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(25, 58);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(565, 277);
            this.dataGridView.StandardTab = true;
            this.dataGridView.TabIndex = 12;
            // 
            // lbl_Pesquisa
            // 
            this.lbl_Pesquisa.AutoSize = true;
            this.lbl_Pesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Pesquisa.Location = new System.Drawing.Point(22, 12);
            this.lbl_Pesquisa.Name = "lbl_Pesquisa";
            this.lbl_Pesquisa.Size = new System.Drawing.Size(71, 17);
            this.lbl_Pesquisa.TabIndex = 20;
            this.lbl_Pesquisa.Text = "Pesquisar";
            // 
            // frmConsultaPai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(611, 377);
            this.Controls.Add(this.lbl_Pesquisa);
            this.Controls.Add(this.btn_Pesquisar);
            this.Controls.Add(this.txtb_Pesquisa);
            this.Controls.Add(this.btn_Sair);
            this.Controls.Add(this.btn_Excluir);
            this.Controls.Add(this.btn_Alterar);
            this.Controls.Add(this.btn_Inserir);
            this.Controls.Add(this.dataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConsultaPai";
            this.Text = "Consulta";
            this.Resize += new System.EventHandler(this.frmConsultaPai_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected System.Windows.Forms.Button btn_Pesquisar;
        protected System.Windows.Forms.TextBox txtb_Pesquisa;
        protected System.Windows.Forms.Button btn_Sair;
        protected System.Windows.Forms.Button btn_Excluir;
        protected System.Windows.Forms.Button btn_Alterar;
        protected System.Windows.Forms.Button btn_Inserir;
        protected System.Windows.Forms.Label lbl_Pesquisa;
        public System.Windows.Forms.DataGridView dataGridView;
    }
}
