using TarkovHelper.Core.Domain;

namespace TarkovHelper.Core.Models;

public class ItemDetails
{
    public int Id { get; protected set; }

    public Item Item { get; protected set; }

    public int Count { get; protected set; }

    public bool IsFoundInRaid { get; protected set; }

    protected ItemDetails()
    {
    }

    public ItemDetails(Item item, int count, bool isFoundInRaid)
    {
        SetCount(count);
        IsFoundInRaid = isFoundInRaid;
        Item = item;
    }

    public void SetCount(int count)
    {
        if (count < 1)
        {
            throw new DomainException(ErrorCodes.InvalidItemCount, "Item count must be greater then 0.");
        }

        Count = count;
    }
}