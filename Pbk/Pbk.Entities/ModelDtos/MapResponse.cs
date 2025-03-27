using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Pbk.Entities.ModelDtos
{
    public class MapResponse

    {
        public MapResponseData Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
