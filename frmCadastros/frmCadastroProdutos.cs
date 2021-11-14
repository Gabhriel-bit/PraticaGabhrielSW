using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_ICI.frmCadastros
{
    public partial class frmCadastroProdutos : Projeto_ICI.frmCadastros.frmCadastroPai
    {
        frmConsultas.frmConsultaSubgrupos frmConsSubGrupo;
        Classes.subgrupos umSubgrupo;

        frmConsultas.frmConsultaFornecedores frmConsForn;
        Classes.fornecedores umForn;

        frmConsultas.frmConsultaModelos frmConsModelo;
        Classes.modelos umModelo;

        Controllers.ctrlProdutos umaCtrlProduto;

        public frmCadastroProdutos(Controllers.ctrlProdutos pCtrlProduto)
        {
            InitializeComponent();
            umaCtrlProduto = pCtrlProduto;
            umSubgrupo = new Classes.subgrupos();
            umForn = new Classes.fornecedores();
            umModelo = new Classes.modelos();

            btn_PesquisarFornecedor.Image = umImgPesquisaSair;
            btn_PesquisarModelo.Image = umImgPesquisaSair;
            btn_PesquisarSubGrupo.Image = umImgPesquisaSair;
        }
        public override void SetFrmCons(Form[] pFrmCad)
        {
            frmConsSubGrupo = (frmConsultas.frmConsultaSubgrupos)pFrmCad[0];
            frmConsForn = (frmConsultas.frmConsultaFornecedores)pFrmCad[1];
            frmConsModelo = (frmConsultas.frmConsultaModelos)pFrmCad[2];
        }
        public override void CarregarTxtBox(object pUmObjeto)
        {
            base.CarregarTxtBox(pUmObjeto);
            var vlProduto = (Classes.produtos)pUmObjeto;
            txtb_Produto.Text = vlProduto.Produto;
            txtb_Unidade.Text = vlProduto.Unidade.ToString();
            txtb_Referencia.Text = vlProduto.Referencia;
            txtb_CodigoBarras.Text = vlProduto.CodigoBarras;
            txtb_Custo.Text = vlProduto.Custo.ToString();
            txtb_PrecoVenda.Text = vlProduto.PrecoVenda.ToString();
            txtb_Saldo.Text = vlProduto.Saldo.ToString();
            txtb_CodigoSubGrupo.Text = vlProduto.UmSubgrupo.Codigo.ToString();
            txtb_SubGrupo.Text = vlProduto.UmSubgrupo.Subgrupo;
            txtb_CodigoModelo.Text = vlProduto.UmModelo.Codigo.ToString();
            txtb_Modelo.Text = vlProduto.UmModelo.Modelo;
            txtb_Marca.Text = vlProduto.UmModelo.UmaMarca.Marca;
            txtb_PesoBruto.Text = vlProduto.PesoBruto.ToString();
            txtb_PesoLiquido.Text = vlProduto.PesoLiquido.ToString();
            txtb_PrecoUltCompra.Text = vlProduto.UltimaCompra.ToString();
            listToLv(vlProduto.ListaFornecedores);
        }
        public override void BloquearTxtBox()
        {
            base.BloquearTxtBox();
            txtb_CodigoBarras.Enabled = false;
            txtb_CodigoFornecedor.Enabled = false;
            txtb_CodigoUsu.Enabled = false;
            txtb_CodigoModelo.Enabled = false;
            txtb_CodigoSubGrupo.Enabled = false;
            txtb_Produto.Enabled = false;
            txtb_Unidade.Enabled = false;
            txtb_Referencia.Enabled = false;
            txtb_PesoBruto.Enabled = false;
            txtb_PesoLiquido.Enabled = false;
            lv_Fornecedores.Enabled = false;

            btn_Adicionar.Enabled = false;
            btn_PesquisarFornecedor.Enabled = false;
            btn_PesquisarModelo.Enabled = false;
            btn_PesquisarSubGrupo.Enabled = false;
            btn_Remover.Enabled = false;
        }
        public override void DesBloqTxTBox()
        {
            txtb_CodigoBarras.Enabled = true;
            txtb_CodigoFornecedor.Enabled = true;
            txtb_CodigoUsu.Enabled = true;
            txtb_CodigoModelo.Enabled = true;
            txtb_CodigoSubGrupo.Enabled = true;
            txtb_Produto.Enabled = true;
            txtb_Unidade.Enabled = true;
            txtb_Referencia.Enabled = true;
            txtb_PesoBruto.Enabled = true;
            txtb_PesoLiquido.Enabled = true;
            lv_Fornecedores.Enabled = true;

            btn_Adicionar.Enabled = true;
            btn_PesquisarFornecedor.Enabled = true;
            btn_PesquisarModelo.Enabled = true;
            btn_PesquisarSubGrupo.Enabled = true;
            btn_Remover.Enabled = true;
        }
        public override void ClearTxTBox()
        {
            base.ClearTxTBox();
            txtb_CodigoBarras.Clear();
            txtb_CodigoFornecedor.Clear();
            txtb_CodigoUsu.Clear();
            txtb_Saldo.Clear();
            txtb_CodigoModelo.Clear();
            txtb_CodigoSubGrupo.Clear();
            txtb_Custo.Clear();
            txtb_Fornecedor.Clear();
            txtb_Marca.Clear();
            txtb_Modelo.Clear();
            txtb_Produto.Clear();
            txtb_SubGrupo.Clear();
            txtb_Unidade.Clear();
            txtb_Referencia.Clear();
            txtb_PesoBruto.Clear();
            txtb_PesoLiquido.Clear();
            txtb_PrecoUltCompra.Clear();
            lv_Fornecedores.Items.Clear();
        }
        private List<Classes.fornecedores> lvToList()
        {
            var vlListaForn = new List<Classes.fornecedores>();
            if (lv_Fornecedores.Items.Count > 0)
            {
                for (int i = 0; i <= lv_Fornecedores.Items.Count - 1; i++)
                {
                    var item = (Classes.fornecedores)lv_Fornecedores.Items[i].Tag;
                    vlListaForn.Add(item.ThisFornecedor);
                }
                return vlListaForn;
            }
            else
            {
                showErrorMsg("Erro ao criar lista de fornecedores!");
                return null;
            }
        }
        private void listToLv(List<Classes.fornecedores> pListaForn)
        {
            if (pListaForn != null && pListaForn.Count > 0)
            {
                lv_Fornecedores.Items.Clear();
                foreach (Classes.fornecedores vlForn in pListaForn)
                {
                    string[] vlStrForn = { vlForn.Codigo.ToString(),
                                           vlForn.Fornecedor,
                                           vlForn.CNPJ_CPF,
                                           vlForn.Email };
                    var lvItem = new ListViewItem(vlStrForn);
                    lvItem.Tag = vlForn.ThisFornecedor;
                    lv_Fornecedores.Items.Add(lvItem);
                }
            }
            else
            {
                showErrorMsg("Erro ao carregar lista de fornecedores!");
            }
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
        private void btn_PesquisarSubGrupo_Click(object sender, EventArgs e)
        {
            var nomeBtn = frmConsSubGrupo.Btn_Sair;
            frmConsSubGrupo.Btn_Sair = "Selecionar";
            frmConsSubGrupo.ConhecaOBJ(umSubgrupo);
            frmConsSubGrupo.ShowDialog();
            frmConsSubGrupo.Btn_Sair = nomeBtn;
            if (umSubgrupo.Codigo != 0)
            {
                txtb_CodigoSubGrupo.Text = umSubgrupo.Codigo.ToString();
                txtb_SubGrupo.Text = umSubgrupo.Subgrupo;
            }
        }
        private void btn_PesquisarModelo_Click(object sender, EventArgs e)
        {
            var nomeBtn = frmConsModelo.Btn_Sair;
            frmConsModelo.Btn_Sair = "Selecionar";
            frmConsModelo.ConhecaOBJ(umModelo);
            frmConsModelo.ShowDialog();
            frmConsModelo.Btn_Sair = nomeBtn;
            if (umModelo.Codigo != 0)
            {
                txtb_CodigoModelo.Text = umModelo.Codigo.ToString();
                txtb_Modelo.Text = umModelo.Modelo;
                txtb_Marca.Text = umModelo.UmaMarca.Marca;
            }
        }
        private void btn_Remover_Click(object sender, EventArgs e)
        {
            if (lv_Fornecedores.Items.Count != 0 && lv_Fornecedores.SelectedItems.Count > 0)
            {
                lv_Fornecedores.Items.Remove(lv_Fornecedores.SelectedItems[0]);
                errorMSG.SetError(lbl_btn_Remover, null);
            }
            else
            {
                errorMSG.SetError(lbl_btn_Remover, "Erro ao remover fornecedor!");
            }
        }
        private void btn_Adicionar_Click(object sender, EventArgs e)
        {
            if (lv_Fornecedores != null && txtb_Fornecedor.Text != "")
            {
                string[] item = { umForn.Codigo.ToString(),
                                  umForn.Fornecedor,
                                  umForn.CNPJ_CPF,
                                  umForn.Email };

                var lvItem = new ListViewItem(item);
                lvItem.Tag = umForn.ThisFornecedor;

                bool vlFind = false;
                foreach (ListViewItem vlItems in lv_Fornecedores.Items)
                {
                    if (((Classes.fornecedores)vlItems.Tag).Codigo == umForn.Codigo)
                    { vlFind = true; }
                }
                if (vlFind)
                {
                    errorMSG.SetError(lbl_btn_Adicionar, "O fonecedor já está adicionado!");
                }
                else
                {
                    errorMSG.Clear();
                    txtb_CodigoFornecedor.Clear();
                    txtb_Fornecedor.Clear();
                    lv_Fornecedores.Items.Add(lvItem);
                }
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
                         (Classes.fornecedores)umaCtrlProduto.CTRLFornecedor.Pesquisar("codigo",
                                                                            vlCodigo.ToString(),
                                                                            out string vlMsg,
                                                                            false);
                    if (vlForn != null)
                    {
                        if (vlMsg == "")
                        {
                            txtb_Fornecedor.Text = vlForn.Fornecedor;
                            umForn.ThisFornecedor = vlForn;
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
        private void txtb_CodigoSubGrupo_TextChanged(object sender, EventArgs e)
        {
            if (txtb_CodigoSubGrupo.Text == "")
            {
                txtb_SubGrupo.Clear();
            }
            else
            {
                if (int.TryParse(txtb_CodigoSubGrupo.Text, out int vlCodigo))
                {
                    var vlSubgrupo =
                         (Classes.subgrupos)umaCtrlProduto.CTRLSubgrupo.Pesquisar("codigo",
                                                                            vlCodigo.ToString(),
                                                                            out string vlMsg,
                                                                            false);
                    if (vlSubgrupo != null)
                    {
                        if (vlMsg == "")
                        {
                            txtb_SubGrupo.Text = vlSubgrupo.Subgrupo;
                            umSubgrupo.ThisSubgrupo = vlSubgrupo;
                        }
                        else
                        {
                            showErrorMsg(vlMsg);
                            txtb_SubGrupo.Clear();
                        }
                    }
                    else
                    {
                        txtb_SubGrupo.Clear();
                    }
                }
            }
        }
        private void txtb_CodigoModelo_TextChanged(object sender, EventArgs e)
        {
            if (txtb_CodigoModelo.Text == "")
            {
                txtb_Modelo.Clear();
                txtb_Marca.Clear();
            }
            else
            {
                if (int.TryParse(txtb_CodigoModelo.Text, out int vlCodigo))
                {
                    var vlModelo =
                         (Classes.modelos)umaCtrlProduto.CTRLModelo.Pesquisar("codigo",
                                                                            vlCodigo.ToString(),
                                                                            out string vlMsg,
                                                                            false);
                    if (vlModelo != null)
                    {
                        if (vlMsg == "")
                        {
                            txtb_Modelo.Text = vlModelo.Modelo;
                            txtb_Marca.Text = vlModelo.UmaMarca.Marca;
                            umModelo.ThisModelo = vlModelo;
                        }
                        else
                        {
                            showErrorMsg(vlMsg);
                            txtb_Modelo.Clear();
                            txtb_Marca.Clear();
                        }
                    }
                    else
                    {
                        txtb_Modelo.Clear();
                        txtb_Marca.Clear();
                    }
                }
            }
        }
        private void txtb_Unidade_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtb_Unidade.Text))
            {
                errorMSG.Clear();
                e.Cancel = false;
            }
            else
            {
                errorMSG.SetError(lbl_Unidade, "O campo UND (unidade) é obrigatório!");
                e.Cancel = closing;
            }
        }
        private void txtb_Produto_Validating(object sender, CancelEventArgs e)
        {
            ValidarNome(txtb_Produto, lbl_Produto, "produto", umaCtrlProduto, e);

        }
        private void btn_Cadastro_Click(object sender, EventArgs e)
        {
            closing = true;
            if (string.IsNullOrEmpty(txtb_Produto.Text))
            {
                errorMSG.SetError(lbl_Produto, "O campo 'Produto' é obrigatório!");
                txtb_Produto.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_Unidade.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_Unidade, "O campo 'UND' (unidade) é obrigatório!");
                txtb_Unidade.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_PrecoVenda.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_PrecoVenda, "O campo 'Preço venda' é obrigatório!");
                txtb_PrecoVenda.Focus();
            }
            else if (!ValidacaoDoubleMoeda(txtb_PesoBruto.Text, false))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_PesoBruto, "O campo 'Peso Bruto' é obrigatório!");
                txtb_PesoBruto.Focus();
            }
            else if (verificarPesoLiq())
            {
                txtb_PesoLiquido.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_Modelo.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_Modelo, "Campo 'Modelo' deve ser inserido" +
                                              "usando o campo 'Código' ou o botão" +
                                              "'Pesquisar'");
                txtb_CodigoModelo.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_SubGrupo.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_SubGrupo, "Campo 'Subgrupo' deve ser inserido" +
                                              "usando o campo 'Código' ou o botão" +
                                              "'Pesquisar'");
                txtb_CodigoSubGrupo.Focus();
            }
            else if (lv_Fornecedores.Items.Count == 0)
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_Fornecedor, "Insira ao menos um fornecedor");
                txtb_CodigoFornecedor.Focus();
            }
            else
            {
                var vlProduto = new Classes.produtos(txtb_Codigo.Text == "" ? 0 : int.Parse(txtb_Codigo.Text),
                                                       txtb_CodigoUsu.Text == "" ? 0 : int.Parse(txtb_CodigoUsu.Text),
                                                       txtb_DataCadastro.Text,
                                                       txtb_DataUltAlt.Text,
                                                       txtb_Produto.Text,
                                                       txtb_Referencia.Text,
                                                       txtb_CodigoBarras.Text,
                                                       strToDecimal(txtb_Custo.Text),
                                                       txtb_Unidade.Text,
                                                       int.Parse(txtb_Saldo.Text == "" ? "0" : txtb_Saldo.Text),
                                                       strToDecimal(txtb_PesoBruto.Text),
                                                       strToDecimal(txtb_PesoLiquido.Text),
                                                       strToDecimal(txtb_PrecoUltCompra.Text),
                                                       strToDecimal(txtb_PrecoVenda.Text));
                vlProduto.UmModelo.ThisModelo = umModelo;
                vlProduto.UmSubgrupo.ThisSubgrupo = umSubgrupo;
                vlProduto.ListaFornecedores = lvToList();
                ObjToDataBase(vlProduto, umaCtrlProduto);
            }
        }

        private void btn_PesquisarModelo_MouseEnter(object sender, EventArgs e)
        {
            btn_PesquisarModelo.Image = umImgPesquisaEntrar;
        }

        private void btn_PesquisarModelo_MouseLeave(object sender, EventArgs e)
        {
            btn_PesquisarModelo.Image = umImgPesquisaSair;
        }

        private void btn_PesquisarSubGrupo_MouseEnter(object sender, EventArgs e)
        {
            btn_PesquisarSubGrupo.Image = umImgPesquisaEntrar;
        }

        private void btn_PesquisarSubGrupo_MouseLeave(object sender, EventArgs e)
        {
            btn_PesquisarSubGrupo.Image = umImgPesquisaSair;
        }

        private void btn_PesquisarFornecedor_MouseEnter(object sender, EventArgs e)
        {
            btn_PesquisarFornecedor.Image = umImgPesquisaEntrar;
        }

        private void btn_PesquisarFornecedor_MouseLeave(object sender, EventArgs e)
        {
            btn_PesquisarFornecedor.Image = umImgPesquisaSair;
        }

        private void lbl_Custo_Validating(object sender, CancelEventArgs e)
        {
            if (ValidacaoDoubleMoeda(txtb_Custo.Text, false))
            {
                errorMSG.Clear();
                e.Cancel = false;
            }
            else
            {
                errorMSG.SetError(lbl_Unidade, "O campo Custo inválido!");
                e.Cancel = closing;
            }
        }

        private void txtb_Saldo_Validating(object sender, CancelEventArgs e)
        {
            if (ValidacaoIntPositivo(txtb_Custo.Text, false))
            {
                errorMSG.Clear();
                e.Cancel = false;
            }
            else
            {
                errorMSG.SetError(lbl_Unidade, "O campo Custo inválido!");
                e.Cancel = closing;
            }
        }

        private void txtb_PesoBruto_Validating(object sender, CancelEventArgs e)
        {
            if (ValidacaoDoubleMoeda(txtb_PesoBruto.Text, false))
            {
                errorMSG.Clear();
                e.Cancel = false;
            }
            else
            {
                errorMSG.SetError(lbl_PesoBruto, "Campo 'Peso bruto' inválido!");
                e.Cancel = closing;
            }
        }

        private void txtb_PesoLiquido_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = verificarPesoLiq();
        }

        private bool verificarPesoLiq()
        {
            var vlPesoB = strToDecimal(txtb_PesoBruto.Text);
            var vlPesoL = strToDecimal(txtb_PesoLiquido.Text);

            errorMSG.Clear();
            if (ValidacaoDoubleMoeda(txtb_PesoLiquido.Text, false) && (vlPesoL <= vlPesoB))
            {
                errorMSG.Clear();
                return false;
            }
            else
            {
                var vlMsg = "Campo 'Peso líquido' inválido!";
                if (vlPesoL > vlPesoB)
                {
                    vlMsg = "O peso líquiso deve ser igual ou inferior ao peso bruto!" +
                            $"\nPeso bruto:   {vlPesoB}\nPeso líquido: {vlPesoL}";
                }
                errorMSG.SetError(lbl_PesoLiquido, vlMsg);
                return closing;
            }
        }

        private void txtb_PrecoVenda_Validating(object sender, CancelEventArgs e)
        {
            if (ValidacaoDoubleMoeda(txtb_PrecoVenda.Text, false))
            {
                errorMSG.Clear();
                e.Cancel = false;
            }
            else
            {
                errorMSG.SetError(lbl_PrecoVenda, "Campo 'Preço venda' inválido!");
                e.Cancel = closing;
            }
        }
    }
}
