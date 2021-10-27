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

        public frmConsultaCompras(Controllers.ctrlCompras pCtrlCompra)
        {
            InitializeComponent();
            btn_Excluir.Text = "Cancelar";
            btn_Alterar.Visible = false;
        }

        public override void SetFrmCad(Form pFrmCad)
        {
            frmCadCompra = (frmCadastros.frmCadastroCompras)pFrmCad;
        }

        private void btn_Inserir_Click(object sender, EventArgs e)
        {
            frmCadCompra.ShowDialog();
        }
    }
}
