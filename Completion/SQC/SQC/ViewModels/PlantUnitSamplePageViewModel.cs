using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SQC.ViewModels
{
    using System.ComponentModel;
    using AutoMapper;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using SQC.Models;
    using SQCLibrary.Helpers;
    using SQCLibrary.Services;

    public class PlantUnitSamplePageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService navigationService;
        private readonly IMapper mapper;
        public PlantUnitSample PlantUnitSample { get; set; }
        public DelegateCommand<PlantUnitSampleDatum> PlantUnitSampleDatumCommand { get; set; }
        public string PageName { get; set; }
        public PlantUnitSamplePageViewModel(INavigationService navigationService,
            IMapper mapper)
        {
            this.navigationService = navigationService;
            this.mapper = mapper;
            PlantUnitSampleDatumCommand = new DelegateCommand<PlantUnitSampleDatum>(async x =>
            {
                NavigationParameters para = new NavigationParameters();
                para.Add("PlantUnitSampleDatum", x);
                await navigationService.NavigateAsync("SampleResultPage", para);
            });
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            if(parameters.GetNavigationMode()== NavigationMode.Back)
            {
                return;
            }
            string plant = "";
            string plantunit = "";
            PLANTUNIT PLANTUNIT = (parameters["PLANTUNIT"] as PLANTUNIT);
            plantunit = PLANTUNIT?.PLANT_UNIT;
            UserPlantUnitDatum UserPlantUnitDatum = (parameters["UserPlantUnitDatum"] as UserPlantUnitDatum);
            plant = UserPlantUnitDatum?.PLANT;

            PlantUnitSampleService service2 = new PlantUnitSampleService();
            var bar = await service2.GetAsync(ConstantsHelper.Token, ConstantsHelper.AppVersion,
                plant, plantunit);

            PlantUnitSample = mapper.Map<PlantUnitSample>(bar);
            PageName = PLANTUNIT.CHINESE_UNIT_NAME;
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
