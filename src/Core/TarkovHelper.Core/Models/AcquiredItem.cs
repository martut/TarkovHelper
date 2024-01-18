namespace TarkovHelper.Core.Models;

public class AcquiredItem : BaseItem
{
    public AcquiredItem()
    {
    }

    public AcquiredItem(User user, int count, bool isFoundInRaid)
        : base(count, isFoundInRaid)
    {
        UserId = user.Id;
    }

    public int UserId { get; set; }
}