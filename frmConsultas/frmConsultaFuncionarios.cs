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
    public partial class frmConsultaFuncionarios : Projeto_ICI.frmConsultas.frmConsultaPai
    {
        frmCadastros.frmCadastroFuncionarios frmCadFunc;
        Controllers.ctrlFuncionarios umCtrlFunc;
        List<Classes.cargos> listaCargos;
        List<Classes.cidades> listaCidades;
        Classes.funcionarios umFunc;
        public frmConsultaFuncionarios()
        {
            InitializeComponent();
            frmCadFunc = new frmCadastros.frmCadastroFuncionarios();
            umCtrlFunc = new Controllers.ctrlFuncionarios();
            umFunc = new Classes.funcionarios();
            carregarDados(umCtrlFunc);
        }
        public frmConsultaFuncionarios(BancoDados.conexoes pUmaConexao)
        {
            InitializeComponent();
            umCtrlFunc = new Controllers.ctrlFuncionarios(pUmaConexao);
            umFunc = new Classes.funcionarios();
            carregarDados(umCtrlFunc);
        }
        public override void SetFrmCad(Form pFrmCad)
        {
            frmCadFunc = (frmCadastros.frmCadastroFuncionarios)pFrmCad;
        }
        protected override void carregarDados(controllers pCTRL)
        {
            base.carregarDados(pCTRL);
            listaCargos = umCtrlFunc.CTRLCargo.PesquisarCollection();
            listaCidades = umCtrlFunc.CTRLCidade.PesquisarCollection();

        }
        public override void ConhecaOBJ(object pOBJ)
        {
            umFunc = (Classes.funcionarios)pOBJ;
        }
        private void btn_Inserir_Click(object sender, EventArgs e)
        {
            frmCadFunc.ClearTxTBox();
            frmCadFunc.ShowDialog();
            carregarDados(umCtrlFunc);
        }
        private Classes.funcionarios dataGridToFuncionario()
        {
            if (dataGridView.SelectedRows.Count == 0 ||
                dataGridView.SelectedRows[0].Cells[0].Value == null)
            {
                return null;
            }
            else
            {
                var row = dataGridView.SelectedRows[0].Cells;
                var vlFunc = new Classes.funcionarios((int)row[0].Value, (int)row[19].Value,
                                                      (string)row[20].Value, (string)row[21].Value,
                                                      (string)row[1].Value, (string)row[7].Value,
                                                      (string)row[8].Value, (string)row[9].Value,
                                                      (string)row[6].Value, (string)row[10].Value,
                                                      (string)row[3].Value, (string)row[4].Value,
                                                      (string)row[11].Value, (string)row[12].Value,
                                                      (string)row[15].Value,
                                                      decimal.Parse(row[16].Value.ToString(), vgEstilo, vgProv),
                                                      decimal.Parse(row[17].Value.ToString(), vgEstilo, vgProv),
                                                      decimal.Parse(row[18].Value.ToString(), vgEstilo, vgProv),
                                                      (string)row[13].Value, (string)row[14].Value);

                vlFunc.UmCargo.Codigo = (int)row[2].Value;
                foreach (Classes.cargos vlCargo in listaCargos)
                {
                    if (vlCargo.Codigo == vlFunc.UmCargo.Codigo)
                    { vlFunc.UmCargo.ThisCargo = vlCargo; }
                }

                vlFunc.UmaCidade.Codigo = (int)row[5].Value;
                foreach (Classes.cidades vlCidade in listaCidades)
                {
                    if (vlCidade.Codigo == vlFunc.UmaCidade.Codigo)
                    { vlFunc.UmaCidade.ThisCidade = vlCidade; }
                }
                return vlFunc;
            }
        }
        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            var vlFunc = dataGridToFuncionario();
            if (vlFunc == null)
            {
                errorMSG.SetError(btn_Alterar, "Selecão inválida!\nSelecione um e apenas um funcionário");
                this.dataGridView.Focus();
            }
            else
            {
                errorMSG.SetError(btn_Alterar, null);
                frmCadFunc.ClearTxTBox();
                var btnName = frmCadFunc.Btn_Acao;
                frmCadFunc.Btn_Acao = "Alterar";
                frmCadFunc.CarregarTxtBox(vlFunc);
                frmCadFunc.ShowDialog();
                frmCadFunc.Btn_Acao = btnName;
                carregarDados(umCtrlFunc);
            }
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            var vlFunc = dataGridToFuncionario();
            if (vlFunc == null)
            {
                errorMSG.SetError(btn_Excluir, "Selecão inválida!\nSelecione um e apenas um funcionário");
                this.dataGridView.Focus();
            }
            else
            {
                errorMSG.SetError(btn_Excluir, null);
                frmCadFunc.ClearTxTBox();
                var btnName = frmCadFunc.Btn_Acao;
                frmCadFunc.BloquearTxtBox();
                frmCadFunc.CarregarTxtBox(vlFunc);
                frmCadFunc.Btn_Acao = "Excluir";
                frmCadFunc.ShowDialog();
                frmCadFunc.Btn_Acao = btnName;
                carregarDados(umCtrlFunc);
            }
        }
        protected override void Sair()
        {
            if (btn_Sair.Text != "Sair")
            {
                var vlFunc = dataGridToFuncionario();
                if (vlFunc == null)
                {
                    errorMSG.SetError(btn_Sair, "Selecione um e apenas um funcionário!");
                    this.dataGridView.Focus();
                }
                else
                {
                    errorMSG.SetError(btn_Sair, null);
                    umFunc.ThisFunc = vlFunc;
                }
            }
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            if (txtb_Pesquisa.Text == "")
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlFunc.Pesquisar();
            }
            else if (ValidacaoCPF(txtb_Pesquisa.Text))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlFunc.Pesquisar("cpf", FormatCPF(txtb_Pesquisa.Text));
                txtb_Pesquisa.Clear();
            }
            else if (ValidacaoCNPJ(txtb_Pesquisa.Text))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlFunc.Pesquisar("cnpj", FormatCNPJ(txtb_Pesquisa.Text));
                txtb_Pesquisa.Clear();
            }
            else if (int.TryParse(txtb_Pesquisa.Text, out _))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlFunc.Pesquisar("codigo", txtb_Pesquisa.Text);
                txtb_Pesquisa.Clear();
            }
            else if (ValidacaoNome(txtb_Pesquisa.Text, 1, true))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlFunc.Pesquisar("funcionario", txtb_Pesquisa.Text);
                txtb_Pesquisa.Clear();
            }
            else
            {
                errorMSG.SetError(lbl_Pesquisa, "Valor de pesquisa inválido!");
            }
        }

        private void frmConsultaFuncionarios_Load(object sender, EventArgs e)
        {
            carregarDados(umCtrlFunc);
        }
    }
}
