using TarkovHelper.Core.Domain;
using TarkovHelper.Core.Models.Enums;

namespace TarkovHelper.Core.Models;

public class Item
{
    public Item()
    {
    }

    public Item(string name, string shortName, ItemType itemType)
    {
        SetName(name);
        SetItemType(itemType);
        SetShortName(shortName);
    }

    public int Id { get; protected set; }

    public string Name { get; protected set; }

    public string ShortName { get; protected set; }

    public ItemType ItemType { get; protected set; }

    public void SetShortName(string shortName)
    {
        if (string.IsNullOrEmpty(shortName))
        {
            throw new DomainException(ErrorCodes.InvalidItemName, "Short name cannot be empty.");
        }

        if (shortName == ShortName)
        {
            return;
        }

        ShortName = shortName;
    }

    public void SetItemType(ItemType itemType)
    {
        if (itemType == ItemType)
        {
            return;
        }

        ItemType = itemType;
    }

    public void SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new DomainException(ErrorCodes.InvalidItemName, "Name cannot be empty.");
        }

        if (name == Name)
        {
            return;
        }

        Name = name;
    }
}