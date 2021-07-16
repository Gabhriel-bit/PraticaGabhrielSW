
namespace Projeto_ICI.frmCadastros
{
    partial class frmCadastroFormasPagamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastroFormasPagamento));
            this.lbl_FormaPag = new System.Windows.Forms.Label();
            this.txtb_FormaPag = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).BeginInit();
            this.SuspendLayout();
            // 
            // txtb_CodigoUsu
            // 
            this.txtb_CodigoUsu.Location = new System.Drawing.Point(17, 247);
            // 
            // lbl_CodigoUsu
            // 
            this.lbl_CodigoUsu.Location = new System.Drawing.Point(14, 229);
            // 
            // btn_Sair
            // 
            this.btn_Sair.Location = new System.Drawing.Point(480, 242);
            this.btn_Sair.TabIndex = 3;
            // 
            // btn_Cadastro
            // 
            this.btn_Cadastro.Location = new System.Drawing.Point(408, 242);
            this.btn_Cadastro.TabIndex = 2;
            this.btn_Cadastro.Click += new System.EventHandler(this.btn_Cadastro_Click);
            // 
            // lbl_UltAlt
            // 
            this.lbl_UltAlt.Location = new System.Drawing.Point(234, 228);
            // 
            // lbl_DataCad
            // 
            this.lbl_DataCad.Location = new System.Drawing.Point(119, 228);
            // 
            // txtb_DataCadastro
            // 
            this.txtb_DataCadastro.Location = new System.Drawing.Point(122, 246);
            // 
            // txtb_DataUltAlt
            // 
            this.txtb_DataUltAlt.Location = new System.Drawing.Point(237, 246);
            // 
            // lbl_FormaPag
            // 
            this.lbl_FormaPag.AutoSize = true;
            this.lbl_FormaPag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FormaPag.Location = new System.Drawing.Point(96, 18);
            this.lbl_FormaPag.Name = "lbl_FormaPag";
            this.lbl_FormaPag.Size = new System.Drawing.Size(132, 15);
            this.lbl_FormaPag.TabIndex = 25;
            this.lbl_FormaPag.Text = "Forma de Pagamento*";
            // 
            // txtb_FormaPag
            // 
            this.txtb_FormaPag.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_FormaPag.Location = new System.Drawing.Point(99, 36);
            this.txtb_FormaPag.Name = "txtb_FormaPag";
            this.txtb_FormaPag.Size = new System.Drawing.Size(252, 20);
            this.txtb_FormaPag.TabIndex = 1;
            this.txtb_FormaPag.Validating += new System.ComponentModel.CancelEventHandler(this.txtb_FormaPag_Validating);
            // 
            // frmCadastroFormasPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(558, 280);
            this.Controls.Add(this.lbl_FormaPag);
            this.Controls.Add(this.txtb_FormaPag);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCadastroFormasPagamento";
            this.Text = "Cadastro de Formas de pagamento";
            this.Controls.SetChildIndex(this.lbl_Codigo, 0);
            this.Controls.SetChildIndex(this.lbl_DataCad, 0);
            this.Controls.SetChildIndex(this.lbl_UltAlt, 0);
            this.Controls.SetChildIndex(this.txtb_Codigo, 0);
            this.Controls.SetChildIndex(this.btn_Cadastro, 0);
            this.Controls.SetChildIndex(this.btn_Sair, 0);
            this.Controls.SetChildIndex(this.txtb_DataUltAlt, 0);
            this.Controls.SetChildIndex(this.txtb_DataCadastro, 0);
            this.Controls.SetChildIndex(this.lbl_CodigoUsu, 0);
            this.Controls.SetChildIndex(this.txtb_CodigoUsu, 0);
            this.Controls.SetChildIndex(this.txtb_FormaPag, 0);
            this.Controls.SetChildIndex(this.lbl_FormaPag, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_FormaPag;
        private System.Windows.Forms.TextBox txtb_FormaPag;
    }
}
