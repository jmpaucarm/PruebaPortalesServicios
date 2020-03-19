using Core.Exceptions;
using Core.Types;

namespace OpenDEVCore.DocBlobStorage.Helpers
{
    public class ExMessages : ExceptionUtils<ExMessages>, IExMessages
    {
        public static string defaultExCode { get => "BLODSROEC999"; }

        public ResourceExDescription EntityValidationError { get => new ResourceExDescription("TDV001", "Valitation Error"); }
        public ResourceExDescription EntityDoesNotExists { get => new ResourceExDescription("TDC001", "Entity Does not Exists"); }
        public ResourceExDescription EntityAllreadyExists { get => new ResourceExDescription("TDC002", "Entity Alredy Exists"); }
        public ResourceExDescription StoringDocumentException { get => new ResourceExDescription("TDC003", "Error while trying to store document"); }

        public ResourceExDescription KeyWordsNotFount { get => new ResourceExDescription("TDC004", "KEY words doses not match with configuration definition "); }

        public ResourceExDescription Map(CoreResponse coreResponse, bool? automaticThrow = true)
        => ExceptionUtils.Map(defaultExCode, typeof(ExMessages), coreResponse, automaticThrow);
    }
}
