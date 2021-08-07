using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_ICI.frmCadastros
{
    public partial class frmCadastroEstados : Projeto_ICI.frmCadastros.frmCadastroPai
    {
        frmConsultas.frmConsultaPaises frmConsPais;
        Controllers.ctrlEstados umCtrlEstado;
        Classes.paises umPais;
        List<Classes.paises> listaPaises;
        public frmCadastroEstados()
        {
            InitializeComponent();
            frmConsPais = new frmConsultas.frmConsultaPaises();
            umCtrlEstado = new Controllers.ctrlEstados();
            umPais = new Classes.paises();
            listaPaises = new List<Classes.paises>();
        }
        public frmCadastroEstados(BancoDados.conexoes pUmaConexao)
        {
            InitializeComponent();
            umCtrlEstado = new Controllers.ctrlEstados(pUmaConexao);
            umPais = new Classes.paises();
            listaPaises = umCtrlEstado.CTRLPais.PesquisarCollection(out string vlMsg);
            showErrorMsg(vlMsg);

            btn_Pesquisar.Image = umImgPesquisaSair;
        }
        public override void SetFrmCons(Form pFrmCad)
        {
            frmConsPais = (frmConsultas.frmConsultaPaises)pFrmCad;
        }
        public override void CarregarTxtBox(object pUmObjeto)
        {
            base.CarregarTxtBox(pUmObjeto);
            txtb_Estado.Text = ((Classes.estados)pUmObjeto).Estado;
            txtb_UF.Text = ((Classes.estados)pUmObjeto).UF;
            txtb_CodigoPais.Text = ((Classes.estados)pUmObjeto).UmPais.Codigo.ToString();
            txtb_Pais.Text = ((Classes.estados)pUmObjeto).UmPais.Pais;
        }

        public override void BloquearTxtBox()
        {
            base.BloquearTxtBox();
            txtb_CodigoPais.Enabled = false;
            txtb_Estado.Enabled = false;
            txtb_UF.Enabled = false;
            btn_Pesquisar.Enabled = false;
        }

        public override void DesBloqTxTBox()
        {
            txtb_CodigoPais.Enabled = true;
            txtb_Estado.Enabled = true;
            txtb_UF.Enabled = true;
            btn_Pesquisar.Enabled = true;
        }

        public override void ClearTxTBox()
        {
            base.ClearTxTBox();
            txtb_CodigoPais.Clear();
            txtb_Estado.Clear();
            txtb_Pais.Clear();
            txtb_UF.Clear();
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            var nomeBtn = frmConsPais.Btn_Sair;
            frmConsPais.Btn_Sair = "Selecionar";
            frmConsPais.ConhecaOBJ(umPais);
            frmConsPais.ShowDialog();
            frmConsPais.Btn_Sair = nomeBtn;
            if (umPais.Codigo != 0)
            {
                txtb_CodigoPais.Text = umPais.Codigo.ToString();
                txtb_Pais.Text = umPais.Pais;
                
            }
            listaPaises = umCtrlEstado.CTRLPais.PesquisarCollection(out string vlMsg);
            showErrorMsg(vlMsg);
        }

        private void txtb_CodigoPais_TextChanged(object sender, EventArgs e)
        {
            if (txtb_CodigoPais.Text == "")
            {
                txtb_Pais.Clear();
            }
            else
            {
                if (int.TryParse(txtb_CodigoPais.Text, out int i))
                {
                    bool vlFind = false;
                    foreach (Classes.paises vlPais in listaPaises)
                    {
                        if (vlPais.Codigo == i)
                        {
                            txtb_Pais.Text = vlPais.Pais;
                            umPais = vlPais.ThisPais;
                            vlFind = true;
                        }
                    }
                    if (!vlFind)
                    { txtb_Pais.Clear(); }
                }
            }
        }

        private void btn_Cadastro_Click(object sender, EventArgs e)
        {
            closing = true;
            if (!ValidacaoNome(txtb_Estado.Text, 2, true))
            {
                errorMSG.SetError(lbl_Estado, "Campo 'Estado' inválido!");
                txtb_Estado.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_Pais.Text))
            {
                errorMSG.SetError(lbl_Estado, null);
                errorMSG.SetError(lbl_Pais, "Campo 'Pais' deve ser inserido" +
                                            "usando o campo 'Código' ou o botão" +
                                            "'Pesquisar'");
                txtb_CodigoPais.Focus();
            }
            else
            {
                errorMSG.SetError(lbl_Estado, null);
                errorMSG.SetError(lbl_Pais, null);
                var vlEstado = new
                Classes.estados(txtb_Codigo.Text == "" ? 0 : int.Parse(txtb_Codigo.Text),
                                txtb_CodigoUsu.Text == "" ? 0 : int.Parse(txtb_CodigoUsu.Text),
                                txtb_DataCadastro.Text, txtb_DataUltAlt.Text, txtb_Estado.Text, txtb_UF.Text);
                vlEstado.UmPais.ThisPais = umPais;
                ObjToDataBase(vlEstado, umCtrlEstado);
            }
        }

        private void txtb_Estado_Validating(object sender, CancelEventArgs e)
        {
            if (ValidacaoNome(txtb_Estado.Text, 2, true))
            {
                errorMSG.SetError(lbl_Estado, null);
                e.Cancel = false;
            }
            else
            {
                errorMSG.SetError(lbl_Estado, "Estado inválido!");
                e.Cancel = closing;
            }
        }

        private void txtb_CodigoPais_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacaoCodigo(txtb_CodigoPais, e);
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
