using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.DAOs
{
    public class daoVendas:daos
    {
        public const string nameTable = "vendas";
        public daoVendas()
        { }

        public override string Inserir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Venda está nula!";
            }
            else
            {
                Classes.vendas vlCompra = (Classes.vendas)pObj;
                return InserirToString(nameTable,
                                       vlCompra.arrayStringCampos(),
                                       vlCompra.arrayStringValores(), true);
            }
        }

        public string InserirItens(List<Classes.itensVenda> listaItens, string pPK)
        {
            if (listaItens == null)
            {
                return "Erro: Lista de itens está nula!";
            }
            else
            {
                string insertion = "";
                foreach (Classes.itensVenda vlItem in listaItens)
                {
                    insertion += InserirToString("produtos_venda",
                                                 vlItem.arrayStringCampos(),
                                                 vlItem.arrayStringValores(), true)
                                                 + '\n';
                }
                return insertion;
            }
        }

        public override string Alterar(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Venda está nula!";
            }
            else
            {
                Classes.vendas vlCompra = (Classes.vendas)pObj;
                string alteration = $"UPDATE {nameTable} SET ";
                for (int i = 4; i <= vlCompra.arrayStringValores().Length - 1; i++)
                {
                    if ((int.TryParse(vlCompra.arrayStringValores()[i], out int _) ||
                        decimal.TryParse(vlCompra.arrayStringValores()[i], out decimal _)) &&
                        !vlCompra.arrayStringValores()[i].Contains("+"))
                    {
                        alteration += $"{vlCompra.arrayStringCampos()[i]} = " +
                            $"{vlCompra.arrayStringValores()[i].Replace(',', '.')}, ";
                    }
                    else
                        alteration += $"{vlCompra.arrayStringCampos()[i]} = " +
                                      $"'{vlCompra.arrayStringValores()[i]}', ";
                }
                alteration = alteration.Remove(alteration.Length - 2) +
                              $" WHERE {vlCompra.arrayStringCampos()[0]} = {vlCompra.arrayStringValores()[0]}" +
                              $" AND {vlCompra.arrayStringCampos()[1]} = {vlCompra.arrayStringValores()[1]}" +
                              $" AND {vlCompra.arrayStringCampos()[2]} = {vlCompra.arrayStringValores()[2]}" +
                              $" AND {vlCompra.arrayStringCampos()[3]} = {vlCompra.arrayStringValores()[3]};";

                return alteration;
            }
        }

        public string AlterarItens(List<Classes.itensVenda> listaItens, string pPK)
        {
            if (listaItens == null)
            {
                return "Erro: Lista de itens está nula!";
            }
            else
            {
                string insertion = "\n" + ExcluirItens(pPK);
                foreach (Classes.itensVenda vlItem in listaItens)
                {
                    insertion += InserirToString("produtos_venda",
                                                 vlItem.arrayStringCampos(),
                                                 vlItem.arrayStringValores(), true)
                                                 + '\n';
                }
                return insertion;
            }
        }

        public override string Excluir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Venda está nula!";
            }
            else
            {
                var vlPK = ((Classes.vendas)pObj).PK;
                var excluir = $"UPDATE {nameTable} SET disponivel = 0 where " +
                              $"modelo = '{vlPK.Split(';')[0]}' AND " +
                              $"serie = '{vlPK.Split(';')[1]}' AND " +
                              $"numero_nf = '{vlPK.Split(';')[2]}' AND " +
                              $"codigoCliente = {vlPK.Split(';')[3]};";

                return excluir;
            }
        }

        public string ExcluirItens(List<Classes.itensVenda> listaItens)
        {
            if (listaItens == null)
            {
                return "Erro: Lista de itens está nula!";
            }
            else
            {
                string insertion = "";
                foreach (Classes.itensVenda vlItem in listaItens)
                    insertion += ExcluirItens(vlItem.PK);

                return insertion;
            }
        }
        public string ExcluirItens(string pPK)
        {
            if (pPK == "")
            {
                return "Erro:Chave de busca inválida!";
            }
            else
            {
                string insertion = "delete from produtos_venda where " +
                                    $"modelo = '{pPK.Split(';')[0]}' AND " +
                                    $"serie = '{pPK.Split(';')[1]}' AND " +
                                    $"numero_nf = '{pPK.Split(';')[2]}' AND " +
                                    $"codigoCliente = {pPK.Split(';')[3]} AND" +
                                    $"codigoProd = {pPK.Split(';')[4]};\n";
                return insertion;
            }
        }
    }
}
