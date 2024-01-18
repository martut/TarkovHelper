namespace TarkovHelper.Application.DTO;

public class RequiredItemDto
{
    public int Id { get; set; }

    public ItemDto Item { get; set; }

    public int Count { get; set; }

    public bool IsFoundInRaid { get; set; }
}