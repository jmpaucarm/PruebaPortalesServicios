using Core.Exceptions;
using Core.Types;

namespace OpenDEVCore.Configuration.Helpers
{
    public class ExMessages : ExceptionUtils<ExMessages>, IExMessages
    {
        /*
          * Código = code => deberá contener las siglas del módulo
          * Mensaje = message => deberá ser el mensaje especifíco del error hacia el cliente
          * public static ResourceExDescription EntityAllreadyExists = new ResourceExDescription("BAS002", "Entidad ya existe");
         */

        public static string defaultExCode { get => "CFN999"; }

        public ResourceExDescription EntityValidationError { get => new ResourceExDescription("EFV001", "Error de validación"); }
        public ResourceExDescription EntityDoesNotExists { get => new ResourceExDescription("CFN001", "Entidad no existe"); }
        public ResourceExDescription EntityAllreadyExists { get => new ResourceExDescription("CFN002", "Entidad ya existe"); }
        public ResourceExDescription IncorrectGeogrphicLocationCode { get => new ResourceExDescription("CFN003", "Código incorrecto!! no se debe cambiar el código"); }
        public ResourceExDescription Map(CoreResponse coreResponse, bool? automaticThrow = true) => Map(new ExMessages(), defaultExCode, coreResponse, automaticThrow);

    }
}
