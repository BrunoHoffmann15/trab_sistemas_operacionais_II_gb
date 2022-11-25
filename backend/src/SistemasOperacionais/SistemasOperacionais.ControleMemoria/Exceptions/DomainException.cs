using System;

namespace SistemasOperacionais.ControleMemoria.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {
        }
    }
}
