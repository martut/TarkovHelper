namespace TarkovHelper.Core.Models;

public class UserStash
{
    public int Id { get; set; }
    
    public int UserId { get; set; }

    public int StashId { get; set; }

    public UserStash()
    {
    }
    
    public UserStash(User user, Stash stash)
    {
        UserId = user.Id;
        StashId = stash.Id;
    }
}