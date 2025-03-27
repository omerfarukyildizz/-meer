using Pbk.DataAccess.Context;
using Pbk.Entities.Models;
using Pbk.Entities.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.DataAccess.Repositories
{
    internal sealed class EndPointRepository : Repository<EndPoint>, IEndPointRepository
    {
        private readonly ApplicationDbContext _context;
 

        public EndPointRepository(ApplicationDbContext context ) : base(context)
        {
            _context = context;
        }

       
    }
}
