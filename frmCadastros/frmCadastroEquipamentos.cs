using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_ICI.frmCadastros
{
    public partial class frmCadastroEquipamentos : Projeto_ICI.frmCadastros.frmCadastroPai
    {
        frmConsultas.frmConsultaModelos frmConsModelo;
        Controllers.ctrlEquipamentos umCtrlEquip;
        Classes.modelos umModelo;

        public frmCadastroEquipamentos(Controllers.ctrlEquipamentos pCtrlEquip)
        {
            InitializeComponent();
            umCtrlEquip = pCtrlEquip;
            umModelo = new Classes.modelos();

            btn_Pesquisar.Image = umImgPesquisaSair;
        }
        public override void SetFrmCons(Form pFrmCad)
        {
            frmConsModelo = (frmConsultas.frmConsultaModelos)pFrmCad;
        }
        public override void CarregarTxtBox(object pUmObjeto)
        {
            base.CarregarTxtBox(pUmObjeto);
            txtb_Equipamento.Text = ((Classes.equipamentos)pUmObjeto).Equipamento;
            txtb_Voltagem.Text = ((Classes.equipamentos)pUmObjeto).Voltagem;
            txtb_ObsTecnica.Text = ((Classes.equipamentos)pUmObjeto).ObsTecnica;
            txtb_CodigoModelo.Text = ((Classes.equipamentos)pUmObjeto).UmModelo.Codigo.ToString();
            txtb_Modelo.Text = ((Classes.equipamentos)pUmObjeto).UmModelo.Modelo;
            txtb_Marca.Text = ((Classes.equipamentos)pUmObjeto).UmModelo.UmaMarca.Marca;
        }

        public override void BloquearTxtBox()
        {
            base.BloquearTxtBox();
            txtb_CodigoModelo.Enabled = false;
            txtb_Equipamento.Enabled = false;
            txtb_Voltagem.Enabled = false;
            txtb_ObsTecnica.Enabled = false;
            btn_Pesquisar.Enabled = false;
        }

        public override void DesBloqTxTBox()
        {
            txtb_CodigoModelo.Enabled = true;
            txtb_Equipamento.Enabled = true;
            txtb_Voltagem.Enabled = true;
            txtb_ObsTecnica.Enabled = true;
            btn_Pesquisar.Enabled = true;
        }

        public override void ClearTxTBox()
        {
            base.ClearTxTBox();
            txtb_CodigoModelo.Clear();
            txtb_Modelo.Clear();
            txtb_Marca.Clear();
            txtb_Equipamento.Clear();
            txtb_Voltagem.Clear();
            txtb_ObsTecnica.Clear();
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
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
                if (int.TryParse(txtb_CodigoModelo.Text, out int vlCodigo))
                {
                    var vlModelo =
                         (Classes.modelos)umCtrlEquip.CTRLModelo.Pesquisar("codigo",
                                                                         vlCodigo.ToString(),
                                                                          out string vlMsg,
                                                                          false);
                    if (vlModelo != null)
                    {
                        if (vlMsg == "")
                        {
                            txtb_Modelo.Text = vlModelo.Modelo;
                            txtb_Marca.Text = vlModelo.UmaMarca.Marca;
                            umModelo.ThisModelo = vlModelo;
                        }
                        else
                        {
                            showErrorMsg(vlMsg);
                            txtb_Modelo.Clear();
                            txtb_Marca.Clear();
                        }
                    }
                    else
                    {
                        txtb_Modelo.Clear();
                        txtb_Marca.Clear();
                    }
                }
            }
        }

        private void btn_Cadastro_Click(object sender, EventArgs e)
        {
            closing = true;
            if (string.IsNullOrEmpty(txtb_Equipamento.Text))
            {
                errorMSG.SetError(lbl_Equipamento, "Campo 'Equipamento' inválido!");
                txtb_Equipamento.Focus();
            }
            if (string.IsNullOrEmpty(txtb_Voltagem.Text))
            {
                errorMSG.SetError(lbl_Volgatem, "Campo 'Voltagem' inválido!");
                txtb_Voltagem.Focus();
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
                errorMSG.Clear();
                var vlEquip = new
                Classes.equipamentos(txtb_Codigo.Text == "" ? 0 : int.Parse(txtb_Codigo.Text),
                                    txtb_CodigoUsu.Text == "" ? 0 : int.Parse(txtb_CodigoUsu.Text),
                                    txtb_DataCadastro.Text, txtb_DataUltAlt.Text,
                                    txtb_Equipamento.Text, txtb_Voltagem.Text, txtb_ObsTecnica.Text);
                vlEquip.UmModelo.ThisModelo = umModelo;
                ObjToDataBase(vlEquip, umCtrlEquip);
            }
        }

        private void txtb_Equipamento_Validating(object sender, CancelEventArgs e)
        {
            ValidarNome(txtb_Equipamento, lbl_Equipamento, "equipamento", umCtrlEquip, e);
        }

        private void txtb_CodigoPais_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacaoCodigo(txtb_CodigoModelo, e);
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
