using AutoMapper;
using Prism;
using Prism.Ioc;
using SQC.Models;
using SQC.ViewModels;
using SQC.Views;
using SQCLibrary.Dtos;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SQC
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ConfigAutoMapper(containerRegistry);

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<UserPlantUnitPage, UserPlantUnitPageViewModel>();
            containerRegistry.RegisterForNavigation<PlantUnitSamplePage, PlantUnitSamplePageViewModel>();
            containerRegistry.RegisterForNavigation<SampleResultPage, SampleResultPageViewModel>();
        }

        private void ConfigAutoMapper(IContainerRegistry containerRegistry)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserPlantUnitDto, UserPlantUnit>();
                cfg.CreateMap<UserPlantUnitDtoDatum, UserPlantUnitDatum>();
                cfg.CreateMap<PLANTUNITDto, PLANTUNIT>();
                cfg.CreateMap<SampleResultDto, SampleResult>();
                cfg.CreateMap<SampleResultDtoData, SampleResultData>();
                cfg.CreateMap<SAMPLERESULTDto, SAMPLERESULT>();
                cfg.CreateMap<PlantUnitSampleDto, PlantUnitSample>();
                cfg.CreateMap<PlantUnitSampleDtoDatum, PlantUnitSampleDatum>();
            });

            IMapper mapper = config.CreateMapper();
            containerRegistry.RegisterInstance<IMapper>(mapper);
        }
    }
}
