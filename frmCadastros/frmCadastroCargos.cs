using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_ICI.frmCadastros
{
    public partial class frmCadastroCargos : Projeto_ICI.frmCadastros.frmCadastroPai
    {
        Controllers.ctrlCargos umCtrlCargo;
        public frmCadastroCargos()
        {
            InitializeComponent();
            umCtrlCargo = new Controllers.ctrlCargos();
            alterarRbtnCNH = false;
        }
        public frmCadastroCargos(BancoDados.conexoes pUmaConexao)
        {
            InitializeComponent();
            umCtrlCargo = new Controllers.ctrlCargos(pUmaConexao);
            alterarRbtnCNH = false;
        }
        public override void CarregarTxtBox(object pUmObjeto)
        {
            base.CarregarTxtBox(pUmObjeto);
            Classes.cargos vlCargo = (Classes.cargos)pUmObjeto;
            txtb_Cargo.Text = vlCargo.Cargo;
            alterarRbtnCNH = vlCargo.CNH;
            txtb_Descricao.Text = vlCargo.Descricao;
        }

        private bool alterarRbtnCNH
        {
            get => rb_Sim.Checked;
            set
            {
                if (value)
                    rb_Sim.Checked = value;
                else
                    rb_Nao.Checked = true;
            }
        }
        public override void ClearTxTBox()
        {
            base.ClearTxTBox();
            txtb_Cargo.Clear();
            alterarRbtnCNH = false;
            txtb_Descricao.Clear();
        }

        public override void DesBloqTxTBox()
        {
            txtb_Cargo.Enabled = true;
            rb_Sim.Enabled = true;
            rb_Nao.Enabled = true;
            txtb_Descricao.Enabled = true;
        }

        public override void BloquearTxtBox()
        {
            base.BloquearTxtBox();
            txtb_Cargo.Enabled = false;
            rb_Nao.Enabled = false;
            rb_Sim.Enabled = false;
            txtb_Descricao.Enabled = false;
        }

        private void txtb_Cargo_Validating(object sender, CancelEventArgs e)
        {
            if (ValidacaoNome(txtb_Cargo.Text, 2, true))
            {
                errorMSG.SetError(lbl_Cargo, null);
                e.Cancel = false;
            }
            else
            {
                errorMSG.SetError(lbl_Cargo, "Cargo inválido!");
                e.Cancel = closing;
            }
        }
        private void btn_Cadastro_Click(object sender, EventArgs e)
        {
            closing = true;
            if (!ValidacaoNome(txtb_Cargo.Text, 2, true))
            {
                errorMSG.SetError(lbl_Cargo, "Campo 'Cargo' é obrigatório!");
                txtb_Cargo.Focus();
            }
            else
            {
                errorMSG.SetError(lbl_Cargo, null);
                var vlCargo = new
                Classes.cargos(txtb_Codigo.Text == "" ? 0 : int.Parse(txtb_Codigo.Text),
                               txtb_CodigoUsu.Text == "" ? 0 : int.Parse(txtb_CodigoUsu.Text),
                               txtb_DataCadastro.Text, txtb_DataUltAlt.Text,
                               alterarRbtnCNH, txtb_Cargo.Text, txtb_Descricao.Text);
                ObjToDataBase(vlCargo, umCtrlCargo);
            }
        }
    }
}
