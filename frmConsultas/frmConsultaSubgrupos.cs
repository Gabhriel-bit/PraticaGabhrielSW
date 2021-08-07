using Projeto_ICI.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_ICI.frmConsultas
{
    public partial class frmConsultaSubgrupos : Projeto_ICI.frmConsultas.frmConsultaPai
    {
        frmCadastros.frmCadastroSubGrupos frmCadSubGrupo;
        Controllers.ctrlSubgrupos umCtrlSubgrupo;
        List<Classes.grupos> listaGrupos;
        Classes.subgrupos umSubgrupo;
        public frmConsultaSubgrupos()
        {
            InitializeComponent();
            frmCadSubGrupo = new frmCadastros.frmCadastroSubGrupos();
            umCtrlSubgrupo = new Controllers.ctrlSubgrupos();
            umSubgrupo = new Classes.subgrupos();
            carregarDados(umCtrlSubgrupo);
        }
        public frmConsultaSubgrupos(BancoDados.conexoes pUmaConexao)
        {
            InitializeComponent();
            umCtrlSubgrupo = new Controllers.ctrlSubgrupos(pUmaConexao);
            umSubgrupo = new Classes.subgrupos();
            carregarDados(umCtrlSubgrupo);
        }
        public override void SetFrmCad(Form pFrmCad)
        {
            frmCadSubGrupo = (frmCadastros.frmCadastroSubGrupos)pFrmCad;
        }
        protected override void carregarDados(controllers pCTRL)
        {
            base.carregarDados(pCTRL);
            listaGrupos = umCtrlSubgrupo.CTRLGrupo.PesquisarCollection(out string vlMsg);
            showErrorMsg(vlMsg);
        }

        public override void ConhecaOBJ(object pOBJ)
        {
            umSubgrupo = (Classes.subgrupos)pOBJ;
        }

        private Classes.subgrupos dataGridToSubgrupo()
        {
            if (dataGridView.SelectedRows.Count == 0 ||
                dataGridView.SelectedRows[0].Cells[0].Value == null)
            {
                return null;
            }
            else
            {
                var row = dataGridView.SelectedRows[0].Cells;
                var vlSubgrupo = new Classes.subgrupos((int)row[0].Value, (int)row[3].Value,
                                                     (string)row[4].Value, (string)row[5].Value,
                                                     (string)row[1].Value);
                vlSubgrupo.UmGrupo.Codigo = (int)row[2].Value;
                foreach (Classes.grupos vlGrupo in listaGrupos)
                {
                    if (vlGrupo.Codigo == vlSubgrupo.UmGrupo.Codigo)
                    { vlSubgrupo.UmGrupo.ThisGrupo = vlGrupo; }
                }
                return vlSubgrupo;
            }
        }

        private void btn_Inserir_Click(object sender, EventArgs e)
        {
            frmCadSubGrupo.ClearTxTBox();
            frmCadSubGrupo.ShowDialog();
            carregarDados(umCtrlSubgrupo);
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            var vlSubgrupo = dataGridToSubgrupo();
            if (vlSubgrupo == null)
            {
                errorMSG.SetError(btn_Alterar, "Selecão inválida!\nSelecione um e apenas um subgrupo");
                this.dataGridView.Focus();
            }
            else
            {
                errorMSG.SetError(btn_Alterar, null);
                frmCadSubGrupo.ClearTxTBox();
                var btnName = frmCadSubGrupo.Btn_Acao;
                frmCadSubGrupo.Btn_Acao = "Alterar";
                frmCadSubGrupo.CarregarTxtBox(vlSubgrupo);
                frmCadSubGrupo.ShowDialog();
                frmCadSubGrupo.Btn_Acao = btnName;
                carregarDados(umCtrlSubgrupo);
            }
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            var vlSubgrupo = dataGridToSubgrupo();
            if (vlSubgrupo == null)
            {
                errorMSG.SetError(btn_Excluir, "Selecão inválida!\nSelecione um e apenas um subgrupo");
                this.dataGridView.Focus();
            }
            else
            {
                errorMSG.SetError(btn_Excluir, null);
                frmCadSubGrupo.ClearTxTBox();
                var btnName = frmCadSubGrupo.Btn_Acao;
                frmCadSubGrupo.BloquearTxtBox();
                frmCadSubGrupo.CarregarTxtBox(vlSubgrupo);
                frmCadSubGrupo.Btn_Acao = "Excluir";
                frmCadSubGrupo.ShowDialog();
                frmCadSubGrupo.Btn_Acao = btnName;
                carregarDados(umCtrlSubgrupo);
            }
        }

        protected override void Sair()
        {
            if (btn_Sair.Text != "Sair")
            {
                var vlSubgrupo = dataGridToSubgrupo();
                if (vlSubgrupo == null)
                {
                    errorMSG.SetError(btn_Sair, "Selecione um e apenas um subgrupo!");
                    this.dataGridView.Focus();
                }
                else
                {
                    errorMSG.SetError(btn_Sair, null);
                    umSubgrupo.ThisSubgrupo = vlSubgrupo;
                }
            }
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            string vlMsg = "";
            if (txtb_Pesquisa.Text == "")
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                carregarDados(umCtrlSubgrupo);
            }
            else if (int.TryParse(txtb_Pesquisa.Text, out _))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlSubgrupo.Pesquisar("codigo", txtb_Pesquisa.Text, out vlMsg);
            }
            else if (ValidacaoNome(txtb_Pesquisa.Text, 1, true))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlSubgrupo.Pesquisar("subgrupo", txtb_Pesquisa.Text, out vlMsg);
            }
            else
            {
                errorMSG.SetError(lbl_Pesquisa, "Valor de pesquisa inválido!");
            }
            showErrorMsg(vlMsg);
            txtb_Pesquisa.Clear();
        }

        private void frmConsultaSubgrupos_Load(object sender, EventArgs e)
        {
            carregarDados(umCtrlSubgrupo);
        }
    }
}
