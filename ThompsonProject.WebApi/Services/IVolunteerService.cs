using ThompsonProject.WebApi.Models.Dtos;

namespace ThompsonProject.WebApi.Services;

internal interface IVolunteerService
{
    Task<VolunteerDto[]> ListVolunteersAsync();
}