using TarkovHelper.Application.Exceptions;

namespace TarkovHelper.Application.Extension;

public static class EnumExtension
{
    public static T Parse<T>(string value, string code) where T : struct
    {
        if (Enum.TryParse<T>(value, out var enumValue))
        {
            return enumValue;
        }

        throw new ServiceException(code, $"'{value}' was not found.");
    }
}