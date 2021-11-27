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
        public magentoProdutos(API.conexaoMagento pConexao)
        {
            umaConexao = pConexao;
            umProduto = new Classes.produtos();
        }
        public string Inserir(Classes.produtos pUmProduto)
        {
            var client = new RestClient(umaConexao.URL + "/index.php/rest/V1/products");
            var request = new RestRequest(Method.POST);
            var vlToken = umaConexao.Token;
            if (vlToken.Contains("Erro"))
                return vlToken;
            request.AddHeader("Authorization", $"Bearer {vlToken}");
            request.AddHeader("Content-Type", "application/json");
            request.AddCookie("private_content_version", "ff7e652208595133bce2da64d6d071d5");
            request.AddCookie("mage-messages",
                "%5B%7B%22type%22%3A%22error%22%2C%22text%22%3A%22Invalid%20Form%20Key." +
                "%20Please%20refresh%20the%20page.%22%7D%5D");
            request.AddParameter("application/json", "{\n\t\"product\": {\n    \"" +
                                "sku\": \"" + pUmProduto.Produto + "\",\n    \"" +
                                "name\": \"" + pUmProduto.Produto + "\",\n    \"" +
                                "attribute_set_id\": 4,\n    \"" +
                                "price\": " + pUmProduto.CalculaPrecoVenda.ToString().Replace('.', ',') + ",\n    \"" +
                                "status\": 1,\n    \"" +
                                "visibility\": 4,\n    \"" +
                                "weight\":" + pUmProduto.PesoLiquido.ToString().Replace('.', ',') + ",\n    \"" +
                                "extension_attributes\": {\n        \"" +
                                    "website_ids\": [\n            1\n        ],\n        \"" +
                                    "category_links\": [\n            {\n                \"" +
                                    "position\": 0,\n                \"" +
                                    "category_id\": \"4\"\n            }\n        ],\n        \"" +
                                    "stock_item\": {\n            \"" +
                                        "stock_id\": 1,\n            \"" +
                                        "qty\": " + pUmProduto.Saldo.ToString() + ",\n            \"" +
                                        "is_in_stock\": true\n        }\n    },\n    \"" +
                                "options\": [],\n    \"" +
                                "media_gallery_entries\": [],\n    \"" +
                                "custom_attributes\": [\n        {\n            \"" +
                                    "attribute_code\": \"options_container\",\n            \"" +
                                    "value\": \"container2\"\n        },\n        {\n            \"" +
                                    "attribute_code\": \"url_key\",\n            \"" +
                                    "value\": \"" + pUmProduto.Produto + "\"\n        },\n        {\n            \"" +
                                    "attribute_code\": \"tax_class_id\",\n            \"" +
                                    "value\": \"2\"\n        },\n        {\n            \"" +
                                    "attribute_code\": \"category_ids\",\n            \"" +
                                    "value\": [\n                \"4\"\n            ]\n        }\n    ]\n\t}\n}",
                                 ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            var vlMsg = anexarImagem(pUmProduto.Produto, colecaoImages.ImagemImpressora);
            return formatRespostaRequest(response, "'Inserção'") + '\n' + vlMsg;
        }
        public string Alterar(Classes.produtos pUmProduto)
        {
            var client = new RestClient(umaConexao.URL + "/index.php/rest/V1/products/" + pUmProduto.Produto);
            var request = new RestRequest(Method.PUT);
            var vlToken = umaConexao.Token;
            if (vlToken.Contains("Erro"))
                return vlToken;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {vlToken}");
            request.AddCookie("private_content_version", "ff7e652208595133bce2da64d6d071d5");
            request.AddCookie("mage-messages", "%5B%7B%22type%22%3A%22error%22%2C%22text%22%3A%22Invali" +
                                               "d%20Form%20Key.%20Please%20refresh%20the%20page.%22%7D%5D");

            request.AddParameter("application/json", "{\n\t\"product\": {\n    \"" +
                                "sku\": \"" + pUmProduto.Produto + "\",\n    \"" +
                                "name\": \"" + pUmProduto.Produto + "\",\n    \"" +
                                "attribute_set_id\": 4,\n    \"" +
                                "price\": " + pUmProduto.CalculaPrecoVenda.ToString().Replace('.', ',') + ",\n    \"" +
                                "status\": 1,\n    \"" +
                                "visibility\": 4,\n    \"" +
                                "weight\":" + pUmProduto.PesoLiquido.ToString().Replace('.', ',') + ",\n    \"" +
                                "extension_attributes\": {\n        \"" +
                                    "website_ids\": [\n            1\n        ],\n        \"" +
                                    "category_links\": [\n            {\n                \"" +
                                    "position\": 0,\n                \"" +
                                    "category_id\": \"4\"\n            }\n        ],\n        \"" +
                                    "stock_item\": {\n            \"" +
                                        "stock_id\": 1,\n            \"" +
                                        "qty\": " + pUmProduto.Saldo.ToString() + ",\n            \"" +
                                        "is_in_stock\": true\n        }\n    },\n    \"" +
                                "options\": [],\n    \"" +
                                "media_gallery_entries\": [],\n    \"" +
                                "custom_attributes\": [\n        {\n            \"" +
                                    "attribute_code\": \"options_container\",\n            \"" +
                                    "value\": \"container2\"\n        },\n        {\n            \"" +
                                    "attribute_code\": \"url_key\",\n            \"" +
                                    "value\": \"" + pUmProduto.Produto + "\"\n        },\n        {\n            \"" +
                                    "attribute_code\": \"tax_class_id\",\n            \"" +
                                    "value\": \"2\"\n        },\n        {\n            \"" +
                                    "attribute_code\": \"category_ids\",\n            \"" +
                                    "value\": [\n                \"4\"\n            ]\n        }\n    ]\n\t}\n}",
                                    ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return default;
        }
        public string Excluir(string pProduto)
        {
            var client = new RestClient(umaConexao.URL + "/index.php/rest/V1/products/" + pProduto);
            var request = new RestRequest(Method.DELETE);
            var vlToken = umaConexao.Token;
            if (vlToken.Contains("Erro"))
                return vlToken;
            request.AddHeader("Authorization", $"Bearer {vlToken}");
            request.AddCookie("private_content_version", "ff7e652208595133bce2da64d6d071d5");
            request.AddCookie("mage-messages", "%5B%7B%22type%22%3A%22error%22%2C%22text%22%3A" +
                              "%22Invalid%20Form%20Key.%20Please%20refresh%20the%20page.%22%7D%5D");
            IRestResponse response = client.Execute(request);
            return formatRespostaRequest(response, "Exclusão");
        }
        public Classes.produtos Pesquisar(string pCampo, string pValor, out string pMsg)
        {
            pMsg = default;



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
            return vlListaProd;
        }

        private string anexarImagem(string pProduto, string pImage)
        {
            var client = new RestClient(umaConexao.URL + "/index.php/rest/V1/products/" + pProduto + "/media");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {umaConexao.Token}");
            request.AddCookie("mage-messages", "%5B%7B%22type%22%3A%22error%22%2C%22text%22%3A%22" +
                                               "Invalid%20Form%20Key.%20Please%20refresh%20the%20page.%22%7D%5D");
            request.AddParameter("application/json", "{\n    \"" +
                                 "entry\": {\n        \"" +
                                 "media_type\": \"image\",\n        \"" +
                                 "label\": \"Image-" + pProduto + "\",\n        \"" +
                                 "position\": 1,\n        \"" +
                                 "disabled\": false,\n        \"" +
                                 "types\": [\n            \"" +
                                     "image\",\n            \"" +
                                     "small_image\",\n            \"" +
                                     "thumbnail\"\n        ],\n        \"" +
                                 "content\": {\n            \"" +
                                     "base64_encoded_data\": \"" + pImage + "\",\n            \"" +
                                     "type\": \"image/png\",\n            \"" +
                                     "name\": \"" + pProduto + ".png\"\n        }\n    }\n}",
                                 ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
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
