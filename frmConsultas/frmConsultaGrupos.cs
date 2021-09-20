using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_ICI.frmConsultas
{
    public partial class frmConsultaGrupos : Projeto_ICI.frmConsultas.frmConsultaPai
    {
        frmCadastros.frmCadastroGrupos frmCadGrupo;
        Controllers.ctrlGrupos umCtrlGrupos;
        Classes.grupos umGrupo;

        public frmConsultaGrupos(Controllers.ctrlGrupos pCtrlGrupo)
        {
            InitializeComponent();
            umCtrlGrupos = pCtrlGrupo;
            umGrupo = new Classes.grupos();
            carregarDados(umCtrlGrupos);
        }
        public override void SetFrmCad(Form pFrmCad)
        {
            frmCadGrupo = (frmCadastros.frmCadastroGrupos)pFrmCad;
        }
        public override void ConhecaOBJ(object pOBJ)
        {
            umGrupo = (Classes.grupos)pOBJ;
        }

        private void btn_Inserir_Click(object sender, EventArgs e)
        {
            frmCadGrupo.ClearTxTBox();
            frmCadGrupo.ShowDialog();
            carregarDados(umCtrlGrupos);
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            var vlGrupo = (Classes.grupos)dataGridToObj(umCtrlGrupos, out string vlMsg);
            if (vlGrupo == null)
            {
                errorMSG.SetError(btn_Alterar, "Selecão inválida!\nSelecione um e apenas um grupo");
                this.dataGridView.Focus();
            }
            else if (vlMsg != "")
            {
                errorMSG.SetError(btn_Alterar, "Erro ao carregar!\n" + vlMsg);
                this.dataGridView.Focus();
            }
            else
            {
                errorMSG.SetError(btn_Alterar, null);
                frmCadGrupo.ClearTxTBox();
                var btnName = frmCadGrupo.Btn_Acao;
                frmCadGrupo.CarregarTxtBox(vlGrupo);
                frmCadGrupo.Btn_Acao = "Alterar";
                frmCadGrupo.ShowDialog();
                frmCadGrupo.Btn_Acao = btnName;
                carregarDados(umCtrlGrupos);
            }
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            var vlGrupo = (Classes.grupos)dataGridToObj(umCtrlGrupos, out string vlMsg);
            if (vlGrupo == null)
            {
                errorMSG.SetError(btn_Excluir, "Selecão inválida!\nSelecione um e apenas um grupo!");
                this.dataGridView.Focus();
            }
            else if (vlMsg != "")
            {
                errorMSG.SetError(btn_Alterar, "Erro ao carregar!\n" + vlMsg);
                this.dataGridView.Focus();
            }
            else
            {
                errorMSG.SetError(btn_Excluir, null);
                frmCadGrupo.ClearTxTBox();
                frmCadGrupo.BloquearTxtBox();
                var btnName = frmCadGrupo.Btn_Acao;
                frmCadGrupo.CarregarTxtBox(vlGrupo);
                frmCadGrupo.Btn_Acao = "Excluir";
                frmCadGrupo.ShowDialog();
                frmCadGrupo.Btn_Acao = btnName;
                carregarDados(umCtrlGrupos);
            }
        }

        protected override void Sair()
        {
            if (btn_Sair.Text != "Sair")
            {
                var vlGrupo = (Classes.grupos)dataGridToObj(umCtrlGrupos, out string vlMsg);
                if (vlGrupo == null)
                {
                    errorMSG.SetError(btn_Sair, "Selecione um e apenas um grupo!");
                    this.dataGridView.Focus();
                }
                else if (vlMsg != "")
                {
                    errorMSG.SetError(btn_Alterar, "Erro ao carregar!\n" + vlMsg);
                    this.dataGridView.Focus();
                }
                else
                {
                    errorMSG.SetError(btn_Sair, null);
                    umGrupo.ThisGrupo = vlGrupo;
                }
            }
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            string vlMsg = "";
            if (txtb_Pesquisa.Text == "")
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                carregarDados(umCtrlGrupos);
            }
            else if (int.TryParse(txtb_Pesquisa.Text, out _))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlGrupos.Pesquisar("codigo", txtb_Pesquisa.Text, default, out vlMsg);
                txtb_Pesquisa.Clear();
            }
            else if (ValidacaoNome(txtb_Pesquisa.Text, 1, true))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlGrupos.Pesquisar("grupo", txtb_Pesquisa.Text, false, out vlMsg);
                txtb_Pesquisa.Clear();
            }
            else
            {
                errorMSG.SetError(lbl_Pesquisa, "Valor de pesquisa inválido!");
            }
            showErrorMsg(vlMsg);
            txtb_Pesquisa.Clear();
        }

        private void frmConsultaGrupos_Load(object sender, EventArgs e)
        {
            carregarDados(umCtrlGrupos);
        }
    }
}
