using TarkovHelper.Core.Domain;
using TarkovHelper.Core.Models.Enums;

namespace TarkovHelper.Core.Models;

public class Item
{
    public int Id { get; protected set; }
    
    public string Name { get; protected set; }

    public ItemType Type { get; protected set; }

    public Item()
    {
    }

    public Item(string name, ItemType type)
    {
        SetName(name);
        SetType(type);
    }

    private void SetType(ItemType type)
    {
        if (type == Type)
        {
            return;
        }

        Type = type;
    }

    private void SetName(string name)
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