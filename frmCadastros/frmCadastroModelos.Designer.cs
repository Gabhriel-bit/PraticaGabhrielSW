
namespace Projeto_ICI.frmCadastros
{
    partial class frmCadastroModelos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastroModelos));
            this.txtb_Modelo = new System.Windows.Forms.TextBox();
            this.lbl_Modelo = new System.Windows.Forms.Label();
            this.lbl_Descrição = new System.Windows.Forms.Label();
            this.txtb_Descricao = new System.Windows.Forms.TextBox();
            this.btn_Pesquisar = new System.Windows.Forms.Button();
            this.lbl_Marca = new System.Windows.Forms.Label();
            this.txtb_Marca = new System.Windows.Forms.TextBox();
            this.lbl_CodigoMarca = new System.Windows.Forms.Label();
            this.txtb_CodigoMarca = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).BeginInit();
            this.SuspendLayout();
            // 
            // txtb_CodigoUsu
            // 
            this.txtb_CodigoUsu.Location = new System.Drawing.Point(24, 284);
            // 
            // lbl_CodigoUsu
            // 
            this.lbl_CodigoUsu.Location = new System.Drawing.Point(21, 266);
            // 
            // btn_Sair
            // 
            this.btn_Sair.Location = new System.Drawing.Point(426, 278);
            this.btn_Sair.TabIndex = 6;
            // 
            // btn_Cadastro
            // 
            this.btn_Cadastro.Location = new System.Drawing.Point(354, 277);
            this.btn_Cadastro.TabIndex = 5;
            this.btn_Cadastro.Click += new System.EventHandler(this.btn_Cadastro_Click);
            // 
            // lbl_UltAlt
            // 
            this.lbl_UltAlt.Location = new System.Drawing.Point(241, 265);
            // 
            // lbl_DataCad
            // 
            this.lbl_DataCad.Location = new System.Drawing.Point(126, 265);
            // 
            // txtb_DataCadastro
            // 
            this.txtb_DataCadastro.Location = new System.Drawing.Point(129, 283);
            // 
            // txtb_DataUltAlt
            // 
            this.txtb_DataUltAlt.Location = new System.Drawing.Point(244, 283);
            // 
            // txtb_Modelo
            // 
            this.txtb_Modelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Modelo.Location = new System.Drawing.Point(99, 36);
            this.txtb_Modelo.Name = "txtb_Modelo";
            this.txtb_Modelo.Size = new System.Drawing.Size(370, 20);
            this.txtb_Modelo.TabIndex = 1;
            this.txtb_Modelo.Validating += new System.ComponentModel.CancelEventHandler(this.txtb_Modelo_Validating);
            // 
            // lbl_Modelo
            // 
            this.lbl_Modelo.AutoSize = true;
            this.lbl_Modelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Modelo.Location = new System.Drawing.Point(96, 16);
            this.lbl_Modelo.Name = "lbl_Modelo";
            this.lbl_Modelo.Size = new System.Drawing.Size(54, 15);
            this.lbl_Modelo.TabIndex = 8;
            this.lbl_Modelo.Text = "Modelo*";
            // 
            // lbl_Descrição
            // 
            this.lbl_Descrição.AutoSize = true;
            this.lbl_Descrição.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Descrição.Location = new System.Drawing.Point(21, 72);
            this.lbl_Descrição.Name = "lbl_Descrição";
            this.lbl_Descrição.Size = new System.Drawing.Size(62, 15);
            this.lbl_Descrição.TabIndex = 10;
            this.lbl_Descrição.Text = "Descrição";
            // 
            // txtb_Descricao
            // 
            this.txtb_Descricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Descricao.Location = new System.Drawing.Point(24, 90);
            this.txtb_Descricao.MaxLength = 250;
            this.txtb_Descricao.Multiline = true;
            this.txtb_Descricao.Name = "txtb_Descricao";
            this.txtb_Descricao.Size = new System.Drawing.Size(445, 68);
            this.txtb_Descricao.TabIndex = 2;
            // 
            // btn_Pesquisar
            // 
            this.btn_Pesquisar.Location = new System.Drawing.Point(406, 174);
            this.btn_Pesquisar.Name = "btn_Pesquisar";
            this.btn_Pesquisar.Size = new System.Drawing.Size(63, 27);
            this.btn_Pesquisar.TabIndex = 4;
            this.btn_Pesquisar.Text = "Pesquisar";
            this.btn_Pesquisar.UseVisualStyleBackColor = true;
            this.btn_Pesquisar.Click += new System.EventHandler(this.btn_Pesquisar_Click);
            // 
            // lbl_Marca
            // 
            this.lbl_Marca.AutoSize = true;
            this.lbl_Marca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Marca.Location = new System.Drawing.Point(96, 161);
            this.lbl_Marca.Name = "lbl_Marca";
            this.lbl_Marca.Size = new System.Drawing.Size(42, 15);
            this.lbl_Marca.TabIndex = 20;
            this.lbl_Marca.Text = "Marca";
            // 
            // txtb_Marca
            // 
            this.txtb_Marca.Enabled = false;
            this.txtb_Marca.Location = new System.Drawing.Point(99, 181);
            this.txtb_Marca.Name = "txtb_Marca";
            this.txtb_Marca.Size = new System.Drawing.Size(301, 20);
            this.txtb_Marca.TabIndex = 19;
            // 
            // lbl_CodigoMarca
            // 
            this.lbl_CodigoMarca.AutoSize = true;
            this.lbl_CodigoMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CodigoMarca.Location = new System.Drawing.Point(21, 161);
            this.lbl_CodigoMarca.Name = "lbl_CodigoMarca";
            this.lbl_CodigoMarca.Size = new System.Drawing.Size(63, 15);
            this.lbl_CodigoMarca.TabIndex = 18;
            this.lbl_CodigoMarca.Text = "Código M.";
            // 
            // txtb_CodigoMarca
            // 
            this.txtb_CodigoMarca.Location = new System.Drawing.Point(24, 181);
            this.txtb_CodigoMarca.Name = "txtb_CodigoMarca";
            this.txtb_CodigoMarca.Size = new System.Drawing.Size(69, 20);
            this.txtb_CodigoMarca.TabIndex = 3;
            this.txtb_CodigoMarca.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtb_CodigoMarca.TextChanged += new System.EventHandler(this.txtb_CodigoMarca_TextChanged);
            // 
            // frmCadastroModelos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(504, 315);
            this.Controls.Add(this.btn_Pesquisar);
            this.Controls.Add(this.lbl_Marca);
            this.Controls.Add(this.txtb_Marca);
            this.Controls.Add(this.lbl_CodigoMarca);
            this.Controls.Add(this.txtb_CodigoMarca);
            this.Controls.Add(this.txtb_Descricao);
            this.Controls.Add(this.lbl_Descrição);
            this.Controls.Add(this.txtb_Modelo);
            this.Controls.Add(this.lbl_Modelo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCadastroModelos";
            this.Text = "Cadastro de Modelos";
            this.Controls.SetChildIndex(this.lbl_CodigoUsu, 0);
            this.Controls.SetChildIndex(this.txtb_CodigoUsu, 0);
            this.Controls.SetChildIndex(this.lbl_Modelo, 0);
            this.Controls.SetChildIndex(this.txtb_Modelo, 0);
            this.Controls.SetChildIndex(this.lbl_Descrição, 0);
            this.Controls.SetChildIndex(this.txtb_Descricao, 0);
            this.Controls.SetChildIndex(this.lbl_Codigo, 0);
            this.Controls.SetChildIndex(this.lbl_DataCad, 0);
            this.Controls.SetChildIndex(this.lbl_UltAlt, 0);
            this.Controls.SetChildIndex(this.txtb_Codigo, 0);
            this.Controls.SetChildIndex(this.btn_Cadastro, 0);
            this.Controls.SetChildIndex(this.btn_Sair, 0);
            this.Controls.SetChildIndex(this.txtb_DataUltAlt, 0);
            this.Controls.SetChildIndex(this.txtb_DataCadastro, 0);
            this.Controls.SetChildIndex(this.txtb_CodigoMarca, 0);
            this.Controls.SetChildIndex(this.lbl_CodigoMarca, 0);
            this.Controls.SetChildIndex(this.txtb_Marca, 0);
            this.Controls.SetChildIndex(this.lbl_Marca, 0);
            this.Controls.SetChildIndex(this.btn_Pesquisar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Pesquisar;
        private System.Windows.Forms.Label lbl_Marca;
        private System.Windows.Forms.TextBox txtb_Marca;
        private System.Windows.Forms.Label lbl_CodigoMarca;
        private System.Windows.Forms.TextBox txtb_CodigoMarca;
        private System.Windows.Forms.TextBox txtb_Modelo;
        private System.Windows.Forms.Label lbl_Modelo;
        private System.Windows.Forms.Label lbl_Descrição;
        private System.Windows.Forms.TextBox txtb_Descricao;
    }
}
