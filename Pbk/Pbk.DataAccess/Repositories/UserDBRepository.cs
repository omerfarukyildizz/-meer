using Pbk.DataAccess.Context;
using Pbk.DataAccess.Repositories;
using Pbk.Entities.Models;
using Pbk.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 
internal sealed class UserDBRepository : Repository<User>, IUserDBRepository
{
    public UserDBRepository(ApplicationDbContext context) : base(context)
    {
    }
}