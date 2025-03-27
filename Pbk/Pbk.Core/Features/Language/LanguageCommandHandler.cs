using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pbk.Entities.Abstractions;
using Pbk.Entities.Models;
using Pbk.Entities.Repositories;
using System.Linq.Expressions;
using Pbk.Core.Utilities.Hashing;

namespace Pbk.Core.Features.User;

internal sealed class LanguageCommandHandler 
{
   
    private readonly ILanguageRepository  _languageRepository;

    public LanguageCommandHandler(ILanguageRepository userDBRepository)
    {
        _languageRepository = userDBRepository;
    }


    public string Handle(string key)
    {

        return key;
    }
}
