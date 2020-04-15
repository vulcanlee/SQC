using SQCLibrary.Helpers;
using SQCLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQCConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //UserPlantUnitService service = new UserPlantUnitService();
            //await service.GetAsync(ConstantsHelper.Token, ConstantsHelper.AppVersion);
            PlantUnitSampleService service = new PlantUnitSampleService();
            var result = await service.PostAsync(ConstantsHelper.Token, ConstantsHelper.AppVersion,
                "CFP", "CFP-SEMI");
        }
    }
}
