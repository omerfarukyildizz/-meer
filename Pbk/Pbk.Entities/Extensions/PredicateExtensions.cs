using System.Linq.Expressions;

namespace Pbk.Entities.Extensions;
public static class PredicateExtensions
{
    public static IQueryable<T> AddFilterIfValue<T>(this IQueryable<T> query, int? property, Expression<Func<T, bool>> predicate)
    {
        if (property.HasValue)
        {
            return query.Where(predicate);
        }

        return query;
    }

    public static IQueryable<T> AddFilterIfValue<T>(this IQueryable<T> query, string? property, Expression<Func<T, bool>> predicate)
    {
        if (!string.IsNullOrWhiteSpace(property))
        {
            return query.Where(predicate);
        }

        return query;
    }

    public static IQueryable<T> AddFilterIfValue<T>(this IQueryable<T> query, bool? property, Expression<Func<T, bool>> predicate)
    {
        if (property.HasValue)
        {
            return query.Where(predicate);
        }

        return query;
    }

    public static IQueryable<T> AddFilterIfValue<T>(this IQueryable<T> query, DateTime? property, Expression<Func<T, bool>> predicate)
    {
        if (property.HasValue)
        {
            return query.Where(predicate);
        }

        return query;
    }

    public static IQueryable<T> AddFilterIfValue<T>(this IQueryable<T> query, decimal? property, Expression<Func<T, bool>> predicate)
    {
        if (property.HasValue)
        {
            return query.Where(predicate);
        }

        return query;
    }

    public static IQueryable<T> AddFilterIfValue<T>(this IQueryable<T> query, double? property, Expression<Func<T, bool>> predicate)
    {
        if (property.HasValue)
        {
            return query.Where(predicate);
        }

        return query;
    }

    public static IQueryable<T> AddFilterIfValue<T>(this IQueryable<T> query, Enum? property, Expression<Func<T, bool>> predicate)
    {
        if (property != null)
        {
            return query.Where(predicate);
        }

        return query;
    }
}