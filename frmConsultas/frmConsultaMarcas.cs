using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_ICI.frmConsultas
{
    public partial class frmConsultaMarcas : Projeto_ICI.frmConsultas.frmConsultaPai
    {
        frmCadastros.frmCadastroMarcas frmCadMarca;
        Controllers.ctrlMarcas umCtrlMarca;
        Classes.marcas umaMarca;

        public frmConsultaMarcas(Controllers.ctrlMarcas pCtrlMarca)
        {
            InitializeComponent();
            umCtrlMarca = pCtrlMarca;
            umaMarca = new Classes.marcas();
            carregarDados(umCtrlMarca);
        }
        public override void SetFrmCad(Form pFrmCad)
        {
            frmCadMarca = (frmCadastros.frmCadastroMarcas)pFrmCad;
        }
        public override void ConhecaOBJ(object pOBJ)
        {
            umaMarca = (Classes.marcas)pOBJ;
        }

        private void btn_Inserir_Click(object sender, EventArgs e)
        {
            frmCadMarca.ClearTxTBox();
            frmCadMarca.ShowDialog();
            carregarDados(umCtrlMarca);
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            var vlMarca = (Classes.marcas)dataGridToObj(umCtrlMarca, out string vlMsg);
            if (vlMarca == null)
            {
                errorMSG.SetError(btn_Alterar, "Selecão inválida!\nSelecione uma e apenas uma marca");
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
                frmCadMarca.ClearTxTBox();
                var btnName = frmCadMarca.Btn_Acao;
                frmCadMarca.CarregarTxtBox(vlMarca);
                frmCadMarca.Btn_Acao = "Alterar";
                frmCadMarca.ShowDialog();
                frmCadMarca.Btn_Acao = btnName;
                carregarDados(umCtrlMarca);
            }
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            var vlMarca = (Classes.marcas)dataGridToObj(umCtrlMarca, out string vlMsg);
            if (vlMarca == null)
            {
                errorMSG.SetError(btn_Excluir, "Selecão inválida!\nSelecione uma e apenas uma marca");
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
                frmCadMarca.ClearTxTBox();
                frmCadMarca.BloquearTxtBox();
                var btnName = frmCadMarca.Btn_Acao;
                frmCadMarca.CarregarTxtBox(vlMarca);
                frmCadMarca.Btn_Acao = "Excluir";
                frmCadMarca.ShowDialog();
                frmCadMarca.Btn_Acao = btnName;
                carregarDados(umCtrlMarca);
            }
        }
        protected override void Sair()
        {
            if (btn_Sair.Text != "Sair")
            {
                var vlMarca = (Classes.marcas)dataGridToObj(umCtrlMarca, out string vlMsg);
                if (vlMarca == null)
                {
                    errorMSG.SetError(btn_Sair, "Selecione uma e apenas uma marca!");
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
                    umaMarca.ThisMarca = vlMarca;
                }
            }
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            string vlMsg = "";
            if (txtb_Pesquisa.Text == "")
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                carregarDados(umCtrlMarca);
            }
            else if (int.TryParse(txtb_Pesquisa.Text, out _))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlMarca.Pesquisar("codigo", txtb_Pesquisa.Text, default, out vlMsg);
                txtb_Pesquisa.Clear();
            }
            else if (ValidacaoNome(txtb_Pesquisa.Text, 1, true))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlMarca.Pesquisar("marca", txtb_Pesquisa.Text, false, out vlMsg);
                txtb_Pesquisa.Clear();
            }
            else
            {
                errorMSG.SetError(lbl_Pesquisa, "Valor de pesquisa inválido!");
            }
            showErrorMsg(vlMsg);
            txtb_Pesquisa.Clear();
        }

        private void frmConsultaMarcas_Load(object sender, EventArgs e)
        {
            carregarDados(umCtrlMarca);
        }
    }
}
