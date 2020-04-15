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

    public class UserPlantUnitPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService navigationService;
        private readonly IMapper mapper;
        public DelegateCommand<UserPlantUnitDatum> PlantNameCommand { get; set; }
        public DelegateCommand<PLANTUNIT> PlantUnitsCommand { get; set; }
        public UserPlantUnit UserPlantUnit { get; set; }

        public UserPlantUnitPageViewModel(INavigationService navigationService,
            IMapper mapper)
        {
            this.navigationService = navigationService;
            this.mapper = mapper;
            PlantNameCommand = new DelegateCommand<UserPlantUnitDatum>(x =>
            {
                x.IsExpand = !x.IsExpand;
                if (x.IsExpand == true)
                {
                    x.ExpandLabel = "V";
                }
                else
                {
                    x.ExpandLabel = ">";
                }
            });

            PlantUnitsCommand = new DelegateCommand<PLANTUNIT>(x =>
            {
                var item = UserPlantUnit.data.FirstOrDefault(q => q.PLANT_UNITS.Contains(x));
                if (item != null)
                {
                    NavigationParameters para = new NavigationParameters();
                    para.Add("UserPlantUnitDatum", item);
                    para.Add("PLANTUNIT", x);
                    navigationService.NavigateAsync("PlantUnitSamplePage", para);
                }
            });
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            if(parameters.GetNavigationMode() == NavigationMode.Back)
            {
                return;
            }

            UserPlantUnitService service = new UserPlantUnitService();
            var foo = await service.GetAsync(ConstantsHelper.Token, ConstantsHelper.AppVersion);

            UserPlantUnit = mapper.Map<UserPlantUnit>(foo);
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
