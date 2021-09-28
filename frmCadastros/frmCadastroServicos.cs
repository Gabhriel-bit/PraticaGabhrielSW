using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_ICI.frmCadastros
{
    public partial class frmCadastroServicos : Projeto_ICI.frmCadastros.frmCadastroPai
    {
        private Controllers.ctrlServicos umCtrlServico;

        public frmCadastroServicos(Controllers.ctrlServicos pCtrlServico)
        {
            InitializeComponent();
            umCtrlServico = pCtrlServico;
        }

        public override void CarregarTxtBox(object pUmObjeto)
        {
            base.CarregarTxtBox(pUmObjeto);
            var vlServico = (Classes.servicos)pUmObjeto;
            txtb_Servico.Text = vlServico.Servico;
            txtb_Descricao.Text = vlServico.Descricao;
            txtb_Preco.Text = vlServico.Preco.ToString();
        }
        public override void BloquearTxtBox()
        {
            base.BloquearTxtBox();
            txtb_Servico.Enabled = false;
            txtb_Descricao.Enabled = false;
            txtb_Preco.Enabled = false;
        }
        public override void DesBloqTxTBox()
        {
            txtb_Servico.Enabled = true;
            txtb_Descricao.Enabled = true;
            txtb_Preco.Enabled = true;
        }
        public override void ClearTxTBox()
        {
            base.ClearTxTBox();
            txtb_Servico.Clear();
            txtb_Descricao.Clear();
            txtb_Preco.Clear();
        }

        private void btn_Cadastro_Click(object sender, EventArgs e)
        {
            closing = true;
            if (string.IsNullOrEmpty(txtb_Servico.Text))
            {
                errorMSG.SetError(lbl_Servico, "Campo 'Serviço' inválido!");
            }
            else if (!ValidacaoDoubleMoeda(txtb_Preco.Text))
            {
                errorMSG.SetError(lbl_Preco, "Campo 'Preço' inválido!");
            }
            else
            {
                errorMSG.SetError(lbl_Servico, null);
                var vlServico = new
                Classes.servicos(txtb_Codigo.Text == "" ? 0 : int.Parse(txtb_Codigo.Text),
                                 txtb_CodigoUsu.Text == "" ? 0 : int.Parse(txtb_CodigoUsu.Text),
                                 txtb_DataCadastro.Text, txtb_DataUltAlt.Text, txtb_Servico.Text,
                                 txtb_Descricao.Text,
                                 decimal.Parse(txtb_Preco.Text == "" ? "0" : txtb_Preco.Text.Replace(".", ","), vgEstilo, vgProv));

                ObjToDataBase(vlServico, umCtrlServico);
            }
        }

        private void txtb_Servico_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtb_Servico.Text))
            {
                if (umCtrlServico.Pesquisar("servico", txtb_Servico.Text, true, out string vlMsg).Rows.Count != 0)
                {
                    if (vlMsg == "")
                    {
                        errorMSG.SetError(lbl_Servico, "Serviço já cadastrado!");
                        e.Cancel = closing;
                    }
                    else
                    {
                        errorMSG.SetError(lbl_Servico, vlMsg);
                        e.Cancel = closing;
                    }
                }
                else
                {
                    errorMSG.SetError(lbl_Servico, null);
                    e.Cancel = false;
                }
            }
            else
            {
                errorMSG.SetError(lbl_Servico, "Serviço inválido!");
                e.Cancel = closing;
            }
        }
    }
}
