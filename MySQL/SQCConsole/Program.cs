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
            UserPlantUnitService service = new UserPlantUnitService();
            await service.Get(ConstantsHelper.Token, ConstantsHelper.AppVersion);
        }
    }
}
