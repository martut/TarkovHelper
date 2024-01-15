namespace TarkovHelper.Core.Models;

public class Stash
{
    private ISet<RequiredItem> _neededItems = new HashSet<RequiredItem>();

    public int Id { get; set; }

    public int UserId { get; set; }

    public IEnumerable<RequiredItem> NeededItems
    {
        get => _neededItems;
        set => _neededItems = new HashSet<RequiredItem>(value);
    }

    public Stash()
    {
    }

    public Stash(User user)
    {
        UserId = user.Id;
    }
}