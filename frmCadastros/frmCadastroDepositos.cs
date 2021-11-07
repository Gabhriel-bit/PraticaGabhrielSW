using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_ICI.frmCadastros
{
    public partial class frmCadastroDepositos : Projeto_ICI.frmCadastros.frmCadastroPai
    {
        frmConsultas.frmConsultaCidades frmConsCidade;
        Classes.cidades umaCidade;

        frmConsultas.frmConsultaProdutos frmConsProduto;
        Classes.produtos umProduto;

        Controllers.ctrlDepositos umCtrlDeposito;

        public frmCadastroDepositos(Controllers.ctrlDepositos pCtrlDeposito)
        {
            InitializeComponent();
            umCtrlDeposito = pCtrlDeposito;
            umaCidade = new Classes.cidades();

            umProduto = new Classes.produtos();

            btn_PesquisarProduto.Image = umImgPesquisaSair;
            btn_Pesquisar.Image = umImgPesquisaSair;
        }
        public override void SetFrmCons(Form[] pFrmCad)
        {
            frmConsCidade = (frmConsultas.frmConsultaCidades)pFrmCad[0];
            frmConsProduto = (frmConsultas.frmConsultaProdutos)pFrmCad[1];
        }
        public override void CarregarTxtBox(object pUmObjeto)
        {
            base.CarregarTxtBox(pUmObjeto);
            var vlDeposito = (Classes.depositos)pUmObjeto;
            txtb_Deposito.Text = vlDeposito.Deposito;
            txtb_Logradouro.Text = vlDeposito.Logradouro;
            txtb_Numero.Text = vlDeposito.Numero;
            txtb_Complemento.Text = vlDeposito.Complemento;
            txtb_Bairro.Text = vlDeposito.Bairro;
            txtb_CEP.Text = vlDeposito.CEP;
            txtb_CodigoCidade.Text = vlDeposito.UmaCidade.Codigo.ToString();
            txtb_Cidade.Text = vlDeposito.UmaCidade.Cidade;

        }

        public override void BloquearTxtBox()
        {
            base.BloquearTxtBox();
            txtb_Deposito.Enabled = false;
            txtb_Numero.Enabled = false;
            txtb_Logradouro.Enabled = false;
            txtb_Complemento.Enabled = false;
            txtb_Bairro.Enabled = false;
            txtb_CEP.Enabled = false;
            txtb_CodigoCidade.Enabled = false;
            txtb_CodigoProduto.Enabled = false;
            lv_Produtos.Enabled = false;

            btn_Adicionar.Enabled = false;
            btn_Remover.Enabled = false;
            btn_Pesquisar.Enabled = false;
            btn_PesquisarProduto.Enabled = false;
        }

        public override void DesBloqTxTBox()
        {
            base.DesBloqTxTBox();
            txtb_Deposito.Enabled = true;
            txtb_Numero.Enabled = true;
            txtb_Logradouro.Enabled = true;
            txtb_Complemento.Enabled = true;
            txtb_Bairro.Enabled = true;
            txtb_CEP.Enabled = true;
            txtb_CodigoCidade.Enabled = true;
            txtb_CodigoProduto.Enabled = true;
            lv_Produtos.Enabled = true;

            btn_Adicionar.Enabled = true;
            btn_Remover.Enabled = true;
            btn_Pesquisar.Enabled = true;
            btn_PesquisarProduto.Enabled = true;
        }

        public override void ClearTxTBox()
        {
            base.ClearTxTBox();
            txtb_Deposito.Clear();
            txtb_Numero.Clear();
            txtb_Logradouro.Clear();
            txtb_Complemento.Clear();
            txtb_Bairro.Clear();
            txtb_CEP.Clear();
            txtb_CodigoCidade.Clear();
            txtb_Cidade.Clear();
            txtb_CodigoProduto.Clear();
            txtb_Produto.Clear();
            lv_Produtos.Items.Clear();
        }
        private List<Classes.produtos> lvToList()
        {
            var vlListaProd = new List<Classes.produtos>();
            if (lv_Produtos.Items.Count > 0)
            {
                for (int i = 0; i <= lv_Produtos.Items.Count - 1; i++)
                {
                    var item = (Classes.produtos)lv_Produtos.Items[i].Tag;
                    var vlProduto = (Classes.produtos)umCtrlDeposito.CTRLProduto.Pesquisar("codigo",
                                                                                       item.Codigo.ToString(),
                                                                                       out string vlMsg,
                                                                                       true);
                    if (vlMsg != "")
                    {
                        showErrorMsg(vlMsg);
                        return null;
                    }
                    vlListaProd.Add(vlProduto.ThisProduto);
                }
                return vlListaProd;
            }
            else
            {
                showErrorMsg("Erro ao criar lista de produtos!");
                return null;
            }
        }

        private void listToLv(List<Classes.produtos> pListaProd)
        {
            if (pListaProd != null && pListaProd.Count > 0)
            {
                lv_Produtos.Items.Clear();
                foreach (Classes.produtos vlProd in pListaProd)
                {
                    string[] item = { vlProd.Codigo.ToString(),
                                      vlProd.Produto,
                                      vlProd.UmModelo.UmaMarca.Marca,
                                      vlProd.UmModelo.Modelo,
                                      vlProd.Referencia,
                                      vlProd.CodigoBarras,
                                      vlProd.UmSubgrupo.Subgrupo,
                                      vlProd.Unidade.ToString(),
                                      vlProd.Saldo.ToString(),
                                      vlProd.Custo.ToString()};
                    var lvItem = new ListViewItem(item);
                    lvItem.Tag = vlProd.ThisProduto;
                    lv_Produtos.Items.Add(lvItem);
                }
            }
            else
            {
                showErrorMsg("Erro ao carregar lista de fornecedores!");
            }
        }
        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            var nomeBtn = frmConsCidade.Btn_Sair;
            frmConsCidade.Btn_Sair = "Selecionar";
            frmConsCidade.ConhecaOBJ(umaCidade);
            frmConsCidade.ShowDialog();
            frmConsCidade.Btn_Sair = nomeBtn;
            if (umaCidade.Codigo != 0)
            {
                txtb_Cidade.Text = umaCidade.Cidade;
                txtb_CodigoCidade.Text = umaCidade.Codigo.ToString();
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

        private void btn_Cadastro_Click(object sender, EventArgs e)
        {
            closing = true;
            if (string.IsNullOrEmpty(txtb_Deposito.Text))
            {
                errorMSG.SetError(lbl_Deposito, "O campo 'Deposito' é obrigatório!");
                txtb_Produto.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_Logradouro.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_Logradouro, "O compo 'Logradouro' é obrigatório!");
                txtb_Logradouro.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_Numero.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_Numero, "O campo 'Numero' é obrigatório!");
                txtb_Numero.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_Bairro.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_Bairro, "O campo 'Bairro' é obrigatório");
                txtb_Bairro.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_Cidade.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_Cidade, "Campo 'Cidade' deve ser inserido" +
                                              "usando o campo 'Código' ou o botão" +
                                              "'Pesquisar'");
                txtb_CodigoCidade.Focus();
            }
            else if (lv_Produtos.Items.Count == 0)
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_Produto, "Deve haver ao menos um produto cadastrado!");
                txtb_CodigoProduto.Focus();
            }
            else
            {
                var vlProduto = new Classes.depositos(txtb_Codigo.Text == "" ? 0 : int.Parse(txtb_Codigo.Text),
                                                       txtb_CodigoUsu.Text == "" ? 0 : int.Parse(txtb_CodigoUsu.Text),
                                                       txtb_DataCadastro.Text,
                                                       txtb_DataUltAlt.Text,
                                                       txtb_Deposito.Text,
                                                       txtb_Logradouro.Text,
                                                       txtb_Numero.Text,
                                                       txtb_Complemento.Text,
                                                       txtb_Bairro.Text,
                                                       txtb_CEP.Text);
                vlProduto.UmaCidade.ThisCidade = umaCidade;
                vlProduto.ListaProd = lvToList();
                ObjToDataBase(vlProduto, umCtrlDeposito);
            }
        }

        private void btn_Adicionar_Click(object sender, EventArgs e)
        {
            if (lv_Produtos != null && txtb_Produto.Text != "")
            {
                string[] item = { umProduto.Codigo.ToString(),
                                  umProduto.Produto,
                                  umProduto.UmModelo.UmaMarca.Marca,
                                  umProduto.UmModelo.Modelo,
                                  umProduto.Referencia,
                                  umProduto.CodigoBarras,
                                  umProduto.UmSubgrupo.Subgrupo,
                                  umProduto.Unidade.ToString(),
                                  umProduto.Saldo.ToString(),
                                  umProduto.Custo.ToString()};
                var lvItem = new ListViewItem(item);
                lvItem.Tag = umProduto.ThisProduto;
                if (lv_Produtos.Items.Count != 0 && !lv_Produtos.Items.Contains(lvItem))
                {
                    errorMSG.SetError(lbl_btn_Adicionar, "O produto já está adicionado!");
                }
                else
                {
                    errorMSG.Clear();
                    txtb_CodigoProduto.Clear();
                    txtb_Produto.Clear();
                    lv_Produtos.Items.Add(lvItem);
                }
            }
        }

        private void txtb_CodigoProduto_TextChanged(object sender, EventArgs e)
        {
            if (txtb_CodigoProduto.Text == "")
            {
                txtb_Produto.Clear();
            }
            else
            {
                if (int.TryParse(txtb_CodigoProduto.Text, out int vlCodigo))
                {
                    var vlProduto =
                         (Classes.produtos)umCtrlDeposito.CTRLProduto.Pesquisar("codigo",
                                                                            vlCodigo.ToString(),
                                                                            out string vlMsg,
                                                                            true);
                    if (vlProduto != null)
                    {
                        if (vlMsg == "")
                        {
                            txtb_Produto.Text = vlProduto.Produto;
                            umProduto.ThisProduto = vlProduto;
                        }
                        else
                        {
                            showErrorMsg(vlMsg);
                            txtb_Produto.Clear();
                        }
                    }
                    else
                    {
                        txtb_Produto.Clear();
                    }
                }
            }
        }

        private void txtb_CodigoCidade_TextChanged(object sender, EventArgs e)
        {
            if (txtb_CodigoCidade.Text == "")
            {
                txtb_Cidade.Clear();
            }
            else
            {
                if (int.TryParse(txtb_CodigoCidade.Text, out int vlCodigo))
                {
                    var vlCidade =
                         (Classes.cidades)umCtrlDeposito.CTRLCidade.Pesquisar("codigo",
                                                                              vlCodigo.ToString(),
                                                                              out string vlMsg,
                                                                              false);
                    if (vlCidade != null)
                    {
                        if (vlMsg == "")
                        {
                            txtb_Cidade.Text = vlCidade.Cidade;
                            vlCidade.ThisCidade = vlCidade;
                        }
                        else
                        {
                            showErrorMsg(vlMsg);
                            txtb_Cidade.Clear();
                        }
                    }
                    else
                    {
                        txtb_Cidade.Clear();
                    }
                }
            }
        }

        private void btn_Remover_Click(object sender, EventArgs e)
        {
            if (lv_Produtos.Items.Count != 0 && lv_Produtos.SelectedItems.Count > 0)
            {
                lv_Produtos.Items.Remove(lv_Produtos.SelectedItems[0]);
                errorMSG.SetError(lbl_btn_Remover, null);
            }
            else
            {
                errorMSG.SetError(lbl_btn_Remover, "Erro ao remover fornecedor!");
            }
        }

        private void txtb_CodigoCidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacaoCodigo(txtb_CodigoCidade, e);
        }

        private void txtb_CodigoProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacaoCodigo(txtb_CodigoProduto, e);
        }

        private void btn_PesquisarProduto_MouseEnter(object sender, EventArgs e)
        {
            btn_PesquisarProduto.Image = umImgPesquisaEntrar;
        }

        private void btn_PesquisarProduto_MouseLeave(object sender, EventArgs e)
        {
            btn_PesquisarProduto.Image = umImgPesquisaSair;
        }

        private void btn_Pesquisar_MouseEnter(object sender, EventArgs e)
        {
            btn_Pesquisar.Image = umImgPesquisaEntrar;
        }

        private void btn_Pesquisar_MouseLeave(object sender, EventArgs e)
        {
            btn_Pesquisar.Image = umImgPesquisaSair;
        }

        private void txtb_Deposito_Validating(object sender, CancelEventArgs e)
        {
            ValidarNome(txtb_Deposito, lbl_Deposito, "deposito", umCtrlDeposito, e);
        }

        private void txtb_Logradouro_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtb_Logradouro.Text))
            {
                errorMSG.SetError(lbl_Logradouro, "Logradouro inválido!");
                e.Cancel = closing;
            }
            else
            {
                errorMSG.Clear();
                e.Cancel = false;
            }
        }

        private void txtb_Numero_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtb_Numero.Text))
            {
                errorMSG.SetError(lbl_Numero, "Número inválido!");
                e.Cancel = closing;
            }
            else
            {
                errorMSG.Clear();
                e.Cancel = false;
            }
        }

        private void txtb_Bairro_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtb_Bairro.Text))
            {
                errorMSG.SetError(lbl_Bairro, "Bairro inválido!");
                e.Cancel = closing;
            }
            else
            {
                errorMSG.Clear();
                e.Cancel = false;
            }
        }
    }
}
