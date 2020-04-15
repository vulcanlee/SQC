using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace SQC.Models
{
    public class SAMPLERESULT : INotifyPropertyChanged
    {
        public string COMPONENT_NAME { get; set; }
        public string RESULT_TEXT { get; set; }
        public string MAX_LIMIT { get; set; }
        public string MIN_LIMIT { get; set; }
        public string UNITS { get; set; }
        public string DESCRIPTION { get; set; }
        public string ANALYSIS { get; set; }
        public string PRODUCT { get; set; }
        public int ID { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class SampleResultData : INotifyPropertyChanged
    {
        public string ID_NUMERIC { get; set; }
        public string PLANT { get; set; }
        public string PLANT_UNIT { get; set; }
        public string CHINESE_UNIT_NAME { get; set; }
        public string SAMPLING_POINT { get; set; }
        public string SAMPLE_TYPE { get; set; }
        public string SAMPLE_NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public string SAMPLED_DATE { get; set; }
        public string DATE_COMPLETED { get; set; }
        public string DATERESAVAIL { get; set; }
        public string LOT_NO { get; set; }
        public ObservableCollection<SAMPLERESULT> SAMPLE_RESULTS { get; set; } = new ObservableCollection<SAMPLERESULT>();

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class SampleResult : INotifyPropertyChanged
    {
        public string result { get; set; }
        public SampleResultData data { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
