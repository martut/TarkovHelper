namespace TarkovHelper.Core.Exceptions;

public class DomainException : TarkovHelperException
{
    public DomainException()
    {
    }

    public DomainException(string code)
    {
    }

    public DomainException(string message, params object[] args)
        : base(string.Empty, message, args)
    {
    }

    public DomainException(string code, string message, params object[] args)
        : base(null, code, message, args)
    {
    }

    public DomainException(Exception innerException, string message, params object[] args)
        : base(innerException, string.Empty, message, args)
    {
    }

    public DomainException(Exception innerException, string code, string message, params object[] args)
        : base(string.Format(message, args), innerException)
    {
    }
}