using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.API
{
    public class conexaoMagento
    {
        private string FumaURL;
        private string Fusername;
        private string Fpassword;
        private string FumToken;
        private DateTime FdateRequestToken;
        private DateTime FultProcesso;
        private string[] FstatusRequest;

        private const string URLDefault = "http://207.244.243.219";

        public conexaoMagento()
        {
            FumaURL   = URLDefault;
            Fusername = "admin";
            Fpassword = "admin123";
            FumToken  = default;
            FdateRequestToken = DateTime.Now;
            FultProcesso = DateTime.Now;
            FstatusRequest = new string[] { "Conexão", "OK" };
        }

        public conexaoMagento(string pURL, string pUsername, string pPassword)
        {
            FumaURL   = pURL;
            Fusername = pUsername;
            Fpassword = pPassword;
            FumToken  = default;
            FdateRequestToken = DateTime.Now;
            FultProcesso = DateTime.Now;
            FstatusRequest = new string[] { "Conexão", "OK" };
        }

        protected void SetDateRequest(int pSegundo = 0, int pMinuto = 0, int pHora = 0,
                                      int pDia= 0, int pMes = 0, int pAno=0, String pDate=default)
        {
            FdateRequestToken = DateTime.TryParse(pDate, out DateTime umaDate) ? umaDate 
                                                                               : DateTime.Now;
            FdateRequestToken = FdateRequestToken.AddYears(pAno);
            FdateRequestToken = FdateRequestToken.AddMonths(pMes);
            FdateRequestToken = FdateRequestToken.AddDays(pDia);
            FdateRequestToken = FdateRequestToken.AddHours(pHora);
            FdateRequestToken = FdateRequestToken.AddMinutes(pMinuto);
            FdateRequestToken = FdateRequestToken.AddSeconds(pSegundo);
        }

        public string URL
        { get => FumaURL; set => FumaURL = value; }
        public string[] StatusRequest
        { get => FstatusRequest; }
        public string Username
        { get => Fusername; set => Fpassword = value; }

        public string Password
        { get => Fpassword; set => Fpassword = value; }
        public string Token
        { get => TokenAcesso(); }
        public virtual string TokenAT(string pContentType)
        {
            return TokenAcesso(pContentType);
        }
        public void setUltProcesso(DateTime pData)
        {
            FultProcesso = pData;
        }
        public string UltDataAcesso
        { get => FultProcesso.ToString("hh:mm:ss"); }
        public string SetURLDefault
        { get => URLDefault; set => FumaURL = URLDefault; }
        protected virtual string TokenAcesso(string pContentType="application/json")
        {
            FultProcesso = DateTime.Now;
            if (FdateRequestToken <= DateTime.Now)
            {
                var vlMagento = new RestClient(URL + "/index.php/rest/V1/integration/admin/token");
                var vlRequisicao = new RestRequest(Method.POST);
                vlRequisicao.AddHeader("Content-Type", pContentType);
                vlRequisicao.AddParameter("application/json",
                                        "{\n\t\"username\": \"" + Username +
                                        "\",\n\t\"password\": \"" + Password + "\"\n}",
                                      ParameterType.RequestBody);

                IRestResponse vlResposta = vlMagento.Execute(vlRequisicao);
                FstatusRequest[1] = vlResposta.StatusCode.ToString();
                return formatRequestMsg(vlResposta);
            }
            return FumToken;
        }

        private string formatRequestMsg(IRestResponse pResposta)
        {
            string vlMsg = "Erro ao conectar-se ao Magento";

            if (pResposta.ErrorException != null)
                vlMsg += ":\n" + pResposta.ErrorException.Message;
            else if (pResposta.ErrorMessage != null) 
                vlMsg += ":\n" + pResposta.ErrorMessage.ToString().Replace("O nome remoto não pôde ser resolvido",
                                                                            "A URL informada não é válida");
            else if (pResposta.Content.ToString().Contains("Decoding error"))
                vlMsg += "\nUsuário e/ou senha inválidos!";
            else if (pResposta.Content.ToString().Contains("is required") ||
                        pResposta.Content.ToString().Contains("Request does not match any route"))
                vlMsg += "\nA URL informada possui parametros errados ou imcompletos!";

            if (vlMsg.Length <= 30)
            {
                SetDateRequest(pMinuto: 30);
                FumToken = pResposta.Content.ToString().Replace('"', ' ');
                FumToken = FumToken.Replace(" ", "");
                return FumToken;
            }
            SetDateRequest(pDate: DateTime.Now.ToString());
            return vlMsg;
        }

    }
}
