using Newtonsoft.Json;
using SQCLibrary.Dots;
using SQCLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SQCLibrary.Services
{
    public class UserPlantUnitService
    {
        public async Task<UserPlantUnitDto> GetAsync(string accessToken, string appVersion)
        {
            UserPlantUnitDto result = new UserPlantUnitDto();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://appcloud.fpcetg.com.tw/factoryCloud/");

            Dictionary<string, string> formDataDictionary = new Dictionary<string, string>();
            formDataDictionary.Add("accessToken", accessToken);
            formDataDictionary.Add(nameof(appVersion), appVersion);

            FormUrlEncodedContent formData = new FormUrlEncodedContent(formDataDictionary);
            HttpResponseMessage response = await client.PostAsync("api/LIMS/userPlantUnit", formData);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<UserPlantUnitDto>(content);
            }

            return result;
        }
    }
}
