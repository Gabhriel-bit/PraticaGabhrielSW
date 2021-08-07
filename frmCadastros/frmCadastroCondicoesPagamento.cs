using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;


namespace Projeto_ICI.frmCadastros
{
    public partial class frmCadastroCondicoesPagamento : Projeto_ICI.frmCadastros.frmCadastroPai
    {
        private frmConsultas.frmConsultasFormasPagamento frmConsFormPag;
        private Controllers.ctrlCondicoesPagamento umCtrlCondPag;
        private List<Classes.formasPagamento> listaFormasPag;
        private List<Classes.parcelasCondPag> listaParcelas;
        private Classes.formasPagamento umaFormaPag;
        private Classes.parcelasCondPag umaParcelaCondPag;

        public frmCadastroCondicoesPagamento()
        {
            InitializeComponent();
            frmConsFormPag = new frmConsultas.frmConsultasFormasPagamento();
            umCtrlCondPag = new Controllers.ctrlCondicoesPagamento();
            listaFormasPag = new List<Classes.formasPagamento>();
            listaParcelas = new List<Classes.parcelasCondPag>();
            umaFormaPag = new Classes.formasPagamento();
            umaParcelaCondPag = new Classes.parcelasCondPag();
        }
        public frmCadastroCondicoesPagamento(BancoDados.conexoes pUmaConexao)
        {
            InitializeComponent();
            umCtrlCondPag = new Controllers.ctrlCondicoesPagamento(pUmaConexao);
            listaFormasPag = umCtrlCondPag.CTRLFormaPagamento.PesquisarCollection(out string vlMsg);
            showErrorMsg(vlMsg);

            listaParcelas = new List<Classes.parcelasCondPag>();
            umaFormaPag = new Classes.formasPagamento();
            umaParcelaCondPag = new Classes.parcelasCondPag();

            btn_PesquisarFormPagParc.Image = umImgPesquisaSair;
        }
        public override void SetFrmCons(Form pFrmCad)
        {
            frmConsFormPag = (frmConsultas.frmConsultasFormasPagamento)pFrmCad;
        }
        public override void CarregarTxtBox(object pUmObjeto)
        {
            base.CarregarTxtBox(pUmObjeto);
            var vlCondPag = (Classes.condicoesPagamento)pUmObjeto;
            txtb_CondicaoPag.Text = vlCondPag.CondicaoPag;
            txtb_TotalParcelas.Text = vlCondPag.TotalParcelas.ToString();
            txtb_TaxaJuros.Text = vlCondPag.TaxaJuros.ToString();
            txtb_Multa.Text = vlCondPag.Multa.ToString();
            txtb_Desconto.Text = vlCondPag.Desconto.ToString();
            listToLv(vlCondPag.ListaParcelas);
            recalcularParcelas();
        }

