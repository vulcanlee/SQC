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

    public class SampleResultPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService navigationService;
        private readonly IMapper mapper;
        public string PageName { get; set; }
        public SampleResult SampleResult { get; set; }
        public UserPlantUnit UserPlantUnit { get; set; }
        public SampleResultPageViewModel(INavigationService navigationService,
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
            string ID_NUMERIC = "";
            PlantUnitSampleDatum PlantUnitSampleDatum = (parameters.GetValue<PlantUnitSampleDatum>("PlantUnitSampleDatum"));
            ID_NUMERIC = PlantUnitSampleDatum?.ID_NUMERIC;

            SampleResultService service3 = new SampleResultService();
            var foobar = await service3.GetAsync(ConstantsHelper.Token, ConstantsHelper.AppVersion
                , ID_NUMERIC);

            SampleResult = mapper.Map<SampleResult>(foobar);
            PageName = PlantUnitSampleDatum.SAMPLING_POINT;
            ReorderID();

        }

        private void ReorderID()
        {
            int foo = 1;
            foreach (var item in SampleResult.data.SAMPLE_RESULTS)
            {
                item.ID = foo++;
            }
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
