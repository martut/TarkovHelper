namespace TarkovHelper.Core.Models;

public class Stash
{
    private ISet<ItemDetails> _neededItems = new HashSet<ItemDetails>();

    public int Id { get; set; }

    public int UserId { get; set; }

    public IEnumerable<ItemDetails> NeededItems
    {
        get => _neededItems;
        set => _neededItems = new HashSet<ItemDetails>(value);
    }

    public Stash()
    {
    }

    public Stash(User user)
    {
        UserId = user.Id;
    }
}