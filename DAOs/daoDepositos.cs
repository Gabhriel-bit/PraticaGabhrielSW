using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.DAOs
{
    public class daoDepositos : daos
    {
        public const string nameTable = "depositos";
        public daoDepositos()
        { }

        public string InserirToString(string pTabela, string[] pCampos, string[] pValores, string pNomeProd)
        {

            string insert = $"insert into {pTabela} (";
            for (int i = 0; i <= pCampos.Length - 2; i++)
            {
                insert += pCampos[i] + ", ";
            }
            insert += pCampos[pCampos.Length - 1] + ") values ((" +
            $"select codigo from depositos where deposito = '{pNomeProd}'), ";

            for (int i = 0; i <= pValores.Length - 1; i++)
            {
                insert += $"{pValores[i].Replace(',', '.')}, ";
            }
            insert = insert.Remove(insert.Length - 2) + ");";

            return insert;
        }

        public override string Inserir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Deposito está nulo!";
            }
            else
            {
                Classes.depositos vlProduto = (Classes.depositos)pObj;
                return InserirToString(nameTable, vlProduto.arrayStringCampos(),
                                       vlProduto.arryStringValores());
            }
        }

        public string InserirDepProd(List<Classes.produtos> listaDepProd, string pNomeProd)
        {
            if (listaDepProd == null)
            {
                return "Erro: Deposito está nulo!";
            }
            else
            {
                string insertion = "";
                string[] campo = { "codigoDeposito", "codigoProduto" }, valor = { "" };
                foreach (Classes.produtos vlProduto in listaDepProd)
                {
                    valor[0] = vlProduto.Codigo.ToString();
                    insertion += InserirToString("deposito_produto",
                                                 campo, valor,
                                                 pNomeProd)
                                                 + '\n';
                }
                return insertion;
            }
        }

        public override string Alterar(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Deposito está nula!";
            }
            else
            {
                Classes.depositos vlProduto = (Classes.depositos)pObj;
                return AlterarToString(nameTable, vlProduto.arrayStringCampos(),
                                       vlProduto.arryStringValores());
            }
        }

        public string AlterarDepProd(List<Classes.produtos> listaProdutos, int pCodigoDep)
        {
            if (listaProdutos == null)
            {
                return "Erro: Deposito está nulo!";
            }
            else
            {
                string insertion = "\n" + "delete from deposito_produto where " +
                                  $"codigoDeposito = {pCodigoDep};\n";
                string[] campo = { "codigoDeposito", "codigoProduto" },
                         valor = { pCodigoDep.ToString() };
                foreach (Classes.produtos vlProduto in listaProdutos)
                {
                    valor[1] = vlProduto.Codigo.ToString();
                    insertion += AlterarToString("deposito_produto",
                                                 campo, valor
                                                 ) + '\n';
                }
                return insertion;
            }
        }

        public override string Excluir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Deposito está nula!";
            }
            else
            {
                Classes.depositos vlProduto = (Classes.depositos)pObj;
                return ExcluirToString(nameTable, "codigo", vlProduto.Codigo.ToString());
            }
        }

        public string ExcluirProdForn(List<Classes.produtos> listaProdutos, int pCodigoDep)
        {
            if (listaProdutos == null)
            {
                return "Erro: Lista de produtos está nula!";
            }
            else
            {
                string insertion = "";
                foreach (Classes.produtos vlProduto in listaProdutos)
                {
                    insertion += "delete from deposito_produto where " +
                    $"codigoProduto = {vlProduto.Codigo} AND " +
                    $"codigoDeposito = {pCodigoDep};\n";
                }
                return insertion;
            }
        }
    }
}
