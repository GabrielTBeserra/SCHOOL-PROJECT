using System;

namespace SCHOOL_PROJECT_COMMON.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
