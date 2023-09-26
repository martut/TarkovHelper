using TarkovHelper.Core.Domain;
using TarkovHelper.Core.Models.Enums;

namespace TarkovHelper.Core.Models;

public class Quest
{
    public int Id { get; set; }
    
    private ISet<RequiredItem> _requiredItems = new HashSet<RequiredItem>();

    public string Name { get; protected set; }

    public Trader Trader { get; protected set; }

    public bool IsCompleted { get; protected set; }

    public IEnumerable<RequiredItem> RequiredItems
    {
        get => _requiredItems;
        set => _requiredItems = new HashSet<RequiredItem>(value);
    }

    public Quest()
    {
    }

    public Quest(string name, Trader trader, bool isCompleted)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new DomainException(ErrorCodes.InvalidQuest, "Quest name cannot be empty.");
        }
    }
}