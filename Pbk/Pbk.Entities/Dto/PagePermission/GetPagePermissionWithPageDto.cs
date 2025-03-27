using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Dto.PagePermission
{
    public class GetPagePermissionWithPageDto
    {
        public int AuthorityID { get; set; }

        public int UserID { get; set; }

        public int DepartmentId { get; set; }

        public int PageId { get; set; }

        public int PagePermissionId { get; set; }
        public string PermissionType { get; set; } = null!;
        public int isUserPermActive { get; set; }  

        public bool HasPermission { get; set; }

        public int InsUser { get; set; }

        public DateTime InsTime { get; set; }

        public int? UpdUser { get; set; }

        public DateTime? UpdTime { get; set; }
    }
}
