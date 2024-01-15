namespace TarkovHelper.Core.Models;

public class UserQuest
{
    public int Id { get; set; }
    
    public int UserId { get; set; }

    public int QuestId { get; set; }

    public UserQuest()
    {
    }

    public UserQuest(User user, Quest quest)
    {
        UserId = user.Id;
        QuestId = quest.Id;
    }
}