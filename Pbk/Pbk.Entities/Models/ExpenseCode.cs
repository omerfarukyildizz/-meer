using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Models
{
    public class ExpenseCode
    {
        [Key]
        public int ExpenseCodeId { get; set; }

        public int DepartmentId { get; set; }

        public string ExpenseCodeName { get; set; } = null!;

        public string? IntegrationCode { get; set; }

        public string? Description { get; set; }

        public string? TycoCode { get; set; }

        public string? ExpenseFlag { get; set; }

        public int? TransactionId { get; set; }

        public int InsUser { get; set; }

        public DateTime InsTime { get; set; }

        public int? UpdUser { get; set; }

        public DateTime? UpdTime { get; set; }
    }
}
