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
        List<Classes.subgrupos> listaSubgrupos;
        Classes.subgrupos umSubgrupo;

        frmConsultas.frmConsultaFornecedores frmConsForn;
        List<Classes.fornecedores> listaForn;
        Classes.fornecedores umForn;

        frmConsultas.frmConsultaModelos frmConsModelo;
        List<Classes.modelos> listaModelos;
        Classes.modelos umModelo;

        Controllers.ctrlProdutos umaCtrlProduto;
        public frmCadastroProdutos()
        {
            InitializeComponent();
            umaCtrlProduto = new Controllers.ctrlProdutos();

            frmConsSubGrupo = new frmConsultas.frmConsultaSubgrupos();
            listaSubgrupos = new List<Classes.subgrupos>();
            umSubgrupo = new Classes.subgrupos();

            frmConsForn = new frmConsultas.frmConsultaFornecedores();
            listaForn = new List<Classes.fornecedores>();
            umForn = new Classes.fornecedores();

            frmConsModelo = new frmConsultas.frmConsultaModelos();
            listaModelos = new List<Classes.modelos>();
            umModelo = new Classes.modelos();
        }
        public frmCadastroProdutos(BancoDados.conexoes pUmaConexao)
        {
            InitializeComponent();
            umaCtrlProduto = new Controllers.ctrlProdutos(pUmaConexao);

            listaSubgrupos = umaCtrlProduto.CTRLSubgrupo.PesquisarCollection();
            umSubgrupo = new Classes.subgrupos();

            listaForn = umaCtrlProduto.CTRLFornecedor.PesquisarCollection();
            umForn = new Classes.fornecedores();

            listaModelos = umaCtrlProduto.CTRLModelo.PesquisarCollection();
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
            txtb_Saldo.Text = vlProduto.Saldo.ToString();
            txtb_CodigoSubGrupo.Text = vlProduto.UmSubgrupo.Codigo.ToString();
            txtb_SubGrupo.Text = vlProduto.UmSubgrupo.Subgrupo;
            txtb_CodigoModelo.Text = vlProduto.UmModelo.Codigo.ToString();
            txtb_Modelo.Text = vlProduto.UmModelo.Modelo;
            txtb_Marca.Text = vlProduto.UmModelo.UmaMarca.Marca;
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
            txtb_Custo.Enabled = false;
            txtb_Produto.Enabled = false;
            txtb_Unidade.Enabled = false;
            txtb_Referencia.Enabled = false;
            txtb_Saldo.Enabled = false;
            lv_Fornecedores.Enabled = false;

            btn_Adicionar.Enabled = false;
            btn_PesquisarFornecedor.Enabled = false;
            btn_PesquisarModelo.Enabled = false;
            btn_PesquisarSubGrupo.Enabled = false;
            btn_Remover.Enabled = false;
        }
        public override void DesBloqTxTBox()
        {
            base.DesBloqTxTBox();
            txtb_CodigoBarras.Enabled = true;
            txtb_CodigoFornecedor.Enabled = true;
            txtb_CodigoUsu.Enabled = true;
            txtb_CodigoModelo.Enabled = true;
            txtb_CodigoSubGrupo.Enabled = true;
            txtb_Custo.Enabled = true;
            txtb_Produto.Enabled = true;
            txtb_Unidade.Enabled = true;
            txtb_Referencia.Enabled = true;
            txtb_Saldo.Enabled = true;
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
                    foreach (Classes.fornecedores vlForn in listaForn)
                    {
                        if (vlForn.Codigo == item.Codigo)
                        {
                            vlListaForn.Add(vlForn.ThisFornecedor);
                            break;
                        }
                    }
                }
                return vlListaForn;
            }
            else
            {
                MessageBox.Show("Erro ao criar lista de fornecedores!");
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
                                           vlForn.CNPJ_CPF };
                    var lvItem = new ListViewItem(vlStrForn);
                    lvItem.Tag = vlForn.ThisFornecedor;
                    lv_Fornecedores.Items.Add(lvItem);
                }
            }
            else
            {
                MessageBox.Show("Erro ao carregar lista de fornecedores!");
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
            listaForn = umaCtrlProduto.CTRLFornecedor.PesquisarCollection();
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
            listaSubgrupos = umaCtrlProduto.CTRLSubgrupo.PesquisarCollection();
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
            listaModelos = umaCtrlProduto.CTRLModelo.PesquisarCollection();
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
            if (lv_Fornecedores != null && txtb_Fornecedor.Text != "" && listaForn.Count > 0)
            {
                foreach (Classes.fornecedores vlForn in listaForn)
                {
                    if (vlForn.Codigo == int.Parse(txtb_CodigoFornecedor.Text))
                    {
                        umForn.ThisFornecedor = vlForn;
                        break;
                    }
                }
                string[] item = { umForn.Codigo.ToString(),
                                  umForn.Fornecedor,
                                  umForn.CNPJ_CPF };
                var lvItem = new ListViewItem(item);
                lvItem.Tag = umForn; bool vlFind = false;
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
                if (int.TryParse(txtb_CodigoFornecedor.Text, out int i))
                {
                    foreach (Classes.fornecedores vlForn in listaForn)
                    {
                        if (vlForn.Codigo == i)
                        {
                            txtb_Fornecedor.Text = vlForn.Fornecedor;
                            umForn = vlForn.ThisFornecedor;
                        }
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
                if (int.TryParse(txtb_CodigoSubGrupo.Text, out int i))
                {
                    foreach (Classes.subgrupos vlSubgrupo in listaSubgrupos)
                    {
                        if (vlSubgrupo.Codigo == i)
                        {
                            txtb_SubGrupo.Text = vlSubgrupo.Subgrupo;
                            umSubgrupo = vlSubgrupo.ThisSubgrupo;
                        }
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
                if (int.TryParse(txtb_CodigoModelo.Text, out int i))
                {
                    foreach (Classes.modelos vlModelo in listaModelos)
                    {
                        if (vlModelo.Codigo == i)
                        {
                            txtb_Modelo.Text = vlModelo.Modelo;
                            txtb_Marca.Text = vlModelo.UmaMarca.Marca;
                            umModelo = vlModelo.ThisModelo;
                        }
                    }
                }
            }
        }
        private void txtb_Unidade_Validating(object sender, CancelEventArgs e)
        {
            if (ValidacaoIntPositivo(txtb_Unidade.Text, false))
            {
                errorMSG.Clear();
                e.Cancel = false;
            }
            else
            {
                errorMSG.SetError(lbl_Unidade, "Insira um número positivo maior que zero!");
                e.Cancel = true;
            }
        }
        private void txtb_Produto_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtb_Produto.Text))
            {
                errorMSG.SetError(lbl_Produto, "O campo 'Produto' é obrigatório!");
                e.Cancel = true;
            }
            else
            {
                errorMSG.Clear();
                e.Cancel = false;
            }
        }
        private void btn_Cadastro_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtb_Produto.Text))
            {
                errorMSG.SetError(lbl_Produto, "O campo 'Produto' é obrigatório!");
                txtb_Produto.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_Unidade.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_Unidade, "O campo 'Unidade' é obrigatório!");
                txtb_Unidade.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_Modelo.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_Modelo, "Campo 'Modelo' deve ser inserido" +
                                              "usando o campo 'Código' ou o botão" +
                                              "'Pesquisar'");
                txtb_CodigoModelo.Focus();
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
                                                       decimal.Parse(txtb_Custo.Text == "" ? "0" : txtb_Custo.Text.Replace(".", ","), vgEstilo, vgProv),
                                                       int.Parse(txtb_Unidade.Text),
                                                       int.Parse(txtb_Saldo.Text == "" ? "0" : txtb_Saldo.Text));
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
    }
}
