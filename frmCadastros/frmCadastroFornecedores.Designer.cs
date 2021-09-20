
namespace Projeto_ICI.frmCadastros
{
    partial class frmCadastroFornecedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastroFornecedores));
            this.lbl_Fornecedor = new System.Windows.Forms.Label();
            this.txtb_Fornecedor = new System.Windows.Forms.TextBox();
            this.lbl_CondicaoPag = new System.Windows.Forms.Label();
            this.txtb_CondicaoPag = new System.Windows.Forms.TextBox();
            this.rb_Juridica = new System.Windows.Forms.RadioButton();
            this.rb_Fisica = new System.Windows.Forms.RadioButton();
            this.lbl_tipoPessoa = new System.Windows.Forms.Label();
            this.btn_PesquisarCondPag = new System.Windows.Forms.Button();
            this.txtb_CodigoCondPag = new System.Windows.Forms.TextBox();
            this.lbl_CodigoCondPag = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).BeginInit();
            this.SuspendLayout();
            // 
            // txtb_CPF_CNPJ
            // 
            this.txtb_CPF_CNPJ.Validating += new System.ComponentModel.CancelEventHandler(this.txtb_CPF_CNPJ_Validating);
            // 
            // btn_PesquisarCidade
            // 
            // txtb_CodigoUsu
            // 
            this.txtb_CodigoUsu.Location = new System.Drawing.Point(24, 373);
            // 
            // lbl_CodigoUsu
            // 
            this.lbl_CodigoUsu.Location = new System.Drawing.Point(21, 355);
            // 
            // btn_Sair
            // 
            this.btn_Sair.Location = new System.Drawing.Point(556, 367);
            this.btn_Sair.TabIndex = 18;
            // 
            // btn_Cadastro
            // 
            this.btn_Cadastro.Location = new System.Drawing.Point(484, 366);
            this.btn_Cadastro.TabIndex = 17;
            this.btn_Cadastro.Click += new System.EventHandler(this.btn_Cadastro_Click);
            // 
            // lbl_UltAlt
            // 
            this.lbl_UltAlt.Location = new System.Drawing.Point(241, 354);
            // 
            // lbl_DataCad
            // 
            this.lbl_DataCad.Location = new System.Drawing.Point(126, 354);
            // 
            // txtb_DataCadastro
            // 
            this.txtb_DataCadastro.Location = new System.Drawing.Point(129, 372);
            // 
            // txtb_DataUltAlt
            // 
            this.txtb_DataUltAlt.Location = new System.Drawing.Point(244, 372);
            // 
            // lbl_Fornecedor
            // 
            this.lbl_Fornecedor.AutoSize = true;
            this.lbl_Fornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Fornecedor.Location = new System.Drawing.Point(96, 18);
            this.lbl_Fornecedor.Name = "lbl_Fornecedor";
            this.lbl_Fornecedor.Size = new System.Drawing.Size(75, 15);
            this.lbl_Fornecedor.TabIndex = 21;
            this.lbl_Fornecedor.Text = "Fornecedor*";
            // 
            // txtb_Fornecedor
            // 
            this.txtb_Fornecedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Fornecedor.Location = new System.Drawing.Point(99, 36);
            this.txtb_Fornecedor.Name = "txtb_Fornecedor";
            this.txtb_Fornecedor.Size = new System.Drawing.Size(337, 20);
            this.txtb_Fornecedor.TabIndex = 1;
            this.txtb_Fornecedor.Validating += new System.ComponentModel.CancelEventHandler(this.txtb_Fornecedor_Validating);
            // 
            // lbl_CondicaoPag
            // 
            this.lbl_CondicaoPag.AutoSize = true;
            this.lbl_CondicaoPag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CondicaoPag.Location = new System.Drawing.Point(439, 187);
            this.lbl_CondicaoPag.Name = "lbl_CondicaoPag";
            this.lbl_CondicaoPag.Size = new System.Drawing.Size(111, 15);
            this.lbl_CondicaoPag.TabIndex = 64;
            this.lbl_CondicaoPag.Text = "Cond. Pagamento*";
            // 
            // txtb_CondicaoPag
            // 
            this.txtb_CondicaoPag.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_CondicaoPag.Enabled = false;
            this.txtb_CondicaoPag.Location = new System.Drawing.Point(442, 205);
            this.txtb_CondicaoPag.Name = "txtb_CondicaoPag";
            this.txtb_CondicaoPag.Size = new System.Drawing.Size(130, 20);
            this.txtb_CondicaoPag.TabIndex = 13;
            // 
            // rb_Juridica
            // 
            this.rb_Juridica.AutoSize = true;
            this.rb_Juridica.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Juridica.Location = new System.Drawing.Point(465, 50);
            this.rb_Juridica.Name = "rb_Juridica";
            this.rb_Juridica.Size = new System.Drawing.Size(68, 19);
            this.rb_Juridica.TabIndex = 3;
            this.rb_Juridica.TabStop = true;
            this.rb_Juridica.Text = "Jurídica";
            this.rb_Juridica.UseVisualStyleBackColor = true;
            this.rb_Juridica.CheckedChanged += new System.EventHandler(this.rb_Juridica_CheckedChanged);
            // 
            // rb_Fisica
            // 
            this.rb_Fisica.AutoSize = true;
            this.rb_Fisica.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Fisica.Location = new System.Drawing.Point(465, 27);
            this.rb_Fisica.Name = "rb_Fisica";
            this.rb_Fisica.Size = new System.Drawing.Size(55, 20);
            this.rb_Fisica.TabIndex = 2;
            this.rb_Fisica.TabStop = true;
            this.rb_Fisica.Text = "Física";
            this.rb_Fisica.UseVisualStyleBackColor = true;
            this.rb_Fisica.CheckedChanged += new System.EventHandler(this.rb_Fisica_CheckedChanged);
            // 
            // lbl_tipoPessoa
            // 
            this.lbl_tipoPessoa.AutoSize = true;
            this.lbl_tipoPessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tipoPessoa.Location = new System.Drawing.Point(462, 9);
            this.lbl_tipoPessoa.Name = "lbl_tipoPessoa";
            this.lbl_tipoPessoa.Size = new System.Drawing.Size(96, 15);
            this.lbl_tipoPessoa.TabIndex = 65;
            this.lbl_tipoPessoa.Text = "Tipo de pessoa*";
            // 
            // btn_PesquisarCondPag
            // 
            this.btn_PesquisarCondPag.Location = new System.Drawing.Point(578, 201);
            this.btn_PesquisarCondPag.Name = "btn_PesquisarCondPag";
            this.btn_PesquisarCondPag.Size = new System.Drawing.Size(26, 25);
            this.btn_PesquisarCondPag.TabIndex = 68;
            this.btn_PesquisarCondPag.UseVisualStyleBackColor = true;
            this.btn_PesquisarCondPag.Click += new System.EventHandler(this.btn_PesquisarCondPag_Click);
            this.btn_PesquisarCondPag.MouseEnter += new System.EventHandler(this.btn_PesquisarCondPag_MouseEnter);
            this.btn_PesquisarCondPag.MouseLeave += new System.EventHandler(this.btn_PesquisarCondPag_MouseLeave);
            // 
            // txtb_CodigoCondPag
            // 
            this.txtb_CodigoCondPag.Location = new System.Drawing.Point(373, 205);
            this.txtb_CodigoCondPag.Name = "txtb_CodigoCondPag";
            this.txtb_CodigoCondPag.Size = new System.Drawing.Size(63, 20);
            this.txtb_CodigoCondPag.TabIndex = 75;
            this.txtb_CodigoCondPag.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtb_CodigoCondPag.TextChanged += new System.EventHandler(this.txtb_CodigoCondPag_TextChanged);
            this.txtb_CodigoCondPag.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtb_CodigoCondPag_KeyPress);
            // 
            // lbl_CodigoCondPag
            // 
            this.lbl_CodigoCondPag.AutoSize = true;
            this.lbl_CodigoCondPag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CodigoCondPag.Location = new System.Drawing.Point(370, 187);
            this.lbl_CodigoCondPag.Name = "lbl_CodigoCondPag";
            this.lbl_CodigoCondPag.Size = new System.Drawing.Size(46, 15);
            this.lbl_CodigoCondPag.TabIndex = 74;
            this.lbl_CodigoCondPag.Text = "Código";
            // 
            // frmCadastroFornecedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 405);
            this.Controls.Add(this.txtb_CodigoCondPag);
            this.Controls.Add(this.lbl_CodigoCondPag);
            this.Controls.Add(this.btn_PesquisarCondPag);
            this.Controls.Add(this.rb_Juridica);
            this.Controls.Add(this.rb_Fisica);
            this.Controls.Add(this.lbl_tipoPessoa);
            this.Controls.Add(this.lbl_CondicaoPag);
            this.Controls.Add(this.txtb_CondicaoPag);
            this.Controls.Add(this.lbl_Fornecedor);
            this.Controls.Add(this.txtb_Fornecedor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCadastroFornecedores";
            this.Text = "Cadastro de fornecedores";
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
            this.Controls.SetChildIndex(this.txtb_Fornecedor, 0);
            this.Controls.SetChildIndex(this.lbl_Fornecedor, 0);
            this.Controls.SetChildIndex(this.txtb_CondicaoPag, 0);
            this.Controls.SetChildIndex(this.lbl_CondicaoPag, 0);
            this.Controls.SetChildIndex(this.lbl_tipoPessoa, 0);
            this.Controls.SetChildIndex(this.rb_Fisica, 0);
            this.Controls.SetChildIndex(this.rb_Juridica, 0);
            this.Controls.SetChildIndex(this.btn_PesquisarCondPag, 0);
            this.Controls.SetChildIndex(this.lbl_CodigoCondPag, 0);
            this.Controls.SetChildIndex(this.txtb_CodigoCondPag, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Fornecedor;
        private System.Windows.Forms.TextBox txtb_Fornecedor;
        private System.Windows.Forms.Label lbl_CondicaoPag;
        private System.Windows.Forms.TextBox txtb_CondicaoPag;
        private System.Windows.Forms.RadioButton rb_Juridica;
        private System.Windows.Forms.RadioButton rb_Fisica;
        private System.Windows.Forms.Label lbl_tipoPessoa;
        private System.Windows.Forms.Button btn_PesquisarCondPag;
        protected System.Windows.Forms.TextBox txtb_CodigoCondPag;
        protected System.Windows.Forms.Label lbl_CodigoCondPag;
    }
}
