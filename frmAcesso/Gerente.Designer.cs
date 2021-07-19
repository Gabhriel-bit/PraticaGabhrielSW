
namespace Projeto_ICI
{
    partial class Gerente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gerente));
            this.menu_Principal = new System.Windows.Forms.MenuStrip();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnItem_Cargos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnItem_Cidades = new System.Windows.Forms.ToolStripMenuItem();
            this.mnItem_Clientes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnItem_CondicoesPagamento = new System.Windows.Forms.ToolStripMenuItem();
            this.mnItem_Depositos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnItem_Estados = new System.Windows.Forms.ToolStripMenuItem();
            this.mnItem_FormasPagamento = new System.Windows.Forms.ToolStripMenuItem();
            this.mnItem_Fornecedores = new System.Windows.Forms.ToolStripMenuItem();
            this.mnItem_Funcionarios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnItem_Grupos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnItem_Marcas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnItem_Modelos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnItem_Produtos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnItem_Paises = new System.Windows.Forms.ToolStripMenuItem();
            this.mnItem_Subgrupos = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.condiçõesDePagamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.depositosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formasDePagamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fornecedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funcionáriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gruposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marcasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modelosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paisesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subgruposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Principal.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu_Principal
            // 
            this.menu_Principal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.menu_Principal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultasToolStripMenuItem,
            this.cadastrosToolStripMenuItem});
            this.menu_Principal.Location = new System.Drawing.Point(0, 0);
            this.menu_Principal.Name = "menu_Principal";
            this.menu_Principal.Size = new System.Drawing.Size(740, 29);
            this.menu_Principal.TabIndex = 4;
            this.menu_Principal.Text = "menuStrip1";
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnItem_Cargos,
            this.mnItem_Cidades,
            this.mnItem_Clientes,
            this.mnItem_CondicoesPagamento,
            this.mnItem_Depositos,
            this.mnItem_Estados,
            this.mnItem_FormasPagamento,
            this.mnItem_Fornecedores,
            this.mnItem_Funcionarios,
            this.mnItem_Grupos,
            this.mnItem_Marcas,
            this.mnItem_Modelos,
            this.mnItem_Produtos,
            this.mnItem_Paises,
            this.mnItem_Subgrupos});
            this.consultasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("consultasToolStripMenuItem.Image")));
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(106, 25);
            this.consultasToolStripMenuItem.Text = "Consultas";
            // 
            // mnItem_Cargos
            // 
            this.mnItem_Cargos.Name = "mnItem_Cargos";
            this.mnItem_Cargos.Size = new System.Drawing.Size(255, 26);
            this.mnItem_Cargos.Text = "&Cargos";
            this.mnItem_Cargos.Click += new System.EventHandler(this.mnItem_Cargos_Click);
            // 
            // mnItem_Cidades
            // 
            this.mnItem_Cidades.Name = "mnItem_Cidades";
            this.mnItem_Cidades.Size = new System.Drawing.Size(255, 26);
            this.mnItem_Cidades.Text = "&Cidades";
            this.mnItem_Cidades.Click += new System.EventHandler(this.mnItem_Cidades_Click);
            // 
            // mnItem_Clientes
            // 
            this.mnItem_Clientes.Name = "mnItem_Clientes";
            this.mnItem_Clientes.Size = new System.Drawing.Size(255, 26);
            this.mnItem_Clientes.Text = "&Clientes";
            this.mnItem_Clientes.Click += new System.EventHandler(this.mnItem_Clientes_Click);
            // 
            // mnItem_CondicoesPagamento
            // 
            this.mnItem_CondicoesPagamento.Name = "mnItem_CondicoesPagamento";
            this.mnItem_CondicoesPagamento.Size = new System.Drawing.Size(255, 26);
            this.mnItem_CondicoesPagamento.Text = "&Condições de Pagamento";
            this.mnItem_CondicoesPagamento.Click += new System.EventHandler(this.mnItem_CondicoesPagamento_Click);
            // 
            // mnItem_Depositos
            // 
            this.mnItem_Depositos.Name = "mnItem_Depositos";
            this.mnItem_Depositos.Size = new System.Drawing.Size(255, 26);
            this.mnItem_Depositos.Text = "&Depositos";
            this.mnItem_Depositos.Click += new System.EventHandler(this.mnItem_Depositos_Click);
            // 
            // mnItem_Estados
            // 
            this.mnItem_Estados.Name = "mnItem_Estados";
            this.mnItem_Estados.Size = new System.Drawing.Size(255, 26);
            this.mnItem_Estados.Text = "&Estados";
            this.mnItem_Estados.Click += new System.EventHandler(this.mnItem_Estados_Click);
            // 
            // mnItem_FormasPagamento
            // 
            this.mnItem_FormasPagamento.Name = "mnItem_FormasPagamento";
            this.mnItem_FormasPagamento.Size = new System.Drawing.Size(255, 26);
            this.mnItem_FormasPagamento.Text = "&Formas de Pagamento";
            this.mnItem_FormasPagamento.Click += new System.EventHandler(this.mnItem_FormasPagamento_Click);
            // 
            // mnItem_Fornecedores
            // 
            this.mnItem_Fornecedores.Name = "mnItem_Fornecedores";
            this.mnItem_Fornecedores.Size = new System.Drawing.Size(255, 26);
            this.mnItem_Fornecedores.Text = "&Fornecedores";
            this.mnItem_Fornecedores.Click += new System.EventHandler(this.mnItem_Fornecedores_Click);
            // 
            // mnItem_Funcionarios
            // 
            this.mnItem_Funcionarios.Name = "mnItem_Funcionarios";
            this.mnItem_Funcionarios.Size = new System.Drawing.Size(255, 26);
            this.mnItem_Funcionarios.Text = "&Funcionários";
            this.mnItem_Funcionarios.Click += new System.EventHandler(this.mnItem_Funcionarios_Click);
            // 
            // mnItem_Grupos
            // 
            this.mnItem_Grupos.Name = "mnItem_Grupos";
            this.mnItem_Grupos.Size = new System.Drawing.Size(255, 26);
            this.mnItem_Grupos.Text = "&Grupos";
            this.mnItem_Grupos.Click += new System.EventHandler(this.mnItem_Grupos_Click);
            // 
            // mnItem_Marcas
            // 
            this.mnItem_Marcas.Name = "mnItem_Marcas";
            this.mnItem_Marcas.Size = new System.Drawing.Size(255, 26);
            this.mnItem_Marcas.Text = "&Marcas";
            this.mnItem_Marcas.Click += new System.EventHandler(this.mnItem_Marcas_Click);
            // 
            // mnItem_Modelos
            // 
            this.mnItem_Modelos.Name = "mnItem_Modelos";
            this.mnItem_Modelos.Size = new System.Drawing.Size(255, 26);
            this.mnItem_Modelos.Text = "&Modelos";
            this.mnItem_Modelos.Click += new System.EventHandler(this.mnItem_Modelos_Click);
            // 
            // mnItem_Produtos
            // 
            this.mnItem_Produtos.Name = "mnItem_Produtos";
            this.mnItem_Produtos.Size = new System.Drawing.Size(255, 26);
            this.mnItem_Produtos.Text = "&Produtos";
            this.mnItem_Produtos.Click += new System.EventHandler(this.mnItem_Produtos_Click);
            // 
            // mnItem_Paises
            // 
            this.mnItem_Paises.Name = "mnItem_Paises";
            this.mnItem_Paises.Size = new System.Drawing.Size(255, 26);
            this.mnItem_Paises.Text = "&Paises";
            this.mnItem_Paises.Click += new System.EventHandler(this.mnItem_Paises_Click);
            // 
            // mnItem_Subgrupos
            // 
            this.mnItem_Subgrupos.Name = "mnItem_Subgrupos";
            this.mnItem_Subgrupos.Size = new System.Drawing.Size(255, 26);
            this.mnItem_Subgrupos.Text = "&Subgrupos";
            this.mnItem_Subgrupos.Click += new System.EventHandler(this.mnItem_Subgrupos_Click);
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargosToolStripMenuItem,
            this.cidadesToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.condiçõesDePagamentoToolStripMenuItem,
            this.depositosToolStripMenuItem,
            this.estadosToolStripMenuItem,
            this.formasDePagamentoToolStripMenuItem,
            this.fornecedoresToolStripMenuItem,
            this.funcionáriosToolStripMenuItem,
            this.gruposToolStripMenuItem,
            this.marcasToolStripMenuItem,
            this.modelosToolStripMenuItem,
            this.produtosToolStripMenuItem,
            this.paisesToolStripMenuItem,
            this.subgruposToolStripMenuItem});
            this.cadastrosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cadastrosToolStripMenuItem.Image")));
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(107, 25);
            this.cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // cargosToolStripMenuItem
            // 
            this.cargosToolStripMenuItem.Name = "cargosToolStripMenuItem";
            this.cargosToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.cargosToolStripMenuItem.Text = "&Cargos";
            this.cargosToolStripMenuItem.Click += new System.EventHandler(this.cargosToolStripMenuItem_Click);
            // 
            // cidadesToolStripMenuItem
            // 
            this.cidadesToolStripMenuItem.Name = "cidadesToolStripMenuItem";
            this.cidadesToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.cidadesToolStripMenuItem.Text = "&Cidades";
            this.cidadesToolStripMenuItem.Click += new System.EventHandler(this.cidadesToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.clientesToolStripMenuItem.Text = "&Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // condiçõesDePagamentoToolStripMenuItem
            // 
            this.condiçõesDePagamentoToolStripMenuItem.Name = "condiçõesDePagamentoToolStripMenuItem";
            this.condiçõesDePagamentoToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.condiçõesDePagamentoToolStripMenuItem.Text = "&Condições de Pagamento";
            this.condiçõesDePagamentoToolStripMenuItem.Click += new System.EventHandler(this.condiçõesDePagamentoToolStripMenuItem_Click);
            // 
            // depositosToolStripMenuItem
            // 
            this.depositosToolStripMenuItem.Name = "depositosToolStripMenuItem";
            this.depositosToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.depositosToolStripMenuItem.Text = "&Depositos";
            this.depositosToolStripMenuItem.Click += new System.EventHandler(this.depositosToolStripMenuItem_Click);
            // 
            // estadosToolStripMenuItem
            // 
            this.estadosToolStripMenuItem.Name = "estadosToolStripMenuItem";
            this.estadosToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.estadosToolStripMenuItem.Text = "&Estados";
            this.estadosToolStripMenuItem.Click += new System.EventHandler(this.estadosToolStripMenuItem_Click);
            // 
            // formasDePagamentoToolStripMenuItem
            // 
            this.formasDePagamentoToolStripMenuItem.Name = "formasDePagamentoToolStripMenuItem";
            this.formasDePagamentoToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.formasDePagamentoToolStripMenuItem.Text = "&Formas de Pagamento";
            this.formasDePagamentoToolStripMenuItem.Click += new System.EventHandler(this.formasDePagamentoToolStripMenuItem_Click);
            // 
            // fornecedoresToolStripMenuItem
            // 
            this.fornecedoresToolStripMenuItem.Name = "fornecedoresToolStripMenuItem";
            this.fornecedoresToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.fornecedoresToolStripMenuItem.Text = "&Fornecedores";
            this.fornecedoresToolStripMenuItem.Click += new System.EventHandler(this.fornecedoresToolStripMenuItem_Click);
            // 
            // funcionáriosToolStripMenuItem
            // 
            this.funcionáriosToolStripMenuItem.Name = "funcionáriosToolStripMenuItem";
            this.funcionáriosToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.funcionáriosToolStripMenuItem.Text = "&Funcionários";
            this.funcionáriosToolStripMenuItem.Click += new System.EventHandler(this.funcionáriosToolStripMenuItem_Click);
            // 
            // gruposToolStripMenuItem
            // 
            this.gruposToolStripMenuItem.Name = "gruposToolStripMenuItem";
            this.gruposToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.gruposToolStripMenuItem.Text = "&Grupos";
            this.gruposToolStripMenuItem.Click += new System.EventHandler(this.gruposToolStripMenuItem_Click);
            // 
            // marcasToolStripMenuItem
            // 
            this.marcasToolStripMenuItem.Name = "marcasToolStripMenuItem";
            this.marcasToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.marcasToolStripMenuItem.Text = "&Marcas";
            this.marcasToolStripMenuItem.Click += new System.EventHandler(this.marcasToolStripMenuItem_Click);
            // 
            // modelosToolStripMenuItem
            // 
            this.modelosToolStripMenuItem.Name = "modelosToolStripMenuItem";
            this.modelosToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.modelosToolStripMenuItem.Text = "&Modelos";
            this.modelosToolStripMenuItem.Click += new System.EventHandler(this.modelosToolStripMenuItem_Click);
            // 
            // produtosToolStripMenuItem
            // 
            this.produtosToolStripMenuItem.Name = "produtosToolStripMenuItem";
            this.produtosToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.produtosToolStripMenuItem.Text = "&Produtos";
            this.produtosToolStripMenuItem.Click += new System.EventHandler(this.produtosToolStripMenuItem_Click);
            // 
            // paisesToolStripMenuItem
            // 
            this.paisesToolStripMenuItem.Name = "paisesToolStripMenuItem";
            this.paisesToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.paisesToolStripMenuItem.Text = "&Paises";
            this.paisesToolStripMenuItem.Click += new System.EventHandler(this.paisesToolStripMenuItem_Click);
            // 
            // subgruposToolStripMenuItem
            // 
            this.subgruposToolStripMenuItem.Name = "subgruposToolStripMenuItem";
            this.subgruposToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.subgruposToolStripMenuItem.Text = "&Subgrupos";
            this.subgruposToolStripMenuItem.Click += new System.EventHandler(this.subgruposToolStripMenuItem_Click);
            // 
            // Gerente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 388);
            this.Controls.Add(this.menu_Principal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu_Principal;
            this.Name = "Gerente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "C. L. COMÉRCIO DE CARTUCHOS E INSUMOS PARA IMPRESSORAS LTDA.";
            this.menu_Principal.ResumeLayout(false);
            this.menu_Principal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menu_Principal;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnItem_Cargos;
        private System.Windows.Forms.ToolStripMenuItem mnItem_Cidades;
        private System.Windows.Forms.ToolStripMenuItem mnItem_Clientes;
        private System.Windows.Forms.ToolStripMenuItem mnItem_CondicoesPagamento;
        private System.Windows.Forms.ToolStripMenuItem mnItem_Depositos;
        private System.Windows.Forms.ToolStripMenuItem mnItem_Estados;
        private System.Windows.Forms.ToolStripMenuItem mnItem_FormasPagamento;
        private System.Windows.Forms.ToolStripMenuItem mnItem_Fornecedores;
        private System.Windows.Forms.ToolStripMenuItem mnItem_Funcionarios;
        private System.Windows.Forms.ToolStripMenuItem mnItem_Grupos;
        private System.Windows.Forms.ToolStripMenuItem mnItem_Marcas;
        private System.Windows.Forms.ToolStripMenuItem mnItem_Modelos;
        private System.Windows.Forms.ToolStripMenuItem mnItem_Produtos;
        private System.Windows.Forms.ToolStripMenuItem mnItem_Paises;
        private System.Windows.Forms.ToolStripMenuItem mnItem_Subgrupos;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem condiçõesDePagamentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem depositosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formasDePagamentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fornecedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem funcionáriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gruposToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marcasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modelosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paisesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subgruposToolStripMenuItem;
    }
}

