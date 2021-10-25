using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Projeto_ICI.Classes;
using System.Windows.Forms;

namespace Projeto_ICI.frmCadastros
{
    public partial class frmCadastroCompras : Projeto_ICI.formularioBase
    {
        private frmConsultas.frmConsultaCondicoesPagamento frmConsCondPag;
        private frmConsultas.frmConsultaTranspotadoras frmConsTransport;
        private frmConsultas.frmConsultaFornecedores frmConsForn;
        private frmConsultas.frmConsultaProdutos frmConsProduto;

        private condicoesPagamento umCondPag;
        private transportadoras umaTranspot;
        private fornecedores umForn;
        private produtos umProduto;

        

        private List<contasPagar> umaListaItens;
        public frmCadastroCompras()
        {
            InitializeComponent();

            umCondPag = new condicoesPagamento();
            umaTranspot = new transportadoras();
            umForn = new fornecedores();
            umProduto = new produtos();
            umaListaItens = new List<contasPagar>();

            groupBox_Produtos.Enabled = true;
            btn_PesquisarFornecedor.Image = umImgPesquisaSair;
            btn_PesquisarProduto.Image = umImgPesquisaSair;
            btn_PesquisaTransportadora.Image = umImgPesquisaSair;
            btn_PesquisarCondPag.Image = umImgPesquisaSair;
        }

        private bool conferir_Campos()
        {
            var vlResult = true;
            if (lv_ItensCompra.Items.Count == 0)
            {
                errorMSG.SetError(btn_Gerar, "Não há itens para gerar as parcelas!");
            }
            else if (umCondPag.Codigo == 0)
            {
                errorMSG.Clear();
                errorMSG.SetError(btn_Gerar, "Seleciona uma condição de pagamento!");
                txtb_CodigoCondPag.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_Seguro.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(btn_Gerar, "Insira um valor para o seguro!\n" +
                    "Caso seja não exista, insira 0");
                txtb_Seguro.Text = "0";
                txtb_Seguro.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_Frete.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(btn_Gerar, "Insira um valor para o frete!\n" +
                    "Caso seja não exista, insira 0");
                txtb_Frete.Text = "0";
                txtb_Frete.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_OutrasDeps.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(btn_Gerar, "Insira um valor para outras despesas!\n" +
                    "Caso seja não exista, insira 0");
                txtb_OutrasDeps.Text = "0";
                txtb_OutrasDeps.Focus();
            }
            return vlResult;
        }

        private void btn_Gerar_Click(object sender, EventArgs e)
        {
            if (lv_ItensCompra.Items.Count == 0)
            {
                errorMSG.SetError(btn_Gerar, "Não há itens para gerar as parcelas!");
            }
            else if (umCondPag.Codigo == 0)
            {
                errorMSG.Clear();
                errorMSG.SetError(btn_Gerar, "Seleciona uma condição de pagamento!");
                txtb_CodigoCondPag.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_Seguro.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(btn_Gerar, "Insira um valor para o seguro!\n" +
                    "Caso seja não exista, insira 0");
                txtb_Seguro.Text = "0";
                txtb_Seguro.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_Frete.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(btn_Gerar, "Insira um valor para o frete!\n" +
                    "Caso seja não exista, insira 0");
                txtb_Frete.Text = "0";
                txtb_Frete.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_OutrasDeps.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(btn_Gerar, "Insira um valor para outras despesas!\n" +
                    "Caso seja não exista, insira 0");
                txtb_OutrasDeps.Text = "0";
                txtb_OutrasDeps.Focus();
            }
            else
            {
                errorMSG.Clear();
                groupBox_Produtos.Enabled = false;
                CalcularParcelas();
            }
        }

