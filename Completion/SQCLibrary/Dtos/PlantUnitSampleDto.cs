using System;
using System.Collections.Generic;
using System.Text;

namespace SQCLibrary.Dtos
{
    public class PlantUnitSampleDtoDatum
    {
        public string PLANT { get; set; }
        public string PLANT_UNIT { get; set; }
        public string ID_NUMERIC { get; set; }
        public string SAMPLE_TYPE { get; set; }
        public string SAMPLE_NAME { get; set; }
        public string SAMPLED_DATE { get; set; }
        public string SAMPLING_POINT { get; set; }
        public string STATUS { get; set; }
    }

    public class PlantUnitSampleDto
    {
        public string result { get; set; }
        public List<PlantUnitSampleDtoDatum> data { get; set; }
    }
}
