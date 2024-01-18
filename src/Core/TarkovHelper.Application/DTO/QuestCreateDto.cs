namespace TarkovHelper.Application.DTO;

public class QuestCreateDto
{
    public string Name { get; set; }

    public string Trader { get; set; }

    public bool IsActive { get; set; }

    public IEnumerable<RequiredItemCreateDto> RequiredItem { get; set; }
}