        private void CalcularParcelas()
        {
            decimal vlTotal = CalcularTotal();
            umaListaItens = new List<contasPagar>();
            foreach (parcelasCondPag vlParcela in umCondPag.ListaParcelas)
            {
                var vlListItem = new contasPagar(txtb_Modelo.Text, txtb_Serie.Text, txtb_NumNF.Text,
                                                 vlParcela.Numero, dt_Emissao.Value.AddDays(vlParcela.Dias).ToString(),
                                                 "", vlTotal * (vlParcela.Porcentagem / 100), 0, int.Parse(txtb_CodigoUsu.Text),
                                                 DateTime.Now.ToString("dd/MM/yyyy"));

                string[] vlLVStrItem = new string[] { vlListItem.Parcela.ToString(),
                                                      vlListItem.Vencimento,
                                                      vlListItem.ValorTotal.ToString()};


                ListViewItem vlLVItem = new ListViewItem(vlLVStrItem);
                vlLVItem.Tag = vlListItem.ThisContaPagar;

                umaListaItens.Add(vlListItem);
                lv_ParcelasContasPag.Items.Add(vlLVItem);
            }
        }

        private decimal CalcularTotal(bool pValorItens = false)
        {
            if (pValorItens)
            {
                return decimal.Parse(txtb_TotalProdutos.Text.Replace(".", ","), vgEstilo, vgProv);
            }
            return decimal.Parse(txtb_Frete.Text.Replace(".", ","), vgEstilo, vgProv) +
                   decimal.Parse(txtb_Seguro.Text.Replace(".", ","), vgEstilo, vgProv) +
                   decimal.Parse(txtb_OutrasDeps.Text.Replace(".", ","), vgEstilo, vgProv) +
                   decimal.Parse(txtb_TotalProdutos.Text.Replace(".", ","), vgEstilo, vgProv);
        }
        public override void SetFrmCons(Form[] pFrmCons)
        {
            frmConsCondPag = (frmConsultas.frmConsultaCondicoesPagamento)pFrmCons[0];
            frmConsTransport = (frmConsultas.frmConsultaTranspotadoras)pFrmCons[1];
            frmConsForn = (frmConsultas.frmConsultaFornecedores)pFrmCons[2];
            frmConsProduto = (frmConsultas.frmConsultaProdutos)pFrmCons[3];
        }

        public void ClearTxTBox()
        {
            txtb_Modelo.Clear();
            txtb_Serie.Clear();
            txtb_NumNF.Clear();
            txtb_CodigoFornecedor.Clear();
            txtb_Fornecedor.Clear();
            dt_Emissao.Value = DateTime.Now;
            dt_Chegada.Value = DateTime.Now;
            lv_ParcelasContasPag.Clear();
            txtb_ChaveAcesso.Clear();
            txtb_TotalNota.Clear();
            txtb_TotalProdutos.Clear();
            ClearGroupBoxProd();

        }
        protected void ClearGroupBoxProd()
        {
            txtb_CodigoProduto.Clear();
            txtb_Produto.Clear();
            txtb_Quantidade.Clear();
            txtb_Unidade.Clear();
            txtb_Custo.Clear();
            txtb_CodigoTransport.Clear();
            txtb_Transport.Clear();
            txtb_Frete.Clear();
            txtb_Seguro.Clear();
            txtb_OutrasDeps.Clear();
            txtb_CodigoCondPag.Clear();
            txtb_CondicaoPag.Clear();
        }

        public void DesBloqTxTBox()
        {
            txtb_Modelo.Enabled = true;
            txtb_Serie.Enabled = true;
            txtb_NumNF.Enabled = true;
            txtb_CodigoFornecedor.Enabled = true;
            dt_Chegada.Enabled = true;
            dt_Emissao.Enabled = true;
            txtb_CodigoTransport.Enabled = true;
            txtb_Frete.Enabled = true;
            txtb_Seguro.Enabled = true;
            txtb_OutrasDeps.Enabled = true;
            txtb_CodigoCondPag.Enabled = true;
            txtb_ChaveAcesso.Enabled = true;
            txtb_CodigoUsu.Enabled = true;

            btn_Adicionar.Enabled = true;
            btn_Alterar.Enabled = true;
            btn_Remover.Enabled = true;
            btn_Gerar.Enabled = true;
            btn_Limpar.Enabled = true;
        }

