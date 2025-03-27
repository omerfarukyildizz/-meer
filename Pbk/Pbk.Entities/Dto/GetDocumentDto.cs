using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Dto
{
    public class GetDocumentDto
    {
        public int DocumentId { get; set; }
        public string? FilePath { get; set; }

        public string FileName { get; set; } = null!;

        public int ArchiveTypeId { get; set; }
    }
}
