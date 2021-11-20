using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Projeto_ICI.Classes;
using System.Windows.Forms;

namespace Projeto_ICI.frmCadastros
{
    public partial class frmCadastroVendas : Projeto_ICI.formularioBase
    {
        private frmConsultas.frmConsultaCondicoesPagamento frmConsCondPag;
        private frmConsultas.frmConsultaTranspotadoras frmConsTransport;
        private frmConsultas.frmConsultaClientes frmConsCliente;
        private frmConsultas.frmConsultaProdutos frmConsProduto;

        private Controllers.ctrlVendas umCtrlCompra;

        private condicoesPagamento umCondPag;
        private transportadoras umaTranspot;
        private clientes umCliente;
        private produtos umProduto;
        private vendas umaVenda;

        private List<contasReceber> umaListaItens;
        public frmCadastroVendas(Controllers.ctrlVendas pCtrlCompra)
        {
            InitializeComponent();

            umCondPag = new condicoesPagamento();
            umaTranspot = new transportadoras();
            umCliente = new clientes();
            umProduto = new produtos();
            umaVenda = new vendas();
            umaListaItens = new List<contasReceber>();

            umCtrlCompra = pCtrlCompra;

            groupBox_Produtos.Enabled = true;
            btn_PesquisarFornecedor.Image = umImgPesquisaSair;
            btn_PesquisarProduto.Image = umImgPesquisaSair;
            btn_PesquisaTransportadora.Image = umImgPesquisaSair;
            btn_PesquisarCondPag.Image = umImgPesquisaSair;
            BloquearTxtBox(true);
            verificarPagamentoConta();
        }

        private void verificarPagamentoConta()
        {
            if(Btn_Acao == "Cancelar")
            {
                var vlConf = false;
                foreach (ListViewItem vlItem in lv_ParcelasContasPag.Items)
                {
                    var vlContaItem = (Classes.contasReceber)vlItem.Tag;
                    if (vlContaItem.DataPagamento != "00/00/0000")
                    {
                        vlConf = true;
                        break;
                    }
                }
                if (vlConf)
                {
                    btn_Salvar.Enabled = false;
                    errorMSG.SetError(btn_Salvar, $"Há uma parcela paga em '{lbl_ContasReceber.Text}'" +
                                                  "\nNão é possivel cancelar " +
                                                  $"{this.Text.Replace("Cadastro de", "")}!");
                }
            }
            
        }

        public override void SetFrmCons(Form[] pFrmCad)
        {
            frmConsCondPag = (frmConsultas.frmConsultaCondicoesPagamento)pFrmCad[0];
            frmConsTransport = (frmConsultas.frmConsultaTranspotadoras)pFrmCad[1];
            frmConsCliente = (frmConsultas.frmConsultaClientes)pFrmCad[2];
            frmConsProduto = (frmConsultas.frmConsultaProdutos)pFrmCad[3];
        }
        public void ClearTxTBox(bool pIncGBProd = true)
        {
            txtb_Modelo.Clear();
            txtb_Serie.Clear();
            txtb_NumNF.Clear();
            txtb_CodigoCliente.Clear();
            txtb_Fornecedor.Clear();
            dt_Emissao.Value = DateTime.Now;
            dt_Chegada.Value = DateTime.Now;
            lv_ParcelasContasPag.Items.Clear();
            txtb_Total.Clear();
            txtb_CodigoTransport.Clear();
            txtb_Transport.Clear();
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

            txtb_CodigoTransport.Enabled = true;
            txtb_CodigoCondPag.Enabled = true;

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

            txtb_CodigoTransport.Enabled = false;
            txtb_CodigoCondPag.Enabled = false;

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
            txtb_CodigoCliente.Enabled = pPK;
            btn_PesquisarFornecedor.Enabled = pPK;
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
            else
            {
                errorMSG.Clear();
                BloquearTxtBox(false);
                gerarContasReceber();
                btn_Gerar.Enabled = false;
                btn_Limpar.Visible = true;
            }
        }

