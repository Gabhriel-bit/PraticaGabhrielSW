using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.DAOs
{
    public class daoProdutos : daos
    {
        public const string nameTable = "produtos";
        public daoProdutos()
        { }

        public string InserirToString(string pTabela, string[] pCampos, string[] pValores, string pNomeProd)
        {

            string insert = $"insert into {pTabela} (";
            for (int i = 0; i <= pCampos.Length - 2; i++)
            {
                insert += pCampos[i] + ", ";
            }
            insert += pCampos[pCampos.Length - 1] + ") values ((" +
            $"select codigo from produtos where produto = '{pNomeProd}'), ";

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
                return "Erro: Produto está nulo!";
            }
            else
            {
                Classes.produtos vlProduto = (Classes.produtos)pObj;
                return InserirToString(nameTable, vlProduto.arrayStringCampos(),
                                       vlProduto.arrayStringValores());
            }
        }

        public string InserirProdForn(List<Classes.fornecedores> listaProdForn, string pNomeProd)
        {
            if (listaProdForn == null)
            {
                return "Erro: Produto está nulo!";
            }
            else
            {
                string insertion = "";
                string[] campo = { "codigoProduto", "codigoFornecedor" }, valor = { "" };
                foreach (Classes.fornecedores vlForn in listaProdForn)
                {
                    valor[0] = vlForn.Codigo.ToString();
                    insertion += InserirToString("produto_fornecedor",
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
                return "Erro: Produto está nula!";
            }
            else
            {
                Classes.produtos vlProduto = (Classes.produtos)pObj;
                return AlterarToString(nameTable, vlProduto.arrayStringCampos(),
                                       vlProduto.arrayStringValores());
            }
        }

        public string AlterarProdForn(List<Classes.fornecedores> listaFornecedores, int pCodigoProd)
        {
            if (listaFornecedores == null)
            {
                return "Erro: Produto está nulo!";
            }
            else
            {
                string insertion = "\n" + "delete from produto_fornecedor where " +
                                         $"codigoProduto = {pCodigoProd};\n";
                string[] campo = { "codigoProduto", "codigoFornecedor" },
                         valor = { pCodigoProd.ToString(), ""};
                foreach (Classes.fornecedores vlForn in listaFornecedores)
                {
                    valor[1] = vlForn.Codigo.ToString();
                    insertion += InserirToString("produto_fornecedor",
                                                 campo, valor,
                                                 true) + '\n';
                }
                return insertion;
            }
        }

        public override string Excluir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Produdo está nula!";
            }
            else
            {
                Classes.produtos vlProduto = (Classes.produtos)pObj;
                return ExcluirToString(nameTable, "codigo", vlProduto.Codigo.ToString());
            }
        }

        public string ExcluirProdForn(List<Classes.fornecedores> listaFornecedores, int pCodigoProd)
        {
            if (listaFornecedores == null)
            {
                return "Erro: Lista de parcelas está nula!";
            }
            else
            {
                string insertion = "";
                foreach (Classes.fornecedores vlForn in listaFornecedores)
                {
                    insertion += "delete from produto_fornecedor where " +
                    $"codigoFornecedor = {vlForn.Codigo} AND " +
                    $"codigoProduto = {pCodigoProd};\n";
                }
                return insertion;
            }
        }
    }
}
