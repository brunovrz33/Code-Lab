using System;
using System.Collections.Generic;
using System.Text;

namespace ex27.Entities
{
    class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {
        }
    }
}
