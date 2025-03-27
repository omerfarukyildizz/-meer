using Pbk.DataAccess.Context;
using Pbk.Entities.Models;
using Pbk.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.DataAccess.Repositories
{
    internal sealed class PageRepository : Repository<Page>, IPageRepository
    {
        public PageRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
