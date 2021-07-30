﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Controllers
{
    public class ctrlPaises : controllers
    {
        public const string camposSelect = "codigo, pais as país, ddi as DDI, moeda, sigla, " +
                                           "codigoUsu as usuário, " +
                                           "dataCad as cadastro, " +
                                           "dataUltAlt as ultima_Alteração";
        private DAOs.daoPaises umDaoPais;

        public ctrlPaises()
        {
            umDaoPais = new DAOs.daoPaises();
        }
        public ctrlPaises(BancoDados.conexoes pUmaConexa)
        {
            umDaoPais = new DAOs.daoPaises();
            UmaConexao = pUmaConexa;
        }

        public ctrlPaises(DAOs.daoPaises pUmaDaoPais)
        {
            umDaoPais = pUmaDaoPais;
        }

        public override string Inserir(object pObjeto)
        {
            var vlPais = (Classes.paises)pObjeto;
            var msg = ExecucaoComandQuery(umDaoPais.Inserir(pObjeto));
            if (msg == "sucesso")
            {
                return $"País '{vlPais.Pais}' inserido com {msg}!";
            }
            else if (msg.Contains("chave duplicada"))
            {
                return $"País '{vlPais.Pais}' já esta cadastrado!";
            }
            return msg;
        }

        public override string Alterar(object pObjeto)
        {
            var msg = ExecucaoComandQuery(umDaoPais.Alterar(pObjeto));
            if (msg == "sucesso")
            {
                var vlPais = (Classes.paises)pObjeto;
                return $"País '{vlPais.Pais}' alterado com {msg}!";
            }
            return msg;
        }

        public override string Excluir(object pObjeto)
        {
            var msg = ExecucaoComandQuery(umDaoPais.Excluir(pObjeto));
            if (msg == "sucesso")
            {
                var vlPais = (Classes.paises)pObjeto;
                return $"País '{vlPais.Pais}' excluido com {msg}!";
            }
            if (msg.Contains("DELETE conflitou"))
            {
                var vlPais = (Classes.paises)pObjeto;
                return $"Existe um registro que depende do país '{vlPais.Pais}'\n" +
                       $"Não foi possivel excluir o país!";
            }
            return msg;
        }
        public List<Classes.paises> PesquisarCollection(out string pMsg)
        {
            DataTable vlTabelaPaises =
                          ExecuteComandSearchQuery(
                                 umDaoPais.PesquisarToString("paises", camposSelect, "", ""), out string vlMsg);
            pMsg = vlMsg;
            if (vlTabelaPaises == null)
            {
                return null;
            }
            else
            {
                List<Classes.paises> lista = new List<Classes.paises>();
                foreach (DataRow row in vlTabelaPaises.Rows)
                {
                    var vlPais = new Classes.paises((int)row[0], (int)row[5],
                                                    (string)row[6], (string)row[7],
                                                    (string)row[1], (string)row[3],
                                                    (string)row[2], (string)row[4]);
                    lista.Add(vlPais);
                }
                return lista;
            }
        }

        public override DataTable Pesquisar(string pCampo, string pValor, out string pMsg)
        {
            var vlTable = ExecuteComandSearchQuery(
                          umDaoPais.PesquisarToString("paises", camposSelect, pCampo, pValor), out string vlMsg);
            pMsg = vlMsg;
            return vlTable;
        }
    }
}
