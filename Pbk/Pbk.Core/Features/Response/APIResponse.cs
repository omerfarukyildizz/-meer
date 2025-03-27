 
namespace Pbk.Core.Features.Response;
public sealed record APIResponse(
    string status,
    string? messages,
    Object? data
);
