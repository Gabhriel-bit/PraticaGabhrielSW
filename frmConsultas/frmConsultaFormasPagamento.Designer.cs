
namespace Projeto_ICI.frmConsultas
{
    partial class frmConsultasFormasPagamento
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
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Pesquisar
            // 
            this.btn_Pesquisar.Click += new System.EventHandler(this.btn_Pesquisar_Click);
            // 
            // btn_Excluir
            // 
            this.btn_Excluir.Click += new System.EventHandler(this.btn_Excluir_Click);
            // 
            // btn_Alterar
            // 
            this.btn_Alterar.Click += new System.EventHandler(this.btn_Alterar_Click);
            // 
            // btn_Inserir
            // 
            this.btn_Inserir.Click += new System.EventHandler(this.btn_Inserir_Click);
            // 
            // frmConsultasFormasPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(611, 377);
            this.Name = "frmConsultasFormasPagamento";
            this.Text = "Consulta de Formas de Pagamento";
            this.Load += new System.EventHandler(this.frmConsultasFormasPagamento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
