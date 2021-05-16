namespace OrganizationService.ApplicationService.Interfaces.Mapper
{
    public interface IMapper<Tin, Tout>
    {
        IMapper<Tin, Tout> Map(Tin input);
        Tout ToOutFormat();
    }
}
