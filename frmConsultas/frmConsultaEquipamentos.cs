using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_ICI.frmConsultas
{
    public partial class frmConsultaEquipamentos : Projeto_ICI.frmConsultas.frmConsultaPai
    {
        frmCadastros.frmCadastroEquipamentos frmCadEquip;
        Controllers.ctrlEquipamentos umCtrlEquip;
        Classes.equipamentos umEquip;

        public frmConsultaEquipamentos(Controllers.ctrlEquipamentos pCtrlEquip)
        {
            InitializeComponent();
            umCtrlEquip = pCtrlEquip;
            umEquip = new Classes.equipamentos();
            carregarDados(umCtrlEquip);
        }
        public override void SetFrmCad(Form pFrmCad)
        {
            frmCadEquip = (frmCadastros.frmCadastroEquipamentos)pFrmCad;
        }

        public override void ConhecaOBJ(object pOBJ)
        {
            umEquip = (Classes.equipamentos)pOBJ;
        }

        private void btn_Inserir_Click(object sender, EventArgs e)
        {
            frmCadEquip.ClearTxTBox();
            frmCadEquip.ShowDialog();
            carregarDados(umCtrlEquip);
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            var vlEquip = (Classes.equipamentos)dataGridToObj(umCtrlEquip, out string vlMsg);
            if (vlEquip == null)
            {
                errorMSG.SetError(btn_Alterar, "Selecão inválida!\nSelecione um e apenas um equipamento");
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
                frmCadEquip.ClearTxTBox();
                var btnName = frmCadEquip.Btn_Acao;
                frmCadEquip.Btn_Acao = "Alterar";
                frmCadEquip.CarregarTxtBox(vlEquip);
                frmCadEquip.ShowDialog();
                frmCadEquip.Btn_Acao = btnName;
                carregarDados(umCtrlEquip);
            }
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            var vlEquip = (Classes.equipamentos)dataGridToObj(umCtrlEquip, out string vlMsg);
            if (vlEquip == null)
            {
                errorMSG.SetError(btn_Excluir, "Selecão inválida!\nSelecione um e apenas um equipamento");
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
                frmCadEquip.ClearTxTBox();
                var btnName = frmCadEquip.Btn_Acao;
                frmCadEquip.BloquearTxtBox();
                frmCadEquip.CarregarTxtBox(vlEquip);
                frmCadEquip.Btn_Acao = "Excluir";
                frmCadEquip.ShowDialog();
                frmCadEquip.Btn_Acao = btnName;
                carregarDados(umCtrlEquip);
            }
        }

        protected override void Sair()
        {
            if (btn_Sair.Text != "Sair")
            {
                var vlEquip = (Classes.equipamentos)dataGridToObj(umCtrlEquip, out string vlMsg);
                if (vlEquip == null)
                {
                    errorMSG.SetError(btn_Sair, "Selecione um e apenas um equipamento!");
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
                    umEquip.ThisEquipemanto = vlEquip;
                }
            }
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            string vlMsg = "";
            if (txtb_Pesquisa.Text == "")
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                carregarDados(umCtrlEquip);
            }
            else if (int.TryParse(txtb_Pesquisa.Text, out _))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlEquip.Pesquisar("codigo", txtb_Pesquisa.Text, default, out vlMsg);
            }
            else if (ValidacaoNome(txtb_Pesquisa.Text, 1, true))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlEquip.Pesquisar("equipamento", txtb_Pesquisa.Text, false, out vlMsg);
            }
            else
            {
                errorMSG.SetError(lbl_Pesquisa, "Valor de pesquisa inválido!");
            }
            showErrorMsg(vlMsg);
            txtb_Pesquisa.Clear();
        }

        private void frmConsultaEquipamentos_Load(object sender, EventArgs e)
        {
            carregarDados(umCtrlEquip);
        }
    }
}
