
namespace Projeto_ICI.frmCadastros
{
    partial class frmCadastroGrupos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastroGrupos));
            this.txtb_Grupo = new System.Windows.Forms.TextBox();
            this.lbl_Grupo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).BeginInit();
            this.SuspendLayout();
            // 
            // txtb_CodigoUsu
            // 
            this.txtb_CodigoUsu.Location = new System.Drawing.Point(24, 233);
            // 
            // lbl_CodigoUsu
            // 
            this.lbl_CodigoUsu.Location = new System.Drawing.Point(21, 215);
            // 
            // btn_Sair
            // 
            this.btn_Sair.Location = new System.Drawing.Point(471, 230);
            // 
            // btn_Cadastro
            // 
            this.btn_Cadastro.Location = new System.Drawing.Point(399, 229);
            this.btn_Cadastro.Click += new System.EventHandler(this.btn_Cadastro_Click_1);
            // 
            // lbl_UltAlt
            // 
            this.lbl_UltAlt.Location = new System.Drawing.Point(241, 214);
            // 
            // lbl_DataCad
            // 
            this.lbl_DataCad.Location = new System.Drawing.Point(126, 214);
            // 
            // txtb_DataCadastro
            // 
            this.txtb_DataCadastro.Location = new System.Drawing.Point(129, 232);
            // 
            // txtb_DataUltAlt
            // 
            this.txtb_DataUltAlt.Location = new System.Drawing.Point(244, 232);
            // 
            // txtb_Grupo
            // 
            this.txtb_Grupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Grupo.Location = new System.Drawing.Point(114, 36);
            this.txtb_Grupo.Name = "txtb_Grupo";
            this.txtb_Grupo.Size = new System.Drawing.Size(215, 20);
            this.txtb_Grupo.TabIndex = 1;
            this.txtb_Grupo.Validating += new System.ComponentModel.CancelEventHandler(this.txtb_Grupo_Validating);
            // 
            // lbl_Grupo
            // 
            this.lbl_Grupo.AutoSize = true;
            this.lbl_Grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Grupo.Location = new System.Drawing.Point(111, 18);
            this.lbl_Grupo.Name = "lbl_Grupo";
            this.lbl_Grupo.Size = new System.Drawing.Size(46, 15);
            this.lbl_Grupo.TabIndex = 11;
            this.lbl_Grupo.Text = "Grupo*";
            // 
            // frmCadastroGrupos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(549, 267);
            this.Controls.Add(this.lbl_Grupo);
            this.Controls.Add(this.txtb_Grupo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCadastroGrupos";
            this.Text = "Cadastro de Grupos";
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
            this.Controls.SetChildIndex(this.txtb_Grupo, 0);
            this.Controls.SetChildIndex(this.lbl_Grupo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtb_Grupo;
        private System.Windows.Forms.Label lbl_Grupo;
    }
}
