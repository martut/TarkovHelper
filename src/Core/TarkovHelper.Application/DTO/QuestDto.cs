namespace TarkovHelper.Application.DTO;

public class QuestDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Trader { get; set; }

    public bool IsActive { get; set; }

    public IEnumerable<RequiredItemDto> RequiredItems { get; set; }
}