using System;

namespace MindEval.FiveSquare.Common
{
    public class MamalonaException : Exception
    {
        public MamalonaException()
        : base()
        { }

        public MamalonaException(string message)
        : base(message)
        { }

        public MamalonaException(string format, params object[] args)
        : base(string.Format(format, args))
        { }

        public MamalonaException(string message, Exception innerException)
        : base(message, innerException)
        { }
    }
}