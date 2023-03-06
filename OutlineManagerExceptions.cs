using System;

namespace OutlineManagerExceptions
{
    [Serializable]
    public class OutlineManagerException : Exception
	{
        public OutlineManagerException()
        { }
        public OutlineManagerException(string message)
			: base(message)
		{ }
        public OutlineManagerException(string message, Exception innerException)
        : base(message, innerException)
        { }
    }

    [Serializable]
	public class OutlineAPIException : Exception
	{
        public virtual int ErrorCode { get; }

        public OutlineAPIException()
        { }
        public OutlineAPIException(string message)
            : base(message)
        { }
        public OutlineAPIException(string message, Exception innerException)
        : base(message, innerException)
        { }
    }
}

