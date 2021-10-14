
namespace Projeto_ICI.frmCadastros
{
    partial class frmCadastroTransportadoras
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
            this.lbl_Transportadora = new System.Windows.Forms.Label();
            this.txtb_Transportadora = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_DataNasc_Fund
            // 
            this.lbl_DataNasc_Fund.Size = new System.Drawing.Size(87, 15);
            this.lbl_DataNasc_Fund.Text = "Data fundação";
            // 
            // lbl_CPF_CNPJ
            // 
            this.lbl_CPF_CNPJ.Size = new System.Drawing.Size(43, 15);
            this.lbl_CPF_CNPJ.Text = "CNPJ*";
            // 
            // txtb_CPF_CNPJ
            // 
            this.txtb_CPF_CNPJ.MaxLength = 18;
            this.txtb_CPF_CNPJ.Validating += new System.ComponentModel.CancelEventHandler(this.txtb_CPF_CNPJ_Validating);
            // 
            // lbl_RG_InscEstadual
            // 
            this.lbl_RG_InscEstadual.Size = new System.Drawing.Size(107, 15);
            this.lbl_RG_InscEstadual.Text = "Inscrição Estadual";
            // 
            // lbl_telCelular
            // 
            this.lbl_telCelular.Size = new System.Drawing.Size(60, 15);
            this.lbl_telCelular.Text = "Telefone*";
            // 
            // btn_Cadastro
            // 
            this.btn_Cadastro.Click += new System.EventHandler(this.btn_Cadastro_Click);
            // 
            // lbl_Transportadora
            // 
            this.lbl_Transportadora.AutoSize = true;
            this.lbl_Transportadora.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Transportadora.Location = new System.Drawing.Point(96, 18);
            this.lbl_Transportadora.Name = "lbl_Transportadora";
            this.lbl_Transportadora.Size = new System.Drawing.Size(96, 15);
            this.lbl_Transportadora.TabIndex = 73;
            this.lbl_Transportadora.Text = "Transportadora*";
            // 
            // txtb_Transportadora
            // 
            this.txtb_Transportadora.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Transportadora.Location = new System.Drawing.Point(99, 36);
            this.txtb_Transportadora.Name = "txtb_Transportadora";
            this.txtb_Transportadora.Size = new System.Drawing.Size(337, 20);
            this.txtb_Transportadora.TabIndex = 72;
            this.txtb_Transportadora.Validating += new System.ComponentModel.CancelEventHandler(this.txtb_Transpotadora_Validating);
            // 
            // frmCadastroTransportadoras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(670, 480);
            this.Controls.Add(this.lbl_Transportadora);
            this.Controls.Add(this.txtb_Transportadora);
            this.Name = "frmCadastroTransportadoras";
            this.Text = "Cadastro de Transportadoras";
            this.Controls.SetChildIndex(this.lbl_Codigo, 0);
            this.Controls.SetChildIndex(this.lbl_DataCad, 0);
            this.Controls.SetChildIndex(this.lbl_UltAlt, 0);
            this.Controls.SetChildIndex(this.txtb_Codigo, 0);
            this.Controls.SetChildIndex(this.btn_Cadastro, 0);
            this.Controls.SetChildIndex(this.btn_Sair, 0);
            this.Controls.SetChildIndex(this.lbl_CodigoUsu, 0);
            this.Controls.SetChildIndex(this.txtb_CodigoUsu, 0);
            this.Controls.SetChildIndex(this.txtb_DataCadastro, 0);
            this.Controls.SetChildIndex(this.txtb_DataUltAlt, 0);
            this.Controls.SetChildIndex(this.txtb_Logradouro, 0);
            this.Controls.SetChildIndex(this.lbl_Logradouro, 0);
            this.Controls.SetChildIndex(this.txtb_Numero, 0);
            this.Controls.SetChildIndex(this.lbl_Numero, 0);
            this.Controls.SetChildIndex(this.txtb_Complemento, 0);
            this.Controls.SetChildIndex(this.lbl_Complemento, 0);
            this.Controls.SetChildIndex(this.txtb_Bairro, 0);
            this.Controls.SetChildIndex(this.lbl_Bairro, 0);
            this.Controls.SetChildIndex(this.txtb_CodigoCidade, 0);
            this.Controls.SetChildIndex(this.lbl_CodigoCidade, 0);
            this.Controls.SetChildIndex(this.txtb_Cidade, 0);
            this.Controls.SetChildIndex(this.lbl_Cidade, 0);
            this.Controls.SetChildIndex(this.btn_PesquisarCidade, 0);
            this.Controls.SetChildIndex(this.txtb_CEP, 0);
            this.Controls.SetChildIndex(this.lbl_CEP, 0);
            this.Controls.SetChildIndex(this.txtb_telCelular, 0);
            this.Controls.SetChildIndex(this.lbl_telCelular, 0);
            this.Controls.SetChildIndex(this.txtb_Email, 0);
            this.Controls.SetChildIndex(this.lbl_Email, 0);
            this.Controls.SetChildIndex(this.txtb_RG_InscEstadual, 0);
            this.Controls.SetChildIndex(this.lbl_RG_InscEstadual, 0);
            this.Controls.SetChildIndex(this.txtb_CPF_CNPJ, 0);
            this.Controls.SetChildIndex(this.lbl_CPF_CNPJ, 0);
            this.Controls.SetChildIndex(this.lbl_DataNasc_Fund, 0);
            this.Controls.SetChildIndex(this.date_DataNasc_Fund, 0);
            this.Controls.SetChildIndex(this.txtb_Transportadora, 0);
            this.Controls.SetChildIndex(this.lbl_Transportadora, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Transportadora;
        private System.Windows.Forms.TextBox txtb_Transportadora;
    }
}
