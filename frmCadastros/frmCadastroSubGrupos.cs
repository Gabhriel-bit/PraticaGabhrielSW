using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_ICI.frmCadastros
{
    public partial class frmCadastroSubGrupos : Projeto_ICI.frmCadastros.frmCadastroPai
    {
        frmConsultas.frmConsultaGrupos frmConsGrupo;
        Controllers.ctrlSubgrupos umCtrlSubgrupo;
        Classes.grupos umGrupo;
        List<Classes.grupos> listaGrupos;
        public frmCadastroSubGrupos()
        {
            InitializeComponent();
            frmConsGrupo = new frmConsultas.frmConsultaGrupos();
            umCtrlSubgrupo = new Controllers.ctrlSubgrupos();
            umGrupo = new Classes.grupos();
            listaGrupos = new List<Classes.grupos>();
        }
        public frmCadastroSubGrupos(BancoDados.conexoes pUmaConexao)
        {
            InitializeComponent();
            umCtrlSubgrupo = new Controllers.ctrlSubgrupos(pUmaConexao);
            umGrupo = new Classes.grupos();
            btn_Pesquisar.Image = umImgPesquisaSair;
            listaGrupos = umCtrlSubgrupo.CTRLGrupo.PesquisarCollection(out string vlMsg);
            showErrorMsg(vlMsg);
        }
        public override void SetFrmCons(Form pFrmCad)
        {
            frmConsGrupo = (frmConsultas.frmConsultaGrupos)pFrmCad;
        }
        public override void CarregarTxtBox(object pUmObjeto)
        {
            base.CarregarTxtBox(pUmObjeto);
            txtb_Subgrupo.Text = ((Classes.subgrupos)pUmObjeto).Subgrupo;
            txtb_CodigoGrupo.Text = ((Classes.subgrupos)pUmObjeto).UmGrupo.Codigo.ToString();
            txtb_Grupo.Text = ((Classes.subgrupos)pUmObjeto).UmGrupo.Grupo;
        }
        public override void BloquearTxtBox()
        {
            base.BloquearTxtBox();
            txtb_CodigoGrupo.Enabled = false;
            txtb_Subgrupo.Enabled = false;
            btn_Pesquisar.Enabled = false;
        }
        public override void DesBloqTxTBox()
        {
            txtb_CodigoGrupo.Enabled = true;
            txtb_Subgrupo.Enabled = true;
            btn_Pesquisar.Enabled = true;
        }
        public override void ClearTxTBox()
        {
            base.ClearTxTBox();
            txtb_CodigoGrupo.Clear();
            txtb_Grupo.Clear();
            txtb_Subgrupo.Clear();
        }
        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            var nomeBtn = frmConsGrupo.Btn_Sair;
            frmConsGrupo.Btn_Sair = "Selecionar";
            frmConsGrupo.ConhecaOBJ(umGrupo);
            frmConsGrupo.ShowDialog();
            frmConsGrupo.Btn_Sair = nomeBtn;
            if (umGrupo.Codigo != 0)
            {
                txtb_CodigoGrupo.Text = umGrupo.Codigo.ToString();
                txtb_Grupo.Text = umGrupo.Grupo;
            }
            listaGrupos = umCtrlSubgrupo.CTRLGrupo.PesquisarCollection(out string vlMsg);
            showErrorMsg(vlMsg);
        }

        private void btn_Cadastro_Click(object sender, EventArgs e)
        {
            closing = true;
            if (!ValidacaoNome(txtb_Subgrupo.Text, 2, true))
            {
                errorMSG.SetError(lbl_Subgrupo, "Campo 'Subgrupo' inválido!");
                txtb_Subgrupo.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_Grupo.Text))
            {
                errorMSG.SetError(lbl_Subgrupo, null);
                errorMSG.SetError(lbl_Grupo, "Campo 'Grupo' deve ser inserido" +
                                             "usando o campo 'Código' ou o botão" +
                                             "'Pesquisar'");
                txtb_CodigoGrupo.Focus();
            }
            else
            {
                errorMSG.SetError(lbl_Subgrupo, null);
                errorMSG.SetError(lbl_Grupo, null);
                var vlSubgrupo = new
                Classes.subgrupos(txtb_Codigo.Text == "" ? 0 : int.Parse(txtb_Codigo.Text),
                                  txtb_CodigoUsu.Text == "" ? 0 : int.Parse(txtb_CodigoUsu.Text),
                                  txtb_DataCadastro.Text, txtb_DataUltAlt.Text, txtb_Subgrupo.Text);
                vlSubgrupo.UmGrupo.ThisGrupo = umGrupo;
                ObjToDataBase(vlSubgrupo, umCtrlSubgrupo);
            }
        }

        private void txtb_CodigoGrupo_TextChanged(object sender, EventArgs e)
        {
            if (txtb_CodigoGrupo.Text == "")
            {
                txtb_Grupo.Clear();
            }
            else
            {
                if (int.TryParse(txtb_CodigoGrupo.Text, out int i))
                {
                    foreach (Classes.grupos vlGrupo in listaGrupos)
                    {
                        if (vlGrupo.Codigo == i)
                        {
                            txtb_Grupo.Text = vlGrupo.Grupo;
                            umGrupo = vlGrupo.ThisGrupo;
                        }
                    }
                }
            }
        }

        private void txtb_Subgrupo_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidacaoNome(txtb_Subgrupo.Text, 2, true))
            {
                errorMSG.SetError(lbl_Subgrupo, null);
                e.Cancel = false;
            }
            else
            {
                errorMSG.SetError(lbl_Subgrupo, "Subgrupo inválido!");
                e.Cancel = closing;
            }
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
