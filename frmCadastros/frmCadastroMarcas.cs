using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_ICI.frmCadastros
{
    public partial class frmCadastroMarcas : Projeto_ICI.frmCadastros.frmCadastroPai
    {
        private Controllers.ctrlMarcas umCtrlMarca;
        public frmCadastroMarcas()
        {
            InitializeComponent();
            umCtrlMarca = new Controllers.ctrlMarcas();
        }
        public frmCadastroMarcas(BancoDados.conexoes pUmaConexao)
        {
            InitializeComponent();
            umCtrlMarca = new Controllers.ctrlMarcas(pUmaConexao);
        }
        public override void BloquearTxtBox()
        {
            base.BloquearTxtBox();
            txtb_Marca.Enabled = false;
        }
        public override void DesBloqTxTBox()
        {
            txtb_Marca.Enabled = true;
        }
        public override void ClearTxTBox()
        {
            base.ClearTxTBox();
            txtb_Marca.Clear();
        }

        public override void CarregarTxtBox(object pUmObjeto)
        {
            base.CarregarTxtBox(pUmObjeto);
            txtb_Marca.Text = ((Classes.marcas)pUmObjeto).Marca;
        }

        private void txtb_Marca_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidacaoNome(txtb_Marca.Text, 2, true))
            {
                errorMSG.SetError(lbl_Marca, "Marca inválida!");
                e.Cancel = closing;
            }
            else
            {
                errorMSG.SetError(lbl_Marca, null);
                e.Cancel = false;
            }
        }

        private void btn_Cadastro_Click(object sender, EventArgs e)
        {
            closing = true;
            if (!ValidacaoNome(txtb_Marca.Text, 2, true))
            {
                errorMSG.SetError(lbl_Marca, "Campo 'Marca' inválido!");
            }
            else
            {
                errorMSG.SetError(lbl_Marca, null);
                var vlMarca = new
                Classes.marcas(txtb_Codigo.Text == "" ? 0 : int.Parse(txtb_Codigo.Text),
                               txtb_CodigoUsu.Text == "" ? 0 : int.Parse(txtb_CodigoUsu.Text),
                               txtb_DataCadastro.Text, txtb_DataUltAlt.Text, txtb_Marca.Text);
                ObjToDataBase(vlMarca, umCtrlMarca);
            }
        }
    }
}
