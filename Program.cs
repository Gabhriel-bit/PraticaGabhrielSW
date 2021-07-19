using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_ICI
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// <para>Necessita um usuário registrado</para>
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //var autorizacao = new Classes.pai();
            //var login = new frmAcesso.frmLogin();
            //login.ConhecaOBJ((object)autorizacao);
            //login.ShowDialog();
            //if (login.ConfirmacaoChave(autorizacao.DataCad))
            //{
            //try
            //{
                Application.Run(new Gerente());
           //}
           //catch
           // { }
            //}
        }
    }
}
