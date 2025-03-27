using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Extensions
{
 
    public static class StringExtension
    {
     
        public static string Lang(this string input)
        {

              return input;
           /* using (var Context =  ContextDB) if (translationDictionary.ContainsKey(input)) {   return translationDictionary[input];  }      else { }*/
        }

    }

}
