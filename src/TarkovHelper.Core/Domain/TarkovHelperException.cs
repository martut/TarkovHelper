namespace TarkovHelper.Core.Domain;

public abstract class TarkovHelperException : Exception
{
    protected TarkovHelperException()
    {
    }

    protected TarkovHelperException(string code)
    {
        Code = code;
    }

    protected TarkovHelperException(string message, params object[] args)
        : this(string.Empty, message, args)
    {
    }

    protected TarkovHelperException(string code, string message, params object[] args)
        : this(null, code, message, args)
    {
    }

    protected TarkovHelperException(Exception? innerException, string message, params object[] args)
        : this(innerException, string.Empty, message, args)
    {
    }

    protected TarkovHelperException(Exception? innerException, string code, string message, params object[] args)
        : base(string.Format(message, args), innerException)
    {
        Code = code;
    }

    public string Code { get; }
}