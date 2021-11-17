using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_ICI.frmConsultas
{
    public partial class frmConsultaCompras : Projeto_ICI.frmConsultas.frmConsultaPai
    {
        frmCadastros.frmCadastroCompras frmCadCompra;
        Controllers.ctrlCompras umCtrlCompra;
        Classes.compras umaCompra;

        public frmConsultaCompras(Controllers.ctrlCompras pCtrlCompra)
        {
            InitializeComponent();
            umCtrlCompra = pCtrlCompra;
            umaCompra = new Classes.compras();
            carregarDados(umCtrlCompra);

            btn_Excluir.Text = "Cancelar";
            btn_Alterar.Visible = false;
            resizeButtons();
        }

        public override void SetFrmCad(Form pFrmCad)
        {
            frmCadCompra = (frmCadastros.frmCadastroCompras)pFrmCad;
        }
        public override void ConhecaOBJ(object pOBJ)
        {
            umaCompra = (Classes.compras)pOBJ;
        }

        private void btn_Inserir_Click(object sender, EventArgs e)
        {
            frmCadCompra.ClearTxTBox();
            frmCadCompra.ShowDialog();
            carregarDados(umCtrlCompra);
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
            var vlCompra = (Classes.compras)dataGridToObj(umCtrlCompra, out string vlMsg);
            if (vlCompra == null)
            {
                errorMSG.SetError(btn_Excluir, "Selecão inválida!\nSelecione apenas uma compra");
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
                frmCadCompra.ClearTxTBox();
                var btnName = frmCadCompra.Btn_Acao;
                frmCadCompra.Btn_Acao = "Cancelar";
                frmCadCompra.CarregarTxtBox(vlCompra);
                frmCadCompra.BloquearTxtBox(true);
                frmCadCompra.ShowDialog();
                frmCadCompra.Btn_Acao = btnName;
                carregarDados(umCtrlCompra);
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
                var vlCodForn = ((Classes.fornecedores)umCtrlCompra.CTRLForn.Pesquisar("fornecedor",
                                 (string)row[3].Value, out pMsg, true)).Codigo.ToString();
                    return pCtrl.Pesquisar(umaCompra.ToStringPK.Split(';'),
                                       new string[] { (string)row[0].Value,
                                                      (string)row[1].Value,
                                                      (string)row[2].Value,
                                                                vlCodForn},
                                       out pMsg, true);
            }
        }

        protected override void Sair()
        {
            if (btn_Sair.Text != "Sair")
            {
                var vlCompra = (Classes.compras)dataGridToObj(umCtrlCompra, out string vlMsg);
                if (vlMsg != "")
                {
                    errorMSG.SetError(btn_Sair, "Erro ao carregar!\n" + vlMsg);
                    this.dataGridView.Focus();
                }
                else
                {
                    errorMSG.SetError(btn_Sair, null);
                    umaCompra.ThisCompra = vlCompra;
                }
            }
        }
        private void frmConsultaCompras_Load(object sender, EventArgs e)
        {
            carregarDados(umCtrlCompra);
            errorMSG.SetError(lbl_CampoPesquisa, "O campo 'Chave identificadora' é composto por:" +
                                                 "\nmodelo;série;número de Nota fiscal;código do fornecedor" +
                                                 "\nInsira os valores nesta ordem e os separando com ';'");
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            var vlChavePesquisa = "";
            var vlValorIgual = true;
            string vlMsg = "";
            switch (cb_ChavePesquisa.SelectedItem.ToString())
            {
                case ("Chave identificadora"):
                {
                    errorMSG.Clear();
                    vlChavePesquisa = (txtb_Pesquisa.Text == "" ? "" : umaCompra.ToStringPK);
                    if(txtb_Pesquisa.Text.Split(';').Length != 4 && txtb_Pesquisa.Text != "")
                        vlMsg = "Insira os quatro campos com o separador ; !";
                    else if(!int.TryParse(txtb_Pesquisa.Text.Split(';')[txtb_Pesquisa.Text.Split(';').Length - 1], out int _)
                            && txtb_Pesquisa.Text != "")
                        vlMsg = "Insira um código válido para o fornecedor!";
                    else
                    {
                        dataGridView.DataSource = umCtrlCompra.Pesquisar(vlChavePesquisa.Split(';'),
                                                                         txtb_Pesquisa.Text.Split(';'),
                                                                         true,
                                                                         out vlMsg);
                        txtb_Pesquisa.Clear();
                    }
                    errorMSG.SetError(lbl_Pesquisa, vlMsg);
                    errorMSG.SetError(lbl_CampoPesquisa, "O campo 'Chave identificadora' é composto por:" +
                                    "\nmodelo;série;número de Nota fiscal;código do fornecedor" +
                                    "\nInsira os valores nesta ordem e os separando com ';'");
                    return;
                }
                case ("Data chegada") :
                {
                    vlChavePesquisa = "data_chegada";
                    vlValorIgual = false;
                    break;
                }
                case ("Data emissão") :
                {
                    vlChavePesquisa = "data_emissao";
                    vlValorIgual = false;
                    break;
                }
                case ("Código Fornecedor") :
                {
                    vlChavePesquisa = "codigoForn";
                    break;
                }
                case ("Código da Condição Pagamento") :
                {
                    vlChavePesquisa = "compras.codigoCondPag";
                    break;
                }
                case ("Código da Transportadora"):
                {
                    vlChavePesquisa = "codigoTransp";
                    break;
                }
            }
            dataGridView.DataSource = umCtrlCompra.Pesquisar(vlChavePesquisa,
                                                             txtb_Pesquisa.Text,
                                                             vlValorIgual, out vlMsg);
            if(vlMsg != "")
                errorMSG.SetError(lbl_Pesquisa, vlMsg);
            txtb_Pesquisa.Clear();
        }

        private void cb_ChavePesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_ChavePesquisa.SelectedItem.ToString() == "Chave identificadora")
            {
                errorMSG.SetError(lbl_CampoPesquisa, "O campo 'Chave identificadora' é composto por:" +
                                         "\nmodelo;série;número de Nota fiscal;código do fornecedor" +
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
