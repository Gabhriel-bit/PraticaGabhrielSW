
namespace Projeto_ICI.API
{
    partial class frmIntegracaoMagento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIntegracaoMagento));
            this.btn_Remover = new System.Windows.Forms.Button();
            this.btn_Adicionar = new System.Windows.Forms.Button();
            this.btn_PesquisarProduto = new System.Windows.Forms.Button();
            this.lbl_Produto = new System.Windows.Forms.Label();
            this.txtb_Produto = new System.Windows.Forms.TextBox();
            this.lbl_CodigoProduto = new System.Windows.Forms.Label();
            this.txtb_CodigoProduto = new System.Windows.Forms.TextBox();
            this.lv_Produtos = new System.Windows.Forms.ListView();
            this.ch_Produto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Custo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_PesoLiq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Saldo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Codigo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_SimEstoq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_SimVisivel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_Visivel = new System.Windows.Forms.CheckBox();
            this.cb_Estoque = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lv_MagentoProd = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_Remove = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.lbl_Proced = new System.Windows.Forms.Label();
            this.lbl_Hora = new System.Windows.Forms.Label();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.lbl_ConSite = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_AddImg = new System.Windows.Forms.Button();
            this.btn_Excluir = new System.Windows.Forms.Button();
            this.btn_Alterar = new System.Windows.Forms.Button();
            this.btn_Inserir = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_moverDir = new System.Windows.Forms.Button();
            this.btn_moverEsq = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Remover
            // 
            this.btn_Remover.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Remover.Location = new System.Drawing.Point(270, 104);
            this.btn_Remover.Name = "btn_Remover";
            this.btn_Remover.Size = new System.Drawing.Size(52, 20);
            this.btn_Remover.TabIndex = 83;
            this.btn_Remover.Text = "Remover";
            this.btn_Remover.UseVisualStyleBackColor = true;
            this.btn_Remover.Click += new System.EventHandler(this.btn_Remover_Click);
            // 
            // btn_Adicionar
            // 
            this.btn_Adicionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Adicionar.Location = new System.Drawing.Point(328, 104);
            this.btn_Adicionar.Name = "btn_Adicionar";
            this.btn_Adicionar.Size = new System.Drawing.Size(53, 20);
            this.btn_Adicionar.TabIndex = 78;
            this.btn_Adicionar.Text = "Adicionar";
            this.btn_Adicionar.UseVisualStyleBackColor = true;
            this.btn_Adicionar.Click += new System.EventHandler(this.btn_Adicionar_Click);
            // 
            // btn_PesquisarProduto
            // 
            this.btn_PesquisarProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PesquisarProduto.Location = new System.Drawing.Point(355, 30);
            this.btn_PesquisarProduto.Name = "btn_PesquisarProduto";
            this.btn_PesquisarProduto.Size = new System.Drawing.Size(26, 25);
            this.btn_PesquisarProduto.TabIndex = 77;
            this.btn_PesquisarProduto.UseVisualStyleBackColor = true;
            this.btn_PesquisarProduto.Click += new System.EventHandler(this.btn_PesquisarProduto_Click);
            // 
            // lbl_Produto
            // 
            this.lbl_Produto.AutoSize = true;
            this.lbl_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Produto.Location = new System.Drawing.Point(65, 23);
            this.lbl_Produto.Name = "lbl_Produto";
            this.lbl_Produto.Size = new System.Drawing.Size(41, 12);
            this.lbl_Produto.TabIndex = 82;
            this.lbl_Produto.Text = "Produto*";
            // 
            // txtb_Produto
            // 
            this.txtb_Produto.Enabled = false;
            this.txtb_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtb_Produto.Location = new System.Drawing.Point(67, 38);
            this.txtb_Produto.Name = "txtb_Produto";
            this.txtb_Produto.Size = new System.Drawing.Size(282, 18);
            this.txtb_Produto.TabIndex = 81;
            // 
            // lbl_CodigoProduto
            // 
            this.lbl_CodigoProduto.AutoSize = true;
            this.lbl_CodigoProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CodigoProduto.Location = new System.Drawing.Point(8, 23);
            this.lbl_CodigoProduto.Name = "lbl_CodigoProduto";
            this.lbl_CodigoProduto.Size = new System.Drawing.Size(45, 12);
            this.lbl_CodigoProduto.TabIndex = 80;
            this.lbl_CodigoProduto.Text = "Código P.";
            // 
            // txtb_CodigoProduto
            // 
            this.txtb_CodigoProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtb_CodigoProduto.Location = new System.Drawing.Point(10, 37);
            this.txtb_CodigoProduto.Name = "txtb_CodigoProduto";
            this.txtb_CodigoProduto.Size = new System.Drawing.Size(51, 18);
            this.txtb_CodigoProduto.TabIndex = 76;
            this.txtb_CodigoProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtb_CodigoProduto.TextChanged += new System.EventHandler(this.txtb_CodigoProduto_TextChanged);
            this.txtb_CodigoProduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtb_CodigoProduto_KeyPress);
            // 
            // lv_Produtos
            // 
            this.lv_Produtos.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lv_Produtos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_Produto,
            this.ch_Custo,
            this.ch_PesoLiq,
            this.ch_Saldo,
            this.ch_Codigo,
            this.ch_SimEstoq,
            this.ch_SimVisivel});
            this.lv_Produtos.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv_Produtos.FullRowSelect = true;
            this.lv_Produtos.GridLines = true;
            this.lv_Produtos.HideSelection = false;
            this.lv_Produtos.HoverSelection = true;
            this.lv_Produtos.Location = new System.Drawing.Point(10, 130);
            this.lv_Produtos.Name = "lv_Produtos";
            this.lv_Produtos.Size = new System.Drawing.Size(371, 122);
            this.lv_Produtos.TabIndex = 79;
            this.lv_Produtos.UseCompatibleStateImageBehavior = false;
            this.lv_Produtos.View = System.Windows.Forms.View.Details;
            // 
            // ch_Produto
            // 
            this.ch_Produto.Text = "Produto";
            this.ch_Produto.Width = 200;
            // 
            // ch_Custo
            // 
            this.ch_Custo.Text = "Preço";
            this.ch_Custo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ch_Custo.Width = 80;
            // 
            // ch_PesoLiq
            // 
            this.ch_PesoLiq.Text = "Peso";
            this.ch_PesoLiq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ch_Saldo
            // 
            this.ch_Saldo.DisplayIndex = 5;
            this.ch_Saldo.Text = "Saldo";
            this.ch_Saldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ch_Codigo
            // 
            this.ch_Codigo.DisplayIndex = 6;
            this.ch_Codigo.Text = "Código";
            this.ch_Codigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ch_SimEstoq
            // 
            this.ch_SimEstoq.DisplayIndex = 3;
            this.ch_SimEstoq.Text = "Estoque";
            // 
            // ch_SimVisivel
            // 
            this.ch_SimVisivel.DisplayIndex = 4;
            this.ch_SimVisivel.Text = "Visivel";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cb_Visivel);
            this.groupBox1.Controls.Add(this.cb_Estoque);
            this.groupBox1.Controls.Add(this.lv_Produtos);
            this.groupBox1.Controls.Add(this.txtb_CodigoProduto);
            this.groupBox1.Controls.Add(this.lbl_CodigoProduto);
            this.groupBox1.Controls.Add(this.btn_Remover);
            this.groupBox1.Controls.Add(this.txtb_Produto);
            this.groupBox1.Controls.Add(this.btn_Adicionar);
            this.groupBox1.Controls.Add(this.lbl_Produto);
            this.groupBox1.Controls.Add(this.btn_PesquisarProduto);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(394, 260);
            this.groupBox1.TabIndex = 86;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Produtos do sistema";
            // 
            // cb_Visivel
            // 
            this.cb_Visivel.AutoSize = true;
            this.cb_Visivel.Checked = true;
            this.cb_Visivel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_Visivel.Location = new System.Drawing.Point(10, 83);
            this.cb_Visivel.Name = "cb_Visivel";
            this.cb_Visivel.Size = new System.Drawing.Size(119, 17);
            this.cb_Visivel.TabIndex = 85;
            this.cb_Visivel.Text = "Está visivel na loja?";
            this.cb_Visivel.UseVisualStyleBackColor = true;
            // 
            // cb_Estoque
            // 
            this.cb_Estoque.AutoSize = true;
            this.cb_Estoque.Checked = true;
            this.cb_Estoque.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_Estoque.Location = new System.Drawing.Point(10, 62);
            this.cb_Estoque.Name = "cb_Estoque";
            this.cb_Estoque.Size = new System.Drawing.Size(111, 17);
            this.cb_Estoque.TabIndex = 84;
            this.cb_Estoque.Text = "Está em estoque?";
            this.cb_Estoque.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lv_MagentoProd);
            this.groupBox2.Controls.Add(this.btn_Remove);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.btn_AddImg);
            this.groupBox2.Controls.Add(this.btn_Excluir);
            this.groupBox2.Controls.Add(this.btn_Alterar);
            this.groupBox2.Controls.Add(this.btn_Inserir);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Location = new System.Drawing.Point(440, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(421, 260);
            this.groupBox2.TabIndex = 87;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Produtos para migrar para o Magento";
            // 
            // lv_MagentoProd
            // 
            this.lv_MagentoProd.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lv_MagentoProd.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lv_MagentoProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv_MagentoProd.FullRowSelect = true;
            this.lv_MagentoProd.GridLines = true;
            this.lv_MagentoProd.HideSelection = false;
            this.lv_MagentoProd.HoverSelection = true;
            this.lv_MagentoProd.Location = new System.Drawing.Point(6, 130);
            this.lv_MagentoProd.Name = "lv_MagentoProd";
            this.lv_MagentoProd.Size = new System.Drawing.Size(409, 122);
            this.lv_MagentoProd.TabIndex = 94;
            this.lv_MagentoProd.UseCompatibleStateImageBehavior = false;
            this.lv_MagentoProd.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Produto";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Preço";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Peso";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader4
            // 
            this.columnHeader4.DisplayIndex = 5;
            this.columnHeader4.Text = "Saldo";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader5
            // 
            this.columnHeader5.DisplayIndex = 6;
            this.columnHeader5.Text = "Código";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader6
            // 
            this.columnHeader6.DisplayIndex = 3;
            this.columnHeader6.Text = "Estoque";
            // 
            // columnHeader7
            // 
            this.columnHeader7.DisplayIndex = 4;
            this.columnHeader7.Text = "Visivel";
            // 
            // btn_Remove
            // 
            this.btn_Remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Remove.Location = new System.Drawing.Point(302, 104);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(54, 20);
            this.btn_Remove.TabIndex = 93;
            this.btn_Remove.Text = "Remove";
            this.btn_Remove.UseVisualStyleBackColor = true;
            this.btn_Remove.Click += new System.EventHandler(this.btn_Remove_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(221, 104);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 20);
            this.button4.TabIndex = 92;
            this.button4.Text = "Magento shop";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.lbl_Proced);
            this.groupBox3.Controls.Add(this.lbl_Hora);
            this.groupBox3.Controls.Add(this.lbl_Status);
            this.groupBox3.Controls.Add(this.lbl_ConSite);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(6, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(290, 70);
            this.groupBox3.TabIndex = 91;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Status das requisições";
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(247, 42);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(37, 22);
            this.button5.TabIndex = 94;
            this.button5.Text = "Info";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // lbl_Proced
            // 
            this.lbl_Proced.AutoSize = true;
            this.lbl_Proced.Location = new System.Drawing.Point(143, 42);
            this.lbl_Proced.Name = "lbl_Proced";
            this.lbl_Proced.Size = new System.Drawing.Size(13, 13);
            this.lbl_Proced.TabIndex = 6;
            this.lbl_Proced.Text = "--";
            // 
            // lbl_Hora
            // 
            this.lbl_Hora.AutoSize = true;
            this.lbl_Hora.Location = new System.Drawing.Point(143, 29);
            this.lbl_Hora.Name = "lbl_Hora";
            this.lbl_Hora.Size = new System.Drawing.Size(13, 13);
            this.lbl_Hora.TabIndex = 5;
            this.lbl_Hora.Text = "--";
            // 
            // lbl_Status
            // 
            this.lbl_Status.AutoSize = true;
            this.lbl_Status.Location = new System.Drawing.Point(143, 54);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(13, 13);
            this.lbl_Status.TabIndex = 5;
            this.lbl_Status.Text = "--";
            // 
            // lbl_ConSite
            // 
            this.lbl_ConSite.AutoSize = true;
            this.lbl_ConSite.Location = new System.Drawing.Point(143, 16);
            this.lbl_ConSite.Name = "lbl_ConSite";
            this.lbl_ConSite.Size = new System.Drawing.Size(13, 13);
            this.lbl_ConSite.TabIndex = 4;
            this.lbl_ConSite.Text = "--";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Status do porcedimento:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo de procedimento:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Horário da ultima conexão:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Conecatado ao site:";
            // 
            // btn_AddImg
            // 
            this.btn_AddImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddImg.Location = new System.Drawing.Point(361, 104);
            this.btn_AddImg.Name = "btn_AddImg";
            this.btn_AddImg.Size = new System.Drawing.Size(54, 20);
            this.btn_AddImg.TabIndex = 89;
            this.btn_AddImg.Text = "Adiciona";
            this.btn_AddImg.UseVisualStyleBackColor = true;
            this.btn_AddImg.Click += new System.EventHandler(this.btn_AddImg_Click);
            // 
            // btn_Excluir
            // 
            this.btn_Excluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Excluir.Location = new System.Drawing.Point(152, 104);
            this.btn_Excluir.Name = "btn_Excluir";
            this.btn_Excluir.Size = new System.Drawing.Size(53, 20);
            this.btn_Excluir.TabIndex = 88;
            this.btn_Excluir.Text = "Excluir";
            this.btn_Excluir.UseVisualStyleBackColor = true;
            this.btn_Excluir.Click += new System.EventHandler(this.btn_Excluir_Click);
            // 
            // btn_Alterar
            // 
            this.btn_Alterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Alterar.Location = new System.Drawing.Point(82, 104);
            this.btn_Alterar.Name = "btn_Alterar";
            this.btn_Alterar.Size = new System.Drawing.Size(53, 20);
            this.btn_Alterar.TabIndex = 87;
            this.btn_Alterar.Text = "Atualizar";
            this.btn_Alterar.UseVisualStyleBackColor = true;
            this.btn_Alterar.Click += new System.EventHandler(this.btn_Alterar_Click);
            // 
            // btn_Inserir
            // 
            this.btn_Inserir.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Inserir.Location = new System.Drawing.Point(6, 104);
            this.btn_Inserir.Name = "btn_Inserir";
            this.btn_Inserir.Size = new System.Drawing.Size(53, 20);
            this.btn_Inserir.TabIndex = 85;
            this.btn_Inserir.Text = "Inserir";
            this.btn_Inserir.UseVisualStyleBackColor = true;
            this.btn_Inserir.Click += new System.EventHandler(this.btn_Inserir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(302, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(113, 82);
            this.pictureBox1.TabIndex = 86;
            this.pictureBox1.TabStop = false;
            // 
            // btn_moverDir
            // 
            this.btn_moverDir.Location = new System.Drawing.Point(412, 212);
            this.btn_moverDir.Name = "btn_moverDir";
            this.btn_moverDir.Size = new System.Drawing.Size(22, 23);
            this.btn_moverDir.TabIndex = 88;
            this.btn_moverDir.Text = ">";
            this.btn_moverDir.UseVisualStyleBackColor = true;
            this.btn_moverDir.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_moverEsq
            // 
            this.btn_moverEsq.Location = new System.Drawing.Point(412, 183);
            this.btn_moverEsq.Name = "btn_moverEsq";
            this.btn_moverEsq.Size = new System.Drawing.Size(22, 23);
            this.btn_moverEsq.TabIndex = 89;
            this.btn_moverEsq.Text = "<";
            this.btn_moverEsq.UseVisualStyleBackColor = true;
            this.btn_moverEsq.Click += new System.EventHandler(this.btn_moverEsq_Click);
            // 
            // button3
            // 
            this.button3.ForeColor = System.Drawing.Color.Red;
            this.button3.Location = new System.Drawing.Point(412, 241);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(22, 23);
            this.button3.TabIndex = 90;
            this.button3.Text = "X";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmIntegracaoMagento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(873, 280);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btn_moverEsq);
            this.Controls.Add(this.btn_moverDir);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmIntegracaoMagento";
            this.Text = "Integração Magento";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Shown += new System.EventHandler(this.frmIntegracaoMagento_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Remover;
        private System.Windows.Forms.Button btn_Adicionar;
        private System.Windows.Forms.Button btn_PesquisarProduto;
        private System.Windows.Forms.Label lbl_Produto;
        private System.Windows.Forms.TextBox txtb_Produto;
        private System.Windows.Forms.Label lbl_CodigoProduto;
        private System.Windows.Forms.TextBox txtb_CodigoProduto;
        private System.Windows.Forms.ListView lv_Produtos;
        private System.Windows.Forms.ColumnHeader ch_Produto;
        private System.Windows.Forms.ColumnHeader ch_Custo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_AddImg;
        private System.Windows.Forms.Button btn_Excluir;
        private System.Windows.Forms.Button btn_Alterar;
        private System.Windows.Forms.Button btn_Inserir;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_moverDir;
        private System.Windows.Forms.Button btn_moverEsq;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_Remove;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_Proced;
        private System.Windows.Forms.Label lbl_Hora;
        private System.Windows.Forms.Label lbl_Status;
        private System.Windows.Forms.Label lbl_ConSite;
        private System.Windows.Forms.ColumnHeader ch_PesoLiq;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ColumnHeader ch_SimEstoq;
        private System.Windows.Forms.ColumnHeader ch_SimVisivel;
        private System.Windows.Forms.ColumnHeader ch_Saldo;
        private System.Windows.Forms.ColumnHeader ch_Codigo;
        private System.Windows.Forms.CheckBox cb_Visivel;
        private System.Windows.Forms.CheckBox cb_Estoque;
        private System.Windows.Forms.ListView lv_MagentoProd;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
