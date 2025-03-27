using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Helpers
{
    public interface IAuthorityHelper
    {
    Task<bool> HasPermissionAsync(string progKodu, string yetkiKodu, int kullanici, CancellationToken cancellationToken);
   Task<bool> CheckYukAndPermissionAsync( int userId, CancellationToken cancellationToken);
    }
}
