using Microsoft.EntityFrameworkCore;

using ThompsonProject.WebApi.Models.Dtos;

namespace ThompsonProject.WebApi.DbContexts;

public class ThompsonContext : DbContext
{
    public DbSet<EventDto> Events { get; set; }
    public DbSet<VolunteerDto> Volunteers { get; set; }

    public ThompsonContext(DbContextOptions options) : base(options)
    {
    }
}