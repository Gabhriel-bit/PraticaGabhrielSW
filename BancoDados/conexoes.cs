using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.BancoDados
{
    public class conexoes
    {
        SqlConnection conexao = new SqlConnection();

        public conexoes()
        {
            conexao.ConnectionString = @"Data Source=DESKTOP-CAPRT28\SQLEXPRESS;Initial Catalog=praticaDBGabhriel;Integrated Security=True";
        }

        public conexoes(string pConnString)
        {
            conexao.ConnectionString = @pConnString;
        }

        public conexoes(string pDataSource, string pInitCatalog, bool pIntegSecurity,
            string pUsername, string pPassword)
        {
            conexao.ConnectionString = $@"Data Source={pDataSource};
                                          Initial Catalog={pInitCatalog};
                                          Integrated Segurity={pIntegSecurity};
                                          User id={pUsername};
                                          Password={pPassword}";
        }

        public SqlConnection OpenConnection
        {
            get
            {
                if (conexao.State == System.Data.ConnectionState.Closed)
                {
                    conexao.Open();
                }
                return conexao;
            }
        }
        public void CloseConnection()
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }
    }
}
