namespace TarkovHelper.Application.DTO;

public class RequiredItemCreateDto
{
    public int ItemId { get; set; }

    public int Count { get; set; }

    public bool IsFoundInRaid { get; set; }
}