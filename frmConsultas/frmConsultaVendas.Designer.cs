
namespace Projeto_ICI.frmConsultas
{
    partial class frmConsultaVendas
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
            this.lbl_CampoPesquisa = new System.Windows.Forms.Label();
            this.cb_ChavePesquisa = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).BeginInit();
            this.SuspendLayout();
            // 
            // txtb_Pesquisa
            // 
            this.txtb_Pesquisa.Location = new System.Drawing.Point(189, 32);
            this.txtb_Pesquisa.Size = new System.Drawing.Size(369, 20);
            // 
            // lbl_Pesquisa
            // 
            this.lbl_Pesquisa.Location = new System.Drawing.Point(186, 12);
            // 
            // lbl_CampoPesquisa
            // 
            this.lbl_CampoPesquisa.AutoSize = true;
            this.lbl_CampoPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CampoPesquisa.Location = new System.Drawing.Point(22, 12);
            this.lbl_CampoPesquisa.Name = "lbl_CampoPesquisa";
            this.lbl_CampoPesquisa.Size = new System.Drawing.Size(118, 17);
            this.lbl_CampoPesquisa.TabIndex = 24;
            this.lbl_CampoPesquisa.Text = "Campo pesquisar";
            // 
            // cb_ChavePesquisa
            // 
            this.cb_ChavePesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.55F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_ChavePesquisa.FormattingEnabled = true;
            this.cb_ChavePesquisa.Items.AddRange(new object[] {
            "Chave identificadora",
            "Data saída",
            "Data emissão",
            "Código Cliente",
            "Código da Transportadora",
            "Código da Condição Pagamento"});
            this.cb_ChavePesquisa.Location = new System.Drawing.Point(25, 31);
            this.cb_ChavePesquisa.Name = "cb_ChavePesquisa";
            this.cb_ChavePesquisa.Size = new System.Drawing.Size(158, 21);
            this.cb_ChavePesquisa.TabIndex = 23;
            this.cb_ChavePesquisa.Text = "Chave identificadora";
            // 
            // frmConsultaVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(611, 377);
            this.Controls.Add(this.lbl_CampoPesquisa);
            this.Controls.Add(this.cb_ChavePesquisa);
            this.Name = "frmConsultaVendas";
            this.Text = "Consulta de Vendas";
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

        protected System.Windows.Forms.Label lbl_CampoPesquisa;
        private System.Windows.Forms.ComboBox cb_ChavePesquisa;
    }
}
