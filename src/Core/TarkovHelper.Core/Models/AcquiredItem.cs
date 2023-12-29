namespace TarkovHelper.Core.Models;

public class AcquiredItem : ItemDetails
{
    public AcquiredItem()
    {
    }

    public AcquiredItem(Item item, int count, bool isFoundInRaid) : base(item, count, isFoundInRaid)
    {
    }
}