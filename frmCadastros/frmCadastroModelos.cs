using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_ICI.frmCadastros
{
    public partial class frmCadastroModelos : Projeto_ICI.frmCadastros.frmCadastroPai
    {
        frmConsultas.frmConsultaMarcas frmConsMarca;
        Controllers.ctrlModelos umCtrlModelos;
        Classes.marcas umaMarca;

        public frmCadastroModelos(Controllers.ctrlModelos pCtrlModelo)
        {
            InitializeComponent();
            umCtrlModelos = pCtrlModelo;
            umaMarca = new Classes.marcas();
            btn_Pesquisar.Image = umImgPesquisaSair;
        }
        public override void SetFrmCons(Form pFrmCad)
        {
            frmConsMarca = (frmConsultas.frmConsultaMarcas)pFrmCad;
        }
        public override void CarregarTxtBox(object pUmObjeto)
        {
            base.CarregarTxtBox(pUmObjeto);
            txtb_Modelo.Text = ((Classes.modelos)pUmObjeto).Modelo;
            txtb_Descricao.Text = ((Classes.modelos)pUmObjeto).Descricao;
            txtb_CodigoMarca.Text = ((Classes.modelos)pUmObjeto).UmaMarca.Codigo.ToString();
            txtb_Marca.Text = ((Classes.modelos)pUmObjeto).UmaMarca.Marca;
        }
        public override void BloquearTxtBox()
        {
            base.BloquearTxtBox();
            txtb_Modelo.Enabled = false;
            txtb_Descricao.Enabled = false;
            txtb_CodigoMarca.Enabled = false;
            btn_Pesquisar.Enabled = false;
        }
        public override void DesBloqTxTBox()
        {
            txtb_Modelo.Enabled = true;
            txtb_Descricao.Enabled = true;
            txtb_CodigoMarca.Enabled = true;
            btn_Pesquisar.Enabled = true;
        }
        public override void ClearTxTBox()
        {
            base.ClearTxTBox();
            txtb_Marca.Clear();
            txtb_Modelo.Clear();
            txtb_Descricao.Clear();
            txtb_CodigoMarca.Clear();
        }
        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            var nomeBtn = frmConsMarca.Btn_Sair;
            frmConsMarca.Btn_Sair = "Selecionar";
            frmConsMarca.ConhecaOBJ(umaMarca);
            frmConsMarca.ShowDialog();
            frmConsMarca.Btn_Sair = nomeBtn;
            if (umaMarca.Codigo != 0)
            {
                txtb_CodigoMarca.Text = umaMarca.Codigo.ToString();
                txtb_Marca.Text = umaMarca.Marca;
            }
        }

        private void txtb_CodigoMarca_TextChanged(object sender, EventArgs e)
        {
            if (txtb_CodigoMarca.Text == "")
            {
                txtb_Marca.Clear();
            }
            else
            {
                if (int.TryParse(txtb_CodigoMarca.Text, out int vlCodigo))
                {
                    var vlMarca =
                         (Classes.marcas)umCtrlModelos.CTRLMarca.Pesquisar("codigo",
                                                                            vlCodigo.ToString(),
                                                                            out string vlMsg,
                                                                            false);
                    if (vlMarca != null)
                    {
                        if (vlMsg == "")
                        {
                            txtb_Marca.Text = vlMarca.Marca;
                            umaMarca.ThisMarca = vlMarca;
                        }
                        else
                        {
                            showErrorMsg(vlMsg);
                            txtb_Marca.Clear();
                        }
                    }
                    else
                    {
                        txtb_Marca.Clear();
                    }
                }
            }
        }

        private void btn_Cadastro_Click(object sender, EventArgs e)
        {
            closing = true;
            if (string.IsNullOrEmpty(txtb_Modelo.Text))
            {
                errorMSG.SetError(lbl_Modelo, "Campo 'Modelo' inválido!");
                txtb_Modelo.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_Marca.Text))
            {
                errorMSG.SetError(lbl_Modelo, null);
                errorMSG.SetError(lbl_Marca, "Campo 'Marca' deve ser inserido" +
                                             "usando o campo 'Código' ou o botão" +
                                             "'Pesquisar'");
                txtb_CodigoMarca.Focus();
            }
            else
            {
                errorMSG.SetError(lbl_Modelo, null);
                errorMSG.SetError(lbl_Marca, null);
                var vlModelo = new
                Classes.modelos(txtb_Codigo.Text == "" ? 0 : int.Parse(txtb_Codigo.Text),
                                txtb_CodigoUsu.Text == "" ? 0 : int.Parse(txtb_CodigoUsu.Text),
                                txtb_DataCadastro.Text, txtb_DataUltAlt.Text, txtb_Modelo.Text,
                                txtb_Descricao.Text);
                vlModelo.UmaMarca.ThisMarca = umaMarca;
                ObjToDataBase(vlModelo, umCtrlModelos);
            }
        }

        private void txtb_Modelo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtb_Modelo.Text))
            {
                errorMSG.SetError(lbl_Modelo, "Modelo inválido!");
                e.Cancel = closing;
            }
            else
            {
                if (umCtrlModelos.Pesquisar("modelo", txtb_Modelo.Text, true, out string vlMsg).Rows.Count != 0)
                {
                    if (vlMsg == "")
                    {
                        errorMSG.SetError(lbl_Modelo, "Modelo já cadastrado!");
                        e.Cancel = closing;
                    }
                    else
                    {
                        errorMSG.SetError(lbl_Modelo, vlMsg);
                        e.Cancel = closing;
                    }
                }
                else
                {
                    errorMSG.SetError(lbl_Modelo, null);
                    e.Cancel = false;
                }
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
