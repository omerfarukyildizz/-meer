using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.ModelDtos
{
    public class MapResponseData
    {
        public int DistanceServiceId { get; set; }
        public DateTime InsDate { get; set; }
        public int RequestKeyId { get; set; }
        public string OriginAddress { get; set; }
        public string DestinationAddress { get; set; }
        public string DistanceText { get; set; }
        public int DistanceValue { get; set; }
        public string DurationText { get; set; }
        public int DurationValue { get; set; }
        public string Status { get; set; }
        public string RequestDestinationAddress { get; set; }
        public string RequestOriginAddress { get; set; }
    }
}
