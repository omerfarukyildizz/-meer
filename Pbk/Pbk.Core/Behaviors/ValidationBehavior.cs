using Pbk.Core.Features.User;
using Pbk.Entities.Models;
using Pbk.Entities.Repositories;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Pbk.Core.Behaviors;
public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    private readonly TanslateCommandHandler tanslateCommandHandler;
    private readonly ITranslateRepository _translateRepository;
    private readonly ILanguageRepository _languageRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators, ITranslateRepository translateRepository, ILanguageRepository languageRepository, IUnitOfWork unitOfWork)
    {
        _validators = validators;
        _translateRepository = translateRepository;
        _languageRepository = languageRepository;
        _unitOfWork = unitOfWork;
        tanslateCommandHandler = new TanslateCommandHandler(_translateRepository, _languageRepository, _unitOfWork);
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);

        var errorDictionary = _validators
            .Select(s => s.Validate(context))
            .SelectMany(s => s.Errors)
            .Where(s => s != null)
            .GroupBy(
            s => s.PropertyName,
            s => s.ErrorMessage, (propertyName, errorMessage) => new
            {
                Key = propertyName,
                Values = errorMessage.Distinct().ToArray()
            })
            .ToDictionary(s => s.Key, s => s.Values[0]);

        if (errorDictionary.Any())
        {
            var errors = errorDictionary.Select(s => new ValidationFailure
            {
                PropertyName =(s.Value),
                ErrorCode = s.Key
            });

            ValidationFailure validationFailure = new ValidationFailure();
            validationFailure.PropertyName = await tanslateCommandHandler.GetTranslation(errors.FirstOrDefault().PropertyName);

            throw new ValidationException(validationFailure.PropertyName);

        }

        return await next();
    }
}
