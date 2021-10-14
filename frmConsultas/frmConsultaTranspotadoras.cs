using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_ICI.frmConsultas
{
    public partial class frmConsultaTranspotadoras : Projeto_ICI.frmConsultas.frmConsultaPai
    {
        frmCadastros.frmCadastroTransportadoras frmCadForn;
        Controllers.ctrlTransportadoras umCtrlTransport;
        Classes.transportadoras umTransport;

        public frmConsultaTranspotadoras(Controllers.ctrlTransportadoras pCtrlForn)
        {
            InitializeComponent();
            umCtrlTransport = pCtrlForn;
            umTransport = new Classes.transportadoras();
            carregarDados(umCtrlTransport);
        }
        public override void SetFrmCad(Form pFrmCad)
        {
            frmCadForn = (frmCadastros.frmCadastroTransportadoras)pFrmCad;
        }
        public override void ConhecaOBJ(object pOBJ)
        {
            umTransport = (Classes.transportadoras)pOBJ;
        }

        private void btn_Inserir_Click(object sender, EventArgs e)
        {
            frmCadForn.ClearTxTBox();
            frmCadForn.ShowDialog();
            carregarDados(umCtrlTransport);
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            var vlTransport = (Classes.transportadoras)dataGridToObj(umCtrlTransport, out string vlMsg);
            if (vlTransport == null)
            {
                errorMSG.SetError(btn_Alterar, "Selecão inválida!\nSelecione um e apenas uma transportadora");
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
                frmCadForn.ClearTxTBox();
                var btnName = frmCadForn.Btn_Acao;
                frmCadForn.Btn_Acao = "Alterar";
                frmCadForn.CarregarTxtBox(vlTransport);
                frmCadForn.ShowDialog();
                frmCadForn.Btn_Acao = btnName;
                carregarDados(umCtrlTransport);
            }
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            var vlTransport = (Classes.transportadoras)dataGridToObj(umCtrlTransport, out string vlMsg);
            if (vlTransport == null)
            {
                errorMSG.SetError(btn_Excluir, "Selecão inválida!\nSelecione um e apenas uma transportadora");
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
                frmCadForn.ClearTxTBox();
                var btnName = frmCadForn.Btn_Acao;
                frmCadForn.BloquearTxtBox();
                frmCadForn.CarregarTxtBox(vlTransport);
                frmCadForn.Btn_Acao = "Excluir";
                frmCadForn.ShowDialog();
                frmCadForn.Btn_Acao = btnName;
                carregarDados(umCtrlTransport);
            }
        }
        protected override void Sair()
        {
            if (btn_Sair.Text != "Sair")
            {
                var vlTransport = (Classes.transportadoras)dataGridToObj(umCtrlTransport, out string vlMsg);
                if (vlTransport == null)
                {
                    errorMSG.SetError(btn_Sair, "Selecione apenas uma trasportadora!");
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
                    umTransport.ThisTransportadora = vlTransport;
                }
            }
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            string vlMsg = "";
            if (txtb_Pesquisa.Text == "")
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlTransport.Pesquisar("", "", default, out vlMsg);
            }
            else if (ValidacaoCPF(txtb_Pesquisa.Text))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlTransport.Pesquisar("cpf", FormatCPF(txtb_Pesquisa.Text), default, out vlMsg);
                txtb_Pesquisa.Clear();
            }
            else if (ValidacaoCNPJ(txtb_Pesquisa.Text))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlTransport.Pesquisar("cnpj", FormatCNPJ(txtb_Pesquisa.Text), default, out vlMsg);
                txtb_Pesquisa.Clear();
            }
            else if (int.TryParse(txtb_Pesquisa.Text, out _))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlTransport.Pesquisar("codigo", txtb_Pesquisa.Text, default, out vlMsg);
                txtb_Pesquisa.Clear();
            }
            else if (ValidacaoNome(txtb_Pesquisa.Text, 1, true))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlTransport.Pesquisar("transportadora", txtb_Pesquisa.Text, false, out vlMsg);
                txtb_Pesquisa.Clear();
            }
            else
            {
                errorMSG.SetError(lbl_Pesquisa, "Valor de pesquisa inválido!");
            }
            showErrorMsg(vlMsg);
            txtb_Pesquisa.Clear();
        }

        private void frmConsultaTransportadoras_Load(object sender, EventArgs e)
        {
            carregarDados(umCtrlTransport);
        }
    }
}
