using Core.Exceptions;

namespace OpenDevCore.DocConfiguration.Helpers
{
    public interface IExMessages
    {
        ResourceExDescription EntityAllreadyExists { get; }
        ResourceExDescription EntityDoesNotExists { get; }
        ResourceExDescription EntityValidationError { get; }

        ResourceExDescription SendFieldsError { get; }

    }
}