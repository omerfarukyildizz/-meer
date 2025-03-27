using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Dto
{
    public class GetUsersAndDepartmentsDto
    {
        public int UserId { get; set; }

        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; } 
        public int RoleId { get; set; }

        public string? DepartmentCode { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; } 

        public string? Position { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public bool? IsPassive { get; set; }
        public int BarsisUserId { get; set; }

        public int InsUser { get; set; }

        public DateTime InsTime { get; set; }

        public DateTime? UpdTime { get; set; }

        public int? UpdUser { get; set; }
    }
}
