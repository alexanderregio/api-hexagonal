using System;

namespace Hexagonal.Domain.Exceptions
{
    public class CoreException : Exception
    {
        public CoreError[] errors { get; }

        public CoreException(params CoreError[] errors)
        {
            this.errors = errors;
        }
    }

    public class CoreError
    {
        public string key { get; }
        public string message { get; }

        public CoreError(string key, string message)
        {
            this.key = key;
            this.message = message;
        }
    }
}
