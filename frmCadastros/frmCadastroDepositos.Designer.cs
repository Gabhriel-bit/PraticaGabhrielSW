
namespace Projeto_ICI.frmCadastros
{
    partial class frmCadastroDepositos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastroDepositos));
            this.lbl_CEP = new System.Windows.Forms.Label();
            this.txtb_CEP = new System.Windows.Forms.TextBox();
            this.btn_Pesquisar = new System.Windows.Forms.Button();
            this.lbl_Cidade = new System.Windows.Forms.Label();
            this.txtb_Cidade = new System.Windows.Forms.TextBox();
            this.lbl_CodigoCidade = new System.Windows.Forms.Label();
            this.txtb_CodigoCidade = new System.Windows.Forms.TextBox();
            this.lbl_Bairro = new System.Windows.Forms.Label();
            this.txtb_Bairro = new System.Windows.Forms.TextBox();
            this.lbl_Complemento = new System.Windows.Forms.Label();
            this.txtb_Complemento = new System.Windows.Forms.TextBox();
            this.lbl_Numero = new System.Windows.Forms.Label();
            this.txtb_Numero = new System.Windows.Forms.TextBox();
            this.lbl_Logradouro = new System.Windows.Forms.Label();
            this.txtb_Logradouro = new System.Windows.Forms.TextBox();
            this.lbl_Deposito = new System.Windows.Forms.Label();
            this.txtb_Deposito = new System.Windows.Forms.TextBox();
            this.lv_Produtos = new System.Windows.Forms.ListView();
            this.ch_Codigo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Produto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Marca = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Modelo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Referencia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_CodigoBarras = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Subgrupo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_UND = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Saldo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Custo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_PesquisarProduto = new System.Windows.Forms.Button();
            this.lbl_Produto = new System.Windows.Forms.Label();
            this.txtb_Produto = new System.Windows.Forms.TextBox();
            this.lbl_CodigoProduto = new System.Windows.Forms.Label();
            this.txtb_CodigoProduto = new System.Windows.Forms.TextBox();
            this.btn_Adicionar = new System.Windows.Forms.Button();
            this.btn_Remover = new System.Windows.Forms.Button();
            this.lbl_btn_Remover = new System.Windows.Forms.Label();
            this.lbl_btn_Pesquisar = new System.Windows.Forms.Label();
            this.lbl_btn_Adicionar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).BeginInit();
            this.SuspendLayout();
            // 
            // txtb_CodigoUsu
            // 
            this.txtb_CodigoUsu.Location = new System.Drawing.Point(17, 545);
            // 
            // lbl_CodigoUsu
            // 
            this.lbl_CodigoUsu.Location = new System.Drawing.Point(14, 527);
            // 
            // btn_Sair
            // 
            this.btn_Sair.Location = new System.Drawing.Point(508, 540);
            this.btn_Sair.TabIndex = 13;
            // 
            // btn_Cadastro
            // 
            this.btn_Cadastro.Location = new System.Drawing.Point(436, 539);
            this.btn_Cadastro.TabIndex = 12;
            this.btn_Cadastro.Click += new System.EventHandler(this.btn_Cadastro_Click);
            // 
            // lbl_UltAlt
            // 
            this.lbl_UltAlt.Location = new System.Drawing.Point(234, 526);
            // 
            // lbl_DataCad
            // 
            this.lbl_DataCad.Location = new System.Drawing.Point(119, 526);
            // 
            // txtb_DataCadastro
            // 
            this.txtb_DataCadastro.Location = new System.Drawing.Point(122, 544);
            // 
            // txtb_DataUltAlt
            // 
            this.txtb_DataUltAlt.Location = new System.Drawing.Point(237, 544);
            // 
            // lbl_CEP
            // 
            this.lbl_CEP.AutoSize = true;
            this.lbl_CEP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CEP.Location = new System.Drawing.Point(19, 127);
            this.lbl_CEP.Name = "lbl_CEP";
            this.lbl_CEP.Size = new System.Drawing.Size(31, 15);
            this.lbl_CEP.TabIndex = 54;
            this.lbl_CEP.Text = "CEP";
            // 
            // txtb_CEP
            // 
            this.txtb_CEP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_CEP.Location = new System.Drawing.Point(22, 145);
            this.txtb_CEP.Name = "txtb_CEP";
            this.txtb_CEP.Size = new System.Drawing.Size(120, 20);
            this.txtb_CEP.TabIndex = 6;
            // 
            // btn_Pesquisar
            // 
            this.btn_Pesquisar.Location = new System.Drawing.Point(488, 138);
            this.btn_Pesquisar.Name = "btn_Pesquisar";
            this.btn_Pesquisar.Size = new System.Drawing.Size(26, 25);
            this.btn_Pesquisar.TabIndex = 8;
            this.btn_Pesquisar.UseVisualStyleBackColor = true;
            this.btn_Pesquisar.Click += new System.EventHandler(this.btn_Pesquisar_Click);
            this.btn_Pesquisar.MouseEnter += new System.EventHandler(this.btn_Pesquisar_MouseEnter);
            this.btn_Pesquisar.MouseLeave += new System.EventHandler(this.btn_Pesquisar_MouseLeave);
            // 
            // lbl_Cidade
            // 
            this.lbl_Cidade.AutoSize = true;
            this.lbl_Cidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Cidade.Location = new System.Drawing.Point(220, 127);
            this.lbl_Cidade.Name = "lbl_Cidade";
            this.lbl_Cidade.Size = new System.Drawing.Size(51, 15);
            this.lbl_Cidade.TabIndex = 51;
            this.lbl_Cidade.Text = "Cidade*";
            // 
            // txtb_Cidade
            // 
            this.txtb_Cidade.Enabled = false;
            this.txtb_Cidade.Location = new System.Drawing.Point(223, 145);
            this.txtb_Cidade.Name = "txtb_Cidade";
            this.txtb_Cidade.Size = new System.Drawing.Size(259, 20);
            this.txtb_Cidade.TabIndex = 50;
            // 
            // lbl_CodigoCidade
            // 
            this.lbl_CodigoCidade.AutoSize = true;
            this.lbl_CodigoCidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CodigoCidade.Location = new System.Drawing.Point(145, 127);
            this.lbl_CodigoCidade.Name = "lbl_CodigoCidade";
            this.lbl_CodigoCidade.Size = new System.Drawing.Size(60, 15);
            this.lbl_CodigoCidade.TabIndex = 49;
            this.lbl_CodigoCidade.Text = "Código C.";
            // 
            // txtb_CodigoCidade
            // 
            this.txtb_CodigoCidade.Location = new System.Drawing.Point(148, 145);
            this.txtb_CodigoCidade.Name = "txtb_CodigoCidade";
            this.txtb_CodigoCidade.Size = new System.Drawing.Size(69, 20);
            this.txtb_CodigoCidade.TabIndex = 7;
            this.txtb_CodigoCidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtb_CodigoCidade.TextChanged += new System.EventHandler(this.txtb_CodigoCidade_TextChanged);
            this.txtb_CodigoCidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtb_CodigoCidade_KeyPress);
            // 
            // lbl_Bairro
            // 
            this.lbl_Bairro.AutoSize = true;
            this.lbl_Bairro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Bairro.Location = new System.Drawing.Point(368, 67);
            this.lbl_Bairro.Name = "lbl_Bairro";
            this.lbl_Bairro.Size = new System.Drawing.Size(45, 15);
            this.lbl_Bairro.TabIndex = 47;
            this.lbl_Bairro.Text = "Bairro*";
            // 
            // txtb_Bairro
            // 
            this.txtb_Bairro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Bairro.Location = new System.Drawing.Point(371, 85);
            this.txtb_Bairro.Name = "txtb_Bairro";
            this.txtb_Bairro.Size = new System.Drawing.Size(180, 20);
            this.txtb_Bairro.TabIndex = 5;
            this.txtb_Bairro.Validating += new System.ComponentModel.CancelEventHandler(this.txtb_Bairro_Validating);
            // 
            // lbl_Complemento
            // 
            this.lbl_Complemento.AutoSize = true;
            this.lbl_Complemento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Complemento.Location = new System.Drawing.Point(232, 67);
            this.lbl_Complemento.Name = "lbl_Complemento";
            this.lbl_Complemento.Size = new System.Drawing.Size(85, 15);
            this.lbl_Complemento.TabIndex = 45;
            this.lbl_Complemento.Text = "Complemento";
            // 
            // txtb_Complemento
            // 
            this.txtb_Complemento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Complemento.Location = new System.Drawing.Point(235, 85);
            this.txtb_Complemento.Name = "txtb_Complemento";
            this.txtb_Complemento.Size = new System.Drawing.Size(130, 20);
            this.txtb_Complemento.TabIndex = 4;
            // 
            // lbl_Numero
            // 
            this.lbl_Numero.AutoSize = true;
            this.lbl_Numero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Numero.Location = new System.Drawing.Point(168, 67);
            this.lbl_Numero.Name = "lbl_Numero";
            this.lbl_Numero.Size = new System.Drawing.Size(57, 15);
            this.lbl_Numero.TabIndex = 43;
            this.lbl_Numero.Text = "Número*";
            // 
            // txtb_Numero
            // 
            this.txtb_Numero.Location = new System.Drawing.Point(171, 85);
            this.txtb_Numero.Name = "txtb_Numero";
            this.txtb_Numero.Size = new System.Drawing.Size(58, 20);
            this.txtb_Numero.TabIndex = 3;
            this.txtb_Numero.Validating += new System.ComponentModel.CancelEventHandler(this.txtb_Numero_Validating);
            // 
            // lbl_Logradouro
            // 
            this.lbl_Logradouro.AutoSize = true;
            this.lbl_Logradouro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Logradouro.Location = new System.Drawing.Point(19, 67);
            this.lbl_Logradouro.Name = "lbl_Logradouro";
            this.lbl_Logradouro.Size = new System.Drawing.Size(76, 15);
            this.lbl_Logradouro.TabIndex = 41;
            this.lbl_Logradouro.Text = "Logradouro*";
            // 
            // txtb_Logradouro
            // 
            this.txtb_Logradouro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Logradouro.Location = new System.Drawing.Point(22, 85);
            this.txtb_Logradouro.Name = "txtb_Logradouro";
            this.txtb_Logradouro.Size = new System.Drawing.Size(143, 20);
            this.txtb_Logradouro.TabIndex = 2;
            this.txtb_Logradouro.Validating += new System.ComponentModel.CancelEventHandler(this.txtb_Logradouro_Validating);
            // 
            // lbl_Deposito
            // 
            this.lbl_Deposito.AutoSize = true;
            this.lbl_Deposito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Deposito.Location = new System.Drawing.Point(96, 18);
            this.lbl_Deposito.Name = "lbl_Deposito";
            this.lbl_Deposito.Size = new System.Drawing.Size(61, 15);
            this.lbl_Deposito.TabIndex = 66;
            this.lbl_Deposito.Text = "Deposito*";
            // 
            // txtb_Deposito
            // 
            this.txtb_Deposito.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Deposito.Location = new System.Drawing.Point(99, 36);
            this.txtb_Deposito.Name = "txtb_Deposito";
            this.txtb_Deposito.Size = new System.Drawing.Size(266, 20);
            this.txtb_Deposito.TabIndex = 1;
            this.txtb_Deposito.Validating += new System.ComponentModel.CancelEventHandler(this.txtb_Deposito_Validating);
            // 
            // lv_Produtos
            // 
            this.lv_Produtos.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lv_Produtos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lv_Produtos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_Codigo,
            this.ch_Produto,
            this.ch_Marca,
            this.ch_Modelo,
            this.ch_Referencia,
            this.ch_CodigoBarras,
            this.ch_Subgrupo,
            this.ch_UND,
            this.ch_Saldo,
            this.ch_Custo});
            this.lv_Produtos.FullRowSelect = true;
            this.lv_Produtos.GridLines = true;
            this.lv_Produtos.HideSelection = false;
            this.lv_Produtos.HoverSelection = true;
            this.lv_Produtos.Location = new System.Drawing.Point(24, 231);
            this.lv_Produtos.Name = "lv_Produtos";
            this.lv_Produtos.Size = new System.Drawing.Size(527, 277);
            this.lv_Produtos.TabIndex = 67;
            this.lv_Produtos.UseCompatibleStateImageBehavior = false;
            this.lv_Produtos.View = System.Windows.Forms.View.Details;
            // 
            // ch_Codigo
            // 
            this.ch_Codigo.Text = "Código";
            // 
            // ch_Produto
            // 
            this.ch_Produto.Text = "Produto";
            this.ch_Produto.Width = 200;
            // 
            // ch_Marca
            // 
            this.ch_Marca.Text = "Marca";
            this.ch_Marca.Width = 150;
            // 
            // ch_Modelo
            // 
            this.ch_Modelo.Text = "Modelo";
            this.ch_Modelo.Width = 150;
            // 
            // ch_Referencia
            // 
            this.ch_Referencia.Text = "Referência";
            this.ch_Referencia.Width = 150;
            // 
            // ch_CodigoBarras
            // 
            this.ch_CodigoBarras.Text = "Código Barras";
            this.ch_CodigoBarras.Width = 200;
            // 
            // ch_Subgrupo
            // 
            this.ch_Subgrupo.Text = "Subgrupo";
            this.ch_Subgrupo.Width = 150;
            // 
            // ch_UND
            // 
            this.ch_UND.Text = "UND";
            this.ch_UND.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ch_UND.Width = 80;
            // 
            // ch_Saldo
            // 
            this.ch_Saldo.Text = "Saldo";
            this.ch_Saldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ch_Saldo.Width = 80;
            // 
            // ch_Custo
            // 
            this.ch_Custo.Text = "Custo";
            this.ch_Custo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ch_Custo.Width = 80;
            // 
            // btn_PesquisarProduto
            // 
            this.btn_PesquisarProduto.Location = new System.Drawing.Point(387, 198);
            this.btn_PesquisarProduto.Name = "btn_PesquisarProduto";
            this.btn_PesquisarProduto.Size = new System.Drawing.Size(26, 25);
            this.btn_PesquisarProduto.TabIndex = 10;
            this.btn_PesquisarProduto.UseVisualStyleBackColor = true;
            this.btn_PesquisarProduto.Click += new System.EventHandler(this.btn_PesquisarProduto_Click);
            this.btn_PesquisarProduto.MouseEnter += new System.EventHandler(this.btn_PesquisarProduto_MouseEnter);
            this.btn_PesquisarProduto.MouseLeave += new System.EventHandler(this.btn_PesquisarProduto_MouseLeave);
            // 
            // lbl_Produto
            // 
            this.lbl_Produto.AutoSize = true;
            this.lbl_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Produto.Location = new System.Drawing.Point(96, 187);
            this.lbl_Produto.Name = "lbl_Produto";
            this.lbl_Produto.Size = new System.Drawing.Size(55, 15);
            this.lbl_Produto.TabIndex = 71;
            this.lbl_Produto.Text = "Produto*";
            // 
            // txtb_Produto
            // 
            this.txtb_Produto.Enabled = false;
            this.txtb_Produto.Location = new System.Drawing.Point(99, 205);
            this.txtb_Produto.Name = "txtb_Produto";
            this.txtb_Produto.Size = new System.Drawing.Size(282, 20);
            this.txtb_Produto.TabIndex = 70;
            // 
            // lbl_CodigoProduto
            // 
            this.lbl_CodigoProduto.AutoSize = true;
            this.lbl_CodigoProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CodigoProduto.Location = new System.Drawing.Point(21, 187);
            this.lbl_CodigoProduto.Name = "lbl_CodigoProduto";
            this.lbl_CodigoProduto.Size = new System.Drawing.Size(60, 15);
            this.lbl_CodigoProduto.TabIndex = 69;
            this.lbl_CodigoProduto.Text = "Código P.";
            // 
            // txtb_CodigoProduto
            // 
            this.txtb_CodigoProduto.Location = new System.Drawing.Point(24, 205);
            this.txtb_CodigoProduto.Name = "txtb_CodigoProduto";
            this.txtb_CodigoProduto.Size = new System.Drawing.Size(69, 20);
            this.txtb_CodigoProduto.TabIndex = 9;
            this.txtb_CodigoProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtb_CodigoProduto.TextChanged += new System.EventHandler(this.txtb_CodigoProduto_TextChanged);
            this.txtb_CodigoProduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtb_CodigoProduto_KeyPress);
            // 
            // btn_Adicionar
            // 
            this.btn_Adicionar.Location = new System.Drawing.Point(419, 198);
            this.btn_Adicionar.Name = "btn_Adicionar";
            this.btn_Adicionar.Size = new System.Drawing.Size(63, 27);
            this.btn_Adicionar.TabIndex = 11;
            this.btn_Adicionar.Text = "Adicionar";
            this.btn_Adicionar.UseVisualStyleBackColor = true;
            this.btn_Adicionar.Click += new System.EventHandler(this.btn_Adicionar_Click);
            // 
            // btn_Remover
            // 
            this.btn_Remover.Location = new System.Drawing.Point(488, 198);
            this.btn_Remover.Name = "btn_Remover";
            this.btn_Remover.Size = new System.Drawing.Size(63, 27);
            this.btn_Remover.TabIndex = 72;
            this.btn_Remover.Text = "Remover";
            this.btn_Remover.UseVisualStyleBackColor = true;
            this.btn_Remover.Click += new System.EventHandler(this.btn_Remover_Click);
            // 
            // lbl_btn_Remover
            // 
            this.lbl_btn_Remover.AutoSize = true;
            this.lbl_btn_Remover.Location = new System.Drawing.Point(505, 182);
            this.lbl_btn_Remover.Name = "lbl_btn_Remover";
            this.lbl_btn_Remover.Size = new System.Drawing.Size(0, 13);
            this.lbl_btn_Remover.TabIndex = 75;
            // 
            // lbl_btn_Pesquisar
            // 
            this.lbl_btn_Pesquisar.AutoSize = true;
            this.lbl_btn_Pesquisar.Location = new System.Drawing.Point(369, 180);
            this.lbl_btn_Pesquisar.Name = "lbl_btn_Pesquisar";
            this.lbl_btn_Pesquisar.Size = new System.Drawing.Size(0, 13);
            this.lbl_btn_Pesquisar.TabIndex = 74;
            // 
            // lbl_btn_Adicionar
            // 
            this.lbl_btn_Adicionar.AutoSize = true;
            this.lbl_btn_Adicionar.Location = new System.Drawing.Point(442, 182);
            this.lbl_btn_Adicionar.Name = "lbl_btn_Adicionar";
            this.lbl_btn_Adicionar.Size = new System.Drawing.Size(0, 13);
            this.lbl_btn_Adicionar.TabIndex = 73;
            // 
            // frmCadastroDepositos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(586, 578);
            this.Controls.Add(this.lbl_btn_Remover);
            this.Controls.Add(this.lbl_btn_Pesquisar);
            this.Controls.Add(this.lbl_btn_Adicionar);
            this.Controls.Add(this.btn_Remover);
            this.Controls.Add(this.btn_Adicionar);
            this.Controls.Add(this.btn_PesquisarProduto);
            this.Controls.Add(this.lbl_Produto);
            this.Controls.Add(this.txtb_Produto);
            this.Controls.Add(this.lbl_CodigoProduto);
            this.Controls.Add(this.txtb_CodigoProduto);
            this.Controls.Add(this.lv_Produtos);
            this.Controls.Add(this.lbl_Deposito);
            this.Controls.Add(this.txtb_Deposito);
            this.Controls.Add(this.lbl_CEP);
            this.Controls.Add(this.txtb_CEP);
            this.Controls.Add(this.btn_Pesquisar);
            this.Controls.Add(this.lbl_Cidade);
            this.Controls.Add(this.txtb_Cidade);
            this.Controls.Add(this.lbl_CodigoCidade);
            this.Controls.Add(this.txtb_CodigoCidade);
            this.Controls.Add(this.lbl_Bairro);
            this.Controls.Add(this.txtb_Bairro);
            this.Controls.Add(this.lbl_Complemento);
            this.Controls.Add(this.txtb_Complemento);
            this.Controls.Add(this.lbl_Numero);
            this.Controls.Add(this.txtb_Numero);
            this.Controls.Add(this.lbl_Logradouro);
            this.Controls.Add(this.txtb_Logradouro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCadastroDepositos";
            this.Text = "Cadastro de Deposito";
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
            this.Controls.SetChildIndex(this.txtb_Logradouro, 0);
            this.Controls.SetChildIndex(this.lbl_Logradouro, 0);
            this.Controls.SetChildIndex(this.txtb_Numero, 0);
            this.Controls.SetChildIndex(this.lbl_Numero, 0);
            this.Controls.SetChildIndex(this.txtb_Complemento, 0);
            this.Controls.SetChildIndex(this.lbl_Complemento, 0);
            this.Controls.SetChildIndex(this.txtb_Bairro, 0);
            this.Controls.SetChildIndex(this.lbl_Bairro, 0);
            this.Controls.SetChildIndex(this.txtb_CodigoCidade, 0);
            this.Controls.SetChildIndex(this.lbl_CodigoCidade, 0);
            this.Controls.SetChildIndex(this.txtb_Cidade, 0);
            this.Controls.SetChildIndex(this.lbl_Cidade, 0);
            this.Controls.SetChildIndex(this.btn_Pesquisar, 0);
            this.Controls.SetChildIndex(this.txtb_CEP, 0);
            this.Controls.SetChildIndex(this.lbl_CEP, 0);
            this.Controls.SetChildIndex(this.txtb_Deposito, 0);
            this.Controls.SetChildIndex(this.lbl_Deposito, 0);
            this.Controls.SetChildIndex(this.lv_Produtos, 0);
            this.Controls.SetChildIndex(this.txtb_CodigoProduto, 0);
            this.Controls.SetChildIndex(this.lbl_CodigoProduto, 0);
            this.Controls.SetChildIndex(this.txtb_Produto, 0);
            this.Controls.SetChildIndex(this.lbl_Produto, 0);
            this.Controls.SetChildIndex(this.btn_PesquisarProduto, 0);
            this.Controls.SetChildIndex(this.btn_Adicionar, 0);
            this.Controls.SetChildIndex(this.btn_Remover, 0);
            this.Controls.SetChildIndex(this.lbl_btn_Adicionar, 0);
            this.Controls.SetChildIndex(this.lbl_btn_Pesquisar, 0);
            this.Controls.SetChildIndex(this.lbl_btn_Remover, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_CEP;
        private System.Windows.Forms.TextBox txtb_CEP;
        private System.Windows.Forms.Button btn_Pesquisar;
        private System.Windows.Forms.Label lbl_Cidade;
        private System.Windows.Forms.TextBox txtb_Cidade;
        private System.Windows.Forms.Label lbl_CodigoCidade;
        private System.Windows.Forms.TextBox txtb_CodigoCidade;
        private System.Windows.Forms.Label lbl_Bairro;
        private System.Windows.Forms.TextBox txtb_Bairro;
        private System.Windows.Forms.Label lbl_Complemento;
        private System.Windows.Forms.TextBox txtb_Complemento;
        private System.Windows.Forms.Label lbl_Numero;
        private System.Windows.Forms.TextBox txtb_Numero;
        private System.Windows.Forms.Label lbl_Logradouro;
        private System.Windows.Forms.TextBox txtb_Logradouro;
        private System.Windows.Forms.Label lbl_Deposito;
        private System.Windows.Forms.TextBox txtb_Deposito;
        private System.Windows.Forms.ListView lv_Produtos;
        private System.Windows.Forms.Button btn_PesquisarProduto;
        private System.Windows.Forms.Label lbl_Produto;
        private System.Windows.Forms.TextBox txtb_Produto;
        private System.Windows.Forms.Label lbl_CodigoProduto;
        private System.Windows.Forms.TextBox txtb_CodigoProduto;
        private System.Windows.Forms.Button btn_Adicionar;
        private System.Windows.Forms.ColumnHeader ch_Codigo;
        private System.Windows.Forms.ColumnHeader ch_Produto;
        private System.Windows.Forms.ColumnHeader ch_Marca;
        private System.Windows.Forms.ColumnHeader ch_Modelo;
        private System.Windows.Forms.ColumnHeader ch_Referencia;
        private System.Windows.Forms.ColumnHeader ch_CodigoBarras;
        private System.Windows.Forms.ColumnHeader ch_Subgrupo;
        private System.Windows.Forms.ColumnHeader ch_UND;
        private System.Windows.Forms.ColumnHeader ch_Saldo;
        private System.Windows.Forms.ColumnHeader ch_Custo;
        private System.Windows.Forms.Button btn_Remover;
        private System.Windows.Forms.Label lbl_btn_Remover;
        private System.Windows.Forms.Label lbl_btn_Pesquisar;
        private System.Windows.Forms.Label lbl_btn_Adicionar;
    }
}
