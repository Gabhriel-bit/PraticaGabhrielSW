
namespace Projeto_ICI.frmCadastros
{
    partial class frmCadastroEquipamentos
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
            this.lbl_Equipamento = new System.Windows.Forms.Label();
            this.txtb_Equipamento = new System.Windows.Forms.TextBox();
            this.lbl_Volgatem = new System.Windows.Forms.Label();
            this.txtb_Voltagem = new System.Windows.Forms.TextBox();
            this.lbl_CodigoModelo = new System.Windows.Forms.Label();
            this.txtb_CodigoModelo = new System.Windows.Forms.TextBox();
            this.lbl_Modelo = new System.Windows.Forms.Label();
            this.txtb_Modelo = new System.Windows.Forms.TextBox();
            this.btn_Pesquisar = new System.Windows.Forms.Button();
            this.lbl_Marca = new System.Windows.Forms.Label();
            this.txtb_Marca = new System.Windows.Forms.TextBox();
            this.lbl_ObsTecnica = new System.Windows.Forms.Label();
            this.txtb_ObsTecnica = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).BeginInit();
            this.SuspendLayout();
            // 
            // txtb_CodigoUsu
            // 
            this.txtb_CodigoUsu.Location = new System.Drawing.Point(17, 326);
            // 
            // lbl_CodigoUsu
            // 
            this.lbl_CodigoUsu.Location = new System.Drawing.Point(14, 308);
            // 
            // btn_Sair
            // 
            this.btn_Sair.Location = new System.Drawing.Point(410, 321);
            // 
            // btn_Cadastro
            // 
            this.btn_Cadastro.Location = new System.Drawing.Point(338, 320);
            this.btn_Cadastro.Click += new System.EventHandler(this.btn_Cadastro_Click);
            // 
            // lbl_UltAlt
            // 
            this.lbl_UltAlt.Location = new System.Drawing.Point(234, 307);
            // 
            // lbl_DataCad
            // 
            this.lbl_DataCad.Location = new System.Drawing.Point(119, 307);
            // 
            // txtb_DataCadastro
            // 
            this.txtb_DataCadastro.Location = new System.Drawing.Point(122, 326);
            // 
            // txtb_DataUltAlt
            // 
            this.txtb_DataUltAlt.Location = new System.Drawing.Point(237, 326);
            // 
            // lbl_Equipamento
            // 
            this.lbl_Equipamento.AutoSize = true;
            this.lbl_Equipamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Equipamento.Location = new System.Drawing.Point(96, 18);
            this.lbl_Equipamento.Name = "lbl_Equipamento";
            this.lbl_Equipamento.Size = new System.Drawing.Size(86, 15);
            this.lbl_Equipamento.TabIndex = 73;
            this.lbl_Equipamento.Text = "Equipamento*";
            // 
            // txtb_Equipamento
            // 
            this.txtb_Equipamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Equipamento.Location = new System.Drawing.Point(99, 36);
            this.txtb_Equipamento.Name = "txtb_Equipamento";
            this.txtb_Equipamento.Size = new System.Drawing.Size(223, 20);
            this.txtb_Equipamento.TabIndex = 72;
            this.txtb_Equipamento.Validating += new System.ComponentModel.CancelEventHandler(this.txtb_Equipamento_Validating);
            // 
            // lbl_Volgatem
            // 
            this.lbl_Volgatem.AutoSize = true;
            this.lbl_Volgatem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Volgatem.Location = new System.Drawing.Point(325, 18);
            this.lbl_Volgatem.Name = "lbl_Volgatem";
            this.lbl_Volgatem.Size = new System.Drawing.Size(64, 15);
            this.lbl_Volgatem.TabIndex = 75;
            this.lbl_Volgatem.Text = "Voltagem*";
            // 
            // txtb_Voltagem
            // 
            this.txtb_Voltagem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Voltagem.Location = new System.Drawing.Point(328, 36);
            this.txtb_Voltagem.Name = "txtb_Voltagem";
            this.txtb_Voltagem.Size = new System.Drawing.Size(61, 20);
            this.txtb_Voltagem.TabIndex = 74;
            // 
            // lbl_CodigoModelo
            // 
            this.lbl_CodigoModelo.AutoSize = true;
            this.lbl_CodigoModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CodigoModelo.Location = new System.Drawing.Point(21, 86);
            this.lbl_CodigoModelo.Name = "lbl_CodigoModelo";
            this.lbl_CodigoModelo.Size = new System.Drawing.Size(65, 15);
            this.lbl_CodigoModelo.TabIndex = 77;
            this.lbl_CodigoModelo.Text = "Código M*";
            // 
            // txtb_CodigoModelo
            // 
            this.txtb_CodigoModelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_CodigoModelo.Location = new System.Drawing.Point(24, 104);
            this.txtb_CodigoModelo.Name = "txtb_CodigoModelo";
            this.txtb_CodigoModelo.Size = new System.Drawing.Size(69, 20);
            this.txtb_CodigoModelo.TabIndex = 76;
            this.txtb_CodigoModelo.TextChanged += new System.EventHandler(this.txtb_CodigoModelo_TextChanged);
            // 
            // lbl_Modelo
            // 
            this.lbl_Modelo.AutoSize = true;
            this.lbl_Modelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Modelo.Location = new System.Drawing.Point(96, 86);
            this.lbl_Modelo.Name = "lbl_Modelo";
            this.lbl_Modelo.Size = new System.Drawing.Size(54, 15);
            this.lbl_Modelo.TabIndex = 79;
            this.lbl_Modelo.Text = "Modelo*";
            // 
            // txtb_Modelo
            // 
            this.txtb_Modelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Modelo.Enabled = false;
            this.txtb_Modelo.Location = new System.Drawing.Point(99, 104);
            this.txtb_Modelo.Name = "txtb_Modelo";
            this.txtb_Modelo.Size = new System.Drawing.Size(167, 20);
            this.txtb_Modelo.TabIndex = 78;
            // 
            // btn_Pesquisar
            // 
            this.btn_Pesquisar.Location = new System.Drawing.Point(363, 99);
            this.btn_Pesquisar.Name = "btn_Pesquisar";
            this.btn_Pesquisar.Size = new System.Drawing.Size(26, 25);
            this.btn_Pesquisar.TabIndex = 80;
            this.btn_Pesquisar.UseVisualStyleBackColor = true;
            this.btn_Pesquisar.Click += new System.EventHandler(this.btn_Pesquisar_Click);
            this.btn_Pesquisar.MouseEnter += new System.EventHandler(this.btn_Pesquisar_MouseEnter);
            this.btn_Pesquisar.MouseLeave += new System.EventHandler(this.btn_Pesquisar_MouseLeave);
            // 
            // lbl_Marca
            // 
            this.lbl_Marca.AutoSize = true;
            this.lbl_Marca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Marca.Location = new System.Drawing.Point(269, 86);
            this.lbl_Marca.Name = "lbl_Marca";
            this.lbl_Marca.Size = new System.Drawing.Size(42, 15);
            this.lbl_Marca.TabIndex = 82;
            this.lbl_Marca.Text = "Marca";
            // 
            // txtb_Marca
            // 
            this.txtb_Marca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Marca.Enabled = false;
            this.txtb_Marca.Location = new System.Drawing.Point(272, 104);
            this.txtb_Marca.Name = "txtb_Marca";
            this.txtb_Marca.Size = new System.Drawing.Size(85, 20);
            this.txtb_Marca.TabIndex = 81;
            // 
            // lbl_ObsTecnica
            // 
            this.lbl_ObsTecnica.AutoSize = true;
            this.lbl_ObsTecnica.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ObsTecnica.Location = new System.Drawing.Point(21, 137);
            this.lbl_ObsTecnica.Name = "lbl_ObsTecnica";
            this.lbl_ObsTecnica.Size = new System.Drawing.Size(126, 15);
            this.lbl_ObsTecnica.TabIndex = 84;
            this.lbl_ObsTecnica.Text = "Observações tecnicas";
            // 
            // txtb_ObsTecnica
            // 
            this.txtb_ObsTecnica.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_ObsTecnica.Location = new System.Drawing.Point(24, 155);
            this.txtb_ObsTecnica.Multiline = true;
            this.txtb_ObsTecnica.Name = "txtb_ObsTecnica";
            this.txtb_ObsTecnica.Size = new System.Drawing.Size(365, 90);
            this.txtb_ObsTecnica.TabIndex = 83;
            // 
            // frmCadastroEquipamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(488, 359);
            this.Controls.Add(this.lbl_ObsTecnica);
            this.Controls.Add(this.txtb_ObsTecnica);
            this.Controls.Add(this.lbl_Marca);
            this.Controls.Add(this.txtb_Marca);
            this.Controls.Add(this.btn_Pesquisar);
            this.Controls.Add(this.lbl_Modelo);
            this.Controls.Add(this.txtb_Modelo);
            this.Controls.Add(this.lbl_CodigoModelo);
            this.Controls.Add(this.txtb_CodigoModelo);
            this.Controls.Add(this.lbl_Volgatem);
            this.Controls.Add(this.txtb_Voltagem);
            this.Controls.Add(this.lbl_Equipamento);
            this.Controls.Add(this.txtb_Equipamento);
            this.Name = "frmCadastroEquipamentos";
            this.Text = "Cadastro de Equipamentos";
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
            this.Controls.SetChildIndex(this.txtb_Equipamento, 0);
            this.Controls.SetChildIndex(this.lbl_Equipamento, 0);
            this.Controls.SetChildIndex(this.txtb_Voltagem, 0);
            this.Controls.SetChildIndex(this.lbl_Volgatem, 0);
            this.Controls.SetChildIndex(this.txtb_CodigoModelo, 0);
            this.Controls.SetChildIndex(this.lbl_CodigoModelo, 0);
            this.Controls.SetChildIndex(this.txtb_Modelo, 0);
            this.Controls.SetChildIndex(this.lbl_Modelo, 0);
            this.Controls.SetChildIndex(this.btn_Pesquisar, 0);
            this.Controls.SetChildIndex(this.txtb_Marca, 0);
            this.Controls.SetChildIndex(this.lbl_Marca, 0);
            this.Controls.SetChildIndex(this.txtb_ObsTecnica, 0);
            this.Controls.SetChildIndex(this.lbl_ObsTecnica, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Equipamento;
        private System.Windows.Forms.TextBox txtb_Equipamento;
        private System.Windows.Forms.Label lbl_Volgatem;
        private System.Windows.Forms.TextBox txtb_Voltagem;
        private System.Windows.Forms.Label lbl_CodigoModelo;
        private System.Windows.Forms.TextBox txtb_CodigoModelo;
        private System.Windows.Forms.Label lbl_Modelo;
        private System.Windows.Forms.TextBox txtb_Modelo;
        private System.Windows.Forms.Button btn_Pesquisar;
        private System.Windows.Forms.Label lbl_Marca;
        private System.Windows.Forms.TextBox txtb_Marca;
        private System.Windows.Forms.Label lbl_ObsTecnica;
        private System.Windows.Forms.TextBox txtb_ObsTecnica;
    }
}
