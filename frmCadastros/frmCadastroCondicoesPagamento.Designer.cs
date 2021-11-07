
namespace Projeto_ICI.frmCadastros
{
    partial class frmCadastroCondicoesPagamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastroCondicoesPagamento));
            this.txtb_CondicaoPag = new System.Windows.Forms.TextBox();
            this.lbl_CondicaoPag = new System.Windows.Forms.Label();
            this.lbl_TotalParcelas = new System.Windows.Forms.Label();
            this.txtb_TotalParcelas = new System.Windows.Forms.TextBox();
            this.lbl_TaxaJuros = new System.Windows.Forms.Label();
            this.txtb_TaxaJuros = new System.Windows.Forms.TextBox();
            this.lbl_Multa = new System.Windows.Forms.Label();
            this.txtb_Multa = new System.Windows.Forms.TextBox();
            this.lbl_Desconto = new System.Windows.Forms.Label();
            this.txtb_Desconto = new System.Windows.Forms.TextBox();
            this.lv_Parcelas = new System.Windows.Forms.ListView();
            this.ch_Numero = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Dias = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Porcentagem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_FormaPag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbl_Dias = new System.Windows.Forms.Label();
            this.txtb_Dias = new System.Windows.Forms.TextBox();
            this.lbl_Porcentagem = new System.Windows.Forms.Label();
            this.txtb_Porcentagem = new System.Windows.Forms.TextBox();
            this.lbl_FormaPag = new System.Windows.Forms.Label();
            this.txtb_FormaPag = new System.Windows.Forms.TextBox();
            this.btn_Adicionar = new System.Windows.Forms.Button();
            this.gb_Parcelas = new System.Windows.Forms.GroupBox();
            this.txtb_CodigoFormPag = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_PesquisarFormPagParc = new System.Windows.Forms.Button();
            this.btn_Remover = new System.Windows.Forms.Button();
            this.btn_Alterar = new System.Windows.Forms.Button();
            this.btn_Limpar = new System.Windows.Forms.Button();
            this.lbl_total = new System.Windows.Forms.Label();
            this.lbl_TotalDias = new System.Windows.Forms.Label();
            this.lbl_TotalPorc = new System.Windows.Forms.Label();
            this.btn_AutoParc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).BeginInit();
            this.gb_Parcelas.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtb_CodigoUsu
            // 
            this.txtb_CodigoUsu.Location = new System.Drawing.Point(24, 519);
            // 
            // lbl_CodigoUsu
            // 
            this.lbl_CodigoUsu.Location = new System.Drawing.Point(21, 501);
            // 
            // btn_Sair
            // 
            this.btn_Sair.Location = new System.Drawing.Point(431, 516);
            this.btn_Sair.TabIndex = 12;
            // 
            // btn_Cadastro
            // 
            this.btn_Cadastro.Location = new System.Drawing.Point(359, 515);
            this.btn_Cadastro.TabIndex = 11;
            this.btn_Cadastro.Click += new System.EventHandler(this.btn_Cadastro_Click);
            // 
            // lbl_UltAlt
            // 
            this.lbl_UltAlt.Location = new System.Drawing.Point(241, 500);
            // 
            // lbl_DataCad
            // 
            this.lbl_DataCad.Location = new System.Drawing.Point(126, 500);
            // 
            // txtb_DataCadastro
            // 
            this.txtb_DataCadastro.Location = new System.Drawing.Point(129, 518);
            // 
            // txtb_DataUltAlt
            // 
            this.txtb_DataUltAlt.Location = new System.Drawing.Point(244, 518);
            // 
            // txtb_CondicaoPag
            // 
            this.txtb_CondicaoPag.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtb_CondicaoPag.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_CondicaoPag.Location = new System.Drawing.Point(99, 36);
            this.txtb_CondicaoPag.Name = "txtb_CondicaoPag";
            this.txtb_CondicaoPag.Size = new System.Drawing.Size(293, 20);
            this.txtb_CondicaoPag.TabIndex = 1;
            this.txtb_CondicaoPag.Validating += new System.ComponentModel.CancelEventHandler(this.txtb_CondicaoPag_Validating);
            // 
            // lbl_CondicaoPag
            // 
            this.lbl_CondicaoPag.AutoSize = true;
            this.lbl_CondicaoPag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CondicaoPag.Location = new System.Drawing.Point(98, 18);
            this.lbl_CondicaoPag.Name = "lbl_CondicaoPag";
            this.lbl_CondicaoPag.Size = new System.Drawing.Size(131, 15);
            this.lbl_CondicaoPag.TabIndex = 11;
            this.lbl_CondicaoPag.Text = "Condição Pagamento*";
            // 
            // lbl_TotalParcelas
            // 
            this.lbl_TotalParcelas.AutoSize = true;
            this.lbl_TotalParcelas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TotalParcelas.Location = new System.Drawing.Point(18, 72);
            this.lbl_TotalParcelas.Name = "lbl_TotalParcelas";
            this.lbl_TotalParcelas.Size = new System.Drawing.Size(85, 15);
            this.lbl_TotalParcelas.TabIndex = 13;
            this.lbl_TotalParcelas.Text = "Total Parcelas";
            // 
            // txtb_TotalParcelas
            // 
            this.txtb_TotalParcelas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_TotalParcelas.Enabled = false;
            this.txtb_TotalParcelas.Location = new System.Drawing.Point(24, 90);
            this.txtb_TotalParcelas.Name = "txtb_TotalParcelas";
            this.txtb_TotalParcelas.Size = new System.Drawing.Size(102, 20);
            this.txtb_TotalParcelas.TabIndex = 2;
            this.txtb_TotalParcelas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl_TaxaJuros
            // 
            this.lbl_TaxaJuros.AutoSize = true;
            this.lbl_TaxaJuros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TaxaJuros.Location = new System.Drawing.Point(129, 72);
            this.lbl_TaxaJuros.Name = "lbl_TaxaJuros";
            this.lbl_TaxaJuros.Size = new System.Drawing.Size(72, 15);
            this.lbl_TaxaJuros.TabIndex = 15;
            this.lbl_TaxaJuros.Text = "Taxa Juros*";
            // 
            // txtb_TaxaJuros
            // 
            this.txtb_TaxaJuros.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_TaxaJuros.Location = new System.Drawing.Point(132, 90);
            this.txtb_TaxaJuros.Name = "txtb_TaxaJuros";
            this.txtb_TaxaJuros.Size = new System.Drawing.Size(87, 20);
            this.txtb_TaxaJuros.TabIndex = 3;
            this.txtb_TaxaJuros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtb_TaxaJuros.Validating += new System.ComponentModel.CancelEventHandler(this.txtb_TaxaJuros_Validating);
            // 
            // lbl_Multa
            // 
            this.lbl_Multa.AutoSize = true;
            this.lbl_Multa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Multa.Location = new System.Drawing.Point(222, 72);
            this.lbl_Multa.Name = "lbl_Multa";
            this.lbl_Multa.Size = new System.Drawing.Size(43, 15);
            this.lbl_Multa.TabIndex = 17;
            this.lbl_Multa.Text = "Multa*";
            // 
            // txtb_Multa
            // 
            this.txtb_Multa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Multa.Location = new System.Drawing.Point(225, 90);
            this.txtb_Multa.Name = "txtb_Multa";
            this.txtb_Multa.Size = new System.Drawing.Size(74, 20);
            this.txtb_Multa.TabIndex = 4;
            this.txtb_Multa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtb_Multa.Validating += new System.ComponentModel.CancelEventHandler(this.txtb_Multa_Validating);
            // 
            // lbl_Desconto
            // 
            this.lbl_Desconto.AutoSize = true;
            this.lbl_Desconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Desconto.Location = new System.Drawing.Point(302, 72);
            this.lbl_Desconto.Name = "lbl_Desconto";
            this.lbl_Desconto.Size = new System.Drawing.Size(59, 15);
            this.lbl_Desconto.TabIndex = 19;
            this.lbl_Desconto.Text = "Desconto";
            // 
            // txtb_Desconto
            // 
            this.txtb_Desconto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Desconto.Location = new System.Drawing.Point(305, 90);
            this.txtb_Desconto.Name = "txtb_Desconto";
            this.txtb_Desconto.Size = new System.Drawing.Size(87, 20);
            this.txtb_Desconto.TabIndex = 5;
            this.txtb_Desconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtb_Desconto.Validating += new System.ComponentModel.CancelEventHandler(this.txtb_Desconto_Validating);
            // 
            // lv_Parcelas
            // 
            this.lv_Parcelas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_Numero,
            this.ch_Dias,
            this.ch_Porcentagem,
            this.ch_FormaPag});
            this.lv_Parcelas.FullRowSelect = true;
            this.lv_Parcelas.GridLines = true;
            this.lv_Parcelas.HideSelection = false;
            this.lv_Parcelas.Location = new System.Drawing.Point(24, 228);
            this.lv_Parcelas.MultiSelect = false;
            this.lv_Parcelas.Name = "lv_Parcelas";
            this.lv_Parcelas.Size = new System.Drawing.Size(464, 234);
            this.lv_Parcelas.TabIndex = 21;
            this.lv_Parcelas.UseCompatibleStateImageBehavior = false;
            this.lv_Parcelas.View = System.Windows.Forms.View.Details;
            // 
            // ch_Numero
            // 
            this.ch_Numero.Text = "Número";
            // 
            // ch_Dias
            // 
            this.ch_Dias.Text = "Dias";
            this.ch_Dias.Width = 80;
            // 
            // ch_Porcentagem
            // 
            this.ch_Porcentagem.Text = "Porcentagem(%)";
            this.ch_Porcentagem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ch_Porcentagem.Width = 100;
            // 
            // ch_FormaPag
            // 
            this.ch_FormaPag.Text = "Forma Pagamento";
            this.ch_FormaPag.Width = 200;
            // 
            // lbl_Dias
            // 
            this.lbl_Dias.AutoSize = true;
            this.lbl_Dias.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Dias.Location = new System.Drawing.Point(3, 19);
            this.lbl_Dias.Name = "lbl_Dias";
            this.lbl_Dias.Size = new System.Drawing.Size(32, 15);
            this.lbl_Dias.TabIndex = 23;
            this.lbl_Dias.Text = "Dias";
            // 
            // txtb_Dias
            // 
            this.txtb_Dias.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Dias.Location = new System.Drawing.Point(6, 37);
            this.txtb_Dias.Name = "txtb_Dias";
            this.txtb_Dias.Size = new System.Drawing.Size(52, 20);
            this.txtb_Dias.TabIndex = 6;
            this.txtb_Dias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtb_Dias.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtb_Dias_KeyPress);
            this.txtb_Dias.Validating += new System.ComponentModel.CancelEventHandler(this.txtb_Dias_Validating_1);
            // 
            // lbl_Porcentagem
            // 
            this.lbl_Porcentagem.AutoSize = true;
            this.lbl_Porcentagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Porcentagem.Location = new System.Drawing.Point(67, 18);
            this.lbl_Porcentagem.Name = "lbl_Porcentagem";
            this.lbl_Porcentagem.Size = new System.Drawing.Size(100, 15);
            this.lbl_Porcentagem.TabIndex = 34;
            this.lbl_Porcentagem.Text = "Porcentagem(%)";
            // 
            // txtb_Porcentagem
            // 
            this.txtb_Porcentagem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_Porcentagem.Location = new System.Drawing.Point(64, 36);
            this.txtb_Porcentagem.Name = "txtb_Porcentagem";
            this.txtb_Porcentagem.Size = new System.Drawing.Size(120, 20);
            this.txtb_Porcentagem.TabIndex = 7;
            this.txtb_Porcentagem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl_FormaPag
            // 
            this.lbl_FormaPag.AutoSize = true;
            this.lbl_FormaPag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FormaPag.Location = new System.Drawing.Point(249, 18);
            this.lbl_FormaPag.Name = "lbl_FormaPag";
            this.lbl_FormaPag.Size = new System.Drawing.Size(109, 15);
            this.lbl_FormaPag.TabIndex = 32;
            this.lbl_FormaPag.Text = "Forma pagamento";
            // 
            // txtb_FormaPag
            // 
            this.txtb_FormaPag.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtb_FormaPag.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtb_FormaPag.Enabled = false;
            this.txtb_FormaPag.Location = new System.Drawing.Point(252, 36);
            this.txtb_FormaPag.Name = "txtb_FormaPag";
            this.txtb_FormaPag.Size = new System.Drawing.Size(141, 20);
            this.txtb_FormaPag.TabIndex = 7;
            // 
            // btn_Adicionar
            // 
            this.btn_Adicionar.Location = new System.Drawing.Point(24, 199);
            this.btn_Adicionar.Name = "btn_Adicionar";
            this.btn_Adicionar.Size = new System.Drawing.Size(63, 23);
            this.btn_Adicionar.TabIndex = 10;
            this.btn_Adicionar.Text = "Adicionar";
            this.btn_Adicionar.UseVisualStyleBackColor = true;
            this.btn_Adicionar.Click += new System.EventHandler(this.btn_Adicionar_Click);
            // 
            // gb_Parcelas
            // 
            this.gb_Parcelas.Controls.Add(this.txtb_CodigoFormPag);
            this.gb_Parcelas.Controls.Add(this.label1);
            this.gb_Parcelas.Controls.Add(this.btn_PesquisarFormPagParc);
            this.gb_Parcelas.Controls.Add(this.txtb_Dias);
            this.gb_Parcelas.Controls.Add(this.lbl_Dias);
            this.gb_Parcelas.Controls.Add(this.lbl_Porcentagem);
            this.gb_Parcelas.Controls.Add(this.txtb_FormaPag);
            this.gb_Parcelas.Controls.Add(this.txtb_Porcentagem);
            this.gb_Parcelas.Controls.Add(this.lbl_FormaPag);
            this.gb_Parcelas.Location = new System.Drawing.Point(24, 126);
            this.gb_Parcelas.Name = "gb_Parcelas";
            this.gb_Parcelas.Size = new System.Drawing.Size(436, 67);
            this.gb_Parcelas.TabIndex = 37;
            this.gb_Parcelas.TabStop = false;
            this.gb_Parcelas.Text = "Parcelas";
            // 
            // txtb_CodigoFormPag
            // 
            this.txtb_CodigoFormPag.Location = new System.Drawing.Point(190, 36);
            this.txtb_CodigoFormPag.Name = "txtb_CodigoFormPag";
            this.txtb_CodigoFormPag.Size = new System.Drawing.Size(56, 20);
            this.txtb_CodigoFormPag.TabIndex = 8;
            this.txtb_CodigoFormPag.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtb_CodigoFormPag.TextChanged += new System.EventHandler(this.txtb_CodigoFormPag_TextChanged);
            this.txtb_CodigoFormPag.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtb_CodigoFormPag_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(187, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 46;
            this.label1.Text = "Código";
            // 
            // btn_PesquisarFormPagParc
            // 
            this.btn_PesquisarFormPagParc.Location = new System.Drawing.Point(399, 33);
            this.btn_PesquisarFormPagParc.Name = "btn_PesquisarFormPagParc";
            this.btn_PesquisarFormPagParc.Size = new System.Drawing.Size(26, 25);
            this.btn_PesquisarFormPagParc.TabIndex = 9;
            this.btn_PesquisarFormPagParc.UseVisualStyleBackColor = true;
            this.btn_PesquisarFormPagParc.Click += new System.EventHandler(this.btn_PesquisarFormPagParc_Click);
            this.btn_PesquisarFormPagParc.MouseEnter += new System.EventHandler(this.btn_PesquisarFormPagParc_MouseEnter);
            this.btn_PesquisarFormPagParc.MouseLeave += new System.EventHandler(this.btn_PesquisarFormPagParc_MouseLeave);
            // 
            // btn_Remover
            // 
            this.btn_Remover.Location = new System.Drawing.Point(197, 199);
            this.btn_Remover.Name = "btn_Remover";
            this.btn_Remover.Size = new System.Drawing.Size(63, 23);
            this.btn_Remover.TabIndex = 14;
            this.btn_Remover.Text = "Remover";
            this.btn_Remover.UseVisualStyleBackColor = true;
            this.btn_Remover.Click += new System.EventHandler(this.btn_Remover_Click);
            // 
            // btn_Alterar
            // 
            this.btn_Alterar.Location = new System.Drawing.Point(112, 199);
            this.btn_Alterar.Name = "btn_Alterar";
            this.btn_Alterar.Size = new System.Drawing.Size(63, 23);
            this.btn_Alterar.TabIndex = 13;
            this.btn_Alterar.Text = "Alterar";
            this.btn_Alterar.UseVisualStyleBackColor = true;
            this.btn_Alterar.Click += new System.EventHandler(this.btn_Alterar_Click);
            // 
            // btn_Limpar
            // 
            this.btn_Limpar.Location = new System.Drawing.Point(286, 199);
            this.btn_Limpar.Name = "btn_Limpar";
            this.btn_Limpar.Size = new System.Drawing.Size(63, 23);
            this.btn_Limpar.TabIndex = 15;
            this.btn_Limpar.Text = "Limpar";
            this.btn_Limpar.UseVisualStyleBackColor = true;
            this.btn_Limpar.Click += new System.EventHandler(this.btn_Limpar_Click);
            // 
            // lbl_total
            // 
            this.lbl_total.AutoSize = true;
            this.lbl_total.Location = new System.Drawing.Point(24, 469);
            this.lbl_total.Name = "lbl_total";
            this.lbl_total.Size = new System.Drawing.Size(34, 13);
            this.lbl_total.TabIndex = 41;
            this.lbl_total.Text = "Total:";
            // 
            // lbl_TotalDias
            // 
            this.lbl_TotalDias.AutoSize = true;
            this.lbl_TotalDias.Location = new System.Drawing.Point(91, 469);
            this.lbl_TotalDias.Name = "lbl_TotalDias";
            this.lbl_TotalDias.Size = new System.Drawing.Size(13, 13);
            this.lbl_TotalDias.TabIndex = 42;
            this.lbl_TotalDias.Text = "0";
            // 
            // lbl_TotalPorc
            // 
            this.lbl_TotalPorc.AutoSize = true;
            this.lbl_TotalPorc.Location = new System.Drawing.Point(170, 469);
            this.lbl_TotalPorc.Name = "lbl_TotalPorc";
            this.lbl_TotalPorc.Size = new System.Drawing.Size(21, 13);
            this.lbl_TotalPorc.TabIndex = 43;
            this.lbl_TotalPorc.Text = "0%";
            // 
            // btn_AutoParc
            // 
            this.btn_AutoParc.Location = new System.Drawing.Point(426, 199);
            this.btn_AutoParc.Name = "btn_AutoParc";
            this.btn_AutoParc.Size = new System.Drawing.Size(62, 23);
            this.btn_AutoParc.TabIndex = 16;
            this.btn_AutoParc.Text = "Auto";
            this.btn_AutoParc.UseVisualStyleBackColor = true;
            this.btn_AutoParc.Visible = false;
            this.btn_AutoParc.Click += new System.EventHandler(this.btn_AutoParc_Click);
            // 
            // frmCadastroCondicoesPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(509, 553);
            this.Controls.Add(this.btn_AutoParc);
            this.Controls.Add(this.lbl_TotalPorc);
            this.Controls.Add(this.lbl_TotalDias);
            this.Controls.Add(this.lbl_total);
            this.Controls.Add(this.btn_Limpar);
            this.Controls.Add(this.btn_Alterar);
            this.Controls.Add(this.btn_Remover);
            this.Controls.Add(this.gb_Parcelas);
            this.Controls.Add(this.btn_Adicionar);
            this.Controls.Add(this.lv_Parcelas);
            this.Controls.Add(this.lbl_Desconto);
            this.Controls.Add(this.txtb_Desconto);
            this.Controls.Add(this.lbl_Multa);
            this.Controls.Add(this.txtb_Multa);
            this.Controls.Add(this.lbl_TaxaJuros);
            this.Controls.Add(this.txtb_TaxaJuros);
            this.Controls.Add(this.lbl_TotalParcelas);
            this.Controls.Add(this.txtb_TotalParcelas);
            this.Controls.Add(this.lbl_CondicaoPag);
            this.Controls.Add(this.txtb_CondicaoPag);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCadastroCondicoesPagamento";
            this.Opacity = 0.95D;
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Cadastro de Condições de pagamento";
            this.Controls.SetChildIndex(this.txtb_CondicaoPag, 0);
            this.Controls.SetChildIndex(this.lbl_CondicaoPag, 0);
            this.Controls.SetChildIndex(this.txtb_TotalParcelas, 0);
            this.Controls.SetChildIndex(this.lbl_TotalParcelas, 0);
            this.Controls.SetChildIndex(this.txtb_TaxaJuros, 0);
            this.Controls.SetChildIndex(this.lbl_TaxaJuros, 0);
            this.Controls.SetChildIndex(this.txtb_Multa, 0);
            this.Controls.SetChildIndex(this.lbl_Multa, 0);
            this.Controls.SetChildIndex(this.txtb_Desconto, 0);
            this.Controls.SetChildIndex(this.lbl_Desconto, 0);
            this.Controls.SetChildIndex(this.lv_Parcelas, 0);
            this.Controls.SetChildIndex(this.btn_Adicionar, 0);
            this.Controls.SetChildIndex(this.gb_Parcelas, 0);
            this.Controls.SetChildIndex(this.btn_Remover, 0);
            this.Controls.SetChildIndex(this.btn_Alterar, 0);
            this.Controls.SetChildIndex(this.btn_Limpar, 0);
            this.Controls.SetChildIndex(this.lbl_total, 0);
            this.Controls.SetChildIndex(this.lbl_TotalDias, 0);
            this.Controls.SetChildIndex(this.lbl_TotalPorc, 0);
            this.Controls.SetChildIndex(this.btn_AutoParc, 0);
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
            ((System.ComponentModel.ISupportInitialize)(this.errorMSG)).EndInit();
            this.gb_Parcelas.ResumeLayout(false);
            this.gb_Parcelas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtb_CondicaoPag;
        private System.Windows.Forms.Label lbl_CondicaoPag;
        private System.Windows.Forms.Label lbl_TotalParcelas;
        private System.Windows.Forms.TextBox txtb_TotalParcelas;
        private System.Windows.Forms.Label lbl_TaxaJuros;
        private System.Windows.Forms.TextBox txtb_TaxaJuros;
        private System.Windows.Forms.Label lbl_Multa;
        private System.Windows.Forms.TextBox txtb_Multa;
        private System.Windows.Forms.Label lbl_Desconto;
        private System.Windows.Forms.TextBox txtb_Desconto;
        private System.Windows.Forms.ListView lv_Parcelas;
        private System.Windows.Forms.ColumnHeader ch_Numero;
        private System.Windows.Forms.ColumnHeader ch_Dias;
        private System.Windows.Forms.Label lbl_Dias;
        private System.Windows.Forms.TextBox txtb_Dias;
        private System.Windows.Forms.Label lbl_Porcentagem;
        private System.Windows.Forms.TextBox txtb_Porcentagem;
        private System.Windows.Forms.Label lbl_FormaPag;
        private System.Windows.Forms.TextBox txtb_FormaPag;
        private System.Windows.Forms.Button btn_Adicionar;
        private System.Windows.Forms.GroupBox gb_Parcelas;
        private System.Windows.Forms.Button btn_Remover;
        private System.Windows.Forms.Button btn_Alterar;
        private System.Windows.Forms.Button btn_Limpar;
        private System.Windows.Forms.Label lbl_total;
        private System.Windows.Forms.Label lbl_TotalDias;
        private System.Windows.Forms.Label lbl_TotalPorc;
        private System.Windows.Forms.ColumnHeader ch_Porcentagem;
        private System.Windows.Forms.ColumnHeader ch_FormaPag;
        private System.Windows.Forms.Button btn_PesquisarFormPagParc;
        protected System.Windows.Forms.TextBox txtb_CodigoFormPag;
        protected System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_AutoParc;
    }
}
