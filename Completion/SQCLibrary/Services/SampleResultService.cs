using Newtonsoft.Json;
using SQCLibrary.Dtos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SQCLibrary.Services
{
    public class SampleResultService
    {
        public async Task<SampleResultDto> GetAsync(string accessToken, string appVersion,
            string sampleID)
        {
            SampleResultDto result = new SampleResultDto();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://appcloud.fpcetg.com.tw/factoryCloud/");
            Dictionary<string, string> formDataDictionary = new Dictionary<string, string>()
            {
                {"accessToken",accessToken },
                {nameof(appVersion), appVersion },
                {nameof(sampleID), sampleID },
            };
            var formData = new FormUrlEncodedContent(formDataDictionary);
            HttpResponseMessage response = await client.PostAsync("api/LIMS/sampleResult", formData);
            string content = await response.Content.ReadAsStringAsync();
            result = JsonConvert.DeserializeObject<SampleResultDto>(content);
            return result;
        }
    }
}
