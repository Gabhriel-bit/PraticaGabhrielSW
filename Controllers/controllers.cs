using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Controllers
{
    public class controllers
    {

        protected BancoDados.conexoes conexao;
        public NumberStyles vgEstilo = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
        public CultureInfo vgProv = new CultureInfo("fr-FR");
        public virtual string Inserir(object pObjeto)
        {
            return "";
        }
        public virtual string Alterar(object pObjeto)
        {
            return "";
        }
        public virtual string Excluir(object pObjeto)
        {
            return "";
        }
        public virtual DataTable Pesquisar(string pCampo, string pValor, out string pMsg)
        {
            pMsg = "";
            return null;
        }

        protected string ExecucaoComandQuery(string pComandText)
        {
            var conn = new SqlCommand();
            try
            {
                if (conn == null && conn.Transaction == null)
                { return "Erro ao conectar ao banco de dados"; }

                //Abre uma conexão com o banco e inicia uma transação
                conn.Connection = conexao.OpenConnection;
                conn.Transaction = conexao.OpenConnection.BeginTransaction();

                //vincula a string da query(inserir, alterar, excluir)
                conn.CommandText = pComandText;

                //execuda a string no banco de dados e encerra a transação
                conn.ExecuteNonQuery();
                conn.Transaction.Commit();
                conexao.CloseConnection();
                return "sucesso";
            }
            catch (SqlException e)
            {
                if (conn.Transaction != null)
                { conn.Transaction.Rollback(); }
                return e.Message;
            }
        }

        //integrar um erro para pesquisa no banco de dados
        protected DataTable ExecuteComandSearchQuery(string pComandText, out string pMsgErro)
        {
            var conn = new SqlCommand();
            string vlTitle = this.ToString().Replace("Projeto_ICI.Controllers.ctrl", "Controller ") + ":\n";
            string vlMsg = "";
            try
            {
                //Abre uma conexão com o banco e inicia uma transação
                vlMsg = vlTitle + "Erro ao conectar ao banco de dados (linhas: 74-77)";
                conn.Connection = conexao.OpenConnection;
                conn.Transaction = conexao.OpenConnection.BeginTransaction();

                conn.CommandText = pComandText;

                vlMsg = vlTitle + "Erro ao carregar tabelas (linhas: 80-82)";
                SqlDataAdapter adp = new SqlDataAdapter(conn);
                DataTable resultado = new DataTable();
                adp.Fill(resultado);

                vlMsg = vlTitle + "Erro ao finalizar execução no Bando de dados (linhas: 85-86)";
                conn.Transaction.Commit();
                conexao.CloseConnection();

                pMsgErro = "";
                return resultado;
            }
            catch (SqlException e)
            {
                if (conn.Transaction != null)
                { conn.Transaction.Rollback(); }
                pMsgErro = vlMsg + '\n' + e.Message;
                return new DataTable();
            }
        }
        public BancoDados.conexoes UmaConexao
        { get => conexao; set => conexao = value; }
    }
}
