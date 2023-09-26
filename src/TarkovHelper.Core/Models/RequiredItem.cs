namespace TarkovHelper.Core.Models;

public class RequiredItem : ItemDetails
{
    public RequiredItem()
    {
    }

    public RequiredItem(Item item, int count, bool isFoundInRaid) : base(item, count, isFoundInRaid)
    {
    }
    
}