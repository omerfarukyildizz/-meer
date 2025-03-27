 
using Pbk.Entities.Repositories;
using Microsoft.EntityFrameworkCore;
 

namespace Pbk.Core.Helpers
{
 
    public class AuthorityHelper: IAuthorityHelper
    {
       //  private readonly IGnlkulprog_yetkiRepository _gnlkulprog_yetkiRepository;
 

        public AuthorityHelper(  )
        {
            //_gnlkulprog_yetkiRepository = gnlkulprogYetkiRepository;
       
        }

      

         
        public async Task<bool> HasPermissionAsync(string progKodu, string yetkiKodu, int kullanici, CancellationToken cancellationToken)
        {
            //var gnlkulprogyetki = await _gnlkulprog_yetkiRepository
            //    .GetWhere(x => x.progkodu == progKodu && x.yetkikodu == yetkiKodu && x.kullanici == kullanici)
            //    .FirstOrDefaultAsync(cancellationToken);

            //return gnlkulprogyetki != null;
            return true;
        }

        public async Task<bool> CheckYukAndPermissionAsync(int userId, CancellationToken cancellationToken)
        {
           
                var hasPermission = await HasPermissionAsync("DenizHava.exe", "HBLNO", userId, cancellationToken);
                if (hasPermission)
                {
                    return false;
                }
            

            return true;
        }
    }
}
