using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_ICI.frmCadastros
{
    public partial class frmCadastroGrupos : Projeto_ICI.frmCadastros.frmCadastroPai
    {
        Controllers.ctrlGrupos umCtrlGrupo;
        public frmCadastroGrupos()
        {
            InitializeComponent();
            umCtrlGrupo = new Controllers.ctrlGrupos();
        }
        public frmCadastroGrupos(BancoDados.conexoes pUmaConexao)
        {
            InitializeComponent();
            umCtrlGrupo = new Controllers.ctrlGrupos(pUmaConexao);
        }
        public override void CarregarTxtBox(object pUmObjeto)
        {
            base.CarregarTxtBox(pUmObjeto);
            txtb_Grupo.Text = ((Classes.grupos)pUmObjeto).Grupo;
        }
        public override void BloquearTxtBox()
        {
            base.BloquearTxtBox();
            txtb_Grupo.Enabled = false;
        }
        public override void DesBloqTxTBox()
        {
            txtb_Grupo.Enabled = true;
        }
        public override void ClearTxTBox()
        {
            base.ClearTxTBox();
            txtb_Grupo.Clear();
        }

        private void txtb_Grupo_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidacaoNome(txtb_Grupo.Text, 2, true))
            {
                errorMSG.SetError(txtb_Grupo, "Grupo inválido!");
                e.Cancel = closing;
            }
            else
            {
                errorMSG.SetError(txtb_Grupo, null);
                e.Cancel = false;
            }
        }

        private void btn_Cadastro_Click_1(object sender, EventArgs e)
        {
            closing = true;
            if (!ValidacaoNome(txtb_Grupo.Text, 2, true))
            {
                errorMSG.SetError(txtb_Grupo, "Campo 'Grupo' inválido!");
            }
            else
            {
                errorMSG.SetError(lbl_Grupo, null);
                var vlGrupo = new
                Classes.grupos(txtb_Codigo.Text == "" ? 0 : int.Parse(txtb_Codigo.Text),
                               txtb_CodigoUsu.Text == "" ? 0 : int.Parse(txtb_CodigoUsu.Text),
                               txtb_DataCadastro.Text, txtb_DataUltAlt.Text, txtb_Grupo.Text);
                ObjToDataBase(vlGrupo, umCtrlGrupo);
            }
        }
    }
}
