using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Entities.Dto.Projects
{
    public class GetProjectDto
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = null!;
    }
}
