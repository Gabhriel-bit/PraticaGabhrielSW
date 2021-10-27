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
            else if (txtb_CondicaoPag.Text == "")
            {
                errorMSG.Clear();
                errorMSG.SetError(btn_Gerar, "Seleciona uma condição de pagamento!");
                txtb_CodigoCondPag.Focus();
            }
            else if (txtb_Transport.Text == "")
            {
                errorMSG.Clear();
                errorMSG.SetError(btn_Gerar, "Seleciona uma transportadora!");
                txtb_Transport.Focus();
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
                vlListItem.UmaFormaPag = vlParcela.UmaFormaPag.ThisFormPag;

                string[] vlLVStrItem = new string[] { vlListItem.Parcela.ToString(),
                                                      vlListItem.Vencimento,
                                                      vlListItem.UmaFormaPag.FormaPag,
                                                      vlListItem.ValorTotal.ToString()};


                ListViewItem vlLVItem = new ListViewItem(vlLVStrItem);
                vlLVItem.Tag = vlListItem.ThisContaPagar;

                umaListaItens.Add(vlListItem);
                lv_ParcelasContasPag.Items.Add(vlLVItem);
            }
            umaCompra.UmaListaContasPagar = umaListaItens;
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
            txtb_PrecoUnt.Clear();
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

            groupBox_Produtos.Enabled = true;
            txtb_Frete.Enabled = true;
            txtb_Seguro.Enabled = true;
            txtb_OutrasDeps.Enabled = true;

            txtb_CodigoTransport.Enabled = true;
            txtb_CodigoCondPag.Enabled = true;

            txtb_ChaveAcesso.Enabled = true;
            txtb_CodigoUsu.Enabled = true;

            btn_Gerar.Enabled = true;
            btn_Limpar.Enabled = true;
            btn_PesquisarCondPag.Enabled = true;
            btn_PesquisarFornecedor.Enabled = true;
            btn_PesquisaTransportadora.Enabled = true;
        }

        public void BloquearTxtBox(bool pPK)
        {
            txtb_Modelo.Enabled = pPK;
            txtb_Serie.Enabled = pPK;
            txtb_NumNF.Enabled = pPK;
            txtb_CodigoFornecedor.Enabled = pPK;
            btn_PesquisarFornecedor.Enabled = pPK;

            dt_Chegada.Enabled = false;
            dt_Emissao.Enabled = false;

            groupBox_Produtos.Enabled = false;
            txtb_Frete.Enabled = false;
            txtb_Seguro.Enabled = false;
            txtb_OutrasDeps.Enabled = false;

            txtb_CodigoTransport.Enabled = false;
            txtb_CodigoCondPag.Enabled = false;

            txtb_ChaveAcesso.Enabled = false;
            txtb_CodigoUsu.Enabled = false;

            btn_Gerar.Enabled = false;
            btn_Limpar.Enabled = false;
            btn_PesquisarCondPag.Enabled = false;
            btn_PesquisaTransportadora.Enabled = false;
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
            validarChaveCompra();
        }

        private void validarChaveCompra()
        {
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
            {
                DesBloqTxTBox();
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
                    var vlForn =
                         (Classes.fornecedores)umCtrlCompra.CTRLForn.Pesquisar("codigo",
                                                                            vlCodigo.ToString(),
                                                                            out string vlMsg,
                                                                            false);
                    if (vlForn != null)
                    {
                        if (vlMsg == "")
                        {
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

        private void txtb_Modelo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtb_Modelo.Text))
            {
                errorMSG.SetError(lbl_Modelo, "Insira um valor válido!");
                txtb_Modelo.Focus();
            }
            else
            {
                errorMSG.Clear();
                txtb_Serie.Focus();
            }
        }

        private void txtb_Serie_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtb_Serie.Text))
            {
                errorMSG.SetError(lbl_Serie, "Insira um valor válido!");
                txtb_Serie.Focus();
            }
            else
            {
                errorMSG.Clear();
                txtb_NumNF.Focus();
            }
        }

        private void txtb_NumNF_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtb_NumNF.Text))
            {
                errorMSG.SetError(lbl_NumNF, "Insira um valor válido!");
                txtb_NumNF.Focus();
            }
            else
            {
                errorMSG.Clear();
                btn_PesquisarFornecedor.Focus();
            }
        }

        private void dt_Emissao_Validating(object sender, CancelEventArgs e)
        {
            if (dt_Emissao.Value > DateTime.Now)
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
            if (dt_Chegada.Value > DateTime.Now)
            {
                errorMSG.SetError(lbl_DataChegada, "A data de chegada deve ser igual ou menor\n" +
                                                   $"que a data atual ({DateTime.Now.ToString().Split(' ')[0]})");
                dt_Chegada.Value = DateTime.Now;
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
            if (!int.TryParse(txtb_Quantidade.Text, out int _))
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
            if (!ValidacaoDoubleMoeda(txtb_PrecoUnt.Text))
            {
                errorMSG.SetError(lbl_PrecoUnt, $"Valor '{txtb_PrecoUnt.Text}' inválido");
                txtb_PrecoUnt.Focus();
            }
            else
                errorMSG.Clear();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidacaoDoubleMoeda(txtb_Desconto.Text))
            {
                errorMSG.SetError(lbl_PrecoUnt, $"Valor '{txtb_Desconto.Text}' inválido");
                txtb_Desconto.Text = "0";
            }
            else
                errorMSG.Clear();
        }

        private void btn_Adicionar_Click(object sender, EventArgs e)
        {
            if (lv_ItensCompra.Items.Count == 0)
            {
                errorMSG.SetError(btn_Adicionar, "Insira ao menos um item!");
                btn_PesquisarProduto.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_Produto.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_CodigoProduto, "Selecione um produto");
                btn_PesquisarProduto.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_Unidade.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_Unidade, "Campo 'Unidade' é obrigatório!");
                txtb_Unidade.Focus();
            }
            else if (!int.TryParse(txtb_Quantidade.Text, out int _))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_Quantidade, $"O valor '{txtb_Quantidade.Text}' não é valido!\n" +
                                                  "Insira um valor inteiro igual ou superior a 1");
                txtb_Quantidade.Focus();
            }
            else if (!ValidacaoDoubleMoeda(txtb_PrecoUnt.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_PrecoUnt, $"Valor '{txtb_PrecoUnt.Text}' inválido");
                txtb_PrecoUnt.Focus();
            }
            else if (!ValidacaoDoubleMoeda(txtb_Desconto.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_PrecoUnt, $"Valor '{txtb_Desconto.Text}' inválido");
                txtb_Desconto.Text = "0";
            }
            else
            {
                errorMSG.Clear();
                var vlItem = new itensCompra(txtb_Modelo.Text, txtb_Seguro.Text, txtb_NumNF.Text,
                                                            txtb_Unidade.Text, int.Parse(txtb_Quantidade.Text),
                                                            decimal.Parse(txtb_PrecoUnt.Text, vgEstilo, vgProv),
                                                            decimal.Parse(txtb_Desconto.Text, vgEstilo, vgProv));
                vlItem.UmProduto = umProduto.ThisProduto;
                vlItem.UmFornecedor = umForn.ThisFornecedor;


                var vlString = new string[] { vlItem.UmProduto.Produto, txtb_Unidade.Text, txtb_Quantidade.Text,
                                              vlItem.PrecoUnidade.ToString(), vlItem.Desconto.ToString(), "NC",
                                              (vlItem.Quantidade * vlItem.PrecoUnidade - vlItem.Desconto).ToString() };

                var vlLVItem = new ListViewItem(vlString);
                vlLVItem.Tag = vlItem.ThisItenCompra;

                umaCompra.UmaListaItens.Add(vlItem);
                lv_ItensCompra.Items.Add(vlLVItem);
            }

        }

        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            if (lv_ParcelasContasPag.Items.Count == 0)
            {
                errorMSG.SetError(lbl_ContasPagar, "As parcelas não foram geradas!\nImpossivel cadastrar a compra.");
                btn_Gerar.Focus();
            }
            else
            {
                errorMSG.Clear();
                umaCompra.Emissao = dt_Emissao.Text.Split(' ')[0];
                umaCompra.Chegada = dt_Chegada.Text.Split(' ')[0];
                umaCompra.ChaveAcesso = txtb_ChaveAcesso.Text;
                umaCompra.CodigoUsu = txtb_CodigoUsu.Text == "" ? 0 : int.Parse(txtb_CodigoUsu.Text);
                umaCompra.TotalNota = decimal.Parse(txtb_TotalNota.Text, vgEstilo, vgProv);
                umaCompra.TotalProdutos = decimal.Parse(txtb_TotalProdutos.Text, vgEstilo, vgProv);


                string msg = "";
                if (Btn_Acao == "Salvar")
                {
                    msg = umCtrlCompra.Inserir(umaCompra);
                }
                else if (Btn_Acao == "Alterar")
                {
                    msg = umCtrlCompra.Alterar(umaCompra);
                }
                else if (Btn_Acao == "Excluir")
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
    }
}
