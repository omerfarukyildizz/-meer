using Pbk.DataAccess.Context;
using Pbk.Entities.Models;
using Pbk.Entities.Repositories;

namespace Pbk.DataAccess.Repositories;
internal sealed class PalletCompanyRepository : Repository<PalletCompany>, IPalletCompanyRepository
{
    public PalletCompanyRepository(ApplicationDbContext context) : base(context)
    {
    }
}
