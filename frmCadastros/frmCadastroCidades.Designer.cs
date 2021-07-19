
namespace Projeto_ICI.frmCadastros
{
    partial class frmCadastroCidades
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastroCidades));
            this.btn_Pesquisar = new System.Windows.Forms.Button();
            this.lbl_Estado = new System.Windows.Forms.Label();
            this.txtb_Estado = new System.Windows.Forms.TextBox();
            this.lbl_CodigoEstado = new System.Windows.Forms.Label();
            this.txtb_CodigoEstado = new System.Windows.Forms.TextBox();
            this.lbl_DDD = new System.Windows.Forms.Label();
            this.txtb_DDD = new System.Windows.Forms.TextBox();
            this.lbl_Cidade = new System.Windows.Forms.Label();
            this.txtb_Cidade = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).BeginInit();
            this.SuspendLayout();
            // 
            // txtb_CodigoUsu
            // 
            this.txtb_CodigoUsu.Location = new System.Drawing.Point(24, 208);
            // 
            // lbl_CodigoUsu
            // 
            this.lbl_CodigoUsu.Location = new System.Drawing.Point(21, 190);
            // 
            // btn_Sair
            // 
            this.btn_Sair.Location = new System.Drawing.Point(433, 202);
            this.btn_Sair.TabIndex = 6;
            // 
            // btn_Cadastro
            // 
            this.btn_Cadastro.Location = new System.Drawing.Point(361, 201);
            this.btn_Cadastro.TabIndex = 5;
            this.btn_Cadastro.Click += new System.EventHandler(this.btn_Cadastro_Click);
            // 
            // lbl_UltAlt
            // 
            this.lbl_UltAlt.Location = new System.Drawing.Point(241, 189);
            // 
            // lbl_DataCad
            // 
            this.lbl_DataCad.Location = new System.Drawing.Point(126, 189);
            // 
            // txtb_DataCadastro
            // 
            this.txtb_DataCadastro.Location = new System.Drawing.Point(129, 207);
            // 
            // txtb_DataUltAlt
            // 
            this.txtb_DataUltAlt.Location = new System.Drawing.Point(244, 207);
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
            // lbl_Estado
            // 
            this.lbl_Estado.AutoSize = true;
            this.lbl_Estado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Estado.Location = new System.Drawing.Point(96, 82);
            this.lbl_Estado.Name = "lbl_Estado";
            this.lbl_Estado.Size = new System.Drawing.Size(45, 15);
            this.lbl_Estado.TabIndex = 24;
            this.lbl_Estado.Text = "Estado";
            // 
            // txtb_Estado
            // 
            this.txtb_Estado.Enabled = false;
            this.txtb_Estado.Location = new System.Drawing.Point(99, 102);
            this.txtb_Estado.Name = "txtb_Estado";
            this.txtb_Estado.Size = new System.Drawing.Size(301, 20);
            this.txtb_Estado.TabIndex = 23;
            // 
            // lbl_CodigoEstado
            // 
            this.lbl_CodigoEstado.AutoSize = true;
            this.lbl_CodigoEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CodigoEstado.Location = new System.Drawing.Point(21, 82);
            this.lbl_CodigoEstado.Name = "lbl_CodigoEstado";
            this.lbl_CodigoEstado.Size = new System.Drawing.Size(60, 15);
            this.lbl_CodigoEstado.TabIndex = 22;
            this.lbl_CodigoEstado.Text = "Código E.";
            // 
            // txtb_CodigoEstado
            // 
            this.txtb_CodigoEstado.Location = new System.Drawing.Point(24, 102);
            this.txtb_CodigoEstado.Name = "txtb_CodigoEstado";
            this.txtb_CodigoEstado.Size = new System.Drawing.Size(69, 20);
            this.txtb_CodigoEstado.TabIndex = 3;
            this.txtb_CodigoEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtb_CodigoEstado.TextChanged += new System.EventHandler(this.txtb_CodigoEstado_TextChanged);
            this.txtb_CodigoEstado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtb_CodigoEstado_KeyPress);
            // 
            // lbl_DDD
            // 
            this.lbl_DDD.AutoSize = true;
            this.lbl_DDD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DDD.Location = new System.Drawing.Point(403, 16);
            this.lbl_DDD.Name = "lbl_DDD";
            this.lbl_DDD.Size = new System.Drawing.Size(34, 15);
            this.lbl_DDD.TabIndex = 20;
            this.lbl_DDD.Text = "DDD";
            // 
            // txtb_DDD
            // 
            this.txtb_DDD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_DDD.Location = new System.Drawing.Point(406, 36);
            this.txtb_DDD.Name = "txtb_DDD";
            this.txtb_DDD.Size = new System.Drawing.Size(63, 20);
            this.txtb_DDD.TabIndex = 2;
            // 
            // lbl_Cidade
            // 
            this.lbl_Cidade.AutoSize = true;
            this.lbl_Cidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Cidade.Location = new System.Drawing.Point(96, 16);
            this.lbl_Cidade.Name = "lbl_Cidade";
            this.lbl_Cidade.Size = new System.Drawing.Size(51, 15);
            this.lbl_Cidade.TabIndex = 18;
            this.lbl_Cidade.Text = "Cidade*";
            // 
            // txtb_Cidade
            // 
            this.txtb_Cidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Cidade.Location = new System.Drawing.Point(99, 36);
            this.txtb_Cidade.Name = "txtb_Cidade";
            this.txtb_Cidade.Size = new System.Drawing.Size(301, 20);
            this.txtb_Cidade.TabIndex = 1;
            this.txtb_Cidade.Validating += new System.ComponentModel.CancelEventHandler(this.txtb_Cidade_Validating);
            // 
            // frmCadastroCidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(511, 239);
            this.Controls.Add(this.btn_Pesquisar);
            this.Controls.Add(this.lbl_Estado);
            this.Controls.Add(this.txtb_Estado);
            this.Controls.Add(this.lbl_CodigoEstado);
            this.Controls.Add(this.txtb_CodigoEstado);
            this.Controls.Add(this.lbl_DDD);
            this.Controls.Add(this.txtb_DDD);
            this.Controls.Add(this.lbl_Cidade);
            this.Controls.Add(this.txtb_Cidade);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCadastroCidades";
            this.Text = "Cadastro de Cidades";
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
            this.Controls.SetChildIndex(this.txtb_Cidade, 0);
            this.Controls.SetChildIndex(this.lbl_Cidade, 0);
            this.Controls.SetChildIndex(this.txtb_DDD, 0);
            this.Controls.SetChildIndex(this.lbl_DDD, 0);
            this.Controls.SetChildIndex(this.txtb_CodigoEstado, 0);
            this.Controls.SetChildIndex(this.lbl_CodigoEstado, 0);
            this.Controls.SetChildIndex(this.txtb_Estado, 0);
            this.Controls.SetChildIndex(this.lbl_Estado, 0);
            this.Controls.SetChildIndex(this.btn_Pesquisar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Pesquisar;
        private System.Windows.Forms.Label lbl_Estado;
        private System.Windows.Forms.TextBox txtb_Estado;
        private System.Windows.Forms.Label lbl_CodigoEstado;
        private System.Windows.Forms.TextBox txtb_CodigoEstado;
        private System.Windows.Forms.Label lbl_DDD;
        private System.Windows.Forms.TextBox txtb_DDD;
        private System.Windows.Forms.Label lbl_Cidade;
        private System.Windows.Forms.TextBox txtb_Cidade;
    }
}