        private void btn_Sair_Click(object sender, EventArgs e)
        {

            Close();
        }

        private void btn_Limpar_Click(object sender, EventArgs e)
        {
            ClearTxTBox();
            ClearGroupBoxProd();
            groupBox_Produtos.Enabled = true;
            lv_ParcelasContasPag.Clear();
        }

        private void groupBox_Produtos_EnabledChanged(object sender, EventArgs e)
        {
            btn_Limpar.Visible = !btn_Limpar.Visible;
        }

        private void btn_PesquisarFornecedor_Click(object sender, EventArgs e)
        {
            var nomeBtn = frmConsForn.Btn_Sair;
            frmConsForn.Btn_Sair = "Selecionar";
            frmConsForn.ConhecaOBJ(umForn);
            frmConsForn.ShowDialog();
            frmConsForn.Btn_Sair = nomeBtn;
            if (umForn.Codigo != 0)
            {
                txtb_CodigoFornecedor.Text = umForn.Codigo.ToString();
                txtb_Fornecedor.Text = umForn.Fornecedor;
            }
        }

        private void btn_PesquisarProduto_Click(object sender, EventArgs e)
        {
            var nomeBtn = frmConsProduto.Btn_Sair;
            frmConsProduto.Btn_Sair = "Selecionar";
            frmConsProduto.ConhecaOBJ(umProduto);
            frmConsProduto.ShowDialog();
            frmConsProduto.Btn_Sair = nomeBtn;
            if (umProduto.Codigo != 0)
            {
                txtb_CodigoProduto.Text = umProduto.Codigo.ToString();
                txtb_Produto.Text = umProduto.Produto;
            }
        }

        private void btn_PesquisarCondPag_Click(object sender, EventArgs e)
        {
            var nomeBtn = frmConsCondPag.Btn_Sair;
            frmConsCondPag.Btn_Sair = "Selecionar";
            frmConsCondPag.ConhecaOBJ(umCondPag);
            frmConsCondPag.ShowDialog();
            frmConsCondPag.Btn_Sair = nomeBtn;
            if (umCondPag.Codigo != 0)
            {
                txtb_CodigoCondPag.Text = umCondPag.Codigo.ToString();
                txtb_CondicaoPag.Text = umCondPag.CondicaoPag;
            }
        }

        private void btn_PesquisaTransportadora_Click(object sender, EventArgs e)
        {
            var nomeBtn = frmConsTransport.Btn_Sair;
            frmConsTransport.Btn_Sair = "Selecionar";
            frmConsTransport.ConhecaOBJ(umaTranspot);
            frmConsTransport.ShowDialog();
            frmConsTransport.Btn_Sair = nomeBtn;
            if (umaTranspot.Codigo != 0)
            {
                txtb_CodigoTransport.Text = umaTranspot.Codigo.ToString();
                txtb_Transport.Text = umaTranspot.Transportadora;
            }
        }

        private void txtb_CodigoFornecedor_TextChanged(object sender, EventArgs e)
        {
            if (txtb_CodigoFornecedor.Text == "")
            {
                txtb_Fornecedor.Clear();
            }
            else
            {
                if (int.TryParse(txtb_CodigoFornecedor.Text, out int vlCodigo))
                {
                    var vlEstado =
                         (Classes.fornecedores).CTRLEstado.Pesquisar("codigo",
                                                                            vlCodigo.ToString(),
                                                                            out string vlMsg,
                                                                            false);
                    if (vlEstado != null)
                    {
                        if (vlMsg == "")
                        {
                            txtb_Fornecedor.Text = vlEstado.Estado;
                            umForn.ThisFornecedor = vlEstado;
                        }
                        else
                        {
                            showErrorMsg(vlMsg);
                            txtb_Fornecedor.Clear();
                        }
                    }
                    else
                    {
                        txtb_Fornecedor.Clear();
                    }
                }
            }
        }
    }
}
