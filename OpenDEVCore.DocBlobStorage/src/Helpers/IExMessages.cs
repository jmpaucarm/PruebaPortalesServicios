using Core.Exceptions;
using Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.DocBlobStorage.Helpers
{
    public interface IExMessages
    {
        ResourceExDescription EntityValidationError { get; }
        ResourceExDescription EntityDoesNotExists { get; }
        ResourceExDescription EntityAllreadyExists { get; }
        ResourceExDescription KeyWordsNotFount { get; }

        ResourceExDescription StoringDocumentException { get; }
        ResourceExDescription Map(CoreResponse coreResponse, bool? automaticThrow = true);

    }
}
