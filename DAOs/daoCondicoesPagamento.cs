using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.DAOs
{
    public class daoCondicoesPagamento : daos
    {
        public const string nameTable = "condicoesPagamento";
        public daoCondicoesPagamento()
        { }

        public string InserirToString(string pTabela, string[] pCampos, string[] pValores, string pNomeCondPag)
        {

            string insert = $"insert into {pTabela} (";
            for (int i = 0; i <= pCampos.Length - 2; i++)
            {
                insert += pCampos[i] + ", ";
            }
            insert += pCampos[pCampos.Length - 1] + ") values ((" +
            $"select codigo from condicoesPagamento where condicaoPagamento = '{pNomeCondPag}'), ";

            for (int i = 0; i <= pValores.Length - 1; i++)
            {
                if ((int.TryParse(pValores[i], out int _) ||
                    decimal.TryParse(pValores[i], out decimal _)) &&
                    !pValores[i].Contains("+"))
                {
                    insert += $"{pValores[i].Replace(',', '.')}, ";
                }
                else
                    insert += $"'{pValores[i]}', ";
            }
            insert = insert.Remove(insert.Length - 2) + ");";

            return insert;
        }

        public override string Inserir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Condição de pagamento está nula!";
            }
            else
            {
                Classes.condicoesPagamento vlCondPag = (Classes.condicoesPagamento)pObj;
                return InserirToString(nameTable, vlCondPag.arrayStringCampos(),
                                       vlCondPag.arryStringValores());
            }
        }

        public string InserirParcelas(List<Classes.parcelasCondPag> listaParcelas, string pNomaCondPag)
        {
            if (listaParcelas == null)
            {
                return "Erro: Lista de parcelas está nula!";
            }
            else
            {
                string insertion = "";
                foreach (Classes.parcelasCondPag vlParcela in listaParcelas)
                {
                    insertion += InserirToString("parcelasCondicaoPagamento",
                                                 vlParcela.arrayStringCampos(),
                                                 vlParcela.arrayStringValores(),
                                                 pNomaCondPag)
                                                 + '\n';
                }
                return insertion;
            }
        }

        public override string Alterar(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Cidade está nula!";
            }
            else
            {
                Classes.condicoesPagamento vlCondPag = (Classes.condicoesPagamento)pObj;
                return AlterarToString(nameTable, vlCondPag.arrayStringCampos(),
                                       vlCondPag.arryStringValores());
            }
        }

        public string AlterarParcelas(List<Classes.parcelasCondPag> listaParcelas, string pNomaCondPag)
        {
            if (listaParcelas == null)
            {
                return "Erro: Lista de parcelas está nula!";
            }
            else
            {
                string insertion = "\n" + ExcluirParcelas(listaParcelas[0].CodigoCondPag);
                foreach (Classes.parcelasCondPag vlParcela in listaParcelas)
                {
                    insertion += InserirToString("parcelasCondicaoPagamento",
                                                 vlParcela.arrayStringCampos(),
                                                 vlParcela.arrayStringValores(),
                                                 pNomaCondPag)
                                                 + '\n';
                }
                return insertion;
            }
        }

        public override string Excluir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Cidade está nula!";
            }
            else
            {
                Classes.condicoesPagamento vlCondPag = (Classes.condicoesPagamento)pObj;
                return ExcluirToString(nameTable, "codigo", vlCondPag.Codigo.ToString());
            }
        }

        public string ExcluirParcelas(List<Classes.parcelasCondPag> listaParcelas)
        {
            if (listaParcelas == null)
            {
                return "Erro: Lista de parcelas está nula!";
            }
            else
            {
                string insertion = "";
                foreach (Classes.parcelasCondPag vlParcela in listaParcelas)
                {
                    insertion += "delete from parcelasCondicaoPagamento where " +
                    $"codigoCondPag = {vlParcela.CodigoCondPag} AND " +
                    $"numero = {vlParcela.Numero};\n";
                }
                return insertion;
            }
        }
        public string ExcluirParcelas(int pCodigoCondPag)
        {
            if (pCodigoCondPag == 0)
            {
                return "Erro: Código da condição de pagamento inválido!";
            }
            else
            {
                string insertion = "delete from parcelasCondicaoPagamento where " +
                                    $"codigoCondPag = {pCodigoCondPag};\n";
                return insertion;
            }
        }
    }
}
