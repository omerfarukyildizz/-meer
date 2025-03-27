using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    public class ErrorResult : Result
    {
       
        /// İşlemin hatalı olması durumunda dönmesi gereken sonuçları yapılandırdık.
        
        public ErrorResult() : base(false)
        {
        }

        public ErrorResult(string message) : base(false, message)
        {
        }
    }
}
