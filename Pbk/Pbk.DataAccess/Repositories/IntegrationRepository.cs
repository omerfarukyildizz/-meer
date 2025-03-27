using Pbk.DataAccess.Context;
using Pbk.Entities.Models;
using Pbk.Entities.Repositories;

namespace Pbk.DataAccess.Repositories;
internal sealed class IntegrationRepository : Repository<Integration>, IIntegrationRepository
{
    public IntegrationRepository(ApplicationDbContext context) : base(context)
    {
    }
}
