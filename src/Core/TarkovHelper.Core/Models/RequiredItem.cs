namespace TarkovHelper.Core.Models;

public class RequiredItem : BaseItem
{
    public RequiredItem()
    {
    }

    public RequiredItem(int count, bool isFoundInRaid) : base(count, isFoundInRaid)
    {
    }

    public static RequiredItem Create(bool isFoundInRaid, int count)
        => new RequiredItem(count, isFoundInRaid);
}