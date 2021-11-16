
namespace Projeto_ICI.frmConsultas
{
    partial class frmConsultaCompras
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
            this.cb_ChavePesquisa = new System.Windows.Forms.ComboBox();
            this.lbl_CampoPesquisa = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Pesquisar
            // 
            this.btn_Pesquisar.Click += new System.EventHandler(this.btn_Pesquisar_Click);
            // 
            // txtb_Pesquisa
            // 
            this.txtb_Pesquisa.Location = new System.Drawing.Point(189, 32);
            this.txtb_Pesquisa.Size = new System.Drawing.Size(369, 20);
            // 
            // btn_Excluir
            // 
            this.btn_Excluir.Click += new System.EventHandler(this.btn_Excluir_Click);
            // 
            // btn_Inserir
            // 
            this.btn_Inserir.Click += new System.EventHandler(this.btn_Inserir_Click);
            // 
            // lbl_Pesquisa
            // 
            this.lbl_Pesquisa.Location = new System.Drawing.Point(186, 12);
            // 
            // cb_ChavePesquisa
            // 
            this.cb_ChavePesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.55F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_ChavePesquisa.FormattingEnabled = true;
            this.cb_ChavePesquisa.Items.AddRange(new object[] {
            "Chave identificadora",
            "Data chegada",
            "Data emissão",
            "Código Fornecedor",
            "Código da Transportadora",
            "Código da Condição Pagamento"});
            this.cb_ChavePesquisa.Location = new System.Drawing.Point(25, 31);
            this.cb_ChavePesquisa.Name = "cb_ChavePesquisa";
            this.cb_ChavePesquisa.Size = new System.Drawing.Size(158, 21);
            this.cb_ChavePesquisa.TabIndex = 21;
            this.cb_ChavePesquisa.Text = "Chave identificadora";
            this.cb_ChavePesquisa.SelectedIndexChanged += new System.EventHandler(this.cb_ChavePesquisa_SelectedIndexChanged);
            // 
            // lbl_CampoPesquisa
            // 
            this.lbl_CampoPesquisa.AutoSize = true;
            this.lbl_CampoPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CampoPesquisa.Location = new System.Drawing.Point(22, 12);
            this.lbl_CampoPesquisa.Name = "lbl_CampoPesquisa";
            this.lbl_CampoPesquisa.Size = new System.Drawing.Size(118, 17);
            this.lbl_CampoPesquisa.TabIndex = 22;
            this.lbl_CampoPesquisa.Text = "Campo pesquisar";
            // 
            // frmConsultaCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(611, 377);
            this.Controls.Add(this.lbl_CampoPesquisa);
            this.Controls.Add(this.cb_ChavePesquisa);
            this.Name = "frmConsultaCompras";
            this.Text = "Consulta Compras";
            this.Load += new System.EventHandler(this.frmConsultaCompras_Load);
            this.Controls.SetChildIndex(this.btn_Inserir, 0);
            this.Controls.SetChildIndex(this.btn_Alterar, 0);
            this.Controls.SetChildIndex(this.btn_Excluir, 0);
            this.Controls.SetChildIndex(this.btn_Sair, 0);
            this.Controls.SetChildIndex(this.txtb_Pesquisa, 0);
            this.Controls.SetChildIndex(this.btn_Pesquisar, 0);
            this.Controls.SetChildIndex(this.lbl_Pesquisa, 0);
            this.Controls.SetChildIndex(this.cb_ChavePesquisa, 0);
            this.Controls.SetChildIndex(this.lbl_CampoPesquisa, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_ChavePesquisa;
        protected System.Windows.Forms.Label lbl_CampoPesquisa;
    }
}
