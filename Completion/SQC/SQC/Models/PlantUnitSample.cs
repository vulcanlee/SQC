using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace SQC.Models
{
    public class PlantUnitSampleDatum : INotifyPropertyChanged
    {
        public string PLANT { get; set; }
        public string PLANT_UNIT { get; set; }
        public string ID_NUMERIC { get; set; }
        public string SAMPLE_TYPE { get; set; }
        public string SAMPLE_NAME { get; set; }
        public string SAMPLED_DATE { get; set; }
        public string SAMPLING_POINT { get; set; }
        public string STATUS { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class PlantUnitSample : INotifyPropertyChanged
    {
        public string result { get; set; }
        public ObservableCollection<PlantUnitSampleDatum> data { get; set; } = new ObservableCollection<PlantUnitSampleDatum>();

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
