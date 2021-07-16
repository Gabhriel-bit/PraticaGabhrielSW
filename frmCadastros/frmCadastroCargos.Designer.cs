
namespace Projeto_ICI.frmCadastros
{
    partial class frmCadastroCargos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastroCargos));
            this.lbl_Cargo = new System.Windows.Forms.Label();
            this.txtb_Cargo = new System.Windows.Forms.TextBox();
            this.lbl_Descricao = new System.Windows.Forms.Label();
            this.txtb_Descricao = new System.Windows.Forms.TextBox();
            this.rb_Sim = new System.Windows.Forms.RadioButton();
            this.rb_Nao = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtb_CodigoUsu
            // 
            this.txtb_CodigoUsu.Location = new System.Drawing.Point(24, 248);
            // 
            // lbl_CodigoUsu
            // 
            this.lbl_CodigoUsu.Location = new System.Drawing.Point(21, 230);
            // 
            // btn_Sair
            // 
            this.btn_Sair.Location = new System.Drawing.Point(423, 245);
            this.btn_Sair.TabIndex = 9;
            // 
            // btn_Cadastro
            // 
            this.btn_Cadastro.Location = new System.Drawing.Point(351, 244);
            this.btn_Cadastro.TabIndex = 8;
            this.btn_Cadastro.Click += new System.EventHandler(this.btn_Cadastro_Click);
            // 
            // lbl_UltAlt
            // 
            this.lbl_UltAlt.Location = new System.Drawing.Point(241, 229);
            // 
            // lbl_DataCad
            // 
            this.lbl_DataCad.Location = new System.Drawing.Point(126, 229);
            // 
            // txtb_DataCadastro
            // 
            this.txtb_DataCadastro.Location = new System.Drawing.Point(129, 247);
            // 
            // txtb_DataUltAlt
            // 
            this.txtb_DataUltAlt.Location = new System.Drawing.Point(244, 247);
            // 
            // lbl_Cargo
            // 
            this.lbl_Cargo.AutoSize = true;
            this.lbl_Cargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Cargo.Location = new System.Drawing.Point(96, 18);
            this.lbl_Cargo.Name = "lbl_Cargo";
            this.lbl_Cargo.Size = new System.Drawing.Size(45, 15);
            this.lbl_Cargo.TabIndex = 43;
            this.lbl_Cargo.Text = "Cargo*";
            // 
            // txtb_Cargo
            // 
            this.txtb_Cargo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Cargo.Location = new System.Drawing.Point(99, 36);
            this.txtb_Cargo.Name = "txtb_Cargo";
            this.txtb_Cargo.Size = new System.Drawing.Size(279, 20);
            this.txtb_Cargo.TabIndex = 1;
            this.txtb_Cargo.Validating += new System.ComponentModel.CancelEventHandler(this.txtb_Cargo_Validating);
            // 
            // lbl_Descricao
            // 
            this.lbl_Descricao.AutoSize = true;
            this.lbl_Descricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Descricao.Location = new System.Drawing.Point(21, 68);
            this.lbl_Descricao.Name = "lbl_Descricao";
            this.lbl_Descricao.Size = new System.Drawing.Size(62, 15);
            this.lbl_Descricao.TabIndex = 47;
            this.lbl_Descricao.Text = "Descrição";
            // 
            // txtb_Descricao
            // 
            this.txtb_Descricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Descricao.Location = new System.Drawing.Point(24, 86);
            this.txtb_Descricao.Multiline = true;
            this.txtb_Descricao.Name = "txtb_Descricao";
            this.txtb_Descricao.Size = new System.Drawing.Size(354, 66);
            this.txtb_Descricao.TabIndex = 2;
            // 
            // rb_Sim
            // 
            this.rb_Sim.AutoSize = true;
            this.rb_Sim.Location = new System.Drawing.Point(0, 19);
            this.rb_Sim.Name = "rb_Sim";
            this.rb_Sim.Size = new System.Drawing.Size(44, 17);
            this.rb_Sim.TabIndex = 6;
            this.rb_Sim.TabStop = true;
            this.rb_Sim.Text = "SIM";
            this.rb_Sim.UseVisualStyleBackColor = true;
            // 
            // rb_Nao
            // 
            this.rb_Nao.AutoSize = true;
            this.rb_Nao.Location = new System.Drawing.Point(50, 18);
            this.rb_Nao.Name = "rb_Nao";
            this.rb_Nao.Size = new System.Drawing.Size(48, 17);
            this.rb_Nao.TabIndex = 7;
            this.rb_Nao.TabStop = true;
            this.rb_Nao.Text = "NÃO";
            this.rb_Nao.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_Nao);
            this.groupBox1.Controls.Add(this.rb_Sim);
            this.groupBox1.Location = new System.Drawing.Point(24, 169);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(98, 38);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CNH";
            // 
            // frmCadastroCargos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(501, 282);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_Descricao);
            this.Controls.Add(this.txtb_Descricao);
            this.Controls.Add(this.lbl_Cargo);
            this.Controls.Add(this.txtb_Cargo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCadastroCargos";
            this.Text = "Cadastro de Cargos";
            this.Controls.SetChildIndex(this.txtb_Cargo, 0);
            this.Controls.SetChildIndex(this.lbl_Cargo, 0);
            this.Controls.SetChildIndex(this.txtb_Descricao, 0);
            this.Controls.SetChildIndex(this.lbl_Descricao, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
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
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Cargo;
        private System.Windows.Forms.TextBox txtb_Cargo;
        private System.Windows.Forms.Label lbl_Descricao;
        private System.Windows.Forms.TextBox txtb_Descricao;
        private System.Windows.Forms.RadioButton rb_Sim;
        private System.Windows.Forms.RadioButton rb_Nao;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
