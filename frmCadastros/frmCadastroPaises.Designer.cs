
namespace Projeto_ICI.frmCadastros
{
    partial class frmCadastroPaises
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastroPaises));
            this.txtb_Pais = new System.Windows.Forms.TextBox();
            this.lbl_Pais = new System.Windows.Forms.Label();
            this.lbl_Moeda = new System.Windows.Forms.Label();
            this.txtb_Moeda = new System.Windows.Forms.TextBox();
            this.lbl_Sigla = new System.Windows.Forms.Label();
            this.txtb_Sigla = new System.Windows.Forms.TextBox();
            this.lbl_DDI = new System.Windows.Forms.Label();
            this.txtb_DDI = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).BeginInit();
            this.SuspendLayout();
            // 
            // txtb_CodigoUsu
            // 
            this.txtb_CodigoUsu.Location = new System.Drawing.Point(24, 134);
            // 
            // lbl_CodigoUsu
            // 
            this.lbl_CodigoUsu.Location = new System.Drawing.Point(21, 116);
            // 
            // date_Cadastro
            // 
            this.txtb_DataCadastro.Location = new System.Drawing.Point(129, 133);
            // 
            // date_UltAlt
            // 
            this.txtb_DataUltAlt.Location = new System.Drawing.Point(244, 133);
            // 
            // btn_Sair
            // 
            this.btn_Sair.Location = new System.Drawing.Point(479, 128);
            this.btn_Sair.TabIndex = 6;
            // 
            // btn_Cadastro
            // 
            this.btn_Cadastro.Location = new System.Drawing.Point(407, 127);
            this.btn_Cadastro.TabIndex = 5;
            this.btn_Cadastro.Click += new System.EventHandler(this.btn_Cadastro_Click);
            // 
            // lbl_UltAlt
            // 
            this.lbl_UltAlt.Location = new System.Drawing.Point(241, 115);
            // 
            // lbl_DataCad
            // 
            this.lbl_DataCad.Location = new System.Drawing.Point(126, 115);
            // 
            // lbl_Codigo
            // 
            this.lbl_Codigo.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Codigo.Size = new System.Drawing.Size(47, 16);
            // 
            // txtb_Pais
            // 
            this.txtb_Pais.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Pais.Location = new System.Drawing.Point(99, 36);
            this.txtb_Pais.Name = "txtb_Pais";
            this.txtb_Pais.Size = new System.Drawing.Size(248, 20);
            this.txtb_Pais.TabIndex = 1;
            this.txtb_Pais.Validating += new System.ComponentModel.CancelEventHandler(this.txtb_Pais_Validating);
            // 
            // lbl_Pais
            // 
            this.lbl_Pais.AutoSize = true;
            this.lbl_Pais.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Pais.Location = new System.Drawing.Point(96, 16);
            this.lbl_Pais.Name = "lbl_Pais";
            this.lbl_Pais.Size = new System.Drawing.Size(36, 15);
            this.lbl_Pais.TabIndex = 9;
            this.lbl_Pais.Text = "País*";
            // 
            // lbl_Moeda
            // 
            this.lbl_Moeda.AutoSize = true;
            this.lbl_Moeda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Moeda.Location = new System.Drawing.Point(350, 16);
            this.lbl_Moeda.Name = "lbl_Moeda";
            this.lbl_Moeda.Size = new System.Drawing.Size(46, 15);
            this.lbl_Moeda.TabIndex = 11;
            this.lbl_Moeda.Text = "Moeda";
            // 
            // txtb_Moeda
            // 
            this.txtb_Moeda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Moeda.Location = new System.Drawing.Point(353, 36);
            this.txtb_Moeda.Name = "txtb_Moeda";
            this.txtb_Moeda.Size = new System.Drawing.Size(59, 20);
            this.txtb_Moeda.TabIndex = 2;
            // 
            // lbl_Sigla
            // 
            this.lbl_Sigla.AutoSize = true;
            this.lbl_Sigla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Sigla.Location = new System.Drawing.Point(415, 16);
            this.lbl_Sigla.Name = "lbl_Sigla";
            this.lbl_Sigla.Size = new System.Drawing.Size(35, 15);
            this.lbl_Sigla.TabIndex = 13;
            this.lbl_Sigla.Text = "Sigla";
            // 
            // txtb_Sigla
            // 
            this.txtb_Sigla.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Sigla.Location = new System.Drawing.Point(418, 36);
            this.txtb_Sigla.Name = "txtb_Sigla";
            this.txtb_Sigla.Size = new System.Drawing.Size(59, 20);
            this.txtb_Sigla.TabIndex = 3;
            // 
            // lbl_DDI
            // 
            this.lbl_DDI.AutoSize = true;
            this.lbl_DDI.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DDI.Location = new System.Drawing.Point(480, 16);
            this.lbl_DDI.Name = "lbl_DDI";
            this.lbl_DDI.Size = new System.Drawing.Size(28, 15);
            this.lbl_DDI.TabIndex = 15;
            this.lbl_DDI.Text = "DDI";
            // 
            // txtb_DDI
            // 
            this.txtb_DDI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_DDI.Location = new System.Drawing.Point(483, 36);
            this.txtb_DDI.Name = "txtb_DDI";
            this.txtb_DDI.Size = new System.Drawing.Size(59, 20);
            this.txtb_DDI.TabIndex = 4;
            // 
            // frmCadastroPaises
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(557, 165);
            this.Controls.Add(this.lbl_DDI);
            this.Controls.Add(this.txtb_DDI);
            this.Controls.Add(this.lbl_Sigla);
            this.Controls.Add(this.txtb_Sigla);
            this.Controls.Add(this.lbl_Moeda);
            this.Controls.Add(this.txtb_Moeda);
            this.Controls.Add(this.lbl_Pais);
            this.Controls.Add(this.txtb_Pais);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCadastroPaises";
            this.Text = "Cadastro de Paises";
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
            this.Controls.SetChildIndex(this.txtb_Pais, 0);
            this.Controls.SetChildIndex(this.lbl_Pais, 0);
            this.Controls.SetChildIndex(this.txtb_Moeda, 0);
            this.Controls.SetChildIndex(this.lbl_Moeda, 0);
            this.Controls.SetChildIndex(this.txtb_Sigla, 0);
            this.Controls.SetChildIndex(this.lbl_Sigla, 0);
            this.Controls.SetChildIndex(this.txtb_DDI, 0);
            this.Controls.SetChildIndex(this.lbl_DDI, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtb_Pais;
        private System.Windows.Forms.Label lbl_Pais;
        private System.Windows.Forms.Label lbl_Moeda;
        private System.Windows.Forms.TextBox txtb_Moeda;
        private System.Windows.Forms.Label lbl_Sigla;
        private System.Windows.Forms.TextBox txtb_Sigla;
        private System.Windows.Forms.Label lbl_DDI;
        private System.Windows.Forms.TextBox txtb_DDI;
    }
}
