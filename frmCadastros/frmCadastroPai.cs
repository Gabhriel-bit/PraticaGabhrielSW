using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_ICI.frmCadastros
{
    public partial class frmCadastroPai : Projeto_ICI.formularioBase
    {
        protected bool closing;
        public frmCadastroPai()
        {
            InitializeComponent();
            this.txtb_DataCadastro.Text = DateTime.Today.ToString().Remove(11);
            this.txtb_DataUltAlt.Text = DateTime.Today.ToString().Remove(11);
            closing = false;
        }
        public virtual void CarregarTxtBox(object pUmObjeto)
        {
            Classes.pai umPai = (Classes.pai)pUmObjeto;
            txtb_Codigo.Text = umPai.Codigo.ToString();
            txtb_CodigoUsu.Text = umPai.CodigoUsu.ToString();
            txtb_DataCadastro.Text = umPai.DataCad;
            txtb_DataUltAlt.Text = umPai.DataUltAlt;
        }
        public virtual void BloquearTxtBox()
        {
            txtb_Codigo.Enabled = false;
            txtb_CodigoUsu.Enabled = false;
            txtb_DataCadastro.Enabled = false;
            txtb_DataUltAlt.Enabled = false;
        }

        public virtual void DesBloqTxTBox()
        {
            txtb_Codigo.Enabled = true;
            txtb_CodigoUsu.Enabled = true;
            txtb_DataCadastro.Enabled = true;
            txtb_DataUltAlt.Enabled = true;
        }
        public string Btn_Acao
        {
            get => btn_Cadastro.Text;
            set => btn_Cadastro.Text = value;
        }

        public virtual void ClearTxTBox()
        {
            txtb_Codigo.Clear();
            txtb_CodigoUsu.Clear();
        }

        protected void ObjToDataBase(object pObj, Controllers.controllers pCtrl)
        {
            string msg = "";
            if (Btn_Acao == "Salvar")
            {
                msg = pCtrl.Inserir(pObj);
            }
            else if (Btn_Acao == "Alterar")
            {
                msg = pCtrl.Alterar(pObj);
            }
            else if (Btn_Acao == "Excluir")
            {
                msg = pCtrl.Excluir(pObj);
            }
            if (msg.Contains("sucesso"))
            {
                MessageBox.Show(msg, "Informação");
                Close();
            }
            else
            {
                MessageBox.Show(msg, "ERRO");
            }
        }
        private void btn_Sair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmCadastroPai_Load(object sender, EventArgs e)
        {
            if (Btn_Acao == "Salvar")
            {
                this.txtb_DataCadastro.Text = DateTime.Today.ToString().Remove(11);
                this.txtb_DataUltAlt.Text = DateTime.Today.ToString().Remove(11);
            }
            else if (Btn_Acao == "Alterar")
            {
                this.txtb_DataUltAlt.Text = DateTime.Today.ToString().Remove(11);
            }
        }
        private void frmCadastroPai_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClearTxTBox();
            DesBloqTxTBox();
            closing = false;
            errorMSG.Clear();
        }
    }
}
