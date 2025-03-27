using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Models
{

    public class EntryType
    {
        [Key]
        public int EntryTypeId { get; set; }

        public string EntryTypeName { get; set; } = null!;

        public string EntryTypeCode { get; set; } = null!;

        public bool IsActive { get; set; }

        public int InsUserId { get; set; }

        public DateTime InsDate { get; set; }

        public int? UpdUserId { get; set; }

        public DateTime? UpdDate { get; set; }

        public bool? IsDeleted { get; set; }

        public int? DeletedUserId { get; set; }
    }

}
