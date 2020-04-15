using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MySQL.ViewModels
{
    using System.ComponentModel;
    using AutoMapper;
    using MySQL.Models;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using SQCLibrary.Helpers;
    using SQCLibrary.Services;

    public class PlantUnitSamplePageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService navigationService;
        private readonly IMapper mapper;

        public PlantUnitSample PlantUnitSample { get; set; }
        public PlantUnitSamplePageViewModel(INavigationService navigationService,
            IMapper mapper)
        {
            this.navigationService = navigationService;
            this.mapper = mapper;
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            string plant = "";
            string plantunit = "";
            PLANTUNIT PLANTUNIT = parameters.GetValues<PLANTUNIT>(nameof(PLANTUNIT)) as PLANTUNIT;
            plantunit = PLANTUNIT.PLANT_UNIT;
            UserPlantUnitDatum userPlantUnitDatum = parameters.GetValue<UserPlantUnitDatum>(nameof(UserPlantUnitDatum)) as UserPlantUnitDatum;
            plant = userPlantUnitDatum.PLANT;

            PlantUnitSampleService service = new PlantUnitSampleService();
            var foo = await service.PostAsync(ConstantsHelper.Token, ConstantsHelper.AppVersion, 
                plant, plantunit);
            PlantUnitSample = mapper.Map<PlantUnitSample>(foo);
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
