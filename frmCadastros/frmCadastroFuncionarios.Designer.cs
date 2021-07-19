
namespace Projeto_ICI.frmCadastros
{
    partial class frmCadastroFuncionarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastroFuncionarios));
            this.lbl_Funcionario = new System.Windows.Forms.Label();
            this.txtb_Funcionario = new System.Windows.Forms.TextBox();
            this.btn_PesquisarCargo = new System.Windows.Forms.Button();
            this.lbl_Cargo = new System.Windows.Forms.Label();
            this.txtb_Cargo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtb_CodigoCargo = new System.Windows.Forms.TextBox();
            this.lbl_CNH = new System.Windows.Forms.Label();
            this.txtb_CNH = new System.Windows.Forms.TextBox();
            this.date_DataVenc = new System.Windows.Forms.DateTimePicker();
            this.lbl_DataVenc = new System.Windows.Forms.Label();
            this.lbl_ComissaoVenda = new System.Windows.Forms.Label();
            this.txtb_ComissaoVenda = new System.Windows.Forms.TextBox();
            this.lbl_ComissaoProd = new System.Windows.Forms.Label();
            this.txtb_ComissaoProd = new System.Windows.Forms.TextBox();
            this.lbl_SalarioBase = new System.Windows.Forms.Label();
            this.txtb_SalarioBase = new System.Windows.Forms.TextBox();
            this.lbl_Comissoes = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).BeginInit();
            this.SuspendLayout();
            // 
            // date_DataNasc_Fund
            // 
            this.date_DataNasc_Fund.Size = new System.Drawing.Size(121, 20);
            this.date_DataNasc_Fund.TabIndex = 13;
            this.date_DataNasc_Fund.Validating += new System.ComponentModel.CancelEventHandler(this.date_DataNasc_Fund_Validating);
            // 
            // lbl_DataNasc_Fund
            // 
            this.lbl_DataNasc_Fund.Size = new System.Drawing.Size(105, 15);
            this.lbl_DataNasc_Fund.Text = "Data nascimento*";
            // 
            // txtb_CPF_CNPJ
            // 
            this.txtb_CPF_CNPJ.TabIndex = 11;
            // 
            // txtb_RG_InscEstadual
            // 
            this.txtb_RG_InscEstadual.TabIndex = 12;
            // 
            // txtb_Email
            // 
            this.txtb_Email.TabIndex = 10;
            // 
            // txtb_telCelular
            // 
            this.txtb_telCelular.TabIndex = 9;
            // 
            // txtb_CEP
            // 
            this.txtb_CEP.TabIndex = 6;
            // 
            // btn_PesquisarCidade
            // 
            this.btn_PesquisarCidade.TabIndex = 8;
            // 
            // txtb_CodigoCidade
            // 
            this.txtb_CodigoCidade.TabIndex = 7;
            // 
            // txtb_Bairro
            // 
            this.txtb_Bairro.TabIndex = 5;
            // 
            // txtb_Complemento
            // 
            this.txtb_Complemento.TabIndex = 4;
            // 
            // txtb_Numero
            // 
            this.txtb_Numero.TabIndex = 3;
            // 
            // txtb_Logradouro
            // 
            this.txtb_Logradouro.TabIndex = 2;
            // 
            // txtb_CodigoUsu
            // 
            this.txtb_CodigoUsu.Location = new System.Drawing.Point(24, 465);
            // 
            // lbl_CodigoUsu
            // 
            this.lbl_CodigoUsu.Location = new System.Drawing.Point(21, 447);
            // 
            // btn_Sair
            // 
            this.btn_Sair.Location = new System.Drawing.Point(546, 462);
            this.btn_Sair.TabIndex = 22;
            // 
            // btn_Cadastro
            // 
            this.btn_Cadastro.Location = new System.Drawing.Point(474, 461);
            this.btn_Cadastro.TabIndex = 21;
            this.btn_Cadastro.Click += new System.EventHandler(this.btn_Cadastro_Click);
            // 
            // lbl_UltAlt
            // 
            this.lbl_UltAlt.Location = new System.Drawing.Point(241, 446);
            // 
            // lbl_DataCad
            // 
            this.lbl_DataCad.Location = new System.Drawing.Point(126, 446);
            // 
            // txtb_DataCadastro
            // 
            this.txtb_DataCadastro.Location = new System.Drawing.Point(129, 464);
            // 
            // txtb_DataUltAlt
            // 
            this.txtb_DataUltAlt.Location = new System.Drawing.Point(244, 464);
            // 
            // lbl_Funcionario
            // 
            this.lbl_Funcionario.AutoSize = true;
            this.lbl_Funcionario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Funcionario.Location = new System.Drawing.Point(96, 18);
            this.lbl_Funcionario.Name = "lbl_Funcionario";
            this.lbl_Funcionario.Size = new System.Drawing.Size(77, 15);
            this.lbl_Funcionario.TabIndex = 41;
            this.lbl_Funcionario.Text = "Funcionário*";
            // 
            // txtb_Funcionario
            // 
            this.txtb_Funcionario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Funcionario.Location = new System.Drawing.Point(99, 36);
            this.txtb_Funcionario.Name = "txtb_Funcionario";
            this.txtb_Funcionario.Size = new System.Drawing.Size(343, 20);
            this.txtb_Funcionario.TabIndex = 1;
            this.txtb_Funcionario.Validating += new System.ComponentModel.CancelEventHandler(this.txtb_Funcionario_Validating);
            // 
            // btn_PesquisarCargo
            // 
            this.btn_PesquisarCargo.Location = new System.Drawing.Point(225, 378);
            this.btn_PesquisarCargo.Name = "btn_PesquisarCargo";
            this.btn_PesquisarCargo.Size = new System.Drawing.Size(26, 25);
            this.btn_PesquisarCargo.TabIndex = 18;
            this.btn_PesquisarCargo.UseVisualStyleBackColor = true;
            this.btn_PesquisarCargo.Click += new System.EventHandler(this.btn_PesquisarCargo_Click);
            this.btn_PesquisarCargo.MouseEnter += new System.EventHandler(this.btn_PesquisarCargo_MouseEnter);
            this.btn_PesquisarCargo.MouseLeave += new System.EventHandler(this.btn_PesquisarCargo_MouseLeave);
            // 
            // lbl_Cargo
            // 
            this.lbl_Cargo.AutoSize = true;
            this.lbl_Cargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Cargo.Location = new System.Drawing.Point(96, 367);
            this.lbl_Cargo.Name = "lbl_Cargo";
            this.lbl_Cargo.Size = new System.Drawing.Size(45, 15);
            this.lbl_Cargo.TabIndex = 68;
            this.lbl_Cargo.Text = "Cargo*";
            // 
            // txtb_Cargo
            // 
            this.txtb_Cargo.Enabled = false;
            this.txtb_Cargo.Location = new System.Drawing.Point(99, 385);
            this.txtb_Cargo.Name = "txtb_Cargo";
            this.txtb_Cargo.Size = new System.Drawing.Size(120, 20);
            this.txtb_Cargo.TabIndex = 67;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 367);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 66;
            this.label2.Text = "Código C.";
            // 
            // txtb_CodigoCargo
            // 
            this.txtb_CodigoCargo.Location = new System.Drawing.Point(24, 385);
            this.txtb_CodigoCargo.Name = "txtb_CodigoCargo";
            this.txtb_CodigoCargo.Size = new System.Drawing.Size(69, 20);
            this.txtb_CodigoCargo.TabIndex = 17;
            this.txtb_CodigoCargo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtb_CodigoCargo.TextChanged += new System.EventHandler(this.txtb_CodigoCargo_TextChanged);
            // 
            // lbl_CNH
            // 
            this.lbl_CNH.AutoSize = true;
            this.lbl_CNH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CNH.Location = new System.Drawing.Point(254, 367);
            this.lbl_CNH.Name = "lbl_CNH";
            this.lbl_CNH.Size = new System.Drawing.Size(36, 15);
            this.lbl_CNH.TabIndex = 71;
            this.lbl_CNH.Text = "CNH ";
            // 
            // txtb_CNH
            // 
            this.txtb_CNH.Location = new System.Drawing.Point(257, 385);
            this.txtb_CNH.Name = "txtb_CNH";
            this.txtb_CNH.Size = new System.Drawing.Size(137, 20);
            this.txtb_CNH.TabIndex = 19;
            // 
            // date_DataVenc
            // 
            this.date_DataVenc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_DataVenc.Location = new System.Drawing.Point(400, 385);
            this.date_DataVenc.Name = "date_DataVenc";
            this.date_DataVenc.Size = new System.Drawing.Size(105, 20);
            this.date_DataVenc.TabIndex = 20;
            // 
            // lbl_DataVenc
            // 
            this.lbl_DataVenc.AutoSize = true;
            this.lbl_DataVenc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DataVenc.Location = new System.Drawing.Point(397, 367);
            this.lbl_DataVenc.Name = "lbl_DataVenc";
            this.lbl_DataVenc.Size = new System.Drawing.Size(99, 15);
            this.lbl_DataVenc.TabIndex = 72;
            this.lbl_DataVenc.Text = "Data vencimento";
            // 
            // lbl_ComissaoVenda
            // 
            this.lbl_ComissaoVenda.AutoSize = true;
            this.lbl_ComissaoVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ComissaoVenda.Location = new System.Drawing.Point(220, 307);
            this.lbl_ComissaoVenda.Name = "lbl_ComissaoVenda";
            this.lbl_ComissaoVenda.Size = new System.Drawing.Size(47, 15);
            this.lbl_ComissaoVenda.TabIndex = 78;
            this.lbl_ComissaoVenda.Text = "Venda*";
            // 
            // txtb_ComissaoVenda
            // 
            this.txtb_ComissaoVenda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_ComissaoVenda.Location = new System.Drawing.Point(223, 325);
            this.txtb_ComissaoVenda.Name = "txtb_ComissaoVenda";
            this.txtb_ComissaoVenda.Size = new System.Drawing.Size(81, 20);
            this.txtb_ComissaoVenda.TabIndex = 16;
            this.txtb_ComissaoVenda.Tag = "";
            this.txtb_ComissaoVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtb_ComissaoVenda.Validating += new System.ComponentModel.CancelEventHandler(this.txtb_ComissaoVenda_Validating);
            // 
            // lbl_ComissaoProd
            // 
            this.lbl_ComissaoProd.AutoSize = true;
            this.lbl_ComissaoProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ComissaoProd.Location = new System.Drawing.Point(135, 307);
            this.lbl_ComissaoProd.Name = "lbl_ComissaoProd";
            this.lbl_ComissaoProd.Size = new System.Drawing.Size(55, 15);
            this.lbl_ComissaoProd.TabIndex = 77;
            this.lbl_ComissaoProd.Text = "Produto*";
            // 
            // txtb_ComissaoProd
            // 
            this.txtb_ComissaoProd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_ComissaoProd.Location = new System.Drawing.Point(138, 325);
            this.txtb_ComissaoProd.Name = "txtb_ComissaoProd";
            this.txtb_ComissaoProd.Size = new System.Drawing.Size(81, 20);
            this.txtb_ComissaoProd.TabIndex = 15;
            this.txtb_ComissaoProd.Tag = "";
            this.txtb_ComissaoProd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtb_ComissaoProd.Validating += new System.ComponentModel.CancelEventHandler(this.txtb_ComissaoProd_Validating);
            // 
            // lbl_SalarioBase
            // 
            this.lbl_SalarioBase.AutoSize = true;
            this.lbl_SalarioBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SalarioBase.Location = new System.Drawing.Point(21, 307);
            this.lbl_SalarioBase.Name = "lbl_SalarioBase";
            this.lbl_SalarioBase.Size = new System.Drawing.Size(81, 15);
            this.lbl_SalarioBase.TabIndex = 76;
            this.lbl_SalarioBase.Text = "Salário base*";
            // 
            // txtb_SalarioBase
            // 
            this.txtb_SalarioBase.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_SalarioBase.Location = new System.Drawing.Point(24, 325);
            this.txtb_SalarioBase.Name = "txtb_SalarioBase";
            this.txtb_SalarioBase.Size = new System.Drawing.Size(108, 20);
            this.txtb_SalarioBase.TabIndex = 14;
            this.txtb_SalarioBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtb_SalarioBase.Validating += new System.ComponentModel.CancelEventHandler(this.txtb_SalarioBase_Validating);
            // 
            // lbl_Comissoes
            // 
            this.lbl_Comissoes.AutoSize = true;
            this.lbl_Comissoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Comissoes.Location = new System.Drawing.Point(135, 292);
            this.lbl_Comissoes.Name = "lbl_Comissoes";
            this.lbl_Comissoes.Size = new System.Drawing.Size(71, 15);
            this.lbl_Comissoes.TabIndex = 79;
            this.lbl_Comissoes.Text = "Comissões:";
            // 
            // frmCadastroFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(624, 499);
            this.Controls.Add(this.lbl_Comissoes);
            this.Controls.Add(this.lbl_ComissaoVenda);
            this.Controls.Add(this.txtb_ComissaoVenda);
            this.Controls.Add(this.lbl_ComissaoProd);
            this.Controls.Add(this.txtb_ComissaoProd);
            this.Controls.Add(this.lbl_SalarioBase);
            this.Controls.Add(this.txtb_SalarioBase);
            this.Controls.Add(this.date_DataVenc);
            this.Controls.Add(this.lbl_DataVenc);
            this.Controls.Add(this.lbl_CNH);
            this.Controls.Add(this.txtb_CNH);
            this.Controls.Add(this.btn_PesquisarCargo);
            this.Controls.Add(this.lbl_Cargo);
            this.Controls.Add(this.txtb_Cargo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtb_CodigoCargo);
            this.Controls.Add(this.lbl_Funcionario);
            this.Controls.Add(this.txtb_Funcionario);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCadastroFuncionario";
            this.Text = "Cadastro de Funcionários";
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
            this.Controls.SetChildIndex(this.txtb_Funcionario, 0);
            this.Controls.SetChildIndex(this.lbl_Funcionario, 0);
            this.Controls.SetChildIndex(this.txtb_CodigoCargo, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtb_Cargo, 0);
            this.Controls.SetChildIndex(this.lbl_Cargo, 0);
            this.Controls.SetChildIndex(this.btn_PesquisarCargo, 0);
            this.Controls.SetChildIndex(this.txtb_CNH, 0);
            this.Controls.SetChildIndex(this.lbl_CNH, 0);
            this.Controls.SetChildIndex(this.lbl_DataVenc, 0);
            this.Controls.SetChildIndex(this.date_DataVenc, 0);
            this.Controls.SetChildIndex(this.txtb_SalarioBase, 0);
            this.Controls.SetChildIndex(this.lbl_SalarioBase, 0);
            this.Controls.SetChildIndex(this.txtb_ComissaoProd, 0);
            this.Controls.SetChildIndex(this.lbl_ComissaoProd, 0);
            this.Controls.SetChildIndex(this.txtb_ComissaoVenda, 0);
            this.Controls.SetChildIndex(this.lbl_ComissaoVenda, 0);
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
            this.Controls.SetChildIndex(this.lbl_Comissoes, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_Funcionario;
        private System.Windows.Forms.TextBox txtb_Funcionario;
        private System.Windows.Forms.Button btn_PesquisarCargo;
        private System.Windows.Forms.Label lbl_Cargo;
        private System.Windows.Forms.TextBox txtb_Cargo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtb_CodigoCargo;
        private System.Windows.Forms.Label lbl_CNH;
        private System.Windows.Forms.TextBox txtb_CNH;
        private System.Windows.Forms.DateTimePicker date_DataVenc;
        private System.Windows.Forms.Label lbl_DataVenc;
        private System.Windows.Forms.Label lbl_ComissaoVenda;
        private System.Windows.Forms.TextBox txtb_ComissaoVenda;
        private System.Windows.Forms.Label lbl_ComissaoProd;
        private System.Windows.Forms.TextBox txtb_ComissaoProd;
        private System.Windows.Forms.Label lbl_SalarioBase;
        private System.Windows.Forms.TextBox txtb_SalarioBase;
        private System.Windows.Forms.Label lbl_Comissoes;
    }
}
