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

        private Controllers.ctrlCompras umCtrlCompra;

        private condicoesPagamento umCondPag;
        private transportadoras umaTranspot;
        private fornecedores umForn;
        private produtos umProduto;
        private compras umaCompra;

        private List<contasPagar> umaListaItens;
        public frmCadastroCompras(Controllers.ctrlCompras pCtrlCompra)
        {
            InitializeComponent();

            umCondPag = new condicoesPagamento();
            umaTranspot = new transportadoras();
            umForn = new fornecedores();
            umProduto = new produtos();
            umaCompra = new compras();
            umaListaItens = new List<contasPagar>();

            umCtrlCompra = pCtrlCompra;

            groupBox_Produtos.Enabled = true;
            btn_PesquisarFornecedor.Image = umImgPesquisaSair;
            btn_PesquisarProduto.Image = umImgPesquisaSair;
            btn_PesquisaTransportadora.Image = umImgPesquisaSair;
            btn_PesquisarCondPag.Image = umImgPesquisaSair;
            BloquearTxtBox(true);
        }

        public override void SetFrmCons(Form[] pFrmCad)
        {
            frmConsCondPag = (frmConsultas.frmConsultaCondicoesPagamento)pFrmCad[0];
            frmConsTransport = (frmConsultas.frmConsultaTranspotadoras)pFrmCad[1];
            frmConsForn = (frmConsultas.frmConsultaFornecedores)pFrmCad[2];
            frmConsProduto = (frmConsultas.frmConsultaProdutos)pFrmCad[3];
        }
        public void ClearTxTBox(bool pIncGBProd = true)
        {
            txtb_Modelo.Clear();
            txtb_Serie.Clear();
            txtb_NumNF.Clear();
            txtb_CodigoFornecedor.Clear();
            txtb_Fornecedor.Clear();
            dt_Emissao.Value = DateTime.Now;
            dt_Chegada.Value = DateTime.Now;
            lv_ParcelasContasPag.Items.Clear();
            txtb_ChaveAcesso.Clear();
            txtb_TotalNota.Clear();
            txtb_TotalProdutos.Clear();
            txtb_CodigoTransport.Clear();
            txtb_Transport.Clear();
            txtb_Frete.Text = "0";
            txtb_Seguro.Text = "0";
            txtb_OutrasDeps.Text = "0";
            txtb_CodigoCondPag.Clear();
            txtb_CondicaoPag.Clear();
            if (pIncGBProd)
            { ClearGroupBoxProd(); }

        }
        protected void ClearGroupBoxProd()
        {
            txtb_CodigoProduto.Clear();
            txtb_Produto.Clear();
            txtb_Quantidade.Clear();
            txtb_Unidade.Clear();
            txtb_PrecoUnt.Clear();
            lv_ItensCompra.Items.Clear();
        }

        public void DesBloqTxTBox()
        {
            EnabledPKTxtBox(true);

            dt_Chegada.Enabled = true;
            dt_Emissao.Enabled = true;

            groupBox_Produtos.Enabled = true;
            txtb_Frete.Enabled = true;
            txtb_Seguro.Enabled = true;
            txtb_OutrasDeps.Enabled = true;

            txtb_CodigoTransport.Enabled = true;
            txtb_CodigoCondPag.Enabled = true;

            txtb_ChaveAcesso.Enabled = true;

            btn_Gerar.Enabled = true;
            btn_Limpar.Visible = !btn_Gerar.Enabled;
            btn_PesquisarCondPag.Enabled = true;
            btn_PesquisarFornecedor.Enabled = true;
            btn_PesquisaTransportadora.Enabled = true;
        }
        public void BloquearTxtBox(bool pPK)
        {
            EnabledPKTxtBox(pPK);

            dt_Chegada.Enabled = false;
            dt_Emissao.Enabled = false;

            groupBox_Produtos.Enabled = false;
            txtb_Frete.Enabled = false;
            txtb_Seguro.Enabled = false;
            txtb_OutrasDeps.Enabled = false;

            txtb_CodigoTransport.Enabled = false;
            txtb_CodigoCondPag.Enabled = false;

            txtb_ChaveAcesso.Enabled = false;

            btn_Gerar.Enabled = false;
            btn_Limpar.Visible = false;
            btn_PesquisarCondPag.Enabled = false;
            btn_PesquisaTransportadora.Enabled = false;
        }

        public void EnabledPKTxtBox(bool pPK)
        {
            txtb_Modelo.Enabled = pPK;
            txtb_Serie.Enabled = pPK;
            txtb_NumNF.Enabled = pPK;
            txtb_CodigoFornecedor.Enabled = pPK;
            btn_PesquisarFornecedor.Enabled = pPK;
        }

        private bool conferir_Campos()
        {
            var vlResult = true;
            if (lv_ItensCompra.Items.Count == 0)
            {
                errorMSG.SetError(btn_Gerar, "Não há itens para gerar as parcelas!");
                vlResult = false;
            }
            else if (umCondPag.Codigo == 0)
            {
                errorMSG.Clear();
                errorMSG.SetError(btn_Gerar, "Seleciona uma condição de pagamento!");
                txtb_CodigoCondPag.Focus();
                vlResult = false;
            }
            else if (string.IsNullOrEmpty(txtb_Seguro.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(btn_Gerar, "Insira um valor para o seguro!\n" +
                    "Caso seja não exista, insira 0");
                txtb_Seguro.Text = "0";
                txtb_Seguro.Focus();
                vlResult = false;
            }
            else if (string.IsNullOrEmpty(txtb_Frete.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(btn_Gerar, "Insira um valor para o frete!\n" +
                    "Caso seja não exista, insira 0");
                txtb_Frete.Text = "0";
                txtb_Frete.Focus();
                vlResult = false;
            }
            else if (string.IsNullOrEmpty(txtb_OutrasDeps.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(btn_Gerar, "Insira um valor para outras despesas!\n" +
                    "Caso seja não exista, insira 0");
                txtb_OutrasDeps.Text = "0";
                txtb_OutrasDeps.Focus();
                vlResult = false;
            }
            return vlResult;
        }

        private void btn_Gerar_Click(object sender, EventArgs e)
        {
            if (lv_ItensCompra.Items.Count == 0)
            {
                errorMSG.SetError(btn_Adicionar, "Não há itens para gerar as parcelas!");
                txtb_CodigoProduto.Focus();
            }
            else if (txtb_CondicaoPag.Text == "")
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_CondicaoPag, "Seleciona uma condição de pagamento!");
                txtb_CodigoCondPag.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_Seguro.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_Seguro, "Insira um valor para o seguro!\n" +
                    "Caso seja não exista, insira 0");
                txtb_Seguro.Text = "0";
                txtb_Seguro.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_Frete.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_Frete, "Insira um valor para o frete!\n" +
                    "Caso seja não exista, insira 0");
                txtb_Frete.Text = "0";
                txtb_Frete.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_OutrasDeps.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_OutrasDeps, "Insira um valor para outras despesas!\n" +
                    "Caso seja não exista, insira 0");
                txtb_OutrasDeps.Text = "0";
                txtb_OutrasDeps.Focus();
            }
            else
            {
                errorMSG.Clear();
                BloquearTxtBox(false);
                CalcularParcelas();
                btn_Gerar.Enabled = false;
                btn_Limpar.Visible = true;
            }
        }

        private void CalcularParcelas()
        {
            refaturarItensCompra();
            gerarContasPagar();
        }

        private List<Classes.itensCompra> lvItensCompraToList()
        {
            var vlListaItensCompra = new List<Classes.itensCompra>();
            decimal vlPesoLiq = 0, vlPesoBruto = 0;
            foreach (ListViewItem vlItem in lv_ItensCompra.Items)
            {
                var vlTag = (Classes.itensCompra)vlItem.Tag;
                vlTag.UmProduto.Saldo = int.Parse(vlItem.SubItems[2].Text);
                vlTag.UmProduto.Custo = strToDecimal(vlItem.SubItems[5].Text);
                vlTag.UmProduto.UltimaCompra = strToDecimal(vlItem.SubItems[3].Text);
                vlPesoBruto += vlTag.UmProduto.PesoBruto;
                vlPesoLiq += vlTag.UmProduto.PesoLiquido;
                vlListaItensCompra.Add(vlTag);
            }
            umaCompra.PesoBruto = vlPesoBruto;
            umaCompra.PesoLiquido = vlPesoLiq;
            return vlListaItensCompra;
        }
        private List<Classes.contasPagar> lvContasPagarToList()
        {
            var vlListaContasPagar = new List<Classes.contasPagar>();
            foreach (ListViewItem vlItem in lv_ParcelasContasPag.Items)
            {
                var vlTag = (Classes.contasPagar)vlItem.Tag;
                vlListaContasPagar.Add(vlTag.ThisContaPagar);
            }
            return vlListaContasPagar;
        }
        private void listToLvItensCompra(List<Classes.itensCompra> pLista)
        {
            decimal vlTotalProduto = 0;
            decimal vlSubTotal = 0;
            foreach (itensCompra vlItem in pLista)
            {
                vlSubTotal = vlItem.Quantidade * vlItem.PrecoUnidade - vlItem.Desconto;
                var vlLVItem = new ListViewItem(new string[] { vlItem.UmProduto.Produto,
                                                              txtb_Unidade.Text,
                                                              txtb_Quantidade.Text,
                                                              vlItem.PrecoUnidade.ToString(),
                                                              vlItem.Desconto.ToString(),
                                                              (vlItem.PrecoUnidade - 
                                                                    vlItem.Desconto).ToString(),
                                                              vlSubTotal.ToString()});

                vlLVItem.Tag = vlItem.ThisItenCompra;
                lv_ItensCompra.Items.Add(vlLVItem);
                vlTotalProduto += vlSubTotal;
            }
            txtb_TotalProdutos.Text = vlTotalProduto.ToString();
        }
        private void listToLvContasPagar(List<Classes.contasPagar> pLista)
        {
            decimal vlTotal = 0;
            foreach (contasPagar vlItem in pLista)
            {
                ListViewItem vlLVItem = new ListViewItem(new string[] { vlItem.Parcela.ToString(),
                                                                        vlItem.UmaFormaPag.FormaPag,
                                                                        vlItem.Vencimento,
                                                                        vlItem.DataPagamento,
                                                                        vlItem.ValorTotal.ToString(),
                                                                        vlItem.ValorPago.ToString()});
                vlLVItem.Tag = vlItem.ThisContaPagar;
                lv_ParcelasContasPag.Items.Add(vlLVItem);
                vlTotal += vlItem.ValorTotal;
            }
            txtb_TotalNota.Text = vlTotal.ToString();
        }
        private void refaturarItensCompra()
        {
            decimal vlTotal = strToDecimal(txtb_Frete.Text) +
                              strToDecimal(txtb_Seguro.Text) +
                              strToDecimal(txtb_OutrasDeps.Text);
            decimal vlDecimal = 0;
            if (vlTotal > 0)
            {
                var vlLista = calcularPorcItens();
                int vlIndex = 0;

                foreach (ListViewItem vlItem in lv_ItensCompra.Items)
                {
                    vlDecimal = (vlTotal * vlLista[vlIndex] /
                                 int.Parse(vlItem.SubItems[2].Text)) +
                                 strToDecimal(vlItem.SubItems[3].Text) -
                                 strToDecimal(vlItem.SubItems[4].Text);
                    vlItem.SubItems[5].Text = Math.Round(vlDecimal, 4).ToString();
                    vlIndex += 1;
                }
            }
            recalcularTotal();
            txtb_TotalNota.Text = txtb_TotalProdutos.Text;
        }

        private void gerarContasPagar()
        {
            var vlTotal = strToDecimal(txtb_TotalNota.Text);
            umaListaItens = new List<contasPagar>();
            decimal vlDecimal = 0;
            foreach (parcelasCondPag vlParcela in umCondPag.ListaParcelas)
            {
                vlDecimal = Math.Round((vlTotal * (vlParcela.Porcentagem / 100)), 4);
                var vlListItem = new
                contasPagar(txtb_Modelo.Text,
                            txtb_Serie.Text,
                            txtb_NumNF.Text,
                            vlParcela.Numero,
                            dt_Emissao.Value.AddDays(vlParcela.Dias).ToString("dd/MM/yyyy"),
                            "00/00/0000",
                            vlDecimal,
                            0,
                            int.Parse((txtb_CodigoUsu.Text == "" ? "0" : txtb_CodigoUsu.Text)),
                            DateTime.Now.ToString("dd/MM/yyyy"),
                            umCondPag.Desconto,
                            umCondPag.TaxaJuros,
                            umCondPag.Multa);
                vlListItem.UmaFormaPag = vlParcela.UmaFormaPag.ThisFormPag;
                vlListItem.UmFornecedor = umForn.ThisFornecedor;

                string[] vlLVStrItem = new string[] { vlListItem.Parcela.ToString(),
                                                      vlListItem.UmaFormaPag.FormaPag,
                                                      vlListItem.Vencimento,
                                                      vlListItem.DataPagamento,
                                                      vlListItem.ValorTotal.ToString(),
                                                      vlListItem.ValorPago.ToString()};

                ListViewItem vlLVItem = new ListViewItem(vlLVStrItem);
                vlLVItem.Tag = vlListItem.ThisContaPagar;

                umaListaItens.Add(vlListItem);
                lv_ParcelasContasPag.Items.Add(vlLVItem);
            }
            umaCompra.UmaListaContasPagar = umaListaItens;
        }

        private List<decimal> calcularPorcItens()
        {
            decimal vlSoma = 0;
            decimal vlPorc = 0;
            var vlLista = new List<decimal>();
            var vlTotalItens = strToDecimal(txtb_TotalProdutos.Text);
            foreach (ListViewItem vlItem in lv_ItensCompra.Items)
            {
                vlPorc = Math.Round(strToDecimal(vlItem.SubItems[6].Text) / vlTotalItens, 4);
                vlLista.Add(vlPorc);
                vlSoma += vlPorc;
            }
            return vlLista;
        }

        private void btn_Sair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Limpar_Click(object sender, EventArgs e)
        {
            ClearTxTBox();
            umaCompra.resetToBasic();
            btn_Limpar.Visible = false;
            EnabledPKTxtBox(true);
        }

        public void CarregarTxtBox(Classes.compras pUmaCompra)
        {
            txtb_Modelo.Text = pUmaCompra.Modelo;
            txtb_Serie.Text = pUmaCompra.Serie;
            txtb_NumNF.Text = pUmaCompra.NumeroNF;
            txtb_Frete.Text = pUmaCompra.Frete.ToString();
            txtb_Seguro.Text = pUmaCompra.Seguro.ToString();
            txtb_OutrasDeps.Text = pUmaCompra.OutrasDeps.ToString();
            dt_Chegada.Text = pUmaCompra.Chegada;
            dt_Emissao.Text = pUmaCompra.Emissao;
            txtb_ChaveAcesso.Text = pUmaCompra.ChaveAcesso;
            txtb_CodigoUsu.Text = pUmaCompra.CodigoUsu.ToString();

            txtb_Fornecedor.Text = pUmaCompra.UmFornecedor.Fornecedor;
            txtb_CodigoFornecedor.Text = pUmaCompra.UmFornecedor.Codigo.ToString();
            txtb_Transport.Text = pUmaCompra.UmaTransportadora.Transportadora;
            txtb_CodigoTransport.Text = pUmaCompra.UmaTransportadora.Codigo.ToString();
            txtb_CondicaoPag.Text = pUmaCompra.UmaCondicaoPag.CondicaoPag;
            txtb_CodigoCondPag.Text = pUmaCompra.UmaCondicaoPag.Codigo.ToString();

            listToLvItensCompra(pUmaCompra.UmaListaItens);
            listToLvContasPagar(pUmaCompra.UmaListaContasPagar);

            umaCompra.ThisCompra = pUmaCompra;
            btn_Salvar.Enabled = true;
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
                txtb_Fornecedor.Clear();
                txtb_CodigoFornecedor.Text = umForn.Codigo.ToString();
                txtb_Fornecedor.Text = umForn.Fornecedor;
            }
            validarChaveCompra();
        }

        private void validarChaveCompra()
        {
            var vlBloq = true;
            if (Btn_Acao == "Cancelar")
            {
                errorMSG.Clear();
                vlBloq = false;
            }
            else if (txtb_Modelo.Text == "")
                errorMSG.SetError(lbl_Modelo, "Insira um modelo!");
            else if (txtb_Serie.Text == "")
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_Serie, "Insira uma série!");
            }
            else if (txtb_NumNF.Text == "" || txtb_NumNF.Text == "0")
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_NumNF, "Insira um número de nota fiscal válido!");
            }
            else if (txtb_Fornecedor.Text == "")
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_Fornecedor, "Insira um fornecedor digitando um código " +
                                                  "ou usado o botão de pesquisa!");
            }
            else
            {
                errorMSG.Clear();
                umaCompra.Modelo = txtb_Modelo.Text;
                umaCompra.Serie = txtb_Serie.Text;
                umaCompra.NumeroNF = txtb_NumNF.Text;
                umaCompra.UmFornecedor = umForn.ThisFornecedor;
                var vlPesquisa = umCtrlCompra.Pesquisar(umaCompra.ToStringPK.Split(';'),
                                                        umaCompra.PK.Split(';'), out string vlMsg, true);
                if (vlPesquisa != null)
                {
                    MessageBox.Show($"Chave de pesquisa [ {umaCompra.ToStringPK} ] já está cadastrada!", "AVISO");
                    txtb_Modelo.Focus();
                }
                else
                    vlBloq = false;
            }
            if (vlBloq)
            { BloquearTxtBox(vlBloq); }
            else
            { 
                DesBloqTxTBox();
                EnabledPKTxtBox(false);
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
                errorMSG.Clear();
                txtb_CodigoProduto.Text = umProduto.Codigo.ToString();
                txtb_Unidade.Text = umProduto.Unidade;
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
                errorMSG.Clear();
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
                errorMSG.Clear();
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
                    var vlForn =
                         (Classes.fornecedores)umCtrlCompra.CTRLForn.Pesquisar("codigo",
                                                                            vlCodigo.ToString(),
                                                                            out string vlMsg,
                                                                            false);
                    if (vlForn != null)
                    {
                        if (vlMsg == "")
                        {
                            txtb_Fornecedor.Clear();
                            txtb_Fornecedor.Text = vlForn.Fornecedor;
                            umForn.ThisFornecedor = vlForn;
                            validarChaveCompra();
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

        private void dt_Emissao_Validating(object sender, CancelEventArgs e)
        {
            if (dt_Emissao.Value.Date > DateTime.Now.Date)
            {
                errorMSG.SetError(lbl_DataEmissao, "A data de emissão deve ser igual ou menor\n" +
                                                   $"que a data atual ({DateTime.Now.ToString().Split(' ')[0]})");
                dt_Emissao.Value = DateTime.Now;
                dt_Emissao.Focus();
            }
            else
            {
                errorMSG.Clear();
            }
        }

        private void dt_Chegada_Validating(object sender, CancelEventArgs e)
        {
            if (dt_Chegada.Value.Date > dt_Emissao.Value.Date)
            {
                errorMSG.SetError(lbl_DataChegada, "A data de chegada deve ser igual ou menor\n" +
                                                   $"que a data de Emissão ({dt_Emissao.Value.ToString().Split(' ')[0]})");
                dt_Chegada.Value = dt_Emissao.Value;
                dt_Chegada.Focus();
            }
            else
            {
                errorMSG.Clear();
            }
        }

        private void txtb_Unidade_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtb_Unidade.Text))
            {
                errorMSG.SetError(lbl_Unidade, "Campo 'Unidade' é obrigatório!");
                txtb_Unidade.Focus();
            }
            else
            {
                errorMSG.Clear();
            }
        }

        private void txtb_Quantidade_Validating(object sender, CancelEventArgs e)
        {
            if (!int.TryParse(txtb_Quantidade.Text, out int i) || (i <= 0))
            {
                errorMSG.SetError(lbl_Quantidade, $"O valor '{txtb_Quantidade.Text}' não é valido!\n" +
                                                  "Insira um valor inteiro igual ou superior a 1");
                txtb_Quantidade.Focus();
            }
            else
                errorMSG.Clear();
        }

        private void txtb_Custo_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidacaoDoubleMoeda(txtb_PrecoUnt.Text, false))
            {
                errorMSG.SetError(lbl_PrecoUnt, $"Valor '{txtb_PrecoUnt.Text}' inválido");
                txtb_PrecoUnt.Focus();
            }
            else
                errorMSG.Clear();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidacaoDoubleMoeda(txtb_Desconto.Text, true))
            {
                errorMSG.SetError(lbl_Desconto, $"Valor '{txtb_Desconto.Text}' inválido");
                txtb_Desconto.Text = "0";
            }
            else if (strToDecimal(txtb_Desconto.Text) > strToDecimal(txtb_PrecoUnt.Text))
            {
                errorMSG.SetError(lbl_Desconto, $"O Desconto não pode exceder o valor do preço unitário!");
                txtb_Desconto.Text = txtb_PrecoUnt.Text;
            }
            else
                errorMSG.Clear();
        }

        private bool verificarItens(string pProduto)
        {
            if (lv_ItensCompra.Items.Count == 0)
            { return false; }
            else
            {
                foreach (ListViewItem vlItem in lv_ItensCompra.Items)
                {
                    var vlTag = (Classes.itensCompra)vlItem.Tag;
                    if(vlTag != null)
                        if (vlTag.UmProduto.Produto == pProduto)
                            return true;
                }
                return false;
            }
        }

        private void recalcularTotal()
        {
            decimal vlTotal = 0;
            decimal vlSubTotal = 0;
            foreach (ListViewItem vlItem in lv_ItensCompra.Items)
            {
                vlSubTotal = strToDecimal(vlItem.SubItems[5].Text) *
                             strToDecimal(vlItem.SubItems[2].Text);
                if (vlSubTotal.ToString().Contains(",9999"))
                    vlSubTotal += decimal.Parse("0,0001");
                vlItem.SubItems[6].Text = vlSubTotal.ToString();
                vlTotal += vlSubTotal;
            }
            txtb_TotalProdutos.Text = vlTotal.ToString();
        }

        private void btn_Adicionar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtb_Produto.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_CodigoProduto, "Selecione um produto");
                btn_PesquisarProduto.Focus();
            }
            else if (verificarItens(txtb_Produto.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_CodigoProduto, "O produto já está na lista");
                txtb_CodigoProduto.Clear();
                txtb_Produto.Clear();
                btn_PesquisarProduto.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_Unidade.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_Unidade, "Campo 'Unidade' é obrigatório!");
                txtb_Unidade.Focus();
            }
            else if (!int.TryParse(txtb_Quantidade.Text, out int i) || (i <= 0))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_Quantidade, $"O valor '{txtb_Quantidade.Text}' não é valido!\n" +
                                                  "Insira um valor inteiro igual ou superior a 1");
                txtb_Quantidade.Focus();
            }
            else if (!ValidacaoDoubleMoeda(txtb_PrecoUnt.Text, false))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_PrecoUnt, $"Valor '{txtb_PrecoUnt.Text}' inválido");
                txtb_PrecoUnt.Focus();
            }
            else
            {
                errorMSG.Clear();
                var vlItem = new itensCompra(txtb_Modelo.Text, txtb_Serie.Text, txtb_NumNF.Text,
                                                            txtb_Unidade.Text, int.Parse(txtb_Quantidade.Text),
                                                            strToDecimal(txtb_PrecoUnt.Text),
                                                            strToDecimal(txtb_Desconto.Text));
                vlItem.UmProduto = umProduto.ThisProduto;
                vlItem.UmFornecedor = umForn.ThisFornecedor;


                var vlString = new string[] { vlItem.UmProduto.Produto,
                                              txtb_Unidade.Text,
                                              txtb_Quantidade.Text,
                                              vlItem.PrecoUnidade.ToString(),
                                              vlItem.Desconto.ToString(),
                                              (vlItem.PrecoUnidade - vlItem.Desconto).ToString(),
                                              (vlItem.Quantidade * vlItem.PrecoUnidade - vlItem.Desconto).ToString() };

                var vlLVItem = new ListViewItem(vlString);
                vlLVItem.Tag = vlItem.ThisItenCompra;

                umaCompra.UmaListaItens.Add(vlItem);
                lv_ItensCompra.Items.Add(vlLVItem);
                txtb_Produto.Clear();
                txtb_CodigoProduto.Clear();
                txtb_Unidade.Clear();
                txtb_PrecoUnt.Clear();
                txtb_Desconto.Text = "0";
                txtb_Quantidade.Text = "0";
                recalcularTotal();
            }

        }

        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            if (lv_ParcelasContasPag.Items.Count == 0)
            {
                errorMSG.SetError(lbl_ContasPagar, "As parcelas não foram geradas!\nImpossivel cadastrar a compra.");
                btn_Gerar.Focus();
            }
            else if (dt_Chegada.Value.Date > dt_Emissao.Value.Date)
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_DataChegada, "A data de chegada deve ser igual ou menor\n" +
                                                   $"que a data de Emissão ({dt_Emissao.Value.ToString().Split(' ')[0]})");
                dt_Chegada.Value = dt_Emissao.Value;
                dt_Chegada.Focus();
            }
            else
            {
                errorMSG.Clear();
                string msg = "";
                if (Btn_Acao == "Salvar")
                {
                    umaCompra.Emissao = dt_Emissao.Text.Split(' ')[0];
                    umaCompra.Chegada = dt_Chegada.Text.Split(' ')[0];
                    umaCompra.ChaveAcesso = txtb_ChaveAcesso.Text;
                    umaCompra.CodigoUsu = txtb_CodigoUsu.Text == "" ? 0 : int.Parse(txtb_CodigoUsu.Text);
                    umaCompra.TotalNota = strToDecimal(txtb_TotalNota.Text);
                    umaCompra.TotalProdutos = strToDecimal(txtb_TotalProdutos.Text);
                    umaCompra.Frete = strToDecimal(txtb_Frete.Text);
                    umaCompra.Seguro = strToDecimal(txtb_Seguro.Text);
                    umaCompra.OutrasDeps = strToDecimal(txtb_OutrasDeps.Text);
                    umaCompra.UmFornecedor.ThisFornecedor = umForn;
                    umaCompra.UmaTransportadora.ThisTransportadora = umaTranspot;
                    umaCompra.UmaCondicaoPag.ThisCondPag = umCondPag;
                    umaCompra.UmaListaItens = lvItensCompraToList();
                    msg = umCtrlCompra.Inserir(umaCompra);
                }/*
                else if (Btn_Acao == "Alterar")
                {
                    msg = umCtrlCompra.Alterar(umaCompra);
                }*/
                else if (Btn_Acao == "Cancelar")
                {
                    msg = umCtrlCompra.Excluir(umaCompra);
                }

                if (msg.Contains("sucesso"))
                {
                    MessageBox.Show(msg, "Informação");
                    Close();
                }
                else
                {
                    MessageBox.Show(msg, "ERRO");
                }
            }
        }
        public string Btn_Acao
        {
            get => btn_Salvar.Text;
            set => btn_Salvar.Text = value;
        }

        private void txtb_Fornecedor_TextChanged(object sender, EventArgs e)
        {
            validarChaveCompra();
        }

        private void txtb_CodigoFornecedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacaoCodigo(txtb_CodigoFornecedor, e);
        }

        private void txtb_CodigoProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacaoCodigo(txtb_CodigoProduto, e);
        }

        private void txtb_CodigoTransport_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacaoCodigo(txtb_CodigoTransport, e);
        }

        private void txtb_CodigoCondPag_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacaoCodigo(txtb_CodigoCondPag, e);
        }

        private void txtb_Quantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacaoCodigo(txtb_Quantidade, e);
        }

        private void txtb_CodigoProduto_TextChanged(object sender, EventArgs e)
        {
            if (txtb_CodigoProduto.Text == "")
            {
                txtb_Produto.Clear();
                txtb_Unidade.Clear();
            }
            else
            {
                if (int.TryParse(txtb_CodigoProduto.Text, out int vlCodigo))
                {
                    var vlProduto =
                         (Classes.produtos)umCtrlCompra.CTRLProduto.Pesquisar("codigo",
                                                                            vlCodigo.ToString(),
                                                                            out string vlMsg,
                                                                            true);
                    if (vlProduto != null)
                    {
                        if (vlMsg == "")
                        {
                            txtb_Produto.Text = vlProduto.Produto;
                            txtb_Unidade.Text = vlProduto.Unidade;
                            umProduto.ThisProduto = vlProduto;
                        }
                        else
                        {
                            showErrorMsg(vlMsg);
                            txtb_Produto.Clear();
                            txtb_Unidade.Clear();
                        }
                    }
                    else
                    {
                        txtb_Produto.Clear();
                        txtb_Unidade.Clear();
                    }
                }
            }
        }

        private void txtb_CodigoTransport_TextChanged(object sender, EventArgs e)
        {
            if (txtb_CodigoTransport.Text == "")
            {
                txtb_Transport.Clear();
            }
            else
            {
                if (int.TryParse(txtb_CodigoTransport.Text, out int vlCodigo))
                {
                    var vlTransport =
                         (Classes.transportadoras)umCtrlCompra.CTRLTransport.Pesquisar("codigo",
                                                                            vlCodigo.ToString(),
                                                                            out string vlMsg,
                                                                            true);
                    if (vlTransport != null)
                    {
                        if (vlMsg == "")
                        {
                            txtb_Transport.Text = vlTransport.Transportadora;
                            umaTranspot.ThisTransportadora = vlTransport;
                        }
                        else
                        {
                            showErrorMsg(vlMsg);
                            txtb_Transport.Clear();
                        }
                    }
                    else
                    {
                        txtb_Transport.Clear();
                    }
                }
            }
        }

        private void txtb_CodigoCondPag_TextChanged(object sender, EventArgs e)
        {
            if (txtb_CodigoCondPag.Text == "")
                txtb_CondicaoPag.Clear();
            else
            {
                if (int.TryParse(txtb_CodigoCondPag.Text, out int vlCodigo))
                {
                    var vlCondPag =
                         (Classes.condicoesPagamento)umCtrlCompra.CTRLCondicaoPag.Pesquisar("codigo",
                                                                                vlCodigo.ToString(),
                                                                                out string vlMsg,
                                                                                true);
                    if (vlCondPag != null)
                    {
                        if (vlMsg == "")
                        {
                            txtb_CondicaoPag.Text = vlCondPag.CondicaoPag;
                            umCondPag.ThisCondPag = vlCondPag;
                        }
                        else
                        {
                            showErrorMsg(vlMsg);
                            txtb_Produto.Clear();
                        }
                    }
                    else
                        txtb_CondicaoPag.Clear();
                }
            }
        }

        private void btn_Remover_Click(object sender, EventArgs e)
        {
            if (lv_ItensCompra.Items.Count <= 0)
                errorMSG.SetError(btn_Remover, "Não há itens na lista!");
            if (lv_ItensCompra.SelectedIndices.Count == 0)
                errorMSG.SetError(btn_Remover, "Selecione um item!");
            else
            {
                errorMSG.Clear();
                ListViewItem vlItem = lv_ItensCompra.Items[lv_ItensCompra.SelectedIndices[0]];
                umaCompra.UmaListaItens.Remove((Classes.itensCompra)vlItem.Tag);
                lv_ItensCompra.Items.Remove(vlItem);
            }
            recalcularTotal();
        }

        private void txtb_Modelo_TextChanged(object sender, EventArgs e)
        {
            validarChaveCompra();
        }

        private void txtb_Serie_TextChanged(object sender, EventArgs e)
        {
            validarChaveCompra();
        }

        private void txtb_NumNF_TextChanged(object sender, EventArgs e)
        {
            validarChaveCompra();
        }

        private void txtb_NumNF_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacaoCodigo(txtb_NumNF, e);
        }

        private void lv_ParcelasContasPag_MouseClick(object sender, MouseEventArgs e)
        {
            lv_ParcelasContasPag.SelectedItems[0].Selected = false;
        }
    }
}
