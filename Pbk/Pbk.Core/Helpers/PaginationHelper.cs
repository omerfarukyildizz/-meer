using System;
using System.Collections.Generic;
using System.Linq;

namespace Pbk.Core.Helpers
{
    public class PaginationHelper
    {
        public static IQueryable<T> Paginate<T>(IQueryable<T> query, int activePage, int pageSize)
        {
            var result = query.Skip((activePage - 1) * pageSize).Take(pageSize);
            return result;
        }
    }
}
