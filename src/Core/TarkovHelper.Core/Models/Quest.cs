using TarkovHelper.Core.Exceptions;
using TarkovHelper.Core.Models.Enums;

namespace TarkovHelper.Core.Models;

public class Quest
{
    private ISet<RequiredItem> _requiredItems = new HashSet<RequiredItem>();

    public Quest()
    {
    }

    public Quest(string name, Trader trader, bool isActive)
    {
        SetName(name);
        SetTrader(Trader);

        if (isActive)
            Activate();
        else
            Deactivate();
    }

    public int Id { get; protected set; }

    public string Name { get; protected set; }

    public Trader Trader { get; protected set; }

    public bool IsActive { get; protected set; }

    public IEnumerable<RequiredItem> RequiredItems
    {
        get => _requiredItems;
        set => _requiredItems = new HashSet<RequiredItem>(value);
    }

    public void SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new DomainException(ErrorCodes.InvalidQuestName,
                "Name cannot be empty.");
        }

        if (name == Name)
        {
            return;
        }

        Name = name;
    }

    public void SetTrader(Trader trader)
    {
        if (trader == Trader)
        {
            return;
        }

        Trader = trader;
    }

    public void Activate()
    {
        if (IsActive)
        {
            return;
        }

        IsActive = true;
    }

    public void Deactivate()
    {
        if (!IsActive)
        {
            return;
        }

        IsActive = false;
    }

    public void AddRequiredItem(RequiredItem requiredItem)
    {
        var item = GetRequiredItemByItemId(requiredItem.Item.Id);
        if (item != null)
        {
            throw new DomainException(ErrorCodes.RequiredItemExists,
                $"Required item: {requiredItem.Item.Name} already exists for quest: {Name}");
        }

        _requiredItems.Add(requiredItem);
    }

    private RequiredItem? GetRequiredItemByItemId(int itemId)
        => _requiredItems.SingleOrDefault(r => r.Item.Id == itemId);
}