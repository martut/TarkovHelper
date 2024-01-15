namespace TarkovHelper.Core.Models;

public class AcquiredItem : BaseItem
{
    public int UserId { get; set; }
    
    public AcquiredItem()
    {
    }

    public AcquiredItem(User user, Item item, int count, bool isFoundInRaid) 
        : base(item, count, isFoundInRaid)
    {
        UserId = user.Id;
    }
}