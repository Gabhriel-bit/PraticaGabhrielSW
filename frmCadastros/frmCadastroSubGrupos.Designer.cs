
namespace Projeto_ICI.frmCadastros
{
    partial class frmCadastroSubGrupos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastroSubGrupos));
            this.btn_Pesquisar = new System.Windows.Forms.Button();
            this.lbl_Grupo = new System.Windows.Forms.Label();
            this.txtb_Grupo = new System.Windows.Forms.TextBox();
            this.lbl_CodigoGrupo = new System.Windows.Forms.Label();
            this.txtb_CodigoGrupo = new System.Windows.Forms.TextBox();
            this.lbl_Subgrupo = new System.Windows.Forms.Label();
            this.txtb_Subgrupo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).BeginInit();
            this.SuspendLayout();
            // 
            // txtb_CodigoUsu
            // 
            this.txtb_CodigoUsu.Location = new System.Drawing.Point(24, 192);
            // 
            // lbl_CodigoUsu
            // 
            this.lbl_CodigoUsu.Location = new System.Drawing.Point(21, 174);
            // 
            // btn_Sair
            // 
            this.btn_Sair.Location = new System.Drawing.Point(467, 189);
            this.btn_Sair.TabIndex = 5;
            // 
            // btn_Cadastro
            // 
            this.btn_Cadastro.Location = new System.Drawing.Point(395, 188);
            this.btn_Cadastro.TabIndex = 4;
            this.btn_Cadastro.Click += new System.EventHandler(this.btn_Cadastro_Click);
            // 
            // lbl_UltAlt
            // 
            this.lbl_UltAlt.Location = new System.Drawing.Point(241, 173);
            // 
            // lbl_DataCad
            // 
            this.lbl_DataCad.Location = new System.Drawing.Point(126, 173);
            // 
            // txtb_DataCadastro
            // 
            this.txtb_DataCadastro.Location = new System.Drawing.Point(129, 191);
            // 
            // txtb_DataUltAlt
            // 
            this.txtb_DataUltAlt.Location = new System.Drawing.Point(244, 191);
            // 
            // btn_Pesquisar
            // 
            this.btn_Pesquisar.Location = new System.Drawing.Point(372, 99);
            this.btn_Pesquisar.Name = "btn_Pesquisar";
            this.btn_Pesquisar.Size = new System.Drawing.Size(63, 27);
            this.btn_Pesquisar.TabIndex = 3;
            this.btn_Pesquisar.Text = "Pesquisar";
            this.btn_Pesquisar.UseVisualStyleBackColor = true;
            this.btn_Pesquisar.Click += new System.EventHandler(this.btn_Pesquisar_Click);
            // 
            // lbl_Grupo
            // 
            this.lbl_Grupo.AutoSize = true;
            this.lbl_Grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Grupo.Location = new System.Drawing.Point(96, 86);
            this.lbl_Grupo.Name = "lbl_Grupo";
            this.lbl_Grupo.Size = new System.Drawing.Size(41, 15);
            this.lbl_Grupo.TabIndex = 20;
            this.lbl_Grupo.Text = "Grupo";
            // 
            // txtb_Grupo
            // 
            this.txtb_Grupo.Enabled = false;
            this.txtb_Grupo.Location = new System.Drawing.Point(99, 106);
            this.txtb_Grupo.Name = "txtb_Grupo";
            this.txtb_Grupo.Size = new System.Drawing.Size(267, 20);
            this.txtb_Grupo.TabIndex = 19;
            // 
            // lbl_CodigoGrupo
            // 
            this.lbl_CodigoGrupo.AutoSize = true;
            this.lbl_CodigoGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CodigoGrupo.Location = new System.Drawing.Point(21, 86);
            this.lbl_CodigoGrupo.Name = "lbl_CodigoGrupo";
            this.lbl_CodigoGrupo.Size = new System.Drawing.Size(61, 15);
            this.lbl_CodigoGrupo.TabIndex = 18;
            this.lbl_CodigoGrupo.Text = "Código G.";
            // 
            // txtb_CodigoGrupo
            // 
            this.txtb_CodigoGrupo.Location = new System.Drawing.Point(24, 106);
            this.txtb_CodigoGrupo.Name = "txtb_CodigoGrupo";
            this.txtb_CodigoGrupo.Size = new System.Drawing.Size(69, 20);
            this.txtb_CodigoGrupo.TabIndex = 2;
            this.txtb_CodigoGrupo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtb_CodigoGrupo.TextChanged += new System.EventHandler(this.txtb_CodigoGrupo_TextChanged);
            // 
            // lbl_Subgrupo
            // 
            this.lbl_Subgrupo.AutoSize = true;
            this.lbl_Subgrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Subgrupo.Location = new System.Drawing.Point(96, 16);
            this.lbl_Subgrupo.Name = "lbl_Subgrupo";
            this.lbl_Subgrupo.Size = new System.Drawing.Size(66, 15);
            this.lbl_Subgrupo.TabIndex = 23;
            this.lbl_Subgrupo.Text = "Subgrupo*";
            // 
            // txtb_Subgrupo
            // 
            this.txtb_Subgrupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Subgrupo.Location = new System.Drawing.Point(99, 36);
            this.txtb_Subgrupo.Name = "txtb_Subgrupo";
            this.txtb_Subgrupo.Size = new System.Drawing.Size(267, 20);
            this.txtb_Subgrupo.TabIndex = 1;
            this.txtb_Subgrupo.Validating += new System.ComponentModel.CancelEventHandler(this.txtb_Subgrupo_Validating);
            // 
            // frmCadastroSubGrupos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(545, 226);
            this.Controls.Add(this.lbl_Subgrupo);
            this.Controls.Add(this.txtb_Subgrupo);
            this.Controls.Add(this.btn_Pesquisar);
            this.Controls.Add(this.lbl_Grupo);
            this.Controls.Add(this.txtb_Grupo);
            this.Controls.Add(this.lbl_CodigoGrupo);
            this.Controls.Add(this.txtb_CodigoGrupo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCadastroSubGrupos";
            this.Text = "Cadastro de Sub-Grupos";
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
            this.Controls.SetChildIndex(this.txtb_CodigoGrupo, 0);
            this.Controls.SetChildIndex(this.lbl_CodigoGrupo, 0);
            this.Controls.SetChildIndex(this.txtb_Grupo, 0);
            this.Controls.SetChildIndex(this.lbl_Grupo, 0);
            this.Controls.SetChildIndex(this.btn_Pesquisar, 0);
            this.Controls.SetChildIndex(this.txtb_Subgrupo, 0);
            this.Controls.SetChildIndex(this.lbl_Subgrupo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Pesquisar;
        private System.Windows.Forms.Label lbl_Grupo;
        private System.Windows.Forms.TextBox txtb_Grupo;
        private System.Windows.Forms.Label lbl_CodigoGrupo;
        private System.Windows.Forms.TextBox txtb_CodigoGrupo;
        private System.Windows.Forms.Label lbl_Subgrupo;
        private System.Windows.Forms.TextBox txtb_Subgrupo;
    }
}
