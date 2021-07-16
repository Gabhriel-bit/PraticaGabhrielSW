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
        public virtual void SetFrmCad(Form pFrmCad)
        {

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
    }
}
