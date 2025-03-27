using Pbk.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Repositories
{
    public interface IEndPointRepository : IRepository<EndPoint>
    {
        //public DbContext getBarsisContext();
    }
}
