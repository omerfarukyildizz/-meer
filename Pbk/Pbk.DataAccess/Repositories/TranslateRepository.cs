using Pbk.DataAccess.Context;
using Pbk.DataAccess.Repositories;
using Pbk.Entities.Models;
using Pbk.Entities.Repositories;
internal sealed class TranslateRepository : Repository<Translate>, ITranslateRepository
{
    public TranslateRepository(ApplicationDbContext context) : base(context)
    {
    }
}