        public override void DesBloqTxTBox()
        {
            txtb_CondicaoPag.Enabled = true;
            txtb_Desconto.Enabled = true;
            txtb_Multa.Enabled = true;
            txtb_Dias.Enabled = true;
            txtb_TaxaJuros.Enabled = true;
            //txtb_TotalParcelas.Enabled = true;
            lv_Parcelas.Enabled = true;
            txtb_CodigoFormPag.Enabled = true;
            txtb_FormaPag.Enabled = true;
            txtb_Porcentagem.Enabled = true;
            btn_Adicionar.Enabled = true;
            btn_Alterar.Enabled = true;
            btn_Remover.Enabled = true;
            btn_Limpar.Enabled = true;
        }
        public override void BloquearTxtBox()
        {
            base.BloquearTxtBox();
            txtb_CondicaoPag.Enabled = false;
            txtb_Desconto.Enabled = false;
            txtb_Multa.Enabled = false;
            txtb_Dias.Enabled = false;
            txtb_TaxaJuros.Enabled = false;
            //txtb_TotalParcelas.Enabled = false;
            lv_Parcelas.Enabled = false;
            txtb_CodigoFormPag.Enabled = false;
            txtb_FormaPag.Enabled = false;
            txtb_Porcentagem.Enabled = false;
            btn_Adicionar.Enabled = false;
            btn_Alterar.Enabled = false;
            btn_Remover.Enabled = false;
            btn_Limpar.Enabled = false;
        }
        public override void ClearTxTBox()
        {
            base.ClearTxTBox();
            txtb_CondicaoPag.Clear();
            txtb_Desconto.Clear();
            txtb_Multa.Clear();
            txtb_Dias.Clear();
            txtb_TaxaJuros.Clear();
            txtb_TotalParcelas.Clear();
            txtb_CodigoFormPag.Clear();
            txtb_FormaPag.Clear();
            txtb_Porcentagem.Clear();
            lv_Parcelas.Items.Clear();
            recalcularParcelas();
        }
        private void CalcularParcelas(bool clearLV)
        {
            //calcula automaticamente as parcelas
            if (!ValidacaoIntPositivo(txtb_Dias.Text, false))
            {
                txtb_Dias.Focus();
            }
            else
            {
                decimal entrada = txtb_Porcentagem.Text == "" ? 0 :
                    Math.Round(decimal.Parse(txtb_Porcentagem.Text, vgEstilo, vgProv), 2);
                string[] porcParcela = CalcularPorcParcelasTxT(int.Parse(txtb_TotalParcelas.Text), entrada.ToString());
                int dias = 0;
                if (clearLV)
                {
                    lv_Parcelas.Items.Clear();
                }
                for (int i = txtb_Porcentagem.Text == "" ? 1 : 2;
                    i <= int.Parse(txtb_TotalParcelas.Text); i++)
                {
                    dias += int.Parse(txtb_Dias.Text);
                    var parcela = new string[] { i.ToString(),
                                                 dias.ToString(),
                                                 porcParcela[i-1] + '%',
                                                 txtb_FormaPag.Text
                                               };
                    var lvItem = new ListViewItem(parcela);
                    lvItem.Tag = parcela;
                    lv_Parcelas.Items.Add(lvItem);
                }
                recalcularParcelas();
            }

        }
        private List<Classes.parcelasCondPag> lvToList()
        {
            var vlListaParcelas = new List<Classes.parcelasCondPag>();
            if (lv_Parcelas.Items.Count > 0)
            {
                for (int i = 0; i <= lv_Parcelas.Items.Count - 1; i++)
                {
                    var item = (Classes.parcelasCondPag)lv_Parcelas.Items[i].Tag;
                    var vlParcela = new Classes.parcelasCondPag(txtb_Codigo.Text == "" ? 0 : int.Parse(txtb_Codigo.Text),
                                                              item.Numero,
                                                              item.Dias,
                                                              item.Porcentagem);
                    vlParcela.UmaFormaPag.ThisFormPag = item.UmaFormaPag;
                    pesquisarFormaPagamento(vlParcela.UmaFormaPag);
                    vlListaParcelas.Add(vlParcela);
                }
                return vlListaParcelas;
            }
            else
            {
                showErrorMsg("Erro ao criar lista de parcelas!");
                return null;
            }
        }

        private void listToLv(List<Classes.parcelasCondPag> pListaParcelas)
        {
            if (pListaParcelas != null && pListaParcelas.Count > 0)
            {
                lv_Parcelas.Items.Clear();
                foreach (Classes.parcelasCondPag vlParcela in pListaParcelas)
                {
                    var vlStrParcela = vlParcela.arrayStringValores(true);
                    var lvItem = new ListViewItem(vlStrParcela);
                    lvItem.Tag = vlParcela.ThisParcelasCondPag;
                    lv_Parcelas.Items.Add(lvItem);
                }
            }
            else
            {
                showErrorMsg("Erro ao carregar lista de parcelas!");
            }
        }

