
namespace Projeto_ICI.frmCadastros
{
    partial class frmCadastroVendas
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
            this.btn_Gerar = new System.Windows.Forms.Button();
            this.btn_Limpar = new System.Windows.Forms.Button();
            this.dt_Chegada = new System.Windows.Forms.DateTimePicker();
            this.dt_Emissao = new System.Windows.Forms.DateTimePicker();
            this.lbl_Transpotadora = new System.Windows.Forms.Label();
            this.txtb_Transport = new System.Windows.Forms.TextBox();
            this.lbl_CodigoTransportadora = new System.Windows.Forms.Label();
            this.txtb_CodigoTransport = new System.Windows.Forms.TextBox();
            this.txtb_CodigoCondPag = new System.Windows.Forms.TextBox();
            this.lbl_CodigoCondPag = new System.Windows.Forms.Label();
            this.btn_PesquisarCondPag = new System.Windows.Forms.Button();
            this.lbl_CondicaoPag = new System.Windows.Forms.Label();
            this.txtb_CondicaoPag = new System.Windows.Forms.TextBox();
            this.lbl_CodigoCliente = new System.Windows.Forms.Label();
            this.txtb_CodigoCliente = new System.Windows.Forms.TextBox();
            this.btn_PesquisaTransportadora = new System.Windows.Forms.Button();
            this.groupBox_Produtos = new System.Windows.Forms.GroupBox();
            this.lbl_Total = new System.Windows.Forms.Label();
            this.txtb_Total = new System.Windows.Forms.TextBox();
            this.lbl_Unidade = new System.Windows.Forms.Label();
            this.lbl_Desconto = new System.Windows.Forms.Label();
            this.txtb_Unidade = new System.Windows.Forms.TextBox();
            this.txtb_Desconto = new System.Windows.Forms.TextBox();
            this.lv_ItensCompra = new System.Windows.Forms.ListView();
            this.ch_Produto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Un = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Quantidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Preco = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Desconto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_SubTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_Remover = new System.Windows.Forms.Button();
            this.btn_Adicionar = new System.Windows.Forms.Button();
            this.lbl_Quantidade = new System.Windows.Forms.Label();
            this.btn_PesquisarProduto = new System.Windows.Forms.Button();
            this.lbl_PrecoUnt = new System.Windows.Forms.Label();
            this.txtb_PrecoUnt = new System.Windows.Forms.TextBox();
            this.lbl_Produto = new System.Windows.Forms.Label();
            this.txtb_Quantidade = new System.Windows.Forms.TextBox();
            this.txtb_Produto = new System.Windows.Forms.TextBox();
            this.lbl_CodigoProduto = new System.Windows.Forms.Label();
            this.txtb_CodigoProduto = new System.Windows.Forms.TextBox();
            this.lbl_DataSaida = new System.Windows.Forms.Label();
            this.btn_PesquisarFornecedor = new System.Windows.Forms.Button();
            this.lbl_DataEmissao = new System.Windows.Forms.Label();
            this.lbl_Cliente = new System.Windows.Forms.Label();
            this.txtb_Fornecedor = new System.Windows.Forms.TextBox();
            this.lbl_NumNF = new System.Windows.Forms.Label();
            this.txtb_NumNF = new System.Windows.Forms.TextBox();
            this.lbl_Modelo = new System.Windows.Forms.Label();
            this.lbl_Serie = new System.Windows.Forms.Label();
            this.txtb_Modelo = new System.Windows.Forms.TextBox();
            this.txtb_Serie = new System.Windows.Forms.TextBox();
            this.btn_Sair = new System.Windows.Forms.Button();
            this.btn_Salvar = new System.Windows.Forms.Button();
            this.lbl_CodigoUsu = new System.Windows.Forms.Label();
            this.txtb_CodigoUsu = new System.Windows.Forms.TextBox();
            this.lbl_ContasReceber = new System.Windows.Forms.Label();
            this.lv_ParcelasContasPag = new System.Windows.Forms.ListView();
            this.ch_Parcela = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_FormaPag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Vencimento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Pagamento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_ValorTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_ValorPago = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).BeginInit();
            this.groupBox_Produtos.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Gerar
            // 
            this.btn_Gerar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Gerar.Location = new System.Drawing.Point(380, 551);
            this.btn_Gerar.Name = "btn_Gerar";
            this.btn_Gerar.Size = new System.Drawing.Size(75, 23);
            this.btn_Gerar.TabIndex = 170;
            this.btn_Gerar.Text = "Gerar";
            this.btn_Gerar.UseVisualStyleBackColor = true;
            this.btn_Gerar.Click += new System.EventHandler(this.btn_Gerar_Click);
            // 
            // btn_Limpar
            // 
            this.btn_Limpar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Limpar.Location = new System.Drawing.Point(284, 551);
            this.btn_Limpar.Name = "btn_Limpar";
            this.btn_Limpar.Size = new System.Drawing.Size(75, 23);
            this.btn_Limpar.TabIndex = 171;
            this.btn_Limpar.Text = "Limpar";
            this.btn_Limpar.UseVisualStyleBackColor = true;
            this.btn_Limpar.Visible = false;
            this.btn_Limpar.Click += new System.EventHandler(this.btn_Limpar_Click);
            // 
            // dt_Chegada
            // 
            this.dt_Chegada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_Chegada.Location = new System.Drawing.Point(127, 71);
            this.dt_Chegada.Name = "dt_Chegada";
            this.dt_Chegada.Size = new System.Drawing.Size(107, 20);
            this.dt_Chegada.TabIndex = 162;
            this.dt_Chegada.Validating += new System.ComponentModel.CancelEventHandler(this.dt_Chegada_Validating);
            // 
            // dt_Emissao
            // 
            this.dt_Emissao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_Emissao.Location = new System.Drawing.Point(14, 71);
            this.dt_Emissao.Name = "dt_Emissao";
            this.dt_Emissao.Size = new System.Drawing.Size(107, 20);
            this.dt_Emissao.TabIndex = 161;
            this.dt_Emissao.Validating += new System.ComponentModel.CancelEventHandler(this.dt_Emissao_Validating);
            // 
            // lbl_Transpotadora
            // 
            this.lbl_Transpotadora.AutoSize = true;
            this.lbl_Transpotadora.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Transpotadora.Location = new System.Drawing.Point(80, 342);
            this.lbl_Transpotadora.Name = "lbl_Transpotadora";
            this.lbl_Transpotadora.Size = new System.Drawing.Size(91, 15);
            this.lbl_Transpotadora.TabIndex = 180;
            this.lbl_Transpotadora.Text = "Transportadora";
            // 
            // txtb_Transport
            // 
            this.txtb_Transport.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Transport.Enabled = false;
            this.txtb_Transport.Location = new System.Drawing.Point(83, 360);
            this.txtb_Transport.Name = "txtb_Transport";
            this.txtb_Transport.Size = new System.Drawing.Size(195, 20);
            this.txtb_Transport.TabIndex = 179;
            // 
            // lbl_CodigoTransportadora
            // 
            this.lbl_CodigoTransportadora.AutoSize = true;
            this.lbl_CodigoTransportadora.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CodigoTransportadora.Location = new System.Drawing.Point(11, 342);
            this.lbl_CodigoTransportadora.Name = "lbl_CodigoTransportadora";
            this.lbl_CodigoTransportadora.Size = new System.Drawing.Size(46, 15);
            this.lbl_CodigoTransportadora.TabIndex = 178;
            this.lbl_CodigoTransportadora.Text = "Código";
            // 
            // txtb_CodigoTransport
            // 
            this.txtb_CodigoTransport.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_CodigoTransport.Location = new System.Drawing.Point(14, 360);
            this.txtb_CodigoTransport.Name = "txtb_CodigoTransport";
            this.txtb_CodigoTransport.Size = new System.Drawing.Size(63, 20);
            this.txtb_CodigoTransport.TabIndex = 163;
            this.txtb_CodigoTransport.TextChanged += new System.EventHandler(this.txtb_CodigoTransport_TextChanged);
            this.txtb_CodigoTransport.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtb_CodigoTransport_KeyPress);
            // 
            // txtb_CodigoCondPag
            // 
            this.txtb_CodigoCondPag.Location = new System.Drawing.Point(357, 363);
            this.txtb_CodigoCondPag.Name = "txtb_CodigoCondPag";
            this.txtb_CodigoCondPag.Size = new System.Drawing.Size(63, 20);
            this.txtb_CodigoCondPag.TabIndex = 165;
            this.txtb_CodigoCondPag.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtb_CodigoCondPag.TextChanged += new System.EventHandler(this.txtb_CodigoCondPag_TextChanged);
            this.txtb_CodigoCondPag.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtb_CodigoCondPag_KeyPress);
            // 
            // lbl_CodigoCondPag
            // 
            this.lbl_CodigoCondPag.AutoSize = true;
            this.lbl_CodigoCondPag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CodigoCondPag.Location = new System.Drawing.Point(354, 345);
            this.lbl_CodigoCondPag.Name = "lbl_CodigoCondPag";
            this.lbl_CodigoCondPag.Size = new System.Drawing.Size(51, 15);
            this.lbl_CodigoCondPag.TabIndex = 174;
            this.lbl_CodigoCondPag.Text = "Código*";
            // 
            // btn_PesquisarCondPag
            // 
            this.btn_PesquisarCondPag.Location = new System.Drawing.Point(624, 359);
            this.btn_PesquisarCondPag.Name = "btn_PesquisarCondPag";
            this.btn_PesquisarCondPag.Size = new System.Drawing.Size(26, 25);
            this.btn_PesquisarCondPag.TabIndex = 166;
            this.btn_PesquisarCondPag.UseVisualStyleBackColor = true;
            this.btn_PesquisarCondPag.Click += new System.EventHandler(this.btn_PesquisarCondPag_Click);
            // 
            // lbl_CondicaoPag
            // 
            this.lbl_CondicaoPag.AutoSize = true;
            this.lbl_CondicaoPag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CondicaoPag.Location = new System.Drawing.Point(423, 345);
            this.lbl_CondicaoPag.Name = "lbl_CondicaoPag";
            this.lbl_CondicaoPag.Size = new System.Drawing.Size(148, 15);
            this.lbl_CondicaoPag.TabIndex = 173;
            this.lbl_CondicaoPag.Text = "Condição de Pagamento*";
            // 
            // txtb_CondicaoPag
            // 
            this.txtb_CondicaoPag.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_CondicaoPag.Enabled = false;
            this.txtb_CondicaoPag.Location = new System.Drawing.Point(426, 363);
            this.txtb_CondicaoPag.Name = "txtb_CondicaoPag";
            this.txtb_CondicaoPag.Size = new System.Drawing.Size(192, 20);
            this.txtb_CondicaoPag.TabIndex = 172;
            // 
            // lbl_CodigoCliente
            // 
            this.lbl_CodigoCliente.AutoSize = true;
            this.lbl_CodigoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CodigoCliente.Location = new System.Drawing.Point(269, 10);
            this.lbl_CodigoCliente.Name = "lbl_CodigoCliente";
            this.lbl_CodigoCliente.Size = new System.Drawing.Size(51, 15);
            this.lbl_CodigoCliente.TabIndex = 189;
            this.lbl_CodigoCliente.Text = "Código*";
            // 
            // txtb_CodigoCliente
            // 
            this.txtb_CodigoCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_CodigoCliente.Location = new System.Drawing.Point(272, 28);
            this.txtb_CodigoCliente.Name = "txtb_CodigoCliente";
            this.txtb_CodigoCliente.Size = new System.Drawing.Size(72, 20);
            this.txtb_CodigoCliente.TabIndex = 159;
            this.txtb_CodigoCliente.TextChanged += new System.EventHandler(this.txtb_CodigoFornecedor_TextChanged);
            this.txtb_CodigoCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtb_CodigoFornecedor_KeyPress);
            // 
            // btn_PesquisaTransportadora
            // 
            this.btn_PesquisaTransportadora.Location = new System.Drawing.Point(281, 358);
            this.btn_PesquisaTransportadora.Name = "btn_PesquisaTransportadora";
            this.btn_PesquisaTransportadora.Size = new System.Drawing.Size(26, 25);
            this.btn_PesquisaTransportadora.TabIndex = 164;
            this.btn_PesquisaTransportadora.UseVisualStyleBackColor = true;
            this.btn_PesquisaTransportadora.Click += new System.EventHandler(this.btn_PesquisaTransportadora_Click);
            // 
            // groupBox_Produtos
            // 
            this.groupBox_Produtos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Produtos.Controls.Add(this.lbl_Total);
            this.groupBox_Produtos.Controls.Add(this.txtb_Total);
            this.groupBox_Produtos.Controls.Add(this.lbl_Unidade);
            this.groupBox_Produtos.Controls.Add(this.lbl_Desconto);
            this.groupBox_Produtos.Controls.Add(this.txtb_Unidade);
            this.groupBox_Produtos.Controls.Add(this.txtb_Desconto);
            this.groupBox_Produtos.Controls.Add(this.lv_ItensCompra);
            this.groupBox_Produtos.Controls.Add(this.btn_Remover);
            this.groupBox_Produtos.Controls.Add(this.btn_Adicionar);
            this.groupBox_Produtos.Controls.Add(this.lbl_Quantidade);
            this.groupBox_Produtos.Controls.Add(this.btn_PesquisarProduto);
            this.groupBox_Produtos.Controls.Add(this.lbl_PrecoUnt);
            this.groupBox_Produtos.Controls.Add(this.txtb_PrecoUnt);
            this.groupBox_Produtos.Controls.Add(this.lbl_Produto);
            this.groupBox_Produtos.Controls.Add(this.txtb_Quantidade);
            this.groupBox_Produtos.Controls.Add(this.txtb_Produto);
            this.groupBox_Produtos.Controls.Add(this.lbl_CodigoProduto);
            this.groupBox_Produtos.Controls.Add(this.txtb_CodigoProduto);
            this.groupBox_Produtos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Produtos.Location = new System.Drawing.Point(14, 96);
            this.groupBox_Produtos.Name = "groupBox_Produtos";
            this.groupBox_Produtos.Size = new System.Drawing.Size(646, 243);
            this.groupBox_Produtos.TabIndex = 188;
            this.groupBox_Produtos.TabStop = false;
            this.groupBox_Produtos.Text = "Produtos";
            // 
            // lbl_Total
            // 
            this.lbl_Total.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Total.AutoSize = true;
            this.lbl_Total.Location = new System.Drawing.Point(537, 198);
            this.lbl_Total.Name = "lbl_Total";
            this.lbl_Total.Size = new System.Drawing.Size(34, 15);
            this.lbl_Total.TabIndex = 153;
            this.lbl_Total.Text = "Total";
            // 
            // txtb_Total
            // 
            this.txtb_Total.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtb_Total.Enabled = false;
            this.txtb_Total.Location = new System.Drawing.Point(540, 216);
            this.txtb_Total.Name = "txtb_Total";
            this.txtb_Total.Size = new System.Drawing.Size(100, 21);
            this.txtb_Total.TabIndex = 152;
            this.txtb_Total.Text = "0";
            this.txtb_Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl_Unidade
            // 
            this.lbl_Unidade.AutoSize = true;
            this.lbl_Unidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Unidade.Location = new System.Drawing.Point(276, 19);
            this.lbl_Unidade.Name = "lbl_Unidade";
            this.lbl_Unidade.Size = new System.Drawing.Size(54, 15);
            this.lbl_Unidade.TabIndex = 111;
            this.lbl_Unidade.Text = "Unidade";
            // 
            // lbl_Desconto
            // 
            this.lbl_Desconto.AutoSize = true;
            this.lbl_Desconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Desconto.Location = new System.Drawing.Point(561, 19);
            this.lbl_Desconto.Name = "lbl_Desconto";
            this.lbl_Desconto.Size = new System.Drawing.Size(59, 15);
            this.lbl_Desconto.TabIndex = 114;
            this.lbl_Desconto.Text = "Desconto";
            // 
            // txtb_Unidade
            // 
            this.txtb_Unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Unidade.Enabled = false;
            this.txtb_Unidade.Location = new System.Drawing.Point(279, 37);
            this.txtb_Unidade.Name = "txtb_Unidade";
            this.txtb_Unidade.Size = new System.Drawing.Size(58, 21);
            this.txtb_Unidade.TabIndex = 9;
            // 
            // txtb_Desconto
            // 
            this.txtb_Desconto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Desconto.Location = new System.Drawing.Point(564, 37);
            this.txtb_Desconto.Name = "txtb_Desconto";
            this.txtb_Desconto.Size = new System.Drawing.Size(76, 21);
            this.txtb_Desconto.TabIndex = 12;
            this.txtb_Desconto.Text = "0";
            this.txtb_Desconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtb_Desconto.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
            // 
            // lv_ItensCompra
            // 
            this.lv_ItensCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lv_ItensCompra.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_Produto,
            this.ch_Un,
            this.ch_Quantidade,
            this.ch_Preco,
            this.ch_Desconto,
            this.ch_SubTotal});
            this.lv_ItensCompra.FullRowSelect = true;
            this.lv_ItensCompra.GridLines = true;
            this.lv_ItensCompra.HideSelection = false;
            this.lv_ItensCompra.Location = new System.Drawing.Point(6, 64);
            this.lv_ItensCompra.MultiSelect = false;
            this.lv_ItensCompra.Name = "lv_ItensCompra";
            this.lv_ItensCompra.Size = new System.Drawing.Size(634, 130);
            this.lv_ItensCompra.TabIndex = 73;
            this.lv_ItensCompra.UseCompatibleStateImageBehavior = false;
            this.lv_ItensCompra.View = System.Windows.Forms.View.Details;
            // 
            // ch_Produto
            // 
            this.ch_Produto.Text = "Produto";
            this.ch_Produto.Width = 250;
            // 
            // ch_Un
            // 
            this.ch_Un.Text = "UND";
            // 
            // ch_Quantidade
            // 
            this.ch_Quantidade.Text = "Quant.";
            // 
            // ch_Preco
            // 
            this.ch_Preco.Text = "Preço";
            this.ch_Preco.Width = 80;
            // 
            // ch_Desconto
            // 
            this.ch_Desconto.Text = "Desconto";
            this.ch_Desconto.Width = 80;
            // 
            // ch_SubTotal
            // 
            this.ch_SubTotal.Text = "Sub Total";
            this.ch_SubTotal.Width = 80;
            // 
            // btn_Remover
            // 
            this.btn_Remover.Location = new System.Drawing.Point(447, 214);
            this.btn_Remover.Name = "btn_Remover";
            this.btn_Remover.Size = new System.Drawing.Size(75, 23);
            this.btn_Remover.TabIndex = 15;
            this.btn_Remover.Text = "Remover";
            this.btn_Remover.UseVisualStyleBackColor = true;
            this.btn_Remover.Click += new System.EventHandler(this.btn_Remover_Click);
            // 
            // btn_Adicionar
            // 
            this.btn_Adicionar.Location = new System.Drawing.Point(366, 214);
            this.btn_Adicionar.Name = "btn_Adicionar";
            this.btn_Adicionar.Size = new System.Drawing.Size(75, 23);
            this.btn_Adicionar.TabIndex = 13;
            this.btn_Adicionar.Text = "Adicionar";
            this.btn_Adicionar.UseVisualStyleBackColor = true;
            this.btn_Adicionar.Click += new System.EventHandler(this.btn_Adicionar_Click);
            // 
            // lbl_Quantidade
            // 
            this.lbl_Quantidade.AutoSize = true;
            this.lbl_Quantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Quantidade.Location = new System.Drawing.Point(495, 17);
            this.lbl_Quantidade.Name = "lbl_Quantidade";
            this.lbl_Quantidade.Size = new System.Drawing.Size(45, 15);
            this.lbl_Quantidade.TabIndex = 80;
            this.lbl_Quantidade.Text = "Quant*";
            // 
            // btn_PesquisarProduto
            // 
            this.btn_PesquisarProduto.Location = new System.Drawing.Point(465, 33);
            this.btn_PesquisarProduto.Name = "btn_PesquisarProduto";
            this.btn_PesquisarProduto.Size = new System.Drawing.Size(26, 25);
            this.btn_PesquisarProduto.TabIndex = 8;
            this.btn_PesquisarProduto.UseVisualStyleBackColor = true;
            this.btn_PesquisarProduto.Click += new System.EventHandler(this.btn_PesquisarProduto_Click);
            // 
            // lbl_PrecoUnt
            // 
            this.lbl_PrecoUnt.AutoSize = true;
            this.lbl_PrecoUnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PrecoUnt.Location = new System.Drawing.Point(340, 19);
            this.lbl_PrecoUnt.Name = "lbl_PrecoUnt";
            this.lbl_PrecoUnt.Size = new System.Drawing.Size(39, 15);
            this.lbl_PrecoUnt.TabIndex = 78;
            this.lbl_PrecoUnt.Text = "Preço";
            // 
            // txtb_PrecoUnt
            // 
            this.txtb_PrecoUnt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_PrecoUnt.Location = new System.Drawing.Point(343, 37);
            this.txtb_PrecoUnt.Name = "txtb_PrecoUnt";
            this.txtb_PrecoUnt.ReadOnly = true;
            this.txtb_PrecoUnt.Size = new System.Drawing.Size(116, 21);
            this.txtb_PrecoUnt.TabIndex = 11;
            this.txtb_PrecoUnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl_Produto
            // 
            this.lbl_Produto.AutoSize = true;
            this.lbl_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Produto.Location = new System.Drawing.Point(67, 19);
            this.lbl_Produto.Name = "lbl_Produto";
            this.lbl_Produto.Size = new System.Drawing.Size(50, 15);
            this.lbl_Produto.TabIndex = 76;
            this.lbl_Produto.Text = "Produto";
            // 
            // txtb_Quantidade
            // 
            this.txtb_Quantidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Quantidade.Location = new System.Drawing.Point(498, 37);
            this.txtb_Quantidade.Name = "txtb_Quantidade";
            this.txtb_Quantidade.Size = new System.Drawing.Size(60, 21);
            this.txtb_Quantidade.TabIndex = 10;
            this.txtb_Quantidade.Tag = "";
            this.txtb_Quantidade.Text = "0";
            this.txtb_Quantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtb_Quantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtb_Quantidade_KeyPress);
            this.txtb_Quantidade.Validating += new System.ComponentModel.CancelEventHandler(this.txtb_Quantidade_Validating);
            // 
            // txtb_Produto
            // 
            this.txtb_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Produto.Location = new System.Drawing.Point(70, 37);
            this.txtb_Produto.Name = "txtb_Produto";
            this.txtb_Produto.ReadOnly = true;
            this.txtb_Produto.Size = new System.Drawing.Size(203, 21);
            this.txtb_Produto.TabIndex = 75;
            // 
            // lbl_CodigoProduto
            // 
            this.lbl_CodigoProduto.AutoSize = true;
            this.lbl_CodigoProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CodigoProduto.Location = new System.Drawing.Point(3, 19);
            this.lbl_CodigoProduto.Name = "lbl_CodigoProduto";
            this.lbl_CodigoProduto.Size = new System.Drawing.Size(51, 15);
            this.lbl_CodigoProduto.TabIndex = 74;
            this.lbl_CodigoProduto.Text = "Código*";
            // 
            // txtb_CodigoProduto
            // 
            this.txtb_CodigoProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_CodigoProduto.Location = new System.Drawing.Point(6, 37);
            this.txtb_CodigoProduto.Name = "txtb_CodigoProduto";
            this.txtb_CodigoProduto.Size = new System.Drawing.Size(58, 21);
            this.txtb_CodigoProduto.TabIndex = 7;
            this.txtb_CodigoProduto.TextChanged += new System.EventHandler(this.txtb_CodigoProduto_TextChanged);
            this.txtb_CodigoProduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtb_CodigoProduto_KeyPress);
            // 
            // lbl_DataSaida
            // 
            this.lbl_DataSaida.AutoSize = true;
            this.lbl_DataSaida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DataSaida.Location = new System.Drawing.Point(124, 53);
            this.lbl_DataSaida.Name = "lbl_DataSaida";
            this.lbl_DataSaida.Size = new System.Drawing.Size(73, 15);
            this.lbl_DataSaida.TabIndex = 187;
            this.lbl_DataSaida.Text = "Data Saída*";
            // 
            // btn_PesquisarFornecedor
            // 
            this.btn_PesquisarFornecedor.Location = new System.Drawing.Point(541, 25);
            this.btn_PesquisarFornecedor.Name = "btn_PesquisarFornecedor";
            this.btn_PesquisarFornecedor.Size = new System.Drawing.Size(26, 25);
            this.btn_PesquisarFornecedor.TabIndex = 160;
            this.btn_PesquisarFornecedor.UseVisualStyleBackColor = true;
            this.btn_PesquisarFornecedor.Click += new System.EventHandler(this.btn_PesquisarFornecedor_Click);
            // 
            // lbl_DataEmissao
            // 
            this.lbl_DataEmissao.AutoSize = true;
            this.lbl_DataEmissao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DataEmissao.Location = new System.Drawing.Point(11, 53);
            this.lbl_DataEmissao.Name = "lbl_DataEmissao";
            this.lbl_DataEmissao.Size = new System.Drawing.Size(89, 15);
            this.lbl_DataEmissao.TabIndex = 186;
            this.lbl_DataEmissao.Text = "Data Emissão*";
            // 
            // lbl_Cliente
            // 
            this.lbl_Cliente.AutoSize = true;
            this.lbl_Cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Cliente.Location = new System.Drawing.Point(347, 10);
            this.lbl_Cliente.Name = "lbl_Cliente";
            this.lbl_Cliente.Size = new System.Drawing.Size(45, 15);
            this.lbl_Cliente.TabIndex = 185;
            this.lbl_Cliente.Text = "Cliente";
            // 
            // txtb_Fornecedor
            // 
            this.txtb_Fornecedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Fornecedor.Enabled = false;
            this.txtb_Fornecedor.Location = new System.Drawing.Point(350, 28);
            this.txtb_Fornecedor.Name = "txtb_Fornecedor";
            this.txtb_Fornecedor.Size = new System.Drawing.Size(185, 20);
            this.txtb_Fornecedor.TabIndex = 184;
            this.txtb_Fornecedor.TextChanged += new System.EventHandler(this.txtb_Fornecedor_TextChanged);
            // 
            // lbl_NumNF
            // 
            this.lbl_NumNF.AutoSize = true;
            this.lbl_NumNF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NumNF.Location = new System.Drawing.Point(159, 10);
            this.lbl_NumNF.Name = "lbl_NumNF";
            this.lbl_NumNF.Size = new System.Drawing.Size(76, 15);
            this.lbl_NumNF.TabIndex = 183;
            this.lbl_NumNF.Text = "Número NF*";
            // 
            // txtb_NumNF
            // 
            this.txtb_NumNF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_NumNF.Location = new System.Drawing.Point(160, 28);
            this.txtb_NumNF.Name = "txtb_NumNF";
            this.txtb_NumNF.Size = new System.Drawing.Size(106, 20);
            this.txtb_NumNF.TabIndex = 158;
            this.txtb_NumNF.TextChanged += new System.EventHandler(this.txtb_NumNF_TextChanged);
            this.txtb_NumNF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtb_NumNF_KeyPress);
            // 
            // lbl_Modelo
            // 
            this.lbl_Modelo.AutoSize = true;
            this.lbl_Modelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Modelo.Location = new System.Drawing.Point(14, 10);
            this.lbl_Modelo.Name = "lbl_Modelo";
            this.lbl_Modelo.Size = new System.Drawing.Size(54, 15);
            this.lbl_Modelo.TabIndex = 182;
            this.lbl_Modelo.Text = "Modelo*";
            // 
            // lbl_Serie
            // 
            this.lbl_Serie.AutoSize = true;
            this.lbl_Serie.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Serie.Location = new System.Drawing.Point(98, 10);
            this.lbl_Serie.Name = "lbl_Serie";
            this.lbl_Serie.Size = new System.Drawing.Size(41, 15);
            this.lbl_Serie.TabIndex = 181;
            this.lbl_Serie.Text = "Serie*";
            // 
            // txtb_Modelo
            // 
            this.txtb_Modelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Modelo.Location = new System.Drawing.Point(14, 28);
            this.txtb_Modelo.Name = "txtb_Modelo";
            this.txtb_Modelo.Size = new System.Drawing.Size(76, 20);
            this.txtb_Modelo.TabIndex = 156;
            this.txtb_Modelo.TextChanged += new System.EventHandler(this.txtb_Modelo_TextChanged);
            // 
            // txtb_Serie
            // 
            this.txtb_Serie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Serie.Location = new System.Drawing.Point(96, 28);
            this.txtb_Serie.Name = "txtb_Serie";
            this.txtb_Serie.Size = new System.Drawing.Size(57, 20);
            this.txtb_Serie.TabIndex = 157;
            this.txtb_Serie.TextChanged += new System.EventHandler(this.txtb_Serie_TextChanged);
            // 
            // btn_Sair
            // 
            this.btn_Sair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Sair.Location = new System.Drawing.Point(580, 551);
            this.btn_Sair.Name = "btn_Sair";
            this.btn_Sair.Size = new System.Drawing.Size(75, 23);
            this.btn_Sair.TabIndex = 194;
            this.btn_Sair.Text = "Sair";
            this.btn_Sair.UseVisualStyleBackColor = true;
            this.btn_Sair.Click += new System.EventHandler(this.btn_Sair_Click);
            // 
            // btn_Salvar
            // 
            this.btn_Salvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Salvar.Location = new System.Drawing.Point(479, 551);
            this.btn_Salvar.Name = "btn_Salvar";
            this.btn_Salvar.Size = new System.Drawing.Size(75, 23);
            this.btn_Salvar.TabIndex = 193;
            this.btn_Salvar.Text = "Salvar";
            this.btn_Salvar.UseVisualStyleBackColor = true;
            this.btn_Salvar.Click += new System.EventHandler(this.btn_Salvar_Click);
            // 
            // lbl_CodigoUsu
            // 
            this.lbl_CodigoUsu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_CodigoUsu.AutoSize = true;
            this.lbl_CodigoUsu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CodigoUsu.Location = new System.Drawing.Point(11, 541);
            this.lbl_CodigoUsu.Name = "lbl_CodigoUsu";
            this.lbl_CodigoUsu.Size = new System.Drawing.Size(74, 15);
            this.lbl_CodigoUsu.TabIndex = 199;
            this.lbl_CodigoUsu.Text = "Código Usu.";
            // 
            // txtb_CodigoUsu
            // 
            this.txtb_CodigoUsu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtb_CodigoUsu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_CodigoUsu.Enabled = false;
            this.txtb_CodigoUsu.Location = new System.Drawing.Point(14, 559);
            this.txtb_CodigoUsu.Name = "txtb_CodigoUsu";
            this.txtb_CodigoUsu.Size = new System.Drawing.Size(71, 20);
            this.txtb_CodigoUsu.TabIndex = 198;
            // 
            // lbl_ContasReceber
            // 
            this.lbl_ContasReceber.AutoSize = true;
            this.lbl_ContasReceber.Location = new System.Drawing.Point(11, 388);
            this.lbl_ContasReceber.Name = "lbl_ContasReceber";
            this.lbl_ContasReceber.Size = new System.Drawing.Size(88, 13);
            this.lbl_ContasReceber.TabIndex = 195;
            this.lbl_ContasReceber.Text = "Contas a receber";
            // 
            // lv_ParcelasContasPag
            // 
            this.lv_ParcelasContasPag.AllowColumnReorder = true;
            this.lv_ParcelasContasPag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lv_ParcelasContasPag.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_Parcela,
            this.ch_FormaPag,
            this.ch_Vencimento,
            this.ch_Pagamento,
            this.ch_ValorTotal,
            this.ch_ValorPago});
            this.lv_ParcelasContasPag.GridLines = true;
            this.lv_ParcelasContasPag.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv_ParcelasContasPag.HideSelection = false;
            this.lv_ParcelasContasPag.Location = new System.Drawing.Point(14, 404);
            this.lv_ParcelasContasPag.MultiSelect = false;
            this.lv_ParcelasContasPag.Name = "lv_ParcelasContasPag";
            this.lv_ParcelasContasPag.Size = new System.Drawing.Size(640, 131);
            this.lv_ParcelasContasPag.TabIndex = 200;
            this.lv_ParcelasContasPag.UseCompatibleStateImageBehavior = false;
            this.lv_ParcelasContasPag.View = System.Windows.Forms.View.Details;
            this.lv_ParcelasContasPag.EnabledChanged += new System.EventHandler(this.groupBox_Produtos_EnabledChanged);
            this.lv_ParcelasContasPag.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lv_ParcelasContasPag_MouseClick);
            // 
            // ch_Parcela
            // 
            this.ch_Parcela.Text = "Parcela";
            // 
            // ch_FormaPag
            // 
            this.ch_FormaPag.Text = "Forma Pagamento";
            this.ch_FormaPag.Width = 150;
            // 
            // ch_Vencimento
            // 
            this.ch_Vencimento.Text = "Vencimento";
            this.ch_Vencimento.Width = 80;
            // 
            // ch_Pagamento
            // 
            this.ch_Pagamento.Text = "Pagamento";
            this.ch_Pagamento.Width = 80;
            // 
            // ch_ValorTotal
            // 
            this.ch_ValorTotal.Text = "Valor Parcela";
            this.ch_ValorTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ch_ValorTotal.Width = 100;
            // 
            // ch_ValorPago
            // 
            this.ch_ValorPago.Text = "Valor Pago";
            this.ch_ValorPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ch_ValorPago.Width = 100;
            // 
            // frmCadastroVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(679, 584);
            this.Controls.Add(this.lv_ParcelasContasPag);
            this.Controls.Add(this.btn_Sair);
            this.Controls.Add(this.btn_Salvar);
            this.Controls.Add(this.lbl_CodigoUsu);
            this.Controls.Add(this.txtb_CodigoUsu);
            this.Controls.Add(this.lbl_ContasReceber);
            this.Controls.Add(this.btn_Gerar);
            this.Controls.Add(this.btn_Limpar);
            this.Controls.Add(this.dt_Chegada);
            this.Controls.Add(this.dt_Emissao);
            this.Controls.Add(this.lbl_Transpotadora);
            this.Controls.Add(this.txtb_Transport);
            this.Controls.Add(this.lbl_CodigoTransportadora);
            this.Controls.Add(this.txtb_CodigoTransport);
            this.Controls.Add(this.txtb_CodigoCondPag);
            this.Controls.Add(this.lbl_CodigoCondPag);
            this.Controls.Add(this.btn_PesquisarCondPag);
            this.Controls.Add(this.lbl_CondicaoPag);
            this.Controls.Add(this.txtb_CondicaoPag);
            this.Controls.Add(this.lbl_CodigoCliente);
            this.Controls.Add(this.txtb_CodigoCliente);
            this.Controls.Add(this.btn_PesquisaTransportadora);
            this.Controls.Add(this.groupBox_Produtos);
            this.Controls.Add(this.lbl_DataSaida);
            this.Controls.Add(this.btn_PesquisarFornecedor);
            this.Controls.Add(this.lbl_DataEmissao);
            this.Controls.Add(this.lbl_Cliente);
            this.Controls.Add(this.txtb_Fornecedor);
            this.Controls.Add(this.lbl_NumNF);
            this.Controls.Add(this.txtb_NumNF);
            this.Controls.Add(this.lbl_Modelo);
            this.Controls.Add(this.lbl_Serie);
            this.Controls.Add(this.txtb_Modelo);
            this.Controls.Add(this.txtb_Serie);
            this.Name = "frmCadastroVendas";
            this.Text = "Cadastro de Vendas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCadastroVendas_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).EndInit();
            this.groupBox_Produtos.ResumeLayout(false);
            this.groupBox_Produtos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Gerar;
        private System.Windows.Forms.Button btn_Limpar;
        private System.Windows.Forms.DateTimePicker dt_Chegada;
        private System.Windows.Forms.DateTimePicker dt_Emissao;
        private System.Windows.Forms.Label lbl_Transpotadora;
        private System.Windows.Forms.TextBox txtb_Transport;
        private System.Windows.Forms.Label lbl_CodigoTransportadora;
        private System.Windows.Forms.TextBox txtb_CodigoTransport;
        protected System.Windows.Forms.TextBox txtb_CodigoCondPag;
        protected System.Windows.Forms.Label lbl_CodigoCondPag;
        private System.Windows.Forms.Button btn_PesquisarCondPag;
        private System.Windows.Forms.Label lbl_CondicaoPag;
        private System.Windows.Forms.TextBox txtb_CondicaoPag;
        private System.Windows.Forms.Label lbl_CodigoCliente;
        private System.Windows.Forms.TextBox txtb_CodigoCliente;
        private System.Windows.Forms.Button btn_PesquisaTransportadora;
        private System.Windows.Forms.GroupBox groupBox_Produtos;
        private System.Windows.Forms.Label lbl_Total;
        private System.Windows.Forms.TextBox txtb_Total;
        private System.Windows.Forms.Label lbl_Unidade;
        private System.Windows.Forms.Label lbl_Desconto;
        private System.Windows.Forms.TextBox txtb_Unidade;
        private System.Windows.Forms.TextBox txtb_Desconto;
        private System.Windows.Forms.ListView lv_ItensCompra;
        private System.Windows.Forms.ColumnHeader ch_Produto;
        private System.Windows.Forms.ColumnHeader ch_Un;
        private System.Windows.Forms.ColumnHeader ch_Quantidade;
        private System.Windows.Forms.ColumnHeader ch_Preco;
        private System.Windows.Forms.ColumnHeader ch_Desconto;
        private System.Windows.Forms.ColumnHeader ch_SubTotal;
        private System.Windows.Forms.Button btn_Remover;
        private System.Windows.Forms.Button btn_Adicionar;
        private System.Windows.Forms.Label lbl_Quantidade;
        private System.Windows.Forms.TextBox txtb_Quantidade;
        private System.Windows.Forms.Label lbl_PrecoUnt;
        private System.Windows.Forms.TextBox txtb_PrecoUnt;
        private System.Windows.Forms.Button btn_PesquisarProduto;
        private System.Windows.Forms.Label lbl_Produto;
        private System.Windows.Forms.TextBox txtb_Produto;
        private System.Windows.Forms.Label lbl_CodigoProduto;
        private System.Windows.Forms.TextBox txtb_CodigoProduto;
        private System.Windows.Forms.Label lbl_DataSaida;
        private System.Windows.Forms.Button btn_PesquisarFornecedor;
        private System.Windows.Forms.Label lbl_DataEmissao;
        private System.Windows.Forms.Label lbl_Cliente;
        private System.Windows.Forms.TextBox txtb_Fornecedor;
        private System.Windows.Forms.Label lbl_NumNF;
        private System.Windows.Forms.TextBox txtb_NumNF;
        private System.Windows.Forms.Label lbl_Modelo;
        private System.Windows.Forms.Label lbl_Serie;
        private System.Windows.Forms.TextBox txtb_Modelo;
        private System.Windows.Forms.TextBox txtb_Serie;
        private System.Windows.Forms.Button btn_Sair;
        private System.Windows.Forms.Button btn_Salvar;
        private System.Windows.Forms.Label lbl_CodigoUsu;
        private System.Windows.Forms.TextBox txtb_CodigoUsu;
        private System.Windows.Forms.Label lbl_ContasReceber;
        private System.Windows.Forms.ListView lv_ParcelasContasPag;
        private System.Windows.Forms.ColumnHeader ch_Parcela;
        private System.Windows.Forms.ColumnHeader ch_FormaPag;
        private System.Windows.Forms.ColumnHeader ch_Vencimento;
        private System.Windows.Forms.ColumnHeader ch_Pagamento;
        private System.Windows.Forms.ColumnHeader ch_ValorTotal;
        private System.Windows.Forms.ColumnHeader ch_ValorPago;
    }
}
