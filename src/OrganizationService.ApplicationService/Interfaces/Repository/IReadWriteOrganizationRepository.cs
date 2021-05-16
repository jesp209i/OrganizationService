namespace OrganizationService.ApplicationService.Interfaces.Repository
{
    public interface IReadWriteOrganizationRepository : IReadOnlyOrganizationRepository, IWriteOnlyOrganizationRepository
    {
    }
}
