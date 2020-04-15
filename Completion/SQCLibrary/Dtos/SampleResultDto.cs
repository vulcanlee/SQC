using System;
using System.Collections.Generic;
using System.Text;

namespace SQCLibrary.Dtos
{
    public class SAMPLERESULTDto
    {
        public string COMPONENT_NAME { get; set; }
        public string RESULT_TEXT { get; set; }
        public string MAX_LIMIT { get; set; }
        public string MIN_LIMIT { get; set; }
        public string UNITS { get; set; }
        public string DESCRIPTION { get; set; }
        public string ANALYSIS { get; set; }
        public string PRODUCT { get; set; }
    }

    public class SampleResultDtoData
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
        public List<SAMPLERESULTDto> SAMPLE_RESULTS { get; set; }
    }

    public class SampleResultDto
    {
        public string result { get; set; }
        public SampleResultDtoData data { get; set; }
    }
}
