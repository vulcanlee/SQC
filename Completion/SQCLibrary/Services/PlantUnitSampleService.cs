using Newtonsoft.Json;
using SQCLibrary.Dtos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SQCLibrary.Services
{
    public class PlantUnitSampleService
    {
        public async Task<PlantUnitSampleDto> GetAsync(string accessToken, string appVersion,
            string plant, string plantUnit)
        {
            PlantUnitSampleDto result = new PlantUnitSampleDto();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://appcloud.fpcetg.com.tw/factoryCloud/");
            Dictionary<string, string> formDataDictionary = new Dictionary<string, string>()
            {
                {"accessToken",accessToken },
                {nameof(appVersion), appVersion },
                {nameof(plant), plant },
                {nameof(plantUnit), plantUnit },
            };
            var formData = new FormUrlEncodedContent(formDataDictionary);
            HttpResponseMessage response = await client.PostAsync("api/LIMS/plantUnitSample", formData);
            string content = await response.Content.ReadAsStringAsync();
            result = JsonConvert.DeserializeObject<PlantUnitSampleDto>(content);
            return result;
        }
    }
}
