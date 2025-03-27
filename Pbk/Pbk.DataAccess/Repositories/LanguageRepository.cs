using Pbk.DataAccess.Context;
using Pbk.DataAccess.Repositories;
using Pbk.Entities.Models;
using Pbk.Entities.Repositories;
internal sealed class LanguageRepository : Repository<Language>, ILanguageRepository
{
    public LanguageRepository(ApplicationDbContext context) : base(context)
    {
    }
}