        private List<Classes.itensVenda> lvItensCompraToList()
        {
            var vlListaItensCompra = new List<Classes.itensVenda>();
            decimal vlPesoLiq = 0, vlPesoBruto = 0;
            foreach (ListViewItem vlItem in lv_ItensCompra.Items)
            {
                var vlTag = (Classes.itensVenda)vlItem.Tag;
                vlTag.UmProduto.Saldo = int.Parse(vlItem.SubItems[2].Text);
                vlTag.UmProduto.Custo = strToDecimal(vlItem.SubItems[5].Text);
                vlTag.UmProduto.UltimaCompra = strToDecimal(vlItem.SubItems[3].Text);
                vlPesoBruto += vlTag.UmProduto.PesoBruto * vlTag.Quantidade;
                vlPesoLiq += vlTag.UmProduto.PesoLiquido * vlTag.Quantidade;
                vlListaItensCompra.Add(vlTag);
            }
            umaVenda.PesoBruto = vlPesoBruto;
            umaVenda.PesoLiquido = vlPesoLiq;
            return vlListaItensCompra;
        }
        private List<Classes.contasReceber> lvContasPagarToList()
        {
            var vlListaContasPagar = new List<Classes.contasReceber>();
            foreach (ListViewItem vlItem in lv_ParcelasContasPag.Items)
            {
                var vlTag = (Classes.contasReceber)vlItem.Tag;
                vlListaContasPagar.Add(vlTag.ThisContaReceber);
            }
            return vlListaContasPagar;
        }
        private void listToLvItensCompra(List<Classes.itensVenda> pLista)
        {
            decimal vlTotalProduto = 0;
            decimal vlSubTotal = 0;
            foreach (itensVenda vlItem in pLista)
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

                vlLVItem.Tag = vlItem.ThisItenVenda;
                lv_ItensCompra.Items.Add(vlLVItem);
                vlTotalProduto += vlSubTotal;
            }
            txtb_Total.Text = vlTotalProduto.ToString();
        }
        private void listToLvContasPagar(List<Classes.contasReceber> pLista)
        {
            decimal vlTotal = 0;
            foreach (contasReceber vlItem in pLista)
            {
                ListViewItem vlLVItem = new ListViewItem(new string[] { vlItem.Parcela.ToString(),
                                                                        vlItem.UmaFormaPag.FormaPag,
                                                                        vlItem.Vencimento,
                                                                        vlItem.DataPagamento,
                                                                        vlItem.ValorTotal.ToString(),
                                                                        vlItem.ValorPago.ToString()});
                vlLVItem.Tag = vlItem.ThisContaReceber;
                lv_ParcelasContasPag.Items.Add(vlLVItem);
                vlTotal += vlItem.ValorTotal;
            }
            txtb_Total.Text = vlTotal.ToString();
        }

