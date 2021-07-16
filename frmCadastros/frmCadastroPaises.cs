using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_ICI.frmCadastros
{
    public partial class frmCadastroPaises : Projeto_ICI.frmCadastros.frmCadastroPai
    {
        private Controllers.ctrlPaises umCtrlPais;
        public frmCadastroPaises()
        {
            InitializeComponent();
            umCtrlPais = new Controllers.ctrlPaises();
        }
        public frmCadastroPaises(BancoDados.conexoes pUmaConexao)
        {
            InitializeComponent();
            umCtrlPais = new Controllers.ctrlPaises(pUmaConexao);
        }

        public override void CarregarTxtBox(object pUmObjeto)
        {
            base.CarregarTxtBox(pUmObjeto);
            var vlPais = (Classes.paises)pUmObjeto;
            txtb_DDI.Text = vlPais.DDI;
            txtb_Moeda.Text = vlPais.Moeda;
            txtb_Pais.Text = vlPais.Pais;
            txtb_Sigla.Text = vlPais.Sigla;
        }
        public override void BloquearTxtBox()
        {
            base.BloquearTxtBox();
            txtb_Pais.Enabled = false;
            txtb_Moeda.Enabled = false;
            txtb_DDI.Enabled = false;
            txtb_Sigla.Enabled = false;
        }
        public override void DesBloqTxTBox()
        {
            txtb_Pais.Enabled = true;
            txtb_Moeda.Enabled = true;
            txtb_DDI.Enabled = true;
            txtb_Sigla.Enabled = true;
        }
        public override void ClearTxTBox()
        {
            base.ClearTxTBox();
            txtb_Pais.Clear();
            txtb_Moeda.Clear();
            txtb_DDI.Clear();
            txtb_Sigla.Clear();
        }

        private void btn_Cadastro_Click(object sender, EventArgs e)
        {
            if (!ValidacaoNome(txtb_Pais.Text, 2, true))
            {
                errorMSG.SetError(lbl_Pais, "Campo 'País' inválido!");
            }
            else
            {
                errorMSG.SetError(lbl_Pais, null);
                var vlPais = new
                Classes.paises(txtb_Codigo.Text == "" ? 0 : int.Parse(txtb_Codigo.Text),
                               txtb_CodigoUsu.Text == "" ? 0 : int.Parse(txtb_CodigoUsu.Text),
                               txtb_DataCadastro.Text, txtb_DataUltAlt.Text, txtb_Pais.Text,
                               txtb_Moeda.Text, txtb_DDI.Text, txtb_Sigla.Text);
                ObjToDataBase(vlPais, umCtrlPais);
            }
        }

        private void txtb_Pais_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidacaoNome(txtb_Pais.Text, 2, true))
            {
                errorMSG.SetError(lbl_Pais, "País inválido!");
                e.Cancel = true;
            }
            else
            {
                errorMSG.SetError(lbl_Pais, null);
                e.Cancel = false;
            }
        }
    }
}
