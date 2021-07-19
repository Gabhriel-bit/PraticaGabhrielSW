
namespace Projeto_ICI.frmCadastros
{
    partial class frmCadastroEstados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastroEstados));
            this.txtb_Estado = new System.Windows.Forms.TextBox();
            this.lbl_Estado = new System.Windows.Forms.Label();
            this.lbl_UF = new System.Windows.Forms.Label();
            this.txtb_UF = new System.Windows.Forms.TextBox();
            this.lbl_CodigoPais = new System.Windows.Forms.Label();
            this.txtb_CodigoPais = new System.Windows.Forms.TextBox();
            this.lbl_Pais = new System.Windows.Forms.Label();
            this.txtb_Pais = new System.Windows.Forms.TextBox();
            this.btn_Pesquisar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).BeginInit();
            this.SuspendLayout();
            // 
            // txtb_CodigoUsu
            // 
            this.txtb_CodigoUsu.Location = new System.Drawing.Point(24, 218);
            // 
            // lbl_CodigoUsu
            // 
            this.lbl_CodigoUsu.Location = new System.Drawing.Point(21, 200);
            // 
            // btn_Sair
            // 
            this.btn_Sair.Location = new System.Drawing.Point(425, 214);
            this.btn_Sair.TabIndex = 6;
            // 
            // btn_Cadastro
            // 
            this.btn_Cadastro.Location = new System.Drawing.Point(353, 213);
            this.btn_Cadastro.TabIndex = 5;
            this.btn_Cadastro.Click += new System.EventHandler(this.btn_Cadastro_Click);
            // 
            // lbl_UltAlt
            // 
            this.lbl_UltAlt.Location = new System.Drawing.Point(241, 199);
            // 
            // lbl_DataCad
            // 
            this.lbl_DataCad.Location = new System.Drawing.Point(126, 199);
            // 
            // txtb_DataCadastro
            // 
            this.txtb_DataCadastro.Location = new System.Drawing.Point(129, 219);
            // 
            // txtb_DataUltAlt
            // 
            this.txtb_DataUltAlt.Location = new System.Drawing.Point(244, 219);
            // 
            // txtb_Estado
            // 
            this.txtb_Estado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Estado.Location = new System.Drawing.Point(99, 36);
            this.txtb_Estado.Name = "txtb_Estado";
            this.txtb_Estado.Size = new System.Drawing.Size(301, 20);
            this.txtb_Estado.TabIndex = 1;
            this.txtb_Estado.Validating += new System.ComponentModel.CancelEventHandler(this.txtb_Estado_Validating);
            // 
            // lbl_Estado
            // 
            this.lbl_Estado.AutoSize = true;
            this.lbl_Estado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Estado.Location = new System.Drawing.Point(96, 16);
            this.lbl_Estado.Name = "lbl_Estado";
            this.lbl_Estado.Size = new System.Drawing.Size(50, 15);
            this.lbl_Estado.TabIndex = 9;
            this.lbl_Estado.Text = "Estado*";
            // 
            // lbl_UF
            // 
            this.lbl_UF.AutoSize = true;
            this.lbl_UF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UF.Location = new System.Drawing.Point(403, 16);
            this.lbl_UF.Name = "lbl_UF";
            this.lbl_UF.Size = new System.Drawing.Size(23, 15);
            this.lbl_UF.TabIndex = 11;
            this.lbl_UF.Text = "UF";
            // 
            // txtb_UF
            // 
            this.txtb_UF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_UF.Location = new System.Drawing.Point(406, 36);
            this.txtb_UF.Name = "txtb_UF";
            this.txtb_UF.Size = new System.Drawing.Size(63, 20);
            this.txtb_UF.TabIndex = 2;
            // 
            // lbl_CodigoPais
            // 
            this.lbl_CodigoPais.AutoSize = true;
            this.lbl_CodigoPais.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CodigoPais.Location = new System.Drawing.Point(21, 82);
            this.lbl_CodigoPais.Name = "lbl_CodigoPais";
            this.lbl_CodigoPais.Size = new System.Drawing.Size(60, 15);
            this.lbl_CodigoPais.TabIndex = 13;
            this.lbl_CodigoPais.Text = "Código P.";
            // 
            // txtb_CodigoPais
            // 
            this.txtb_CodigoPais.Location = new System.Drawing.Point(24, 102);
            this.txtb_CodigoPais.Name = "txtb_CodigoPais";
            this.txtb_CodigoPais.Size = new System.Drawing.Size(69, 20);
            this.txtb_CodigoPais.TabIndex = 3;
            this.txtb_CodigoPais.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtb_CodigoPais.TextChanged += new System.EventHandler(this.txtb_CodigoPais_TextChanged);
            this.txtb_CodigoPais.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtb_CodigoPais_KeyPress);
            // 
            // lbl_Pais
            // 
            this.lbl_Pais.AutoSize = true;
            this.lbl_Pais.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Pais.Location = new System.Drawing.Point(96, 82);
            this.lbl_Pais.Name = "lbl_Pais";
            this.lbl_Pais.Size = new System.Drawing.Size(36, 15);
            this.lbl_Pais.TabIndex = 15;
            this.lbl_Pais.Text = "País*";
            // 
            // txtb_Pais
            // 
            this.txtb_Pais.Enabled = false;
            this.txtb_Pais.Location = new System.Drawing.Point(99, 102);
            this.txtb_Pais.Name = "txtb_Pais";
            this.txtb_Pais.Size = new System.Drawing.Size(301, 20);
            this.txtb_Pais.TabIndex = 14;
            // 
            // btn_Pesquisar
            // 
            this.btn_Pesquisar.Location = new System.Drawing.Point(406, 95);
            this.btn_Pesquisar.Name = "btn_Pesquisar";
            this.btn_Pesquisar.Size = new System.Drawing.Size(26, 25);
            this.btn_Pesquisar.TabIndex = 4;
            this.btn_Pesquisar.UseVisualStyleBackColor = true;
            this.btn_Pesquisar.Click += new System.EventHandler(this.btn_Pesquisar_Click);
            this.btn_Pesquisar.MouseEnter += new System.EventHandler(this.btn_Pesquisar_MouseEnter);
            this.btn_Pesquisar.MouseLeave += new System.EventHandler(this.btn_Pesquisar_MouseLeave);
            // 
            // frmCadastroEstados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(503, 251);
            this.Controls.Add(this.btn_Pesquisar);
            this.Controls.Add(this.lbl_Pais);
            this.Controls.Add(this.txtb_Pais);
            this.Controls.Add(this.lbl_CodigoPais);
            this.Controls.Add(this.txtb_CodigoPais);
            this.Controls.Add(this.lbl_UF);
            this.Controls.Add(this.txtb_UF);
            this.Controls.Add(this.lbl_Estado);
            this.Controls.Add(this.txtb_Estado);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCadastroEstados";
            this.Text = "Cadastro de Estados";
            this.Controls.SetChildIndex(this.lbl_CodigoUsu, 0);
            this.Controls.SetChildIndex(this.txtb_CodigoUsu, 0);
            this.Controls.SetChildIndex(this.lbl_Codigo, 0);
            this.Controls.SetChildIndex(this.lbl_DataCad, 0);
            this.Controls.SetChildIndex(this.lbl_UltAlt, 0);
            this.Controls.SetChildIndex(this.txtb_Codigo, 0);
            this.Controls.SetChildIndex(this.btn_Cadastro, 0);
            this.Controls.SetChildIndex(this.btn_Sair, 0);
            this.Controls.SetChildIndex(this.txtb_DataUltAlt, 0);
            this.Controls.SetChildIndex(this.txtb_DataCadastro, 0);
            this.Controls.SetChildIndex(this.txtb_Estado, 0);
            this.Controls.SetChildIndex(this.lbl_Estado, 0);
            this.Controls.SetChildIndex(this.txtb_UF, 0);
            this.Controls.SetChildIndex(this.lbl_UF, 0);
            this.Controls.SetChildIndex(this.txtb_CodigoPais, 0);
            this.Controls.SetChildIndex(this.lbl_CodigoPais, 0);
            this.Controls.SetChildIndex(this.txtb_Pais, 0);
            this.Controls.SetChildIndex(this.lbl_Pais, 0);
            this.Controls.SetChildIndex(this.btn_Pesquisar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtb_Estado;
        private System.Windows.Forms.Label lbl_Estado;
        private System.Windows.Forms.Label lbl_UF;
        private System.Windows.Forms.TextBox txtb_UF;
        private System.Windows.Forms.Label lbl_CodigoPais;
        private System.Windows.Forms.TextBox txtb_CodigoPais;
        private System.Windows.Forms.Label lbl_Pais;
        private System.Windows.Forms.TextBox txtb_Pais;
        private System.Windows.Forms.Button btn_Pesquisar;
    }
}
