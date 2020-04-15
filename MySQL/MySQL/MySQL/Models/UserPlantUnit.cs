using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace MySQL.Models
{
    public class PLANTUNIT : INotifyPropertyChanged
    {
        public string PLANT_UNIT { get; set; }
        public string GROUP_ID { get; set; }
        public string CHINESE_UNIT_NAME { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class UserPlantUnitDatum : INotifyPropertyChanged
    {
        public string PLANT { get; set; }
        public string CHINESE_PLANT_NAME { get; set; }
        public string ExpandLabel { get; set; } = ">";
        public bool IsExpand { get; set; } = false;
        public ObservableCollection<PLANTUNIT> PLANT_UNITS { get; set; } = new ObservableCollection<PLANTUNIT>();

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class UserPlantUnit : INotifyPropertyChanged
    {
        public string result { get; set; }

        public ObservableCollection<UserPlantUnitDatum> data { get; set; } = new ObservableCollection<UserPlantUnitDatum>();
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
