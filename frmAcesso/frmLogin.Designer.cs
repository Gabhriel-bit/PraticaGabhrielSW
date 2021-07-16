
namespace Projeto_ICI.frmAcesso
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtb_Usuario = new System.Windows.Forms.TextBox();
            this.txtb_Senha = new System.Windows.Forms.TextBox();
            this.btn_Conectar = new System.Windows.Forms.Button();
            this.btn_Sair = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuário";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Senha";
            // 
            // txtb_Usuario
            // 
            this.txtb_Usuario.Location = new System.Drawing.Point(25, 41);
            this.txtb_Usuario.Name = "txtb_Usuario";
            this.txtb_Usuario.Size = new System.Drawing.Size(165, 20);
            this.txtb_Usuario.TabIndex = 2;
            // 
            // txtb_Senha
            // 
            this.txtb_Senha.Location = new System.Drawing.Point(25, 97);
            this.txtb_Senha.Name = "txtb_Senha";
            this.txtb_Senha.Size = new System.Drawing.Size(165, 20);
            this.txtb_Senha.TabIndex = 3;
            this.txtb_Senha.UseSystemPasswordChar = true;
            // 
            // btn_Conectar
            // 
            this.btn_Conectar.Location = new System.Drawing.Point(25, 141);
            this.btn_Conectar.Name = "btn_Conectar";
            this.btn_Conectar.Size = new System.Drawing.Size(62, 23);
            this.btn_Conectar.TabIndex = 4;
            this.btn_Conectar.Text = "&Conectar";
            this.btn_Conectar.UseVisualStyleBackColor = true;
            this.btn_Conectar.Click += new System.EventHandler(this.btn_Conectar_Click);
            // 
            // btn_Sair
            // 
            this.btn_Sair.Location = new System.Drawing.Point(128, 141);
            this.btn_Sair.Name = "btn_Sair";
            this.btn_Sair.Size = new System.Drawing.Size(62, 23);
            this.btn_Sair.TabIndex = 5;
            this.btn_Sair.Text = "&Sair";
            this.btn_Sair.UseVisualStyleBackColor = true;
            this.btn_Sair.Click += new System.EventHandler(this.btn_Sair_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(219, 196);
            this.Controls.Add(this.btn_Sair);
            this.Controls.Add(this.btn_Conectar);
            this.Controls.Add(this.txtb_Senha);
            this.Controls.Add(this.txtb_Usuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLogin";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtb_Usuario;
        private System.Windows.Forms.TextBox txtb_Senha;
        private System.Windows.Forms.Button btn_Conectar;
        private System.Windows.Forms.Button btn_Sair;
    }
}
