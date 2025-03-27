using Pbk.DataAccess.Context;
using Pbk.DataAccess.Repositories;
using Pbk.Entities.Models;
using Pbk.Entities.Repositories;
internal sealed class ProjectRepository : Repository<Project>, IProjectRepository
{
    public ProjectRepository(ApplicationDbContext context) : base(context)
    {
    }
}