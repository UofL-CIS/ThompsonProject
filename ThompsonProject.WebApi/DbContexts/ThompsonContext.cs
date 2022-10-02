using Microsoft.EntityFrameworkCore;

using ThompsonProject.WebApi.Models.Dtos;

namespace ThompsonProject.WebApi.DbContexts;

public class ThompsonContext : DbContext
{
    private static string s_connStr;

    public DbSet<EventDto> Events { get; set; }
    public DbSet<VolunteerDto> Volunteers { get; set; }

    public ThompsonContext(IConfiguration config)
    {
        s_connStr = config.GetConnectionString("Thompson");
    }

    public ThompsonContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(s_connStr,
            ServerVersion.AutoDetect(s_connStr));

        base.OnConfiguring(optionsBuilder);
    }
}