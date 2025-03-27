using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Base
{
    public record BaseCommand(string? Language = "en", string? IpAddress = "");

}
