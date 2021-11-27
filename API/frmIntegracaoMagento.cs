using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_ICI.API
{
    public partial class frmIntegracaoMagento : Projeto_ICI.formularioBase
    {
        private string FimagemBase64;
        private conexaoMagento umConexao;
        private Classes.produtos umProduto;
        private API.magentoProdutos umMagentoProd;
        private Controllers.ctrlProdutos umaCtrlProduto;
        private frmConsultas.frmConsultaProdutos frmConsProduto;
        private string FmsgLog;
        private List<Tuple<Classes.produtos, bool[]>> FlistaProdutos;
        public frmIntegracaoMagento(conexaoMagento pConexaoMagento, Controllers.ctrlProdutos pCtrl)
        {
            InitializeComponent();

            //umProduto = new Classes.produtos();
            umMagentoProd = new magentoProdutos(pConexaoMagento);
            umProduto = new Classes.produtos(0, 0, "", "", "DeskJet-2230",
                                                       "", "", decimal.Parse("1523"),
                                                       "", 4, 12, decimal.Parse("10"),
                                                       0, 0);
            umaCtrlProduto = pCtrl;
            FmsgLog = "";
            FimagemBase64 = "";
            FlistaProdutos = new List<Tuple<Classes.produtos, bool[]>>();
            umConexao = pConexaoMagento;
        }
        public override void SetFrmCons(Form pFrmCons)
        {
            frmConsProduto = (frmConsultas.frmConsultaProdutos)pFrmCons;
        }
        private void atualizarStatus(string pProcedimeto, string  pStatus)
        {
            //Conecatado ao site:
            lbl_ConSite.Text = umConexao.URL;
            //Horário da ultima conexão:
            lbl_Hora.Text = umConexao.UltDataAcesso;
            //Tipo de procedimento:
            lbl_Proced.Text = pProcedimeto;
            //Status do porcedimento:
            lbl_Status.Text = pStatus;
            if (pStatus == "OK")
                lbl_Status.ForeColor = System.Drawing.Color.Green;
            else
                lbl_Status.ForeColor = System.Drawing.Color.Red;
        }

        private void btn_Inserir_Click(object sender, EventArgs e)
        {
            if (lv_MagentoProd.SelectedItems.Count > 0)
            {
                var vlProduto = (Classes.produtos)lv_MagentoProd.SelectedItems[0].Tag;
                foreach (Tuple<Classes.produtos, bool[]> vlTuple in FlistaProdutos)
                {
                    if (vlTuple.Item1.Codigo == vlProduto.Codigo)
                    {
                        umMagentoProd.Conferencias = vlTuple.Item2;
                    }
                }
                FmsgLog = umMagentoProd.Inserir(vlProduto, out string[] vlLog, FimagemBase64);
                atualizarStatus(vlLog[0], vlLog[1]);
                trocaLVAposAcao();
            }
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            if (lv_MagentoProd.SelectedItems.Count > 0)
            {
                var vlProduto = (Classes.produtos)lv_MagentoProd.SelectedItems[0].Tag;
                foreach (Tuple<Classes.produtos, bool[]> vlTuple in FlistaProdutos)
                {
                    if (vlTuple.Item1.Codigo == vlProduto.Codigo)
                    {
                        umMagentoProd.Conferencias = vlTuple.Item2;
                    }
                }
                FmsgLog = umMagentoProd.Alterar(vlProduto, out string[] vlLog);
                atualizarStatus(vlLog[0], vlLog[1]);
                trocaLVAposAcao();
            }
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            if (lv_MagentoProd.SelectedItems.Count > 0)
            {
                var vlProduto = (Classes.produtos)lv_MagentoProd.SelectedItems[0].Tag;
                foreach (Tuple<Classes.produtos, bool[]> vlTuple in FlistaProdutos)
                {
                    if (vlTuple.Item1.Codigo == vlProduto.Codigo)
                    {
                        umMagentoProd.Conferencias = vlTuple.Item2;
                    }
                }
                FmsgLog = umMagentoProd.Excluir(vlProduto.Produto, out string[] vlLog);
                atualizarStatus(vlLog[0], vlLog[1]);
                trocaLVAposAcao();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("chrome.exe", umConexao.URL);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(FmsgLog, "Informações");
        }

        private void frmIntegracaoMagento_Shown(object sender, EventArgs e)
        {
            atualizarStatus(umConexao.StatusRequest[0], umConexao.StatusRequest[1]);
            pictureBox1.Image = null;
            FimagemBase64 = "";
        }

        private void txtb_CodigoProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacaoCodigo(txtb_CodigoProduto, e);
        }

        private void txtb_CodigoProduto_TextChanged(object sender, EventArgs e)
        {
            if (txtb_CodigoProduto.Text == "")
                txtb_Produto.Clear();
            else
            {
                if (int.TryParse(txtb_CodigoProduto.Text, out int vlCodigo))
                {
                    var vlProduto =
                         (Classes.produtos)umaCtrlProduto.Pesquisar("codigo",
                                                                    vlCodigo.ToString(),
                                                                    out string vlMsg,
                                                                    true);
                    if (vlProduto != null)
                        if (vlMsg == "")
                        {
                            txtb_Produto.Text = vlProduto.Produto;
                            umProduto.ThisProduto = vlProduto;
                        }
                        else
                        {
                            errorMSG.SetError(lbl_CodigoProduto, vlMsg);
                            txtb_Produto.Clear();
                        }
                    else
                        txtb_Produto.Clear();
                }
            }
        }

        private void btn_PesquisarProduto_Click(object sender, EventArgs e)
        {
            var nomeBtn = frmConsProduto.Btn_Sair;
            frmConsProduto.Btn_Sair = "Selecionar";
            frmConsProduto.ConhecaOBJ(umProduto);
            frmConsProduto.ShowDialog();
            frmConsProduto.Btn_Sair = nomeBtn;
            if (umProduto.Codigo != 0)
            {
                txtb_CodigoProduto.Text = umProduto.Codigo.ToString();
                txtb_Produto.Text = umProduto.Produto;
            }
        }

        private void btn_Adicionar_Click(object sender, EventArgs e)
        {
            if (lv_Produtos != null && txtb_Produto.Text != "" &&
                !lv_Produtos.Items.ContainsKey(txtb_Produto.Text) &&
                !lv_MagentoProd.Items.ContainsKey(txtb_Produto.Text))
            {
                string[] item = { umProduto.Produto,
                                  umProduto.CalculaPrecoVenda.ToString(),
                                  umProduto.PesoLiquido.ToString(),
                                  umProduto.Saldo.ToString(),
                                  umProduto.Codigo.ToString(),
                                  cb_Estoque.Checked.ToString().ToLower(),
                                  cb_Visivel.Checked.ToString().ToLower()};
                var lvItem = new ListViewItem(item);

                var vlTuple = new Tuple<Classes.produtos, bool[]>(umProduto.ThisProduto, new bool[] { cb_Estoque.Checked,
                                                                                                     cb_Visivel.Checked});
                FlistaProdutos.Add(vlTuple);

                lvItem.Tag = umProduto.ThisProduto;
                lvItem.Name = umProduto.Produto;

                errorMSG.Clear();
                txtb_CodigoProduto.Clear();
                txtb_Produto.Clear();
                lv_Produtos.Items.Add(lvItem);
            }
        }

        private void btn_Remover_Click(object sender, EventArgs e)
        {
            if (lv_Produtos.Items.Count != 0 && lv_Produtos.SelectedItems.Count > 0)
            {
                var vlProduto = (Classes.produtos)lv_Produtos.SelectedItems[0].Tag;
                int i = 0;
                foreach (Tuple<Classes.produtos, bool[]> vlTuple in FlistaProdutos)
                {
                    if (vlTuple.Item1.Codigo == vlProduto.Codigo)
                    {
                        FlistaProdutos.Remove(vlTuple);
                        break;
                    }
                }
                lv_Produtos.Items.Remove(lv_Produtos.SelectedItems[0]);
                errorMSG.SetError(btn_Remover, null);
            }
            else
            {
                errorMSG.SetError(btn_Remover, "Erro ao remover fornecedor!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lv_Produtos.SelectedItems.Count > 0)
            {
                var vlProd = (Classes.produtos)lv_Produtos.SelectedItems[0].Tag;
                var vlItem = lv_Produtos.SelectedItems[0];
                lv_Produtos.Items.Remove(lv_Produtos.SelectedItems[0]);
                string[] item = default;

                foreach (Tuple<Classes.produtos, bool[]> vlTuple in FlistaProdutos)
                {
                    if (vlTuple.Item1.Codigo == vlProd.Codigo)
                    {
                        item = new string[] { vlProd.Produto,
                                                vlProd.CalculaPrecoVenda.ToString(),
                                                vlProd.PesoLiquido.ToString(),
                                                vlProd.Saldo.ToString(),
                                                vlProd.Codigo.ToString(),
                                                vlTuple.Item2[0].ToString().ToLower(),
                                                vlTuple.Item2[1].ToString().ToLower()};
                        break;
                    }
                }

                var lvItem = new ListViewItem(item);
                lvItem.Tag = vlProd.ThisProduto;
                lvItem.Name = vlProd.Produto;

                lv_MagentoProd.Items.Add(lvItem);
                btn_moverDir.Enabled = false;
                btn_moverEsq.Enabled = true;
            }
        }

        private void trocaLVAposAcao()
        {
            if (lv_MagentoProd.SelectedItems.Count > 0)
            {
                var vlProd = (Classes.produtos)lv_MagentoProd.SelectedItems[0].Tag;
                var vlItem = lv_MagentoProd.SelectedItems[0];
                lv_MagentoProd.Items.Remove(lv_MagentoProd.SelectedItems[0]);
                string[] item = default;

                foreach (Tuple<Classes.produtos, bool[]> vlTuple in FlistaProdutos)
                {
                    if (vlTuple.Item1.Codigo == vlProd.Codigo)
                    {
                        item = new string[] { vlProd.Produto,
                                                vlProd.CalculaPrecoVenda.ToString(),
                                                vlProd.PesoLiquido.ToString(),
                                                vlProd.Saldo.ToString(),
                                                vlProd.Codigo.ToString(),
                                                vlTuple.Item2[0].ToString().ToLower(),
                                                vlTuple.Item2[1].ToString().ToLower()};
                        break;
                    }
                }

                var lvItem = new ListViewItem(item);
                lvItem.Tag = vlProd.ThisProduto;
                lvItem.Name = vlProd.Produto;

                lv_Produtos.Items.Add(lvItem);
                btn_moverDir.Enabled = true;
                btn_moverEsq.Enabled = false;
            }
        }
        private void btn_moverEsq_Click(object sender, EventArgs e)
        {
            trocaLVAposAcao();
        }
        protected void convertImg(string pCaminho)
        {
            using (Bitmap bmp = new Bitmap(pCaminho))
                using (MemoryStream ms = new MemoryStream())
                {
                    bmp.Save(ms, bmp.RawFormat);
                    FimagemBase64 = Convert.ToBase64String(ms.ToArray());;
                }

        }

        private void btn_AddImg_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Escolha uma imagem .PNG";
            openFileDialog1.FileName = ".png";
            openFileDialog1.ShowDialog();
            if ((openFileDialog1.FileName != ".png" && openFileDialog1.FileName != "") &&
                 openFileDialog1.FileName.Contains(".png"))
            {
                convertImg(openFileDialog1.FileName);
                pictureBox1.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            FimagemBase64 = "";
            pictureBox1.Image = null;
        }
    }
}
