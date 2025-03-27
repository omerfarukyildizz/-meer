using Microsoft.EntityFrameworkCore;

namespace Pbk.Entities.Editors
{
    [Keyless]
    public class GnlYukAndKarsDepartmanEditor
    {
        public string? YukDepartman { get; set; }
        public string? KarsilayanDepartman { get; set; }
    }
}
