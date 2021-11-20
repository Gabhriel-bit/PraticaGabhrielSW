using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_ICI.frmConsultas
{
    public partial class frmConsultaVendas : Projeto_ICI.frmConsultas.frmConsultaPai
    {
        frmCadastros.frmCadastroVendas frmCadVenda;
        Controllers.ctrlVendas umCtrlVenda;
        Classes.vendas umaVenda;

        public frmConsultaVendas(Controllers.ctrlVendas pCtrlVenda)
        {
            InitializeComponent();
            umCtrlVenda = pCtrlVenda;
            umaVenda = new Classes.vendas();
            carregarDados(umCtrlVenda);

            btn_Excluir.Text = "Cancelar";
            btn_Alterar.Visible = false;
            resizeButtons();
        }

        public override void SetFrmCad(Form pFrmCad)
        {
            frmCadVenda = (frmCadastros.frmCadastroVendas)pFrmCad;
        }
        public override void ConhecaOBJ(object pOBJ)
        {
            umaVenda = (Classes.vendas)pOBJ;
        }

        private void btn_Inserir_Click(object sender, EventArgs e)
        {
            frmCadVenda.ClearTxTBox();
            frmCadVenda.ShowDialog();
            carregarDados(umCtrlVenda);
        }

        protected override void resizeButtons()
        {
            decimal larguraDGV = this.Width - 35;
            var pos = Math.Truncate((larguraDGV - 40) / 3);
            var X = int.Parse((pos + Math.Truncate(pos / 3)).ToString());
            btn_Excluir.Location = new Point(X, btn_Excluir.Location.Y);
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            var vlCompra = (Classes.vendas)dataGridToObj(umCtrlVenda, out string vlMsg);
            if (vlCompra == null)
            {
                errorMSG.SetError(btn_Excluir, "Selecão inválida!\nSelecione apenas uma venda");
                this.dataGridView.Focus();
            }
            else if (vlMsg != "")
            {
                errorMSG.SetError(btn_Excluir, "Erro ao carregar!\n" + vlMsg);
                this.dataGridView.Focus();
            }
            else
            {
                errorMSG.SetError(btn_Excluir, null);
                frmCadVenda.ClearTxTBox();
                var btnName = frmCadVenda.Btn_Acao;
                frmCadVenda.Btn_Acao = "Cancelar";
                frmCadVenda.CarregarTxtBox(vlCompra);
                frmCadVenda.BloquearTxtBox(false);
                frmCadVenda.ShowDialog();
                frmCadVenda.Btn_Acao = btnName;
                carregarDados(umCtrlVenda);
            }
        }
        protected override object dataGridToObj(Controllers.ctrl pCtrl, out string pMsg)
        {
            pMsg = "";
            if (dataGridView.SelectedRows.Count == 0 || dataGridView.SelectedRows[0].Cells[0].Value == null)
                return null;
            else
            {
                var row = dataGridView.SelectedRows[0].Cells;
                var vlCodigoCliente = ((Classes.clientes)umCtrlVenda.CTRLCliente.Pesquisar("cliente",
                                 (string)row[3].Value, out pMsg, true)).Codigo.ToString();
                return pCtrl.Pesquisar(umaVenda.ToStringPK.Split(';'),
                                   new string[] { (string)row[0].Value,
                                                      (string)row[1].Value,
                                                      (string)row[2].Value,
                                                                vlCodigoCliente},
                                   out pMsg, true);
            }
        }

        protected override void Sair()
        {
            if (btn_Sair.Text != "Sair")
            {
                var vlCompra = (Classes.vendas)dataGridToObj(umCtrlVenda, out string vlMsg);
                if (vlMsg != "")
                {
                    errorMSG.SetError(btn_Sair, "Erro ao carregar!\n" + vlMsg);
                    this.dataGridView.Focus();
                }
                else
                {
                    errorMSG.SetError(btn_Sair, null);
                    umaVenda.ThisCompra = vlCompra;
                }
            }
        }
        private void frmConsultaCompras_Load(object sender, EventArgs e)
        {
            carregarDados(umCtrlVenda);
            errorMSG.SetError(lbl_CampoPesquisa, "O campo 'Chave identificadora' é composto por:" +
                                                 "\nmodelo;série;número de Nota fiscal;código do cliente" +
                                                 "\nInsira os valores nesta ordem e os separando com ';'");
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            var vlChavePesquisa = "";
            string vlMsg = "";
            switch (cb_ChavePesquisa.SelectedItem.ToString())
            {
                case ("Chave identificadora"):
                    {
                        errorMSG.Clear();
                        vlChavePesquisa = (txtb_Pesquisa.Text == "" ? "" : umaVenda.ToStringPK);
                        if (txtb_Pesquisa.Text.Split(';').Length != 4 && txtb_Pesquisa.Text != "")
                            vlMsg = "Insira os quatro campos com o separador ; !";
                        else if (!int.TryParse(txtb_Pesquisa.Text.Split(';')[txtb_Pesquisa.Text.Split(';').Length - 1], out int _)
                                && txtb_Pesquisa.Text != "")
                            vlMsg = "Insira um código válido para o cliente!";
                        else
                        {
                            dataGridView.DataSource = umCtrlVenda.Pesquisar(vlChavePesquisa.Split(';'),
                                                                             txtb_Pesquisa.Text.Split(';'),
                                                                             false,
                                                                             out vlMsg);
                            txtb_Pesquisa.Clear();
                        }
                        errorMSG.SetError(lbl_Pesquisa, vlMsg);
                        errorMSG.SetError(lbl_CampoPesquisa, "O campo 'Chave identificadora' é composto por:" +
                                        "\nmodelo;série;número de Nota fiscal;código do cliente" +
                                        "\nInsira os valores nesta ordem e os separando com ';'");
                        return;
                    }
                case ("Data chegada"):
                    {
                        vlChavePesquisa = "data_chegada";
                        break;
                    }
                case ("Data emissão"):
                    {
                        vlChavePesquisa = "data_emissao";
                        break;
                    }
                case ("Código Fornecedor"):
                    {
                        vlChavePesquisa = "codigoCliente";
                        break;
                    }
                case ("Código da Condição Pagamento"):
                    {
                        vlChavePesquisa = "vendas.codigoCondPag";
                        break;
                    }
                case ("Código da Transportadora"):
                    {
                        vlChavePesquisa = "codigoTransp";
                        break;
                    }
            }
            dataGridView.DataSource = umCtrlVenda.Pesquisar(vlChavePesquisa,
                                                             txtb_Pesquisa.Text,
                                                             false,
                                                             out vlMsg);
            if (vlMsg != "")
                errorMSG.SetError(lbl_Pesquisa, vlMsg);
            txtb_Pesquisa.Clear();
        }

        private void cb_ChavePesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_ChavePesquisa.SelectedItem.ToString() == "Chave identificadora")
            {
                errorMSG.SetError(lbl_CampoPesquisa, "O campo 'Chave identificadora' é composto por:" +
                                         "\nmodelo;série;número de Nota fiscal;código do cliente" +
                                         "\nInsira os valores nesta ordem e os separe com ;");
            }
            else
            {
                errorMSG.SetError(lbl_CampoPesquisa, null);
            }

        }

        private void cb_ChavePesquisa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtb_Pesquisa.Focus();
        }
    }
}
