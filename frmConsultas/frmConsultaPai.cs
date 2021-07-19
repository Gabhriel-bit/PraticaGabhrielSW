using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_ICI.frmConsultas
{
    public partial class frmConsultaPai : Projeto_ICI.formularioBase
    {
        public frmConsultaPai()
        {
            InitializeComponent();
            btn_Pesquisar.Image = umImgPesquisaSair;
        }
        /*
        /// <summary>
        /// Esconde os campos de pesquisa
        /// <list type="bullet">
        /// <item><description><para><em>Valor(int 1) Esconde somente o Campo 2 </em></para></description></item>
        /// <item><description><para><em>Valor(int 2) Esconde o Campo 2 e o Campo 3</em></para></description></item>
        /// <item><description><para><em>Qualquer outro valor não fará alterações</em></para></description></item>
        /// </list>
        /// <param name="pCampos"></param>
        /// </summary>
        */
        private void btn_Sair_Click(object sender, EventArgs e)
        {
            Sair();
            Close();
        }
        protected virtual void Sair()
        {

        }
        protected virtual void carregarDados(Controllers.controllers pCTRL)
        {
            this.dataGridView.DataSource = pCTRL.Pesquisar();
        }

        public string Btn_Sair
        { get => btn_Sair.Text; set => btn_Sair.Text = value; }

        private void frmConsultaPai_Resize(object sender, EventArgs e)
        {
            decimal larguraDGV = this.Width - 35;
            var pos = Math.Truncate((larguraDGV - 40) / 4);
            var X = int.Parse((pos + Math.Truncate(pos / 3)).ToString());
            btn_Alterar.Location = new Point(X, btn_Alterar.Location.Y);
            X = int.Parse((pos + Math.Truncate(pos * 2 - pos / 4)).ToString());
            btn_Excluir.Location = new Point(X, btn_Excluir.Location.Y);
        }

        private void btn_Pesquisar_MouseEnter(object sender, EventArgs e)
        {
            btn_Pesquisar.Image = umImgPesquisaEntrar;
        }

        private void btn_Pesquisar_MouseLeave(object sender, EventArgs e)
        {
            btn_Pesquisar.Image = umImgPesquisaSair;
        }
    }
}
