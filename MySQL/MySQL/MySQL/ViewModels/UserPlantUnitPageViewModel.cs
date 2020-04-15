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

    public class UserPlantUnitPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService navigationService;
        private readonly IMapper mapper;

        public UserPlantUnit UserPlantUnit { get; set; }
        public UserPlantUnitPageViewModel(INavigationService navigationService,
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
            UserPlantUnitService userPlantUnitService = new UserPlantUnitService();
            var foo = await userPlantUnitService
                .GetAsync(ConstantsHelper.Token,
                ConstantsHelper.AppVersion);

            // Type A                                   Type B
            UserPlantUnit = mapper.Map<UserPlantUnit>(foo);

            #region 若不使用 AutoMapper，則需要使用底下的這麼多程式碼，才能完成相關作業
            //UserPlantUnit.result = foo.result;
            //UserPlantUnit.data = new System.Collections.ObjectModel.ObservableCollection<UserPlantUnitDatum>();
            //foreach (var item in foo.data)
            //{
            //    UserPlantUnitDatum userPlantUnitDatum = new UserPlantUnitDatum();
            //    userPlantUnitDatum.CHINESE_PLANT_NAME = item.CHINESE_PLANT_NAME;
            //    userPlantUnitDatum.PLANT = item.PLANT;
            //    userPlantUnitDatum.PLANT_UNITS = new System.Collections.ObjectModel.ObservableCollection<PLANTUNIT>();
            //    foreach (var item2 in item.PLANT_UNITS)
            //    {
            //        PLANTUNIT pLANTUNIT = new PLANTUNIT();
            //        pLANTUNIT.CHINESE_UNIT_NAME = item2.CHINESE_UNIT_NAME;
            //        pLANTUNIT.GROUP_ID = item2.GROUP_ID;
            //        pLANTUNIT.PLANT_UNIT = item2.PLANT_UNIT;
            //        userPlantUnitDatum.PLANT_UNITS.Add(pLANTUNIT);
            //    }
            //    UserPlantUnit.data.Add(userPlantUnitDatum);
            //}
            #endregion
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {

        }

    }
}
