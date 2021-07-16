using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_ICI.frmAcesso
{
    public partial class frmLogin : Projeto_ICI.formularioBase
    {
        private const string chave = "65858479827390656879";
        private Classes.pai confirmacao;
        public frmLogin()
        {
            InitializeComponent();
        }
        public override void ConhecaOBJ(object pOBJ)
        {
            confirmacao = (Classes.pai)pOBJ;
        }

        private void btn_Conectar_Click(object sender, EventArgs e)
        {
            confirmacao.DataCad = chave;
            Close();
        }

        private void btn_Sair_Click(object sender, EventArgs e)
        {
            Close();
        }
        public bool ConfirmacaoChave(string pChave)
        {
            return confirmacaoChave(pChave);
        }
        public static bool confirmacaoChave(string pChave)
        {
            if (pChave == chave)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
