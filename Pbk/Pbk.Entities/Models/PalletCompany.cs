using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Models
{
    public class PalletCompany
    {
        public int PalletCompanyId { get; set; }
        public string PalletCompanyName { get; set; } = null!;
        public int InsUser { get; set; }
        public DateTime InsTime { get; set; }
    }
}
