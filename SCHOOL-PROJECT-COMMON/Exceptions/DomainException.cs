using System;

namespace SCHOOL_PROJECT_COMMON.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {
        }
    }
}
