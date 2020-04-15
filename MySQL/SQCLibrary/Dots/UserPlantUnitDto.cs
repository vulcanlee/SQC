using System;
using System.Collections.Generic;
using System.Text;

namespace SQCLibrary.Dots
{
    public class PLANTUNITDto
    {
        public string PLANT_UNIT { get; set; }
        public string GROUP_ID { get; set; }
        public string CHINESE_UNIT_NAME { get; set; }
    }

    public class UserPlantUnitDtoDatum
    {
        public string PLANT { get; set; }
        public string CHINESE_PLANT_NAME { get; set; }
        public List<PLANTUNITDto> PLANT_UNITS { get; set; }
    }

    public class UserPlantUnitDto
    {
        public string result { get; set; }
        public List<UserPlantUnitDtoDatum> data { get; set; }
    }
}
