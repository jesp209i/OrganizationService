using AutoFixture;
using AutoFixture.Xunit2;
using System.Linq;

namespace ApplicationServiceTest.Helpers
{
    internal class EntityAutoDataAttribute : AutoDataAttribute
    {
        public EntityAutoDataAttribute() : base(() => new Fixture().Customize(new EntityAutoDataCustomization()))
        {
        }
    }

    internal class EntityAutoDataCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {

            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                    .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            fixture.Customizations.Add(new OrganizationMemberGenerator());
        }
    }
}