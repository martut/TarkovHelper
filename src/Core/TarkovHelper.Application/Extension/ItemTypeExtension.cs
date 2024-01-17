using TarkovHelper.Application.Exceptions;
using TarkovHelper.Core.Models.Enums;

namespace TarkovHelper.Application.Extension;

public static class ItemTypeExtension
{
    public static ItemType Parse(string type)
    {
        if (Enum.TryParse<ItemType>(type, out var itemType))
        {
            return itemType;
        }

        throw new ServiceException(ErrorCodes.ItemTypeNotFound,
            $"Item type: '{type}' was not found.");
    }
}