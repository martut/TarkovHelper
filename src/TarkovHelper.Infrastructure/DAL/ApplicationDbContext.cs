using Microsoft.EntityFrameworkCore;
using TarkovHelper.Core.Models;

namespace TarkovHelper.Infrastructure.DAL;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Item> Items { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Quest> Quests { get; set; }

    public DbSet<Stash> Stashes { get; set; }

    public DbSet<AcquiredItem> AcquiredItems { get; set; }

    public DbSet<RequiredItem> RequiredItems { get; set; }

    public DbSet<UserQuest> UserQuests { get; set; }

    public DbSet<UserStash> UserStashes { get; set; }
}