using TarkovHelper.Core.Exceptions;

namespace TarkovHelper.Application.Exceptions;

public class ServiceException : TarkovHelperException
{
    public ServiceException()
    {
    }

    public ServiceException(string code)
    {
    }

    public ServiceException(string message, params object[] args)
        : base(string.Empty, message, args)
    {
    }

    public ServiceException(string code, string message, params object[] args)
        : base(null, code, message, args)
    {
    }

    public ServiceException(Exception innerException, string message, params object[] args)
        : base(innerException, string.Empty, message, args)
    {
    }

    public ServiceException(Exception innerException, string code, string message, params object[] args)
        : base(string.Format(message, args), innerException)
    {
    }
}