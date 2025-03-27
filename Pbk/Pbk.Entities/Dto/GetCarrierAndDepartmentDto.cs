using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Dto
{
    public class GetCarrierAndDepartmentDto
    {
        public int CarrierId { get; set; }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;

        public string CarrierName { get; set; } = null!;

        public string SAPAccountCode { get; set; } = null!;

        public int? PaymentTerms { get; set; }

        public int? DocumentId { get; set; }

        public string? ContactPerson { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public bool IsPassive { get; set; }

        public int InsUser { get; set; }

        public DateTime InsTime { get; set; }

        public int? UpdUser { get; set; }

        public DateTime? UpdTime { get; set; }
    }
}
