
namespace Projeto_ICI.frmCadastros
{
    partial class frmCadastroProdutos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastroProdutos));
            this.lbl_Produto = new System.Windows.Forms.Label();
            this.txtb_Produto = new System.Windows.Forms.TextBox();
            this.lbl_Unidade = new System.Windows.Forms.Label();
            this.txtb_Unidade = new System.Windows.Forms.TextBox();
            this.lbl_Modelo = new System.Windows.Forms.Label();
            this.txtb_Modelo = new System.Windows.Forms.TextBox();
            this.lbl_CodigoModelo = new System.Windows.Forms.Label();
            this.txtb_CodigoModelo = new System.Windows.Forms.TextBox();
            this.lbl_Marca = new System.Windows.Forms.Label();
            this.btn_PesquisarModelo = new System.Windows.Forms.Button();
            this.txtb_Marca = new System.Windows.Forms.TextBox();
            this.btn_PesquisarSubGrupo = new System.Windows.Forms.Button();
            this.txtb_SubGrupo = new System.Windows.Forms.TextBox();
            this.lbl_CodigoSubGrupo = new System.Windows.Forms.Label();
            this.txtb_CodigoSubGrupo = new System.Windows.Forms.TextBox();
            this.lbl_SubGrupo = new System.Windows.Forms.Label();
            this.lbl_Referencia = new System.Windows.Forms.Label();
            this.txtb_Referencia = new System.Windows.Forms.TextBox();
            this.lbl_CodigoBarras = new System.Windows.Forms.Label();
            this.txtb_CodigoBarras = new System.Windows.Forms.TextBox();
            this.lbl_Custo = new System.Windows.Forms.Label();
            this.txtb_Custo = new System.Windows.Forms.TextBox();
            this.lbl_Saldo = new System.Windows.Forms.Label();
            this.txtb_Saldo = new System.Windows.Forms.TextBox();
            this.lbl_Fornecedor = new System.Windows.Forms.Label();
            this.txtb_CodigoFornecedor = new System.Windows.Forms.TextBox();
            this.lbl_CodigoFornecedor = new System.Windows.Forms.Label();
            this.txtb_Fornecedor = new System.Windows.Forms.TextBox();
            this.btn_PesquisarFornecedor = new System.Windows.Forms.Button();
            this.btn_Remover = new System.Windows.Forms.Button();
            this.lv_Fornecedores = new System.Windows.Forms.ListView();
            this.ch_Codigo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Fornecedor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_CNPJ = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_Adicionar = new System.Windows.Forms.Button();
            this.lbl_btn_Adicionar = new System.Windows.Forms.Label();
            this.lbl_btn_Pesquisar = new System.Windows.Forms.Label();
            this.lbl_btn_Remover = new System.Windows.Forms.Label();
            this.lbl_PrecoUltCompra = new System.Windows.Forms.Label();
            this.txtb_PrecoUltCompra = new System.Windows.Forms.TextBox();
            this.lbl_PesoBruto = new System.Windows.Forms.Label();
            this.lbl_PesoLiquido = new System.Windows.Forms.Label();
            this.txtb_PesoLiquido = new System.Windows.Forms.TextBox();
            this.txtb_PesoBruto = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).BeginInit();
            this.SuspendLayout();
            // 
            // txtb_CodigoUsu
            // 
            this.txtb_CodigoUsu.Location = new System.Drawing.Point(17, 492);
            // 
            // lbl_CodigoUsu
            // 
            this.lbl_CodigoUsu.Location = new System.Drawing.Point(14, 474);
            // 
            // btn_Sair
            // 
            this.btn_Sair.Location = new System.Drawing.Point(454, 487);
            this.btn_Sair.TabIndex = 18;
            // 
            // btn_Cadastro
            // 
            this.btn_Cadastro.Location = new System.Drawing.Point(382, 486);
            this.btn_Cadastro.TabIndex = 17;
            this.btn_Cadastro.Click += new System.EventHandler(this.btn_Cadastro_Click);
            // 
            // lbl_UltAlt
            // 
            this.lbl_UltAlt.Location = new System.Drawing.Point(234, 473);
            // 
            // lbl_DataCad
            // 
            this.lbl_DataCad.Location = new System.Drawing.Point(119, 473);
            // 
            // txtb_DataCadastro
            // 
            this.txtb_DataCadastro.Location = new System.Drawing.Point(122, 491);
            // 
            // txtb_DataUltAlt
            // 
            this.txtb_DataUltAlt.Location = new System.Drawing.Point(237, 491);
            // 
            // lbl_Produto
            // 
            this.lbl_Produto.AutoSize = true;
            this.lbl_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Produto.Location = new System.Drawing.Point(96, 18);
            this.lbl_Produto.Name = "lbl_Produto";
            this.lbl_Produto.Size = new System.Drawing.Size(55, 15);
            this.lbl_Produto.TabIndex = 23;
            this.lbl_Produto.Text = "Produto*";
            // 
            // txtb_Produto
            // 
            this.txtb_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Produto.Location = new System.Drawing.Point(99, 36);
            this.txtb_Produto.Name = "txtb_Produto";
            this.txtb_Produto.Size = new System.Drawing.Size(252, 20);
            this.txtb_Produto.TabIndex = 0;
            this.txtb_Produto.Validating += new System.ComponentModel.CancelEventHandler(this.txtb_Produto_Validating);
            // 
            // lbl_Unidade
            // 
            this.lbl_Unidade.AutoSize = true;
            this.lbl_Unidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Unidade.Location = new System.Drawing.Point(354, 18);
            this.lbl_Unidade.Name = "lbl_Unidade";
            this.lbl_Unidade.Size = new System.Drawing.Size(39, 15);
            this.lbl_Unidade.TabIndex = 25;
            this.lbl_Unidade.Text = "UND*";
            // 
            // txtb_Unidade
            // 
            this.txtb_Unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Unidade.Location = new System.Drawing.Point(357, 36);
            this.txtb_Unidade.Name = "txtb_Unidade";
            this.txtb_Unidade.Size = new System.Drawing.Size(75, 20);
            this.txtb_Unidade.TabIndex = 1;
            this.txtb_Unidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtb_Unidade.Validating += new System.ComponentModel.CancelEventHandler(this.txtb_Unidade_Validating);
            // 
            // lbl_Modelo
            // 
            this.lbl_Modelo.AutoSize = true;
            this.lbl_Modelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Modelo.Location = new System.Drawing.Point(96, 128);
            this.lbl_Modelo.Name = "lbl_Modelo";
            this.lbl_Modelo.Size = new System.Drawing.Size(54, 15);
            this.lbl_Modelo.TabIndex = 27;
            this.lbl_Modelo.Text = "Modelo*";
            // 
            // txtb_Modelo
            // 
            this.txtb_Modelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Modelo.Enabled = false;
            this.txtb_Modelo.Location = new System.Drawing.Point(99, 146);
            this.txtb_Modelo.Name = "txtb_Modelo";
            this.txtb_Modelo.Size = new System.Drawing.Size(165, 20);
            this.txtb_Modelo.TabIndex = 26;
            // 
            // lbl_CodigoModelo
            // 
            this.lbl_CodigoModelo.AutoSize = true;
            this.lbl_CodigoModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CodigoModelo.Location = new System.Drawing.Point(21, 128);
            this.lbl_CodigoModelo.Name = "lbl_CodigoModelo";
            this.lbl_CodigoModelo.Size = new System.Drawing.Size(63, 15);
            this.lbl_CodigoModelo.TabIndex = 29;
            this.lbl_CodigoModelo.Text = "Codigo M.";
            // 
            // txtb_CodigoModelo
            // 
            this.txtb_CodigoModelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_CodigoModelo.Location = new System.Drawing.Point(24, 146);
            this.txtb_CodigoModelo.Name = "txtb_CodigoModelo";
            this.txtb_CodigoModelo.Size = new System.Drawing.Size(69, 20);
            this.txtb_CodigoModelo.TabIndex = 7;
            this.txtb_CodigoModelo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtb_CodigoModelo.TextChanged += new System.EventHandler(this.txtb_CodigoModelo_TextChanged);
            // 
            // lbl_Marca
            // 
            this.lbl_Marca.AutoSize = true;
            this.lbl_Marca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Marca.Location = new System.Drawing.Point(267, 127);
            this.lbl_Marca.Name = "lbl_Marca";
            this.lbl_Marca.Size = new System.Drawing.Size(42, 15);
            this.lbl_Marca.TabIndex = 31;
            this.lbl_Marca.Text = "Marca";
            // 
            // btn_PesquisarModelo
            // 
            this.btn_PesquisarModelo.Location = new System.Drawing.Point(371, 143);
            this.btn_PesquisarModelo.Name = "btn_PesquisarModelo";
            this.btn_PesquisarModelo.Size = new System.Drawing.Size(26, 25);
            this.btn_PesquisarModelo.TabIndex = 8;
            this.btn_PesquisarModelo.UseVisualStyleBackColor = true;
            this.btn_PesquisarModelo.Click += new System.EventHandler(this.btn_PesquisarModelo_Click);
            this.btn_PesquisarModelo.MouseEnter += new System.EventHandler(this.btn_PesquisarModelo_MouseEnter);
            this.btn_PesquisarModelo.MouseLeave += new System.EventHandler(this.btn_PesquisarModelo_MouseLeave);
            // 
            // txtb_Marca
            // 
            this.txtb_Marca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Marca.Enabled = false;
            this.txtb_Marca.Location = new System.Drawing.Point(270, 146);
            this.txtb_Marca.Name = "txtb_Marca";
            this.txtb_Marca.Size = new System.Drawing.Size(95, 20);
            this.txtb_Marca.TabIndex = 36;
            // 
            // btn_PesquisarSubGrupo
            // 
            this.btn_PesquisarSubGrupo.Location = new System.Drawing.Point(371, 199);
            this.btn_PesquisarSubGrupo.Name = "btn_PesquisarSubGrupo";
            this.btn_PesquisarSubGrupo.Size = new System.Drawing.Size(26, 25);
            this.btn_PesquisarSubGrupo.TabIndex = 12;
            this.btn_PesquisarSubGrupo.UseVisualStyleBackColor = true;
            this.btn_PesquisarSubGrupo.Click += new System.EventHandler(this.btn_PesquisarSubGrupo_Click);
            this.btn_PesquisarSubGrupo.MouseEnter += new System.EventHandler(this.btn_PesquisarSubGrupo_MouseEnter);
            this.btn_PesquisarSubGrupo.MouseLeave += new System.EventHandler(this.btn_PesquisarSubGrupo_MouseLeave);
            // 
            // txtb_SubGrupo
            // 
            this.txtb_SubGrupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_SubGrupo.Enabled = false;
            this.txtb_SubGrupo.Location = new System.Drawing.Point(99, 202);
            this.txtb_SubGrupo.Name = "txtb_SubGrupo";
            this.txtb_SubGrupo.Size = new System.Drawing.Size(266, 20);
            this.txtb_SubGrupo.TabIndex = 41;
            // 
            // lbl_CodigoSubGrupo
            // 
            this.lbl_CodigoSubGrupo.AutoSize = true;
            this.lbl_CodigoSubGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CodigoSubGrupo.Location = new System.Drawing.Point(21, 184);
            this.lbl_CodigoSubGrupo.Name = "lbl_CodigoSubGrupo";
            this.lbl_CodigoSubGrupo.Size = new System.Drawing.Size(69, 15);
            this.lbl_CodigoSubGrupo.TabIndex = 40;
            this.lbl_CodigoSubGrupo.Text = "Codigo SG.";
            // 
            // txtb_CodigoSubGrupo
            // 
            this.txtb_CodigoSubGrupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_CodigoSubGrupo.Location = new System.Drawing.Point(24, 202);
            this.txtb_CodigoSubGrupo.Name = "txtb_CodigoSubGrupo";
            this.txtb_CodigoSubGrupo.Size = new System.Drawing.Size(69, 20);
            this.txtb_CodigoSubGrupo.TabIndex = 11;
            this.txtb_CodigoSubGrupo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtb_CodigoSubGrupo.TextChanged += new System.EventHandler(this.txtb_CodigoSubGrupo_TextChanged);
            // 
            // lbl_SubGrupo
            // 
            this.lbl_SubGrupo.AutoSize = true;
            this.lbl_SubGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SubGrupo.Location = new System.Drawing.Point(96, 183);
            this.lbl_SubGrupo.Name = "lbl_SubGrupo";
            this.lbl_SubGrupo.Size = new System.Drawing.Size(66, 15);
            this.lbl_SubGrupo.TabIndex = 38;
            this.lbl_SubGrupo.Text = "Subgrupo*";
            // 
            // lbl_Referencia
            // 
            this.lbl_Referencia.AutoSize = true;
            this.lbl_Referencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Referencia.Location = new System.Drawing.Point(21, 72);
            this.lbl_Referencia.Name = "lbl_Referencia";
            this.lbl_Referencia.Size = new System.Drawing.Size(67, 15);
            this.lbl_Referencia.TabIndex = 49;
            this.lbl_Referencia.Text = "Referência";
            // 
            // txtb_Referencia
            // 
            this.txtb_Referencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Referencia.Location = new System.Drawing.Point(24, 90);
            this.txtb_Referencia.Name = "txtb_Referencia";
            this.txtb_Referencia.Size = new System.Drawing.Size(69, 20);
            this.txtb_Referencia.TabIndex = 3;
            // 
            // lbl_CodigoBarras
            // 
            this.lbl_CodigoBarras.AutoSize = true;
            this.lbl_CodigoBarras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CodigoBarras.Location = new System.Drawing.Point(96, 72);
            this.lbl_CodigoBarras.Name = "lbl_CodigoBarras";
            this.lbl_CodigoBarras.Size = new System.Drawing.Size(84, 15);
            this.lbl_CodigoBarras.TabIndex = 51;
            this.lbl_CodigoBarras.Text = "Codigo barras";
            // 
            // txtb_CodigoBarras
            // 
            this.txtb_CodigoBarras.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_CodigoBarras.Location = new System.Drawing.Point(99, 90);
            this.txtb_CodigoBarras.Name = "txtb_CodigoBarras";
            this.txtb_CodigoBarras.Size = new System.Drawing.Size(223, 20);
            this.txtb_CodigoBarras.TabIndex = 4;
            // 
            // lbl_Custo
            // 
            this.lbl_Custo.AutoSize = true;
            this.lbl_Custo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Custo.Location = new System.Drawing.Point(435, 18);
            this.lbl_Custo.Name = "lbl_Custo";
            this.lbl_Custo.Size = new System.Drawing.Size(38, 15);
            this.lbl_Custo.TabIndex = 53;
            this.lbl_Custo.Text = "Custo";
            this.lbl_Custo.Validating += new System.ComponentModel.CancelEventHandler(this.lbl_Custo_Validating);
            // 
            // txtb_Custo
            // 
            this.txtb_Custo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Custo.Enabled = false;
            this.txtb_Custo.Location = new System.Drawing.Point(438, 36);
            this.txtb_Custo.Name = "txtb_Custo";
            this.txtb_Custo.Size = new System.Drawing.Size(69, 20);
            this.txtb_Custo.TabIndex = 2;
            this.txtb_Custo.Text = "0";
            this.txtb_Custo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl_Saldo
            // 
            this.lbl_Saldo.AutoSize = true;
            this.lbl_Saldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Saldo.Location = new System.Drawing.Point(323, 72);
            this.lbl_Saldo.Name = "lbl_Saldo";
            this.lbl_Saldo.Size = new System.Drawing.Size(39, 15);
            this.lbl_Saldo.TabIndex = 55;
            this.lbl_Saldo.Text = "Saldo";
            // 
            // txtb_Saldo
            // 
            this.txtb_Saldo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Saldo.Enabled = false;
            this.txtb_Saldo.Location = new System.Drawing.Point(326, 90);
            this.txtb_Saldo.Name = "txtb_Saldo";
            this.txtb_Saldo.Size = new System.Drawing.Size(73, 20);
            this.txtb_Saldo.TabIndex = 5;
            this.txtb_Saldo.Text = "0";
            this.txtb_Saldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtb_Saldo.Validating += new System.ComponentModel.CancelEventHandler(this.txtb_Saldo_Validating);
            // 
            // lbl_Fornecedor
            // 
            this.lbl_Fornecedor.AutoSize = true;
            this.lbl_Fornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Fornecedor.Location = new System.Drawing.Point(96, 239);
            this.lbl_Fornecedor.Name = "lbl_Fornecedor";
            this.lbl_Fornecedor.Size = new System.Drawing.Size(75, 15);
            this.lbl_Fornecedor.TabIndex = 43;
            this.lbl_Fornecedor.Text = "Fornecedor*";
            // 
            // txtb_CodigoFornecedor
            // 
            this.txtb_CodigoFornecedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_CodigoFornecedor.Location = new System.Drawing.Point(24, 258);
            this.txtb_CodigoFornecedor.Name = "txtb_CodigoFornecedor";
            this.txtb_CodigoFornecedor.Size = new System.Drawing.Size(69, 20);
            this.txtb_CodigoFornecedor.TabIndex = 13;
            this.txtb_CodigoFornecedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtb_CodigoFornecedor.TextChanged += new System.EventHandler(this.txtb_CodigoFornecedor_TextChanged);
            // 
            // lbl_CodigoFornecedor
            // 
            this.lbl_CodigoFornecedor.AutoSize = true;
            this.lbl_CodigoFornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CodigoFornecedor.Location = new System.Drawing.Point(21, 240);
            this.lbl_CodigoFornecedor.Name = "lbl_CodigoFornecedor";
            this.lbl_CodigoFornecedor.Size = new System.Drawing.Size(59, 15);
            this.lbl_CodigoFornecedor.TabIndex = 45;
            this.lbl_CodigoFornecedor.Text = "Codigo F.";
            // 
            // txtb_Fornecedor
            // 
            this.txtb_Fornecedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Fornecedor.Enabled = false;
            this.txtb_Fornecedor.Location = new System.Drawing.Point(99, 258);
            this.txtb_Fornecedor.Name = "txtb_Fornecedor";
            this.txtb_Fornecedor.Size = new System.Drawing.Size(242, 20);
            this.txtb_Fornecedor.TabIndex = 46;
            // 
            // btn_PesquisarFornecedor
            // 
            this.btn_PesquisarFornecedor.Location = new System.Drawing.Point(347, 253);
            this.btn_PesquisarFornecedor.Name = "btn_PesquisarFornecedor";
            this.btn_PesquisarFornecedor.Size = new System.Drawing.Size(26, 25);
            this.btn_PesquisarFornecedor.TabIndex = 14;
            this.btn_PesquisarFornecedor.UseVisualStyleBackColor = true;
            this.btn_PesquisarFornecedor.Click += new System.EventHandler(this.btn_PesquisarFornecedor_Click);
            this.btn_PesquisarFornecedor.MouseEnter += new System.EventHandler(this.btn_PesquisarFornecedor_MouseEnter);
            this.btn_PesquisarFornecedor.MouseLeave += new System.EventHandler(this.btn_PesquisarFornecedor_MouseLeave);
            // 
            // btn_Remover
            // 
            this.btn_Remover.Location = new System.Drawing.Point(446, 253);
            this.btn_Remover.Name = "btn_Remover";
            this.btn_Remover.Size = new System.Drawing.Size(61, 25);
            this.btn_Remover.TabIndex = 16;
            this.btn_Remover.Text = "Remover";
            this.btn_Remover.UseVisualStyleBackColor = true;
            this.btn_Remover.Click += new System.EventHandler(this.btn_Remover_Click);
            // 
            // lv_Fornecedores
            // 
            this.lv_Fornecedores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_Codigo,
            this.ch_Fornecedor,
            this.ch_CNPJ,
            this.ch_Email});
            this.lv_Fornecedores.FullRowSelect = true;
            this.lv_Fornecedores.GridLines = true;
            this.lv_Fornecedores.HideSelection = false;
            this.lv_Fornecedores.Location = new System.Drawing.Point(24, 284);
            this.lv_Fornecedores.MultiSelect = false;
            this.lv_Fornecedores.Name = "lv_Fornecedores";
            this.lv_Fornecedores.Size = new System.Drawing.Size(483, 177);
            this.lv_Fornecedores.TabIndex = 66;
            this.lv_Fornecedores.UseCompatibleStateImageBehavior = false;
            this.lv_Fornecedores.View = System.Windows.Forms.View.Details;
            // 
            // ch_Codigo
            // 
            this.ch_Codigo.Text = "Código";
            // 
            // ch_Fornecedor
            // 
            this.ch_Fornecedor.Text = "Fornecedor";
            this.ch_Fornecedor.Width = 200;
            // 
            // ch_CNPJ
            // 
            this.ch_CNPJ.Text = "CPF / CNPJ";
            this.ch_CNPJ.Width = 100;
            // 
            // ch_Email
            // 
            this.ch_Email.Text = "E-mail";
            this.ch_Email.Width = 115;
            // 
            // btn_Adicionar
            // 
            this.btn_Adicionar.Location = new System.Drawing.Point(379, 253);
            this.btn_Adicionar.Name = "btn_Adicionar";
            this.btn_Adicionar.Size = new System.Drawing.Size(61, 25);
            this.btn_Adicionar.TabIndex = 15;
            this.btn_Adicionar.Text = "Adicionar";
            this.btn_Adicionar.UseVisualStyleBackColor = true;
            this.btn_Adicionar.Click += new System.EventHandler(this.btn_Adicionar_Click);
            // 
            // lbl_btn_Adicionar
            // 
            this.lbl_btn_Adicionar.AutoSize = true;
            this.lbl_btn_Adicionar.Location = new System.Drawing.Point(382, 241);
            this.lbl_btn_Adicionar.Name = "lbl_btn_Adicionar";
            this.lbl_btn_Adicionar.Size = new System.Drawing.Size(0, 13);
            this.lbl_btn_Adicionar.TabIndex = 67;
            // 
            // lbl_btn_Pesquisar
            // 
            this.lbl_btn_Pesquisar.AutoSize = true;
            this.lbl_btn_Pesquisar.Location = new System.Drawing.Point(309, 239);
            this.lbl_btn_Pesquisar.Name = "lbl_btn_Pesquisar";
            this.lbl_btn_Pesquisar.Size = new System.Drawing.Size(0, 13);
            this.lbl_btn_Pesquisar.TabIndex = 68;
            // 
            // lbl_btn_Remover
            // 
            this.lbl_btn_Remover.AutoSize = true;
            this.lbl_btn_Remover.Location = new System.Drawing.Point(453, 241);
            this.lbl_btn_Remover.Name = "lbl_btn_Remover";
            this.lbl_btn_Remover.Size = new System.Drawing.Size(0, 13);
            this.lbl_btn_Remover.TabIndex = 69;
            // 
            // lbl_PrecoUltCompra
            // 
            this.lbl_PrecoUltCompra.AutoSize = true;
            this.lbl_PrecoUltCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PrecoUltCompra.Location = new System.Drawing.Point(402, 72);
            this.lbl_PrecoUltCompra.Name = "lbl_PrecoUltCompra";
            this.lbl_PrecoUltCompra.Size = new System.Drawing.Size(100, 15);
            this.lbl_PrecoUltCompra.TabIndex = 71;
            this.lbl_PrecoUltCompra.Text = "Preço ult compra";
            // 
            // txtb_PrecoUltCompra
            // 
            this.txtb_PrecoUltCompra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_PrecoUltCompra.Enabled = false;
            this.txtb_PrecoUltCompra.Location = new System.Drawing.Point(405, 90);
            this.txtb_PrecoUltCompra.Name = "txtb_PrecoUltCompra";
            this.txtb_PrecoUltCompra.Size = new System.Drawing.Size(102, 20);
            this.txtb_PrecoUltCompra.TabIndex = 6;
            this.txtb_PrecoUltCompra.Text = "0";
            this.txtb_PrecoUltCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl_PesoBruto
            // 
            this.lbl_PesoBruto.AutoSize = true;
            this.lbl_PesoBruto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PesoBruto.Location = new System.Drawing.Point(400, 128);
            this.lbl_PesoBruto.Name = "lbl_PesoBruto";
            this.lbl_PesoBruto.Size = new System.Drawing.Size(71, 15);
            this.lbl_PesoBruto.TabIndex = 73;
            this.lbl_PesoBruto.Text = "Peso bruto*";
            // 
            // lbl_PesoLiquido
            // 
            this.lbl_PesoLiquido.AutoSize = true;
            this.lbl_PesoLiquido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PesoLiquido.Location = new System.Drawing.Point(400, 184);
            this.lbl_PesoLiquido.Name = "lbl_PesoLiquido";
            this.lbl_PesoLiquido.Size = new System.Drawing.Size(84, 15);
            this.lbl_PesoLiquido.TabIndex = 75;
            this.lbl_PesoLiquido.Text = "Peso Líquido*";
            // 
            // txtb_PesoLiquido
            // 
            this.txtb_PesoLiquido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_PesoLiquido.Location = new System.Drawing.Point(403, 202);
            this.txtb_PesoLiquido.Name = "txtb_PesoLiquido";
            this.txtb_PesoLiquido.Size = new System.Drawing.Size(104, 20);
            this.txtb_PesoLiquido.TabIndex = 10;
            this.txtb_PesoLiquido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtb_PesoLiquido.Validating += new System.ComponentModel.CancelEventHandler(this.txtb_PesoLiquido_Validating);
            // 
            // txtb_PesoBruto
            // 
            this.txtb_PesoBruto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_PesoBruto.Location = new System.Drawing.Point(403, 148);
            this.txtb_PesoBruto.Name = "txtb_PesoBruto";
            this.txtb_PesoBruto.Size = new System.Drawing.Size(104, 20);
            this.txtb_PesoBruto.TabIndex = 9;
            this.txtb_PesoBruto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtb_PesoBruto.Validating += new System.ComponentModel.CancelEventHandler(this.txtb_PesoBruto_Validating);
            // 
            // frmCadastroProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(532, 525);
            this.Controls.Add(this.txtb_PesoBruto);
            this.Controls.Add(this.lbl_PesoLiquido);
            this.Controls.Add(this.txtb_PesoLiquido);
            this.Controls.Add(this.lbl_PesoBruto);
            this.Controls.Add(this.lbl_PrecoUltCompra);
            this.Controls.Add(this.txtb_PrecoUltCompra);
            this.Controls.Add(this.lbl_btn_Remover);
            this.Controls.Add(this.lbl_btn_Pesquisar);
            this.Controls.Add(this.lbl_btn_Adicionar);
            this.Controls.Add(this.btn_Adicionar);
            this.Controls.Add(this.btn_Remover);
            this.Controls.Add(this.lv_Fornecedores);
            this.Controls.Add(this.lbl_Saldo);
            this.Controls.Add(this.txtb_Saldo);
            this.Controls.Add(this.lbl_Custo);
            this.Controls.Add(this.txtb_Custo);
            this.Controls.Add(this.lbl_CodigoBarras);
            this.Controls.Add(this.txtb_CodigoBarras);
            this.Controls.Add(this.lbl_Referencia);
            this.Controls.Add(this.txtb_Referencia);
            this.Controls.Add(this.btn_PesquisarFornecedor);
            this.Controls.Add(this.txtb_Fornecedor);
            this.Controls.Add(this.lbl_CodigoFornecedor);
            this.Controls.Add(this.txtb_CodigoFornecedor);
            this.Controls.Add(this.lbl_Fornecedor);
            this.Controls.Add(this.btn_PesquisarSubGrupo);
            this.Controls.Add(this.txtb_SubGrupo);
            this.Controls.Add(this.lbl_CodigoSubGrupo);
            this.Controls.Add(this.txtb_CodigoSubGrupo);
            this.Controls.Add(this.lbl_SubGrupo);
            this.Controls.Add(this.txtb_Marca);
            this.Controls.Add(this.btn_PesquisarModelo);
            this.Controls.Add(this.lbl_Marca);
            this.Controls.Add(this.lbl_CodigoModelo);
            this.Controls.Add(this.txtb_CodigoModelo);
            this.Controls.Add(this.lbl_Modelo);
            this.Controls.Add(this.txtb_Modelo);
            this.Controls.Add(this.lbl_Unidade);
            this.Controls.Add(this.txtb_Unidade);
            this.Controls.Add(this.lbl_Produto);
            this.Controls.Add(this.txtb_Produto);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCadastroProdutos";
            this.Text = "Cadastro de Produtos";
            this.Controls.SetChildIndex(this.txtb_Produto, 0);
            this.Controls.SetChildIndex(this.lbl_Produto, 0);
            this.Controls.SetChildIndex(this.txtb_Unidade, 0);
            this.Controls.SetChildIndex(this.lbl_Unidade, 0);
            this.Controls.SetChildIndex(this.txtb_Modelo, 0);
            this.Controls.SetChildIndex(this.lbl_Modelo, 0);
            this.Controls.SetChildIndex(this.txtb_CodigoModelo, 0);
            this.Controls.SetChildIndex(this.lbl_CodigoModelo, 0);
            this.Controls.SetChildIndex(this.lbl_Marca, 0);
            this.Controls.SetChildIndex(this.btn_PesquisarModelo, 0);
            this.Controls.SetChildIndex(this.txtb_Marca, 0);
            this.Controls.SetChildIndex(this.lbl_SubGrupo, 0);
            this.Controls.SetChildIndex(this.txtb_CodigoSubGrupo, 0);
            this.Controls.SetChildIndex(this.lbl_CodigoSubGrupo, 0);
            this.Controls.SetChildIndex(this.txtb_SubGrupo, 0);
            this.Controls.SetChildIndex(this.btn_PesquisarSubGrupo, 0);
            this.Controls.SetChildIndex(this.lbl_Fornecedor, 0);
            this.Controls.SetChildIndex(this.txtb_CodigoFornecedor, 0);
            this.Controls.SetChildIndex(this.lbl_CodigoFornecedor, 0);
            this.Controls.SetChildIndex(this.txtb_Fornecedor, 0);
            this.Controls.SetChildIndex(this.btn_PesquisarFornecedor, 0);
            this.Controls.SetChildIndex(this.txtb_Referencia, 0);
            this.Controls.SetChildIndex(this.lbl_Referencia, 0);
            this.Controls.SetChildIndex(this.txtb_CodigoBarras, 0);
            this.Controls.SetChildIndex(this.lbl_CodigoBarras, 0);
            this.Controls.SetChildIndex(this.txtb_Custo, 0);
            this.Controls.SetChildIndex(this.lbl_Custo, 0);
            this.Controls.SetChildIndex(this.txtb_Saldo, 0);
            this.Controls.SetChildIndex(this.lbl_Saldo, 0);
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
            this.Controls.SetChildIndex(this.lv_Fornecedores, 0);
            this.Controls.SetChildIndex(this.btn_Remover, 0);
            this.Controls.SetChildIndex(this.btn_Adicionar, 0);
            this.Controls.SetChildIndex(this.lbl_btn_Adicionar, 0);
            this.Controls.SetChildIndex(this.lbl_btn_Pesquisar, 0);
            this.Controls.SetChildIndex(this.lbl_btn_Remover, 0);
            this.Controls.SetChildIndex(this.txtb_PrecoUltCompra, 0);
            this.Controls.SetChildIndex(this.lbl_PrecoUltCompra, 0);
            this.Controls.SetChildIndex(this.lbl_PesoBruto, 0);
            this.Controls.SetChildIndex(this.txtb_PesoLiquido, 0);
            this.Controls.SetChildIndex(this.lbl_PesoLiquido, 0);
            this.Controls.SetChildIndex(this.txtb_PesoBruto, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Produto;
        private System.Windows.Forms.TextBox txtb_Produto;
        private System.Windows.Forms.Label lbl_Unidade;
        private System.Windows.Forms.TextBox txtb_Unidade;
        private System.Windows.Forms.Label lbl_Modelo;
        private System.Windows.Forms.TextBox txtb_Modelo;
        private System.Windows.Forms.Label lbl_CodigoModelo;
        private System.Windows.Forms.TextBox txtb_CodigoModelo;
        private System.Windows.Forms.Label lbl_Marca;
        private System.Windows.Forms.Button btn_PesquisarModelo;
        private System.Windows.Forms.TextBox txtb_Marca;
        private System.Windows.Forms.Button btn_PesquisarSubGrupo;
        private System.Windows.Forms.TextBox txtb_SubGrupo;
        private System.Windows.Forms.Label lbl_CodigoSubGrupo;
        private System.Windows.Forms.TextBox txtb_CodigoSubGrupo;
        private System.Windows.Forms.Label lbl_SubGrupo;
        private System.Windows.Forms.Label lbl_Referencia;
        private System.Windows.Forms.TextBox txtb_Referencia;
        private System.Windows.Forms.Label lbl_CodigoBarras;
        private System.Windows.Forms.TextBox txtb_CodigoBarras;
        private System.Windows.Forms.Label lbl_Custo;
        private System.Windows.Forms.TextBox txtb_Custo;
        private System.Windows.Forms.Label lbl_Saldo;
        private System.Windows.Forms.TextBox txtb_Saldo;
        private System.Windows.Forms.Label lbl_Fornecedor;
        private System.Windows.Forms.TextBox txtb_CodigoFornecedor;
        private System.Windows.Forms.Label lbl_CodigoFornecedor;
        private System.Windows.Forms.TextBox txtb_Fornecedor;
        private System.Windows.Forms.Button btn_PesquisarFornecedor;
        private System.Windows.Forms.Button btn_Remover;
        private System.Windows.Forms.ListView lv_Fornecedores;
        private System.Windows.Forms.ColumnHeader ch_Codigo;
        private System.Windows.Forms.ColumnHeader ch_Fornecedor;
        private System.Windows.Forms.ColumnHeader ch_CNPJ;
        private System.Windows.Forms.Button btn_Adicionar;
        private System.Windows.Forms.Label lbl_btn_Adicionar;
        private System.Windows.Forms.Label lbl_btn_Pesquisar;
        private System.Windows.Forms.Label lbl_btn_Remover;
        private System.Windows.Forms.Label lbl_PrecoUltCompra;
        private System.Windows.Forms.TextBox txtb_PrecoUltCompra;
        private System.Windows.Forms.TextBox txtb_PesoLiquido;
        private System.Windows.Forms.Label lbl_PesoBruto;
        private System.Windows.Forms.Label lbl_PesoLiquido;
        private System.Windows.Forms.TextBox txtb_PesoBruto;
        private System.Windows.Forms.ColumnHeader ch_Email;
    }
}