        private void pesquisarFormaPagamento(Classes.formasPagamento pParcela)
        {
            if (listaFormasPag != null)
            {
                foreach (Classes.formasPagamento vlParcela in listaFormasPag)
                {
                    if (vlParcela.FormaPag == pParcela.FormaPag)
                    {
                        pParcela.ThisFormPag = vlParcela;
                        break;
                    }
                }
            }
        }

        private void txtb_TotalParcelas_Validating(object sender, CancelEventArgs e)
        {
            if (ValidacaoIntPositivo(txtb_TotalParcelas.Text, false))
            {
                errorMSG.SetError(lbl_TotalParcelas, null);
                e.Cancel = false;
            }
            else
            {
                errorMSG.SetError(lbl_TotalParcelas,
                        "Valor (" + txtb_TotalParcelas.Text + ") inválido!\n" +
                        "O número de parcelas deve ser inteiro e positivo maior que 0 (zero)!");
                txtb_TotalParcelas.Text = "1";
                e.Cancel = closing;
            }
        }

        private bool confereTotalPorc()
        {
            if (!ValidacaoDoubleMoeda(txtb_Porcentagem.Text))
            {
                errorMSG.SetError(lbl_Porcentagem, "Insira um valor inteiro positivo com" +
                                   "até 4 casas decimais  \nExempo: 25,2365");
                return true;
            }
            else
            {
                decimal totalPorc = decimal.Parse(lbl_TotalPorc.Text.Remove(lbl_TotalPorc.Text.Length - 1), vgEstilo, vgProv);
                decimal totalMaisNovaParcela = decimal.Parse(txtb_Porcentagem.Text.Replace(".", ","), vgEstilo, vgProv) + totalPorc;
                if (lbl_TotalPorc.Text == "100%")
                {
                    errorMSG.SetError(lbl_Porcentagem, "Limite de parcelas já alcançou 100% !");
                    return true;
                }
                else if (totalMaisNovaParcela > 100)
                {
                    errorMSG.SetError(lbl_Porcentagem, "Porcentagem da parcela inválida!\n" +
                           $"O valor '{txtb_Porcentagem.Text}%' excederá o valor de 100%\n" +
                           $"O valor máximo que pode ser inserido é '{100 - totalPorc}%'");
                    txtb_Porcentagem.Text = (100 - totalPorc).ToString();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void btn_Adicionar_Click(object sender, EventArgs e)
        {
            if (!ValidacaoIntPositivo(txtb_Dias.Text, true))
            {
                errorMSG.SetError(lbl_Dias, "Valor inválido!\nInsira um número positivo sem casas decimais");
                txtb_Dias.Focus();
            }
            else if (confereTotalPorc())
            {
                errorMSG.SetError(lbl_Dias, null);
                txtb_Porcentagem.Focus();
            }
            else if (!ValidacaoNome(txtb_FormaPag.Text, 2, true))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_FormaPag, "Forma de pagamento inválida!");
                txtb_FormaPag.Focus();
            }
            else
            {
                errorMSG.Clear();
                /*if (umaParcelaCondPag.Numero != 0 && lv_Parcelas.Items.Count > 0)
                {
                    umaParcelaCondPag.Dias = int.Parse(txtb_Dias.Text);
                    umaParcelaCondPag.Porcentagem = decimal.Parse(txtb_Porcentagem.Text.Replace(".", ","), vgEstilo, vgProv);
                    umaParcelaCondPag.UmaFormaPag.Codigo = int.Parse(txtb_CodigoFormPag.Text);
                    umaParcelaCondPag.UmaFormaPag.FormaPag = txtb_FormaPag.Text;
                    txtb_Dias.Clear();
                    txtb_Porcentagem.Clear();
                    txtb_CodigoFormPag.Clear();
                    txtb_FormaPag.Clear();
                    recalcularParcelas(umaParcelaCondPag.ThisParcelasCondPag);
                }
                else
                {*/
                var vlParcela = new
                    Classes.parcelasCondPag(0,
                                            (lv_Parcelas.Items.Count + 1),
                                            int.Parse(txtb_Dias.Text),
                                            decimal.Parse(txtb_Porcentagem.Text.Replace(".", ","), vgEstilo, vgProv));
                vlParcela.UmaFormaPag.FormaPag = txtb_FormaPag.Text;
                pesquisarFormaPagamento(vlParcela.UmaFormaPag);
                var parcela = vlParcela.arrayStringValores(true);
                var lvItem = new ListViewItem(parcela);
                lvItem.Tag = vlParcela;
                lv_Parcelas.Items.Add(lvItem);
                txtb_Dias.Clear();
                txtb_Porcentagem.Clear();
                txtb_CodigoFormPag.Clear();
                txtb_FormaPag.Clear();
                recalcularParcelas();
                //}
            }
        }

        private void btn_Limpar_Click(object sender, EventArgs e)
        {
            lv_Parcelas.Items.Clear();
            txtb_Porcentagem.Clear();
            txtb_Dias.Clear();
            txtb_CodigoFormPag.Clear();
            txtb_FormaPag.Clear();
            txtb_TotalParcelas.Clear();
            lbl_TotalDias.Text = "0";
            lbl_TotalPorc.Text = "0%";
            controleAutomatico(false);
        }

        private void btn_Remover_Click(object sender, EventArgs e)
        {
            controleAutomatico(false);
            if (lv_Parcelas.Items.Count == 0)
            {
                errorMSG.SetError(btn_Remover, "Não ha parcelas cadastradas!");
            }
            else
            {
                errorMSG.SetError(btn_Remover, null);
                if (lv_Parcelas.SelectedItems.Count != 0)
                {
                    errorMSG.SetError(btn_Remover, null);
                    foreach (ListViewItem item in lv_Parcelas.SelectedItems)
                    {
                        lv_Parcelas.Items.Remove(item);
                    }
                    recalcularParcelas();
                }
                else
                {
                    errorMSG.SetError(btn_Remover, "Selecione um item da lista!");
                }
            }

        }
        private void recalcularParcelas(Classes.parcelasCondPag pParcela = null)
        {
            if (lv_Parcelas.Items.Count != 0)
            {
                ListView lista = ClonarListView(lv_Parcelas);
                lv_Parcelas.Items.Clear();
                int numero = 1;
                decimal somaPorc = 0;
                int somadias = 0;
                foreach (ListViewItem item in lista.Items)
                {
                    if (pParcela != null && pParcela.Numero == numero)
                    {
                        numero++;
                        somadias += pParcela.Dias;
                        somaPorc += pParcela.Porcentagem;
                        var vlLiClone = new ListViewItem(pParcela.arrayStringValores(true));
                        vlLiClone.Tag = pParcela.ThisParcelasCondPag;
                        lv_Parcelas.Items.Add(vlLiClone);
                    }
                    var vlObj = (Classes.parcelasCondPag)item.Tag;
                    vlObj.Numero = numero;
                    somadias += vlObj.Dias;
                    somaPorc += vlObj.Porcentagem;
                    string[] linha = vlObj.arrayStringValores(true);
                    var vlClone = new ListViewItem(linha);
                    vlClone.Tag = vlObj.ThisParcelasCondPag;
                    lv_Parcelas.Items.Add(vlClone);
                    numero++;
                }
                if (txtb_TotalParcelas.Enabled == true)
                {
                    lbl_TotalDias.Text =
                        ((Classes.parcelasCondPag)lista.Items[lista.Items.Count - 1].Tag).Dias.ToString();
                }
                else
                { lbl_TotalDias.Text = somadias.ToString(); }
                txtb_TotalParcelas.Text = lv_Parcelas.Items.Count.ToString();
                lbl_TotalPorc.Text = somaPorc.ToString() + "%";

            }
            else
            {
                lbl_TotalDias.Text = "0";
                txtb_TotalParcelas.Text = "0";
                lbl_TotalPorc.Text = "0%";
            }
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            controleAutomatico(false);
            if (lv_Parcelas.Items.Count == 0)
            {
                errorMSG.SetError(btn_Alterar, "Não ha parcelas cadastradas!");
            }
            else
            {
                if (lv_Parcelas.SelectedItems.Count == 0)
                {
                    errorMSG.SetError(btn_Alterar, "Selecione um item da lista!");
                }
                else if (lv_Parcelas.SelectedItems[0] != lv_Parcelas.Items[lv_Parcelas.Items.Count - 1])
                {
                    errorMSG.Clear();
                    errorMSG.SetError(btn_Alterar, "Só é possivel alterar a ultima parcela!");
                }
                else
                {
                    errorMSG.SetError(btn_Alterar, null);
                    var vlSelctParcela = lv_Parcelas.SelectedItems[0];
                    umaParcelaCondPag.ThisParcelasCondPag =
                        (Classes.parcelasCondPag)vlSelctParcela.Tag;
                    txtb_Dias.Text = umaParcelaCondPag.Dias.ToString();
                    txtb_Porcentagem.Text = umaParcelaCondPag.Porcentagem.ToString();
                    txtb_CodigoFormPag.Text = umaParcelaCondPag.UmaFormaPag.Codigo.ToString();
                    txtb_FormaPag.Text = umaParcelaCondPag.UmaFormaPag.FormaPag;

                    lv_Parcelas.Items.Remove(vlSelctParcela);
                    recalcularParcelas();
                }
            }
        }

        private void controleAutomatico(bool pDestravar)
        {
            if (pDestravar)
            {
                txtb_TotalParcelas.Enabled = true;
                lbl_TotalParcelas.Text += '*';
                txtb_TotalParcelas.Validating += txtb_TotalParcelas_Validating;

                lbl_Dias.Text += '*';
                txtb_Dias.Validating += txtb_Dias_Validating;

                txtb_Porcentagem.Enabled = false;

                txtb_TotalParcelas.Focus();
            }
            else
            {
                txtb_TotalParcelas.Enabled = false;
                lbl_TotalParcelas.Text = lbl_TotalParcelas.Text.Replace("*", "");
                txtb_TotalParcelas.Validating -= txtb_TotalParcelas_Validating;

                lbl_Dias.Text = lbl_Dias.Text.Replace("*", "");
                txtb_Dias.Validating -= txtb_Dias_Validating;

                txtb_Porcentagem.Enabled = true;
            }
        }

        private void btn_AutoParc_Click(object sender, EventArgs e)
        {
            if (txtb_TotalParcelas.Enabled == false)
            {
                controleAutomatico(true);
            }
            else
            {
                if (ValidacaoIntPositivo(txtb_Dias.Text, true))
                { CalcularParcelas(true); }
                else
                { txtb_Dias.Focus(); }
            }
        }
        private void txtb_CondicaoPag_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtb_CondicaoPag.Text))
            {
                errorMSG.SetError(lbl_CondicaoPag, "Condição de pagamento inválida!");
                e.Cancel = closing;
            }
            else
            {
                errorMSG.Clear();
                e.Cancel = false;
            }
        }
        private void txtb_Dias_Validating(object sender, CancelEventArgs e)
        {
            if (ValidacaoIntPositivo(txtb_Dias.Text, false))
            {
                errorMSG.SetError(lbl_Dias, null);
            }
            else
            {
                errorMSG.SetError(lbl_Dias, "Insira os dias a serem pagos das parcelas");
            }
        }
        private void txtb_TaxaJuros_Validating(object sender, CancelEventArgs e)
        {
            if (decimal.TryParse(txtb_TaxaJuros.Text, out decimal _))
            {
                errorMSG.SetError(lbl_TaxaJuros, "Taxa de juros inválida");
                e.Cancel = closing;
            }
            else
            {
                errorMSG.SetError(lbl_TaxaJuros, null);
                e.Cancel = false;
            }
        }
        private void btn_PesquisarFormPagParc_Click(object sender, EventArgs e)
        {
            var nomeBtn = frmConsFormPag.Btn_Sair;
            frmConsFormPag.Btn_Sair = "Selecionar";
            frmConsFormPag.ConhecaOBJ(umaFormaPag);
            frmConsFormPag.ShowDialog();
            frmConsFormPag.Btn_Sair = nomeBtn;
            if (umaFormaPag.Codigo != 0)
            {
                txtb_CodigoFormPag.Text = umaFormaPag.Codigo.ToString();
                txtb_FormaPag.Text = umaFormaPag.FormaPag;
            }
            listaFormasPag = umCtrlCondPag.CTRLFormaPagamento.PesquisarCollection(out string vlMsg);
            showErrorMsg(vlMsg);
        }

        private void txtb_CodigoFormPag_TextChanged(object sender, EventArgs e)
        {
            if (txtb_CodigoFormPag.Text == "")
            {
                txtb_FormaPag.Clear();
            }
            else
            {
                if (int.TryParse(txtb_CodigoFormPag.Text, out int i))
                {
                    bool vlFind = false;
                    foreach (Classes.formasPagamento vlFormPag in listaFormasPag)
                    {
                        if (vlFormPag.Codigo == i)
                        {
                            txtb_FormaPag.Text = vlFormPag.FormaPag;
                            umaFormaPag = vlFormPag.ThisFormPag;
                            vlFind = true;
                        }
                    }
                    if (!vlFind)
                    { txtb_FormaPag.Clear(); }
                }
            }
        }
        /// <summary>
        /// Clona os item da lista passada como parâmetro, para uma nova instância "ListView" e a retorna
        /// <list type="bullet">
        /// <item><description><para><em>pLista{item1, item2, item3} -> return{item1, item2, item3} </em></para></description></item>
        /// <item><description><para><em>O parâmetro "pLista" não é desalocado da memória</em></para></description></item>
        /// </list>
        /// <param name="pLista"></param>
        /// </summary>
        public ListView ClonarListView(ListView pLista)
        {
            if (pLista.Items.Count != 0)
            {
                var lista = new ListView();
                foreach (ListViewItem item in pLista.Items)
                {
                    var vlClone = (ListViewItem)item.Clone();
                    if (item.Tag.ToString().Contains("parcelas"))
                    {
                        vlClone.Tag = ((Classes.parcelasCondPag)item.Tag).ThisParcelasCondPag;
                    }
                    else
                    {
                        var vlString = (string[])item.Tag;
                        vlClone.Tag = new Classes.parcelasCondPag(0,
                                                                  int.Parse(vlString[0]),
                                                                  int.Parse(vlString[1]),
                                                                  decimal.Parse(vlString[2].Replace("%", ""), vgEstilo, vgProv));
                        ((Classes.parcelasCondPag)vlClone.Tag).UmaFormaPag.FormaPag = vlString[3];
                        if (vlString[3] != "")
                        {
                            pesquisarFormaPagamento(
                                ((Classes.parcelasCondPag)vlClone.Tag).UmaFormaPag);
                        }
                    }
                    lista.Items.Add(vlClone);
                }
                return lista;
            }
            else
            {
                return null;
            }
        }

        private void btn_Cadastro_Click(object sender, EventArgs e)
        {
            closing = true;
            if (string.IsNullOrEmpty(txtb_CondicaoPag.Text))
            {
                errorMSG.SetError(lbl_CondicaoPag, "o campo 'Condição de pagamento' é obrigatório!");
                txtb_CondicaoPag.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_TaxaJuros.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_TaxaJuros, "O campo 'Taxa juros' é obrigatório!");
                txtb_TaxaJuros.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_Multa.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_Multa, "O campo 'Multa' é obrigatório!");
                txtb_Multa.Focus();
            }
            else if (lbl_TotalPorc.Text != "100%" && lbl_TotalPorc.Text != "100,0000%")
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_Dias, "É necessário inserir ao menos uma parcela!");
                txtb_Dias.Focus();
                txtb_Dias.Text = "0";
                txtb_Porcentagem.Text = "100";
            }
            else
            {
                var vlCondicaoPag = new Classes.condicoesPagamento(txtb_Codigo.Text == "" ? 0 : int.Parse(txtb_Codigo.Text),
                                                                   txtb_CodigoUsu.Text == "" ? 0 : int.Parse(txtb_CodigoUsu.Text),
                                                                   txtb_DataCadastro.Text,
                                                                   txtb_DataUltAlt.Text,
                                                                   txtb_CondicaoPag.Text,
                                                                   int.Parse(txtb_TotalParcelas.Text),
                                                                   decimal.Parse(txtb_TaxaJuros.Text.Replace(".", ","), vgEstilo, vgProv),
                                                                   decimal.Parse(txtb_Multa.Text.Replace(".", ","), vgEstilo, vgProv),
                                                                   decimal.Parse(txtb_Desconto.Text.Replace(".", ","), vgEstilo, vgProv));
                vlCondicaoPag.ListaParcelas = lvToList();
                ObjToDataBase(vlCondicaoPag, umCtrlCondPag);
            }
        }

        private void txtb_Multa_Validating(object sender, CancelEventArgs e)
        {
            if (decimal.TryParse(txtb_Multa.Text, out decimal _))
            {
                errorMSG.Clear();
                e.Cancel = false;
            }
            else
            {
                errorMSG.SetError(lbl_Multa, "Multa inválida!");
                e.Cancel = closing;
            }
        }

        private void txtb_Dias_Validating_1(object sender, CancelEventArgs e)
        {
            if (ValidacaoIntPositivo(txtb_Dias.Text, true))
            {
                if (lv_Parcelas.Items.Count == 0)
                {
                    errorMSG.Clear();
                    e.Cancel = false;
                }
                else
                {
                    var vlUltParc = (Classes.parcelasCondPag)lv_Parcelas.Items[lv_Parcelas.Items.Count - 1].Tag;
                    if (int.Parse(txtb_Dias.Text) <= vlUltParc.Dias)
                    {
                        errorMSG.SetError(lbl_Dias, "O numero de dias não pode ser igual ou inferior\na ultima parcela!");
                        txtb_Dias.Text = (vlUltParc.Dias + 7).ToString();
                        e.Cancel = closing;
                    }
                    else
                    {
                        errorMSG.Clear();
                        e.Cancel = false;
                    }
                }
            }
            else
            {
                errorMSG.SetError(lbl_Dias, "O número de dias deve ser positivo!");
                e.Cancel = closing;
            }
        }

        private void txtb_CodigoFormPag_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacaoCodigo(txtb_CodigoFormPag, e);
        }

        private void txtb_Desconto_Validating(object sender, CancelEventArgs e)
        {
            if (decimal.TryParse(txtb_Desconto.Text, out decimal _))
            {
                errorMSG.Clear();
                e.Cancel = false;
            }
            else
            {
                errorMSG.SetError(lbl_Multa, "Multa inválida!");
                e.Cancel = closing;
            }
        }

        private void btn_PesquisarFormPagParc_MouseEnter(object sender, EventArgs e)
        {
            btn_PesquisarFormPagParc.Image = umImgPesquisaEntrar;
        }

        private void btn_PesquisarFormPagParc_MouseLeave(object sender, EventArgs e)
        {
            btn_PesquisarFormPagParc.Image = umImgPesquisaSair;
        }
    }
}
