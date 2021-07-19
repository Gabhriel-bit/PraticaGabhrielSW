
namespace Projeto_ICI.frmCadastros
{
    partial class frmCadastroPessoas
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
            this.date_DataNasc_Fund = new System.Windows.Forms.DateTimePicker();
            this.lbl_DataNasc_Fund = new System.Windows.Forms.Label();
            this.lbl_CPF_CNPJ = new System.Windows.Forms.Label();
            this.txtb_CPF_CNPJ = new System.Windows.Forms.TextBox();
            this.lbl_RG_InscEstadual = new System.Windows.Forms.Label();
            this.txtb_RG_InscEstadual = new System.Windows.Forms.TextBox();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.txtb_Email = new System.Windows.Forms.TextBox();
            this.lbl_telCelular = new System.Windows.Forms.Label();
            this.txtb_telCelular = new System.Windows.Forms.TextBox();
            this.lbl_CEP = new System.Windows.Forms.Label();
            this.txtb_CEP = new System.Windows.Forms.TextBox();
            this.btn_PesquisarCidade = new System.Windows.Forms.Button();
            this.lbl_Cidade = new System.Windows.Forms.Label();
            this.txtb_Cidade = new System.Windows.Forms.TextBox();
            this.lbl_CodigoCidade = new System.Windows.Forms.Label();
            this.txtb_CodigoCidade = new System.Windows.Forms.TextBox();
            this.lbl_Bairro = new System.Windows.Forms.Label();
            this.txtb_Bairro = new System.Windows.Forms.TextBox();
            this.lbl_Complemento = new System.Windows.Forms.Label();
            this.txtb_Complemento = new System.Windows.Forms.TextBox();
            this.lbl_Numero = new System.Windows.Forms.Label();
            this.txtb_Numero = new System.Windows.Forms.TextBox();
            this.lbl_Logradouro = new System.Windows.Forms.Label();
            this.txtb_Logradouro = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).BeginInit();
            this.SuspendLayout();
            // 
            // txtb_CodigoUsu
            // 
            this.txtb_CodigoUsu.Location = new System.Drawing.Point(17, 447);
            // 
            // lbl_CodigoUsu
            // 
            this.lbl_CodigoUsu.Location = new System.Drawing.Point(14, 429);
            // 
            // btn_Sair
            // 
            this.btn_Sair.Location = new System.Drawing.Point(592, 442);
            // 
            // btn_Cadastro
            // 
            this.btn_Cadastro.Location = new System.Drawing.Point(520, 441);
            // 
            // lbl_UltAlt
            // 
            this.lbl_UltAlt.Location = new System.Drawing.Point(234, 428);
            // 
            // lbl_DataCad
            // 
            this.lbl_DataCad.Location = new System.Drawing.Point(119, 428);
            // 
            // txtb_DataCadastro
            // 
            this.txtb_DataCadastro.Location = new System.Drawing.Point(122, 447);
            // 
            // txtb_DataUltAlt
            // 
            this.txtb_DataUltAlt.Location = new System.Drawing.Point(237, 447);
            // 
            // date_DataNasc_Fund
            // 
            this.date_DataNasc_Fund.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_DataNasc_Fund.Location = new System.Drawing.Point(310, 260);
            this.date_DataNasc_Fund.Name = "date_DataNasc_Fund";
            this.date_DataNasc_Fund.Size = new System.Drawing.Size(105, 20);
            this.date_DataNasc_Fund.TabIndex = 59;
            this.date_DataNasc_Fund.Validating += new System.ComponentModel.CancelEventHandler(this.date_DataNasc_Validating);
            // 
            // lbl_DataNasc_Fund
            // 
            this.lbl_DataNasc_Fund.AutoSize = true;
            this.lbl_DataNasc_Fund.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DataNasc_Fund.Location = new System.Drawing.Point(307, 242);
            this.lbl_DataNasc_Fund.Name = "lbl_DataNasc_Fund";
            this.lbl_DataNasc_Fund.Size = new System.Drawing.Size(100, 15);
            this.lbl_DataNasc_Fund.TabIndex = 71;
            this.lbl_DataNasc_Fund.Text = "Data nascimento";
            // 
            // lbl_CPF_CNPJ
            // 
            this.lbl_CPF_CNPJ.AutoSize = true;
            this.lbl_CPF_CNPJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CPF_CNPJ.Location = new System.Drawing.Point(21, 242);
            this.lbl_CPF_CNPJ.Name = "lbl_CPF_CNPJ";
            this.lbl_CPF_CNPJ.Size = new System.Drawing.Size(35, 15);
            this.lbl_CPF_CNPJ.TabIndex = 69;
            this.lbl_CPF_CNPJ.Text = "CPF*";
            // 
            // txtb_CPF_CNPJ
            // 
            this.txtb_CPF_CNPJ.Location = new System.Drawing.Point(24, 260);
            this.txtb_CPF_CNPJ.MaxLength = 14;
            this.txtb_CPF_CNPJ.Name = "txtb_CPF_CNPJ";
            this.txtb_CPF_CNPJ.Size = new System.Drawing.Size(137, 20);
            this.txtb_CPF_CNPJ.TabIndex = 56;
            this.txtb_CPF_CNPJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtb_CPF_CNPJ_KeyPress);
            this.txtb_CPF_CNPJ.Validating += new System.ComponentModel.CancelEventHandler(this.txtb_CPF_CNPJ_Validating);
            this.txtb_CPF_CNPJ.Validated += new System.EventHandler(this.txtb_CPF_CNPJ_Validated);
            // 
            // lbl_RG_InscEstadual
            // 
            this.lbl_RG_InscEstadual.AutoSize = true;
            this.lbl_RG_InscEstadual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_RG_InscEstadual.Location = new System.Drawing.Point(164, 242);
            this.lbl_RG_InscEstadual.Name = "lbl_RG_InscEstadual";
            this.lbl_RG_InscEstadual.Size = new System.Drawing.Size(25, 15);
            this.lbl_RG_InscEstadual.TabIndex = 68;
            this.lbl_RG_InscEstadual.Text = "RG";
            // 
            // txtb_RG_InscEstadual
            // 
            this.txtb_RG_InscEstadual.Location = new System.Drawing.Point(167, 260);
            this.txtb_RG_InscEstadual.Name = "txtb_RG_InscEstadual";
            this.txtb_RG_InscEstadual.Size = new System.Drawing.Size(137, 20);
            this.txtb_RG_InscEstadual.TabIndex = 57;
            // 
            // lbl_Email
            // 
            this.lbl_Email.AutoSize = true;
            this.lbl_Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Email.Location = new System.Drawing.Point(157, 187);
            this.lbl_Email.Name = "lbl_Email";
            this.lbl_Email.Size = new System.Drawing.Size(44, 15);
            this.lbl_Email.TabIndex = 67;
            this.lbl_Email.Text = "Email*";
            // 
            // txtb_Email
            // 
            this.txtb_Email.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Email.Location = new System.Drawing.Point(160, 205);
            this.txtb_Email.Name = "txtb_Email";
            this.txtb_Email.Size = new System.Drawing.Size(207, 20);
            this.txtb_Email.TabIndex = 52;
            this.txtb_Email.Validating += new System.ComponentModel.CancelEventHandler(this.txtb_Email_Validating);
            // 
            // lbl_telCelular
            // 
            this.lbl_telCelular.AutoSize = true;
            this.lbl_telCelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_telCelular.Location = new System.Drawing.Point(21, 187);
            this.lbl_telCelular.Name = "lbl_telCelular";
            this.lbl_telCelular.Size = new System.Drawing.Size(51, 15);
            this.lbl_telCelular.TabIndex = 66;
            this.lbl_telCelular.Text = "Celular*";
            // 
            // txtb_telCelular
            // 
            this.txtb_telCelular.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_telCelular.Location = new System.Drawing.Point(24, 205);
            this.txtb_telCelular.Name = "txtb_telCelular";
            this.txtb_telCelular.Size = new System.Drawing.Size(130, 20);
            this.txtb_telCelular.TabIndex = 51;
            this.txtb_telCelular.Validating += new System.ComponentModel.CancelEventHandler(this.txtb_telCelular_Validating);
            // 
            // lbl_CEP
            // 
            this.lbl_CEP.AutoSize = true;
            this.lbl_CEP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CEP.Location = new System.Drawing.Point(21, 133);
            this.lbl_CEP.Name = "lbl_CEP";
            this.lbl_CEP.Size = new System.Drawing.Size(31, 15);
            this.lbl_CEP.TabIndex = 65;
            this.lbl_CEP.Text = "CEP";
            // 
            // txtb_CEP
            // 
            this.txtb_CEP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_CEP.Location = new System.Drawing.Point(24, 151);
            this.txtb_CEP.Name = "txtb_CEP";
            this.txtb_CEP.Size = new System.Drawing.Size(137, 20);
            this.txtb_CEP.TabIndex = 48;
            // 
            // btn_PesquisarCidade
            // 
            this.btn_PesquisarCidade.Location = new System.Drawing.Point(507, 144);
            this.btn_PesquisarCidade.Name = "btn_PesquisarCidade";
            this.btn_PesquisarCidade.Size = new System.Drawing.Size(26, 25);
            this.btn_PesquisarCidade.TabIndex = 50;
            this.btn_PesquisarCidade.UseVisualStyleBackColor = true;
            this.btn_PesquisarCidade.Click += new System.EventHandler(this.btn_PesquisarCidade_Click);
            this.btn_PesquisarCidade.MouseEnter += new System.EventHandler(this.btn_PesquisarCidade_MouseEnter);
            this.btn_PesquisarCidade.MouseLeave += new System.EventHandler(this.btn_PesquisarCidade_MouseLeave);
            // 
            // lbl_Cidade
            // 
            this.lbl_Cidade.AutoSize = true;
            this.lbl_Cidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Cidade.Location = new System.Drawing.Point(241, 133);
            this.lbl_Cidade.Name = "lbl_Cidade";
            this.lbl_Cidade.Size = new System.Drawing.Size(51, 15);
            this.lbl_Cidade.TabIndex = 64;
            this.lbl_Cidade.Text = "Cidade*";
            // 
            // txtb_Cidade
            // 
            this.txtb_Cidade.Enabled = false;
            this.txtb_Cidade.Location = new System.Drawing.Point(242, 151);
            this.txtb_Cidade.Name = "txtb_Cidade";
            this.txtb_Cidade.Size = new System.Drawing.Size(259, 20);
            this.txtb_Cidade.TabIndex = 63;
            // 
            // lbl_CodigoCidade
            // 
            this.lbl_CodigoCidade.AutoSize = true;
            this.lbl_CodigoCidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CodigoCidade.Location = new System.Drawing.Point(164, 133);
            this.lbl_CodigoCidade.Name = "lbl_CodigoCidade";
            this.lbl_CodigoCidade.Size = new System.Drawing.Size(60, 15);
            this.lbl_CodigoCidade.TabIndex = 62;
            this.lbl_CodigoCidade.Text = "Código C.";
            // 
            // txtb_CodigoCidade
            // 
            this.txtb_CodigoCidade.Location = new System.Drawing.Point(167, 151);
            this.txtb_CodigoCidade.Name = "txtb_CodigoCidade";
            this.txtb_CodigoCidade.Size = new System.Drawing.Size(69, 20);
            this.txtb_CodigoCidade.TabIndex = 49;
            this.txtb_CodigoCidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtb_CodigoCidade.TextChanged += new System.EventHandler(this.txtb_CodigoCidade_TextChanged);
            this.txtb_CodigoCidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtb_CodigoCidade_KeyPress);
            // 
            // lbl_Bairro
            // 
            this.lbl_Bairro.AutoSize = true;
            this.lbl_Bairro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Bairro.Location = new System.Drawing.Point(370, 73);
            this.lbl_Bairro.Name = "lbl_Bairro";
            this.lbl_Bairro.Size = new System.Drawing.Size(45, 15);
            this.lbl_Bairro.TabIndex = 61;
            this.lbl_Bairro.Text = "Bairro*";
            // 
            // txtb_Bairro
            // 
            this.txtb_Bairro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Bairro.Location = new System.Drawing.Point(373, 91);
            this.txtb_Bairro.Name = "txtb_Bairro";
            this.txtb_Bairro.Size = new System.Drawing.Size(197, 20);
            this.txtb_Bairro.TabIndex = 47;
            // 
            // lbl_Complemento
            // 
            this.lbl_Complemento.AutoSize = true;
            this.lbl_Complemento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Complemento.Location = new System.Drawing.Point(234, 73);
            this.lbl_Complemento.Name = "lbl_Complemento";
            this.lbl_Complemento.Size = new System.Drawing.Size(85, 15);
            this.lbl_Complemento.TabIndex = 60;
            this.lbl_Complemento.Text = "Complemento";
            // 
            // txtb_Complemento
            // 
            this.txtb_Complemento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Complemento.Location = new System.Drawing.Point(237, 91);
            this.txtb_Complemento.Name = "txtb_Complemento";
            this.txtb_Complemento.Size = new System.Drawing.Size(130, 20);
            this.txtb_Complemento.TabIndex = 46;
            // 
            // lbl_Numero
            // 
            this.lbl_Numero.AutoSize = true;
            this.lbl_Numero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Numero.Location = new System.Drawing.Point(170, 73);
            this.lbl_Numero.Name = "lbl_Numero";
            this.lbl_Numero.Size = new System.Drawing.Size(57, 15);
            this.lbl_Numero.TabIndex = 58;
            this.lbl_Numero.Text = "Número*";
            // 
            // txtb_Numero
            // 
            this.txtb_Numero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Numero.Location = new System.Drawing.Point(173, 91);
            this.txtb_Numero.Name = "txtb_Numero";
            this.txtb_Numero.Size = new System.Drawing.Size(58, 20);
            this.txtb_Numero.TabIndex = 45;
            // 
            // lbl_Logradouro
            // 
            this.lbl_Logradouro.AutoSize = true;
            this.lbl_Logradouro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Logradouro.Location = new System.Drawing.Point(21, 73);
            this.lbl_Logradouro.Name = "lbl_Logradouro";
            this.lbl_Logradouro.Size = new System.Drawing.Size(76, 15);
            this.lbl_Logradouro.TabIndex = 54;
            this.lbl_Logradouro.Text = "Logradouro*";
            // 
            // txtb_Logradouro
            // 
            this.txtb_Logradouro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Logradouro.Location = new System.Drawing.Point(24, 91);
            this.txtb_Logradouro.Name = "txtb_Logradouro";
            this.txtb_Logradouro.Size = new System.Drawing.Size(143, 20);
            this.txtb_Logradouro.TabIndex = 44;
            // 
            // frmCadastroPessoas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(670, 480);
            this.Controls.Add(this.date_DataNasc_Fund);
            this.Controls.Add(this.lbl_DataNasc_Fund);
            this.Controls.Add(this.lbl_CPF_CNPJ);
            this.Controls.Add(this.txtb_CPF_CNPJ);
            this.Controls.Add(this.lbl_RG_InscEstadual);
            this.Controls.Add(this.txtb_RG_InscEstadual);
            this.Controls.Add(this.lbl_Email);
            this.Controls.Add(this.txtb_Email);
            this.Controls.Add(this.lbl_telCelular);
            this.Controls.Add(this.txtb_telCelular);
            this.Controls.Add(this.lbl_CEP);
            this.Controls.Add(this.txtb_CEP);
            this.Controls.Add(this.btn_PesquisarCidade);
            this.Controls.Add(this.lbl_Cidade);
            this.Controls.Add(this.txtb_Cidade);
            this.Controls.Add(this.lbl_CodigoCidade);
            this.Controls.Add(this.txtb_CodigoCidade);
            this.Controls.Add(this.lbl_Bairro);
            this.Controls.Add(this.txtb_Bairro);
            this.Controls.Add(this.lbl_Complemento);
            this.Controls.Add(this.txtb_Complemento);
            this.Controls.Add(this.lbl_Numero);
            this.Controls.Add(this.txtb_Numero);
            this.Controls.Add(this.lbl_Logradouro);
            this.Controls.Add(this.txtb_Logradouro);
            this.Name = "frmCadastroPessoas";
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
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.DateTimePicker date_DataNasc_Fund;
        protected System.Windows.Forms.Label lbl_DataNasc_Fund;
        protected System.Windows.Forms.Label lbl_CPF_CNPJ;
        protected System.Windows.Forms.TextBox txtb_CPF_CNPJ;
        protected System.Windows.Forms.Label lbl_RG_InscEstadual;
        protected System.Windows.Forms.TextBox txtb_RG_InscEstadual;
        protected System.Windows.Forms.Label lbl_Email;
        protected System.Windows.Forms.TextBox txtb_Email;
        protected System.Windows.Forms.Label lbl_telCelular;
        protected System.Windows.Forms.TextBox txtb_telCelular;
        protected System.Windows.Forms.Label lbl_CEP;
        protected System.Windows.Forms.TextBox txtb_CEP;
        protected System.Windows.Forms.Button btn_PesquisarCidade;
        protected System.Windows.Forms.Label lbl_Cidade;
        protected System.Windows.Forms.TextBox txtb_Cidade;
        protected System.Windows.Forms.Label lbl_CodigoCidade;
        protected System.Windows.Forms.TextBox txtb_CodigoCidade;
        protected System.Windows.Forms.Label lbl_Bairro;
        protected System.Windows.Forms.TextBox txtb_Bairro;
        protected System.Windows.Forms.Label lbl_Complemento;
        protected System.Windows.Forms.TextBox txtb_Complemento;
        protected System.Windows.Forms.Label lbl_Numero;
        protected System.Windows.Forms.TextBox txtb_Numero;
        protected System.Windows.Forms.Label lbl_Logradouro;
        protected System.Windows.Forms.TextBox txtb_Logradouro;
    }
}
