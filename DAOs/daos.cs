using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.DAOs
{
    public class daos
    {
        public virtual string InserirToString(string pTabela, string[] pCampos, string[] pValores, bool pAllVal = false)
        {
            //adiciona os campos das tabelas
            string insert = $"insert into {pTabela} (";
            for (int i = (pAllVal ? 0 : 1); i <= pCampos.Length - 2; i++)
            {
                insert += pCampos[i] + ", ";
            }
            //remove o espaço e a virgula final e adiciona a proxima sequencia de ações
            insert += pCampos[pCampos.Length - 1] + ") values (";

            try
            {
                for (int i = (pAllVal ? 0 : 1); i <= pValores.Length - 1; i++)
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
            }
            catch (Exception e)
            {
                string msg = e.Message;
                throw;
            }
            //insere os valores na sequencia dos campos especificados

            //remove o espaço e a virgula final e adiciona ); para encerrar a inserção
            insert = insert.Remove(insert.Length - 2) + ");";

            return insert;
        }

        public virtual string Inserir(object pObj)
        {
            return "";
        }
        public virtual string Inserir(List<object> pObj)
        {
            return "";
        }
        public string AlterarToString(string pTabela, string[] pCampos, string[] pValores)
        {
            //adiciona os campos e os valores do registro
            string alteration = $"UPDATE {pTabela} SET ";
            for (int i = 1; i <= pValores.Length - 1; i++)
            {
                if ((int.TryParse(pValores[i], out int _) ||
                    decimal.TryParse(pValores[i], out decimal _)) &&
                    !pValores[i].Contains("+"))
                {
                    alteration += $"{pCampos[i]} = " +
                        $"{pValores[i].Replace(',', '.')}, ";
                }
                else
                    alteration += $"{pCampos[i]} = '{pValores[i]}', ";
            }
            //remove o espaço e a virgula final e adiciona a condição WHERE
            //e o campo identificador (codigo)
            alteration = alteration.Remove(alteration.Length - 2) +
                          $" WHERE {pCampos[0]} = {pValores[0]}; ";

            return alteration;
        }

        public virtual string Alterar(object pObj)
        {
            return "";
        }

        public string ExcluirToString(string pTabela, string pCampo, string pValor)
        {
            var excluir = $"UPDATE {pTabela} SET disponivel = 0 where {pCampo} = " +
                          $"{pValor.Replace(',', '.')};";
            return excluir;
        }
        public string ExcluirToString(string pTabela, string[] pCampos, string[] pValores)
        {
            var excluir = $"UPDATE {pTabela} SET disponivel = 0 where ";
            for (int i = 1; i <= pValores.Length - 1; i++)
            {
                if ((int.TryParse(pValores[i], out int _) ||
                    decimal.TryParse(pValores[i], out decimal _)) &&
                    !pValores[i].Contains("+"))
                {
                    excluir += $"{pCampos[i]} = " +
                        $"{pValores[i].Replace(',', '.')} AND ";
                }
                else
                    excluir += $"{pCampos[i]} = '{pValores[i]}' AND ";
            }
            return excluir.Remove(excluir.Length - 5) + ";";
        }
        public virtual string Excluir(object pObj)
        {
            return "";
        }
        public virtual string Excluir(List<object> pObj)
        {
            return "";
        }
        public virtual string Pesquisar(object pObj)
        {
            return "";
        }

        public string PesquisarToString(string pNameTable, string pCamposSelecionados,
            string pCampo, string pValor, string[] pRefCampos = default, bool pValorIgual = false)
        {
            string vlNomeDao = (pNameTable.Split(',').Length == 1)
                               ? vlNomeDao = pNameTable
                               : ToString().Replace("Projeto_ICI.DAOs.dao", "").ToLower();

            string search = $"select {pCamposSelecionados} from {pNameTable} " +
                            (pValorIgual ? " where " : $"where {vlNomeDao}.disponivel != 0 ");

            if (pCampo != "")
            {
                if (int.TryParse(pValor, out int _) ||
                    decimal.TryParse(pValor, out decimal _))
                    search += (pValorIgual ? "" : " AND ") + $"{pCampo}={pValor.Replace(',', '.')}";
                else
                {
                    if (pValorIgual)
                        search += (pValorIgual ? "" : " AND ") + $" {pCampo} = '{pValor}'";
                    else
                        search += (pValorIgual ? "" : " AND ") + $" {pCampo} like '%{pValor}%'";
                }
            }
            if (pRefCampos != null)
            {
                search += " AND ";

                foreach (string campo in pRefCampos)
                {
                    search += campo + " AND ";
                }
                search = search.Remove(search.Length - 5) + ";";
            }
            return search;
        }

        public string PesquisarToString(string pNameTable, string pCamposSelecionados,
                      string[] pCampos, string[] pValores, string[] pRefCampos = default, bool pValorIgual = false)
        {
            string vlNomeDao = (pNameTable.Split(',').Length == 1)
                               ? vlNomeDao = pNameTable
                               : ToString().Replace("Projeto_ICI.DAOs.dao", "").ToLower();

            string search = $"select {pCamposSelecionados} from {pNameTable} " +
                            (pValorIgual ? " where " : $"where {vlNomeDao}.disponivel != 0 ");
            search += (search.Contains("disponivel") ? "AND " : "");

            for (int i = 0; i<=pCampos.Count() -1; i++)
            {
                if (int.TryParse(pValores[i], out int _) ||
                    decimal.TryParse(pValores[i], out decimal _))
                    search += $"{pCampos[i]}={pValores[i].Replace(',', '.')} AND ";
                else
                {
                    if (pValorIgual)
                        search +=  $"{pCampos[i]} = '{pValores[i]}' AND ";
                    else
                        search += $"{pCampos[i]} like '%{pValores[i]}%' AND ";
                }
            }
            search = search.Remove(search.Length - 5) + ';';
            if (pRefCampos != null)
            {
                search = search.Remove(search.Length - 1) + " AND ";

                foreach (string campo in pRefCampos)
                {
                    search += campo + " AND ";
                }
                search = search.Remove(search.Length - 5) + ";";
            }
            return search;
        }
    }
}
