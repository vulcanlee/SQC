using SQCLibrary.Helpers;
using SQCLibrary.Services;
using System;
using System.Threading.Tasks;

namespace SQCConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            UserPlantUnitService service = new UserPlantUnitService();
            var foo = await service.GetAsync(ConstantsHelper.Token, ConstantsHelper.AppVersion);

            PlantUnitSampleService service2 = new PlantUnitSampleService();
            var bar = await service2.GetAsync(ConstantsHelper.Token, ConstantsHelper.AppVersion,
                "CFP", "CFP-SEMI");

            SampleResultService service3 = new SampleResultService();
            var foobar = await service3.GetAsync(ConstantsHelper.Token, ConstantsHelper.AppVersion
                , "   9244151");


            Console.WriteLine("Hello World!");

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
    }
}
