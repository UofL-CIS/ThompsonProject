using ThompsonProject.WebApi.Models.Dtos;

namespace ThompsonProject.WebApi.Repos.Abstractions;

public interface IVolunteerRepo
{
    public Task<IEnumerable<VolunteerDto>> ReadAllVolunteersAsync();
}
