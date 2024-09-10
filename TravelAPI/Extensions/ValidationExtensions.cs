using FluentValidation.Results;

namespace TravelAPI.Extensions
{
    public static class ValidationExtensions
    {
        public static Dictionary<string, string[]> ToDictionary(this IEnumerable<ValidationFailure> validationFailures)
        {
            ArgumentNullException.ThrowIfNull(validationFailures);

            return validationFailures.GroupBy(failure =>
            {
                return failure.FormattedMessagePlaceholderValues["CollectionIndex"].ToString();
            }).ToDictionary(group => $"boarding card index {group.Key}",
                            group => group.Select(failure => failure.ErrorMessage).ToArray());
        }
    }
}
