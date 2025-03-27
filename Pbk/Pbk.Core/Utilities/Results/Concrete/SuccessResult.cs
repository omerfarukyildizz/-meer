using Core.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    
    /// İşlem başarılı olduğunda, işlem sonucunu gönderen yapıyı oluşturduk.
   
    public class SuccessResult : Result
    {
        public SuccessResult() : base(true)
        {
        }

        public SuccessResult(string message) : base(true, message)
        {
        }
    }
}
