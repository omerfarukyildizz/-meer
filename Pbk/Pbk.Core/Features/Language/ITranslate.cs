using Pbk.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.User;

public interface ITranslate
{
     Task<bool> Add(string TranslateKey);
     Task<string> GetTranslation(string request);
}
