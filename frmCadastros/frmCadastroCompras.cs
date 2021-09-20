using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_ICI.frmComprasVendas
{
    public partial class frmCadastroCompras : Projeto_ICI.formularioBase
    {
        public frmCadastroCompras()
        {
            InitializeComponent();

            groupBox_Produtos.Enabled = true;
            btn_PesquisarFornecedor.Image = umImgPesquisaSair;
            btn_PesquisarProduto.Image = umImgPesquisaSair;
            btn_PesquisaTransportadora.Image = umImgPesquisaSair;
            btn_PesquisarCondPag.Image = umImgPesquisaSair;
        }

        private void btn_Gerar_Click(object sender, EventArgs e)
        {
            groupBox_Produtos.Enabled = false;
        }

        private void btn_Sair_Click(object sender, EventArgs e)
        {

            Close();
        }
    }
}