using ThompsonProject.WebApi.Models.Dtos;
using ThompsonProject.WebApi.Repos.Abstractions;

namespace ThompsonProject.WebApi.Repos.Concretions;

public class VolunteerDal : BaseDal, IVolunteerRepo
{
    public VolunteerDal(IConfiguration configuration) : base(configuration)
    {
    }

    public Task<IEnumerable<VolunteerDto>> ReadAllVolunteersAsync()
    {
        return ExecuteQueryStoredProcedureAsync<VolunteerDto>("spAllVolunteers", null);
    }
}
