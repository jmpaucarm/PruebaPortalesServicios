using Core.Exceptions;
using Core.Types;

namespace OpenDEVCore.Configuration.Helpers
{
    public interface IExMessages
    {
        ResourceExDescription EntityAllreadyExists { get; }
        ResourceExDescription EntityDoesNotExists { get; }
        ResourceExDescription EntityValidationError { get; }
        ResourceExDescription IncorrectGeogrphicLocationCode { get; }

        ResourceExDescription Map(CoreResponse coreResponse, bool? automaticThrow = true);
    }
}