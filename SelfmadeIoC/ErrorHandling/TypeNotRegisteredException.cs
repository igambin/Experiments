using System;

namespace SelfmadeIoC
{
    public class TypeNotRegisteredException : Exception
    {
        public TypeNotRegisteredException()
        {
        }

        public TypeNotRegisteredException(Exception e) 
            : base("Der aufzulösende Typ ist nicht registriert bzw. die Argumente des ersten registrierten Konstruktors können nicht aufgelöst werden.", e)
        {
            // TODO: Complete member initialization
            
        }
    }
}
