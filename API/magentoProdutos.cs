using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.API
{
    public class magentoProdutos
    {
        private API.conexaoMagento umaConexao;
        private Classes.produtos umProduto;
        private bool[] Fconferencias;
        public magentoProdutos(API.conexaoMagento pConexao)
        {
            umaConexao = pConexao;
            umProduto = new Classes.produtos();
            Fconferencias = new bool[] { true, true };
        }
        public bool[] Conferencias
        { get => Fconferencias; set => Fconferencias = value; }
        public string Inserir(Classes.produtos pUmProduto, out string[] pProcStstus,string pImage = "")
        {
            var client = new RestClient(umaConexao.URL + "/index.php/rest/V1/products");
            var request = new RestRequest(Method.POST);
            var vlToken = umaConexao.Token;
            pProcStstus = new string[] { "Inserção", "error" };
            if (vlToken.Contains("Erro"))
                return vlToken;
            request.AddHeader("Authorization", $"Bearer {vlToken}");
            request.AddHeader("Content-Type", "application/json");
            request.AddCookie("private_content_version", "ff7e652208595133bce2da64d6d071d5");
            request.AddCookie("mage-messages",
                "%5B%7B%22type%22%3A%22error%22%2C%22text%22%3A%22Invalid%20Form%20Key." +
                "%20Please%20refresh%20the%20page.%22%7D%5D");
            request.AddParameter("application/json", "{\"product\":{" +
                                                        "\"sku\":\"" + pUmProduto.Produto.Replace(" ", "-") + "\"," +
                                                        "\"name\": \"" + pUmProduto.Produto + "\"," +
                                                        "\"attribute_set_id\": 4," +
                                                        "\"price\":" + pUmProduto.CalculaPrecoVenda.ToString().Replace(",", ".") + "," +
                                                        "\"status\": 1," +
                                                        $"\"visibility\": {(Conferencias[0] ? 4 : 0)}," +
                                                        "\"weight\":" + pUmProduto.PesoLiquido.ToString().Replace(",", ".") + "," +
                                                        "\"type_id\": \"simple\"," +
                                                        "\"extension_attributes\":{" +
                                                            "\"website_ids\": [ 1 ]," +
                                                            "\"category_links\":[{" +
                                                                "\"position\": 0," +
                                                                "\"category_id\": \"3\"}]," +
                                                            "\"stock_item\":{" +
                                                                "\"stock_id\": 1," +
                                                                "\"qty\": " + pUmProduto.Saldo.ToString() + "," +
                                                                "\"is_in_stock\": " + (Conferencias[1] ? "true" : "false") + "}}," +
                                                        "\"custom_attributes\":[{" +
                                                            "\"attribute_code\": \"url_key\"," +
                                                                "\"value\": \"" + pUmProduto.Produto + "\"},{" +
                                                            "\"attribute_code\":\"tax_class_id\"," +
                                                                "\"value\": \"2\"},{" +
                                                            "\"attribute_code\": \"category_ids\"," +
                                                                "\"value\": [\"4\"]}]}}",
                                  ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var vlMsg = anexarImagem(pUmProduto.Produto, pImage);
            pProcStstus[1] = response.StatusCode.ToString();
            umaConexao.setUltProcesso(DateTime.Now);
            return formatRespostaRequest(response, "'Inserção'") + '\n' + vlMsg;
        }
        public string Alterar(Classes.produtos pUmProduto, out string[] pProcStstus)
        {
            var client = new RestClient(umaConexao.URL + "/index.php/rest/V1/products/" + pUmProduto.Produto);
            var request = new RestRequest(Method.PUT);
            var vlToken = umaConexao.Token;
            pProcStstus = new string[] { "Alteração", "error" };
            if (vlToken.Contains("Erro"))
                return vlToken;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {vlToken}");
            request.AddCookie("private_content_version", "ff7e652208595133bce2da64d6d071d5");
            request.AddCookie("mage-messages", "%5B%7B%22type%22%3A%22error%22%2C%22text%22%3A%22Invali" +
                                               "d%20Form%20Key.%20Please%20refresh%20the%20page.%22%7D%5D");

            request.AddParameter("application/json", "{\"product\":{" +
                                                        "\"sku\":\"" + pUmProduto.Produto.Replace(" ", "-") + "\"," +
                                                        "\"name\": \"" + pUmProduto.Produto + "\"," +
                                                        "\"attribute_set_id\": 4," +
                                                        "\"price\":" + pUmProduto.CalculaPrecoVenda.ToString().Replace(",", ".") + "," +
                                                        "\"status\": 1," +
                                                        $"\"visibility\": {(Conferencias[0] ? 4 : 0)}," +
                                                        "\"weight\":" + pUmProduto.PesoLiquido.ToString().Replace(",", ".") + "," +
                                                        "\"type_id\": \"simple\"," +
                                                        "\"extension_attributes\":{" +
                                                            "\"website_ids\": [ 1 ]," +
                                                            "\"category_links\":[{" +
                                                                "\"position\": 0," +
                                                                "\"category_id\": \"3\"}]," +
                                                            "\"stock_item\":{" +
                                                                "\"stock_id\": 1," +
                                                                "\"qty\": " + pUmProduto.Saldo.ToString() + "," +
                                                                "\"is_in_stock\": " + (Conferencias[1] ? "true" : "false") + "}}," +
                                                        "\"custom_attributes\":[{" +
                                                            "\"attribute_code\": \"url_key\"," +
                                                                "\"value\": \"" + pUmProduto.Produto + "\"},{" +
                                                            "\"attribute_code\":\"tax_class_id\"," +
                                                                "\"value\": \"2\"},{" +
                                                            "\"attribute_code\": \"category_ids\"," +
                                                                "\"value\": [\"4\"]}]}}",
                                  ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            pProcStstus[1] = response.StatusCode.ToString();
            umaConexao.setUltProcesso(DateTime.Now);
            return formatRespostaRequest(response, "'Alteração'");
        }
        public string Excluir(string pProduto, out string[] pProcStstus)
        {
            var client = new RestClient(umaConexao.URL + "/index.php/rest/V1/products/" + pProduto.Replace(" ", "-"));
            var request = new RestRequest(Method.DELETE);
            pProcStstus = new string[] { "Exclusão", "error" };
            var vlToken = umaConexao.Token;
            if (vlToken.Contains("Erro"))
                return vlToken;
            request.AddHeader("Authorization", $"Bearer {vlToken}");
            request.AddCookie("private_content_version", "ff7e652208595133bce2da64d6d071d5");
            request.AddCookie("mage-messages", "%5B%7B%22type%22%3A%22error%22%2C%22text%22%3A" +
                              "%22Invalid%20Form%20Key.%20Please%20refresh%20the%20page.%22%7D%5D");
            IRestResponse response = client.Execute(request);
            pProcStstus[1] = response.StatusCode.ToString();
            umaConexao.setUltProcesso(DateTime.Now);
            return formatRespostaRequest(response, "Exclusão");
        }
        public Classes.produtos Pesquisar(string pCampo, string pValor, out string pMsg)
        {
            pMsg = default;


            umaConexao.setUltProcesso(DateTime.Now);
            return default;
        }
        public List<Classes.produtos> Pesquisar()
        {
            var vlListaProd = new List<Classes.produtos>();
            var client = new RestClient(umaConexao.URL + "/index.php/rest/V1/products?searchCriteria=%5B%5D");
            var request = new RestRequest(Method.GET);
            var vlToken = umaConexao.Token;
            if (vlToken.Contains("Erro"))
                return new List<Classes.produtos>();
            request.AddHeader("Authorization", $"Bearer {vlToken}");
            request.AddCookie("private_content_version", "ff7e652208595133bce2da64d6d071d5");
            request.AddCookie("mage-messages", "%5B%7B%22type%22%3A%22error%22%2C%22text%22%3A%22Invalid%20Form%20Key.%20Please%20refresh%20the%20page.%22%7D%5D");
            IRestResponse response = client.Execute(request);
            umaConexao.setUltProcesso(DateTime.Now);
            return vlListaProd;
        }

        private string anexarImagem(string pProduto, string pImage)
        {
            var client = new RestClient(umaConexao.URL + "/index.php/rest/V1/products/" + pProduto.Replace(" ", "-") + "/media");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {umaConexao.Token}");
            request.AddCookie("mage-messages", "%5B%7B%22type%22%3A%22error%22%2C%22text%22%3A%22" +
                                               "Invalid%20Form%20Key.%20Please%20refresh%20the%20page.%22%7D%5D");
            request.AddParameter("application/json", "{" +
                                 "\"entry\": {" +
                                 "\"media_type\": \"image\"," +
                                 "\"label\": \"Image-" + pProduto + "\"," +
                                 "\"position\": 1," +
                                 "\"disabled\": false," +
                                 "\"types\": [\"image\", \"small_image\", \"thumbnail\"]," +
                                 "\"content\": {" +
                                     "\"base64_encoded_data\": \"" + pImage + "\"," +
                                     "\"type\": \"image/png\"," +
                                     "\"name\": \"" + pProduto + ".png\"}}}",
                                 ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            umaConexao.setUltProcesso(DateTime.Now);
            return formatRespostaRequest(response, "'Anexar Imagem'");
        }

        private string formatRespostaRequest(IRestResponse pResponse, string pNomeProces)
        {
            var vlMsg = "Erro ao realizar Operação " + pNomeProces;
            if (pResponse.StatusDescription.ToString() == "OK")
                vlMsg = vlMsg.Replace("Erro ao realizar ", "") + " realizada com sucesso!";
            else if (pResponse.ErrorException != null)
                vlMsg += ":\n" + pResponse.ErrorException.Message;
            else if (pResponse.ErrorMessage != null)
                vlMsg += ":\n" + pResponse.ErrorMessage.ToString().Replace("O nome remoto não pôde ser resolvido",
                                                                            "A URL informada não é válida");
            else if (pResponse.Content.ToString().Contains("Decoding error"))
                vlMsg += "\nUsuário e/ou senha inválidos!";
            else if (pResponse.Content.ToString().Contains("is required") ||
                        pResponse.Content.ToString().Contains("Request does not match any route"))
                vlMsg += "\nA URL informada possui parametros errados ou imcompletos!";
            return vlMsg;
        }
    }
}
