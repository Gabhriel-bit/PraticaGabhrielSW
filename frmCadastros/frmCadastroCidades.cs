using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_ICI.frmCadastros
{
    public partial class frmCadastroCidades : Projeto_ICI.frmCadastros.frmCadastroPai
    {
        frmConsultas.frmConsultaEstados frmConsEstado;
        Controllers.ctrlCidades umCtrlCidade;
        Classes.estados umEstado;
        List<Classes.estados> listaEstados;
        public frmCadastroCidades()
        {
            InitializeComponent();
            frmConsEstado = new frmConsultas.frmConsultaEstados();
            umCtrlCidade = new Controllers.ctrlCidades();
            umEstado = new Classes.estados();
            listaEstados = new List<Classes.estados>();
        }

        public frmCadastroCidades(BancoDados.conexoes pUmaConexao)
        {
            InitializeComponent();
            umCtrlCidade = new Controllers.ctrlCidades(pUmaConexao);
            umEstado = new Classes.estados();
            listaEstados = umCtrlCidade.CTRLEstado.PesquisarCollection(out string vlMsg);
            showErrorMsg(vlMsg);
            btn_Pesquisar.Image = umImgPesquisaSair;
        }
        public override void SetFrmCons(Form pFrmCad)
        {
            frmConsEstado = (frmConsultas.frmConsultaEstados)pFrmCad;
        }
        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            var nomeBtn = frmConsEstado.Btn_Sair;
            frmConsEstado.Btn_Sair = "Selecionar";
            frmConsEstado.ConhecaOBJ(umEstado);
            frmConsEstado.ShowDialog();
            frmConsEstado.Btn_Sair = nomeBtn;
            if (umEstado.Codigo != 0)
            {
                txtb_CodigoEstado.Text = umEstado.Codigo.ToString();
                txtb_Estado.Text = umEstado.Estado;
            }
            listaEstados = umCtrlCidade.CTRLEstado.PesquisarCollection(out string vlMsg);
            showErrorMsg(vlMsg);
        }

        public override void CarregarTxtBox(object pUmObjeto)
        {
            base.CarregarTxtBox(pUmObjeto);
            txtb_Cidade.Text = ((Classes.cidades)pUmObjeto).Cidade;
            txtb_DDD.Text = ((Classes.cidades)pUmObjeto).DDD;
            txtb_CodigoEstado.Text = ((Classes.cidades)pUmObjeto).UmEstado.Codigo.ToString();
            txtb_Estado.Text = ((Classes.cidades)pUmObjeto).UmEstado.Estado;

        }

        public override void DesBloqTxTBox()
        {
            txtb_Cidade.Enabled = true;
            txtb_CodigoEstado.Enabled = true;
            //txtb_Estado.Enabled = true;
            txtb_DDD.Enabled = true;
            btn_Pesquisar.Enabled = true;
        }

        public override void ClearTxTBox()
        {
            base.ClearTxTBox();
            txtb_Cidade.Clear();
            txtb_CodigoEstado.Clear();
            txtb_Estado.Clear();
            txtb_DDD.Clear();
        }

        public override void BloquearTxtBox()
        {
            base.BloquearTxtBox();
            txtb_Cidade.Enabled = false;
            txtb_CodigoEstado.Enabled = false;
            txtb_Estado.Enabled = false;
            txtb_DDD.Enabled = false;
            btn_Pesquisar.Enabled = false;
        }

        private void txtb_Cidade_Validating(object sender, CancelEventArgs e)
        {
            if (ValidacaoNome(txtb_Cidade.Text, 2, true))
            {
                errorMSG.SetError(lbl_Cidade, null);
                e.Cancel = false;
            }
            else
            {
                errorMSG.SetError(lbl_Cidade, "Cidade inválido!");
                e.Cancel = closing;
            }
        }

        private void btn_Cadastro_Click(object sender, EventArgs e)
        {
            closing = true;
            if (!ValidacaoNome(txtb_Cidade.Text, 2, true))
            {
                errorMSG.SetError(lbl_Cidade, "Campo 'Cidade' inválido!");
                txtb_Cidade.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_Estado.Text))
            {
                errorMSG.SetError(lbl_Cidade, null);
                errorMSG.SetError(lbl_Estado, "Campo 'Estado' deve ser inserido" +
                                              "usando o campo 'Código' ou o botão" +
                                              "'Pesquisar'");
                btn_Pesquisar.Focus();
            }
            else
            {
                errorMSG.SetError(lbl_Cidade, null);
                errorMSG.SetError(lbl_Estado, null);
                var vlCidade = new
                Classes.cidades(txtb_Codigo.Text == "" ? 0 : int.Parse(txtb_Codigo.Text),
                                txtb_CodigoUsu.Text == "" ? 0 : int.Parse(txtb_CodigoUsu.Text),
                                txtb_DataCadastro.Text, txtb_DataUltAlt.Text, txtb_Cidade.Text,
                                txtb_DDD.Text);
                vlCidade.UmEstado.ThisEstado = umEstado;
                ObjToDataBase(vlCidade, umCtrlCidade);
            }
        }

        private void txtb_CodigoEstado_TextChanged(object sender, EventArgs e)
        {
            if (txtb_CodigoEstado.Text == "")
            {
                txtb_Estado.Clear();
            }
            else
            {
                if (int.TryParse(txtb_CodigoEstado.Text, out int i))
                {
                    bool vlFind = false;
                    foreach (Classes.estados vlEstado in listaEstados)
                    {
                        if (vlEstado.Codigo == i)
                        {
                            txtb_Estado.Text = vlEstado.Estado;
                            umEstado = vlEstado.ThisEstado;
                            vlFind = true;
                        }
                    }
                    if (!vlFind)
                    { txtb_Estado.Clear(); }
                }
            }
        }

        private void txtb_CodigoEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacaoCodigo(txtb_CodigoEstado, e);
        }

        private void btn_Pesquisar_MouseEnter(object sender, EventArgs e)
        {
            btn_Pesquisar.Image = umImgPesquisaEntrar;
        }

        private void btn_Pesquisar_MouseLeave(object sender, EventArgs e)
        {
            btn_Pesquisar.Image = umImgPesquisaSair;
        }
    }
}
