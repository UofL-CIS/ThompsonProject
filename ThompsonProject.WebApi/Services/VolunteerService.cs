using ThompsonProject.WebApi.Models.Dtos;
using ThompsonProject.WebApi.Repos.Abstractions;

namespace ThompsonProject.WebApi.Services;

internal class VolunteerService : IVolunteerService
{
    private readonly IVolunteerRepo _repo;

    public VolunteerService(IVolunteerRepo ctx)
    {
        _repo = ctx;
    }

    public async Task<VolunteerDto[]> ListVolunteersAsync()
    {
        return (await _repo.ReadAllVolunteersAsync()).ToArray();
    }
}