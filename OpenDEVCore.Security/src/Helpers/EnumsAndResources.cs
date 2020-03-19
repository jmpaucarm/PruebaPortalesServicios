using Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.Security.Helpers
{
    public static class ExMessages
    {
        /*
          * Código = code => deberá contener las siglas del módulo
          * Mensaje = message => deberá ser el mensaje especifíco del error hacia el cliente
          * public static ResourceExDescription EntityAllreadyExists = new ResourceExDescription("BAS002", "Entidad ya existe");
         */
        public static ResourceExDescription EntityValidationError = new ResourceExDescription("EFV001", "Error de validación");
        


        public static ResourceExDescription TokenRevoked = new ResourceExDescription("refresh_token_already_revoked", $"Refresh token.");

        public static ResourceExDescription UserAllreadyExists = new ResourceExDescription("SEC001", "Usuario ya existe!");
        public static ResourceExDescription UserIsNotActive = new ResourceExDescription("SEC002", "Usuario no es Activo!");
        public static ResourceExDescription UserDoesNotExists = new ResourceExDescription("SEC003", "Usuario no existe!");
        public static ResourceExDescription UserIsBlocked = new ResourceExDescription("SEC004", "Usuario está Bloqueado!");
        public static ResourceExDescription UserIsConnectedInAnotherTerminal = new ResourceExDescription("SEC005", "Usuario está conectado en otra máquina!");
        public static ResourceExDescription UserBlocked = new ResourceExDescription("SEC006", "Password Incorrecto, usuario bloqueado!");
        public static ResourceExDescription UsersPasswordIncorrect = new ResourceExDescription("SEC007", "Password Incorrecto!");


        public static ResourceExDescription EntityDoesNotExists = new ResourceExDescription("SEC008", "Entidad no existe");
        public static ResourceExDescription EntityAllreadyExists = new ResourceExDescription("SEC009", "Entidad ya existe");

        public static ResourceExDescription UserDatePassword = new ResourceExDescription("SEC010", "Tiene que cambiar de password!");








    }
}

