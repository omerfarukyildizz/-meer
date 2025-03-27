using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Helpers
{
    public static class ExceptionHelper
    {
        public static string GetCustomErrorMessage(Exception ex)
        {
            // İlk olarak hatanın kendisini kontrol ediyoruz
            string message = ex.Message;

            // InnerException varsa ve trigger kelimesi içeriyorsa özel mesajı hazırlıyoruz
            if (ex.InnerException != null && ex.InnerException.Message.Contains("trigger"))
            {
                // \r\n sonrasını atmak için Split kullanıyoruz
                string[] parts = ex.InnerException.Message.Split(new[] { "\r\n" }, StringSplitOptions.None);
                if (parts.Length > 0)
                {
                    message = parts[0]; // İlk kısmı alıyoruz
                }
            }

            return message;
        }
    }
}
