using Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDevCore.DocConfiguration.Helpers
{
    public class ExMessages : ExceptionUtils<ExMessages>, IExMessages
    {
        public static string dedefaultExCode { get => "TYPEDOC999"; }

        public ResourceExDescription EntityValidationError { get => new ResourceExDescription("TDV001", "Error de validación"); }
        public ResourceExDescription EntityDoesNotExists { get => new ResourceExDescription("TDC001", "Entidad no existe"); }
        public ResourceExDescription EntityAllreadyExists { get => new ResourceExDescription("TDC002", "Entidad ya existe"); }

        public ResourceExDescription SendFieldsError { get => new ResourceExDescription("TDC003", "Debe enviar las palabras clave"); }

    }
}
