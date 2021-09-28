
namespace Projeto_ICI.frmCadastros
{
    partial class frmCadastroServicos
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
            this.lbl_Preco = new System.Windows.Forms.Label();
            this.txtb_Preco = new System.Windows.Forms.TextBox();
            this.lbl_Servico = new System.Windows.Forms.Label();
            this.txtb_Servico = new System.Windows.Forms.TextBox();
            this.lbl_Descricao = new System.Windows.Forms.Label();
            this.txtb_Descricao = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).BeginInit();
            this.SuspendLayout();
            // 
            // txtb_CodigoUsu
            // 
            this.txtb_CodigoUsu.Location = new System.Drawing.Point(17, 317);
            this.txtb_CodigoUsu.TabIndex = 7;
            // 
            // lbl_CodigoUsu
            // 
            this.lbl_CodigoUsu.Location = new System.Drawing.Point(14, 299);
            // 
            // btn_Sair
            // 
            this.btn_Sair.Location = new System.Drawing.Point(417, 312);
            this.btn_Sair.TabIndex = 5;
            // 
            // btn_Cadastro
            // 
            this.btn_Cadastro.Location = new System.Drawing.Point(345, 311);
            this.btn_Cadastro.TabIndex = 4;
            this.btn_Cadastro.Click += new System.EventHandler(this.btn_Cadastro_Click);
            // 
            // txtb_Codigo
            // 
            this.txtb_Codigo.TabIndex = 6;
            // 
            // lbl_UltAlt
            // 
            this.lbl_UltAlt.Location = new System.Drawing.Point(234, 298);
            // 
            // lbl_DataCad
            // 
            this.lbl_DataCad.Location = new System.Drawing.Point(119, 298);
            // 
            // txtb_DataCadastro
            // 
            this.txtb_DataCadastro.Location = new System.Drawing.Point(122, 317);
            this.txtb_DataCadastro.TabIndex = 8;
            // 
            // txtb_DataUltAlt
            // 
            this.txtb_DataUltAlt.Location = new System.Drawing.Point(237, 317);
            this.txtb_DataUltAlt.TabIndex = 9;
            // 
            // lbl_Preco
            // 
            this.lbl_Preco.AutoSize = true;
            this.lbl_Preco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Preco.Location = new System.Drawing.Point(271, 18);
            this.lbl_Preco.Name = "lbl_Preco";
            this.lbl_Preco.Size = new System.Drawing.Size(44, 15);
            this.lbl_Preco.TabIndex = 73;
            this.lbl_Preco.Text = "Preço*";
            // 
            // txtb_Preco
            // 
            this.txtb_Preco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Preco.Location = new System.Drawing.Point(274, 36);
            this.txtb_Preco.Name = "txtb_Preco";
            this.txtb_Preco.Size = new System.Drawing.Size(95, 20);
            this.txtb_Preco.TabIndex = 2;
            this.txtb_Preco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl_Servico
            // 
            this.lbl_Servico.AutoSize = true;
            this.lbl_Servico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Servico.Location = new System.Drawing.Point(96, 18);
            this.lbl_Servico.Name = "lbl_Servico";
            this.lbl_Servico.Size = new System.Drawing.Size(52, 15);
            this.lbl_Servico.TabIndex = 75;
            this.lbl_Servico.Text = "Serviço*";
            // 
            // txtb_Servico
            // 
            this.txtb_Servico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Servico.Location = new System.Drawing.Point(99, 36);
            this.txtb_Servico.Name = "txtb_Servico";
            this.txtb_Servico.Size = new System.Drawing.Size(169, 20);
            this.txtb_Servico.TabIndex = 1;
            this.txtb_Servico.Validating += new System.ComponentModel.CancelEventHandler(this.txtb_Servico_Validating);
            // 
            // lbl_Descricao
            // 
            this.lbl_Descricao.AutoSize = true;
            this.lbl_Descricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Descricao.Location = new System.Drawing.Point(21, 76);
            this.lbl_Descricao.Name = "lbl_Descricao";
            this.lbl_Descricao.Size = new System.Drawing.Size(62, 15);
            this.lbl_Descricao.TabIndex = 77;
            this.lbl_Descricao.Text = "Descrição";
            // 
            // txtb_Descricao
            // 
            this.txtb_Descricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Descricao.Location = new System.Drawing.Point(24, 94);
            this.txtb_Descricao.Multiline = true;
            this.txtb_Descricao.Name = "txtb_Descricao";
            this.txtb_Descricao.Size = new System.Drawing.Size(345, 96);
            this.txtb_Descricao.TabIndex = 3;
            // 
            // frmCadastroServicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(495, 350);
            this.Controls.Add(this.lbl_Descricao);
            this.Controls.Add(this.txtb_Descricao);
            this.Controls.Add(this.lbl_Servico);
            this.Controls.Add(this.txtb_Servico);
            this.Controls.Add(this.lbl_Preco);
            this.Controls.Add(this.txtb_Preco);
            this.Name = "frmCadastroServicos";
            this.Text = "Cadastro de Serviços";
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
            this.Controls.SetChildIndex(this.txtb_Preco, 0);
            this.Controls.SetChildIndex(this.lbl_Preco, 0);
            this.Controls.SetChildIndex(this.txtb_Servico, 0);
            this.Controls.SetChildIndex(this.lbl_Servico, 0);
            this.Controls.SetChildIndex(this.txtb_Descricao, 0);
            this.Controls.SetChildIndex(this.lbl_Descricao, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Preco;
        private System.Windows.Forms.TextBox txtb_Preco;
        private System.Windows.Forms.Label lbl_Servico;
        private System.Windows.Forms.TextBox txtb_Servico;
        private System.Windows.Forms.Label lbl_Descricao;
        private System.Windows.Forms.TextBox txtb_Descricao;
    }
}
