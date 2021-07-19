using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_ICI.frmCadastros
{
    public partial class frmCadastroFormasPagamento : Projeto_ICI.frmCadastros.frmCadastroPai
    {
        private Controllers.ctrlFormasPagamento umCtrlFormPag;
        public frmCadastroFormasPagamento()
        {
            InitializeComponent();
            umCtrlFormPag = new Controllers.ctrlFormasPagamento();
        }
        public frmCadastroFormasPagamento(BancoDados.conexoes pUmaConexao)
        {
            InitializeComponent();
            umCtrlFormPag = new Controllers.ctrlFormasPagamento(pUmaConexao);
        }
        public override void CarregarTxtBox(object pUmObjeto)
        {
            base.CarregarTxtBox(pUmObjeto);
            txtb_FormaPag.Text = ((Classes.formasPagamento)pUmObjeto).FormaPag;
        }

        public override void BloquearTxtBox()
        {
            base.BloquearTxtBox();
            txtb_FormaPag.Enabled = false;
        }

        public override void DesBloqTxTBox()
        {
            txtb_FormaPag.Enabled = true;
        }

        public override void ClearTxTBox()
        {
            base.ClearTxTBox();
            txtb_FormaPag.Clear();
        }

        private void txtb_FormaPag_Validating(object sender, CancelEventArgs e)
        {
            if (ValidacaoNome(txtb_FormaPag.Text, 2, true))
            {
                errorMSG.SetError(lbl_FormaPag, null);
                e.Cancel = false;
            }
            else
            {
                errorMSG.SetError(lbl_FormaPag, "Forma de pagamento inválida!");
                e.Cancel = closing;
            }
        }

        private void btn_Cadastro_Click(object sender, EventArgs e)
        {
            closing = true;
            if (!ValidacaoNome(txtb_FormaPag.Text, 2, true))
            {
                errorMSG.SetError(lbl_FormaPag, "Campo 'Forma de pagamento' inválido!");
            }
            else
            {
                errorMSG.SetError(lbl_FormaPag, null);
                var vlFormaPag = new
                Classes.formasPagamento(txtb_Codigo.Text == "" ? 0 : int.Parse(txtb_Codigo.Text),
                                        txtb_CodigoUsu.Text == "" ? 0 : int.Parse(txtb_CodigoUsu.Text),
                                        txtb_DataCadastro.Text, txtb_DataUltAlt.Text, txtb_FormaPag.Text);
                ObjToDataBase(vlFormaPag, umCtrlFormPag);
            }
        }
    }
}
