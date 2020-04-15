using Newtonsoft.Json;
using SQCLibrary.Dots;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SQCLibrary.Services
{
    public class PlantUnitSampleService
    {
        public async Task<PlantUnitSampleDto> PostAsync(string accessToken, string appVersion,
            string plant, string plantUnit)
        {
            PlantUnitSampleDto result = new PlantUnitSampleDto();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://appcloud.fpcetg.com.tw/factoryCloud/");
            Dictionary<string, string> formDataDictionary = new Dictionary<string, string>()
            {
                {nameof(accessToken), accessToken },
                {nameof(appVersion), appVersion },
                {nameof(appVersion), plant },
                {nameof(appVersion), plantUnit },
            };
            FormUrlEncodedContent formData = new FormUrlEncodedContent(formDataDictionary);
            var response = await client.PostAsync("api/LIMS/plantUnitSample", formData);
            string content = await response.Content.ReadAsStringAsync();
            result = JsonConvert.DeserializeObject<PlantUnitSampleDto>(content);

            return result;
        }
    }
}
