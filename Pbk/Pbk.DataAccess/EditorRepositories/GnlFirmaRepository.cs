using Pbk.DataAccess.Context;
using Pbk.DataAccess.Repositories;
using Pbk.Entities.EditorRepositories;
using Pbk.Entities.Editors;

internal sealed class GnlFirmaEditorRepository : Repository<GnlFirmaEditor>, IGnlFirmaEditorRepository
{
    public GnlFirmaEditorRepository(ApplicationDbContext context) : base(context)
    {
    }
}