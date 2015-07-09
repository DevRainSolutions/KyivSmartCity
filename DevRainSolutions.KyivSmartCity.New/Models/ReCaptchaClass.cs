using System.Collections.Generic;
using Newtonsoft.Json;

namespace DevRainSolutions.KyivSmartCity.New.Models
{
    public class ReCaptchaClass
    {
        public static string Validate(string encodedResponse)
        {
            var client = new System.Net.WebClient();

            

            var GoogleReply = client.DownloadString(
                string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}",
                    Recaptcha.SecretKey, encodedResponse));

            var captchaResponse = JsonConvert.DeserializeObject<ReCaptchaClass>(GoogleReply);

            return captchaResponse.Success;
        }

        [JsonProperty("success")]
        public string Success
        {
            get { return m_Success; }
            set { m_Success = value; }
        }

        private string m_Success;
        [JsonProperty("error-codes")]
        public List<string> ErrorCodes
        {
            get { return m_ErrorCodes; }
            set { m_ErrorCodes = value; }
        }


        private List<string> m_ErrorCodes;
    }
}