        private void gerarContasReceber()
        {
            var vlTotal = strToDecimal(txtb_Total.Text);
            umaListaItens = new List<contasReceber>();
            decimal vlDecimal = 0;
            foreach (parcelasCondPag vlParcela in umCondPag.ListaParcelas)
            {
                vlDecimal = Math.Round((vlTotal * (vlParcela.Porcentagem / 100)), 4);
                var vlListItem = new
                contasReceber(txtb_Modelo.Text,
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
                vlListItem.UmCliente = umCliente.ThisCliente;

                string[] vlLVStrItem = new string[] { vlListItem.Parcela.ToString(),
                                                      vlListItem.UmaFormaPag.FormaPag,
                                                      vlListItem.Vencimento,
                                                      vlListItem.DataPagamento,
                                                      vlListItem.ValorTotal.ToString(),
                                                      vlListItem.ValorPago.ToString()};

                ListViewItem vlLVItem = new ListViewItem(vlLVStrItem);
                vlLVItem.Tag = vlListItem.ThisContaReceber;

                umaListaItens.Add(vlListItem);
                lv_ParcelasContasPag.Items.Add(vlLVItem);
            }
            umaVenda.UmaListaContasReceber = umaListaItens;
        }

        private void btn_Sair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Limpar_Click(object sender, EventArgs e)
        {
            ClearTxTBox();
            umaVenda.resetToBasic();
            btn_Limpar.Visible = false;
            EnabledPKTxtBox(true);
        }

        public void CarregarTxtBox(Classes.vendas pUmaCompra)
        {
            txtb_Modelo.Text = pUmaCompra.Modelo;
            txtb_Serie.Text = pUmaCompra.Serie;
            txtb_NumNF.Text = pUmaCompra.NumeroNF;
            dt_Chegada.Text = pUmaCompra.Saida;
            dt_Emissao.Text = pUmaCompra.Emissao;
            txtb_CodigoUsu.Text = pUmaCompra.CodigoUsu.ToString();

            txtb_Fornecedor.Text = pUmaCompra.UmCliente.Cliente;
            txtb_CodigoCliente.Text = pUmaCompra.UmCliente.Codigo.ToString();
            txtb_Transport.Text = pUmaCompra.UmaTransportadora.Transportadora;
            txtb_CodigoTransport.Text = pUmaCompra.UmaTransportadora.Codigo.ToString();
            txtb_CondicaoPag.Text = pUmaCompra.UmaCondicaoPag.CondicaoPag;
            txtb_CodigoCondPag.Text = pUmaCompra.UmaCondicaoPag.Codigo.ToString();

            listToLvItensCompra(pUmaCompra.UmaListaItens);
            listToLvContasPagar(pUmaCompra.UmaListaContasReceber);

            umaVenda.ThisCompra = pUmaCompra;
            btn_Salvar.Enabled = true;
        }

        private void groupBox_Produtos_EnabledChanged(object sender, EventArgs e)
        {
            btn_Limpar.Visible = !btn_Limpar.Visible;
        }

        private void btn_PesquisarFornecedor_Click(object sender, EventArgs e)
        {
            var nomeBtn = frmConsCliente.Btn_Sair;
            frmConsCliente.Btn_Sair = "Selecionar";
            frmConsCliente.ConhecaOBJ(umCliente);
            frmConsCliente.ShowDialog();
            frmConsCliente.Btn_Sair = nomeBtn;
            if (umCliente.Codigo != 0)
            {
                txtb_Fornecedor.Clear();
                txtb_CodigoCliente.Text = umCliente.Codigo.ToString();
                txtb_Fornecedor.Text = umCliente.Cliente;
            }
            validaChaveVenda();
        }

        private void validaChaveVenda()
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
                errorMSG.SetError(lbl_Cliente, "Insira um cliente digitando um código " +
                                                  "ou usado o botão de pesquisa!");
            }
            else
            {
                errorMSG.Clear();
                umaVenda.Modelo = txtb_Modelo.Text;
                umaVenda.Serie = txtb_Serie.Text;
                umaVenda.NumeroNF = txtb_NumNF.Text;
                umaVenda.UmCliente = umCliente.ThisCliente;
                var vlPesquisa = umCtrlCompra.Pesquisar(umaVenda.ToStringPK.Split(';'),
                                                        umaVenda.PK.Split(';'), out string vlMsg, true);
                if (vlPesquisa != null)
                {
                    MessageBox.Show($"Chave de pesquisa [ {umaVenda.ToStringPK} ] já está cadastrada!", "AVISO");
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
                txtb_PrecoUnt.Text = umProduto.CalculaPrecoVenda.ToString();
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
            if (txtb_CodigoCliente.Text == "")
            {
                txtb_Fornecedor.Clear();
            }
            else
            {
                if (int.TryParse(txtb_CodigoCliente.Text, out int vlCodigo))
                {
                    var vlForn =
                         (Classes.clientes)umCtrlCompra.CTRLCliente.Pesquisar("codigo",
                                                                            vlCodigo.ToString(),
                                                                            out string vlMsg,
                                                                            false);
                    if (vlForn != null)
                    {
                        if (vlMsg == "")
                        {
                            txtb_Fornecedor.Clear();
                            txtb_Fornecedor.Text = vlForn.Cliente;
                            umCliente.ThisCliente = vlForn;
                            validaChaveVenda();
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
                errorMSG.SetError(lbl_DataSaida, "A data de saída deve ser igual ou menor\n" +
                                                   $"que a data de Emissão ({dt_Emissao.Value.ToString().Split(' ')[0]})");
                dt_Chegada.Value = dt_Emissao.Value;
                dt_Chegada.Focus();
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
                    var vlTag = (Classes.itensVenda)vlItem.Tag;
                    if (vlTag != null)
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
                vlSubTotal = (strToDecimal(vlItem.SubItems[3].Text) - strToDecimal(vlItem.SubItems[4].Text))
                              * strToDecimal(vlItem.SubItems[2].Text);
                vlItem.SubItems[5].Text = vlSubTotal.ToString();
                vlTotal += vlSubTotal;
            }
            txtb_Total.Text = vlTotal.ToString();
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
                var vlItem = new itensVenda(txtb_Modelo.Text, txtb_Serie.Text, txtb_NumNF.Text,
                                                            txtb_Unidade.Text, int.Parse(txtb_Quantidade.Text),
                                                            strToDecimal(txtb_PrecoUnt.Text),
                                                            strToDecimal(txtb_Desconto.Text));
                vlItem.UmProduto = umProduto.ThisProduto;
                vlItem.UmCliente = umCliente.ThisCliente;


                var vlString = new string[] { vlItem.UmProduto.Produto,
                                              txtb_Unidade.Text,
                                              txtb_Quantidade.Text,
                                              vlItem.PrecoUnidade.ToString(),
                                              vlItem.Desconto.ToString(),
                                              (vlItem.PrecoUnidade - vlItem.Desconto).ToString(),
                                              (vlItem.Quantidade * vlItem.PrecoUnidade - vlItem.Desconto).ToString() };

                var vlLVItem = new ListViewItem(vlString);
                vlLVItem.Tag = vlItem.ThisItenVenda;

                umaVenda.UmaListaItens.Add(vlItem);
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
                errorMSG.SetError(lbl_ContasReceber, "As parcelas não foram geradas!\n" +
                                                     "Impossivel cadastrar a venda.");
                btn_Gerar.Focus();
            }
            else if (dt_Chegada.Value.Date > dt_Emissao.Value.Date)
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_DataSaida, "A data de saída deve ser igual ou menor\n" +
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
                    umaVenda.Emissao = dt_Emissao.Text.Split(' ')[0];
                    umaVenda.Saida = dt_Chegada.Text.Split(' ')[0];
                    umaVenda.CodigoUsu = txtb_CodigoUsu.Text == "" ? 0 : int.Parse(txtb_CodigoUsu.Text);
                    umaVenda.TotalNota = strToDecimal(txtb_Total.Text);
                    umaVenda.UmCliente.ThisCliente = umCliente;
                    umaVenda.UmaTransportadora.ThisTransportadora = umaTranspot;
                    umaVenda.UmaCondicaoPag.ThisCondPag = umCondPag;
                    umaVenda.UmaListaItens = lvItensCompraToList();
                    msg = umCtrlCompra.Inserir(umaVenda);
                }/*
                else if (Btn_Acao == "Alterar")
                {
                    msg = umCtrlCompra.Alterar(umaVenda);
                }*/
                else if (Btn_Acao == "Cancelar")
                {
                    msg = umCtrlCompra.Excluir(umaVenda);
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
            validaChaveVenda();
        }

        private void txtb_CodigoFornecedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacaoCodigo(txtb_CodigoCliente, e);
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
                txtb_PrecoUnt.Clear();
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
                            txtb_PrecoUnt.Text = vlProduto.CalculaPrecoVenda.ToString();
                            txtb_Unidade.Text = vlProduto.Unidade;
                            umProduto.ThisProduto = vlProduto;
                        }
                        else
                        {
                            showErrorMsg(vlMsg);
                            txtb_Produto.Clear();
                            txtb_PrecoUnt.Clear();
                            txtb_Unidade.Clear();
                        }
                    }
                    else
                    {
                        txtb_Produto.Clear();
                        txtb_PrecoUnt.Clear();
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
                umaVenda.UmaListaItens.Remove((Classes.itensVenda)vlItem.Tag);
                lv_ItensCompra.Items.Remove(vlItem);
            }
            recalcularTotal();
        }

        private void txtb_Modelo_TextChanged(object sender, EventArgs e)
        {
            validaChaveVenda();
        }

        private void txtb_Serie_TextChanged(object sender, EventArgs e)
        {
            validaChaveVenda();
        }

        private void txtb_NumNF_TextChanged(object sender, EventArgs e)
        {
            validaChaveVenda();
        }

        private void txtb_NumNF_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacaoCodigo(txtb_NumNF, e);
        }

        private void lv_ParcelasContasPag_MouseClick(object sender, MouseEventArgs e)
        {
            lv_ParcelasContasPag.SelectedItems[0].Selected = false;
        }

        private void frmCadastroVendas_FormClosed(object sender, FormClosedEventArgs e)
        {
            btn_Salvar.Enabled = true;
        }
    }
}
