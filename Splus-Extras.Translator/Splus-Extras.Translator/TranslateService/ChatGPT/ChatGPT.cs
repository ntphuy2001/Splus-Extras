using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using System.Linq;
using System.Security.Cryptography;
using RestSharp;
using Microsoft.CSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;


namespace Splus_Extras.Translator
{
    public class ChatGPT : ITranslationService
    {
        private readonly HttpClient _client;
        private readonly string _endPoint;
        private readonly TranslationServiceSingleton _translator = TranslationServiceSingleton.Instance;

        public ChatGPT(string token)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            _endPoint = "https://api.openai.com/v1/chat/completions";
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_translator.Token}");
        }

        async Task<List<string>> ITranslationService.Translate(List<string> listResources)
        {
            string prompt = "";
            for (int i = 0; i < listResources.Count; i++)
            {
                if (i == listResources.Count - 1)
                    prompt += $"'{listResources[i]}'";
                else
                    prompt += $"'{listResources[i]}', ";
            }
            //Basic request body to test the connection
            var requestBody = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "system", content = $"You are a helpful assistant. Translate this paragraphs list bellow, sentence by sentence, in context with the content of the entire given list, from '{_translator.SourceLanguage}' to '{_translator.TargetLanguage}'. The result should be only a string of all translated text in the given list, the results concatenated with the string '>>--<<'." },
                    new { role = "user", content = $"[{prompt}]" }
               },
                //max_tokens = 100,
                //temperature = 0.5
            };

            string jsonString = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");


            var response = await this._client.PostAsync(_endPoint, content);

            string responseContent = await response.Content.ReadAsStringAsync();

            var jsonResponse = JObject.Parse(responseContent);

            string messagResponse = jsonResponse["choices"][0]["message"]["content"].Value<string>();

            return new List<string>(messagResponse.Split(new string[] { ">>--<<" }, StringSplitOptions.None));
        }
    }
}
