using ThompsonProject.WebApi.DbContexts;
using ThompsonProject.WebApi.Models.Dtos;

namespace ThompsonProject.WebApi.Services;

internal class VolunteerService : IVolunteerService
{
    private readonly ThompsonContext _ctx;

    public VolunteerService(ThompsonContext ctx)
    {
        _ctx = ctx;
    }

    public Task<VolunteerDto[]> ListVolunteersAsync()
    {
        return Task.FromResult(_ctx.Volunteers.ToArray());
    }
}